﻿// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ValidarLogIn(){
    return UsuarioYContraseña();
}
function ValidarRegistro(){
    UsuarioYContraseña();
    ContraseñasCoinciden();
}
function ContraseñasCoinciden(){
    const password = document.getElementById('contraseña');
    const passRepe = document.getElementById('password2');
    if(!(password === passRepe)){
        let error = document.getElementById('mostrarError');
        error.innerHTML("Las contraseñas no coinciden");
    }
}

function UsuarioYContraseña(){
    const username = document.getElementById('usuario');
    const password = document.getElementById('contraseña');
    let tieneMayus = ValidarMayus(password);
    let tieneMinus = ValidarMinus();
    let tiene8Min = ValidarExtension(password);
    if(tiene8Min && tieneMinus && tieneMayus){
        document.getElementById('loginForm').submit(); //Hay que poner esto o se envia directo?
        //Si hay que ponerlo habria que poner en la instruccion de arriba una varible para que se pueda llamar desde != funciones
        
    }else{
        let errorContraseña = document.getElementById('mostarError');
        errorContraseña.innerHTML("Su contraseña no cumple con los requisitos necesarios (al menos 8 digitos, 1 mayúscula y 1 minúscula)");
    }
    if(ValidarUsuario()){ //Es necesario?
        let errorUsuario = document.getElementById('mostarError');
        errorUsuario.innerHTML("Usuario no completado");
    }
    // https://es.stackoverflow.com/questions/411752/como-puedo-enviar-formulario-tras-validar-con-javascript 
}

function ValidarUsuario(username){
    const username = document.getElementById('usuario');
    let bool = false;
    if(username.trim() != ""){
         bool = true;
    }
    return bool;
}

function ValidarCodigo(){
    const codigoIngresado = document.getElementById('codigoIngresado');
    const codigoGenerado = document.getElementById('codigoGenerado');
    return (codigoIngresado === codigoGenerado);

    
}