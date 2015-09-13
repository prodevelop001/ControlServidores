using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
