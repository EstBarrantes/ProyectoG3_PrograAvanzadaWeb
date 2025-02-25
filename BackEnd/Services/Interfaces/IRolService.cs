using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IRolService
    {
        void AddRol(RolDTO Rol);
        void UpdateRol(RolDTO Rol);
        void DeleteRol(int id);
        List<RolDTO> GetRols();
        RolDTO GetRolById(int id);
    }
}
