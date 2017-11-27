using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Web.Models
{
    public class Especialidad
    {
        public Especialidad()
        {
            Doctor = new HashSet<Doctor>();
        }

        public int EspecialidadId { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }

    }
}
