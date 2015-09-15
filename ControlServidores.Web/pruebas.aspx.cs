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
            gdvPrueba.DataSource = Negocio.Seguridad.Usuarios.Obtener(new Entidades.Usuarios());
            gdvPrueba.DataBind();
        }

        protected void btnPrueba_Click(object sender, EventArgs e)
        {
            Entidades.Usuarios u = new Entidades.Usuarios();
            u.Usuario = "Perro";
            u.IdPersona = 1;
            u.Pwd = "guau";
            u.IdRol.IdRol = 4;

            Negocio.Seguridad.Usuarios.Nuevo(u);
        }
    }
}