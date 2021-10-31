using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Globers.Models;

namespace Globers.Controllers
{
    public class EditorialAppController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public EditorialAppController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: EditorialAppController
        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync("api/Editorial");
            IEnumerable<EditorialModel> editorial = new List<EditorialModel>();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                editorial = JsonConvert.DeserializeObject<IEnumerable<EditorialModel>>(response);
            }
            return View(editorial);
        }

        // GET: EditorialAppController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync($"api/Editorial/{id}");
            EditorialModel editorial = new();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                editorial = JsonConvert.DeserializeObject<EditorialModel>(response);
            }
            return View(editorial);
        }

        // GET: EditorialAppController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditorialAppController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EditorialModel model)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                var result = await client.PostAsJsonAsync($"api/Editorial/", model);
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

        // GET: EditorialAppController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                var result = await client.GetAsync($"api/Editorial/{id}");
                EditorialModel editorial = new();
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    editorial = JsonConvert.DeserializeObject<EditorialModel>(response);
                }
                return View(editorial);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(HomeController.Error), "Home", e.Message);
            }
        }

        // POST: EditorialAppController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditorialModel model)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                StringContent content = new(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var result = await client.PutAsync($"api/Editorial/{id}", content);

                EditorialModel editorial = new();
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

        // GET: EditorialAppController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync($"api/Editorial/{id}");
            EditorialModel editorial = new();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                editorial = JsonConvert.DeserializeObject<EditorialModel>(response);
            }
            return View(editorial);
        }

        // POST: EditorialAppController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, EditorialModel model)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                var result = await client.DeleteAsync($"api/Editorial/{id}");
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
