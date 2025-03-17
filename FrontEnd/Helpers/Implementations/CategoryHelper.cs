using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CategoryHelper : ICategoryHelper
    {
        IServiceRepository _ServiceRepository;

        public CategoryHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        CategoryViewModel Convertir(CategoryAPI category)
        {
            return new CategoryViewModel
            {
                CategoriaId = category.CategoriaId,
                Nombre = category.Nombre
            };
        }

        CategoryAPI Convertir(CategoryViewModel category)
        {
            return  new CategoryAPI
            {
                CategoriaId = category.CategoriaId,
                Nombre = category.Nombre
            };
        }




        public CategoryViewModel Add(CategoryViewModel ViewModel)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.PostResponse("api/Categoria", Convertir(ViewModel));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }

            return ViewModel;
        }

        public void Delete(int id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.DeleteResponse("api/Categoria/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }
        }

        public List<CategoryViewModel> GetCategories()
        {
            List<CategoryAPI> data = new List<CategoryAPI>();
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Categoria");


            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<List<CategoryAPI>>(content) ?? new();


            }

            List<CategoryViewModel> list = new List<CategoryViewModel>();
            data.ForEach(x =>
            {
                list.Add(Convertir(x));
            });
            return list;
        }

        public CategoryViewModel GetCategory(int? id)
        {

            CategoryAPI data = new CategoryAPI();
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Categoria/" + id.ToString());


            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject<CategoryAPI>(content) ?? new();


            }

            return Convertir(data);
        }

        public CategoryViewModel Update(CategoryViewModel category)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.PutResponse("api/Categoria", Convertir(category));
            if (responseMessage != null)
            {
                var content = responseMessage.Content;
            }


            return category;
        }
    }
}
