using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Web.Data;
using Clinica.Web.Models;

namespace Clinica.Web.Controllers
{
    public class TicketPagoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketPagoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TicketPago
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TicketPago.Include(t => t.Cita);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TicketPago/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPago = await _context.TicketPago.SingleOrDefaultAsync(m => m.TicketPagoId == id);
            if (ticketPago == null)
            {
                return NotFound();
            }

            return View(ticketPago);
        }

        // GET: TicketPago/Create
        public IActionResult Create()
        {
            ViewData["CitaId"] = new SelectList(_context.Cita, "CitaId", "CitaId");
            return View();
        }

        // POST: TicketPago/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketPagoId,CitaId,MontoPagado,NumeroComprobante,Pagado,Vuelto")] TicketPago ticketPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketPago);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CitaId"] = new SelectList(_context.Cita, "CitaId", "CitaId", ticketPago.CitaId);
            return View(ticketPago);
        }

        // GET: TicketPago/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPago = await _context.TicketPago.SingleOrDefaultAsync(m => m.TicketPagoId == id);
            if (ticketPago == null)
            {
                return NotFound();
            }
            ViewData["CitaId"] = new SelectList(_context.Cita, "CitaId", "CitaId", ticketPago.CitaId);
            return View(ticketPago);
        }

        // POST: TicketPago/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketPagoId,CitaId,MontoPagado,NumeroComprobante,Pagado,Vuelto")] TicketPago ticketPago)
        {
            if (id != ticketPago.TicketPagoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketPagoExists(ticketPago.TicketPagoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CitaId"] = new SelectList(_context.Cita, "CitaId", "CitaId", ticketPago.CitaId);
            return View(ticketPago);
        }

        // GET: TicketPago/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPago = await _context.TicketPago.SingleOrDefaultAsync(m => m.TicketPagoId == id);
            if (ticketPago == null)
            {
                return NotFound();
            }

            return View(ticketPago);
        }

        // POST: TicketPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketPago = await _context.TicketPago.SingleOrDefaultAsync(m => m.TicketPagoId == id);
            _context.TicketPago.Remove(ticketPago);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TicketPagoExists(int id)
        {
            return _context.TicketPago.Any(e => e.TicketPagoId == id);
        }
    }
}
