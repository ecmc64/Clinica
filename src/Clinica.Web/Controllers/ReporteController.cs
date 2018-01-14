using Clinica.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Web.Controllers
{
    public class ReportesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var reporteHtml = ConstruirReporteSimple();
            ViewBag.ReporteHtml = reporteHtml;
            return View();
        }

        //public IActionResult ContactosSimple()
        //{
        //    var reporteHtml = ConstruirReporteSimple();
        //    ViewBag.ReporteHtml = reporteHtml;
        //    return View();
        //}

        public IActionResult Contactos()
        {
            //var listaTiendas = new List<SelectListItem>();
            //using (var context = new ApplicationDbContext())
            //{
            //    var stores = context.Store.ToList();
            //    foreach (var store in stores)
            //    {
            //        var item = new SelectListItem { Text = store.Name, Value = store.BusinessEntityId.ToString() };
            //        listaTiendas.Add(item);
            //    }
            //}
            //ViewBag.Tiendas = listaTiendas;

            return View();
        }

        public JsonResult ReporteContactosJson(string idTienda)
        {
            return Json(ConstruirReporte(idTienda));
        }

        private string ConstruirReporte(string idTienda)
        {
            var servidor = "http://s101nv04/ReportServer";
            var carpeta = "ProyectoReportes";
            var reporte = "Store_Contacts";
            var commands = "&rs:Command=render&rs:Format=HTML4.0&rc:Parameters=false";
            //Defino parametro desde rdl
            var parametros = $"&StoreID={idTienda}";
            return $@"<iframe width=""100%"" style=""height:480px"" frameborder=""0"" 
                src=""{servidor}?/{carpeta}/{reporte}{parametros}{commands}""></iframe>";
            // Con Parameters=false aparece opcion de combo dentro de mismo reporte
        }

        private string ConstruirReporteSimple()
        {
            var servidor = "http://s101nv04/ReportServer";
            var carpeta = "ProyectoReportes";
            var reporte = "RepPaciente";
            // Con Parameters=false aparece opcion de combo dentro de mismo reporte
            var commands = "&rs:Command=render&rs:Format=HTML4.0&rc:Parameters=false";
            return $@"<iframe width=""100%"" style=""height:480px"" frameborder=""0"" src=""{servidor}?/{carpeta}/{reporte}{commands}""></iframe>";
        }
    }
}
