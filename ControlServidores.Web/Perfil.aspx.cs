using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuarios usuario = (Entidades.Usuarios)Session["usuario"];
            lblUsrName.Text = usuario.Usuario;

            Entidades.Personas people = (Entidades.Personas)usuario.IdPersona;
            if (people != null)
            {
                lblNombre.Text = people.Nombre;
            }
            else
            {
                lblNombre.Text = "Sin Persona ligada";
            }

        }
    }
}