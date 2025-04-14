using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace FrontEnd.Helpers.Implementations
{
    public class RolHelper : IRolHelper
    {
        private readonly IServiceRepository _ServiceRepository;

        public RolHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        RolViewModel Convertir(RolAPI Rol)
        {
            return new RolViewModel
            {
                RolId = Rol.RolId,
                NombreRol = Rol.NombreRol,
            };
        }

        RolAPI Convertir(RolViewModel Rol)
        {
            return new RolAPI
            {
                RolId = Rol.RolId,
                NombreRol = Rol.NombreRol,
            };
        }

        public RolViewModel Add(RolViewModel Rol)
        {
            try
            {
                HttpResponseMessage responseMessage = _ServiceRepository.PostResponse("api/Rol", Convertir(Rol));
                if (responseMessage != null)
                {
                    var content = responseMessage.Content;
                }
                return Rol;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar Rol: " + ex.Message, ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Rol/" + id);
                if (responseMessage != null)
                {
                    var content = responseMessage.Content;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar Rol con ID {id}: {ex.Message}", ex);
            }
        }

        public RolViewModel GetRol(int? id)
        {
            try
            {
                RolAPI data = new RolAPI();
                HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Rol/" + id.ToString());

                if (responseMessage != null)
                {
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<RolAPI>(content) ?? new RolAPI();
                }

                return Convertir(data);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener Rol con ID {id}: {ex.Message}", ex);
            }
        }

        public List<RolViewModel> GetRoles()
        {
            try
            {
                List<RolAPI> data = new List<RolAPI>();
                HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Rol");

                if (responseMessage != null)
                {
                    var content = responseMessage.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<RolAPI>>(content) ?? new();
                }

                List<RolViewModel> list = new();
                foreach (var item in data)
                {
                    list.Add(Convertir(item));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de Rols: " + ex.Message, ex);
            }
        }

        public RolViewModel Update(RolViewModel Rol)
        {
            try
            {
                HttpResponseMessage responseMessage = _ServiceRepository.PutResponse("api/Rol", Convertir(Rol));
                if (responseMessage != null)
                {
                    var content = responseMessage.Content;
                }

                return Rol;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar Rol: " + ex.Message, ex);
            }
        }
    }
}