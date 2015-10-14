namespace ControlServidores.Entidades
{
    public class PersonaXservidor
    {
        public virtual int IdPersonaServidor { get; set; }

        public virtual int IdPersona { get; set; }

        public virtual int IdServidor { get; set; }

        public virtual int IdBitacora { get; set; }

        public virtual Personas Personas {get;set;}

        public virtual Servidor Servidor { get; set; }

        public virtual BitacoraMantenimiento Bitacora { get; set; }

        public PersonaXservidor()
        {
            Personas = new Personas();
            Servidor = new Servidor();
            Bitacora = new BitacoraMantenimiento();
        }
	}
}