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