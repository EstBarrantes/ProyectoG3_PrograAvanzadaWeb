using FrontEnd.ApiModels;

namespace FrontEnd.Models
{
    public class FacturaViewModel
    {
        public int FacturaId { get; set; }

        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public string Estado { get; set; } = null!;

        public string MetodoPago { get; set; } = null!;

        public ICollection<DetalleFacturaViewModel> DetalleFacturas { get; set; } = new List<DetalleFacturaViewModel>();
    }
}
