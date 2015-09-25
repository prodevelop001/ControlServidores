using System.Collections.Generic;

namespace ControlServidores.Entidades
{
    public class Menu
    {
        public virtual int IdMenu { get; set; }

        public virtual string Nombre { get; set; }

        public virtual string Url { get; set; }

        public virtual int Nodo { get; set; }

        public virtual int Orden { get; set; }

        public virtual int Sesion { get; set; }

        public virtual ISet<MenuXrol> MenuXrol { get; set; }
    }
}
