using System.Collections.Generic;

namespace ControlServidores.Entidades
{
	public class SO
	{
		public virtual int IdSO {get;set;}
		
		public virtual string NombreSO {get;set;}

        public virtual ISet<SOxServidor> SOxServidor { get; set; }
    }
}