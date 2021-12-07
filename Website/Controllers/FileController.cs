using System;
using System.IO;
using KnowledgeExtraction.Common.Exceptions;
using KnowledgeExtraction.Common.Services;
using KnowledgeExtraction.Preprocessing;
using KnowledgeExtraction.Preprocessing.Parsers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IPreProcessingService<Stream> ExtractionService;

        public FileController(IPreProcessingService<Stream> extractionService)
        {
            ExtractionService = extractionService;
        }


        [HttpGet]
        [Route("/[controller]/")]
        public IActionResult GetFile()
        {
            Console.WriteLine("HEREEE");
            return Ok("HEY");
        }

        [HttpPost]
        [Route("/[controller]/Extract")]
        public IActionResult PostFile(IFormFile file)
        {
            IActionResult result = Ok();
            try
            {
                ExtractionService.PreprocessKnowledge(file.OpenReadStream());
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