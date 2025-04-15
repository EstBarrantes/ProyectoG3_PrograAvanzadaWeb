using Entities.Entities;

namespace BackEnd.DTO
{
    public class DetalleFacturaDTO
    {
        public int DetalleId { get; set; }

        public int FacturaId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal { get; set; }


    }
}
