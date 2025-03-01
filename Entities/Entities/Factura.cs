using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Factura
{
    public int FacturaId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime Fecha { get; set; }

    public decimal Total { get; set; }

    public string Estado { get; set; } = null!;

    public string MetodoPago { get; set; } = null!;

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Usuario Usuario { get; set; } = null!;
}
