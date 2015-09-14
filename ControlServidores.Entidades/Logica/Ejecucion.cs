using System.Collections.Generic;

namespace ControlServidores.Entidades.Logica
{
    public class Ejecucion
    {
        /// <summary>
        /// Resultado de la ejecución, True=satisfactorio, False= no satisfactorio
        /// </summary>
        public bool resultado { get; set; }

        /// <summary>
        /// Regresa lista de errores entendibles por una persona
        /// </summary>
        public List<Error> errores { get; set; }

        public Ejecucion()
        {
            errores = new List<Error>();
        }
    }
}
