using System.Collections.Generic;

namespace ControlServidores.Negocio.Catalogos
{
    public class MarcaServidor
    {
        /// <summary>
        /// Obtiene el o los registros de las marcas de los servidores que se utilizan.
        /// </summary>
        /// <param name="ms"></param>
        /// <returns>Lista</returns>
        public static List<Entidades.MarcaServidor> obtenerMarcaServidor(Entidades.MarcaServidor ms)
        {
            return Datos.Catalogos.MarcaServidor.obtenerMarcaServidor(ms);
        }
    }
}
