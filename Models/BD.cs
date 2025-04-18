using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using Microsoft.Extensions.ObjectPool;
using ProyectoIntegrador_MiCiudad.Models.ModelsViews;


namespace ProyectoIntegrador_MiCiudad.Models;

public static class BD{
private static string _connectionString = @"Server=.;Database=MiCiudad; Trusted_Connection=True";


public static void AgregarVecino(Usuario userAAgregar) {
    string SQL = "INSERT Usuario(Nombre, Apellido, Contraseña, UserName, Altura, Calle, DNI, Mail) VALUES (@pNombre, @pApellido, @pContrasena, @pUsuario, @pAltura, @pCalle, @pDNI, @pMail)"; 
    using(SqlConnection db = new SqlConnection(_connectionString)){
    db.Execute(SQL, new{pUsuario = userAAgregar.UserName, pContrasena = userAAgregar.Contraseña, pNombre = userAAgregar.Nombre, pApellido = userAAgregar.Apellido, pDNI = userAAgregar.DNI, pMail = userAAgregar.Mail, pAltura = userAAgregar.Altura, pCalle = userAAgregar.Calle});
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
public static Usuario TraerDatosUsuario(string username, string contraseñaIngresada){
    Usuario usuarioTraido = null;
    using(SqlConnection db = new SqlConnection(_connectionString)){
        string SQL = "SELECT * FROM Usuario WHERE UserName = @pUsuario AND Contraseña = @pContraseña";
    usuarioTraido = db.QueryFirstOrDefault<Usuario>(SQL, new{pUsuario = username, pContraseña = contraseñaIngresada}); 
    }
    return usuarioTraido;


//Cambio de ret (bool) a usuarioTraido
public static Usuario TraerDatosUsuarioSoloUsername(string username){
    string SQL = "SELECT * FROM Usuario WHERE UserName = @pUsuario"; 
    Usuario usuarioTraido = null;
    using(SqlConnection db = new SqlConnection(_connectionString)){
    usuarioTraido = db.QueryFirstOrDefault<Usuario>(SQL, new{pUsuario = username}); 
    }
    return usuarioTraido;

}
public static bool BuscarSiExiste(string username){
    string SQL = "SELECT UserName FROM Usuario WHERE UserName = @pUsuario "; 
    using(SqlConnection db = new SqlConnection(_connectionString)){
    string usuarioTraido = db.QueryFirstOrDefault(SQL, new{pUsuario = username}).ToString();
    bool ret = false;
    if(usuarioTraido != null){
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


public static string BuscarMail(string usuarioIngresado){
    string SQL = "SELECT Mail FROM Usuario WHERE UserName = @pUsuario"; //If exists? Tira error sino?
    string mailTraido = "";
    using(SqlConnection db = new SqlConnection(_connectionString))
    {
        mailTraido = db.QueryFirstOrDefault<string>(SQL, new{pUsuario = usuarioIngresado});
    }
    return mailTraido; //Devuelve "" si no lo encuentra?
}

}
