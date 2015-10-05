using System.Collections.Generic;

namespace ControlServidores.Negocio.Seguridad
{
    public class MenuXrol
    {
        public static List<Entidades.MenuXrol> Obtener(Entidades.MenuXrol a)
        {
            return Datos.Seguridad.MenuXrol.Obtener(a);
        }
    }
}
