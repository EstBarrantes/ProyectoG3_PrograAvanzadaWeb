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

        // GET: UsuarioController
        public ActionResult Index()
        {
            return View(_usuarioHelper.GetUsuarios());
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            var result = _usuarioHelper.GetUsuario(id);
            return View(result);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                _usuarioHelper.Add(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_usuarioHelper.GetUsuario(id));
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            try
            {
                _usuarioHelper.Update(usuario);
                return RedirectToAction("Details", new { id = usuario.UsuarioId });
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_usuarioHelper.GetUsuario(id));
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioViewModel usuario)
        {
            try
            {
                _usuarioHelper.Delete(usuario.UsuarioId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}


