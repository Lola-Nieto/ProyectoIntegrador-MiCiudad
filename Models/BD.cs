using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using Microsoft.Extensions.ObjectPool;


namespace ProyectoIntegrador_MiCiudad.Models;

public static class BD{
private static string _connectionString = @"Server=localhost;Database=MiCiudad; Trusted_Connection=True";

public static void AgregarVecino(Usuario userAAgregar) {
    string SQL = "INSERT Usuario(Nombre, Apellido, Contrasena, UserName, Altura, Calle, DNI, Mail) VALUES (pNombre, pApellido, pContrasena, pUsuario, pAltura, pCalle, pDNI, pMail)"; 
     using(SqlConnection db = new SqlConnection(_connectionString)){
    db.Execute(SQL, new{pUsuario = userAAgregar.UserName, pContrasena = userAAgregar.Contraseña, pNombre = userAAgregar.Nombre, pApellido = userAAgregar.Apellido, pDNI = userAAgregar.DNI, pMail = userAAgregar.Mail, pAltura = userAAgregar.Altura, pCalle = userAAgregar.Calle});
    }
}

public static bool ChequearCuentaExiste(string usuarioIngresado, string contraseñaIngresada){
    string SQL = "IF EXISTS (SELECT UserName FROM Usuario WHERE UserName = @pUsuario AND Contraseña = @pContraseña) BEGIN return 1 END"; //Cómo hago que devuelva el usuario?
    string usuarioTraido = String.Empty;
    bool existe = false;
    using(SqlConnection db = new SqlConnection(_connectionString)){
    
    usuarioTraido = db.QueryFirstOrDefault(SQL, new{pUsuario = usuarioIngresado, pContraseña = contraseñaIngresada}).ToString();    }
    if(usuarioTraido != null){ //Cannot perform on null reference
        existe = true;
    }
    return existe;
}

public static Usuario TraerDatosUsuario(string username){
    string SQL = "SELECT * FROM Usuario WHERE UserName = @pUsuario "; 
    Usuario usuarioTraido = null;
    using(SqlConnection db = new SqlConnection(_connectionString)){
    usuarioTraido = db.QueryFirstOrDefault<Usuario>(SQL, new{pUsuario = username}); 
    return usuarioTraido;
}
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
}

}

public static string BuscarMail(string usuarioIngresado){
    string SQL = "SELECT Mail FROM Usuario WHERE UserName = @pUsuario"; //If exists? Tira error sino?
    string mailTraido = String.Empty;
    using(SqlConnection db = new SqlConnection(_connectionString)){
    
    mailTraido = db.QueryFirstOrDefault(SQL, new{pUsuario = usuarioIngresado}).ToString();
       }
    return mailTraido;

       }

}
