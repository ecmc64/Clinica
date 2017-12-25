using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Clinica.Web.Data;

namespace Clinica.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171223133222_m2")]
    partial class m2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Clinica.Web.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Clinica.Web.Models.CentroMedico", b =>
                {
                    b.Property<int>("CentroMedicoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Direccion");

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre");

                    b.Property<string>("Telefonos");

                    b.HasKey("CentroMedicoId");

                    b.ToTable("CentroMedico");
                });

            modelBuilder.Entity("Clinica.Web.Models.Cita", b =>
                {
                    b.Property<int>("CitaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CentroMedicoId");

                    b.Property<int>("CitaEstadoId");

                    b.Property<int>("CitaTipoId");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaRegistra");

                    b.Property<DateTime>("Fin");

                    b.Property<DateTime>("Inicio");

                    b.Property<string>("Observacion");

                    b.Property<int>("PacienteId");

                    b.Property<double>("Precio");

                    b.Property<int>("ProfesionalId");

                    b.Property<string>("UsuarioRegistra");

                    b.HasKey("CitaId");

                    b.HasIndex("CentroMedicoId");

                    b.HasIndex("CitaEstadoId");

                    b.HasIndex("CitaTipoId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("ProfesionalId");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("Clinica.Web.Models.CitaEstado", b =>
                {
                    b.Property<int>("CitaEstadoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<bool>("Estado");

                    b.HasKey("CitaEstadoId");

                    b.ToTable("CitaEstado");
                });

            modelBuilder.Entity("Clinica.Web.Models.CitaTipo", b =>
                {
                    b.Property<int>("CitaTipoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<bool>("Estado");

                    b.HasKey("CitaTipoId");

                    b.ToTable("CitaTipo");
                });

            modelBuilder.Entity("Clinica.Web.Models.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApellidoMaterno");

                    b.Property<string>("ApellidoPaterno");

                    b.Property<string>("Direccion");

                    b.Property<string>("Email");

                    b.Property<bool>("Estado");

                    b.Property<DateTime?>("FechaNacimiento");

                    b.Property<string>("Nombres");

                    b.Property<string>("NumeroDocumento");

                    b.Property<int>("PacienteCategoriaId");

                    b.Property<string>("Telefonos");

                    b.HasKey("PacienteId");

                    b.HasIndex("PacienteCategoriaId");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("Clinica.Web.Models.PacienteCategoria", b =>
                {
                    b.Property<int>("PacienteCategoriaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<bool>("Estado");

                    b.HasKey("PacienteCategoriaId");

                    b.ToTable("PacienteCategoria");
                });

            modelBuilder.Entity("Clinica.Web.Models.Profesional", b =>
                {
                    b.Property<int>("ProfesionalId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellidos");

                    b.Property<string>("Email");

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombres");

                    b.Property<int>("ProfesionalTipoId");

                    b.Property<string>("Telefonos");

                    b.HasKey("ProfesionalId");

                    b.HasIndex("ProfesionalTipoId");

                    b.ToTable("Profesional");
                });

            modelBuilder.Entity("Clinica.Web.Models.ProfesionalCentroMedico", b =>
                {
                    b.Property<int>("ProfesionalCentroMedicoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CentroMedicoId");

                    b.Property<DateTime?>("FechaRegistro");

                    b.Property<int>("ProfesionalHorarioId");

                    b.Property<int>("ProfesionalId");

                    b.HasKey("ProfesionalCentroMedicoId");

                    b.HasIndex("CentroMedicoId");

                    b.HasIndex("ProfesionalHorarioId");

                    b.HasIndex("ProfesionalId");

                    b.ToTable("ProfesionalCentroMedico");
                });

            modelBuilder.Entity("Clinica.Web.Models.ProfesionalHorario", b =>
                {
                    b.Property<int>("ProfesionalHorarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Horario");

                    b.HasKey("ProfesionalHorarioId");

                    b.ToTable("ProfesionalHorario");
                });

            modelBuilder.Entity("Clinica.Web.Models.ProfesionalTipo", b =>
                {
                    b.Property<int>("ProfesionalTipoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<bool>("Estado");

                    b.HasKey("ProfesionalTipoId");

                    b.ToTable("ProfesionalTipo");
                });

            modelBuilder.Entity("Clinica.Web.Models.Tarifa", b =>
                {
                    b.Property<int>("TarifaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CentroMedicoId");

                    b.Property<int>("CitaTipoId");

                    b.Property<bool>("Estado");

                    b.Property<int>("PacienteCategoriaId");

                    b.Property<double>("Precio");

                    b.HasKey("TarifaId");

                    b.HasIndex("CentroMedicoId");

                    b.HasIndex("CitaTipoId");

                    b.HasIndex("PacienteCategoriaId");

                    b.ToTable("Tarifa");
                });

            modelBuilder.Entity("Clinica.Web.Models.TicketPago", b =>
                {
                    b.Property<int>("TicketPagoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CitaId");

                    b.Property<string>("NumeroComprobante");

                    b.Property<bool>("Pagado");

                    b.HasKey("TicketPagoId");

                    b.HasIndex("CitaId");

                    b.ToTable("TicketPago");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Clinica.Web.Models.Cita", b =>
                {
                    b.HasOne("Clinica.Web.Models.CentroMedico", "CentroMedico")
                        .WithMany()
                        .HasForeignKey("CentroMedicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinica.Web.Models.CitaEstado", "CitaEstado")
                        .WithMany("Cita")
                        .HasForeignKey("CitaEstadoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinica.Web.Models.CitaTipo", "CitaTipo")
                        .WithMany("Cita")
                        .HasForeignKey("CitaTipoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinica.Web.Models.Paciente", "Paciente")
                        .WithMany("Cita")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinica.Web.Models.Profesional", "Profesional")
                        .WithMany("Cita")
                        .HasForeignKey("ProfesionalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clinica.Web.Models.Paciente", b =>
                {
                    b.HasOne("Clinica.Web.Models.PacienteCategoria", "PacienteCategoria")
                        .WithMany("Paciente")
                        .HasForeignKey("PacienteCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clinica.Web.Models.Profesional", b =>
                {
                    b.HasOne("Clinica.Web.Models.ProfesionalTipo", "ProfesionalTipo")
                        .WithMany("Profesional")
                        .HasForeignKey("ProfesionalTipoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clinica.Web.Models.ProfesionalCentroMedico", b =>
                {
                    b.HasOne("Clinica.Web.Models.CentroMedico", "CentroMedico")
                        .WithMany("ProfesionalCentroMedico")
                        .HasForeignKey("CentroMedicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinica.Web.Models.ProfesionalHorario", "ProfesionalHorario")
                        .WithMany("ProfesionalCentroMedico")
                        .HasForeignKey("ProfesionalHorarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinica.Web.Models.Profesional", "Profesional")
                        .WithMany("ProfesionalCentroMedico")
                        .HasForeignKey("ProfesionalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clinica.Web.Models.Tarifa", b =>
                {
                    b.HasOne("Clinica.Web.Models.CentroMedico", "CentroMedico")
                        .WithMany("Tarifa")
                        .HasForeignKey("CentroMedicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinica.Web.Models.CitaTipo", "CitaTipo")
                        .WithMany("Tarifa")
                        .HasForeignKey("CitaTipoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinica.Web.Models.PacienteCategoria", "PacienteCategoria")
                        .WithMany("Tarifa")
                        .HasForeignKey("PacienteCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Clinica.Web.Models.TicketPago", b =>
                {
                    b.HasOne("Clinica.Web.Models.Cita", "Cita")
                        .WithMany()
                        .HasForeignKey("CitaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Clinica.Web.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Clinica.Web.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinica.Web.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
