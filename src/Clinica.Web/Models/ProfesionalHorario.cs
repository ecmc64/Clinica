using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class ProfesionalHorario
    {
        public int ProfesionalHorarioId { get; set; }
        public string Horario { get; set; }
        public virtual ICollection<ProfesionalCentroMedico> ProfesionalCentroMedico { get; set; }

    }
}