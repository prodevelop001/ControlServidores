using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLogin.Text = "";
        }

        protected void lnkBtnSubmit_Click(object sender, EventArgs e)
        {
            /*
            Aqui va el código
            */
            List<Entidades.Usuarios> usrLogin = new List<Entidades.Usuarios>();
            usrLogin = Negocio.Seguridad.Usuarios.Obtener(new Entidades.Usuarios()
            {
                Usuario = txtUsrName.Text,
                Pwd = txtUsrPass.Text
            });
          
        }
    }
}