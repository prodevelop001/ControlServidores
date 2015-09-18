using System.Collections.Generic;

namespace ControlServidores.Negocio.Inventarios
{
    public class Soporte
    {
        /// <summary>
        /// Obtiene registros de Soporte.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.Almacenamiento></returns>
        public static List<Entidades.Soporte> Obtener(Entidades.Soporte a)
        {
            return Datos.Inventarios.Soporte.Obtener(a);
        }

        /// <summary>
        /// Registra un nuevo Soporte.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.Soporte a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = Datos.Inventarios.Soporte.Nuevo(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Soporte registrado correctamente.";
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
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.Soporte a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = Datos.Inventarios.Soporte.Actualizar(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Soporte actualizado correctamente.";
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
        /// Elimina el registro en Soporte.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.Soporte a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = Datos.Inventarios.Soporte.Eliminar(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Soporte eliminado.";
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
