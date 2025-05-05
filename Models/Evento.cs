using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIntegrador_MiCiudad.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int CreadoPor { get; set; }
        public string Categoria { get; set; } // ejemplo: "Festival", "Feria", etc.
    }
}
