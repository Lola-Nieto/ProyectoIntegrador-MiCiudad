namespace ProyectoIntegrador_MiCiudad.Models;
public class Reporte
{
    public int ID { get; set; }
    public int IdUsuario { get; set; }
    public string Tipo { get; set; }
    public string Direccion { get; set; }
    public string Descripcion { get; set; }
    public DateTime Dia { get; set; }
    public TimeSpan Hora { get; set; }
}