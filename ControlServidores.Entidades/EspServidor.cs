using System.Collections.Generic;

namespace ControlServidores.Entidades
{
	public class EspServidor
	{
		public virtual int IdEspecificacion {get;set;}

        public virtual int IdServidor { get; set; }
		
		public virtual int IdProcesador {get; set; }
		
		public virtual int NumProcesadores {get;set;}
		
		public virtual string CapacidadRAM { get;set;}
		
		public virtual int IdTipoArreglo {get; set;}
		
		public virtual string NumSerie {get; set;}

        public virtual ISet<Servidor> Servidor { get; set; }

        public virtual TipoArregloDisco TipoArregloDisco { get; set; }

        public virtual Procesador Procesador { get; set; }

        public EspServidor()
        {
            TipoArregloDisco = new TipoArregloDisco();
            Procesador = new Procesador();
        }
    }
}