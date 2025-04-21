using System;
using System.ComponentModel.DataAnnotations;

namespace ProyectoIntegrador_MiCiudad.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La hora es obligatoria")]
        public TimeSpan Hora { get; set; }

        [Required]
        public string Categoria { get; set; }

        public int CreadoPor { get; set; }

        public DateTime? ActualizadoEn { get; set; }
    }
}
