using System.Collections.Generic;
using System.Linq;

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
            resultado.resultado = true;
            List<Entidades.Soporte> sop = new List<Entidades.Soporte>();
            sop = Datos.Inventarios.Soporte.Obtener(new Entidades.Soporte()
            {
                Modelo = new Entidades.Modelo() { IdModelo = a.Modelo.IdModelo },
                Empresa = null
            });
            if(sop.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Este modelo ya tiene soporte.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            { 
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
            resultado.resultado = true;
            List<Entidades.Soporte> sop = new List<Entidades.Soporte>();
            sop = Datos.Inventarios.Soporte.Obtener(new Entidades.Soporte()
            {
                Modelo = new Entidades.Modelo() { IdModelo = a.Modelo.IdModelo },
                Empresa = null
            });
            var dis = from s in sop
                      where s.IdSoporte != a.IdSoporte
                      select s;
            sop = dis.ToList();
            if (sop.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Este modelo ya tiene soporte.";
                resultado.errores.Add(error);
            }
            if (resultado.resultado == true)
            {
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
