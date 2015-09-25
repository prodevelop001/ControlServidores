using System.Collections.Generic;

namespace ControlServidores.Negocio.Seguridad
{
    public class Menu
    {
        public static List<Entidades.Menu> Obtener(Entidades.Menu a)
        {
            return Datos.Seguridad.Menu.obtener(a);
        }
    }
}
