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
    public class TarifaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarifaController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Tarifa
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tarifa.Include(t => t.CentroMedico).Include(t => t.CitaTipo).Include(t => t.PacienteCategoria);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tarifa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifa = await _context.Tarifa.SingleOrDefaultAsync(m => m.TarifaId == id);
            if (tarifa == null)
            {
                return NotFound();
            }

            return View(tarifa);
        }

        // GET: Tarifa/Create
        public IActionResult Create()
        {
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "Nombre");
            ViewData["CitaTipoId"] = new SelectList(_context.CitaTipo, "CitaTipoId", "Descripcion");
            ViewData["PacienteCategoriaId"] = new SelectList(_context.PacienteCategoria, "PacienteCategoriaId", "Descripcion");
            return View();
        }

        // POST: Tarifa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TarifaId,CentroMedicoId,CitaTipoId,Estado,PacienteCategoriaId,Precio")] Tarifa tarifa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarifa);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "Nombre", tarifa.CentroMedicoId);
            ViewData["CitaTipoId"] = new SelectList(_context.CitaTipo, "CitaTipoId", "Descripcion", tarifa.CitaTipoId);
            ViewData["PacienteCategoriaId"] = new SelectList(_context.PacienteCategoria, "PacienteCategoriaId", "Descripcion", tarifa.PacienteCategoriaId);
            return View(tarifa);
        }

        // GET: Tarifa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifa = await _context.Tarifa.SingleOrDefaultAsync(m => m.TarifaId == id);
            if (tarifa == null)
            {
                return NotFound();
            }
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "Nombre", tarifa.CentroMedicoId);
            ViewData["CitaTipoId"] = new SelectList(_context.CitaTipo, "CitaTipoId", "Descripcion", tarifa.CitaTipoId);
            ViewData["PacienteCategoriaId"] = new SelectList(_context.PacienteCategoria, "PacienteCategoriaId", "Descripcion", tarifa.PacienteCategoriaId);
            return View(tarifa);
        }

        // POST: Tarifa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TarifaId,CentroMedicoId,CitaTipoId,Estado,PacienteCategoriaId,Precio")] Tarifa tarifa)
        {
            if (id != tarifa.TarifaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarifa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarifaExists(tarifa.TarifaId))
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
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "Nombre", tarifa.CentroMedicoId);
            ViewData["CitaTipoId"] = new SelectList(_context.CitaTipo, "CitaTipoId", "Descripcion", tarifa.CitaTipoId);
            ViewData["PacienteCategoriaId"] = new SelectList(_context.PacienteCategoria, "PacienteCategoriaId", "Descripcion", tarifa.PacienteCategoriaId);
            return View(tarifa);
        }

        // GET: Tarifa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarifa = await _context.Tarifa.SingleOrDefaultAsync(m => m.TarifaId == id);
            if (tarifa == null)
            {
                return NotFound();
            }

            return View(tarifa);
        }

        // POST: Tarifa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarifa = await _context.Tarifa.SingleOrDefaultAsync(m => m.TarifaId == id);
            _context.Tarifa.Remove(tarifa);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TarifaExists(int id)
        {
            return _context.Tarifa.Any(e => e.TarifaId == id);
        }
    }
}
