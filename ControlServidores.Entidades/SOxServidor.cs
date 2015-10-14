namespace ControlServidores.Entidades
{
	public class SOxServidor
	{
		public virtual int IdSOxServidor {get;set;}
		
		public virtual int IdServidor {get;set;}
		
		public virtual int IdSO {get;set;}

        public virtual int IdEstatus { get; set; }

        public virtual Servidor Servidor { get; set; }

        public virtual SO SO { get; set; }

        public virtual Estatus Estatus { get; set; }

        public SOxServidor()
        {
            Servidor = new Servidor();
            SO = new SO();
            Estatus = new Estatus();
        }
	}
}