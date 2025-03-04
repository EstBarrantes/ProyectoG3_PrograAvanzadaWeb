using BackEnd.DTO;
using DAL.Implementations;

namespace BackEnd.Services.Interfaces
{
    public interface IUsuarioService
    {

        void AddUsuario(UsuarioDTO Usuario);
        void UpdateUsuariol(UsuarioDTO Usuario);
        void DeleteUsuario(int id);
        List<UsuarioDTO> GetUsuarios();
        UsuarioDTO GetUsuarioById(int id);


    }
}
