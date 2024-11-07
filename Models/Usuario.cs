namespace ProyectoIntegrador_MiCiudad.Models;

public class Usuario{
    public string UserName {get; set; }
    private string Contraseña { get; set; }
    public string Nombre {get; set; }
    public string Apellido {get; set; }
    public int DNI {get; set;}
    public string Calle {get; set; }
    public int Altura {get; set;}
    public string Mail {get; set; }

    public Usuario (){

    }
    private Usuario(string username, string contraseña, string nombre, string apellido, int dni, string direccion, string mail){
        UserName = username;
        Contraseña = contraseña;
        Nombre = nombre;
        Apellido = apellido;
        DNI = dni;
        direccion.Trim().Split(" ");

    }
    public void CrearUsuario(string usuario, string nombre, string apellido, int dni, string mail, string direccion, string contraseña){
        Usuario nuevoVecino = new Usuario(usuario, contraseña, nombre, apellido, dni, direccion, mail);
    }
    
    public static string NumRandom(){
        Random rnd = new Random();
    int randomNumber = rnd.Next(100,1000);
    return Convert.ToString(randomNumber);
    }
}