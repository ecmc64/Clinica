using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Web.Models
{
    public class TicketPago
    {
        public int TicketPagoId { get; set; }
        public int CitaId { get; set; }
        public bool Pagado { get; set; }
        public string NumeroComprobante { get; set; }

        public virtual Cita Cita { get; set; }

    }
}