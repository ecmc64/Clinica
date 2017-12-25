using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class ProfesionalCentroMedico
    {
        public int ProfesionalCentroMedicoId { get; set; }
        public int ProfesionalId { get; set; }
        public int CentroMedicoId { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int ProfesionalHorarioId { get; set; }

        public virtual CentroMedico CentroMedico { get; set; }
        public virtual Profesional Profesional { get; set; }
        public virtual ProfesionalHorario ProfesionalHorario { get; set; }
    }
}