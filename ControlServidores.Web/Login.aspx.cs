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
            lblLogin.Attributes["style"] = "display: none;";
            //lblLogin.Style;
        }

        protected void lnkBtnSubmit_Click(object sender, EventArgs e)
        {
            /*
            Aqui va el código
            */
            Entidades.Usuarios usrLogin = new Entidades.Usuarios();
            //List<Entidades.Usuarios> userL = new List<Entidades.Usuarios>();
            usrLogin.Usuario = txtUsrName.Text;
            usrLogin.Pwd = txtUsrPass.Text;
            //userL = Datos.Seguridad.Usuarios.Obtener(new Entidades.Usuarios() { Usuario = usrLogin.Usuario });
            if (usrLogin.Usuario != "")
            {
                lblLogin.Attributes["style"] = "display: block;";
                lblLogin.Text = usrLogin.Usuario.ToString();
            }
            else
            {
                lblLogin.Attributes["style"] = "display: block;";
                lblLogin.Text = "Usuario y/o contraseña incorrectas";
            }
        }
    }
}