namespace ControlServidores.Entidades
{
	public class RolUsuario
	{
		public virtual int IdRol {get;set;}
		
		public virtual string NombreRol {get;set;}
		
		public virtual bool C {get;set;}
		
		public virtual bool R {get;set;}
		
		public virtual bool U {get;set;}
		
		public virtual bool D {get;set;}
	}
}