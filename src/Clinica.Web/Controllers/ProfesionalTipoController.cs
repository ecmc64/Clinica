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
    public class ProfesionalTipoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfesionalTipoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ProfesionalTipo
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfesionalTipo.ToListAsync());
        }

        // GET: ProfesionalTipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesionalTipo = await _context.ProfesionalTipo.SingleOrDefaultAsync(m => m.ProfesionalTipoId == id);
            if (profesionalTipo == null)
            {
                return NotFound();
            }

            return View(profesionalTipo);
        }

        // GET: ProfesionalTipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfesionalTipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfesionalTipoId,Descripcion,Estado")] ProfesionalTipo profesionalTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesionalTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(profesionalTipo);
        }

        // GET: ProfesionalTipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesionalTipo = await _context.ProfesionalTipo.SingleOrDefaultAsync(m => m.ProfesionalTipoId == id);
            if (profesionalTipo == null)
            {
                return NotFound();
            }
            return View(profesionalTipo);
        }

        // POST: ProfesionalTipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfesionalTipoId,Descripcion,Estado")] ProfesionalTipo profesionalTipo)
        {
            if (id != profesionalTipo.ProfesionalTipoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesionalTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionalTipoExists(profesionalTipo.ProfesionalTipoId))
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
            return View(profesionalTipo);
        }

        // GET: ProfesionalTipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesionalTipo = await _context.ProfesionalTipo.SingleOrDefaultAsync(m => m.ProfesionalTipoId == id);
            if (profesionalTipo == null)
            {
                return NotFound();
            }

            return View(profesionalTipo);
        }

        // POST: ProfesionalTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesionalTipo = await _context.ProfesionalTipo.SingleOrDefaultAsync(m => m.ProfesionalTipoId == id);
            _context.ProfesionalTipo.Remove(profesionalTipo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProfesionalTipoExists(int id)
        {
            return _context.ProfesionalTipo.Any(e => e.ProfesionalTipoId == id);
        }
    }
}
