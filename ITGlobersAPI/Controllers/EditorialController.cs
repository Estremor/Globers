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
    public class EditorialController : ControllerBase
    {
        #region Fields
        private readonly IEditorialAppService _editorialService;
        #endregion

        #region C´tor
        public EditorialController(IEditorialAppService editorialService)
        {
            _editorialService = editorialService;
        }
        #endregion

        #region Methods
        // GET: api/<EditorialController>
        [HttpGet]
        public IEnumerable<EditorialDto> Get()
        {
            return _editorialService.GetAllEditorial();
        }

        // GET api/<EditorialController>/5
        [HttpGet("{id}")]
        public EditorialDto Get(int id)
        {
            return _editorialService.GetEditorialById(id);
        }

        // POST api/<EditorialController>
        [HttpPost]
        public void Post(EditorialDto autor)
        {
            _editorialService.Save(autor);
        }

        // PUT api/<EditorialController>/5
        [HttpPut("{id}")]
        public void Put(int id, EditorialDto autor)
        {
            _editorialService.UpdateEditorial(autor);
        }

        // DELETE api/<EditorialController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _editorialService.DeleteEditorial(id);
        }
        #endregion
    }
}
