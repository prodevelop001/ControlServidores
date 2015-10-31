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
            lblIdRol.Text = usuario.IdRol.IdRol.ToString();

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
            txtPass1.Text = "";
            txtPass2.Text = "";

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
            resultado.resultado = false;
            //us.IdUsuario = Convert.ToInt32(lblIdUsuario.Text);

            if (txtPass1.Text.Trim() == txtPass2.Text.Trim())
            {
                us.IdUsuario = Convert.ToInt32(lblIdUsuario.Text);
                us.Usuario = lblUsrName.Text.Trim();
                us.Pwd = txtPass1.Text.Trim();
                us.IdRol.IdRol = Convert.ToInt32(lblIdRol.Text);
                us.IdPersona.IdPersona = Convert.ToInt32(lblIdPersona.Text);
                resultado = Negocio.Seguridad.Usuarios.Actualizar(us);
            }
            else
            {
                txtPass1.Attributes.Add("value", txtPass1.Text);
                txtPass2.Attributes.Add("value", txtPass2.Text);
                lblResultado.Text = "Las Contraseñas deben coincidir.";
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