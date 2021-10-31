using Aplication.Contracts;
using Aplication.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {

        #region Fields
        private readonly ILibroAppService _libroService;
        #endregion

        #region C´tor
        public LibroController(ILibroAppService libroService)
        {
            _libroService = libroService;
        }
        #endregion

        // GET: api/<LibroController>
        [HttpGet]
        public IEnumerable<LibroDto> Get()
        {
            return _libroService.GetAllLibros();
        }

        // GET api/<LibroController>/5
        [HttpGet("{id}")]
        public LibroDto Get(int id)
        {
            return _libroService.GetLibroById(id);
        }

        // POST api/<LibroController>
        [HttpPost]
        public void Post(LibroDto libro)
        {
            _libroService.Save(libro);
        }

        // PUT api/<LibroController>/5
        [HttpPut]
        public void Put(LibroDto libro)
        {
            _libroService.UpdateLibro(libro);
        }

        // DELETE api/<LibroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _libroService.DeleteLibro(id);
        }
    }
}
