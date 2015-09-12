using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlServidores.Entidades
{
    public class Menu
    {
        public virtual int IdMenu { get; set; }

        public virtual string Nombre { get; set; }

        public virtual string Url { get; set; }

        public virtual int NODO { get; set; }

        public virtual int Orden { get; set; }

        public virtual bool Sesion { get; set; }
    }
}
