using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.implementations
{
    public class FacturaService : IFacturaService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;

        public FacturaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Factura Convertir(FacturaDTO producto)
        {
            return new Factura
            {
                FacturaId = producto.FacturaId,
                UsuarioId = producto.UsuarioId ,
                Fecha = producto.Fecha,
                Total = producto.Total,
                Estado = producto.Estado,
                MetodoPago = producto.MetodoPago,
                DetalleFacturas = ConvertirDetalle(producto.DetalleFacturas)
            };
        }
        FacturaDTO ConvertirDTO(Factura producto)
        {
            return new FacturaDTO
            {
                FacturaId = producto.FacturaId,
                UsuarioId = producto.UsuarioId,
                Fecha = producto.Fecha,
                Total = producto.Total,
                Estado = producto.Estado,
                MetodoPago = producto.MetodoPago,
                DetalleFacturas = ConvertirDetalleDTO(producto.DetalleFacturas),
            };
        }

        List<DetalleFactura> ConvertirDetalle(ICollection<DetalleFacturaDTO>? data)
        {
            if (data == null) return new List<DetalleFactura>();

            return data.Select(x => new DetalleFactura
            {
                DetalleId = x.DetalleId,
                FacturaId = x.FacturaId,
                ProductoId = x.ProductoId,
                Cantidad = x.Cantidad,
                PrecioUnitario = x.PrecioUnitario,
                Subtotal = x.Subtotal
            }).ToList();


        }
        List<DetalleFacturaDTO> ConvertirDetalleDTO(ICollection<DetalleFactura>? data)
        {
            if (data == null) return new List<DetalleFacturaDTO>();

            return data.Select(x => new DetalleFacturaDTO
            {
                DetalleId = x.DetalleId,
                FacturaId = x.FacturaId,
                ProductoId = x.ProductoId,
                Cantidad = x.Cantidad,
                PrecioUnitario = x.PrecioUnitario,
                Subtotal = x.Subtotal
            }).ToList();
        }

        public bool CreateFactura(FacturaDTO producto)
        {
            var productoEntity = Convertir(producto);
            if(!_unidadDeTrabajo.FacturaDAL.Add(productoEntity))
                return false;
            if (!_unidadDeTrabajo.Complete())
                return false;

            return true;

        }

        public void DeleteFactura(int id)
        {
            var producto = new Factura { FacturaId = id };
            _unidadDeTrabajo.FacturaDAL.Remove(producto);
            _unidadDeTrabajo.Complete();
        }

        public FacturaDTO GetFacturaById(int id)
        {
            var result = _unidadDeTrabajo.FacturaDAL.Get(id);
            return ConvertirDTO(result);
        }

        public List<FacturaDTO> GetFacturas()
        {
            var result = _unidadDeTrabajo.FacturaDAL.GetAll();
            List<FacturaDTO> productos = new List<FacturaDTO>();
            foreach (var item in result)
            {
                productos.Add(ConvertirDTO(item));
            }
            return productos;
        }

        public bool UpdateFactura(FacturaDTO Factura)
        {
            var productoEntity = Convertir(Factura);
            if (!_unidadDeTrabajo.FacturaDAL.Update(productoEntity))
                return false;
            if (!_unidadDeTrabajo.Complete())
                return false;

            return true;
        }


    }
}
