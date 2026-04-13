using System;
using System.Collections.Generic;

namespace ActividadS5.Models;

public partial class Proyectoempleado
{
    public int Proyectoempleadoid { get; set; }

    public int Proyectoid { get; set; }

    public int Empleadoid { get; set; }

    public string? Rolenproyecto { get; set; }

    public DateOnly? Fechaasignacion { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;
}
