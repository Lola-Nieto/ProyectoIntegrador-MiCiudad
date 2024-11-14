function ocultar(obj){
    document.getElementById('obj').style.display = 'none';

}
function mostrar(obj){
    document.getElementById('obj').style.display = 'block';
    }
function ValidarMayus(password){
    return (!(password === password.toLowerCase()));
}
function ValidarMinus(password){
    return (!(password === password.toUpperCase()));
}
function ValidarExtension(password){
    return (password.length >= 8);
}

    // https://norfipc.com/inf/javascript-como-ocultar-mostrar-elementos-paginas-web.html 