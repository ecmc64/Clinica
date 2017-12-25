using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class CitaEstado
    {
        public int CitaEstadoId { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
    }
}