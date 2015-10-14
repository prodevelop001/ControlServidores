using System.Collections.Generic;
using System.Linq;

namespace ControlServidores.Negocio.Catalogos
{
    public class TipoArregloDisco
    {
        /// <summary>
        /// Obtiene registros de TipoArregloDisco
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.TipoArregloDisco></returns>
        public static List<Entidades.TipoArregloDisco> Obtener(Entidades.TipoArregloDisco a)
        {
            return Datos.Catalogos.TipoArregloDisco.Obtener(a);
        }

        /// <summary>
        /// Nuevo registro en TipoArregloDisco.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.TipoArregloDisco a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.TipoArregloDisco> tiposL = new List<Entidades.TipoArregloDisco>();
            tiposL = Datos.Catalogos.TipoArregloDisco.Obtener(new Entidades.TipoArregloDisco() { Tipo = a.Tipo });
            if (tiposL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 0;
                error.descripcionCorta = "Este tipo de disco ya esta registrado.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.TipoArregloDisco.Nuevo(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Tipo de disco almacenado correctamente.";
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

            return  resultado;
        }

        /// <summary>
        /// Actualiza un registo en TipoArregloDisco.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.TipoArregloDisco a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.TipoArregloDisco> tiposL = new List<Entidades.TipoArregloDisco>();
            tiposL = Datos.Catalogos.TipoArregloDisco.Obtener(new Entidades.TipoArregloDisco() { Tipo = a.Tipo });
            var validarDatos = from l in tiposL
                               where l.IdTipoArreglo == a.IdTipoArreglo
                               select l;
            tiposL = validarDatos.ToList();
            if (tiposL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 0;
                error.descripcionCorta = "Este tipo de disco ya esta registrado.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.TipoArregloDisco.Actualizar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Tipo de disco actualizado correctamente.";
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
        /// Elimina un registro de TipoArregloDisco
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.TipoArregloDisco a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.EspServidor> especificacionL = new List<Entidades.EspServidor>();
            especificacionL = Datos.Inventarios.EspServidor.Obtener(new Entidades.EspServidor() { IdTipoArreglo = a.IdTipoArreglo });
 
            if(especificacionL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 0;
                error.descripcionCorta = "Hay servidores con este tipo de arreglo de disco.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.TipoArregloDisco.Eliminar(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 0;
                    error.descripcionCorta = "Tipo de arreglo eliminado.";
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
