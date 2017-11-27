using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Clinica.Web.Models;

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

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Especialidad> Especialidad { get; set; }
        public DbSet<HorarioAtencion> HorarioAtencion { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<ProgramaAtencion> ProgramaAtencion { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
    }
}
