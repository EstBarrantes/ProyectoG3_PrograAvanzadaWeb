using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<UsuarioDTO> Get()
        {
            return _usuarioService.GetUsuarios();
        }

        // GET api/Usuario/5
        [HttpGet("{id}")]
        public UsuarioDTO Get(int id)
        {
            return _usuarioService.GetUsuarioById(id);
        }

        // POST api/Usuario
        [HttpPost]
        public void Post([FromBody] UsuarioDTO usuario)
        {
            _usuarioService.AddUsuario(usuario);
        }

        // PUT api/Usuario
        [HttpPut]
        public void Put([FromBody] UsuarioDTO usuario)
        {
            _usuarioService.UpdateUsuario(usuario);
        }

        // DELETE api/Usuario/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _usuarioService.DeleteUsuario(id);
        }
    }
}
