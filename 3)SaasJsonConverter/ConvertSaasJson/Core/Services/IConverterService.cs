using ConvertSaasJson.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConvertSaasJson.Core.Services
{
    public interface IConverterService
    {
        IEnumerable<TextModel> ConvertToTextWithLine(List<JsonRequestModel> saaSjson);
    }
}
