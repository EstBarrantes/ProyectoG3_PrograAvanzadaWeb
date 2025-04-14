using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
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
        private readonly IRolService _rolService;
        private readonly UserManager<IdentityUser> userManager;
        private ITokenService TokenService;

        public UsuarioController(IUsuarioService usuarioService, IRolService rolService, UserManager<IdentityUser> userManager,
                                ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _rolService = rolService;
            this.userManager = userManager;
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


            IdentityUser user = await userManager.FindByNameAsync(model.Correo);
            LoginDTO Usuario = new LoginDTO();
            if (user != null && await userManager.CheckPasswordAsync(user, model.Contrasena))
            {

                var userRoles = await userManager.GetRolesAsync(user);
                var rol = await _rolService.GetRolByCorreo(correo);

                var jwtToken = TokenService.GenerateToken(user, userRoles.ToList());

                Usuario.Token = jwtToken;
                Usuario.Rol = userRoles.ToList();
                Usuario.Username = user.UserName;


                return Ok(Usuario);
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {

            var userExists = await userManager.FindByNameAsync(model.Username);

            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            IdentityUser user = new IdentityUser
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

            return Ok();

        }
    }
}
