namespace ControlServidores.Entidades
{
	public class EspServidor
	{
		public virtual int IdEspecificacion {get;set;}
		
		public virtual int IdProcesador {get; set; }
		
		public virtual int NumProcesadores {get;set;}
		
		public virtual string CapacidadRam {get;set;}
		
		public virtual int IdTipoArreglo {get; set;}
		
		public virtual string NumSerie {get; set;}
	}
}