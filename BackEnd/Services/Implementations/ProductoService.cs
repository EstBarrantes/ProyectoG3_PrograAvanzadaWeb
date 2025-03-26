using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.implementations
{
    public class ProductoService : IProductoService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;

        public ProductoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Producto Convertir(ProductoDTO producto)
        {
            return new Producto
            {
                ProductoId = producto.ProductoId ?? 0,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                CategoriaId = producto.CategoriaId,
                ImagenUrl = producto.ImagenUrl,
                FechaAgregado = producto.FechaAgregado,
                Descuento = producto.Descuento
            };
        }
        ProductoDTO ConvertirDTO(Producto producto)
        {
            return new ProductoDTO
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                CategoriaId = producto.CategoriaId,
                ImagenUrl = producto.ImagenUrl,
                FechaAgregado = producto.FechaAgregado,
                Descuento = producto.Descuento
            };
        }

        public void AddProducto(ProductoDTO producto)
        {
            var productoEntity = Convertir(producto);
            var des =_unidadDeTrabajo.ProductoDAL.Add(productoEntity); ;
            var des1 = _unidadDeTrabajo.Complete(); 
            //_unidadDeTrabajo.ProductoDAL.Add(productoEntity);
            //_unidadDeTrabajo.Complete();
        }

        public void DeleteProducto(int id)
        {
            var producto = new Producto { ProductoId = id };
            _unidadDeTrabajo.ProductoDAL.Remove(producto);
            _unidadDeTrabajo.Complete();
        }

        public ProductoDTO GetProductoById(int id)
        {
            var result = _unidadDeTrabajo.ProductoDAL.Get(id);
            return ConvertirDTO(result);
        }

        public List<ProductoDTO> GetProductos()
        {
            var result = _unidadDeTrabajo.ProductoDAL.GetAll();
            List<ProductoDTO> productos = new List<ProductoDTO>();
            foreach (var item in result)
            {
                productos.Add(ConvertirDTO(item));
            }
            return productos;
        }

        public void UpdateProducto(ProductoDTO Producto)
        {
            var productoEntity = Convertir(Producto);
            _unidadDeTrabajo.ProductoDAL.Update(productoEntity);
            _unidadDeTrabajo.Complete();
        }


    }
}
