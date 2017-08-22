using Newtonsoft.Json;

namespace SonarCloudRulesExtractor
{
    internal class RulesSearchResult
    {

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("p")]
        public int P { get; set; }

        [JsonProperty("ps")]
        public int Ps { get; set; }

        [JsonProperty("rules")]
        public Rule[] Rules { get; set; }
        
    }

}
