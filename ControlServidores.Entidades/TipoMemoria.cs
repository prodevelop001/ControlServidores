using System.Collections.Generic;

namespace ControlServidores.Entidades
{
	public class TipoMemoria
	{
		public virtual int IdTipoMemoria {get;set;}
		
		public virtual string Tipo {get;set;}

        public virtual ISet<Almacenamiento> Almacenamiento { get; set; }
    }
}