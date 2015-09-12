namespace ControlServidores.Entidades
{
	public class Almacenamiento
	{
			public virtual int IdAlmacenamiento { get; set; }
			
			public virtual int IdServidor { get; set; }
			
			public virtual int IdTipoMemoria { get; set; }
			
			public virtual string Capacidad { get; set; }
	}
}