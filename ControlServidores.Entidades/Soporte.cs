using System;

namespace ControlServidores.Entidades
{
	public class Soporte
	{
		public virtual int IdSoporte {get;set;}
		
		public virtual int IdEmpresa {get;set;}
		
		public virtual int IdMarca {get;set;}
		
		public virtual DateTime? FechaInicio {get;set;}
		
		public virtual DateTime? FechaFin {get;set;}
	}
}