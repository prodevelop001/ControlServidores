

using System.Collections.Generic;

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

        public virtual ISet<MenuXrol> MenuXrol { get; set; }

        public virtual ISet<Usuarios> Usuarios { get; set; }
    }
}