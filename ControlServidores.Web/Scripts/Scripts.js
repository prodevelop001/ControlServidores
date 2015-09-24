
/***** Verifica con el usuario si desea borrar el registro **********/
function checkMe()
{
    if (confirm("¿Esta seguro de eliminar el archivo?"))
    {
        return true;
    }
    else
    {
        return false;
    }
}