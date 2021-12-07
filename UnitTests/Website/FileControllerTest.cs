using System;
using System.IO;
using ExtractorTests.KnowledgeExtraction;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Common.Services;
using KnowledgeExtraction.Preprocessing;
using KnowledgeExtraction.Preprocessing.Parsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Website.Controllers;

namespace ExtractorTests.Website
{
    public class FileControllerTest : PdfCreator
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Post_CorrectParse_Gives_OkResult()
        {
            IPreProcessingService<Stream> extractor = Substitute.For<IPreProcessingService<Stream>>();
            var controller = new FileController(extractor);
            var form = CreateFileMock();
            extractor.PreprocessKnowledge(form.OpenReadStream());

            var response = controller.PostFile(form);
            Assert.IsInstanceOf<OkResult>(response);
        }

        [Test]
        public void Post_IncorrectForm_Gives_BadRequest()
        {
            IPreProcessingService<Stream> extractor = Substitute.For<IPreProcessingService<Stream>>();
            var controller = new FileController(extractor);
            var form = CreateFailingFileMock();

            var response = controller.PostFile(form);
            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }

        [Test]
        public void Post_FailedParse_Gives_BadRequestObjectResult()
        {
            IPreProcessingService<Stream> extractor = Substitute.For<IPreProcessingService<Stream>>();
            var file = CreateFileMock();
            extractor.When(x => x.PreprocessKnowledge(file.OpenReadStream()))
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