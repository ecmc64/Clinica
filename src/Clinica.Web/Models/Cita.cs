using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class Cita
    {
        public int CitaId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public string UsuarioRegistra { get; set; }
        public DateTime FechaRegistra { get; set; }
        [Display(Name = "Centro Medico")]
        public int CentroMedicoId { get; set; }
        [Display(Name = "Estado Cita")]
        public int CitaEstadoId { get; set; }
        [Display(Name = "Tipo Cita")]
        public int CitaTipoId { get; set; }
        [Display(Name = "Profesional")]
        public int ProfesionalId { get; set; }
        [Display(Name = "Paciente")]
        public int PacienteId { get; set; }
        public double Precio { get; set; }

        public virtual CentroMedico CentroMedico { get; set; }
        public virtual CitaEstado CitaEstado { get; set; }
        public virtual CitaTipo CitaTipo { get; set; }
        public virtual Profesional Profesional { get; set; }
        public virtual Paciente Paciente { get; set; }

    }
}