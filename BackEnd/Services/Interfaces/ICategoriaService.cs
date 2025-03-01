using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface ICategoriaService
    {
        void AddCategoria(CategoriaDTO Categoria);
        void UpdateCategoria(CategoriaDTO Categoria);
        void DeleteCategoria(int id);
        List<CategoriaDTO> GetCategorias();
        CategoriaDTO GetCategoriaById(int id);
    }
}
