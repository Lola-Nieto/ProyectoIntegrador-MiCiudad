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

        //dotnet add package Newtonsoft.Json --> en la consola para que el paquete funcione
       try
        {
            var serializedObject = HttpContext.Session.GetString("vecino");
                
            if (!string.IsNullOrEmpty(serializedObject))
            {
                var vecino = JsonConvert.DeserializeObject<Usuario>(serializedObject);
                ViewBag.EsAdmin = vecino.IsAdmin;

            }
        }
        catch (Exception ex)
        {
            // Podés loguearlo si usás logger
            TempData["Error"] = "Error al cargar los datos del usuario.";
        }


                ViewBag.Eventos = BD.ObtenerEventos();
                return View();
            }

        [HttpPost]
        public IActionResult Crear(Evento nuevoEvento) //Se crea el obj evento? Sino se crea no le llega nada
        {
            var serializedObject = HttpContext.Session.GetString("vecino");
            var vecino = JsonConvert.DeserializeObject<Usuario>(serializedObject);

            nuevoEvento.CreadoPor = vecino.ID;
            BD.CrearEvento(nuevoEvento);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var serializedObject = HttpContext.Session.GetString("vecino");
            var vecino = JsonConvert.DeserializeObject<Usuario>(serializedObject);
            if (vecino.IsAdmin != 1)
                return Unauthorized();

            BD.EliminarEvento(id);
            return RedirectToAction("Index");
        }
    }
}