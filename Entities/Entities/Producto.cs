using System;
using System.Collections.Generic;

namespace Entities.Entities;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int CategoriaId { get; set; }

    public string? ImagenUrl { get; set; }

    public DateTime FechaAgregado { get; set; }

    public decimal? Descuento { get; set; }

    public virtual Categorium Categoria { get; set; } = null!;

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
