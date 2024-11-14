namespace ProyectoIntegrador_MiCiudad.Models;

public class Usuario{
    public string UserName {get; set; }
    public string Contraseña { get; set; }
    public string Nombre {get; set; }
    public string Apellido {get; set; }
    public int DNI {get; set;}
    public string Calle {get; set; }
    public int Altura {get; set;}
    public string Mail {get; set; }
    public int Patente {get; set;}
    public int IdGrupoCuadra{get; set;}
    public int IdGrupoEdificio {get; set;}
    public int IdGrupoBarrio {get; set;}

    private Usuario (){
        
    }
    private Usuario(string username, string contraseña, string nombre, string apellido, int dni, string calle, int altura, string mail){
        UserName = username;
        Contraseña = contraseña;
        Nombre = nombre;
        Apellido = apellido;
        DNI = dni;
        Mail = mail;
        Calle = calle; 
        Altura = altura;
    }
    private Usuario(string username, string contraseña, string nombre, string apellido, int dni, string calle, int altura, string mail, int patente){
        UserName = username;
        Contraseña = contraseña;
        Nombre = nombre;
        Apellido = apellido;
        DNI = dni;
        Mail = mail;
        Calle = calle; 
        Altura = altura;
        Patente = patente;
    }
    private Usuario(string username, string contraseña, string nombre, string apellido, int dni, string calle, int altura, string mail, int patente, int idGrupoCuadra, int idGrupoBarrio, int idGrupoEdificio){
        UserName = username;
        Contraseña = contraseña;
        Nombre = nombre;
        Apellido = apellido;
        DNI = dni;
        Mail = mail;
        Calle = calle; 
        Altura = altura;
        IdGrupoCuadra = idGrupoCuadra;
        IdGrupoEdificio = idGrupoEdificio;
        IdGrupoBarrio = idGrupoBarrio;

    }
    public static void CrearUsuarioYAgregar(string usuario, string nombre, string apellido, int dni, string mail, string calle, int altura, string contraseña){
        Usuario nuevoVecino = new Usuario(usuario, contraseña, nombre, apellido, dni, calle, altura, mail);
        BD.AgregarVecino(nuevoVecino);
    }
    
    public static int NumRandom(){
        Random rnd = new Random();
    int randomNumber = rnd.Next(100,1000);
    return randomNumber;
    }
}