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
    public class HorarioAtencionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HorarioAtencionController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: HorarioAtencion
        public async Task<IActionResult> Index()
        {
            return View(await _context.HorarioAtencion.ToListAsync());
        }

        // GET: HorarioAtencion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioAtencion = await _context.HorarioAtencion.SingleOrDefaultAsync(m => m.HorarioAtencionId == id);
            if (horarioAtencion == null)
            {
                return NotFound();
            }

            return View(horarioAtencion);
        }

        // GET: HorarioAtencion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HorarioAtencion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HorarioAtencionId,DescripcionRango,Estado")] HorarioAtencion horarioAtencion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horarioAtencion);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(horarioAtencion);
        }

        // GET: HorarioAtencion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioAtencion = await _context.HorarioAtencion.SingleOrDefaultAsync(m => m.HorarioAtencionId == id);
            if (horarioAtencion == null)
            {
                return NotFound();
            }
            return View(horarioAtencion);
        }

        // POST: HorarioAtencion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HorarioAtencionId,DescripcionRango,Estado")] HorarioAtencion horarioAtencion)
        {
            if (id != horarioAtencion.HorarioAtencionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horarioAtencion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioAtencionExists(horarioAtencion.HorarioAtencionId))
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
            return View(horarioAtencion);
        }

        // GET: HorarioAtencion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horarioAtencion = await _context.HorarioAtencion.SingleOrDefaultAsync(m => m.HorarioAtencionId == id);
            if (horarioAtencion == null)
            {
                return NotFound();
            }

            return View(horarioAtencion);
        }

        // POST: HorarioAtencion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var horarioAtencion = await _context.HorarioAtencion.SingleOrDefaultAsync(m => m.HorarioAtencionId == id);
            _context.HorarioAtencion.Remove(horarioAtencion);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool HorarioAtencionExists(int id)
        {
            return _context.HorarioAtencion.Any(e => e.HorarioAtencionId == id);
        }
    }
}
