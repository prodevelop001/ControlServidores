using System;

namespace ControlServidores.Entidades
{
	public class BitacoraMantenimiento
	{
		public virtual int IdBitacora { get; set; }
		
		public virtual DateTime FechaCaptura { get; set; }
		
		public virtual DateTime FechaMantenimiento { get; set; }
		
		public virtual string DescripcionMantenimiento { get; set; }
		
		public virtual string Observaciones { get; set; }
		
		public virtual string fchCaptura_ini {get;set;}
		
		public virtual string fchCaptura_fin {get;set;}
		
		public virtual string fchMantenimiento_ini {get;set;}
		
		public virtual string fchMantenimiento_fin {get;set;}
	}
}