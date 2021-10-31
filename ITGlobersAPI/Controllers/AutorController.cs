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
    public class AutorController : ControllerBase
    {
        #region Fields
        private readonly IAutorAppService _autorService;
        #endregion

        #region C´tor
        public AutorController(IAutorAppService autorService)
        {
            _autorService = autorService;
        }
        #endregion

        #region Methods
        // GET: api/<AutorController>
        [HttpGet]
        public IEnumerable<AutorDto> Get()
        {
            return _autorService.GetAllAutor();
        }

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        public AutorDto Get(int id)
        {
            return _autorService.GetAutorById(id);
        }

        // POST api/<AutorController>
        [HttpPost]
        public void Post(AutorDto autor)
        {
            _autorService.Save(autor);
        }

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        public void Put(int id, AutorDto autor)
        {
            _autorService.UpdateAutor(autor);
        }


        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _autorService.DeleteAutor(id);
        }
        #endregion
    }
}
