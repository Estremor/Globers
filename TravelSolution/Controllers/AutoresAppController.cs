using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Globers.Models;

namespace Globers.Controllers
{
    public class AutoresAppController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public AutoresAppController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: AutoresAppController
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

        // GET: AutoresAppController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync($"api/Autor/{id}");
            AutorModel autor = new();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                autor = JsonConvert.DeserializeObject<AutorModel>(response);
            }
            return View(autor);
        }

        // GET: AutoresAppController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutoresAppController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutorModel model)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                var result = await client.PostAsJsonAsync($"api/Autor/", model);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }
        }

        // GET: AutoresAppController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                var result = await client.GetAsync($"api/Autor/{id}");
                AutorModel autor = new();
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    autor = JsonConvert.DeserializeObject<AutorModel>(response);
                }
                return View(autor);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(HomeController.Error), "Home", e.Message);
            }
        }

        // POST: AutoresAppController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AutorModel model)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                StringContent content = new(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var result = await client.PutAsync($"api/Autor/{id}", content);

                AutorModel autor = new();
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }
        }

        // GET: AutoresAppController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync($"api/Autor/{id}");
            AutorModel autor = new();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                autor = JsonConvert.DeserializeObject<AutorModel>(response);
            }
            return View(autor);
        }

        // POST: AutoresAppController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AutorModel model)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                var result = await client.DeleteAsync($"api/Autor/{id}");
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }
            catch
            {
                return RedirectToAction(nameof(HomeController.Error), "Home");
            }
        }
    }
}
