using GetOnGiphyAPI.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace GetOnGiphyAPI.Utils
{
    public class GiphyParser
    {
        public IEnumerable<GiphyResult> ParseMemes(JObject giphyContent)
        {
            return giphyContent["data"]
                .Select(item => new GiphyResult
                {
                    Extension = item["type"].ToString(),
                    Title = item["title"].ToString(),
                    Url = item["images"]["downsized_large"]["url"].ToString()
                });
        }
    }
}
