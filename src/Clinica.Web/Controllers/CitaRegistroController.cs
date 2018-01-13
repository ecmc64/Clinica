using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Clinica.Web.Data;
using Microsoft.EntityFrameworkCore;
using Clinica.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Clinica.Web.Models;

namespace Clinica.Web.Controllers
{
    public class CitaRegistroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitaRegistroController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //var citatk = _context.TicketPago.Include(c=>c.Cita).Include(c => c.Cita.CentroMedico).Include(c => c.Cita.CitaEstado).Include(c => c.Cita.CitaTipo).Include(c => c.Cita.Paciente).Include(c => c.Cita.Profesional).Where(c=>c.Pagado==false).ToList();
            var citaDb = _context.Cita.Include(c => c.CentroMedico).Include(c => c.CitaEstado).Include(c => c.CitaTipo).Include(c => c.Paciente).Include(c => c.Profesional).ToList();
            var registro = new List<CitaRegistroViewModel>();

            citaDb.ForEach(x => registro.Add(
                new CitaRegistroViewModel
                {
                    CitaId = x.CitaId,
                    FechaRegistro = x.FechaRegistra,
                    FechaCita = x.Inicio.Date,
                    Inicio = x.Inicio,
                    Fin = x.Fin,
                    CentroMedicoId = x.CentroMedicoId,
                    CitaTipoId = x.CitaTipoId,
                    ProfesionalId = x.ProfesionalId,
                    PacienteId = x.PacienteId,
                    Precio = x.Precio,
                    CentroMedico = x.CentroMedico,
                    CitaEstado = x.CitaEstado,
                    CitaTipo = x.CitaTipo,
                    Profesional = x.Profesional,
                    Paciente = x.Paciente
                }));
            //registro.CitaId = citaDb.CitaId;


            return View(registro);
        }

        public IActionResult Create()
        {
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "Nombre");
            ViewData["CitaEstadoId"] = new SelectList(_context.CitaEstado, "CitaEstadoId", "Descripcion");
            ViewData["CitaTipoId"] = new SelectList(_context.CitaTipo, "CitaTipoId", "Descripcion");
            //ViewData["PacienteId"] = new SelectList(_context.Paciente, "PacienteId", "FullName");
            ViewData["ProfesionalId"] = new SelectList(_context.Profesional, "ProfesionalId", "Nombres");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CitaRegistroViewModel pCita)
        {
            if (ModelState.IsValid)
            {
                TimeSpan ts;
                var citaDb = new Cita();
                var data = _context.Paciente.Where(c => c.NumeroDocumento == pCita.DniPaciente).First();

                citaDb.CentroMedicoId = pCita.CentroMedicoId;
                citaDb.CitaEstadoId = 1;
                citaDb.CitaTipoId = pCita.CitaTipoId;
                citaDb.Descripcion = string.Empty;
                citaDb.FechaRegistra = DateTime.Now;
                citaDb.Inicio = pCita.FechaCita.Date;
                citaDb.Fin = pCita.FechaCita.Date;
                ts = new TimeSpan(pCita.Inicio.Hour, pCita.Inicio.Minute, 0);
                citaDb.Inicio += ts;
                ts = new TimeSpan(pCita.Fin.Hour, pCita.Fin.Minute, 0);
                citaDb.Fin += ts;

                citaDb.Observacion = string.Empty;
                citaDb.PacienteId = data.PacienteId;
                citaDb.Precio = pCita.Precio;
                citaDb.ProfesionalId = pCita.ProfesionalId;
                citaDb.UsuarioRegistra = "COUTER";

                _context.Add(citaDb);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CentroMedicoId"] = new SelectList(_context.CentroMedico, "CentroMedicoId", "Nombre");
            ViewData["CitaEstadoId"] = new SelectList(_context.CitaEstado, "CitaEstadoId", "Descripcion");
            ViewData["CitaTipoId"] = new SelectList(_context.CitaTipo, "CitaTipoId", "Descripcion");
            //ViewData["PacienteId"] = new SelectList(_context.Paciente, "PacienteId", "FullName");
            ViewData["ProfesionalId"] = new SelectList(_context.Profesional, "ProfesionalId", "Nombres");
            return View(pCita);
        }

        public JsonResult GetPacienteByDni(string pDni)
        {
            var data = _context.Paciente.Where(c=>c.NumeroDocumento == pDni).ToListAsync();
            return Json(data);
        }

        public JsonResult GetTarifaPaciente(int pCentroMedicoId, int pCitaTipoId, int pPacienteCategoriaId)
        {
            var data = _context.Tarifa.Where(c => c.CentroMedicoId == pCentroMedicoId && c.CitaTipoId == pCitaTipoId && c.PacienteCategoriaId == pPacienteCategoriaId).ToListAsync();
            return Json(data);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.Include(m=>m.Paciente).Include(m=>m.CitaEstado).Include(m=>m.CentroMedico).Include(m=>m.Profesional).Include(m=>m.CitaTipo).SingleOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }

            var objView = SetVista(cita);
            
            return View(objView);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cita = await _context.Cita.Include(m => m.Paciente).Include(m => m.CitaEstado).Include(m => m.CentroMedico).Include(m => m.Profesional).Include(m => m.CitaTipo).SingleOrDefaultAsync(m => m.CitaId == id);
            if (cita == null)
            {
                return NotFound();
            }
            var objView = SetVista(cita);
            
            return View(objView);
        }

        // POST: Cita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cita = await _context.Cita.SingleOrDefaultAsync(m => m.CitaId == id);
            _context.Cita.Remove(cita);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private CitaRegistroViewModel SetVista(Cita pCita)
        {
            var objView = new CitaRegistroViewModel
            {
                CitaId = pCita.CitaId,
                FechaRegistro = pCita.FechaRegistra,
                FechaCita = pCita.Inicio.Date,
                Inicio = pCita.Inicio,
                Fin = pCita.Fin,
                CentroMedicoId = pCita.CentroMedicoId,
                CitaTipoId = pCita.CitaTipoId,
                ProfesionalId = pCita.ProfesionalId,
                PacienteId = pCita.PacienteId,
                Precio = pCita.Precio,
                CentroMedico = pCita.CentroMedico,
                CitaEstado = pCita.CitaEstado,
                CitaTipo = pCita.CitaTipo,
                Paciente = pCita.Paciente,
                Profesional = pCita.Profesional
            };

            return objView;
        }
    }
}