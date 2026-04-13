using System;
using System.Collections.Generic;

namespace ActividadS5.Models;

public partial class Hitoproyecto
{
    public int Hitoproyectoid { get; set; }

    public int Proyectoid { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? Fechaplanificada { get; set; }

    public DateOnly? Fechacumplimiento { get; set; }

    public string? Estado { get; set; }

    public virtual Proyecto Proyecto { get; set; } = null!;
}
