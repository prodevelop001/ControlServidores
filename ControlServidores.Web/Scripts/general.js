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
function agregar_iconos() {
    var num = document.getElementById("numCols").innerHTML;
    /***Icono Editar***/
    if (num === "5")
    {
        var x2 = document.querySelectorAll(".miTabla5 tbody tr td:nth-child(" + (num - 1) + ") a");
    }
    else if (num === "7") {
        var x2 = document.querySelectorAll(".miTabla7 tbody tr td:nth-child(" + (num - 1) + ") a");
    }
    else if (num === "9") {
        var x2 = document.querySelectorAll(".miTabla9 tbody tr td:nth-child(" + (num - 1) + ") a");
    }
    var i2;
    for (i2 = 0 ; i2 < x2.length; i2++) {
        x2[i2].className = x2.className + " icon-pencil";
    }
    /**Icono Eliminar**/
    if (num === "5")
    {
        var y2 = document.querySelectorAll(".miTabla5 tbody tr td:nth-child(" + num + ") a");
    }
    else if (num === "7") {
        var y2 = document.querySelectorAll(".miTabla7 tbody tr td:nth-child(" + num + ") a");
    }
    else if (num === "9") {
        var y2 = document.querySelectorAll(".miTabla9 tbody tr td:nth-child(" + num + ") a");
    }
    
    var i2;
    for (i2 = 0 ; 2 < y2.length; i2++) {
        y2[i2].className = y2.className + " icon-cross";
    }
}

/***** Verifica con el usuario si desea borrar el registro **********/
function checkMe() {
    if (confirm("¿Esta seguro de eliminar el registro?")) {
        return true;
    }
    else {
        return false;
    }
}