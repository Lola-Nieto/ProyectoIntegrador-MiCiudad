using Microsoft.AspNetCore.Mvc;
using ProyectoIntegrador_MiCiudad.Models;
using ProyectoIntegrador_MiCiudad.Models.ModelsViews;
using System;

namespace ProyectoIntegrador_MiCiudad.Controllers
{
    /*
    public class CalendarioController : Controller
    {
        public IActionResult Index(string filtro = "", int? mes = null, int? año = null)
        {
            DateTime hoy = DateTime.Now;
            int mesActual = mes ?? hoy.Month;
            int añoActual = año ?? hoy.Year;

            ViewBag.Mes = mesActual;
            ViewBag.Año = añoActual;
            ViewBag.Filtro = filtro;

            ViewBag.EsAdmin = UsuarioLogueado.Instancia.IsAdmin;
            ViewBag.Eventos = BD.ObtenerEventos(mesActual, añoActual, filtro);

            return View();
        }

        public IActionResult Detalle(int id)
        {
            var evento = BD.ObtenerEvento(id);
            return View(evento);
        }

        public IActionResult Crear()
        {
            if (!UsuarioLogueado.Instancia.IsAdmin) return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Evento evento)
        {
            if (!UsuarioLogueado.Instancia.IsAdmin) return RedirectToAction("Index");

            evento.CreadoPor = UsuarioLogueado.Instancia.Id;
            evento.Fecha = evento.Fecha.Date + evento.Hora;
            BD.GuardarEvento(evento);

            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            if (!UsuarioLogueado.Instancia.IsAdmin) return RedirectToAction("Index");
            var evento = BD.ObtenerEvento(id);
            return View(evento);
        }

        [HttpPost]
        public IActionResult Editar(Evento evento)
        {
            if (!UsuarioLogueado.Instancia.IsAdmin) return RedirectToAction("Index");
            evento.ActualizadoEn = DateTime.Now;
            BD.ActualizarEvento(evento);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            if (UsuarioLogueado.Instancia.IsAdmin)
            {
                BD.EliminarEvento(id);
            }
            return RedirectToAction("Index");
        }
    }

    */
}
