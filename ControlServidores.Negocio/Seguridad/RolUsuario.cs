using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlServidores.Datos;


namespace ControlServidores.Negocio.Seguridad
{
    public class RolUsuario
    {
        public static List<Entidades.RolUsuario> Obtener(Entidades.RolUsuario a)
        {
            return Datos.Seguridad.RolUsuario.Obtener(a);
        }

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

        public static Entidades.Logica.Ejecucion Actualizar(Entidades.RolUsuario a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            List<Entidades.MenuXrol> mrL = new List<Entidades.MenuXrol>();
            mrL = Datos.Seguridad.MenuXrol.Obtener(new Entidades.MenuXrol() { IdRol = new Entidades.RolUsuario() { IdRol = a.IdRol } });


            return resultado;
        }
    }
}
