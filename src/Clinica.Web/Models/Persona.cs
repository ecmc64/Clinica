using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Web.Models
{
    public class Persona
    {
        public string NroDocumento { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public int PersonaId { get; set; }
        public int? TipoDocumentoId { get; set; }

        //public virtual Doctor Doctor { get; set; }
        //public virtual Paciente Paciente { get; set; }
        ////public virtual Usuarios Usuarios { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }

    }
}
