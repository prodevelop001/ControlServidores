using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlServidores.Negocio.Catalogos
{
    public class TipoStorage
    {
        /// <summary>
        /// Obtiene registros de TipoStorage.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.TipoStorage></returns>
        public static List<Entidades.TipoStorage> Obtener(Entidades.TipoStorage a)
        {
            return Datos.Catalogos.TipoStorage.Obtener(a);
        }

        /// <summary>
        /// Nuevo registro en TipoStorage
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.TipoStorage a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error = new Entidades.Logica.Error();

            resultado.resultado = true;

            List<Entidades.TipoStorage> storageL = new List<Entidades.TipoStorage>();
            storageL = Datos.Catalogos.TipoStorage.Obtener(new Entidades.TipoStorage() { Tipo = a.Tipo });
            if (storageL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe un Tipo de storage con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.TipoStorage.Nuevo(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Tipo de storage almacenado correctamente.";
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
        /// Actualiza un registro en TipoStorage.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.TipoStorage a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error = new Entidades.Logica.Error();

            resultado.resultado = true;

            List<Entidades.TipoStorage> storageL = new List<Entidades.TipoStorage>();
            storageL = Datos.Catalogos.TipoStorage.Obtener(new Entidades.TipoStorage() { Tipo = a.Tipo });
            var validarDatos = from l in storageL
                               where l.IdTipoStorage != a.IdTipoStorage
                               select l;
            storageL = validarDatos.ToList();
            if (storageL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe un Tipo de storage con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.TipoStorage.Actualizar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Tipo de storage actualizado correctamente.";
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
        /// Elimina un registro en TipoStorage.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.TipoStorage a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Storage> storageL = new List<Entidades.Storage>();
            storageL = Datos.Inventarios.Storage.Obtener(new Entidades.Storage() { IdTipoStorage = a.IdTipoStorage });
            if(storageL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Hay servidores con este tipo de storage asingnado, no se puede eliminar.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true )
            {
                resultado.resultado = Datos.Catalogos.TipoStorage.Eliminar(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Tipo de storage eliminado.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Proceso no completado.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }
    }
}
