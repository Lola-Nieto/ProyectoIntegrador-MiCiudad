using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using ProyectoIntegrador_MiCiudad.Models;
using ProyectoIntegrador_MiCiudad.Models.ModelsViews;


namespace ProyectoIntegrador_MiCiudad.Controllers;

public class Account : Controller {
    private readonly ILogger<HomeController> _logger;

    public Account(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    
     public ActionResult Registro()
        {
            return View();
        }
    [HttpPost] 
    public ActionResult RegistroValidacion(string usuario, string nombre, string apellido, int dni, string mail, string calle, int altura, string contraseña)
        {
            TempData["Usuario"] = Usuario.CrearUsuarioYAgregar(usuario, nombre, apellido, dni, mail, calle, altura, contraseña);   
            return RedirectToAction("Index", "Home"); 
        }
          public ActionResult LogIn()
        {
            return View();
        }
             public ActionResult OlvidePassword()
        {
            return View();
        }
        public ActionResult MiCuenta(){
             var reciboUsuario = TempData["Usuario"] as Usuario;
            TempData["Usuario"] = reciboUsuario;   
            return View();
        }
        public IActionResult Logout()
        {
        HttpContext.Session.Remove("user");
        return RedirectToAction("Index", "Home");
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
            if(mail != ""){ //O habría que poner null?
                ret = true; 
            }
            return ret;
        }
        [HttpPost] 
         public ActionResult ValidacionOlvidePasswordCod(string username)
        {
            Usuario vecino = BD.TraerDatosUsuarioSoloUsername(username);

            return View("Index", "Home");
        }
        [HttpPost] 
             public bool ValidacionLogIn(string usuario, string contraseña)
        {
            bool ret = false;
            Usuario usuarioLogeado = BD.TraerDatosUsuario(usuario, contraseña); 
            if(usuarioLogeado != null){
                ret = true;
            }
            return ret;
        }

        public bool ExisteClienteRegistro(int Dni){
            bool existe = BD.ChequearExistenciaCliente(Dni);
            return existe;
        }
        
        [HttpPost] 
        public ActionResult TraerDatos(string username, string password){
            UsuarioLogueado uLogueado = new UsuarioLogueado(username, password);
            string ulog = uLogueado.ToString();
            TempData["Usuario"] = BD.TraerDatosUsuario(username, password);
             HttpContext.Session.SetString("user", ulog);
            return RedirectToAction("Index", "Home");
        } 
        
        public bool EstaLogeado(){
            bool ret = false;
            if(HttpContext.Session.GetString("user") != null){
                ret = true;
            }
            return ret;
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
    }



    

