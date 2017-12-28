using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class Profesional
    {
        public int ProfesionalId { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre")]
        public string Nombres { get; set; }
        public string Telefonos { get; set; }
        [Display(Name = "Correo")]
        [EmailAddress(ErrorMessage = "E-mail en formato inválido.")]
        public string Email { get; set; }
        public bool Estado { get; set; }
        [Display(Name = "Tipo Profesional")]
        public int ProfesionalTipoId { get; set; }

        public virtual ProfesionalTipo ProfesionalTipo { get; set; }
        public virtual ICollection<ProfesionalCentroMedico> ProfesionalCentroMedico { get; set; }
        public virtual ICollection<Cita> Cita { get; set; }
    }
}