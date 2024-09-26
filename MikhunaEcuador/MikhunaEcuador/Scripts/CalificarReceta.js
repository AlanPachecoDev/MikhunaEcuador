// getAttribute('calificacion');

const radio1 = document.getElementById("radio1");
const radio2 = document.getElementById("radio2");
const radio3 = document.getElementById("radio3");
const radio4 = document.getElementById("radio4");
const radio5 = document.getElementById("radio5");


var calificacion = 0;

function calificar(evt) {


    evt.preventDefault();

    if (radio1.checked) {
        calificacion = 5;

    }

    if (radio2.checked) {
        calificacion = 4;
    }

    if (radio3.checked) {
        calificacion = 3;
    }

    if (radio4.checked) {
        calificacion = 2;
    }

    if (radio5.checked) {
        calificacion = 1;
    }

    document.getElementById("Cali").value = calificacion;


    console.log(calificacion);

    document.Clasi.submit();


}