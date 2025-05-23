using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.ObjectPool;
using ProyectoIntegrador_MiCiudad.Models.ModelsViews;


namespace ProyectoIntegrador_MiCiudad.Models;

public static class BD
{
    private static string _connectionString = @"Server=.;Database=MiCiudad; Trusted_Connection=true; TrustServerCertificate=True";


    public static void AgregarVecino(Usuario userAAgregar)
    {
        string SQL = "INSERT Usuario(Nombre, Apellido, Contraseña, UserName, Altura, Calle, DNI, Mail) VALUES (@pNombre, @pApellido, @pContrasena, @pUsuario, @pAltura, @pCalle, @pDNI, @pMail)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(SQL, new { pUsuario = userAAgregar.UserName, pContrasena = userAAgregar.Contraseña, pNombre = userAAgregar.Nombre, pApellido = userAAgregar.Apellido, pDNI = userAAgregar.DNI, pMail = userAAgregar.Mail, pAltura = userAAgregar.Altura, pCalle = userAAgregar.Calle });
        }
    }
    /*
    public static bool ChequearCuentaExiste(string usuarioIngresado, string contraseñaIngresada){
        string SQL = "SELECT UserName FROM Usuario WHERE UserName = @pUsuario AND Contraseña = @pContraseña"; //Cómo hago que devuelva el usuario?
        Usuario usuarioTraido = null;
        bool existe = false;
        using(SqlConnection db = new SqlConnection(_connectionString)){

        usuarioTraido = db.QueryFirstOrDefault(SQL, new{pUsuario = usuarioIngresado, pContraseña = contraseñaIngresada}).ToString();    }
        if(usuarioTraido != null){ //Cannot perform on null reference
            existe = true;
        }
        return existe;
    }
    */

    /*
public static Usuario TraerDatosUsuario(string username, string contraseña)
{
    Usuario user = null;
    using (SqlConnection con = new SqlConnection(_connectionString))
    {
        con.Open();
        string query = "SELECT * FROM USUARIO WHERE UserName = @user AND Contraseña = @pass";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@user", username);
        cmd.Parameters.AddWithValue("@pass", contraseña);

        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            user = new Usuario()
            {
                ID = Convert.ToInt32(["ID"]),
                UserName = reader["UserName"].ToString(),
                Contraseña = reader["Contraseña"].ToString(),
                Nombre = reader["Nombre"].ToString(),
                Apellido = reader["Apellido"].ToString(),
                DNI = Convert.ToInt32(reader["DNI"]),
                Mail = reader["Mail"].ToString(),
                Calle = reader["Calle"].ToString(),
                Altura = Convert.ToInt32(reader["Altura"]),
                Patente = reader["Patente"] != DBNull.Value ? Convert.ToInt32(reader["Patente"]) : 0,
                IdGrupoCuadra = reader["idGrupoCuadra"] != DBNull.Value ? Convert.ToInt32(reader["idGrupoCuadra"]) : 0,
                IdGrupoEdificio = reader["idGrupoEdificio"] != DBNull.Value ? Convert.ToInt32(reader["idGrupoEdificio"]) : 0,
                IdGrupoBarrio = reader["idGrupoBarrio"] != DBNull.Value ? Convert.ToInt32(reader["idGrupoBarrio"]) : 0,
                IsAdmin = Convert.ToBoolean(reader["isAdmin"])
            };
        }
    }
    return user;
} 
--> Lo llamo desde ValidacionLogIn --> No hacerlo así porq no se sabe si efectivamente va a devolver un usuario 
*/
public static int TraerIdUsuario(string username, string contraseña)
{
    string SQL = "SELECT ID FROM USUARIO WHERE UserName = @pUser AND Contraseña = @pPass";
    int idTraido = -1;
    using (SqlConnection db = new SqlConnection(_connectionString))
    {
        var resultado = db.QueryFirstOrDefault<int?>(SQL, new { pUser = username, pPass = contraseña });

        if (resultado.HasValue)
        {
            idTraido = resultado.Value;
        }
    }
    return idTraido;
}

public static List<Reporte> ObtenerReportes()
{
    string SQL = "SELECT ID, idUsuario, Hora, Dia, Tipo, Direccion, Descripcion FROM REPORTES";
    using (SqlConnection db = new SqlConnection(_connectionString))
    {
        return db.Query<Reporte>(SQL).ToList();
    }
}


