using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class FacturaHelper : IFacturaHelper
    {
        IServiceRepository _ServiceRepository;

        public FacturaHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }




        FacturaViewModel Convertir(FacturaAPI producto)
        {
            return new FacturaViewModel
            {
                FacturaId = producto.FacturaId,
                UsuarioId = producto.UsuarioId,
                Fecha = producto.Fecha,
                Total = producto.Total,
                Estado = producto.Estado,
                MetodoPago = producto.MetodoPago,
                DetalleFacturas = ConvertirDetalle(producto.DetalleFacturas)
            };
        }
        FacturaAPI Convertir(FacturaViewModel producto)
        {
            return new FacturaAPI
            {
                FacturaId = producto.FacturaId,
                UsuarioId = producto.UsuarioId,
                Fecha = producto.Fecha,
                Total = producto.Total,
                Estado = producto.Estado,
                MetodoPago = producto.MetodoPago,
                DetalleFacturas = ConvertirDetalleAPI(producto.DetalleFacturas),
            };
        }

        List<DetalleFacturaViewModel> ConvertirDetalle(ICollection<DetalleFacturaAPI>? data)
        {
            if (data == null) return new List<DetalleFacturaViewModel>();

            return data.Select(x => new DetalleFacturaViewModel
            {
                DetalleId = x.DetalleId,
                FacturaId = x.FacturaId,
                ProductoId = x.ProductoId,
                Cantidad = x.Cantidad,
                PrecioUnitario = x.PrecioUnitario,
                Subtotal = x.Subtotal
            }).ToList();


        }
        List<DetalleFacturaAPI> ConvertirDetalleAPI(ICollection<DetalleFacturaViewModel>? data)
        {
            if (data == null) return new List<DetalleFacturaAPI>();

            return data.Select(x => new DetalleFacturaAPI
            {
                DetalleId = x.DetalleId,
                FacturaId = x.FacturaId,
                ProductoId = x.ProductoId,
                Cantidad = x.Cantidad,
                PrecioUnitario = x.PrecioUnitario,
                Subtotal = x.Subtotal
            }).ToList();
        }




        public FacturaViewModel Add(FacturaViewModel ViewModel)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.PostResponse("api/Categoria", Convertir(ViewModel));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }

            return ViewModel;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Categoria/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public List<FacturaViewModel> GetCategories()
        {
            List<FacturaAPI> data = new List<FacturaAPI>();
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Categoria");


            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<FacturaAPI>>(content) ?? new();


            }

            List<FacturaViewModel> list = new List<FacturaViewModel>();
            data.ForEach(x =>
            {
                list.Add(Convertir(x));
            });
            return list;
        }

        public FacturaViewModel GetFactura(int? id)
        {

            FacturaAPI data = new FacturaAPI();
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Categoria/" + id.ToString());


            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<FacturaAPI>(content) ?? new();


            }

            return Convertir(data);
        }

        public FacturaViewModel Update(FacturaViewModel factura)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.PutResponse("api/Categoria", Convertir(factura));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }


            return factura;
        }
    }
}
