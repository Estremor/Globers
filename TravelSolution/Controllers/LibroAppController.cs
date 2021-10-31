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
    public class LibroAppController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public LibroAppController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: LibroAppController
        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync("api/Libro");
            IEnumerable<LibroModel> libros = new List<LibroModel>();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                libros = JsonConvert.DeserializeObject<IEnumerable<LibroModel>>(response);
            }
            return View(libros);
        }

        // GET: LibroAppController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync($"api/Libro/{id}");
            LibroModel libro = new();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                libro = JsonConvert.DeserializeObject<LibroModel>(response);
            }
            return View(libro);
        }

        // GET: LibroAppController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibroAppController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LibroModel model)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                var result = await client.PostAsJsonAsync($"api/Libro/", model);
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

        // GET: LibroAppController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                var result = await client.GetAsync($"api/Libro/{id}");
                LibroModel libro = new();
                if (result.IsSuccessStatusCode)
                {
                    var response = await result.Content.ReadAsStringAsync();
                    libro = JsonConvert.DeserializeObject<LibroModel>(response);
                }
                return View(libro);
            }
            catch (Exception e)
            {
                return RedirectToAction(nameof(HomeController.Error), "Home", e.Message);
            }
        }

        // POST: LibroAppController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LibroModel model)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                StringContent content = new(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var result = await client.PutAsync($"api/Libro/{id}", content);
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

        // GET: LibroAppController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync($"api/Libro/{id}");
            LibroModel libro = new();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                libro = JsonConvert.DeserializeObject<LibroModel>(response);
            }
            return View(libro);
        }

        // POST: LibroAppController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, LibroModel model)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                var result = await client.DeleteAsync($"api/Libro/{id}");
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
