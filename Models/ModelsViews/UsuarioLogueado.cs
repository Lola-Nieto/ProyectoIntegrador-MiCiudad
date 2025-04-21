using System.Text.Json;
namespace ProyectoIntegrador_MiCiudad.Models.ModelsViews
{
    public class UsuarioLogueado
    {
        private static UsuarioLogueado instancia;

        public string UserName { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool IsAdmin { get; set; }

        private UsuarioLogueado() { }

        public UsuarioLogueado(string username, string nombre, string apellido, bool esAdmin) { 
            UserName = username; 
            Nombre = nombre; 
            Apellido = apellido; 
            IsAdmin = esAdmin;

        }
        public static UsuarioLogueado Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new UsuarioLogueado();
                }
                return instancia;
            }
        }

        public static void CerrarSesion()
        {
            instancia = null;
        }
    }
}
