using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlServidores.Entidades
{
    public class MarcaServidor
    {
        /// <summary>
        /// Id de la marca. Llave primaria.
        /// </summary>
        public virtual int IdMarca { get; set; }

        /// <summary>
        /// Nombre de la marca.
        /// </summary>
        public virtual string NombreMarca { get; set; }
    }
}
