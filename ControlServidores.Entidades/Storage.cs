namespace ControlServidores.Entidades
{
	public class Storage
	{
		public virtual int IdStorage {get;set;}
		
		public virtual Servidor Servidor {get;set;}
		
		public virtual int IdTipoStorage {get;set;}
		
		public virtual string CapacidadAsignada {get;set;}

        public virtual int IdEstatus { get; set; }

        public virtual TipoStorage TipoStorage { get; set; }

        public virtual Estatus Estatus { get; set; }

        public Storage()
        {
            Servidor = new Servidor();
            TipoStorage = new TipoStorage();
            Estatus = new Estatus();
        }
    }
}