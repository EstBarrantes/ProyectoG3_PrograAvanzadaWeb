using BackEnd.DTO;
using BackEnd.Services.Interfaces;
//using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        IRolService _rolService;
        public RolController (IRolService rolService)
        {
            _rolService = rolService;
        }

        // GET: api/<rolController>
        [HttpGet]
        public IEnumerable<RolDTO> Get()
        {
            return _rolService.GetRols();
        }

        // GET api/<rolController>/5
        [HttpGet("{id}")]
        public RolDTO Get(int id)
        {
            return _rolService.GetRolById(id);
        }

        // POST api/<rolController>
        [HttpPost]
        public void Post([FromBody] RolDTO rol)
        {
            _rolService.AddRol(rol);
        }

        // PUT api/<rolController>/5
        [HttpPut]
        public void Put( [FromBody] RolDTO rol)
        {
            _rolService.UpdateRol(rol);
        }

        // DELETE api/<rolController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _rolService.DeleteRol(id);
        }
    }
}
