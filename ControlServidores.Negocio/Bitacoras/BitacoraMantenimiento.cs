using System.Collections.Generic;

namespace ControlServidores.Negocio.Bitacoras
{
    public class BitacoraMantenimiento
    {
        public static List<Entidades.BitacoraMantenimiento> Obtener(Entidades.BitacoraMantenimiento a)
        {
            return Datos.Bitacoras.BitacoraMantenimiento.Obtener(a);
        }

        public static Entidades.Logica.Ejecucion Nuevo(Entidades.BitacoraMantenimiento a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;
            resultado.resultado = Datos.Bitacoras.BitacoraMantenimiento.Nuevo(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Se registro un evento en la bitacora de operaciones correctamente.";
                resultado.errores.Add(error);
            }
            else
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Ocurrio un problema para registra el evento en la bitacora, proceso no concluido.";
                resultado.errores.Add(error);
            }

            return resultado;
        }

        public static Entidades.Logica.Ejecucion Actualizar(Entidades.BitacoraMantenimiento a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;
            resultado.resultado = Datos.Bitacoras.BitacoraMantenimiento.Actualizar(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Se actualizo el registro en la bitacora de operaciones correctamente.";
                resultado.errores.Add(error);
            }
            else
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Ocurrio un problema para registra el evento en la bitacora, proceso no concluido.";
                resultado.errores.Add(error);
            }

            return resultado;
        }
    }
}
