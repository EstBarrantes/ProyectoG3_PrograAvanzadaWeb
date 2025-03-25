using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IProductoService
    {
        void AddProducto(ProductoDTO Producto);
        void UpdateProducto(ProductoDTO Producto);
        void DeleteProducto(int id);
        List<ProductoDTO> GetProductos();
        ProductoDTO GetProductoById(int id);
    }
}
