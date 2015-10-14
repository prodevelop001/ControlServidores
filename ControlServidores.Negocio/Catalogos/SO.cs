using System.Collections.Generic;
using System.Linq;

namespace ControlServidores.Negocio.Catalogos
{
    public class SO
    {
        /// <summary>
        /// Obtiene registros de SO.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.SO></returns>
        public static List<Entidades.SO> Obtener(Entidades.SO a)
        {
            return Datos.Catalogos.SO.Obtener(a);
        }

        /// <summary>
        /// Nuevo registro en SO.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.SO a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.SO> soL = new List<Entidades.SO>();
            soL = Datos.Catalogos.SO.Obtener(new Entidades.SO() { NombreSO = a.NombreSO });
            if (soL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe un SO con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.SO.Nuevo(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "SO almacenado correctamente.";
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
        /// Actualiza un registro en SO.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.SO a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.SO> soL = new List<Entidades.SO>();
            soL = Datos.Catalogos.SO.Obtener(new Entidades.SO() { NombreSO = a.NombreSO });
            var validarDatos = from l in soL
                               where l.IdSO != a.IdSO
                               select l;
            soL = validarDatos.ToList();
            if (soL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe un SO con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.SO.Actualizar(a);
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
            }

            return resultado;
        }

        /// <summary>
        /// Elimina un registo de SO.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.SO a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.SOxServidor> soSerL = new List<Entidades.SOxServidor>();
            soSerL = Datos.Inventarios.SOxServidor.Obtener(new Entidades.SOxServidor() { IdSO = a.IdSO });
            if(soSerL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 0;
                error.descripcionCorta = "Hay servidores que tienen este SO, no se puede eliminar.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.SO.Eliminar(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 0;
                    error.descripcionCorta = "SO eliminado.";
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
