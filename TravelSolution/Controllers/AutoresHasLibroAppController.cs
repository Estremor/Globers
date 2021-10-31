using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Globers.Models;

namespace Globers.Controllers
{
    public class AutoresHasLibroAppController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public AutoresHasLibroAppController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: AutoresHasLibroAppController
        public async Task<IActionResult> Index()
        {
            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync("api/AutoresHasLibro");
            IEnumerable<AutoresHasLibroModel> autors = new List<AutoresHasLibroModel>();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                autors = JsonConvert.DeserializeObject<IEnumerable<AutoresHasLibroModel>>(response);
            }
            return View(autors);
        }

        // GET: AutoresHasLibroAppController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync($"api/AutoresHasLibro/{id}");
            AutoresHasLibroModel autor = new();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                autor = JsonConvert.DeserializeObject<AutoresHasLibroModel>(response);
            }
            return View(autor);
        }

        // GET: AutoresHasLibroAppController/Create
        public async Task<IActionResult> Create()
        {
            #region ListselectedAutor
            List<SelectListItem> lstAutor = new();
            HttpClient clientAutor = _httpClient.CreateClient("Server");
            HttpResponseMessage result = await clientAutor.GetAsync("api/Autor");
            IEnumerable<AutorModel> autors = new List<AutorModel>();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                autors = JsonConvert.DeserializeObject<IEnumerable<AutorModel>>(response);
                autors.ToList().ForEach(autor => lstAutor.Add(new SelectListItem { Text = autor.nombre, Value = autor.id.ToString() }));
                ViewBag.LisAutor = lstAutor;
            }
            #endregion


            #region ListSelectedLibro
            List<SelectListItem> lstLibro = new();
            HttpClient clientLibro = _httpClient.CreateClient("Server");
            HttpResponseMessage resultLibro = await clientLibro.GetAsync("api/Libro");
            IEnumerable<LibroModel> libros = new List<LibroModel>();
            if (result.IsSuccessStatusCode)
            {
                var response = await resultLibro.Content.ReadAsStringAsync();
                libros = JsonConvert.DeserializeObject<IEnumerable<LibroModel>>(response);
                libros.ToList().ForEach(libro => lstLibro.Add(new SelectListItem { Text = libro.titulo, Value = libro.isbn.ToString() }));
                ViewBag.ListLibro = lstLibro;
            }
            #endregion



            return View();
        }

        // POST: AutoresHasLibroAppController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AutoresHasLibroModel model)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                var result = await client.PostAsJsonAsync($"api/AutoresHasLibro/", model);
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

        // GET: AutoresHasLibroAppController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync($"api/AutoresHasLibro/{id}");
            AutoresHasLibroModel autor = new();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                autor = JsonConvert.DeserializeObject<AutoresHasLibroModel>(response);
            }
            return View(autor);
        }

        // POST: AutoresHasLibroAppController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AutoresHasLibroModel model)
        {
            try
            {
                var client = _httpClient.CreateClient("Server");
                var result = await client.DeleteAsync($"api/AutoresHasLibro/{id}");
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
