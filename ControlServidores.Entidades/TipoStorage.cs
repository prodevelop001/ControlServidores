using System.Collections.Generic;

namespace ControlServidores.Entidades
{
	public class TipoStorage
	{
		public virtual int IdTipoStorage {get;set;}
		
		public virtual string Tipo {get;set;}

        public virtual ISet<Storage> Storage { get; set; }
	}
}