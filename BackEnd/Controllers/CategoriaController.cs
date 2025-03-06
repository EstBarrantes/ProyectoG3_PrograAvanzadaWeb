using BackEnd.DTO;
using BackEnd.Services.Interfaces;
//using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        ICategoriaService _CategoriaService;
        public CategoriaController (ICategoriaService CategoriaService)
        {
            _CategoriaService = CategoriaService;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public IEnumerable<CategoriaDTO> Get()
        {
            return _CategoriaService.GetCategorias();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public CategoriaDTO Get(int id)
        {
            return _CategoriaService.GetCategoriaById(id);
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public void Post([FromBody] CategoriaDTO rol)
        {
            _CategoriaService.AddCategoria(rol);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut]
        public void Put( [FromBody] CategoriaDTO rol)
        {
            _CategoriaService.UpdateCategoria(rol);
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _CategoriaService.DeleteCategoria(id);
        }
    }
}
