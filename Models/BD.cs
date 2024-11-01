using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;


namespace ProyectoIntegrador_MiCiudad.Models;

public static class BD{
private static string _connectionString = @"Server=localhost;Database=BD; Trusted_Connection=True";


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
}

public static string BuscarMail(string usuarioIngresado){
    string SQL = "SELECT Mail FROM Usuario WHERE UserName = @pUsuario"; //If exists?
    string mailTraido = String.Empty;
       using(SqlConnection db = new SqlConnection(_connectionString)){
    
    mailTraido = db.Query<Usuario>(SQL, new{pUsuario = usuarioIngresado}).ToString();
       }
    return mailTraido;

       }