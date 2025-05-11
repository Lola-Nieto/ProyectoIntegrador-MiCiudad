using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrador_MiCiudad.Models;

namespace ProyectoIntegrador_MiCiudad.Controllers;
public class ReportesController : Controller
{
    public IActionResult Index()
    {
        var reportes = BD.ObtenerReportes();
        return View(reportes);
    }


    public IActionResult CrearReporte()
    {
        return View();
    }

[HttpPost]
public IActionResult CrearReporte(Reporte reporte)
{
    if (reporte.IdUsuario == 0)
    {
        reporte.IdUsuario = 1;  
    }

    if (reporte.Dia == DateTime.MinValue)
    {
        reporte.Dia = DateTime.Now;
    }

    if (reporte.Hora == TimeSpan.Zero)
    {
        reporte.Hora = DateTime.Now.TimeOfDay;
    }

    BD.GuardarReporte(reporte);
    return RedirectToAction("Index");
}

}