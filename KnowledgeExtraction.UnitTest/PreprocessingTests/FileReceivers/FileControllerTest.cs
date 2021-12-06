using System;
using System.IO;
using System.IO.Enumeration;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing.FileReceivers;
using KnowledgeExtraction.Preprocessing.Parsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Tls;
using BadRequestResult = System.Web.Http.Results.BadRequestResult;

namespace ExtractorTests.PreprocessingTests.FileReceivers
{
    public class FileControllerTest :PdfCreator
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Post_CorrectParse_Gives_OkResult()
        {
            IExtractor<Stream, PdfArticle> extractor = Substitute.For<IExtractor<Stream, PdfArticle>>();
            FileController controller = new FileController(extractor);
            var form = CreateFileMock();
            extractor.Extract(form.OpenReadStream())
                .Returns(new PdfArticle(new string[] {"a", "b"}, "test title"));
            
            var response = controller.PostFile(form);
            Assert.IsInstanceOf<OkResult>(response);
        }
        
        [Test]
        public void Post_IncorrectForm_Gives_BadRequest()
        {
            IExtractor<Stream, PdfArticle> extractor = Substitute.For<IExtractor<Stream, PdfArticle>>();
            FileController controller = new FileController(extractor);
            var form = CreateFailingFileMock();

            var response = controller.PostFile(form);
            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }
        
        [Test]
        public void Post_FailedParse_Gives_BadRequestObjectResult()
        {
            IExtractor<Stream, PdfArticle> extractor = Substitute.For<IExtractor<Stream, PdfArticle>>();
            IFormFile file = CreateFileMock();
            extractor.
                When(x => x.Extract(file.OpenReadStream()))
                .Do(x => throw new PdfParsingException());
            
            FileController controller = new FileController(extractor);
            IActionResult response = controller.PostFile(file);
            
            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }

        public static IFormFile CreateFileMock()
        {
            IFormFile fileMock = Substitute.For<IFormFile>();
            //Setup mock file using a memory stream
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
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
            IFormFile fileMock = Substitute.For<IFormFile>();
            //Setup mock file using a memory stream
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.When(x => x.OpenReadStream()).Do(x =>
            {
                throw new Exception();
            });
            fileMock.FileName.Returns(fileName);
            fileMock.Length.Returns(ms.Length);
            
            return fileMock;
        }

    }
}