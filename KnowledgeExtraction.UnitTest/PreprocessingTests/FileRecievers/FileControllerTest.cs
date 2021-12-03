using System.IO;
using System.Web.Http.Results;
using KnowledgeExtraction.Common.Communication;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing.FileReceivers;
using KnowledgeExtraction.Preprocessing.Parsers;
using Microsoft.AspNetCore.Http.Internal;
using NSubstitute;
using NUnit.Framework;

namespace ExtractorTests.PreprocessingTests.FileRecievers
{
    public class FileControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        public void Post_CorrectForm_Gives_OkResult()
        {
            IExtractor<Stream, PdfArticle> extractor = Substitute.For<IExtractor<Stream, PdfArticle>>();
            FileController controller = new FileController(extractor);
            var form = new FormFile(null, 0, 0, null, null);

            var response = controller.PostFile(form);
            Assert.IsInstanceOf<OkResult>(response);
        }
        
        public void Post_IncorrectForm_Gives_BadRequest()
        {
            IExtractor<Stream, PdfArticle> extractor = Substitute.For<IExtractor<Stream, PdfArticle>>();
            FileController controller = new FileController(extractor);
            var form = new FormFile(null, 0, 0, null, null);

            var response = controller.PostFile(form);
            Assert.IsInstanceOf<BadRequestResult>(response);
        }
        
        public void Post_IncorrectStream_Gives_BadRequest()
        {
            IExtractor<Stream, PdfArticle> extractor = Substitute.For<IExtractor<Stream, PdfArticle>>();
            FileController controller = new FileController(extractor);
            var form = new FormFile(null, 0, 0, null, null);

            var response = controller.PostFile(form);
            Assert.IsInstanceOf<BadRequestResult>(response);
        }

    }
}