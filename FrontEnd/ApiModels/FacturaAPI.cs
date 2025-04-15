namespace FrontEnd.ApiModels
{
    public class FacturaAPI
    {
        public int FacturaId { get; set; }

        public int UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public string Estado { get; set; } = null!;

        public string MetodoPago { get; set; } = null!;

        public ICollection<DetalleFacturaAPI> DetalleFacturas { get; set; } = new List<DetalleFacturaAPI>();

    }
}
