using System.Collections.Generic;
using System.Linq;

namespace ControlServidores.Negocio.Catalogos
{
    public class Empresa
    {

        /// <summary>
        /// Obtiene todos los registros de Empresa
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.Empresa></returns>
        public static List<Entidades.Empresa> Obtener(Entidades.Empresa a)
        {
            return Datos.Catalogos.Empresa.Obtener(a);
        }

        /// <summary>
        /// Nuevo registro en Empresa
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.Empresa a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Empresa> empresaL = new List<Entidades.Empresa>();
            empresaL = Datos.Catalogos.Empresa.Obtener(new Entidades.Empresa() { Nombre = a.Nombre });
            if(empresaL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe una empresa cone el mismo nombre.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.Empresa.Nuevo(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Empresa almacenada correctamente.";
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
        /// Actualiza un registo de Empresa.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.Empresa a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Empresa> empresaL = new List<Entidades.Empresa>();
            empresaL = Datos.Catalogos.Empresa.Obtener(new Entidades.Empresa() { Nombre = a.Nombre });
            var validarDatos = from l in empresaL
                               where l.IdEmpresa != a.IdEmpresa
                               select l;
            empresaL = validarDatos.ToList();
            if (empresaL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Ya existe una empresa con el mismo nombre.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.Empresa.Actualizar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Empresa actualizada correctamente.";
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
        /// Elimina un registro de Empresa
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.Empresa a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Soporte> soporteL = new List<Entidades.Soporte>();
            soporteL = Datos.Inventarios.Soporte.Obtener(new Entidades.Soporte() { IdEmpresa = a.IdEmpresa });
            if(soporteL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 3;
                error.descripcionCorta = "Hay marcas con soporte de esta empresa, no se puede eliminar.";
                resultado.errores.Add(error);
            }

            if(resultado.resultado == true)
            {
                resultado.resultado = Datos.Catalogos.Empresa.Eliminar(a);
                if(resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Empresa eliminada correctamente.";
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
