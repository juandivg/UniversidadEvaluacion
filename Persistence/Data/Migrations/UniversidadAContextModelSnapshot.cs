﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(UniversidadAContext))]
    partial class UniversidadAContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.AlumnoMatriculaAsignatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("IdAsignaturafk")
                        .HasColumnType("int");

                    b.Property<int>("IdCursoEscolarfk")
                        .HasColumnType("int");

                    b.Property<int>("IdPersonafk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAsignaturafk");

                    b.HasIndex("IdCursoEscolarfk");

                    b.HasIndex("IdPersonafk");

                    b.ToTable("alumno_se_matricula_asignatura", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Asignatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<float>("Creditos")
                        .HasColumnType("float");

                    b.Property<int>("Cuatrimestre")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("Curso")
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    b.Property<int>("IdGradofk")
                        .HasColumnType("int");

                    b.Property<int?>("IdProfesorfk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoAsignaturafk")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("IdGradofk");

                    b.HasIndex("IdProfesorfk");

                    b.HasIndex("IdTipoAsignaturafk");

                    b.ToTable("asignatura", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CursoEscolar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("AnyoFinal")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<int>("AnyoInicio")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("curso_escolar", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("departamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Grado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("grado", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Apellido1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Apellido2")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdSexofk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPersonafk")
                        .HasColumnType("int");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.Property<string>("Telefono")
                        .HasMaxLength(9)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("IdSexofk");

                    b.HasIndex("IdTipoPersonafk");

                    b.ToTable("persona", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamentofk")
                        .HasColumnType("int");

                    b.Property<int>("IdPersonafk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamentofk");

                    b.HasIndex("IdPersonafk");

                    b.ToTable("profesor", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Sexo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("sexo", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TipoAsignatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("tipo_asignatura", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TipoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("tipo_persona", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AlumnoMatriculaAsignatura", b =>
                {
                    b.HasOne("Domain.Entities.Asignatura", "Asignatura")
                        .WithMany("alumnoMatriculaAsignaturas")
                        .HasForeignKey("IdAsignaturafk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.CursoEscolar", "CursoEscolar")
                        .WithMany("AlumnoMatriculaAsignaturas")
                        .HasForeignKey("IdCursoEscolarfk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Persona", "Persona")
                        .WithMany("AlumnoMatriculaAsignaturas")
                        .HasForeignKey("IdPersonafk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asignatura");

                    b.Navigation("CursoEscolar");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Domain.Entities.Asignatura", b =>
                {
                    b.HasOne("Domain.Entities.Grado", "Grado")
                        .WithMany("Asignaturas")
                        .HasForeignKey("IdGradofk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Profesor", "Profesor")
                        .WithMany("Asignaturas")
                        .HasForeignKey("IdProfesorfk");

                    b.HasOne("Domain.Entities.TipoAsignatura", "TipoAsignatura")
                        .WithMany("Asignaturas")
                        .HasForeignKey("IdTipoAsignaturafk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grado");

                    b.Navigation("Profesor");

                    b.Navigation("TipoAsignatura");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.HasOne("Domain.Entities.Sexo", "Sexo")
                        .WithMany("Personas")
                        .HasForeignKey("IdSexofk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TipoPersona", "TipoPersona")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoPersonafk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sexo");

                    b.Navigation("TipoPersona");
                });

            modelBuilder.Entity("Domain.Entities.Profesor", b =>
                {
                    b.HasOne("Domain.Entities.Departamento", "Departamento")
                        .WithMany("Profesores")
                        .HasForeignKey("IdDepartamentofk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Persona", "Persona")
                        .WithMany("Profesores")
                        .HasForeignKey("IdPersonafk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Domain.Entities.Asignatura", b =>
                {
                    b.Navigation("alumnoMatriculaAsignaturas");
                });

            modelBuilder.Entity("Domain.Entities.CursoEscolar", b =>
                {
                    b.Navigation("AlumnoMatriculaAsignaturas");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("Domain.Entities.Grado", b =>
                {
                    b.Navigation("Asignaturas");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Navigation("AlumnoMatriculaAsignaturas");

                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("Domain.Entities.Profesor", b =>
                {
                    b.Navigation("Asignaturas");
                });

            modelBuilder.Entity("Domain.Entities.Sexo", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Domain.Entities.TipoAsignatura", b =>
                {
                    b.Navigation("Asignaturas");
                });

            modelBuilder.Entity("Domain.Entities.TipoPersona", b =>
                {
                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}
