using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SourceQubeRulesExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = @"https://sonarcloud.io/api/rules/search?";

            var rules = new List<Rule>();

            var result = GetSearchResultContents(url);

            rules.AddRange(result.Rules);

            while (result.Total > (result.Ps * result.P))
            {
                var page = result.P + 1;
                result = GetSearchResultContents($"{url}&p={page}");

                rules.AddRange(result.Rules);
            }

        }

        private static RulesSearchResult GetSearchResultContents(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var json = httpClient.GetStringAsync(url).Result;

                //return JObject.Parse(json);

                return JsonConvert.DeserializeObject<RulesSearchResult>(json);
            }
        }
    }

}
