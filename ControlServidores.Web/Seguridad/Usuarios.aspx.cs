using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Seguridad
{
    public partial class Usuarios : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 9;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    if (permisos.R == true)
                    {
                        pnlFormulario.Visible = false;
                        pnlResultado.Visible = false;
                        llenarGdvUsuarios();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }

        private void llenarGdvUsuarios()
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            gdvUsuarios.DataSource = Negocio.Seguridad.Usuarios.Obtener(new Entidades.Usuarios() { IdPersona = null,  IdRol = null });
            gdvUsuarios.DataBind();
        }

        private void llenarDdlPersonas()
        {
            ddlPersona.Items.Clear();
            ddlPersona.AppendDataBoundItems = true;
            ddlPersona.Items.Add(new ListItem("-- Seleccione --", "0"));
            ddlPersona.DataTextField = "Nombre";
            ddlPersona.DataValueField = "IdPersona";
            ddlPersona.DataSource = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas()
            {
                IdEstatus = 1
            });
            ddlPersona.DataBind();
        }

        private void llenarDdlRoles()
        {
            ddlRol.Items.Clear();
            ddlRol.AppendDataBoundItems = true;
            ddlRol.Items.Add(new ListItem("-- Seleccione --", "0"));
            ddlRol.DataTextField = "NombreRol";
            ddlRol.DataValueField = "IdRol";
            ddlRol.DataSource = Negocio.Seguridad.RolUsuario.Obtener(new Entidades.RolUsuario());
            ddlRol.DataBind();
        }

        private void limpiar()
        {
            txtNombreUsuario.Text =
            txtPass1.Text =
            txtPass2.Text = string.Empty;
            txtPass1.Attributes.Add("value", "");
            txtPass2.Attributes.Add("value", "");
            ddlPersona.SelectedValue = "0";
            ddlRol.SelectedValue = "0";
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "1";
            lblResultado.Text = string.Empty;
            lblIdUsuario.Text = string.Empty;
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = permisos.C;
            pnlUsuarios.Visible = false;
            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            llenarDdlRoles();
            llenarDdlPersonas();
            limpiar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            lblResultado.Text = string.Empty;
            lblIdUsuario.Text = string.Empty;
            btnNuevo.Visible = true;
            pnlUsuarios.Visible = true;
            pnlFormulario.Visible = false;
            pnlResultado.Visible = false;
        }

        protected void gdvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "2";
            btnNuevo.Visible = false;
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = permisos.U;
            pnlUsuarios.Visible = false;
            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            llenarDdlRoles();
            llenarDdlPersonas();

            lblIdUsuario.Text = gdvUsuarios.SelectedRow.Cells[1].Text;
            List<Entidades.Usuarios> usList = new List<Entidades.Usuarios>();
            usList = Negocio.Seguridad.Usuarios.Obtener(new Entidades.Usuarios()
            {
                IdUsuario = Convert.ToInt32(lblIdUsuario.Text), IdPersona = null, IdRol = null
            });
            Entidades.Usuarios us = usList.First();
            txtNombreUsuario.Text = us.Usuario;
            ddlRol.SelectedValue = us.IdRol.IdRol.ToString();
            if (us.IdPersona != null)
                ddlPersona.SelectedValue = us.IdPersona.IdPersona.ToString();
            txtPass1.Attributes.Add("value", us.Pwd);
            txtPass2.Attributes.Add("value", us.Pwd);
        }

        protected void gdvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblRol1 = e.Row.FindControl("lblRol1") as Label;
                int IdRol = Convert.ToInt32(e.Row.Cells[3].Text);
                List<Entidades.RolUsuario> rolList = new List<Entidades.RolUsuario>();
                rolList = Negocio.Seguridad.RolUsuario.Obtener(new Entidades.RolUsuario()
                {
                    IdRol = IdRol
                });
                lblRol1.Text = rolList.First().NombreRol;

                Label lblPersona1 = e.Row.FindControl("lblPersona1") as Label;
                int IdPersona = 0;
                if (!string.IsNullOrEmpty(e.Row.Cells[5].Text.Replace("&nbsp;", "")))
                {
                    IdPersona = Convert.ToInt32(e.Row.Cells[5].Text);
                    List<Entidades.Personas> perList = new List<Entidades.Personas>();
                    perList = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas()
                    {
                        IdPersona = IdPersona
                    });
                    lblPersona1.Text = perList.First().Nombre;
                }
                else
                    lblPersona1.Text = "Ninguna persona.";

                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        LinkButton button = control as LinkButton;
                        if (button != null && button.Text == "Eliminar")
                        {
                            button.Enabled = permisos.D;
                            if (button.Enabled)
                                button.OnClientClick = "return checkMe()";
                        }
                    }
                }
            }
        }

        protected void gdvUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblResultado.Text = string.Empty;
            int IdUsuario = Convert.ToInt32(gdvUsuarios.Rows[e.RowIndex].Cells[1].Text);
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            resultado = Negocio.Seguridad.Usuarios.Eliminar(new Entidades.Usuarios()
            {
                IdUsuario = IdUsuario, IdPersona = null, IdRol = null
            });

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
                
                llenarGdvUsuarios();
            }
            pnlResultado.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            Entidades.Usuarios us = new Entidades.Usuarios();
            us.Usuario = txtNombreUsuario.Text.Trim();
            us.IdRol.IdRol = Convert.ToInt32(ddlRol.SelectedValue);
            us.IdPersona.IdPersona = Convert.ToInt32(ddlPersona.SelectedValue);

            //if (ddlPersona.SelectedValue == "0")
            //    us.IdPersona.IdPersona = -1;
            //else
            //    us.IdPersona.IdPersona = Convert.ToInt32(ddlPersona.SelectedValue);

            if (txtPass1.Text.Trim() == txtPass2.Text.Trim())
            {
                if (hdfEstado.Value == "1" && permisos.C == true && ddlRol.SelectedValue != "0" && ddlPersona.SelectedValue != "0")
                {
                    us.Pwd = txtPass1.Text.Trim();
                    resultado = Negocio.Seguridad.Usuarios.Nuevo(us);
                }
                else if (hdfEstado.Value == "2" && permisos.U == true && ddlRol.SelectedValue != "0" && ddlPersona.SelectedValue != "0")
                {
                    us.IdUsuario = Convert.ToInt32(lblIdUsuario.Text);
                    us.Pwd = txtPass1.Text.Trim();
                    resultado = Negocio.Seguridad.Usuarios.Actualizar(us);
                }
                else if(ddlRol.SelectedValue == "0")
                {
                    lblResultado.Text = "Seleccionar un rol.";
                }
                else
                {
                    lblResultado.Text = "No tienes privilegios para realizar esta acción.";
                }
            }
            else
            {
                txtPass1.Attributes.Add("value", txtPass1.Text);
                txtPass2.Attributes.Add("value", txtPass2.Text);
                lblResultado.Text = "Contraseñas deben coincidir.";
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
                lblIdUsuario.Text = string.Empty;
                btnNuevo.Visible = true;
                pnlUsuarios.Visible = true;
                pnlFormulario.Visible = false;
                llenarGdvUsuarios();
            }
            pnlResultado.Visible = true;
        }
    }
}