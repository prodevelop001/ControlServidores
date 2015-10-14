using System.Collections.Generic;

namespace ControlServidores.Entidades
{
	public class Modelo
	{
		public virtual int IdModelo {get;set;}
		
		public virtual int IdMarca {get;set;}
		
		public virtual string NombreModelo {get;set;}

        public virtual ISet<Servidor> Servidor { get; set; }

        public virtual ISet<Soporte> Soporte { get; set; }
    }
}