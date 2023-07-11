using System;
using System.Collections.Generic;

namespace Domain.Entity;

public partial class Producto
{
    public int Idproducto { get; set; }

    public int Idcategoria { get; set; }

    public string? Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal PrecioVenta { get; set; }

    public int Stock { get; set; }

    public string? Descripcion { get; set; }

    public byte[]? Imagen { get; set; }

    public bool? Estado { get; set; }

    public virtual Categorium IdcategoriaNavigation { get; set; } = null!;
}
