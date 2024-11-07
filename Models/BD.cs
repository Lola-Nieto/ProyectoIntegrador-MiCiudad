using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using Microsoft.Extensions.ObjectPool;


namespace ProyectoIntegrador_MiCiudad.Models;

public static class BD{
private static string _connectionString = @"Server=A-PHZ2-CIDI-43;Database=MiCiudad; Trusted_Connection=True";


public static bool ChequearCuentaExiste(string usuarioIngresado, string contraseñaIngresado){
    string SQL = "SELECT UserName FROM Usuario WHERE UserName = @pUsuario AND Contraseña = pContraseña"; //If exists?
    string usuarioTraido = String.Empty;
    bool existe = false;
    using(SqlConnection db = new SqlConnection(_connectionString)){
    
    usuarioTraido = db.Query<Usuario>(SQL, new{pUsuario = usuarioIngresado, pContraseña = contraseñaIngresado}).ToString();
    }
    if(usuarioTraido != string.Empty){
        existe = true;
    }
    return existe;
}

public static Usuario TraerDatosUsuario(string username){
    string SQL = "SELECT * FROM Usuario WHERE UserName = @pUsuario "; 
    Usuario usuarioTraido = null;
    using(SqlConnection db = new SqlConnection(_connectionString)){
    usuarioTraido = DB.QueryFirstOrDefault<Usuario>(SQL, new{pUsuario = username}); 
    return usuarioTraido;
}
}
public static bool BuscarSiExiste(string username){
    string SQL = "SELECT UserName FROM Usuario WHERE UserName = @pUsuario "; 
    using(SqlConnection db = new SqlConnection(_connectionString)){
    string usuarioTraido = db.Query<Usuario>(SQL, new{pUsuario = username}).ToString();
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
    
    mailTraido = db.Query<Usuario>(SQL, new{pUsuario = usuarioIngresado}).ToString();
       }
    return mailTraido;

       }

}
