using System.Collections.Generic;

namespace ControlServidores.Negocio.Inventarios
{
    public class SOxServidor
    {
        /// <summary>
        /// Obtiene registros de SOxServidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.Almacenamiento></returns>
        public static List<Entidades.SOxServidor> Obtener(Entidades.SOxServidor a)
        {
            return Datos.Inventarios.SOxServidor.Obtener(a);
        }

        /// <summary>
        /// Registra un nuevo SOxServidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.SOxServidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = Datos.Inventarios.SOxServidor.Nuevo(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "SO registrado correctamente.";
                resultado.errores.Add(error);
            }
            else
            {
                error = new Entidades.Logica.Error();
                error.idError = 2;
                error.descripcionCorta = "Proceso no completado.";
                resultado.errores.Add(error);
            }

            return resultado;
        }


        /// <summary>
        /// Actualiza un registro en Almacenamiento.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.SOxServidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = Datos.Inventarios.SOxServidor.Actualizar(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "SO actualizado correctamente.";
                resultado.errores.Add(error);
            }
            else
            {
                error = new Entidades.Logica.Error();
                error.idError = 2;
                error.descripcionCorta = "Proceso no completado.";
                resultado.errores.Add(error);
            }

            return resultado;
        }

        /// <summary>
        /// Elimina el registro en SOxServidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.SOxServidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = Datos.Inventarios.SOxServidor.Eliminar(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "SO eliminado del servidor.";
                resultado.errores.Add(error);
            }
            else
            {
                error = new Entidades.Logica.Error();
                error.idError = 2;
                error.descripcionCorta = "Proceso no completado.";
                resultado.errores.Add(error);
            }

            return resultado;
        }
    }
}
