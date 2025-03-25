using BackEnd.DTO;
using BackEnd.Services.Interfaces;
//using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        IProductoService _productoService;
        public ProductoController (IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/<productoController>
        [HttpGet]
        public IEnumerable<ProductoDTO> Get()
        {
            return _productoService.GetProductos();
        }

        // GET api/<productoController>/5
        [HttpGet("{id}")]
        public ProductoDTO Get(int id)
        {
            return _productoService.GetProductoById(id);
        }

        // POST api/<productoController>
        [HttpPost]
        public void Post([FromBody] ProductoDTO producto)
        {
            _productoService.AddProducto(producto);
        }

        // PUT api/<productoController>/5
        [HttpPut]
        public void Put( [FromBody] ProductoDTO producto)
        {
            _productoService.UpdateProducto(producto);
        }

        // DELETE api/<productoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productoService.DeleteProducto(id);
        }
    }
}
