using System;
using System.Collections.Generic;

namespace ActividadS5.Models;

public partial class Costoproyecto
{
    public int Costoproyectoid { get; set; }

    public int Proyectoid { get; set; }

    public DateOnly? Fechagasto { get; set; }

    public string? Concepto { get; set; }

    public decimal? Monto { get; set; }

    public string? Tipocosto { get; set; }

    public virtual Proyecto Proyecto { get; set; } = null!;
}
