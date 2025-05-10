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
           // var serializedObject = HttpContext.Session.GetString("vecino");
             var idUsuario = HttpContext.Session.GetInt32("idUsuario");

            if (idUsuario.HasValue)
            {
                var vecino = BD.TraerDatosUsuarioConID(idUsuario.Value);
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

             var idUsuario = HttpContext.Session.GetInt32("idUsuario");
            if(idUsuario.HasValue){
                nuevoEvento.CreadoPor = (int)idUsuario;
                BD.CrearEvento(nuevoEvento);
                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var idUsuario = HttpContext.Session.GetInt32("idUsuario");
            if (idUsuario.HasValue)
            {
                var vecino = BD.TraerDatosUsuarioConID(idUsuario.Value);
                 if (!vecino.IsAdmin)
                return Unauthorized();

            BD.EliminarEvento(id);
            }
           
            return RedirectToAction("Index");
        }
    }
}