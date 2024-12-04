using System.Text.Json;
namespace ProyectoIntegrador_MiCiudad.Models.ModelsViews;


public class UsuarioLogueado{
    public string Email { get; set; }
    public string Password { get; set; }

public UsuarioLogueado(string email, string password){
    Email = email;
    Password = password;
}
}    


