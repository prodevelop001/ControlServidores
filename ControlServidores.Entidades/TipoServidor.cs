using System.Collections.Generic;

namespace ControlServidores.Entidades
{
	public class TipoServidor
	{
		public virtual int IdTipoServidor {get;set;}
		
		public virtual string Tipo {get;set;}
		
		public virtual string Descripcion {get;set;}

        public virtual ISet<Servidor> Servidor { get; set; }
    }
}