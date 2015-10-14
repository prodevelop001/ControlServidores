using System.Collections.Generic;

namespace ControlServidores.Entidades
{
	public class Empresa
	{
		public virtual int IdEmpresa {get;set;}
		
		public virtual string Nombre {get;set;}
		
		public virtual string Telefono {get;set;}
		
		public virtual string Direccion {get;set;}

        public virtual ISet<Soporte> Soporte { get; set; }
	}
}