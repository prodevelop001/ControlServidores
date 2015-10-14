namespace ControlServidores.Entidades
{
    public class Almacenamiento
    {
        public virtual int IdAlmacenamiento { get; set; }

        public virtual int IdServidor { get; set; }

        public virtual string Unidad { get; set; }

        public virtual int IdTipoMemoria { get; set; }

        public virtual string Capacidad { get; set; }

        public virtual int IdEstatus { get; set; }

        public virtual TipoMemoria TipoMemoria { get; set; }

        public Almacenamiento()
        {
            TipoMemoria = new TipoMemoria();
        }
    }
}