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
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Doctor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Doctor.Include(d => d.TipoDocumento).Include(d => d.Especialidad);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Doctor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.SingleOrDefaultAsync(m => m.PersonaId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "TipoDocumentoId", "TipoDocumentoId");
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidad, "EspecialidadId", "EspecialidadId");
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonaId,ApellidoMaterno,ApellidoPaterno,Direccion,Estado,FechaNacimiento,FechaRegistro,Nombres,NroDocumento,TipoDocumentoId,Comentario,EspecialidadId,FechaAlta,NumeroColegiatura")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "TipoDocumentoId", "TipoDocumentoId", doctor.TipoDocumentoId);
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidad, "EspecialidadId", "EspecialidadId", doctor.EspecialidadId);
            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.SingleOrDefaultAsync(m => m.PersonaId == id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "TipoDocumentoId", "TipoDocumentoId", doctor.TipoDocumentoId);
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidad, "EspecialidadId", "EspecialidadId", doctor.EspecialidadId);
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonaId,ApellidoMaterno,ApellidoPaterno,Direccion,Estado,FechaNacimiento,FechaRegistro,Nombres,NroDocumento,TipoDocumentoId,Comentario,EspecialidadId,FechaAlta,NumeroColegiatura")] Doctor doctor)
        {
            if (id != doctor.PersonaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.PersonaId))
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
            ViewData["TipoDocumentoId"] = new SelectList(_context.TipoDocumento, "TipoDocumentoId", "TipoDocumentoId", doctor.TipoDocumentoId);
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidad, "EspecialidadId", "EspecialidadId", doctor.EspecialidadId);
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.SingleOrDefaultAsync(m => m.PersonaId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctor.SingleOrDefaultAsync(m => m.PersonaId == id);
            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.PersonaId == id);
        }
    }
}
