using System.Collections.Generic;

namespace ControlServidores.Negocio.Inventarios
{
    public class EspServidor
    {
        /// <summary>
        /// Obtiene registros de EspServidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.Almacenamiento></returns>
        public static List<Entidades.EspServidor> Obtener(Entidades.EspServidor a)
        {
            return Datos.Inventarios.EspServidor.Obtener(a);
        }

        /// <summary>
        /// Registra un nueva EspServidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.EspServidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = Datos.Inventarios.EspServidor.Nuevo(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Especificación registrada correctamente.";
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
        /// Actualiza un registro de Configuración de red.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.EspServidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = Datos.Inventarios.EspServidor.Actualizar(a);
            if (resultado.resultado == true)
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Especificación actualizada correctamente.";
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
        /// Elimina el registro de Configuración de red.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.EspServidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Servidor> servL = new List<Entidades.Servidor>();
            servL = Datos.Inventarios.Servidor.Obtener(new Entidades.Servidor() { Especificacion=new Entidades.EspServidor() { IdEspecificacion = a.IdEspecificacion } });
            if(servL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Esta especificación esta asignada a al servidor, no puede eliminarse.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Inventarios.EspServidor.Eliminar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Especificación eliminada.";
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
    }
}
