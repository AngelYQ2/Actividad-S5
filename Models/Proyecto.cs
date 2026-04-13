using System;
using System.Collections.Generic;

namespace ActividadS5.Models;

public partial class Proyecto
{
    public int Proyectoid { get; set; }

    public int Clienteid { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Objetivos { get; set; }

    public DateOnly Fechainicio { get; set; }

    public DateOnly? Fechafinestimada { get; set; }

    public DateOnly? Fechafinreal { get; set; }

    public string? Estado { get; set; }

    public decimal? Presupuestoestimado { get; set; }

    public decimal? Gastoreal { get; set; }

    public int? Responsableprincipalid { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<Costoproyecto> Costoproyectos { get; set; } = new List<Costoproyecto>();

    public virtual ICollection<Hitoproyecto> Hitoproyectos { get; set; } = new List<Hitoproyecto>();

    public virtual ICollection<Informeprogreso> Informeprogresos { get; set; } = new List<Informeprogreso>();

    public virtual ICollection<Interaccioncliente> Interaccionclientes { get; set; } = new List<Interaccioncliente>();

    public virtual ICollection<Proyectoempleado> Proyectoempleados { get; set; } = new List<Proyectoempleado>();

    public virtual Empleado? Responsableprincipal { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
