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

            //int idPersona = Convert.ToInt32(usuario.IdUsuario);
            int idPersona = Convert.ToInt32(usuario.IdPersona);

            //List<Entidades.Personas> persona = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas()
            //{
            //    IdPersona = 1
            //}
            //);

            //Entidades.Personas p = persona.First();
            //lblNombre.Text = p.Nombre;
            lblNombre.Text = idPersona.ToString();
        }
    }
}