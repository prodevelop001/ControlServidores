using System;
using System.Web;

namespace ControlServidores.Web
{
    public partial class Login : System.Web.UI.Page
    {
        HttpContext context = HttpContext.Current;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            Entidades.Usuarios usr = (Entidades.Usuarios)context.Session["usuario"];
            if(usr != null && usr.Usuario != "")
            {
                Response.Redirect("~/Catalogos/ConceptoEstatus.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    lblLogin.Text = "";
                    lblLogin.Attributes["style"] = "display: none;";
                }
            }
            lnkBtnSubmit.Focus();
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
            usrLogin.IdPersona = null;
            usrLogin.IdRol = null;
            //userL = Datos.Seguridad.Usuarios.Obtener(new Entidades.Usuarios() { Usuario = usrLogin.Usuario });
            if (usrLogin.Usuario != "" && !string.IsNullOrEmpty(txtUsrPass.Text))
            {
                lblLogin.Attributes["style"] = "display: block;";
                lblLogin.Text = usrLogin.Usuario.ToString();
                if (Negocio.Seguridad.Seguridad.iniciarSesion(usrLogin) == true)
                {
                    //redirecionar
                    Response.Redirect("~/Catalogos/ConceptoEstatus.aspx");
                }
                else
                {
                    lblLogin.Attributes["style"] = "display: block;";
                    lblLogin.Text = "Usuario y/o contraseña incorrectas";
                }
            }
            else
            {
                lblLogin.Attributes["style"] = "display: block;";
                lblLogin.Text = "Campos vacios";
            }
        }

    }
}