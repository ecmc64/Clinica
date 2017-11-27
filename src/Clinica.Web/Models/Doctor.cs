using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Web.Models
{
    public class Doctor : Persona
    {
        public Doctor()
        {
            ProgramaAtencion = new HashSet<ProgramaAtencion>();
        }

        public int? EspecialidadId { get; set; }
        public string NumeroColegiatura { get; set; }
        public DateTime? FechaAlta { get; set; }
        //public bool? Estado { get; set; }
        public string Comentario { get; set; }
        //public int DoctorId { get; set; }

        public virtual ICollection<ProgramaAtencion> ProgramaAtencion { get; set; }
        //public virtual Persona Persona { get; set; }
        public virtual Especialidad Especialidad { get; set; }
        //public virtual Persona Persona { get; set; }

    }
}
