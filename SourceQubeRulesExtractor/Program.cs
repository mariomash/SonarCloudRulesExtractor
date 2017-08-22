using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using ServiceStack.Text;

namespace SonarCloudRulesExtractor
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

            File.AppendAllText("rules.csv", CsvSerializer.SerializeToString<List<Rule>>(rules));

        }

        private static RulesSearchResult GetSearchResultContents(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var json = httpClient.GetStringAsync(url).Result;

                return JsonConvert.DeserializeObject<RulesSearchResult>(json);
            }
        }
    }

}
