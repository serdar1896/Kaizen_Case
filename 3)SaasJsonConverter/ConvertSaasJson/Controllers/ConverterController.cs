using ConvertSaasJson.Core.Services;
using ConvertSaasJson.DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConvertSaasJson.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConverterController : Controller
    {
        private readonly IConverterService _converterService;
        public ConverterController(IConverterService converterService)
        {
            _converterService = converterService;
        }

        [HttpPatch]
        [Route("ConvertJsonToText")]
        public IActionResult ConvertJsonToText([FromBody] List<JsonRequestModel> saaSjson)
        {

           var result = _converterService.ConvertToTextWithLine(saaSjson);


            return Ok(result);
        }
    }
}
