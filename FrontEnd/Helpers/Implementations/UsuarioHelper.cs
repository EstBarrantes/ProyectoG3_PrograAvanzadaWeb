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
                UsuarioID = usuario.UsuarioID,
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
                UsuarioID = usuario.UsuarioID,
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
            try
            {
                HttpResponseMessage responseMessage = _ServiceRepository.PostResponse("api/Usuario", Convertir(usuario));
                if (responseMessage != null)
                {
                    var content = responseMessage.Content;
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar usuario: " + ex.Message, ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Usuario/" + id);
                if (responseMessage != null)
                {
                    var content = responseMessage.Content;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar usuario con ID {id}: {ex.Message}", ex);
            }
        }

        public UsuarioViewModel GetUsuario(int? id)
        {
            try
            {
                UsuarioAPI data = new UsuarioAPI();
                HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Usuario/" + id.ToString());

                if (responseMessage != null)
                {
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<UsuarioAPI>(content) ?? new UsuarioAPI();
                }

                return Convertir(data);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener usuario con ID {id}: {ex.Message}", ex);
            }
        }

        public List<UsuarioViewModel> GetUsuarios()
        {
            try
            {
                List<UsuarioAPI> data = new List<UsuarioAPI>();
                HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/usuario");

                if (responseMessage != null)
                {
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<UsuarioAPI>>(content) ?? new();
                }

                List<UsuarioViewModel> list = new();
                foreach (var item in data)
                {
                    list.Add(Convertir(item));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de usuarios: " + ex.Message, ex);
            }
        }

        public UsuarioViewModel Update(UsuarioViewModel usuario)
        {
            try
            {
                HttpResponseMessage responseMessage = _ServiceRepository.PutResponse("api/Usuario", Convertir(usuario));
                if (responseMessage != null)
                {
                    var content = responseMessage.Content;
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar usuario: " + ex.Message, ex);
            }
        }

        public LoginAPI Login(string correo, string contra)
        {
            try
            {
                HttpResponseMessage response = _ServiceRepository.PostResponse("api/Usuario/Login", new { Correo = correo, Contrasena = contra });
                var content = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<LoginAPI>(content);
                }
                else
                {
                    return new LoginAPI();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}