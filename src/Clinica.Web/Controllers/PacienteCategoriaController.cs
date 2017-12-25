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
    public class PacienteCategoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacienteCategoriaController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: PacienteCategoria
        public async Task<IActionResult> Index()
        {
            return View(await _context.PacienteCategoria.ToListAsync());
        }

        // GET: PacienteCategoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteCategoria = await _context.PacienteCategoria.SingleOrDefaultAsync(m => m.PacienteCategoriaId == id);
            if (pacienteCategoria == null)
            {
                return NotFound();
            }

            return View(pacienteCategoria);
        }

        // GET: PacienteCategoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PacienteCategoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacienteCategoriaId,Descripcion,Estado")] PacienteCategoria pacienteCategoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacienteCategoria);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pacienteCategoria);
        }

        // GET: PacienteCategoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteCategoria = await _context.PacienteCategoria.SingleOrDefaultAsync(m => m.PacienteCategoriaId == id);
            if (pacienteCategoria == null)
            {
                return NotFound();
            }
            return View(pacienteCategoria);
        }

        // POST: PacienteCategoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacienteCategoriaId,Descripcion,Estado")] PacienteCategoria pacienteCategoria)
        {
            if (id != pacienteCategoria.PacienteCategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacienteCategoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteCategoriaExists(pacienteCategoria.PacienteCategoriaId))
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
            return View(pacienteCategoria);
        }

        // GET: PacienteCategoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacienteCategoria = await _context.PacienteCategoria.SingleOrDefaultAsync(m => m.PacienteCategoriaId == id);
            if (pacienteCategoria == null)
            {
                return NotFound();
            }

            return View(pacienteCategoria);
        }

        // POST: PacienteCategoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacienteCategoria = await _context.PacienteCategoria.SingleOrDefaultAsync(m => m.PacienteCategoriaId == id);
            _context.PacienteCategoria.Remove(pacienteCategoria);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PacienteCategoriaExists(int id)
        {
            return _context.PacienteCategoria.Any(e => e.PacienteCategoriaId == id);
        }
    }
}
