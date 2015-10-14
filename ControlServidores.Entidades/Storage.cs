namespace ControlServidores.Entidades
{
	public class Storage
	{
		public virtual int IdStorage {get;set;}
		
		public virtual int IdServidor {get;set;}
		
		public virtual int IdTipoStorage {get;set;}
		
		public virtual string CapacidadAsignada {get;set;}

        public virtual int IdEstatus { get; set; }

        public virtual TipoStorage TipoStorage { get; set; }

        public virtual Estatus Estatus { get; set; }

        public Storage()
        {
            TipoStorage = new TipoStorage();
            Estatus = new Estatus();
        }
    }
}