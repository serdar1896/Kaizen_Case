using ConvertSaasJson.Core.Services;
using ConvertSaasJson.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConvertSaasJson.Services
{
    public class ConverterService:IConverterService
    {

        public IEnumerable<TextModel> ConvertToTextWithLine(List<JsonRequestModel> saaSjson)
        {
            var resultModel = new List<TextModel>();

            for (int i = 1; i < saaSjson.Count; i++)
            {
                var oldLine = resultModel.FirstOrDefault(x => Math.Abs(x.Y_Coord - saaSjson[i].boundingPoly.vertices[0].y) < 10);
                if (oldLine!=null)
                {
                    oldLine.Text +=  (" " + saaSjson[i].description);
                }
                else
                {
                    resultModel.Add(new TextModel()
                    {
                        Line = resultModel.Count + 1,
                        Text = saaSjson[i].description,  
                        Y_Coord = saaSjson[i].boundingPoly.vertices[0].y
                    });
                }
            }

            CreateTextFile(resultModel);

            return resultModel;
        }

        public bool CreateTextFile(List<TextModel> textModel)
        {
            string fileName = ".\\DataLayer\\Data\\SaaS_Text.txt";

            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            fs.Close();

            foreach (var textLine in textModel)
            {
                File.AppendAllText(fileName, Environment.NewLine + textLine.Text);
            }

            return true;
        }


    }
}
