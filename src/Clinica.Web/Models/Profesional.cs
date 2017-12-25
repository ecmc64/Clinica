using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class Profesional
    {
        public int ProfesionalId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefonos { get; set; }
        public string Email { get; set; }
        public bool Estado { get; set; }
        public int ProfesionalTipoId { get; set; }

        public virtual ProfesionalTipo ProfesionalTipo { get; set; }
        public virtual ICollection<ProfesionalCentroMedico> ProfesionalCentroMedico { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
    }
}