using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlServidores.Negocio.Seguridad
{
    public class Usuarios
    {
        public static List<Entidades.Usuarios> Obtener(Entidades.Usuarios a)
        {
            return Datos.Seguridad.Usuarios.Obtener(a);
        }

        public static Entidades.Logica.Ejecucion Nuevo(Entidades.Usuarios a)
        {
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Logica.Error error;

            resultado.resultado = true;

            List<Entidades.Usuarios> userL = new List<Entidades.Usuarios>();
            userL = Datos.Seguridad.Usuarios.Obtener(new Entidades.Usuarios() { IdPersona = a.IdPersona });
            if(userL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 2;
                error.descripcionCorta = "Ya existe un usuario asignado para esta persona.";
            }
            userL = Datos.Seguridad.Usuarios.Obtener(new Entidades.Usuarios() { Usuario = a.Usuario});
            if (userL.Count > 0)
            {
                resultado.resultado = false;
                error = new Entidades.Logica.Error();
                error.idError = 2;
                error.descripcionCorta = "Ya existe un usuario con el mismo alias.";
            }

            return resultado;
        }
    }
}
