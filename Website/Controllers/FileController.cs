﻿using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreProcessingTest.Common.Exceptions;
using PreProcessingTest.Common.Services;

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