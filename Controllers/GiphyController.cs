using GetOnGiphyAPI.Models;
using GetOnGiphyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GetOnGiphyAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class GiphyController : ControllerBase
    {
        private readonly ILogger<GiphyController> _logger;
        const int DEFAULT_AMOUNT = 5;

        public GiphyController(ILogger<GiphyController> logger)
        {
            _logger = logger;
        }

        // GET: /
        [HttpGet]
        public string Get()
        {
            string warning = "You need to provide a search string and you can define a return amount. \n" +
                "Ex.: \n" +
                "https://api.geton-giphy.euaaron.codes/Rocambole/6" +
                "\n\n\n\n" +
                "You may find a documentation at 'https://api.geton-giphy.euaaron.codes/swagger/' \n" +
                "API made in 1 hour and 38 minutes by a dude who never made even a simple .NET console application. " +
                "#NeverStopLearning! \n" +
                "~ Aaron Carneiro (@euaaron)";
            return warning;
        }        

        // GET /Rocambole
        [HttpGet("{searchString}")]
        public async Task<IEnumerable<GiphyResult>> Get(string searchString)
        {
            var memes = new GiphyRobotService();
            var resultSet = await memes.GetMemes(searchString, DEFAULT_AMOUNT);
            return resultSet;
        }

        // GET /Aang/15
        [HttpGet("{searchString}/{amount}")]
        public async Task<IEnumerable<GiphyResult>> Get(string searchString, int amount = DEFAULT_AMOUNT)
        {
            var memes = new GiphyRobotService();
            var resultSet = await memes.GetMemes(searchString, amount);
            return resultSet;
        }

    }
}
