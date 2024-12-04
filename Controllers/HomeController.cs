using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrador_MiCiudad.Models;
using ProyectoIntegrador_MiCiudad.Models.ModelsViews;

namespace ProyectoIntegrador_MiCiudad.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        /*
        var reciboSesion = TempData["Sesion"] as string;
        TempData["Sesion"] = reciboSesion;
        */
        return View();
    }
}
