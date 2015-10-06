using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace ControlServidores.Negocio.Seguridad
{
    public class Usuarios
    {
        /// <summary>
        /// Obtiene a los usuarios que estan registrados.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>List<Entidades.Usuarios></returns>
        public static List<Entidades.Usuarios> Obtener(Entidades.Usuarios a)
        {
            return Datos.Seguridad.Usuarios.Obtener(a);
        }

        /// <summary>
        /// Nuevo usuario para el sistema.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.Usuarios a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Usuarios> userL = new List<Entidades.Usuarios>();
            userL = Datos.Seguridad.Usuarios.Obtener(new Entidades.Usuarios() { IdPersona = a.IdPersona });
            if (userL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 2;
                error.descripcionCorta = "Ya existe un usuario asignado para esta persona.";
                resultado.errores.Add(error);
            }
            userL = Datos.Seguridad.Usuarios.Obtener(new Entidades.Usuarios() { Usuario = a.Usuario });
            if (userL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 2;
                error.descripcionCorta = "Ya existe un usuario con el mismo alias.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                if (a.IdPersona.IdPersona == -1)
                {
                    a.IdPersona = null;
                }
                resultado.resultado = Datos.Seguridad.Usuarios.nuevo(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Usuario almacenado correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Proceso no completado correctamente.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Actualiza a un usuario.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.Usuarios a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Usuarios> userL = new List<Entidades.Usuarios>();
            userL = Datos.Seguridad.Usuarios.Obtener(new Entidades.Usuarios() { IdPersona = a.IdPersona });
            var validarDatos = from l in userL
                               where l.IdUsuario != a.IdUsuario
                               select l;
            userL = validarDatos.ToList();
            if (userL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 2;
                error.descripcionCorta = "Ya existe un usuario asignado para esta persona.";
                resultado.errores.Add(error);
            }
            userL = Datos.Seguridad.Usuarios.Obtener(new Entidades.Usuarios() { Usuario = a.Usuario });
            validarDatos = from l in userL
                           where l.IdUsuario != a.IdUsuario
                           select l;
            userL = validarDatos.ToList();
            if (userL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 2;
                error.descripcionCorta = "Ya existe un usuario con el mismo alias.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                if (a.IdPersona.IdPersona == -1)
                {
                    a.IdPersona = null;
                }
                resultado.resultado = Datos.Seguridad.Usuarios.actualizar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Usuario actualizado correctamente.";
                    resultado.errores.Add(error);
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Proceso no completado correctamente.";
                    resultado.errores.Add(error);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Elimina un usuario del sistema.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Eliminar(Entidades.Usuarios a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;
            resultado.resultado = true;
            string usuarioPrincipal = ConfigurationManager.AppSettings["UsuarioPrincipal"] ?? string.Empty;

            List<Entidades.Usuarios> userL = new List<Entidades.Usuarios>();
            userL = Datos.Seguridad.Usuarios.Obtener(a);

            if (userL.FirstOrDefault().Usuario == usuarioPrincipal)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 2;
                error.descripcionCorta = "Este usuario no puede ser eliminado.";
                resultado.errores.Add(error);
            }

            if (resultado.resultado == true)
            {
                resultado.resultado = Datos.Seguridad.Usuarios.eliminar(a);
                if (resultado.resultado == true)
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Usuario eliminado satisfactoriamente.";
                    resultado.errores.Add(error);
                }
            }
            return resultado;
        }

    }
}
