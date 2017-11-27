using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Clinica.Web.Data;

namespace Clinica.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171126010018_mm1")]
    partial class mm1
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

            modelBuilder.Entity("Clinica.Web.Models.Especialidad", b =>
                {
                    b.Property<int>("EspecialidadId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<bool?>("Estado");

                    b.Property<DateTime?>("FechaCreacion");

                    b.HasKey("EspecialidadId");

                    b.ToTable("Especialidad");
                });

            modelBuilder.Entity("Clinica.Web.Models.HorarioAtencion", b =>
                {
                    b.Property<int>("HorarioAtencionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescripcionRango");

                    b.Property<bool?>("Estado");

                    b.HasKey("HorarioAtencionId");

                    b.ToTable("HorarioAtencion");
                });

            modelBuilder.Entity("Clinica.Web.Models.Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApellidoMaterno");

                    b.Property<string>("ApellidoPaterno");

                    b.Property<string>("Direccion");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<bool?>("Estado");

                    b.Property<DateTime?>("FechaNacimiento");

                    b.Property<DateTime?>("FechaRegistro");

                    b.Property<string>("Nombres");

                    b.Property<string>("NroDocumento");

                    b.Property<int?>("TipoDocumentoId");

                    b.HasKey("PersonaId");

                    b.HasIndex("TipoDocumentoId");

                    b.ToTable("Persona");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Clinica.Web.Models.ProgramaAtencion", b =>
                {
                    b.Property<int>("ProgramaAtencionId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("CitaAtendida");

                    b.Property<string>("Diagnostico");

                    b.Property<int>("DoctorId");

                    b.Property<DateTime?>("Fecha");

                    b.Property<DateTime?>("FechaAtencion");

                    b.Property<DateTime?>("FechaDiagnostico");

                    b.Property<int>("HoraAtencionId");

                    b.Property<string>("Observaciones");

                    b.Property<int?>("PersonaId");

                    b.HasKey("ProgramaAtencionId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("HoraAtencionId");

                    b.HasIndex("PersonaId");

                    b.ToTable("ProgramaAtencion");
                });

            modelBuilder.Entity("Clinica.Web.Models.TipoDocumento", b =>
                {
                    b.Property<int>("TipoDocumentoId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("Estado");

                    b.Property<string>("NombreDocumento");

                    b.HasKey("TipoDocumentoId");

                    b.ToTable("TipoDocumento");
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

            modelBuilder.Entity("Clinica.Web.Models.Doctor", b =>
                {
                    b.HasBaseType("Clinica.Web.Models.Persona");

                    b.Property<string>("Comentario");

                    b.Property<int?>("EspecialidadId");

                    b.Property<DateTime?>("FechaAlta");

                    b.Property<string>("NumeroColegiatura");

                    b.HasIndex("EspecialidadId");

                    b.ToTable("Doctor");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("Clinica.Web.Models.Paciente", b =>
                {
                    b.HasBaseType("Clinica.Web.Models.Persona");

                    b.Property<DateTime?>("FechaUltimaVisita");

                    b.Property<string>("Observacion");

                    b.ToTable("Paciente");

                    b.HasDiscriminator().HasValue("Paciente");
                });

            modelBuilder.Entity("Clinica.Web.Models.Persona", b =>
                {
                    b.HasOne("Clinica.Web.Models.TipoDocumento", "TipoDocumento")
                        .WithMany("Persona")
                        .HasForeignKey("TipoDocumentoId");
                });

            modelBuilder.Entity("Clinica.Web.Models.ProgramaAtencion", b =>
                {
                    b.HasOne("Clinica.Web.Models.Doctor", "Doctor")
                        .WithMany("ProgramaAtencion")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinica.Web.Models.HorarioAtencion", "HoraAtencion")
                        .WithMany("ProgramaAtencion")
                        .HasForeignKey("HoraAtencionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Clinica.Web.Models.Paciente", "Persona")
                        .WithMany("ProgramaAtencion")
                        .HasForeignKey("PersonaId");
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

            modelBuilder.Entity("Clinica.Web.Models.Doctor", b =>
                {
                    b.HasOne("Clinica.Web.Models.Especialidad", "Especialidad")
                        .WithMany("Doctor")
                        .HasForeignKey("EspecialidadId");
                });
        }
    }
}