public static void GuardarReporte(Reporte reporte)
{
    using (SqlConnection con = new SqlConnection(_connectionString))
    {
        con.Open();
        string query = "INSERT INTO REPORTES (IdUsuario, Tipo, Direccion, Descripcion, Dia, Hora) VALUES (@idUsuario, @tipo, @direccion, @descripcion, @dia, @hora)";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@idUsuario", reporte.IdUsuario);
        cmd.Parameters.AddWithValue("@tipo", reporte.Tipo);
        cmd.Parameters.AddWithValue("@direccion", reporte.Direccion);
        cmd.Parameters.AddWithValue("@descripcion", reporte.Descripcion);
        cmd.Parameters.AddWithValue("@dia", reporte.Dia);
        cmd.Parameters.AddWithValue("@hora", reporte.Hora);
        cmd.ExecuteNonQuery();
    }
}

 
    public static Usuario TraerDatosUsuarioConID(int id)
    {
        string SQL = "SELECT * FROM Usuario WHERE ID = @pId";
        Usuario usuarioTraido = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            usuarioTraido = db.QueryFirstOrDefault<Usuario>(SQL, new { pId = id });
        }
        return usuarioTraido;

    }
    public static Usuario TraerDatosUsuarioSoloUsername(string username)
    {
        string SQL = "SELECT * FROM Usuario WHERE UserName = @pUsuario";
        Usuario usuarioTraido = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            usuarioTraido = db.QueryFirstOrDefault<Usuario>(SQL, new { pUsuario = username });
        }
        return usuarioTraido;

    }
    
    public static bool BuscarSiExiste(string username)
    {
        string SQL = "SELECT UserName FROM Usuario WHERE UserName = @pUsuario ";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string usuarioTraido = db.QueryFirstOrDefault(SQL, new { pUsuario = username }).ToString();
            bool ret = false;
            if (usuarioTraido != null)
            {
                ret = true;
            }
            return ret;
        } //Para qué si la búsqueda para registro la hace con el mail?

    }
    
    /*

    Con SP
    public static bool ChequearExistenciaCliente(int dni){
        bool ret = false;
        string sp = "sp_ChequearExistenciaCliente"; 
        using(SqlConnection db = new SqlConnection(_connectionString)){
        ret = db.Query<bool>(sp, new{pDocumento = dni , ret = ret}, 
        commandType: CommandType.StoredProcedure);

    }return ret;
    }

    Anterior
    public static bool ChequearExistenciaCliente(int dni){
        string usuarioTraido;
        string SQL = "SELECT UserName FROM Usuario WHERE DNI = @pDocumento "; 
        using(SqlConnection db = new SqlConnection(_connectionString)){
        usuarioTraido = db.QueryFirstOrDefault(SQL, new{pDocumento = dni}).ToString();
        bool ret = false;
        if(string.IsNullOrEmpty(usuarioTraido)){
            ret = true;
        } 
        return ret;
    }
    }


    */
    public static bool ChequearExistenciaCliente(int dni)
    {
        string usuarioTraido = null;
        string SQL = "SELECT UserName FROM Usuario WHERE DNI = @pDocumento";

        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            var resultado = db.QueryFirstOrDefault<string>(SQL, new { pDocumento = dni });
            usuarioTraido = resultado;
        }

        return !string.IsNullOrEmpty(usuarioTraido);
    }


    public static string BuscarMail(string usuarioIngresado)
    {
        string SQL = "SELECT Mail FROM Usuario WHERE UserName = @pUsuario"; //If exists? Tira error sino?
        string mailTraido = "";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            mailTraido = db.QueryFirstOrDefault<string>(SQL, new { pUsuario = usuarioIngresado });
        }
        return mailTraido; //Devuelve "" si no lo encuentra?
    }
       public static List<Evento> ObtenerEventos()
        {
            List<Evento> eventos = new List<Evento>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM calendario";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    eventos.Add(new Evento
                    {
                        Id = (int)reader["id"],
                        Titulo = reader["titulo"].ToString(),
                        Descripcion = reader["descripcion"].ToString(),
                        Fecha = (DateTime)reader["fecha"],
                        Hora = (TimeSpan)reader["hora"],
                        CreadoPor = (int)reader["creado_por"]
                    });
                }
            }
            return eventos;
        }

        public static void CrearEvento(Evento e)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO calendario (titulo, descripcion, fecha, hora, creado_por) VALUES (@titulo, @desc, @fecha, @hora, @creadoPor)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@titulo", e.Titulo);
                cmd.Parameters.AddWithValue("@desc", e.Descripcion);
                cmd.Parameters.AddWithValue("@fecha", e.Fecha);
                cmd.Parameters.AddWithValue("@hora", e.Hora);
                cmd.Parameters.AddWithValue("@creadoPor", e.CreadoPor);
                cmd.ExecuteNonQuery();
            }
        }

        public static void EliminarEvento(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "DELETE FROM calendario WHERE id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

}
