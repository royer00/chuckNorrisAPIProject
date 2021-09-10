using ChuckNorrisDisplayProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChuckNorrisDisplayProject.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private static readonly HttpClient client = new HttpClient();

        private static async Task<string> GetSingleChuckJoke()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var joke =  await client.GetStringAsync("https://api.chucknorris.io/jokes/random");
            
            return joke;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetRandomChuckNorrisJoke()
        {
            var jokeModel = new ChuckNorrisJokeModel();
            jokeModel = JsonConvert.DeserializeObject<ChuckNorrisJokeModel>(await GetSingleChuckJoke());
            return View(jokeModel);
        }
    }
}
