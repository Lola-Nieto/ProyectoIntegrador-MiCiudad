// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function ValidarLogIn(){
    const username = document.getElementById('usuario');
    const password = document.getElementById('contraseña');
    let tieneMayus = !(password === password.toLowerCase());
    let tieneMinus = ValidarMinus(password);
    if(password.length != 8){
        let errorContraseña = document.getElementById('mostarError');
        errorContraseña.innerHTML("Su contraseña no tiene los ocho caracteres necesarios");
    }else{
        document.getElementById('loginForm').submit();
    }
    // https://es.stackoverflow.com/questions/411752/como-puedo-enviar-formulario-tras-validar-con-javascript 
}

function ValidarUsuario(){
    const username = document.getElementById('usuario');
    
}