namespace ControlServidores.Entidades
{
    public class ConfRed
    {
        public virtual int IdConfRed { get; set; }

        public virtual int IdServidor { get; set; }

        public virtual string InterfazRed { get; set; }

        public virtual string DirMac { get; set; }

        public virtual string DirIP { get; set; }

        public virtual string MascaraSubRed { get; set; }

        public virtual string Gateway { get; set; }

        public virtual string DNS { get; set; }

        public virtual string VLAN { get; set; }

        public virtual int IdEstatus {get;set;}
	}
}