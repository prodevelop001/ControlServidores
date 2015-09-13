using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web
{
    public partial class pruebas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                llenarGrid();
            }
        }

        private void llenarGrid()
        {
            gdvPrueba.DataSource = Negocio.Seguridad.MenuXrol.Obtener(new Entidades.MenuXrol() { IdRol= new Entidades.RolUsuario() { IdRol= 4} });
            gdvPrueba.DataBind();
        }

        protected void btnPrueba_Click(object sender, EventArgs e)
        {
            Entidades.RolUsuario rol = new Entidades.RolUsuario();
            rol.NombreRol = "Nuevo Rol";

            List<Entidades.MenuXrol> mrL = new List<Entidades.MenuXrol>();
            Entidades.MenuXrol mr = new Entidades.MenuXrol();

            mr.IdMenu.IdMenu = 1;
            mr.IdRol.IdRol = 4;
            mrL.Add(mr);

            mr = new Entidades.MenuXrol();
            mr.IdMenu.IdMenu = 2;
            mr.IdRol.IdRol = 4;
            mrL.Add(mr);

            Negocio.Seguridad.RolUsuario.Nuevo(rol, mrL);
        }
    }
}