using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TestingProject.Entities;
using TestingProject.Logs;
using static TestingProject.Enums.EventTypes;

namespace TestingProject.CommonFunctions
{
    class ReadJson
    {

        public EntCommons ReadJsonFile()
        {
            string completePath = Path.Combine(@"C:\Learning_Plan\Practices\CSharp_SpecflowSelenium\TestingProject\CommonData\CommonData.json");
            EntCommons result = new EntCommons();
            try
            {
                StreamReader streamReader = new StreamReader(completePath);
                string jsonData = streamReader.ReadToEnd();
                streamReader.Close();

                result = JsonConvert.DeserializeObject<EntCommons>(jsonData);
            }
            catch (Exception ex)
            {
                Log.AddEvent(ex.Message , LogType.ERROR);
            }
            return result;

        }
    }
}
