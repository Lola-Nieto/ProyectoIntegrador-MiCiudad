using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using ProyectoIntegrador_MiCiudad.Models;
using ProyectoIntegrador_MiCiudad.Models.ModelsViews;
using Newtonsoft.Json;


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
    /* [HttpPost] 
   public ActionResult RegistroValidacion(string usuario, string nombre, string apellido, int dni, string mail, string calle, int altura, string contraseña)
        {
            Usuario nuevoVecino = Usuario.CrearUsuarioYAgregar(usuario, nombre, apellido, dni, mail, calle, altura, contraseña); 
            Session["Usuario"] =  nuevoVecino; 
            HttpContext.Session.SetString("user", ulog);
            return RedirectToAction("Index", "Home"); 
        }  
        */
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
        [HttpGet] 
        public int ValidacionLogIn(string usuario, string pass)
        {
            int idUsuario = BD.TraerIdUsuario(usuario, pass); 
            
            return idUsuario;
        }

        public bool ExisteClienteRegistro(int Dni){
            bool existe = BD.ChequearExistenciaCliente(Dni);
            return existe;
        }
        //Areglar esto!!!!! 
        //InvalidOperationException: The 'Microsoft.AspNetCore.Mvc.ViewFeatures.Infrastructure.DefaultTempDataSerializer' cannot serialize an object of type 'ProyectoIntegrador_MiCiudad.Models.Usuario'.
        //Microsoft.AspNetCore.Mvc.ViewFeatures.Infrastructure.DefaultTempDataSerializer.Serialize(IDictionary<string, object> values)

        //Tema con la sesión del usuario y traer los datos de la BD y convertirlos a tipo Usuario

/*
        [HttpPost] 
        public ActionResult TraerDatos(string id){
            Usuario vecino = BD.TraerDatosUsuarioConID(id);
            UsuarioLogueado uLogueado = new UsuarioLogueado(vecino.UserName, vecino.Nombre, vecino.Apellido, vecino.IsAdmin);

            //UsuarioLogueado uLogueado = new UsuarioLogueado(vecino.UserName, vecino.Contraseña);
            string ulog = uLogueado.ToString();
            TempData["Usuario"] = BD.TraerDatosUsuarioConID(id);
            HttpContext.Session.SetString("user", ulog);
            return RedirectToAction("Index", "Home");
        } //Hacer bien esto!!!!!!!!
        */
        
        public ActionResult TraerDatos(int idVecino){
            Usuario vecino = BD.TraerDatosUsuarioConID(idVecino);
            var serializedObject = JsonConvert.SerializeObject(vecino);
            HttpContext.Session.SetString("vecino", serializedObject); //dotnet add package Newtonsoft.Json

             

            //UsuarioLogueado uLogueado = new UsuarioLogueado(vecino.UserName, vecino.Contraseña);
            return RedirectToAction("Index", "Home");
        } //Hacer bien esto!!!!!!!!

/*
var serializedObject = HttpContext.Session.GetString("vecino");

        // Deserialize the JSON string back to an object
            var vecino = JsonConvert.DeserializeObject<Usuario>(serializedObject);
*/

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



    

