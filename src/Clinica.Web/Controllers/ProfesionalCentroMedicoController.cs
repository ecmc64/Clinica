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
    public class ProfesionalCentroMedicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfesionalCentroMedicoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ProfesionalCentroMedico
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProfesionalCentroMedico.Include(p => p.CentroMedico).Include(p => p.Profesional).Include(p => p.ProfesionalHorario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProfesionalCentroMedico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesionalCentroMedico = await _context.ProfesionalCentroMedico.SingleOrDefaultAsync(m => m.ProfesionalCentroMedicoId == id);
            if (profesionalCentroMedico == null)
            {
                return NotFound();
            }

            return View(profesionalCentroMedico);
        }

        // GET: ProfesionalCentroMedico/Create
        public IActionResult Create()
        {
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "CentroMedicoId");
            ViewData["ProfesionalId"] = new SelectList(_context.Profesional, "ProfesionalId", "ProfesionalId");
            ViewData["ProfesionalHorarioId"] = new SelectList(_context.ProfesionalHorario, "ProfesionalHorarioId", "ProfesionalHorarioId");
            return View();
        }

        // POST: ProfesionalCentroMedico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfesionalCentroMedicoId,CentroMedicoId,FechaRegistro,ProfesionalHorarioId,ProfesionalId")] ProfesionalCentroMedico profesionalCentroMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesionalCentroMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "CentroMedicoId", profesionalCentroMedico.CentroMedicoId);
            ViewData["ProfesionalId"] = new SelectList(_context.Profesional, "ProfesionalId", "ProfesionalId", profesionalCentroMedico.ProfesionalId);
            ViewData["ProfesionalHorarioId"] = new SelectList(_context.ProfesionalHorario, "ProfesionalHorarioId", "ProfesionalHorarioId", profesionalCentroMedico.ProfesionalHorarioId);
            return View(profesionalCentroMedico);
        }

        // GET: ProfesionalCentroMedico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesionalCentroMedico = await _context.ProfesionalCentroMedico.SingleOrDefaultAsync(m => m.ProfesionalCentroMedicoId == id);
            if (profesionalCentroMedico == null)
            {
                return NotFound();
            }
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "CentroMedicoId", profesionalCentroMedico.CentroMedicoId);
            ViewData["ProfesionalId"] = new SelectList(_context.Profesional, "ProfesionalId", "ProfesionalId", profesionalCentroMedico.ProfesionalId);
            ViewData["ProfesionalHorarioId"] = new SelectList(_context.ProfesionalHorario, "ProfesionalHorarioId", "ProfesionalHorarioId", profesionalCentroMedico.ProfesionalHorarioId);
            return View(profesionalCentroMedico);
        }

        // POST: ProfesionalCentroMedico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfesionalCentroMedicoId,CentroMedicoId,FechaRegistro,ProfesionalHorarioId,ProfesionalId")] ProfesionalCentroMedico profesionalCentroMedico)
        {
            if (id != profesionalCentroMedico.ProfesionalCentroMedicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesionalCentroMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionalCentroMedicoExists(profesionalCentroMedico.ProfesionalCentroMedicoId))
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
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "CentroMedicoId", profesionalCentroMedico.CentroMedicoId);
            ViewData["ProfesionalId"] = new SelectList(_context.Profesional, "ProfesionalId", "ProfesionalId", profesionalCentroMedico.ProfesionalId);
            ViewData["ProfesionalHorarioId"] = new SelectList(_context.ProfesionalHorario, "ProfesionalHorarioId", "ProfesionalHorarioId", profesionalCentroMedico.ProfesionalHorarioId);
            return View(profesionalCentroMedico);
        }

        // GET: ProfesionalCentroMedico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesionalCentroMedico = await _context.ProfesionalCentroMedico.SingleOrDefaultAsync(m => m.ProfesionalCentroMedicoId == id);
            if (profesionalCentroMedico == null)
            {
                return NotFound();
            }

            return View(profesionalCentroMedico);
        }

        // POST: ProfesionalCentroMedico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesionalCentroMedico = await _context.ProfesionalCentroMedico.SingleOrDefaultAsync(m => m.ProfesionalCentroMedicoId == id);
            _context.ProfesionalCentroMedico.Remove(profesionalCentroMedico);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProfesionalCentroMedicoExists(int id)
        {
            return _context.ProfesionalCentroMedico.Any(e => e.ProfesionalCentroMedicoId == id);
        }
    }
}
