using System.Collections.Generic;
using System.Linq;

namespace ControlServidores.Negocio.Inventarios
{
    public class ConfRed
    {
        /// <summary>
        /// Obtiene registros de Configuración de red.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.Almacenamiento></returns>
        public static List<Entidades.ConfRed> Obtener(Entidades.ConfRed a)
        {
            return Datos.Inventarios.ConfRed.Obtener(a);
        }

        /// <summary>
        /// Registra un nuevo tipode Configuración de red.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.ConfRed a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.ConfRed> consultaRed = new List<Entidades.ConfRed>();
            consultaRed = Datos.Inventarios.ConfRed.Obtener(new Entidades.ConfRed() { DirIP = a.DirIP, MascaraSubRed = a.MascaraSubRed });
            if (consultaRed.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Dirección de IP duplicada.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Inventarios.ConfRed.Nuevo(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Configuración de red registrada correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 2;
                    error.descripcionCorta = "Proceso no completado.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }


        /// <summary>
        /// Actualiza un registro de Configuración de red.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.ConfRed a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.ConfRed> consultaRed = new List<Entidades.ConfRed>();
            consultaRed = Datos.Inventarios.ConfRed.Obtener(new Entidades.ConfRed() { DirIP = a.DirIP, MascaraSubRed = a.MascaraSubRed });
            var red = from l in consultaRed
                      where l.IdConfRed != a.IdConfRed
                      select l;
            consultaRed = red.ToList();

            if (consultaRed.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Dirección de IP duplicada.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Inventarios.ConfRed.Actualizar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Configuración de red actualizada correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 2;
                    error.descripcionCorta = "Proceso no completado.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Elimina el registro de Configuración de red.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.ConfRed a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = Datos.Inventarios.ConfRed.Eliminar(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Configuración de red eliminada.";
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
