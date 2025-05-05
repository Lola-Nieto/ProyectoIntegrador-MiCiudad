using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrador_MiCiudad.Models;
using System;
using Newtonsoft.Json;

namespace MiCiudad.Controllers
{
    public class CalendarioController : Controller
    {
        public IActionResult Index()
        {
             //dotnet add package Newtonsoft.Json
       //     var vecinoObjJson = HttpContext.Session.GetString("vecino", serializedObject);
        //    var vecino = JsonConvert.DeserializeObject<Usuario>(serializedObject);

            ViewBag.EsAdmin = HttpContext.Session.GetInt32("isAdmin") == 1;
            ViewBag.Eventos = BD.ObtenerEventos();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Evento nuevoEvento)
        {
            if (HttpContext.Session.GetInt32("isAdmin") != 1)
                return Unauthorized();

            nuevoEvento.CreadoPor = HttpContext.Session.GetInt32("userId") ?? 0;
            BD.CrearEvento(nuevoEvento);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            if (HttpContext.Session.GetInt32("isAdmin") != 1)
                return Unauthorized();

            BD.EliminarEvento(id);
            return RedirectToAction("Index");
        }
    }
}