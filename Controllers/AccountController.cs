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
     public ActionResult Registro()
        {
            return View();
        }
          public ActionResult LogIn()
        {
            return View();
        }
             public ActionResult OlvidePassword()
        {
            return View();
        }
        [HttpPost] 
             public ActionResult LogIn(string username, string password)
        {
            
            string view = "LogIn";
            bool verificar = BD.ChequearCuentaExiste(username, password);
            if(verificar){
                view = "Bienvenida";
            }else{
                ViewBag.MensajeError = "Usuario y/o contraseña incorrectos";
            }
            return View(view);
        }

}



    

