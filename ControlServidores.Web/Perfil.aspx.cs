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

            obtenerDatos();
            pnlFormulario.Visible = false;
            pnlResultado.Visible = false;
            pnlInfo.Visible = true;


        }//Fin Void

        protected void obtenerDatos()
        {
            Entidades.Usuarios usuario = (Entidades.Usuarios)Session["usuario"];
            lblUsrName.Text = usuario.Usuario;
            lblIdUsuario.Text = usuario.IdUsuario.ToString();

            Entidades.Personas people = (Entidades.Personas)usuario.IdPersona;

            //if (people.IdPersona!=0)
            //{
            //    List<Entidades.Personas> p = new List<Entidades.Personas>();
            //    p = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas()
            //    {
            //        IdPersona = people.IdPersona
            //    });
            //    if (p.Count > 0)
            //    {
            //        people = p.First();
            //    }
            //}
            if (people != null)
            {
                List<Entidades.Personas> p = new List<Entidades.Personas>();
                p = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas()
                {
                    IdPersona = people.IdPersona
                });
                if (p.Count > 0)
                {
                    people = p.First();
                }

                lblNombre.Text = people.Nombre;
                lblPuesto.Text = people.Puesto;
                lblExtension.Text = people.Extension;
                lblCorreo.Text = people.Correo;
                lblIdPersona.Text = people.IdPersona.ToString();
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
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            txtNombreUsuario.Text = HttpUtility.HtmlDecode(lblUsrName.Text);
            txtNombre.Text = HttpUtility.HtmlDecode(lblNombre.Text);
            txtPuesto.Text = HttpUtility.HtmlDecode(lblPuesto.Text);
            txtExtension.Text = HttpUtility.HtmlDecode(lblExtension.Text);
            txtCorreo.Text = HttpUtility.HtmlDecode(lblCorreo.Text);

            if (!string.IsNullOrWhiteSpace(lblIdPersona.Text.Trim()))
            {
                hdfEstado.Value = "2";
            }
            else
            {
                hdfEstado.Value = "1";
            }

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

            Entidades.Personas persona = new Entidades.Personas();
            persona.Nombre = txtNombre.Text.Trim();
            persona.Puesto = txtPuesto.Text.Trim();
            persona.Extension = txtExtension.Text.Trim();
            persona.Correo = txtCorreo.Text.Trim();
            //persona.IdEstatus = Convert.ToInt32(ddlEstatus.SelectedValue);
            //if (hdfEstado.Value == "1" && permisos.C == true)
            if (hdfEstado.Value == "1")
            {
                resultado = Negocio.Seguridad.Personas.Nuevo(persona);
                us.IdUsuario = Convert.ToInt32(lblIdUsuario.Text);
                obtenerDatos();
                us.IdPersona.IdPersona = Convert.ToInt32(lblIdPersona.Text);
                resultado = Negocio.Seguridad.Usuarios.Actualizar(us);
            }
            //else if (hdfEstado.Value == "2" && permisos.U == true)
            else if (hdfEstado.Value == "2")
            {
                persona.IdPersona = Convert.ToInt32(lblIdPersona.Text);
                resultado = Negocio.Seguridad.Personas.Actualizar(persona);
            }
            else
            {
                lblResultado.Text = "No tienes privilegios para realizar esta acción.";
            }

            resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
            {
                lblResultado.Text += error.descripcionCorta + "<br/>";
            });



            //lblResultado.ForeColor = System.Drawing.Color.Red;
            lblResultado.Attributes["style"] = "color: #F00;";
            pnlResultado.Attributes["style"] = "background: rgba(252, 55, 55, 0.2);";
            if (resultado.resultado == true)
            {
                //lblResultado.ForeColor = System.Drawing.Color.Green;
                lblResultado.Attributes["style"] = "color: #008000;";
                pnlResultado.Attributes["style"] = "background: rgba(147, 252, 55, 0.22);";
                hdfEstado.Value = "0";

                pnlFormulario.Visible = false;
                pnlInfo.Visible = true;
                btnActualizar.Visible = true;
                obtenerDatos();
            }
            pnlResultado.Visible = true;




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