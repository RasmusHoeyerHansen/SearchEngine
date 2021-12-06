using System;
using System.IO;
using System.Web.Http.Results;
using KnowledgeExtraction.Common.Communication;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing.Parsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeExtraction.Preprocessing.FileReceivers
{
    [ApiController]
    [Route("[controller]")]
    internal class FileController : ControllerBase, IFileReceiver<PdfArticle>
    {
        private readonly IExtractor<Stream,PdfArticle> ArticleExtractor;
        public event Action<PdfArticle>? FileReceived;

        public FileController(IExtractor<Stream,PdfArticle> extractor)
        {
            this.ArticleExtractor = extractor;
        }
        
        [HttpPost, Route("/[controller]/Extract")]
        public IActionResult PostFile(IFormFile file)
        {
            IActionResult result;
            try
            {
                Stream? stream = file.OpenReadStream();
                var x = ArticleExtractor.Extract(stream);
                FileReceived?.Invoke(x);
                result = Ok();
            }
            catch (PdfParsingException e)
            {
                result = BadRequest(e.Message);
            }
            catch (Exception e)
            {
                result = BadRequest("Corrupted File");
            }

            return result;
        }
    }

}