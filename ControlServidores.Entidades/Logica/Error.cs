using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlServidores.Entidades.Logica
{
    public class Error
    {
        /// <summary>
        /// Id del error.
        /// </summary>
        public int idError { get; set; }

        /// <summary>
        /// Descripción corta del error.
        /// </summary>
        public string descripcionCorta { get; set; }

        /// <summary>
        /// Descripción larga del error.
        /// </summary>
        public string descripcionLarga { get; set; }
    }
}
