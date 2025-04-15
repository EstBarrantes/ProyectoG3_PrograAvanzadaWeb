using BackEnd.DTO;
using BackEnd.Services.Interfaces;
//using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        IFacturaService _FacturaService;
        public FacturaController (IFacturaService FacturaService)
        {
            _FacturaService = FacturaService;
        }

        // GET: api/<FacturaController>
        [HttpGet]
        public IEnumerable<FacturaDTO> Get()
        {
            return _FacturaService.GetFacturas();
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public FacturaDTO Get(int id)
        {
            return _FacturaService.GetFacturaById(id);
        }

        // POST api/<FacturaController>
        [HttpPost]
        public void Post([FromBody] FacturaDTO rol)
        {
            _FacturaService.CreateFactura(rol);
        }

        // PUT api/<FacturaController>/5
        [HttpPut]
        public void Put( [FromBody] FacturaDTO rol)
        {
            _FacturaService.UpdateFactura(rol);
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _FacturaService.DeleteFactura(id);
        }
    }
}
