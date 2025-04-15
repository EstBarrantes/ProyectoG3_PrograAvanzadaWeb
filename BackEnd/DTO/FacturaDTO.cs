using Entities.Entities;

namespace BackEnd.DTO
{
    public class FacturaDTO
    {
        public int FacturaId { get; set; }

        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public string Estado { get; set; } = null!;

        public string MetodoPago { get; set; } = null!;

        public ICollection<DetalleFacturaDTO> DetalleFacturas { get; set; } = new List<DetalleFacturaDTO>();

    }
}
