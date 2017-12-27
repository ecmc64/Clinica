using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre")]
        public string Nombres { get; set; }
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }
        public string Telefonos { get; set; }
        public string Direccion { get; set; }
        //[EmailAddress(ErrorMessage = "E-mail en formato inválido.")]
        public string Email { get; set; }
        [Display(Name = "Numero de Documento")]
        public string NumeroDocumento { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }
        public bool Estado { get; set; }
        [Display(Name = "Categoria Paciente")]
        public int PacienteCategoriaId { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
        public virtual PacienteCategoria PacienteCategoria { get; set; }
    }
}