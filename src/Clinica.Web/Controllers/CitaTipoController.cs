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
    public class CitaTipoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitaTipoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CitaTipo
        public async Task<IActionResult> Index()
        {
            return View(await _context.CitaTipo.ToListAsync());
        }

        // GET: CitaTipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaTipo = await _context.CitaTipo.SingleOrDefaultAsync(m => m.CitaTipoId == id);
            if (citaTipo == null)
            {
                return NotFound();
            }

            return View(citaTipo);
        }

        // GET: CitaTipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CitaTipo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CitaTipoId,Descripcion,Estado")] CitaTipo citaTipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citaTipo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(citaTipo);
        }

        // GET: CitaTipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaTipo = await _context.CitaTipo.SingleOrDefaultAsync(m => m.CitaTipoId == id);
            if (citaTipo == null)
            {
                return NotFound();
            }
            return View(citaTipo);
        }

        // POST: CitaTipo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CitaTipoId,Descripcion,Estado")] CitaTipo citaTipo)
        {
            if (id != citaTipo.CitaTipoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citaTipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaTipoExists(citaTipo.CitaTipoId))
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
            return View(citaTipo);
        }

        // GET: CitaTipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citaTipo = await _context.CitaTipo.SingleOrDefaultAsync(m => m.CitaTipoId == id);
            if (citaTipo == null)
            {
                return NotFound();
            }

            return View(citaTipo);
        }

        // POST: CitaTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citaTipo = await _context.CitaTipo.SingleOrDefaultAsync(m => m.CitaTipoId == id);
            _context.CitaTipo.Remove(citaTipo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CitaTipoExists(int id)
        {
            return _context.CitaTipo.Any(e => e.CitaTipoId == id);
        }
    }
}
