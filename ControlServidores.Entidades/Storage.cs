namespace ControlServidores.Entidades
{
	public class Storage
	{
		public virtual int IdStorage {get;set;}
		
		public virtual int IdServidor {get;set;}
		
		public virtual int IdTipoStorage {get;set;}
		
		public virtual string CapacidadAsignada {get;set;}
	}
}