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
    public class CitaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitaController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Cita
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cita.Include(c => c.CentroMedico).Include(c => c.CitaEstado).Include(c => c.CitaTipo).Include(c => c.Paciente).Include(c => c.Profesional);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.SingleOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // GET: Cita/Create
        public IActionResult Create()
        {
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "CentroMedicoId");
            ViewData["CitaEstadoId"] = new SelectList(_context.CitaEstado, "CitaEstadoId", "CitaEstadoId");
            ViewData["CitaTipoId"] = new SelectList(_context.CitaTipo, "CitaTipoId", "CitaTipoId");
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "PacienteId", "PacienteId");
            ViewData["ProfesionalId"] = new SelectList(_context.Profesional, "ProfesionalId", "ProfesionalId");
            return View();
        }

        // POST: Cita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitaId,CentroMedicoId,CitaEstadoId,CitaTipoId,Descripcion,FechaRegistra,Fin,Inicio,Observacion,PacienteId,Precio,ProfesionalId,UsuarioRegistra")] Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "CentroMedicoId", cita.CentroMedicoId);
            ViewData["CitaEstadoId"] = new SelectList(_context.CitaEstado, "CitaEstadoId", "CitaEstadoId", cita.CitaEstadoId);
            ViewData["CitaTipoId"] = new SelectList(_context.CitaTipo, "CitaTipoId", "CitaTipoId", cita.CitaTipoId);
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "PacienteId", "PacienteId", cita.PacienteId);
            ViewData["ProfesionalId"] = new SelectList(_context.Profesional, "ProfesionalId", "ProfesionalId", cita.ProfesionalId);
            return View(cita);
        }

        // GET: Cita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.SingleOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "CentroMedicoId", cita.CentroMedicoId);
            ViewData["CitaEstadoId"] = new SelectList(_context.CitaEstado, "CitaEstadoId", "CitaEstadoId", cita.CitaEstadoId);
            ViewData["CitaTipoId"] = new SelectList(_context.CitaTipo, "CitaTipoId", "CitaTipoId", cita.CitaTipoId);
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "PacienteId", "PacienteId", cita.PacienteId);
            ViewData["ProfesionalId"] = new SelectList(_context.Profesional, "ProfesionalId", "ProfesionalId", cita.ProfesionalId);
            return View(cita);
        }

        // POST: Cita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitaId,CentroMedicoId,CitaEstadoId,CitaTipoId,Descripcion,FechaRegistra,Fin,Inicio,Observacion,PacienteId,Precio,ProfesionalId,UsuarioRegistra")] Cita cita)
        {
            if (id != cita.CitaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaExists(cita.CitaId))
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
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "CentroMedicoId", cita.CentroMedicoId);
            ViewData["CitaEstadoId"] = new SelectList(_context.CitaEstado, "CitaEstadoId", "CitaEstadoId", cita.CitaEstadoId);
            ViewData["CitaTipoId"] = new SelectList(_context.CitaTipo, "CitaTipoId", "CitaTipoId", cita.CitaTipoId);
            ViewData["PacienteId"] = new SelectList(_context.Paciente, "PacienteId", "PacienteId", cita.PacienteId);
            ViewData["ProfesionalId"] = new SelectList(_context.Profesional, "ProfesionalId", "ProfesionalId", cita.ProfesionalId);
            return View(cita);
        }

        // GET: Cita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.SingleOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            return View(cita);
        }

        // POST: Cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Cita.SingleOrDefaultAsync(m => m.CitaId == id);
            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CitaExists(int id)
        {
            return _context.Cita.Any(e => e.CitaId == id);
        }
    }
}
