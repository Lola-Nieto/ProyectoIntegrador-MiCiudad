using System.Text.Json;

[Serializable]
public class Usuario(string email, string password)
{
    public string? Email { get; set; } = email;
    public string? Password { get; set; } = password;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

    public static Usuario? FromString(string? json)
    {
        if (json is null)
        {
            return null;
        }

        return JsonSerializer.Deserialize<Usuario>(json);
    }
}
