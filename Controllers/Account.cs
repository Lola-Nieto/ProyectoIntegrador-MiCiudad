using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrador_MiCiudad.Models;

namespace ProyectoIntegrador_MiCiudad.Controllers;

public class Account : Controller {
    private readonly ILogger<HomeController> _logger;

    public Account(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
     public ActionResult LogIn()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Ingresar(string usuario, string contraseña)
        {
               //mando todo a la base de datos
        }
}



    

