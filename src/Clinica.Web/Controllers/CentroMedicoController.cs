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
    public class CentroMedicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CentroMedicoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CentroMedico
        public async Task<IActionResult> Index()
        {
            ViewBag.Titulo = "Listado de Clínicas";
            return View(await _context.CentroMedico.ToListAsync());
        }

        // GET: CentroMedico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroMedico = await _context.CentroMedico.SingleOrDefaultAsync(m => m.CentroMedicoId == id);
            if (centroMedico == null)
            {
                return NotFound();
            }

            return View(centroMedico);
        }

        // GET: CentroMedico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CentroMedico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CentroMedicoId,Direccion,Estado,Nombre,Telefonos")] CentroMedico centroMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centroMedico);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(centroMedico);
        }

        // GET: CentroMedico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroMedico = await _context.CentroMedico.SingleOrDefaultAsync(m => m.CentroMedicoId == id);
            if (centroMedico == null)
            {
                return NotFound();
            }
            return View(centroMedico);
        }

        // POST: CentroMedico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CentroMedicoId,Direccion,Estado,Nombre,Telefonos")] CentroMedico centroMedico)
        {
            if (id != centroMedico.CentroMedicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centroMedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentroMedicoExists(centroMedico.CentroMedicoId))
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
            return View(centroMedico);
        }

        // GET: CentroMedico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centroMedico = await _context.CentroMedico.SingleOrDefaultAsync(m => m.CentroMedicoId == id);
            if (centroMedico == null)
            {
                return NotFound();
            }
            ViewBag.Mensaje = "¿Está seguro de eliminar?";
            return View(centroMedico);
        }

        // POST: CentroMedico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centroMedico = await _context.CentroMedico.SingleOrDefaultAsync(m => m.CentroMedicoId == id);
            _context.CentroMedico.Remove(centroMedico);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CentroMedicoExists(int id)
        {
            return _context.CentroMedico.Any(e => e.CentroMedicoId == id);
        }
    }
}
