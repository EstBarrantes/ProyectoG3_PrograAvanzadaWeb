using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class ProductoViewModel
    {
        public int ProductoId { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int CategoriaId { get; set; }
        public IEnumerable<CategoryViewModel> Categorias { get; set; }
        [Display(Name = "Nombre de Categoria")]
        public string CategoriaNombre { get; set; }
        public string? ImagenUrl { get; set; }

        public DateTime FechaAgregado { get; set; }

        public decimal? Descuento { get; set; }
    }
}
