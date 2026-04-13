using System;
using System.Collections.Generic;

namespace ActividadS5.Models;

public partial class Informeprogreso
{
    public int Informeprogresoid { get; set; }

    public int Proyectoid { get; set; }

    public int Empleadoid { get; set; }

    public DateOnly? Fechainforme { get; set; }

    public decimal? Porcentajeavance { get; set; }

    public string? Resumenavance { get; set; }

    public string? Observaciones { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;
}
