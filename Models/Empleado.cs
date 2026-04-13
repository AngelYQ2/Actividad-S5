using System;
using System.Collections.Generic;

namespace ActividadS5.Models;

public partial class Empleado
{
    public int Empleadoid { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Cargo { get; set; }

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateOnly? Fechaingreso { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<Informeprogreso> Informeprogresos { get; set; } = new List<Informeprogreso>();

    public virtual ICollection<Interaccioncliente> Interaccionclientes { get; set; } = new List<Interaccioncliente>();

    public virtual ICollection<Proyectoempleado> Proyectoempleados { get; set; } = new List<Proyectoempleado>();

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
