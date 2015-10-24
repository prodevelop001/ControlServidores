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
                lblNombre.Text = null;
                lblPuesto.Text = null;
                lblExtension.Text = null;
                lblCorreo.Text = null;
            }

            Entidades.RolUsuario rol = (Entidades.RolUsuario)usuario.IdRol;
            if (rol != null)
            {
                lblRol.Text = rol.NombreRol;
            }
            else
            {
                lblNombre.Text = null;
                
            }

            pnlFormulario.Visible = false;
            pnlResultado.Visible = false;
            pnlInfo.Visible = true;


        }//Fin Void

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            txtNombreUsuario.Text = HttpUtility.HtmlDecode(lblUsrName.Text);
            txtNombre.Text = HttpUtility.HtmlDecode(lblNombre.Text);
            txtPuesto.Text = HttpUtility.HtmlDecode(lblPuesto.Text);
            txtExtension.Text = HttpUtility.HtmlDecode(lblExtension.Text);
            txtCorreo.Text = HttpUtility.HtmlDecode(lblCorreo.Text);

            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            pnlInfo.Visible = false;
            btnActualizar.Visible = false;
        }//Fin de Boton Actualizar

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            //permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            Entidades.Usuarios us = new Entidades.Usuarios();
            us.Usuario = txtNombreUsuario.Text.Trim();
            //us.IdRol.IdRol = Convert.ToInt32(ddlRol.SelectedValue);
            //if (ddlPersona.SelectedValue == "0")
            //    us.IdPersona.IdPersona = -1;
            //else
            //    us.IdPersona.IdPersona = Convert.ToInt32(ddlPersona.SelectedValue);

            //if (txtPass1.Text.Trim() == txtPass2.Text.Trim())
            //{
            //    if (hdfEstado.Value == "1" && permisos.C == true && ddlRol.SelectedValue != "0")
            //    {
            //        us.Pwd = txtPass1.Text.Trim();
            //        resultado = Negocio.Seguridad.Usuarios.Nuevo(us);
            //    }
            //    else if (hdfEstado.Value == "2" && permisos.U == true && ddlRol.SelectedValue != "0")
            //    {
            //        us.IdUsuario = Convert.ToInt32(lblIdUsuario.Text);
            //        us.Pwd = txtPass1.Text.Trim();
            //        resultado = Negocio.Seguridad.Usuarios.Actualizar(us);
            //    }
            //    else if (ddlRol.SelectedValue == "0")
            //    {
            //        lblResultado.Text = "Seleccionar un rol.";
            //    }
            //    else
            //    {
            //        lblResultado.Text = "No tienes privilegios para realizar esta acción.";
            //    }
            //}
            //else
            //{
            //    txtPass1.Attributes.Add("value", txtPass1.Text);
            //    txtPass2.Attributes.Add("value", txtPass2.Text);
            //    lblResultado.Text = "Contraseñas deben coincidir.";
            //}
            //resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
            //{
            //    lblResultado.Text += error.descripcionCorta + "<br/>";
            //});

            ////lblResultado.ForeColor = System.Drawing.Color.Red;
            //lblResultado.Attributes["style"] = "color: #F00;";
            //pnlResultado.Attributes["style"] = "background: rgba(252, 55, 55, 0.2);";
            //if (resultado.resultado == true)
            //{
            //    //lblResultado.ForeColor = System.Drawing.Color.Green;
            //    lblResultado.Attributes["style"] = "color: #008000;";
            //    pnlResultado.Attributes["style"] = "background: rgba(147, 252, 55, 0.22);";
            //    hdfEstado.Value = "0";
            //    lblIdUsuario.Text = string.Empty;
            //    btnNuevo.Visible = true;
            //    pnlUsuarios.Visible = true;
            //    pnlFormulario.Visible = false;
            //    llenarGdvUsuarios();
            //}
            //pnlResultado.Visible = true;

        }//Fin de Boton Guardar

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            btnActualizar.Visible = true;
            pnlInfo.Visible = true;
            pnlFormulario.Visible = false;
            pnlResultado.Visible = false;
        }//Fin de Boton Cancelar

    }//Fin de la Clase
}