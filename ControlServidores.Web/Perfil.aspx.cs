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
                lblPuesto.Text = people.Puesto;
                lblExtension.Text = people.Extension;
                lblCorreo.Text = people.Correo;
            }
            else
            {
                lblNombre.Text = "Sin Persona ligada";
                lblPuesto.Text = "Sin Puesto asignado";
                lblExtension.Text = "Sin Extensión asignado";
                lblCorreo.Text = "Sin Correo asignado";
            }

            Entidades.RolUsuario rol = (Entidades.RolUsuario)usuario.IdRol;
            if (rol != null)
            {
                lblRol.Text = rol.NombreRol;
            }
            else
            {
                lblNombre.Text = "Sin Rol asignado";
                
            }
        }//Fin Void



    }//Fin de la Clase
}