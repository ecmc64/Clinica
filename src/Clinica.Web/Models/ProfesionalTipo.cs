using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class ProfesionalTipo
    {
        public int ProfesionalTipoId { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public virtual ICollection<Profesional> Profesional { get; set; }
    }
}