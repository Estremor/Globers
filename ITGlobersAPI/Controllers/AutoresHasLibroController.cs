using Aplication.Contracts;
using Aplication.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITGlobersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresHasLibroController : ControllerBase
    {
        #region Fields
        private readonly IAutoresHasLibroAppService _autorLibroService;
        #endregion

        #region C´tor
        public AutoresHasLibroController(IAutoresHasLibroAppService autorService)
        {
            _autorLibroService = autorService;
        }
        #endregion

        #region Methods
        // GET: api/<AutoresHasLibroController>
        [HttpGet]
        public IEnumerable<AutoresHasLibroDto> Get()
        {
            return _autorLibroService.GetAllAutoresHasLibro();
        }

        // GET api/<AutoresHasLibroController>/5
        [HttpGet("{id}")]
        public AutoresHasLibroDto Get(int id)
        {
            return _autorLibroService.GetAutoresHasLibroById(id);
        }

        // POST api/<AutoresHasLibroController>
        [HttpPost]
        public void Post(AutoresHasLibroDto autorLibro)
        {
            _autorLibroService.Save(autorLibro);
        }


        // DELETE api/<AutoresHasLibroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _autorLibroService.DeleteAutoresHasLibro(id);
        }
        #endregion
    }
}
