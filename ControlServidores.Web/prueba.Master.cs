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
            /*
            Entidades.Usuarios usr = (Entidades.Usuarios)context.Session["usuario"];
            lblUsrName.Text = usr.Usuario.ToString();
            */
            lblUsrName.Text = "Mauro A.";
        }

        protected void cerrarSesion_Click(object sender, EventArgs e)
        {
            Negocio.Seguridad.Seguridad.cerrarSesion();
            Response.Redirect("~/Login.aspx");
        }
    }
}