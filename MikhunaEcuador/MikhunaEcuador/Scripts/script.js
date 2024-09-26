const cardLogin = document.getElementById('cardLoginID');
const gF = document.getElementById('gF');
const gT = document.getElementById('gT');

const gI = document.getElementById('gI');

const displayGf = gF.getAttribute("display");
const displayGt = gT.getAttribute("display");

function girarLogin() {
    //cardLogin class
    gF.style.visibility = "hidden";
    gF.style.display = "none";

    gT.style.visibility = "visible";
    gT.style.display = displayGt;

    cardLogin.style.transform = "rotateY(180deg)";
    gT.style.transform = "rotateY(-180deg)";

    cardLogin.style.transition = "all 400ms ease-in-out";
    cardLogin.style.perspective = "1000px";
    //document.getElementsByClass('giroTrasero-login');
}

girarLogin();

function girarLogin2() {
    //cardLogin class
    gT.style.display = "none";
    gT.style.visibility = "hidden";
    gF.style.display = displayGf;
    gF.style.visibility = "visible";
    
    

    cardLogin.style.transform = "rotateY(-180deg)";
    gF.style.transform = "rotateY(180deg)";

    cardLogin.style.transition = "all 400ms ease-in-out";
    cardLogin.style.perspective = "1000px";
    //document.getElementsByClass('giroTrasero-login');

}

//var btnCrearReceta = document.getElementById("btnCrearReceta");


//var receta = document.getElementById('mostrarReceta');
//var displayReceta = receta.getAttribute('display');
//var ingrePasos = document.getElementById('oculto1');
//var displayIngrePasos = ingrePasos.getAttribute('display');

////En un inicio los displays de ingrepasos está desactivado
//ingrePasos.style.display = "none";

//function mostrar() {
//    //Desactivo el display
//    receta.style.display = "none";

//    //Vuelvo a activar
//    ingrePasos.style.display = displayIngrePasos;

//    console.log("Sí se muestraeeeee");
//    //ingrePasos.style.visibility = "initial";
//}





