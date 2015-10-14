using System.Collections.Generic;

namespace ControlServidores.Entidades
{
	public class Procesador
	{
		public virtual int IdProcesador {get;set;}
		
		public virtual string Nombre {get;set;}
		
		public virtual int NumCores {get;set;}
		
		public virtual string Velocidad {get;set;}
		
		public virtual string Cache {get;set;}
		
		public virtual string TamanoPalabra {get;set;}

        public virtual ISet<EspServidor> Especificacion { get; set; }
    }
}