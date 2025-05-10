using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using ProyectoIntegrador_MiCiudad.Models;
using ProyectoIntegrador_MiCiudad.Models.ModelsViews;
using Newtonsoft.Json;


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
        /* if(HttpContext.Session.GetString("vecino") != null){
            var reciboUsuario = TempData["Usuario"] as Usuario;
            TempData["Usuario"] = reciboUsuario;   
            }
        */
     

        try
        {
           
            var idUsuario = HttpContext.Session.GetInt32("idUsuario");
            if (idUsuario.HasValue)
            {
                var vecino = BD.TraerDatosUsuarioConID(idUsuario.Value);
                TempData["Usuario"] = vecino;
            }
        }
        catch (Exception ex)
        {
            // Podés loguearlo si usás logger
            System.IO.File.WriteAllText("error_log.txt", ex.ToString());
            TempData["Error"] = "Error al cargar los datos del usuario.";
        }

        return View();
    }


}


