using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreProcessing.Common.Exceptions;
using PreProcessing.Common.Services;

namespace Website.Controllers
{
    [ApiController, Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IKnowledgeFromTextService<Stream> ExtractionFromTextService;

        public FileController(IKnowledgeFromTextService<Stream> extractionFromTextService)
        {
            ExtractionFromTextService = extractionFromTextService;
        }

        [HttpPost]
        [Route("/[controller]/Extract")]
        public IActionResult PostFile(IFormFile file)
        {
            IActionResult result = Ok();
            try
            {
                ExtractionFromTextService.ExtractKnowledge(file.OpenReadStream());
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