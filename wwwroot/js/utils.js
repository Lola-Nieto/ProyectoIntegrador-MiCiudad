function ocultar(obj){
    document.getElementById('obj').style.display = 'none';

}
function mostrar(obj){
    document.getElementById('obj').style.display = 'block';
    }
function ValidarMayus(password){
    return (!(password === password.toUpperCase()));
}
function ValidarMinus(password){
    return (!(password === password.toLowerCase()));
}
    // https://norfipc.com/inf/javascript-como-ocultar-mostrar-elementos-paginas-web.html 