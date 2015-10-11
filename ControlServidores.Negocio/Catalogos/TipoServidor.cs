using System.Collections.Generic;
using System.Linq;

namespace ControlServidores.Negocio.Catalogos
{
    public class TipoServidor
    {

        /// <summary>
        /// Obtiene registros de TipoServidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.TipoServidor></returns>
        public static List<Entidades.TipoServidor> Obtener(Entidades.TipoServidor a)
        {
            return Datos.Catalogos.TipoServidor.Obtener(a);
        }

        /// <summary>
        /// Nuevo registro en TipoServidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.TipoServidor></returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.TipoServidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.TipoServidor> tipoSeL = new List<Entidades.TipoServidor>();
            tipoSeL = Datos.Catalogos.TipoServidor.Obtener(new Entidades.TipoServidor() { Tipo = a.Tipo });
            if( tipoSeL.Count > 0 )
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe un tipo de memoria con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.TipoServidor.Nuevo(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Tipo de memoria almacenado correctamente.";
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
        /// Actualiza un registro en TipoServidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualiza(Entidades.TipoServidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.TipoServidor> tipoSeL = new List<Entidades.TipoServidor>();
            tipoSeL = Datos.Catalogos.TipoServidor.Obtener(new Entidades.TipoServidor() { Tipo = a.Tipo });
            var validarDatos = from l in tipoSeL
                               where l.IdTipoServidor != a.IdTipoServidor
                               select l;
            tipoSeL = validarDatos.ToList();
            if (tipoSeL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe un tipo de memoria con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.TipoServidor.Actualizar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Tipo de memoria actualizada correctamente.";
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
        /// Elimina un registro en TipoServidor.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.TipoServidor a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Servidor> servL = new List<Entidades.Servidor>();
            servL = Datos.Inventarios.Servidor.Obtener(new Entidades.Servidor() { TipoServidor = new Entidades.TipoServidor() { IdTipoServidor = a.IdTipoServidor } });
            if(servL.Count > 0)
            {
                resultado.resultado = true;
                error = new Entidades.Logica.Error();
                error.idError = 0;
                error.descripcionCorta = "Hay servidores que son de este tipo, no se puede eliminar.";
                resultado.errores.Add(error);
            }

            if( resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.TipoServidor.Eliminar(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Tipo de servidor eliminado.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Proceso no completado";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }
    }
}
