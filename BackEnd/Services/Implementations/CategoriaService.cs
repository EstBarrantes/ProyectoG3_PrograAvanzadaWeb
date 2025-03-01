using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.implementations
{
    public class CategoriaService : ICategoriaService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;

        public CategoriaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Categorium Convertir(CategoriaDTO Categorium)
        {
            return new Categorium
            {
                CategoriaId = Categorium.CategoriaId,
                Nombre = Categorium.Nombre,
            };
        }
        CategoriaDTO ConvertirDTO(Categorium Categorium)
        {
            return new CategoriaDTO
            {
                CategoriaId = Categorium.CategoriaId,
                Nombre = Categorium.Nombre,
            };
        }

        public void AddCategoria(CategoriaDTO Categorium)
        {
            var CategoriumEntity = Convertir(Categorium);
            _unidadDeTrabajo.CategoriaDAL.Add(CategoriumEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeleteCategoria(int id)
        {
            var Categorium = new Categorium { CategoriaId = id };
            _unidadDeTrabajo.CategoriaDAL.Remove(Categorium);
            _unidadDeTrabajo.Complete();
        }

        public CategoriaDTO GetCategoriaById(int id)
        {
            var result = _unidadDeTrabajo.CategoriaDAL.Get(id);
            return ConvertirDTO(result);
        }

        public List<CategoriaDTO> GetCategorias()
        {
            var result = _unidadDeTrabajo.CategoriaDAL.GetAll();
            List<CategoriaDTO> Categoriums = new List<CategoriaDTO>();
            foreach (var item in result)
            {
                Categoriums.Add(ConvertirDTO(item));
            }
            return Categoriums;
        }

        public void UpdateCategoria(CategoriaDTO Categorium)
        {
            var CategoriumEntity = Convertir(Categorium);
            _unidadDeTrabajo.CategoriaDAL.Update(CategoriumEntity);
            _unidadDeTrabajo.Complete();
        }


    }
}
