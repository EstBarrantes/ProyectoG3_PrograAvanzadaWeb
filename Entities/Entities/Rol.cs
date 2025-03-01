using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Rol
{
    public int RolId { get; set; }

    public string NombreRol { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
