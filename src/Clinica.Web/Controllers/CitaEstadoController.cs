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
    public class CitaEstadoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitaEstadoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CitaEstado
        public async Task<IActionResult> Index()
        {
            return View(await _context.CitaEstado.ToListAsync());
        }

        // GET: CitaEstado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaEstado = await _context.CitaEstado.SingleOrDefaultAsync(m => m.CitaEstadoId == id);
            if (citaEstado == null)
            {
                return NotFound();
            }

            return View(citaEstado);
        }

        // GET: CitaEstado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CitaEstado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitaEstadoId,Descripcion,Estado")] CitaEstado citaEstado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citaEstado);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(citaEstado);
        }

        // GET: CitaEstado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaEstado = await _context.CitaEstado.SingleOrDefaultAsync(m => m.CitaEstadoId == id);
            if (citaEstado == null)
            {
                return NotFound();
            }
            return View(citaEstado);
        }

        // POST: CitaEstado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitaEstadoId,Descripcion,Estado")] CitaEstado citaEstado)
        {
            if (id != citaEstado.CitaEstadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citaEstado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaEstadoExists(citaEstado.CitaEstadoId))
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
            return View(citaEstado);
        }

        // GET: CitaEstado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaEstado = await _context.CitaEstado.SingleOrDefaultAsync(m => m.CitaEstadoId == id);
            if (citaEstado == null)
            {
                return NotFound();
            }

            return View(citaEstado);
        }

        // POST: CitaEstado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citaEstado = await _context.CitaEstado.SingleOrDefaultAsync(m => m.CitaEstadoId == id);
            _context.CitaEstado.Remove(citaEstado);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CitaEstadoExists(int id)
        {
            return _context.CitaEstado.Any(e => e.CitaEstadoId == id);
        }
    }
}
