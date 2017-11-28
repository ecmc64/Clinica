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
    public class PacienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacienteController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Paciente
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Paciente.Include(p => p.TipoDocumento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Paciente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.SingleOrDefaultAsync(m => m.PersonaId == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Paciente/Create
        public IActionResult Create()
        {
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "TipoDocumentoId", "TipoDocumentoId");
            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonaId,ApellidoMaterno,ApellidoPaterno,Direccion,Estado,FechaNacimiento,FechaRegistro,Nombres,NroDocumento,TipoDocumentoId,FechaUltimaVisita,Observacion")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "TipoDocumentoId", "TipoDocumentoId", paciente.TipoDocumentoId);
            return View(paciente);
        }

        // GET: Paciente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.SingleOrDefaultAsync(m => m.PersonaId == id);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "TipoDocumentoId", "TipoDocumentoId", paciente.TipoDocumentoId);
            return View(paciente);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonaId,ApellidoMaterno,ApellidoPaterno,Direccion,Estado,FechaNacimiento,FechaRegistro,Nombres,NroDocumento,TipoDocumentoId,FechaUltimaVisita,Observacion")] Paciente paciente)
        {
            if (id != paciente.PersonaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.PersonaId))
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
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "TipoDocumentoId", "TipoDocumentoId", paciente.TipoDocumentoId);
            return View(paciente);
        }

        // GET: Paciente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.SingleOrDefaultAsync(m => m.PersonaId == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Paciente.SingleOrDefaultAsync(m => m.PersonaId == id);
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PacienteExists(int id)
        {
            return _context.Paciente.Any(e => e.PersonaId == id);
        }
    }
}
