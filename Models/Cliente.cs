using System;
using System.Collections.Generic;

namespace ActividadS5.Models;

public partial class Cliente
{
    public int Clienteid { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Razonsocial { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public DateTime? Fecharegistro { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Interaccioncliente> Interaccionclientes { get; set; } = new List<Interaccioncliente>();

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
