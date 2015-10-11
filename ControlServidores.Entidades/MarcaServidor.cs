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
