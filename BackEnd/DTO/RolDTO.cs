using Entities.Entities;

namespace BackEnd.DTO
{
    public class RolDTO
    {
        public int RolId { get; set; }

        public string NombreRol { get; set; } = null!;

        public string? Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
