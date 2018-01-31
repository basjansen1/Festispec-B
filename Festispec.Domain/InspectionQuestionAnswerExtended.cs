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
                return table.Select(row => new List<string> {row[0].ToString(), row[1].ToString()}).ToList();
            }
            catch
            {
                return new List<List<string>>
                {
                    new List<string> {"", ""},
                    new List<string> {"", ""},
                    new List<string> {"", ""},
                    new List<string> {"", ""},
                    new List<string> {"", ""},
                    new List<string> {"", ""}
                };
            }
        }

        public List<List<string>> DeserializeBeeldAnswer()
        {
            return DeserializeBeeldAnswer(Answer);
        }
        public List<List<string>> DeserializeBeeldAnswer(string answer)
        {
            try
            {
                var table = (JArray)JsonConvert.DeserializeObject(answer);
                return table.Select(row => new List<string> { row[0].ToString(), row[1].ToString() }).ToList();
            }
            catch
            {
                return new List<List<string>>();
            }
        }
    }
}