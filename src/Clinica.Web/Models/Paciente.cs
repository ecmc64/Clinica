using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefonos { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool Estado { get; set; }
        public int PacienteCategoriaId { get; set; }

        public virtual ICollection<Cita> Cita { get; set; }
        public virtual PacienteCategoria PacienteCategoria { get; set; }
    }
}