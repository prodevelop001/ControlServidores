using System.Collections.Generic;

namespace ControlServidores.Entidades
{
    public class Servidor
    {
        public virtual int IdServidor { get; set; }

        public virtual string AliasServidor { get; set; }

        public virtual int IdModelo { get; set; }

        public virtual int IdEspecificacion { get; set; }

        public virtual int IdTipoServidor { get; set; }

        public virtual int IdVirtualizador { get; set; }

        public virtual string DescripcionUso { get; set; }

        public virtual int IdEstatus { get; set; }

        public virtual Modelo Modelo { get; set; }

        public virtual EspServidor Especificacion { get; set; }

        public virtual TipoServidor TipoServidor { get; set; }

        public virtual ISet<ConfRed> Red { get; set; }

        public virtual ISet<SOxServidor> SOxServidor { get; set; }

        public virtual ISet<PersonaXservidor> PersonaXservidor { get; set; }

        public virtual ISet<Storage> Storage { get; set; }

        public Servidor()
        {
            Modelo = new Modelo();
            Especificacion = new EspServidor();
            TipoServidor = new TipoServidor();
        }       
    }
}