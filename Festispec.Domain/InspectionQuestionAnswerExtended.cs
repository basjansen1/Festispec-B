using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Festispec.Domain
{
    public partial class InspectionQuestionAnswer
    {
        public List<List<string>> DeserializeTabelAnswer()
        {
            return DeserializeTabelAnswer(Answer);
        }
        public List<List<string>> DeserializeTabelAnswer(string answer)
        {
            try
            {
                var table = (JArray) JsonConvert.DeserializeObject(answer);
                return table.Select(row => new List<string> {row["column1"].ToString(), row["column2"].ToString()}).ToList();
            }
            catch
            {
                return new List<List<string>>
                {
                    new List<string> {"", ""},
                    new List<string> {"", ""},
                    new List<string> {"", ""},
                    new List<string> {"", ""},
                };
            }
        }

        //        private void SerializeMetadata(object deserializedAnswer)
        //        {
        //            Answer = JsonConvert.SerializeObject(deserializedAnswer);
        //        }
    }
}