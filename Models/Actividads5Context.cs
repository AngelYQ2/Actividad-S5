using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ActividadS5.Models;

public partial class Actividads5Context : DbContext
{
    public Actividads5Context()
    {
    }

    public Actividads5Context(DbContextOptions<Actividads5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Costoproyecto> Costoproyectos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Hitoproyecto> Hitoproyectos { get; set; }

    public virtual DbSet<Informeprogreso> Informeprogresos { get; set; }

    public virtual DbSet<Interaccioncliente> Interaccionclientes { get; set; }

    public virtual DbSet<Proyecto> Proyectos { get; set; }

    public virtual DbSet<Proyectoempleado> Proyectoempleados { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=actividads5;user=root;password=;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.42-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Clienteid).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecharegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .HasColumnName("nombre");
            entity.Property(e => e.Razonsocial)
                .HasMaxLength(200)
                .HasColumnName("razonsocial");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Costoproyecto>(entity =>
        {
            entity.HasKey(e => e.Costoproyectoid).HasName("PRIMARY");

            entity.ToTable("costoproyecto");

            entity.HasIndex(e => e.Proyectoid, "proyectoid");

            entity.Property(e => e.Costoproyectoid).HasColumnName("costoproyectoid");
            entity.Property(e => e.Concepto)
                .HasMaxLength(200)
                .HasColumnName("concepto");
            entity.Property(e => e.Fechagasto).HasColumnName("fechagasto");
            entity.Property(e => e.Monto)
                .HasPrecision(12, 2)
                .HasColumnName("monto");
            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");
            entity.Property(e => e.Tipocosto)
                .HasMaxLength(50)
                .HasColumnName("tipocosto");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Costoproyectos)
                .HasForeignKey(d => d.Proyectoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("costoproyecto_ibfk_1");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Empleadoid).HasName("PRIMARY");

            entity.ToTable("empleado");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.Empleadoid).HasColumnName("empleadoid");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .HasColumnName("apellidos");
            entity.Property(e => e.Cargo)
                .HasMaxLength(100)
                .HasColumnName("cargo");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Fechaingreso).HasColumnName("fechaingreso");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .HasColumnName("nombres");
            entity.Property(e => e.Telefono)
                .HasMaxLength(30)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Hitoproyecto>(entity =>
        {
            entity.HasKey(e => e.Hitoproyectoid).HasName("PRIMARY");

            entity.ToTable("hitoproyecto");

            entity.HasIndex(e => e.Proyectoid, "proyectoid");

            entity.Property(e => e.Hitoproyectoid).HasColumnName("hitoproyectoid");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasColumnName("estado");
            entity.Property(e => e.Fechacumplimiento).HasColumnName("fechacumplimiento");
            entity.Property(e => e.Fechaplanificada).HasColumnName("fechaplanificada");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Hitoproyectos)
                .HasForeignKey(d => d.Proyectoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hitoproyecto_ibfk_1");
        });

        modelBuilder.Entity<Informeprogreso>(entity =>
        {
            entity.HasKey(e => e.Informeprogresoid).HasName("PRIMARY");

            entity.ToTable("informeprogreso");

            entity.HasIndex(e => e.Empleadoid, "empleadoid");

            entity.HasIndex(e => e.Proyectoid, "proyectoid");

            entity.Property(e => e.Informeprogresoid).HasColumnName("informeprogresoid");
            entity.Property(e => e.Empleadoid).HasColumnName("empleadoid");
            entity.Property(e => e.Fechainforme).HasColumnName("fechainforme");
            entity.Property(e => e.Observaciones)
                .HasColumnType("text")
                .HasColumnName("observaciones");
            entity.Property(e => e.Porcentajeavance)
                .HasPrecision(5, 2)
                .HasColumnName("porcentajeavance");
            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");
            entity.Property(e => e.Resumenavance)
                .HasColumnType("text")
                .HasColumnName("resumenavance");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Informeprogresos)
                .HasForeignKey(d => d.Empleadoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("informeprogreso_ibfk_2");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Informeprogresos)
                .HasForeignKey(d => d.Proyectoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("informeprogreso_ibfk_1");
        });

