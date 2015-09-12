﻿using System;

namespace ControlServidores.Entidades
{
    public class Usuarios
    {
        /// <summary>
        /// Id usuario, llave primaria
        /// </summary>
        public virtual int IdUsuario { get; set; }

        /// <summary>
        /// Id de persona
        /// </summary>
        public virtual int IdPersona { get; set; }

        /// <summary>
        /// Usuario
        /// </summary>
        public virtual string Usuario {get;set;}

        /// <summary>
        /// Password
        /// </summary>
        public virtual string Pwd { get; set; }

        /// <summary>
        /// Fecha de ultimo acceso al sistema.
        /// </summary>
        public virtual DateTime FechaUltimoAcceso { get; set; }

        /// <summary>
        /// Id de Rol de usuario.
        /// </summary>
        public virtual int IdRol { get; set; }
    }
}
