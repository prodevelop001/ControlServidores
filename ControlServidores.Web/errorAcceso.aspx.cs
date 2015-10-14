using System;

namespace ControlServidores.Web
{
    public partial class errorAcceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Entidades.Usuarios usuario = (Entidades.Usuarios)Session["usuario"];
            if ((usuario == null) || (usuario.Usuario == string.Empty))
            {
                if (!IsPostBack)
                {
                    lblInfo.Text = "Para acceder al sistema es necesario registrase con su usuario y contraseña";
                    hlkRedirLogin.Visible = true;
                }
            }
        }
    }
}