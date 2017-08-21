using Newtonsoft.Json;

namespace SourceQubeRulesExtractor
{
    internal class Param
    {

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("htmlDesc")]
        public string HtmlDesc { get; set; }

        [JsonProperty("defaultValue")]
        public string DefaultValue { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

}
