// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ValidarRegistro()
{
    alert('Entra a la función');

    let contraValida = ValidarContraseña();
    let contraCoinciden = ContraseñasCoinciden();
    let username = document.getElementById('usuario').value; 
    let usertomado = ValidarExistenciaUsuario(username);                                                                                                                                                                                                                                                                          
     if(usertomado){
        let errorUsuario = document.getElementById('mostrarError');
        alert('2do if / usuario ya tomado');
    errorUsuario.innerHTML ="Usuario ya está tomado";
    return false;
    }
    alert(contraValida && contraCoinciden && !usertomado);
   return contraValida && contraCoinciden && !usertomado;  
}
function ValidarRegistro1eraParte(dni){
    alert("CHAU");
    let ret = false;
    let existeCliente = ValidarPersonaNueva(dni);
    if(!existeCliente){
        document.getElementById('parte2').style.visibility = "visible";
        document.getElementById('parte1').style.visibility = "hidden";
        alert('CLiente no existe --> puede seguir parte 2'); 
        ret = true;
    }
    return ret;
}



function ValidarPersonaNueva(dni){
    alert('Se mete en condicion AJAX validarPersonaNueva');
        $.ajax({
            url: '/Account/ExisteClienteRegistro', 
            data: {Dni : dni}, 
            type: 'GET', 
            dataType: 'json', 
            success: function(response){
                    ret = response;   
                    
            }
            
        });
        alert(ret);
        return ret;
}


function ContraseñasCoinciden()
{
    let ret=true;
    const password = document.getElementById('contraseña').value;
    const passRepe = document.getElementById('password2').value;
    if(!(password === passRepe)){
        let error = document.getElementById('mostrarError');
        error.innerHTML="Las contraseñas no coinciden";
        alert('contraseñas no coinciden');
        ret=false;
    }
    return ret;
}

function ValidarContraseña()
{
    let ret = false;

    const username = document.getElementById('usuario').value;
    const password = document.getElementById('contraseña').value;
    console.log(password);
    let tieneMayus = ValidarMayus(password);
    let tieneMinus = ValidarMinus(password);
    let tiene8Min = ValidarExtension(password);
    
    if(tiene8Min && tieneMinus && tieneMayus){
        ret = true;
    }else{
        alert('Contraseña no cumple requisitos');
        let errorContraseña = document.getElementById('mostrarError');
        errorContraseña.innerHTML ="Su contraseña no cumple con los requisitos necesarios (al menos 8 digitos, 1 mayúscula y 1 minúscula)";
    }

    return ret;
    // https://es.stackoverflow.com/questions/411752/como-puedo-enviar-formulario-tras-validar-con-javascript 
}

function ValidarExistenciaUsuario(username){
    let ret = false; 
    let usuario = username.value;
    if(ValidarUsuarioEscrito()){
        $.ajax({
            url: '/Account/ExisteUsuarioRegistro', 
            data: {Username : usuario}, 
            type: 'GET', 
            dataType: 'json', 
            success: function(response){
                    ret = response;   
            }
            
        });
        }  
        
    }
    return ret;

    function ValidarOlvidePass1eraParte(usuario){
        let ret= false;
        let existeUsuario = ValidarExistenciaUsuario(usuario);
        if(!existeUsuario){
            document.getElementById('parte2').style.visibility = "visible";
            document.getElementById('parte1').style.visibility = "hidden";
            mensajeB.style.color = (pass===pass.toLowerCase() ? "red" : "green");  
            alert('Usuario no existe --> puede seguir parte 2'); 
            ret = true;
        }
        alert(ret);
        return ret;
    }

function ValidarUsuarioOlvidePass(usuario){
return ValidarExistenciaUsuario(username);
}

function ValidarUsuarioEscrito(username){
    let ret = true;
    if(username.trim() == ""){
         ret = false;
         let errorUsuario = document.getElementById('mostrarError');
         errorUsuario.innerHTML = "El ingreso de usuario es requerido";
    }
    return ret;
}

function ValidarCodigo(){
    const codigoIngresado = document.getElementById('codigoIngresado');
    const codigoGenerado = document.getElementById('codigoGenerado');
    let ret = false;
    if(codigoIngresado == codigoGenerado){
            document.getElementById('OlvidePassForm').submit();
            ret = true;
    }else{
        let errorCod = document.getElementById('mostrarError');
        errorCod.innerHTML ="Código incorrecto";

    }
    return ret;
}

function ValidarExistenciaUsuarioYContra(username, password){
    let ret = false; 
    let usuario = username.value;
    if(ValidarUsuarioEscrito()){
        $.ajax({
            url: '/Account/ValidacionLogIn', 
            data: {usuario : username , contraseña : password}, 
            type: 'GET', 
            dataType: 'json', 
            success: function(response){
                    ret = response;   
            }
            
        });
    }
    return ret;
}


function ValidarLogIn(){
    alert('ENtra a Validar el Log In');
    let username = document.getElementById('usuario').value;
    let password = document.getElementById('contraseña').value;
    let existeUsuario = ValidarExistenciaUsuarioYContra(username, password);
    
    if(!existeUsuario){
        let errorUsuario = document.getElementById('mostrarError');
        errorUsuario.innerHTML ="Usuario y/o contraseña incorrectos";
        alert('Usuario y/o contraseña incorrectos');
    }
    return existeUsuario;
}
