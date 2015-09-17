﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlServidores.Negocio.Seguridad
{
    public class Seguridad
    {
        /// <summary>
        /// Inicia sesion en el sistema.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public bool iniciarSesion(Entidades.Usuarios usuario)
        {
            Entidades.Usuarios usuarioDatos = new Entidades.Usuarios();

            List<Entidades.Usuarios> usuarios = Datos.Seguridad.Usuarios.Obtener(usuario);
            usuario = usuarios.FirstOrDefault();

            //Si los datos de logeo son correctos, se inicia sesión
            HttpContext context = HttpContext.Current;
            if (usuarios.Count() > 0)
            {
                context.Session["usuario"] = usuario;
                return true;
            }
            else
            {
                context.Session["usuario"] = null;
                return false;
            }
        }

        /// <summary>
        /// Desturye las variables de sesion y cookies.
        /// </summary>
        public void cerrarSesion()
        {
            HttpContext context = HttpContext.Current;
            context.Session.Clear();
            context.Session.Abandon();
            context.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }

        /// <summary>
        /// valida si un usuario tiene acceso a la pagina.
        /// </summary>
        /// <param name="IdPagina"></param>
        /// <returns>bool</returns>
        public static bool AccesoPagina(int IdPagina)
        {
            HttpContext context = HttpContext.Current;
            Entidades.Usuarios us = (Entidades.Usuarios)context.Session["usuario"];
            Entidades.MenuXrol menu = new Entidades.MenuXrol()
            {
                IdRol = new Entidades.RolUsuario()
                { IdRol = us.IdRol.IdRol }
               ,
                IdMenu = new Entidades.Menu()
                { IdMenu = IdPagina }
            };

            List<Entidades.MenuXrol> menuL = new List<Entidades.MenuXrol>();
            menuL = Datos.Seguridad.MenuXrol.Obtener(menu);
            if (menuL.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}
