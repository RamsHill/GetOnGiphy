using GetOnGiphyAPI.Models;
using GetOnGiphyAPI.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace GetOnGiphyAPI.Services
{
    public class GiphyRobotService
    {
        private static readonly HttpClient httpClient = new HttpClient();

        public const string BASE_WEBSITE_ADDRESS = "https://api.giphy.com/v1/gifs/search?api_key=3eFQvabDx69SMoOemSPiYfh9FY0nzO9x&offset=0";

        public async Task<IEnumerable<GiphyResult>> GetMemes(string searchTerm, int amount)
        {
            var response = await httpClient.GetAsync($"{BASE_WEBSITE_ADDRESS}&q={GetUrlEncodedSearchTerm(searchTerm)}&limit={amount}");
            response.EnsureSuccessStatusCode();
            var mainPageHtmlContent = await response.Content.ReadAsStringAsync();
            var giphyContent = JsonConvert.DeserializeObject<JObject>(mainPageHtmlContent);
            var giphyParser = new GiphyParser();
            return giphyParser.ParseMemes(giphyContent);

        }

        public static string GetUrlEncodedSearchTerm(string searchTerm)
        {
            return HttpUtility.UrlEncode(searchTerm);
        }
    }
}
