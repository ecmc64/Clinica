using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Web.Models
{
    public class HorarioAtencion
    {
        public HorarioAtencion()
        {
            ProgramaAtencion = new HashSet<ProgramaAtencion>();
        }

        public int HorarioAtencionId { get; set; }
        public string DescripcionRango { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<ProgramaAtencion> ProgramaAtencion { get; set; }

    }
}
