using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.implementations
{
    public class RolService : IRolService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;

        public RolService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Rol Convertir(RolDTO rol)
        {
            return new Rol
            {
                RolId = rol.RolId,
                NombreRol = rol.NombreRol,
                Usuarios = rol.Usuarios,
            };
        }
        RolDTO ConvertirDTO(Rol rol)
        {
            return new RolDTO
            {
                RolId = rol.RolId,
                NombreRol = rol.NombreRol,
                Usuarios = rol.Usuarios,
            };
        }

        public void AddRol(RolDTO rol)
        {
            var rolEntity = Convertir(rol);
            _unidadDeTrabajo.RolDAL.Add(rolEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeleteRol(int id)
        {
            var rol = new Rol { RolId = id };
            _unidadDeTrabajo.RolDAL.Remove(rol);
            _unidadDeTrabajo.Complete();
        }

        public RolDTO GetRolById(int id)
        {
            var result = _unidadDeTrabajo.RolDAL.Get(id);
            return ConvertirDTO(result);
        }

        public List<RolDTO> GetRols()
        {
            var result = _unidadDeTrabajo.RolDAL.GetAll();
            List<RolDTO> rols = new List<RolDTO>();
            foreach (var item in result)
            {
                rols.Add(ConvertirDTO(item));
            }
            return rols;
        }

        public void UpdateRol(RolDTO Rol)
        {
            var rolEntity = Convertir(Rol);
            _unidadDeTrabajo.RolDAL.Update(rolEntity);
            _unidadDeTrabajo.Complete();
        }


    }
}
