using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
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
        if(HttpContext.Session.GetString("vecino") != null){
         var reciboUsuario = TempData["Usuario"] as Usuario;
        TempData["Usuario"] = reciboUsuario;   
        }

        var serializedObject = HttpContext.Session.GetString("vecino");

        // Deserialize the JSON string back to an object
            var vecino = JsonConvert.DeserializeObject<Usuario>(serializedObject);
        
        return View();
    }
}
