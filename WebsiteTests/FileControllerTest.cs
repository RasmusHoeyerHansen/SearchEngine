
using System;
using System.IO;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using PreProcessing.Common.Exceptions;
using PreProcessing.Common.Services;
using Website.Controllers;

namespace WebsiteTests
{
    public class FileControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Post_CorrectParse_Gives_OkResult()
        {
            IKnowledgeFromTextService<Stream> extractor = Substitute.For<IKnowledgeFromTextService<Stream>>();
            var controller = new FileController(extractor);
            var form = CreateFileMock();
            extractor.ExtractKnowledge(form.OpenReadStream());

            var response = controller.PostFile(form);
            Assert.IsInstanceOf<OkResult>(response);
        }

        [Test]
        public void Post_IncorrectForm_Gives_BadRequest()
        {
            IKnowledgeFromTextService<Stream> extractor = Substitute.For<IKnowledgeFromTextService<Stream>>();
            var controller = new FileController(extractor);
            var form = CreateFailingFileMock();

            var response = controller.PostFile(form);
            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }

        [Test]
        public void Post_FailedParse_Gives_BadRequestObjectResult()
        {
            IKnowledgeFromTextService<Stream> extractor = Substitute.For<IKnowledgeFromTextService<Stream>>();
            var file = CreateFileMock();
            extractor.When(x => x.ExtractKnowledge(file.OpenReadStream()))
                .Do(x => throw new PdfParsingException());

            var controller = new FileController(extractor);
            var response = controller.PostFile(file);

            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }

        public static IFormFile CreateFileMock()
        {
            var fileMock = Substitute.For<IFormFile>();
            //Setup mock file using a memory stream
            string content = "Hello World from a Fake File";
            string fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.OpenReadStream().Returns(ms);
            fileMock.FileName.Returns(fileName);
            fileMock.Length.Returns(ms.Length);
            return fileMock;
        }

        public static IFormFile CreateFailingFileMock()
        {
            var fileMock = Substitute.For<IFormFile>();
            //Setup mock file using a memory stream
            string content = "Hello World from a Fake File";
            string fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.When(x => x.OpenReadStream()).Do(x => { throw new Exception(); });
            fileMock.FileName.Returns(fileName);
            fileMock.Length.Returns(ms.Length);

            return fileMock;
        }
    }
}