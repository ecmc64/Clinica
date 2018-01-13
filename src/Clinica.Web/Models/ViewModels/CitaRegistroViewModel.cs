using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Web.Models.ViewModels
{
    public class CitaRegistroViewModel
    {
        public int CitaId { get; set; }
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Fecha de Cita")]
        [DataType(DataType.Date)]
        public DateTime FechaCita { get; set; }
        [DataType(DataType.Time)]
        public DateTime Inicio { get; set; }
        [DataType(DataType.Time)]
        public DateTime Fin { get; set; }
        [Display(Name = "Centro Medico")]
        public int CentroMedicoId { get; set; }
        [Display(Name = "Tipo Cita")]
        public int CitaTipoId { get; set; }
        [Display(Name = "Profesional")]
        public int ProfesionalId { get; set; }
        [Display(Name = "Paciente")]
        public int PacienteId { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}", ApplyFormatInEditMode = true)]
        public double Precio { get; set; }
        [Display(Name = "Nombre Paciente")]
        public string NombrePaciente{ get; set; }
        [Display(Name = "DNI")]
        public string DniPaciente { get; set; }


        public virtual CentroMedico CentroMedico { get; set; }
        public virtual CitaEstado CitaEstado { get; set; }
        public virtual CitaTipo CitaTipo { get; set; }
        public virtual Profesional Profesional { get; set; }
        public virtual Paciente Paciente { get; set; }
    }
}
