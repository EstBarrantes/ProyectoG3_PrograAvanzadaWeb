using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class FacturaController : Controller
    {
        const string SessionKey = "Carrito";
        IFacturaHelper _facturaHelper;
        IUsuarioHelper _usuarioHelper;

        private List<CarritoViewModel> GetCarrito()
        {
            var carritoJson = HttpContext.Session.GetString(SessionKey);
            return string.IsNullOrEmpty(carritoJson) ? new List<CarritoViewModel>() : JsonConvert.DeserializeObject<List<CarritoViewModel>>(carritoJson);
        }


        public FacturaController(IFacturaHelper facturaHelper, IUsuarioHelper usuarioHelper)
        {
            _facturaHelper = facturaHelper;
            _usuarioHelper = usuarioHelper;
        }

        // GET: FacturaController
        public ActionResult Index()
        {
            var data = _facturaHelper.GetFacturas();
            return View();
        }

        public IActionResult GenerarFactura()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Usuario");
            }

            var carrito = GetCarrito();
            if (!carrito.Any())
                return RedirectToAction("Carrito", "Carrito");

            var model = new FacturaViewModel
            {
                Fecha = DateTime.Now,
                Estado = "Pendiente",
                MetodoPago = "",
                Subtotal = carrito.Sum(p => p.Cantidad * p.Precio),
                DetalleFacturas = carrito.Select(c => new DetalleFacturaViewModel
                {
                    ProductoId = c.Id,
                    Cantidad = c.Cantidad,
                    PrecioUnitario = c.Precio,
                    Subtotal = c.Cantidad * c.Precio,
                }).ToList(),
                Descuento = carrito.Sum(p => p.Descuento),
                Total = carrito.Sum(p => p.Cantidad * p.Precio) - carrito.Sum(p => p.Descuento)
            };

            return View("FormularioFactura", model);
        }

        [HttpPost]
        public IActionResult ConfirmarCompra(FacturaViewModel factura)
        {
            if (User.Identity.IsAuthenticated)
            {
                var usuarioIdClaim = User.Identity.Name;
                var usuario = _usuarioHelper.GetUsuarioByCorreo(usuarioIdClaim);
                if (usuarioIdClaim != null)
                {
                    factura.UsuarioId = usuario.UsuarioID;
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuario");
            }

            _facturaHelper.Add(factura);

            // Limpiar carrito tras compra
            HttpContext.Session.Remove(SessionKey);

            return RedirectToAction("Confirmacion");
        }

        public IActionResult Confirmacion()
        {
            return View(); 
        }


        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            var result = _facturaHelper.GetFactura(id);
            return View(result);
        }

        // GET: FacturaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacturaViewModel factura)
        {
            try
            {
                _facturaHelper.Add(factura);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_facturaHelper.GetFactura(id));
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacturaViewModel factura)
        {
            try
            {
                _facturaHelper.Update(factura);
                return RedirectToAction("Details", new { id = factura.FacturaId });
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_facturaHelper.GetFactura(id));
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FacturaViewModel factura)
        {
            try
            {
                _facturaHelper.Delete(factura.FacturaId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
