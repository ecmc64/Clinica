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
    public class ProfesionalHorarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfesionalHorarioController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ProfesionalHorario
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfesionalHorario.ToListAsync());
        }

        // GET: ProfesionalHorario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesionalHorario = await _context.ProfesionalHorario.SingleOrDefaultAsync(m => m.ProfesionalHorarioId == id);
            if (profesionalHorario == null)
            {
                return NotFound();
            }

            return View(profesionalHorario);
        }

        // GET: ProfesionalHorario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfesionalHorario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfesionalHorarioId,Horario")] ProfesionalHorario profesionalHorario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesionalHorario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(profesionalHorario);
        }

        // GET: ProfesionalHorario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesionalHorario = await _context.ProfesionalHorario.SingleOrDefaultAsync(m => m.ProfesionalHorarioId == id);
            if (profesionalHorario == null)
            {
                return NotFound();
            }
            return View(profesionalHorario);
        }

        // POST: ProfesionalHorario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfesionalHorarioId,Horario")] ProfesionalHorario profesionalHorario)
        {
            if (id != profesionalHorario.ProfesionalHorarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesionalHorario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionalHorarioExists(profesionalHorario.ProfesionalHorarioId))
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
            return View(profesionalHorario);
        }

        // GET: ProfesionalHorario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesionalHorario = await _context.ProfesionalHorario.SingleOrDefaultAsync(m => m.ProfesionalHorarioId == id);
            if (profesionalHorario == null)
            {
                return NotFound();
            }

            return View(profesionalHorario);
        }

        // POST: ProfesionalHorario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesionalHorario = await _context.ProfesionalHorario.SingleOrDefaultAsync(m => m.ProfesionalHorarioId == id);
            _context.ProfesionalHorario.Remove(profesionalHorario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProfesionalHorarioExists(int id)
        {
            return _context.ProfesionalHorario.Any(e => e.ProfesionalHorarioId == id);
        }
    }
}
