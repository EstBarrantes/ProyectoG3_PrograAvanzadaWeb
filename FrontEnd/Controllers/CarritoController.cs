using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;
using Newtonsoft.Json;

public class CarritoController : Controller
{
    const string SessionKey = "Carrito";

    private List<CarritoViewModel> GetCarrito()
    {
        var carritoJson = HttpContext.Session.GetString(SessionKey);
        return string.IsNullOrEmpty(carritoJson) ? new List<CarritoViewModel>() : JsonConvert.DeserializeObject<List<CarritoViewModel>>(carritoJson);
    }

    private void SaveCarrito(List<CarritoViewModel> carrito)
    {
        HttpContext.Session.SetString(SessionKey, JsonConvert.SerializeObject(carrito));
    }

    [HttpPost]
    public IActionResult Agregar(int id, string nombre, decimal precio, int cantidad, string returnUrl)
    {
        var carrito = GetCarrito();
        var item = carrito.FirstOrDefault(p => p.Id== id);
        if (item != null)
            item.Cantidad += cantidad;
        else
            carrito.Add(new CarritoViewModel
            {
                Id= id,
                Nombre_Producto = nombre,
                Precio = precio,
                Cantidad = cantidad
            });

        SaveCarrito(carrito);
        return Redirect(returnUrl ?? "/");
    }


    [HttpPost]
    public IActionResult Eliminar(int id, string returnUrl)
    {
        var carrito = GetCarrito();
        var item = carrito.FirstOrDefault(p => p.Id == id);
        if (item != null)
        {
            carrito.Remove(item);
            SaveCarrito(carrito);
        }

        return Redirect(returnUrl ?? "/");
    }

    public IActionResult Ver()
    {
        var carrito = GetCarrito();
        return PartialView("_Carrito", carrito);
    }
    public IActionResult Carrito()
    {
        var carrito = GetCarrito();
        return PartialView("_Carrito", carrito);
    }

}
