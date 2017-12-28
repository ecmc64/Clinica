using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class CentroMedico
    {
        public int CentroMedicoId { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre")]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefonos { get; set; }
        public bool Estado { get; set; }
        public virtual ICollection<ProfesionalCentroMedico> ProfesionalCentroMedico { get; set; }
        public virtual ICollection<Tarifa> Tarifa { get; set; }
    }
}