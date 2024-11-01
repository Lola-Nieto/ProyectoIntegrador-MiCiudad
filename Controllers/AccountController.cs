using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
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
    [HttpPost] 
    public ActionResult RegistroValidacion(string usuario, string nombre, string apellido, int dni, string mail, string direccion, string contraseña)
        {
            string view = "Bienvenida";
            bool ExisteElUsuario = BD.BuscarSiExiste(usuario);
            if(!ExisteElUsuario){
                // BD.AgregarVecino();
                //Usuario nuevo = Usuario.CrearUsuario(usuario, nombre, apellido, dni, mail, direccion, contraseña); //Para qué creo un nuevo usuario? Hay que hacerlo?
            }else{
                view = "Registro";
                ViewBag.Error = "Este nombre de usuario no está disponible";
            }
            return View(view);
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
         public ActionResult ValidacionOlvidePassword(string username)
        {
            string mail = BD.BuscarMail(username);
            string view = "OlvidePassword";
            if(mail != null){
                view = "Bienvenida";
            }
            else{
                ViewBag.MensajeError = "Usuario no encontrado";
            }
            return View(view);
        }
        [HttpPost] 
         public ActionResult ValidacionOlvidePasswordCod(string username)
        {
            //Usuario vecino = BD.TraerDatosUsuario(username);
            BD.TraerDatosUsuario(username);
            return View("Bienvenida");
        }
        [HttpPost] 
             public ActionResult ValidacionLogIn(string username, string password)
        {
            
            string view = "LogIn";
            bool verificar = BD.ChequearCuentaExiste(username, password);
            if(verificar){
                view = "Bienvenida";
                ViewBag.MensajeCodigo = "Ingrese el siguiente número: ";
                ViewBag.MensajeCodigo += Usuario.NumRandom();
            }else{
                ViewBag.MensajeError = "Usuario y/o contraseña incorrectos";
            }
            return View(view);
        }

}



    

