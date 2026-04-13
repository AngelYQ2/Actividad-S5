using System;
using System.Collections.Generic;

namespace ActividadS5.Models;

public partial class Interaccioncliente
{
    public int Interaccionclienteid { get; set; }

    public int Clienteid { get; set; }

    public int? Proyectoid { get; set; }

    public int Empleadoid { get; set; }

    public string? Tipointeraccion { get; set; }

    public DateTime? Fechahora { get; set; }

    public string? Asunto { get; set; }

    public string? Detalle { get; set; }

    public string? Medio { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Proyecto? Proyecto { get; set; }
}
