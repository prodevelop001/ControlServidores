using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlServidores.Negocio.Catalogos
{
    public class TipoMemoria
    {
        /// <summary>
        /// Obtiene registros de TipoMemoria.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.TipoMemoria></returns>
        public static List<Entidades.TipoMemoria> Obtener(Entidades.TipoMemoria a)
        {
            return Datos.Catalogos.TipoMemoria.Obtener(a);
        }

        /// <summary>
        /// Nuevo registro en TipoMemoria.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Nuevo (Entidades.TipoMemoria a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.TipoMemoria> tipomL = new List<Entidades.TipoMemoria>();
            tipomL = Datos.Catalogos.TipoMemoria.Obtener(new Entidades.TipoMemoria() { Tipo = a.Tipo });
            if(tipomL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe un tipo de memoria con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.TipoMemoria.Nuevo(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Tipo de memoria almacenada correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 2;
                    error.descripcionCorta = "Proceso no cmpletado.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Actualiza un registro en TipoMemoria
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.TipoMemoria a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.TipoMemoria> tipomL = new List<Entidades.TipoMemoria>();
            tipomL = Datos.Catalogos.TipoMemoria.Obtener(new Entidades.TipoMemoria() { Tipo = a.Tipo });
            var validarDatos = from l in tipomL
                               where l.IdTipoMemoria != a.IdTipoMemoria
                               select l;
            tipomL = validarDatos.ToList();
            if (tipomL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe un tipo de memoria con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.TipoMemoria.Actualizar(a);
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
                    error.descripcionCorta = "Proceso no cmpletado.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Elimina un registro en TipoMemoria.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.TipoMemoria a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Almacenamiento> almacenamientoL = new List<Entidades.Almacenamiento>();
            almacenamientoL = Datos.Inventarios.Almacenamiento.Obtener(new Entidades.Almacenamiento() { IdTipoMemoria = a.IdTipoMemoria });
            if(almacenamientoL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Hay seridores con este tipo de almacenamiento, no se puede eliminar.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.TipoMemoria.Actualizar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Tipo de almacenamiento guardado corectamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 3;
                    error.descripcionCorta = "Proceso no completado.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }
    }
}
