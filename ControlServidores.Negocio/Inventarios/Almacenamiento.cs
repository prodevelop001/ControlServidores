using System.Collections.Generic;

namespace ControlServidores.Negocio.Inventarios
{
    public class Almacenamiento
    {
        /// <summary>
        /// Obtiene registros de Almacenamiento.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.Almacenamiento></returns>
        public static List<Entidades.Almacenamiento> Obtener(Entidades.Almacenamiento a)
        {
            return Datos.Inventarios.Almacenamiento.Obtener(a);
        }

        /// <summary>
        /// Registra un nuevo tipo de almacenamiento en un servidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.Almacenamiento a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = Datos.Inventarios.Almacenamiento.Nuevo(a);
            if(resultado.resultado== true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Almacenamiento registrado correctamente.";
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
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.Almacenamiento a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = Datos.Inventarios.Almacenamiento.Actualizar(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Almacenamiento actualizado correctamente.";
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
        /// Elimina el registro en Almacenamiento.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.Almacenamiento a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = Datos.Inventarios.Almacenamiento.Eliminar(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Almacenamiento eliminado.";
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
