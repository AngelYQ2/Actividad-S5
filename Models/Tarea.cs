using System;
using System.Collections.Generic;

namespace ActividadS5.Models;

public partial class Tarea
{
    public int Tareaid { get; set; }

    public int Proyectoid { get; set; }

    public int Empleadoid { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? Fechainicio { get; set; }

    public DateOnly? Fechavencimiento { get; set; }

    public string? Estado { get; set; }

    public decimal? Avanceporcentaje { get; set; }

    public string? Prioridad { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;
}
