namespace ControlServidores.Entidades
{
	public class MenuXrol
	{
		public  virtual int Id {get;set;}

        //public virtual int IdMenu {get;set;}
        public virtual Menu IdMenu { get; set; }

        //public virtual int IdRol {get;set;}
        public virtual RolUsuario IdRol { get; set; }

        public MenuXrol()
        {
            IdMenu = new Menu();
            IdRol = new RolUsuario();
        }
    }
}