using System.Text.Json;
namespace ProyectoIntegrador_MiCiudad.Models.ModelsViews;


public class UsuarioLogueado{
    public string Username { get; set; }
    public string Password { get; set; }

public UsuarioLogueado(string username, string password){
    Username = username;
    Password = password;
}
public UsuarioLogueado(){
}    

}
