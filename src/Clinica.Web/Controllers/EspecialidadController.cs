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
    public class EspecialidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspecialidadController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Especialidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Especialidad.ToListAsync());
        }

        // GET: Especialidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad.SingleOrDefaultAsync(m => m.EspecialidadId == id);
            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // GET: Especialidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especialidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EspecialidadId,Descripcion,Estado,FechaCreacion")] Especialidad especialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(especialidad);
        }

        // GET: Especialidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad.SingleOrDefaultAsync(m => m.EspecialidadId == id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        // POST: Especialidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EspecialidadId,Descripcion,Estado,FechaCreacion")] Especialidad especialidad)
        {
            if (id != especialidad.EspecialidadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadExists(especialidad.EspecialidadId))
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
            return View(especialidad);
        }

        // GET: Especialidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad.SingleOrDefaultAsync(m => m.EspecialidadId == id);
            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        // POST: Especialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especialidad = await _context.Especialidad.SingleOrDefaultAsync(m => m.EspecialidadId == id);
            _context.Especialidad.Remove(especialidad);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool EspecialidadExists(int id)
        {
            return _context.Especialidad.Any(e => e.EspecialidadId == id);
        }
    }
}
