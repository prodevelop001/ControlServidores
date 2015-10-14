using System.Collections.Generic;

namespace ControlServidores.Entidades
{
    public class TipoArregloDisco
    {
        public virtual int IdTipoArreglo { get; set; }

        public virtual string Tipo { get; set; }

        public virtual string Descripcion { get; set; }
        
        public virtual ISet<EspServidor> Especificacion{ get; set; }
    }
}