using System;
using System.IO;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Common.Models;
using KnowledgeExtraction.Preprocessing.Parsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeExtraction.Common.Communication.FileReceivers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase, IFileWatcherObservable<PdfArticle>
    {
        private readonly IExtractor<Stream,PdfArticle> ArticleExtractor;
        public event Action<PdfArticle>? FileReceived;

        public FileController(IHttpFormInputObserver<PdfArticle> httpInputObservable)
        {

        }

        public FileController(IExtractor<Stream,PdfArticle> extractor)
        {
            this.ArticleExtractor = extractor;
        }

        [HttpGet, Route("/[controller]/")]
        public IActionResult GetFile()
        {
            Console.WriteLine("HEREEE");
            return Ok("HEY");
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