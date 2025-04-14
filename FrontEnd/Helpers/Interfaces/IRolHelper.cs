using FrontEnd.ApiModels;
using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IRolHelper
    {
        List<RolViewModel> GetRoles();
        RolViewModel GetRol(int? id);
        RolViewModel Add(RolViewModel Rol);
        RolViewModel Update(RolViewModel Rol);
        void Delete(int id);

    }
}
