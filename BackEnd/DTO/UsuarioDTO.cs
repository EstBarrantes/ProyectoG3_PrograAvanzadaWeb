using DAL.Implementations;
using Entities.Entities;

namespace BackEnd.DTO
{
    public class UsuarioDTO
    {


        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public string Correo { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public int RolId { get; set; }

        public DateTime FechaRegistro { get; set; }

        public bool Activo { get; set; }

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

        public virtual Rol Rol { get; set; } = null!;
    }
}
