namespace ProyectoIntegrador_MiCiudad.Models.ModelsViews;
using System.Text.Json;



[Serializable]
public class UsuarioLogueado(string email, string password)
{
    public string? Email { get; set; } = email;
    public string? Password { get; set; } = password;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    public static UsuarioLogueado? FromString(string? json)
    {
        if (json is null)
        {
            return null;
        }

        return JsonSerializer.Deserialize<UsuarioLogueado>(json);
    }
}
