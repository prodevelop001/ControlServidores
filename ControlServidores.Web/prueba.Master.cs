using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web
{
    public partial class prueba : System.Web.UI.MasterPage
    {
        HttpContext context = HttpContext.Current;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Entidades.Usuarios usr = (Entidades.Usuarios)context.Session["usuario"];
            lblUsrName.Text = usr.Usuario.ToString();

            /*
            lblUsrName.Text = "Mauro A.";
            */
            Entidades.Usuarios usuario = (Entidades.Usuarios)Session["usuario"];
            int requiereSesion = 1;
            int IdRol;

            IdRol = usuario.IdRol.IdRol;


            List<Entidades.MenuXrol> menus = new List<Entidades.MenuXrol>();
            menus = Negocio.Seguridad.MenuXrol.Obtener(new Entidades.MenuXrol()
            {
                IdRol = new Entidades.RolUsuario() { IdRol = IdRol }
            });

            //TODO Definir origen de la lista
            this.llenarMenu(menus, requiereSesion);


        }

        protected void cerrarSesion_Click(object sender, EventArgs e)
        {
            Negocio.Seguridad.Seguridad.cerrarSesion();
            Response.Redirect("~/Login.aspx");
        }

        private void llenarMenu(List<Entidades.MenuXrol> menus, int requiereSesion)
        {
            List<Entidades.MenuXrol> menusPadre;
            var consultaPadres = from m in menus
                                 where m.IdMenu.Nodo == 0
                                 where m.IdMenu.Sesion == requiereSesion
                                 orderby m.IdMenu.Orden
                                 select m;
            menusPadre = consultaPadres.ToList();

            menusPadre.ForEach(delegate (Entidades.MenuXrol menu)
            {
                MenuItem miMenuItem = new MenuItem(menu.IdMenu.Nombre, string.Empty, string.Empty, menu.IdMenu.Url);
                List<Entidades.MenuXrol> submenus;
                var consultaSubmenus = from m in menus
                                       where m.IdMenu.Nodo == menu.IdMenu.IdMenu
                                       where m.IdMenu.Sesion == requiereSesion
                                       orderby m.IdMenu.Orden
                                       select m;
                submenus = consultaSubmenus.ToList();
                submenus.ForEach(delegate (Entidades.MenuXrol submenu)
                {
                    MenuItem miMenuItemChild = new MenuItem(submenu.IdMenu.Nombre, string.Empty, string.Empty, submenu.IdMenu.Url);
                    //this.MyMenu.Items.Add(miMenuItemChild);
                    miMenuItem.ChildItems.Add(miMenuItemChild);
                });
                this.Menu1.Items.Add(miMenuItem);
            });
        }


    }
}