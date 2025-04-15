using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductoController : Controller
    {

        IProductoHelper _productoHelper;
        ICategoryHelper _categoryHelper;

        public ProductoController(IProductoHelper productoHelper, ICategoryHelper categoryHelper)
        {
            _productoHelper = productoHelper;
            _categoryHelper = categoryHelper;
        }

        // GET: ProductoController
        public ActionResult Index()
        {
            ProductoViewModel producto = new ProductoViewModel();
            var test = _categoryHelper.GetCategories();
            producto.Categorias = test;


            return View(_productoHelper.GetProductos());
           // return View(_productoHelper.GetProductos());
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            ProductoViewModel producto = _productoHelper.GetProducto(id);
            producto.CategoriaNombre = _categoryHelper.GetCategory(producto.CategoriaId).Nombre;

            return View(producto);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            ProductoViewModel producto = new ProductoViewModel();
            //producto.Categorias = _categoryHelper.GetCategories();
            var cat = _categoryHelper.GetCategories();
            producto.Categorias= cat;

            return View(producto);
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoViewModel producto)
        {
            try
            {
                producto.ProductoId = null;
                _productoHelper.Add(producto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductoViewModel product = _productoHelper.GetProducto(id);
            product.Categorias = _categoryHelper.GetCategories();
            return View(product);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoViewModel producto)
        {
            try
            {
                _productoHelper.Update(producto);
                return RedirectToAction("Details", new { id = producto.ProductoId });
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductoViewModel product = _productoHelper.GetProducto(id);
            product.CategoriaNombre = _categoryHelper
                                    .GetCategory(product.CategoriaId)
                                    .Nombre;

            return View(product);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductoViewModel producto)
        {
            try
            {
                _productoHelper.Delete(producto.ProductoId ?? 0);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
