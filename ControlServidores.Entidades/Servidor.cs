namespace ControlServidores.Entidades
{
	public class Servidor
	{
		public virtual int IdServidor {get;set;}
		
		public virtual string AliasServidor {get;set;}
		
		public virtual int IdModelo {get;set;}
		
		public virtual int  IdEspecificacion {get;set;}
		
		public virtual int IdTipoServidor {get;set;}
		
		public virtual int IdVirtualizador {get;set;}
		
		public virtual string DescripcionUso {get;set;}
	}
}