using BackEnd.DTO;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IRolService _rolService;
        private ITokenService TokenService;

        public UsuarioController(IUsuarioService usuarioService, IRolService rolService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _rolService = rolService;
            TokenService = tokenService;
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

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {


            var usuario = await _usuarioService.GetUsuarioByCorreo(model.Correo);

            if (usuario == null)
                return Unauthorized("Credenciales inválidas");

            bool estaHash = !string.IsNullOrWhiteSpace(usuario.Contrasena) && usuario.Contrasena.Length >= 60;
            if (estaHash)
            {
                var hasher = new PasswordHasher<object>();
                var result = hasher.VerifyHashedPassword(null, usuario.Contrasena, model.Contrasena);


                if (result == PasswordVerificationResult.Success)
                {

                    //var userRoles = await userManager.GetRolesAsync(user);
                    var rol = _rolService.GetRolByCorreo(model.Correo);

                    var jwtToken = TokenService.GenerateToken(usuario, rol);

                    usuario.Token = jwtToken;
                    usuario.RolId = rol.RolID;
                    //usuario.Correo = user.UserName; //creo que no ocupo esta linea?

                    return Ok(usuario);
                }
            }
            else
            {
                if (usuario.Contrasena == model.Contrasena)
                {

                    var rol = _rolService.GetRolByCorreo(model.Correo);

                    var jwtToken = TokenService.GenerateToken(usuario, rol);

                    usuario.Token = jwtToken;
                    usuario.RolId = rol.RolID;
                    //usuario.Correo = user.UserName; //creo que no ocupo esta linea?

                    return Ok(usuario);
                }
            }


            return Unauthorized();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UsuarioDTO model)
        {

            var usuarioExistente = await _usuarioService.GetUsuarioByCorreo(model.Correo);

            if (usuarioExistente != null)
            {
                return Conflict("Ya existe un usuario con ese correo.");
            }

            var hasher = new PasswordHasher<object>();
            string hashedPassword = hasher.HashPassword(null, model.Contrasena);

            var nuevoUsuario = new UsuarioDTO
            {
                Correo = model.Correo,
                Contrasena = hashedPassword,
                RolId = model.RolId,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                FechaRegistro = DateTime.Now,
                Activo = true,
                Direccion = model.Direccion,
                Telefono = model.Telefono

            };

            _usuarioService.AddUsuario(nuevoUsuario);

            return Ok();

        }
    }
}
