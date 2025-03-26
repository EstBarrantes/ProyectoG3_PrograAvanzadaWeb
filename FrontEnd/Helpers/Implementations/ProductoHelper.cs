using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class ProductoHelper : IProductoHelper
    {
        IServiceRepository _ServiceRepository;

        public ProductoHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        ProductoViewModel Convertir(ProductoAPI producto)
        {
            return new ProductoViewModel
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                CategoriaId = (int)producto.CategoriaId,
                ImagenUrl = producto.ImagenUrl,
                FechaAgregado = producto.FechaAgregado,
                Descuento = producto.Descuento
            };
        }

        ProductoAPI Convertir(ProductoViewModel producto)
        {
            return  new ProductoAPI
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                CategoriaId = (int)producto.CategoriaId,
                ImagenUrl = producto.ImagenUrl,
                FechaAgregado = producto.FechaAgregado,
                Descuento = producto.Descuento
            };
        }




        public ProductoViewModel Add(ProductoViewModel ViewModel)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.PostResponse("api/Producto", Convertir(ViewModel));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }

            return ViewModel;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Producto/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public List<ProductoViewModel> GetProductos()
        {
            List<ProductoAPI> data = new List<ProductoAPI>();
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Producto");


            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<ProductoAPI>>(content) ?? new();


            }

            List<ProductoViewModel> list = new List<ProductoViewModel>();
            data.ForEach(x =>
            {
                var productoViewModel = Convertir(x);

                HttpResponseMessage categoryResponse = _ServiceRepository.GetResponse("api/Categoria/" + productoViewModel.CategoriaId);
                if (categoryResponse != null)
                {
                    var categoryContent = categoryResponse.Content.ReadAsStringAsync().Result;
                    var category = JsonConvert.DeserializeObject<ProductoViewModel>(categoryContent);

                    productoViewModel.CategoriaNombre = category?.Nombre;
                }


                list.Add(productoViewModel);
            });
            return list;
        }

        public ProductoViewModel GetProducto(int? id)
        {

            ProductoAPI data = new ProductoAPI();
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Producto/" + id.ToString());


            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<ProductoAPI>(content) ?? new();


            }

            return Convertir(data);
        }

        public ProductoViewModel Update(ProductoViewModel producto)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.PutResponse("api/Producto", Convertir(producto));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }


            return producto;
        }
    }
}
