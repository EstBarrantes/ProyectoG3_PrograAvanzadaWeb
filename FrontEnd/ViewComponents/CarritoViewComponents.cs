using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.ViewComponents
{
    public class CarritoViewComponent : ViewComponent
    {
        const string SessionKey = "Carrito";

        public IViewComponentResult Invoke()
        {
            var carritoJson = HttpContext.Session.GetString(SessionKey);
            var carrito = string.IsNullOrEmpty(carritoJson)
                ? new List<CarritoViewModel>()
                : JsonConvert.DeserializeObject<List<CarritoViewModel>>(carritoJson);

            return View("_Carrito", carrito);
        }
    }
}

