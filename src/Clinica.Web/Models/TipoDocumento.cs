using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Web.Models
{
    public class TipoDocumento
    {
        public TipoDocumento()
        {
            Persona = new HashSet<Persona>();
        }

        public int TipoDocumentoId { get; set; }
        public string NombreDocumento { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }

    }
}
