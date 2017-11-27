using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Web.Models
{
    public class Paciente : Persona
    {
        public Paciente()
        {
            ProgramaAtencion = new HashSet<ProgramaAtencion>();
        }

        public DateTime? FechaUltimaVisita { get; set; }
        public string Observacion { get; set; }
        //public int PersonaId { get; set; }

        public virtual ICollection<ProgramaAtencion> ProgramaAtencion { get; set; }
        //public virtual Persona Persona { get; set; }

    }
}
