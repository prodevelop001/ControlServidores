using System.Collections.Generic;
using System.Linq;

namespace ControlServidores.Negocio.Seguridad
{
    public class RolUsuario
    {
        /// <summary>
        /// Obtiene todos los roles que estan en el sistema.
        /// </summary>
        /// <param name="a"></param>
        /// <returns> List<Entidades.RolUsuario></returns>
        public static List<Entidades.RolUsuario> Obtener(Entidades.RolUsuario a)
        {
            return Datos.Seguridad.RolUsuario.Obtener(a);
        }

        /// <summary>
        /// Método para agregar un Rol.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="mrL"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Nuevo(Entidades.RolUsuario r, List<Entidades.MenuXrol> mrL)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            List<Entidades.RolUsuario> RolLista = new List<Entidades.RolUsuario>();
            RolLista = Datos.Seguridad.RolUsuario.Obtener(new Entidades.RolUsuario() { NombreRol = r.NombreRol });

            if (RolLista.Count == 0)
            {
                resultado.resultado = Datos.Seguridad.RolUsuario.Nuevo(r);
                if (resultado.resultado == true)
                {
                    RolLista = Datos.Seguridad.RolUsuario.Obtener(new Entidades.RolUsuario() { NombreRol = r.NombreRol });

                    mrL.ForEach(delegate (Entidades.MenuXrol mr)
                    {
                        mr.IdRol.IdRol = RolLista.FirstOrDefault().IdRol;
                    });

                    resultado.resultado = Datos.Seguridad.MenuXrol.Nuevo(mrL);
                    if (resultado.resultado == true)
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 2;
                        error.descripcionCorta = "Rol almacenado correctamente.";
                        resultado.errores.Add(error);
                    }
                    else
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 4;
                        error.descripcionCorta = "No hay menu almacenado para este rol, proceso no compeltado correctamente.";
                        resultado.errores.Add(error);
                    }
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 3;
                    error.descripcionCorta = "Proceso no compleato.";
                    resultado.errores.Add(error);
                }
            }
            else
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Ya existe un rol con el mismo nombre.";
                resultado.errores.Add(error);
            }

            return resultado;
        }

        /// <summary>
        /// Método para actualizar un rol.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="mrL"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Actualizar(Entidades.RolUsuario a, List<Entidades.MenuXrol> mrL)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            List<Entidades.RolUsuario> RolLista = new List<Entidades.RolUsuario>();
            RolLista = Datos.Seguridad.RolUsuario.Obtener(new Entidades.RolUsuario() { NombreRol = a.NombreRol });

            var validarNombre = from l in RolLista
                                where l.IdRol != a.IdRol
                                select l;
            RolLista = validarNombre.ToList();
            if (RolLista.Count == 0)
            {
                resultado.resultado = Datos.Seguridad.RolUsuario.Actualizar(a);
                if (resultado.resultado == true)
                {

                    error = new Entidades.Logica.Error();
                    error.idError = 1;
                    error.descripcionCorta = "Rol actualizado correctamente.";
                    resultado.errores.Add(error);

                    List<Entidades.MenuXrol> _mrL = new List<Entidades.MenuXrol>();
                    _mrL = Datos.Seguridad.MenuXrol.Obtener(new Entidades.MenuXrol() { IdRol = new Entidades.RolUsuario() { IdRol = a.IdRol } });

                    if (_mrL.Count > 0)
                    {
                        resultado.resultado = Datos.Seguridad.MenuXrol.Eliminar(_mrL);
                    }

                    resultado.resultado = Datos.Seguridad.MenuXrol.Nuevo(mrL);
                    if (resultado.resultado == true)
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 2;
                        error.descripcionCorta = "Menus actualizados correctamente.";
                        resultado.errores.Add(error);
                    }
                    else
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 3;
                        error.descripcionCorta = "Menus no actualizados, proceso no se completo correctamente.";
                        resultado.errores.Add(error);
                    }

                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 2;
                    error.descripcionCorta = "No se realizo actualización de rol, proceso no ejecutado correctamente.";
                    resultado.errores.Add(error);
                }
            }
            return resultado;
        }

        /// <summary>
        /// Método para borrar un rol.
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Entidades.Logica.Ejecucion</returns>
        public static Entidades.Logica.Ejecucion Borrar(Entidades.RolUsuario a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            List<Entidades.Usuarios> usuariosL = new List<Entidades.Usuarios>();
            Entidades.Usuarios us = new Entidades.Usuarios();
            us.IdRol.IdRol = a.IdRol;
            usuariosL = Datos.Seguridad.Usuarios.Obtener(us);
            if (usuariosL.Count == 0)
            {
                List<Entidades.MenuXrol> _mrL = new List<Entidades.MenuXrol>();
                _mrL = Datos.Seguridad.MenuXrol.Obtener(new Entidades.MenuXrol() { IdRol = new Entidades.RolUsuario() { IdRol = a.IdRol } });
                resultado.resultado = Datos.Seguridad.MenuXrol.Eliminar(_mrL);
                if (resultado.resultado == true)
                {

                    error = new Entidades.Logica.Error();
                    error.idError = 3;
                    error.descripcionCorta = "Asignación de menus al rol han sido eliminados.";
                    resultado.errores.Add(error);

                    resultado.resultado = Datos.Seguridad.RolUsuario.Eliminar(a);
                    if (resultado.resultado == true)
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 2;
                        error.descripcionCorta = "Rol eliminado.";
                        resultado.errores.Add(error);
                    }
                    else
                    {
                        error = new Entidades.Logica.Error();
                        error.idError = 3;
                        error.descripcionCorta = "Rol no eliminado. Proceso no se completo correctamente.";
                        resultado.errores.Add(error);
                    }
                }
                else
                {
                    error = new Entidades.Logica.Error();
                    error.idError = 4;
                    error.descripcionCorta = "Asignación de menus al rol han sido eliminados.";
                    resultado.errores.Add(error);
                }
            }
            else
            {
                error = new Entidades.Logica.Error();
                error.idError = 1;
                error.descripcionCorta = "Hay usuarios con este rol asignado. Rol no ha sido eliminado.";
                resultado.errores.Add(error);
            }

            return resultado;
        }
    }
}
