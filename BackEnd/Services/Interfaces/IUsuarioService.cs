using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IUsuarioService
    {

        void AddUsuario(UsuarioDTO Usuario);


        void UpdateUsuario(UsuarioDTO Usuario);
        void DeleteUsuario(int id);
        List<UsuarioDTO> GetUsuarios();
        UsuarioDTO GetUsuarioById(int id);


    }
}
