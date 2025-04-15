using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;

        public UsuarioService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Usuario Convertir(UsuarioDTO usuario)
        {
            return new Usuario
            {
                UsuarioID = usuario.UsuarioID,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                Contraseña = usuario.Contrasena,
                RolID = usuario.RolId,
                FechaRegistro = usuario.FechaRegistro,
                Activo = usuario.Activo,
                Direccion = usuario.Direccion,
                Telefono = usuario.Telefono
            };
        }

        UsuarioDTO ConvertirDTO(Usuario usuario)
        {
            return new UsuarioDTO
            {
                UsuarioID = usuario.UsuarioID,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                Contrasena = usuario.Contraseña,
                RolId = usuario.RolID,
               
                FechaRegistro = usuario.FechaRegistro,
                Activo = usuario.Activo,
                Direccion = usuario.Direccion,
                Telefono = usuario.Telefono
            };
        }

        public void AddUsuario(UsuarioDTO usuario)
        {
            var usuarioEntity = Convertir(usuario);
            _unidadDeTrabajo.UsuarioDAL.Add(usuarioEntity);
            _unidadDeTrabajo.Complete();
        }

        public void DeleteUsuario(int id)
        {
            var usuario = new Usuario { UsuarioID = id };
            _unidadDeTrabajo.UsuarioDAL.Remove(usuario);
            _unidadDeTrabajo.Complete();
        }

        public UsuarioDTO GetUsuarioById(int id)
        {
            var result = _unidadDeTrabajo.UsuarioDAL.Get(id);
            return ConvertirDTO(result);
        }

        public async Task<UsuarioDTO> GetUsuarioByCorreo(string correo)
        {
            var result = await _unidadDeTrabajo.UsuarioDAL.GetUsuarioByCorreoAsync(correo);
            return ConvertirDTO(result ?? new());
        }

        public List<UsuarioDTO> GetUsuarios()
        {
            var result = _unidadDeTrabajo.UsuarioDAL.GetAll();
            List<UsuarioDTO> usuarios = new();
            foreach (var item in result)
            {
                usuarios.Add(ConvertirDTO(item));
            }
            return usuarios;
        }

        public void UpdateUsuario(UsuarioDTO usuario)
        {
            var usuarioEntity = Convertir(usuario);
            _unidadDeTrabajo.UsuarioDAL.Update(usuarioEntity);
            _unidadDeTrabajo.Complete();
        }
    }
}
