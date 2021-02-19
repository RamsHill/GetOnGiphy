using GetOnGiphyAPI.Models;
using GetOnGiphyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GetOnGiphyAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GiphyController : ControllerBase
    {
        private readonly ILogger<GiphyController> _logger;
        const int DEFAULT_AMOUNT = 5;

        public GiphyController(ILogger<GiphyController> logger)
        {
            _logger = logger;
        }

        // GET: <GiphyController>
        [HttpGet]
        public string Get()
        {
            string warning = "API made in 1 hour and 38 minutes by a dude who never made even a simple .NET console application. #NeverStopLearning! \n ~ Aaron Carneiro (@euaaron)";
            return warning;
        }        

        // GET <GiphyController>/Aang
        [HttpGet("{searchString}")]
        public async Task<IEnumerable<GiphyResult>> Get(string searchString)
        {
            var memes = new GiphyRobotService();
            var resultSet = await memes.GetMemes(searchString, DEFAULT_AMOUNT);
            return resultSet;
        }

        // GET <GiphyController>/Aang/15
        [HttpGet("{searchString}/{amount}")]
        public async Task<IEnumerable<GiphyResult>> Get(string searchString, int amount = DEFAULT_AMOUNT)
        {
            var memes = new GiphyRobotService();
            var resultSet = await memes.GetMemes(searchString, amount);
            return resultSet;
        }

    }
}
