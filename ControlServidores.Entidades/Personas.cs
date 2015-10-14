using System.Collections.Generic;

namespace ControlServidores.Entidades
{
	public class Personas
	{
		public virtual int IdPersona {get;set;}
		
		public virtual string Nombre {get;set;}
		
		public virtual string Puesto {get;set;}
		
		public virtual string Extension {get;set;}
		
		public virtual string Correo {get;set;}

        public virtual int IdEstatus { get; set; }

        public virtual ISet<Usuarios> Usuarios { get; set; }

        public virtual ISet<PersonaXservidor> PersonaXservidor { get; set;  }
	}
}