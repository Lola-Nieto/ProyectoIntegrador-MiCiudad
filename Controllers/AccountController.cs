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
        return View("LogIn");
    }
     public ActionResult Registro()
        {
            return View();
        }
    [HttpPost] 
    public ActionResult RegistroValidacion(string usuario, string nombre, string apellido, int dni, string mail, string calle, int altura, string contraseña)
        {
            Usuario.CrearUsuarioYAgregar(usuario, nombre, apellido, dni, mail, calle, altura, contraseña);
            return View("Index");
        }
          public ActionResult LogIn()
        {
            return View();
        }
             public ActionResult OlvidePassword()
        {
            return View();
        }
        [HttpGet] 
         public int ExisteUsuarioOvidePass(string Username)
        {
            string mail = BD.BuscarMail(Username);
            int ret = -1; 
            if(mail == ""){
                ret = Usuario.NumRandom(); 
            }
            return ret;
        }
         public bool ExisteUsuarioRegistro(string Username)
        {
            string mail = BD.BuscarMail(Username);
            bool ret = false; 
            if(mail == ""){
                ret = true; 
            }
            return ret;
        }
        [HttpPost] 
         public ActionResult ValidacionOlvidePasswordCod(string username)
        {
            Usuario vecino = BD.TraerDatosUsuarioSoloUsername(username);
            return View("Bienvenida");
        }
        [HttpPost] 
             public bool ValidacionLogIn(string usuario, string contraseña)
        {
            bool ret = false;
            Usuario usuarioTraido = BD.TraerDatosUsuario(usuario, contraseña);
            if(usuarioTraido != null){
                ret = true;
            }
            return ret;
        }
        [HttpPost] 
        public ActionResult TraerDatos(string usuario, string contraseña){
            Usuario usuarioLogeado = BD.TraerDatosUsuario(usuario, contraseña);
            //Crear el usuario a partir de los datos traídos - HttpContext.Session.SetString("user", new Usuario(email, password).ToString());
            //Tendría que crear un usuario nuevo? Podría acerlo en la validación y luego mandar directo al index
        } 

        public bool EstaLogeado(){
            bool ret = false;
            if(HttpContext.Session.GetString("user") != null){
                ret = true;
            }
            return ret;
        }//CÓMO HACER QUE CAMBIE LA BARRA? Tengo que llamar a función? Cuándo? Si no pasa por el controller para mostrarlo 
        /*
         public ActionResult ValidacionLogIn(string usuario, string contraseña)
        {
            
            string view = "LogIn";
            Usuario usuarioTraido = BD.TraerDatosUsuario(usuario, contraseña);
            if(usuarioTraido != null){
                view = "Bienvenida";
            }else{
                ViewBag.MensajeError = "Usuario y/o contraseña incorrectos";
            }
            return View(view);
        }
        */
}



    

