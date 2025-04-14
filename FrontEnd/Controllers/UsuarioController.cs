using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FrontEnd.ApiModels;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioHelper _usuarioHelper;
        private readonly IRolHelper _rolHelper;

        public UsuarioController(IUsuarioHelper usuarioHelper, IRolHelper rolHelper)
        {
            _usuarioHelper = usuarioHelper;
            _rolHelper = rolHelper;
        }

        // GET: Usuario/ListadoDeUsuarios
        public ActionResult ListadoDeUsuarios()
        {
            var usuarios = _usuarioHelper.GetUsuarios();
            return View("ListadoDeUsuarios", usuarios);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            var usuario = _usuarioHelper.GetUsuario(id);
            return View("ListadoDeUsuarios", usuario); // O crear una vista Details.cshtml si se desea
        }

        // GET: Usuario/ViewCrearUsuario
        public ActionResult ViewCrearUsuario()
        {
            UsuarioViewModel model = new();
            model.listaRoles = _rolHelper.GetRoles();

            return View("ViewCrearUsuario", model);
        }

        // POST: Usuario/ViewCrearUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewCrearUsuario(UsuarioViewModel usuario)
        {
            try
            {
                _usuarioHelper.Add(usuario);
                return RedirectToAction("ListadoDeUsuarios");
            }
            catch
            {
                return View("ViewCrearUsuario");
            }
        }

        // GET: Usuario/EditarUsuario/5
        public ActionResult EditarUsuario(int id)
        {
            var usuario = _usuarioHelper.GetUsuario(id);
            return View("EditarUsuario", usuario);
        }

        // POST: Usuario/EditarUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(UsuarioViewModel usuario)
        {
            try
            {
                _usuarioHelper.Update(usuario);
                return RedirectToAction("ListadoDeUsuarios");
            }
            catch
            {
                return View("EditarUsuario", usuario);
            }
        }

        // GET: Usuario/EliminarUsuario/5
        public ActionResult EliminarUsuario(int id)
        {
            var usuario = _usuarioHelper.GetUsuario(id);
            return View("EliminarUsuario", usuario);
        }

        // POST: Usuario/EliminarUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarUsuario(UsuarioViewModel usuario)
        {
            try
            {
                _usuarioHelper.Delete(usuario.UsuarioID);
                return RedirectToAction("ListadoDeUsuarios");
            }
            catch
            {
                return View("EliminarUsuario", usuario);
            }
        }

        public ActionResult Login()
        {
            UsuarioViewModel user = new UsuarioViewModel();
            //user.ReturnUrl = ReturnURL;
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var login = _usuarioHelper.Login(user.Correo, user.Contrasena);
                    if (login.Token != null)
                    {
                        TokenAPI token = new TokenAPI
                        {
                            Token = login.Token.Token,
                            Expiration = login.Token.Expiration
                        };
                        HttpContext.Session.SetString("Token", token.Token);




                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, login.Correo as string),
                            new Claim(ClaimTypes.Name, login.Correo as string),
                            new Claim(ClaimTypes.Role, login.Rol?.ToString() ?? "")
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                        { IsPersistent = false });

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "Invalid login attempt.");
                        return View(user);
                    }
                }
                return View(user);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Session.Remove("Token");

            return RedirectToAction("Home", "Index");
        }



    }
}
