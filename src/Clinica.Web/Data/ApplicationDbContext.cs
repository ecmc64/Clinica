using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clinica.Web.Models;
using System.Data;

namespace Clinica.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }

        //static ApplicationDbContext()
        //{
        //    // Set the database intializer which is run once during application start
        //    // This seeds the database with admin user credentials and admin role
        //    Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        //}

        //public class ApplicationDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
        //{
        //}

        //protected override void Seed(ApplicationDbContext context)
        //{
        //    InitializeIdentityForEF(context);
        //    base.Seed(context);
        //}


        public DbSet<CentroMedico> CentroMedico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Profesional> Profesional { get; set; }
        public DbSet<ProfesionalCentroMedico> ProfesionalCentroMedico { get; set; }
        public DbSet<ProfesionalTipo> ProfesionalTipo { get; set; }
        public DbSet<PacienteCategoria> PacienteCategoria { get; set; }
        public DbSet<Cita> Cita { get; set; }
        public DbSet<Tarifa> Tarifa { get; set; }
        public DbSet<CitaTipo> CitaTipo { get; set; }
        public DbSet<CitaEstado> CitaEstado { get; set; }
        public DbSet<ProfesionalHorario> ProfesionalHorario { get; set; }
        public DbSet<TicketPago> TicketPago { get; set; }
    }
}
