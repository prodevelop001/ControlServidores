var x = document.querySelectorAll(".miTabla tr td:nth-child(4) a");
var i;
for (i = 0 ; i < x.length; i++)
{
    x[i].className = x.className + " icon-pencil";
}

var y = document.querySelectorAll(".miTabla tr td:nth-child(5) a");
var i;
for (i = 0 ; i < y.length; i++) {
    y[i].className = y.className + " icon-cross";
}
//-----------------------------Concepto Estatus---------------------------------------
function agregar_iconos(){
    var x2 = document.querySelectorAll("#cuerpoPpal_gdvConceptos tbody tr td:nth-child(4) a");
    var i2;
    for (i2 = 0 ; i2 < x2.length; i2++) {
        x2[i2].className = x2.className + " icon-pencil";
    }

    var y2 = document.querySelectorAll("#cuerpoPpal_gdvConceptos tbody tr td:nth-child(5) a");
    var i2;
    for (i2 = 0 ; 2 < y2.length; i2++) {
        y2[i2].className = y2.className + " icon-cross";
    }
}

function mensaje() {
    alert("Mensaje de prueba");
}