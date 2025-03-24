using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace FrontEnd.Helpers.Implementations
{
    public class UsuarioHelper : IUsuarioHelper
    {
        private readonly IServiceRepository _ServiceRepository;

        public UsuarioHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        UsuarioViewModel Convertir(UsuarioAPI usuario)
        {
            return new UsuarioViewModel
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                Contraseña = usuario.Contraseña,
                RolId = usuario.RolId,
                FechaRegistro = usuario.FechaRegistro,
                Activo = usuario.Activo,
                Direccion = usuario.Direccion,
                Telefono = usuario.Telefono
            };
        }

        UsuarioAPI Convertir(UsuarioViewModel usuario)
        {
            return new UsuarioAPI
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Correo = usuario.Correo,
                Contraseña = usuario.Contraseña,
                RolId = usuario.RolId,
                FechaRegistro = usuario.FechaRegistro,
                Activo = usuario.Activo,
                Direccion = usuario.Direccion,
                Telefono = usuario.Telefono
            };
        }

        public UsuarioViewModel Add(UsuarioViewModel usuario)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.PostResponse("api/Usuario", Convertir(usuario));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }

            return usuario;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Usuario/" + id);
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public UsuarioViewModel GetUsuario(int? id)
        {
            UsuarioAPI data = new UsuarioAPI();
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Usuario/" + id.ToString());

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<UsuarioAPI>(content) ?? new();
            }

            return Convertir(data);
        }

        public List<UsuarioViewModel> GetUsuarios()
        {
            List<UsuarioAPI> data = new List<UsuarioAPI>();
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Usuario");

            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<UsuarioAPI>>(content) ?? new();
            }

            List<UsuarioViewModel> list = new List<UsuarioViewModel>();
            data.ForEach(x =>
            {
                list.Add(Convertir(x));
            });

            return list;
        }

        public UsuarioViewModel Update(UsuarioViewModel usuario)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.PutResponse("api/Usuario", Convertir(usuario));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }

            return usuario;
        }
    }
}