        modelBuilder.Entity<Interaccioncliente>(entity =>
        {
            entity.HasKey(e => e.Interaccionclienteid).HasName("PRIMARY");

            entity.ToTable("interaccioncliente");

            entity.HasIndex(e => e.Clienteid, "clienteid");

            entity.HasIndex(e => e.Empleadoid, "empleadoid");

            entity.HasIndex(e => e.Proyectoid, "proyectoid");

            entity.Property(e => e.Interaccionclienteid).HasColumnName("interaccionclienteid");
            entity.Property(e => e.Asunto)
                .HasMaxLength(200)
                .HasColumnName("asunto");
            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Detalle)
                .HasColumnType("text")
                .HasColumnName("detalle");
            entity.Property(e => e.Empleadoid).HasColumnName("empleadoid");
            entity.Property(e => e.Fechahora)
                .HasColumnType("datetime")
                .HasColumnName("fechahora");
            entity.Property(e => e.Medio)
                .HasMaxLength(50)
                .HasColumnName("medio");
            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");
            entity.Property(e => e.Tipointeraccion)
                .HasMaxLength(50)
                .HasColumnName("tipointeraccion");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Interaccionclientes)
                .HasForeignKey(d => d.Clienteid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("interaccioncliente_ibfk_1");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Interaccionclientes)
                .HasForeignKey(d => d.Empleadoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("interaccioncliente_ibfk_3");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Interaccionclientes)
                .HasForeignKey(d => d.Proyectoid)
                .HasConstraintName("interaccioncliente_ibfk_2");
        });

        modelBuilder.Entity<Proyecto>(entity =>
        {
            entity.HasKey(e => e.Proyectoid).HasName("PRIMARY");

            entity.ToTable("proyecto");

            entity.HasIndex(e => e.Clienteid, "clienteid");

            entity.HasIndex(e => e.Responsableprincipalid, "responsableprincipalid");

            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");
            entity.Property(e => e.Clienteid).HasColumnName("clienteid");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasColumnName("estado");
            entity.Property(e => e.Fechafinestimada).HasColumnName("fechafinestimada");
            entity.Property(e => e.Fechafinreal).HasColumnName("fechafinreal");
            entity.Property(e => e.Fechainicio).HasColumnName("fechainicio");
            entity.Property(e => e.Gastoreal)
                .HasPrecision(12, 2)
                .HasColumnName("gastoreal");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .HasColumnName("nombre");
            entity.Property(e => e.Objetivos)
                .HasColumnType("text")
                .HasColumnName("objetivos");
            entity.Property(e => e.Presupuestoestimado)
                .HasPrecision(12, 2)
                .HasColumnName("presupuestoestimado");
            entity.Property(e => e.Responsableprincipalid).HasColumnName("responsableprincipalid");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.Clienteid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyecto_ibfk_1");

            entity.HasOne(d => d.Responsableprincipal).WithMany(p => p.Proyectos)
                .HasForeignKey(d => d.Responsableprincipalid)
                .HasConstraintName("proyecto_ibfk_2");
        });

        modelBuilder.Entity<Proyectoempleado>(entity =>
        {
            entity.HasKey(e => e.Proyectoempleadoid).HasName("PRIMARY");

            entity.ToTable("proyectoempleado");

            entity.HasIndex(e => e.Empleadoid, "empleadoid");

            entity.HasIndex(e => new { e.Proyectoid, e.Empleadoid }, "proyectoid").IsUnique();

            entity.Property(e => e.Proyectoempleadoid).HasColumnName("proyectoempleadoid");
            entity.Property(e => e.Empleadoid).HasColumnName("empleadoid");
            entity.Property(e => e.Fechaasignacion).HasColumnName("fechaasignacion");
            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");
            entity.Property(e => e.Rolenproyecto)
                .HasMaxLength(100)
                .HasColumnName("rolenproyecto");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Proyectoempleados)
                .HasForeignKey(d => d.Empleadoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyectoempleado_ibfk_2");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Proyectoempleados)
                .HasForeignKey(d => d.Proyectoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("proyectoempleado_ibfk_1");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.Tareaid).HasName("PRIMARY");

            entity.ToTable("tarea");

            entity.HasIndex(e => e.Empleadoid, "empleadoid");

            entity.HasIndex(e => e.Proyectoid, "proyectoid");

            entity.Property(e => e.Tareaid).HasColumnName("tareaid");
            entity.Property(e => e.Avanceporcentaje)
                .HasPrecision(5, 2)
                .HasColumnName("avanceporcentaje");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Empleadoid).HasColumnName("empleadoid");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .HasColumnName("estado");
            entity.Property(e => e.Fechainicio).HasColumnName("fechainicio");
            entity.Property(e => e.Fechavencimiento).HasColumnName("fechavencimiento");
            entity.Property(e => e.Prioridad)
                .HasMaxLength(20)
                .HasColumnName("prioridad");
            entity.Property(e => e.Proyectoid).HasColumnName("proyectoid");
            entity.Property(e => e.Titulo)
                .HasMaxLength(200)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.Empleadoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tarea_ibfk_2");

            entity.HasOne(d => d.Proyecto).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.Proyectoid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tarea_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
