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
    public class ProfesionalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfesionalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Profesional
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Profesional.Include(p => p.ProfesionalTipo);
            var result = await applicationDbContext.ToListAsync();
            return View(result);
        }

        public async Task<IActionResult> Index2()
        {
            var applicationDbContext = _context.Profesional.Include(p => p.ProfesionalTipo);
            var result = await applicationDbContext.ToListAsync();
            return View(result);
        }

        public async Task<JsonResult> JsonData()
        {
            var data = await _context.Profesional.Include(p => p.ProfesionalTipo).ToListAsync();
            var result = Json(data);
            return result;
        }

        // GET: Profesional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesional.Include(x => x.ProfesionalTipo).SingleOrDefaultAsync(m => m.ProfesionalId == id);

            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // GET: Profesional/Create
        public IActionResult Create()
        {
            ViewData["ProfesionalTipoId"] = new SelectList(_context.ProfesionalTipo, "ProfesionalTipoId", "Descripcion");
            return View();
        }

        // POST: Profesional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfesionalId,Email,Estado,Nombres,ProfesionalTipoId,Telefonos")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesional);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ProfesionalTipoId"] = new SelectList(_context.ProfesionalTipo, "ProfesionalTipoId", "Descripcion", profesional.ProfesionalTipoId);
            return View(profesional);
        }

        // GET: Profesional/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesional.SingleOrDefaultAsync(m => m.ProfesionalId == id);
            if (profesional == null)
            {
                return NotFound();
            }
            ViewData["ProfesionalTipoId"] = new SelectList(_context.ProfesionalTipo, "ProfesionalTipoId", "Descripcion", profesional.ProfesionalTipoId);
            return View(profesional);
        }

        // POST: Profesional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfesionalId,Email,Estado,Nombres,ProfesionalTipoId,Telefonos")] Profesional profesional)
        {
            if (id != profesional.ProfesionalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionalExists(profesional.ProfesionalId))
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
            ViewData["ProfesionalTipoId"] = new SelectList(_context.ProfesionalTipo, "ProfesionalTipoId", "Descripcion", profesional.ProfesionalTipoId);
            return View(profesional);
        }

        // GET: Profesional/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesional.SingleOrDefaultAsync(m => m.ProfesionalId == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // POST: Profesional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesional = await _context.Profesional.SingleOrDefaultAsync(m => m.ProfesionalId == id);
            _context.Profesional.Remove(profesional);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProfesionalExists(int id)
        {
            return _context.Profesional.Any(e => e.ProfesionalId == id);
        }
    }
}
