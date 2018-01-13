using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class TicketPago
    {
        public int TicketPagoId { get; set; }
        public int CitaId { get; set; }
        public bool Pagado { get; set; }
        [Display(Name = "Numero de Comprobante")]
        public string NumeroComprobante { get; set; }
        [Display(Name = "Monto a pagar")]
        public double MontoPagado { get; set; }
        public double Vuelto { get; set; }

        public virtual Cita Cita { get; set; }

    }
}