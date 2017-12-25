using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class PacienteCategoria // FFVV, Leñador, Externo
    {
        public int PacienteCategoriaId { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<Paciente> Paciente { get; set; }
        public virtual ICollection<Tarifa> Tarifa { get; set; }

    }
}