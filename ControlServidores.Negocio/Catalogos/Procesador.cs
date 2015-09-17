using System.Collections.Generic;
using System.Linq;

namespace ControlServidores.Negocio.Catalogos
{
    public class Procesador
    {
        /// <summary>
        /// Obtiene los registros de Procesador.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.Procesador></returns>
        public static List<Entidades.Procesador> Obtener(Entidades.Procesador a)
        {
            return Datos.Catalogos.Procesador.Obtener(a);
        }

        /// <summary>
        /// Nuevo registro en Procesador.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.Procesador a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Procesador> procesadorL = new List<Entidades.Procesador>();
            procesadorL = Datos.Catalogos.Procesador.Obtener(new Entidades.Procesador() { Nombre = a.Nombre });
            if (procesadorL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe un procesador con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.Procesador.Nuevo(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Procesador almacenado correctamente.";
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
        /// Actualiza un registo en Procesador.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.Procesador a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Procesador> procesadorL = new List<Entidades.Procesador>();
            procesadorL = Datos.Catalogos.Procesador.Obtener(new Entidades.Procesador() { Nombre = a.Nombre });
            var validarDatos = from l in procesadorL
                               where l.IdProcesador != a.IdProcesador
                               select l;
            procesadorL = validarDatos.ToList();
            if (procesadorL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe un procesador con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.Procesador.Nuevo(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Procesador almacenado correctamente.";
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
        /// Elimina un registro en Procesador.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.Procesador a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.EspServidor> especificacionL = new List<Entidades.EspServidor>();
            especificacionL = Datos.Inventarios.EspServidor.Obtener(new Entidades.EspServidor() { IdProcesador = a.IdProcesador });
            if(especificacionL.Count >  0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 0;
                error.descripcionCorta = "Existen especificacines de servidor con este procesador, no puede eliminarse.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.Procesador.Eliminar(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 0;
                    error.descripcionCorta = "Procesador eliminado correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 0;
                    error.descripcionCorta = "Proceso no completado.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }
    }
}
