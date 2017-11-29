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
    public class TipoDocumentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoDocumentoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: TipoDocumento
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDocumento.ToListAsync());
        }

        // GET: TipoDocumento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumento.SingleOrDefaultAsync(m => m.TipoDocumentoId == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDocumento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDocumentoId,Estado,NombreDocumento")] TipoDocumento tipoDocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumento.SingleOrDefaultAsync(m => m.TipoDocumentoId == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }
            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoDocumentoId,Estado,NombreDocumento")] TipoDocumento tipoDocumento)
        {
            if (id != tipoDocumento.TipoDocumentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocumentoExists(tipoDocumento.TipoDocumentoId))
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
            return View(tipoDocumento);
        }

        // GET: TipoDocumento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDocumento = await _context.TipoDocumento.SingleOrDefaultAsync(m => m.TipoDocumentoId == id);
            if (tipoDocumento == null)
            {
                return NotFound();
            }

            return View(tipoDocumento);
        }

        // POST: TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDocumento = await _context.TipoDocumento.SingleOrDefaultAsync(m => m.TipoDocumentoId == id);
            _context.TipoDocumento.Remove(tipoDocumento);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TipoDocumentoExists(int id)
        {
            return _context.TipoDocumento.Any(e => e.TipoDocumentoId == id);
        }
    }
}
