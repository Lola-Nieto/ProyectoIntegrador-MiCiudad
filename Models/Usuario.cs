namespace ProyectoIntegrador_MiCiudad.Models
{
    public class Usuario
    {
        public string UserName { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public string Mail { get; set; }
        public int Patente { get; set; }
        public int IdGrupoCuadra { get; set; }
        public int IdGrupoEdificio { get; set; }
        public int IdGrupoBarrio { get; set; }
        public bool IsAdmin { get; set; }

        public Usuario() { }

        private Usuario(string username, string contraseña, string nombre, string apellido, int dni, string calle, int altura, string mail, bool isAdmin = false)
        {
            UserName = username;
            Contraseña = contraseña;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Mail = mail;
            Calle = calle;
            Altura = altura;
            IsAdmin = isAdmin;
        }

        private Usuario(string username, string contraseña, string nombre, string apellido, int dni, string calle, int altura, string mail, int patente, bool isAdmin = false)
        {
            UserName = username;
            Contraseña = contraseña;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Mail = mail;
            Calle = calle;
            Altura = altura;
            Patente = patente;
            IsAdmin = isAdmin;
        }

        private Usuario(string username, string contraseña, string nombre, string apellido, int dni, string calle, int altura, string mail, int patente, int idGrupoCuadra, int idGrupoBarrio, int idGrupoEdificio, bool isAdmin = false)
        {
            UserName = username;
            Contraseña = contraseña;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Mail = mail;
            Calle = calle;
            Altura = altura;
            Patente = patente;
            IdGrupoCuadra = idGrupoCuadra;
            IdGrupoEdificio = idGrupoEdificio;
            IdGrupoBarrio = idGrupoBarrio;
            IsAdmin = isAdmin;
        }

        public static Usuario CrearUsuarioYAgregar(string usuario, string nombre, string apellido, int dni, string mail, string calle, int altura, string contraseña)
        {
            Usuario nuevoVecino = new Usuario(usuario, contraseña, nombre, apellido, dni, calle, altura, mail);
            BD.AgregarVecino(nuevoVecino);
            return nuevoVecino;
        }

        public static void CrearUsuario(string usuario, string nombre, string apellido, int dni, string mail, string calle, int altura, string contraseña)
        {
            Usuario nuevoVecino = new Usuario(usuario, contraseña, nombre, apellido, dni, calle, altura, mail);
            BD.AgregarVecino(nuevoVecino);
        }

        public static int NumRandom()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(100, 1000);
            return randomNumber;
        }
    }
}
