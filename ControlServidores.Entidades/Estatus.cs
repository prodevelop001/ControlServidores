using System.Collections.Generic;

namespace ControlServidores.Entidades
{
    public class Estatus
	{
		public virtual int IdEstatus {get;set;}
		
		public virtual int IdConceptoEstatus {get;set;}
		
		public virtual string _Estatus {get;set;}

        public virtual ISet<ConfRed> ConfRed { get; set; }

        public virtual ISet<SOxServidor> SOxServidor { get; set; }

        public virtual ISet<Personas> Persona { get; set; }
    }
}