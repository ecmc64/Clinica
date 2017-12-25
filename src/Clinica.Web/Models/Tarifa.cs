using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class Tarifa
    {
        public int TarifaId { get; set; }
        public int CentroMedicoId { get; set; }
        public int PacienteCategoriaId { get; set; }
        public int CitaTipoId { get; set; }
        public double Precio { get; set; }
        public bool Estado { get; set; }

        public virtual CentroMedico CentroMedico { get; set; }
        public virtual PacienteCategoria PacienteCategoria { get; set; }
        public virtual CitaTipo CitaTipo { get; set; }
    }
}