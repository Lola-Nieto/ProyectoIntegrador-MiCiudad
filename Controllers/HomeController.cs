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
        var serializedObject = HttpContext.Session.GetString("vecino");

        if (!string.IsNullOrEmpty(serializedObject))
        {
            var vecino = JsonConvert.DeserializeObject<Usuario>(serializedObject);
            TempData["Usuario"] = vecino;
        }
    }
    catch (Exception ex)
    {
        // Podés loguearlo si usás logger
        TempData["Error"] = "Error al cargar los datos del usuario.";
    }

    return View();
}


}


