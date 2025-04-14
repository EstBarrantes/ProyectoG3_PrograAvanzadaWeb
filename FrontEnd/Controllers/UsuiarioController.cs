using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioHelper _usuarioHelper;

        public UsuarioController(IUsuarioHelper usuarioHelper)
        {
            _usuarioHelper = usuarioHelper;
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
            return View("ViewCrearUsuario");
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
    }
}
