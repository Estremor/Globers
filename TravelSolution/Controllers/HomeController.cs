using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Globers.Models;

namespace Globers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync("api/Autor");
            IEnumerable<AutorModel> autors = new List<AutorModel>();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                autors = JsonConvert.DeserializeObject<IEnumerable<AutorModel>>(response);
            }
            return View(autors);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
