using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gympass.Domain.Model
{
    public class TemplateConfigModel
    {
        [JsonProperty(PropertyName = "field")]
        public string field { get; set; }

        [JsonProperty(PropertyName = "startIndex")]
        public string startIndex { get; set; }

        [JsonProperty(PropertyName = "length")]
        public string length { get; set; }
    }

    public class RootObject
    {
        [JsonProperty("Template")]
        public List<TemplateConfigModel> Results { get; set; }
    }
}
