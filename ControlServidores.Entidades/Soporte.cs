using System;

namespace ControlServidores.Entidades
{
	public class Soporte
	{
		public virtual int IdSoporte {get;set;}
		
		public virtual int IdEmpresa {get;set;}
		
		public virtual int IdModelo {get;set;}
		
		public virtual DateTime? FechaInicio {get;set;}
		
		public virtual DateTime? FechaFin {get;set;}

        public virtual Modelo Modelo { get; set; }

        public virtual Empresa Empresa { get; set; }

        public Soporte()
        {
            Modelo = new Modelo();
            Empresa = new Empresa();
        }
	}
}