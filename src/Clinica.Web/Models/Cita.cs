using System;
using System.Collections.Generic;
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
        public int CentroMedicoId { get; set; }
        public int CitaEstadoId { get; set; }
        public int CitaTipoId { get; set; }
        public int ProfesionalId { get; set; }
        public int PacienteId { get; set; }
        public double Precio { get; set; }

        public virtual CentroMedico CentroMedico { get; set; }
        public virtual CitaEstado CitaEstado { get; set; }
        public virtual CitaTipo CitaTipo { get; set; }
        public virtual Profesional Profesional { get; set; }
        public virtual Paciente Paciente { get; set; }

    }
}