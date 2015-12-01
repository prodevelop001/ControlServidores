using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Seguridad
{
    public partial class Personas : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 6;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    if (permisos.R == true)
                    {
                        pnlFormulario.Visible = false;
                        pnlResultado.Visible = false;
                        llenarGdvPersonas();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }

        private void llenarGdvPersonas()
        {
            gdvPersonas.DataSource = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas());
            gdvPersonas.DataBind();
        }

        private void llenarDdlEstatus()
        {
            ddlEstatus.Items.Clear();
            ddlEstatus.AppendDataBoundItems = true;
            ddlEstatus.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlEstatus.DataTextField = "_Estatus";
            ddlEstatus.DataValueField = "IdEstatus";
            ddlEstatus.DataSource = Negocio.Catalogos.Estatus.Obtener(new Entidades.Estatus()
            {
                IdConceptoEstatus = 1
            });
            ddlEstatus.DataBind();
        }

        void limpiar()
        {
            txtNombre.Text =
            txtPuesto.Text =
            txtCorreo.Text =
            txtExtension.Text = string.Empty;
            ddlEstatus.SelectedValue = "0";
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "1";
            lblResultado.Text = string.Empty;
            pnlPersonas.Visible = false;
            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = permisos.C;
            llenarDdlEstatus();
            limpiar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            pnlPersonas.Visible = true;
            pnlFormulario.Visible = false;
            btnNuevo.Visible = true;
            lblResultado.Text = string.Empty;
            pnlResultado.Visible = false;
        }

        protected void gdvPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "2";
            lblResultado.Text = string.Empty;
            pnlPersonas.Visible = false;
            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = permisos.U;
            btnNuevo.Visible = false;
            llenarDdlEstatus();

            lblIdPersona.Text = gdvPersonas.SelectedRow.Cells[1].Text;
            txtNombre.Text = HttpUtility.HtmlDecode(gdvPersonas.SelectedRow.Cells[2].Text);
            txtPuesto.Text = HttpUtility.HtmlDecode(gdvPersonas.SelectedRow.Cells[3].Text);
            txtExtension.Text = HttpUtility.HtmlDecode(gdvPersonas.SelectedRow.Cells[4].Text);
            txtCorreo.Text = HttpUtility.HtmlDecode(gdvPersonas.SelectedRow.Cells[5].Text);
            ddlEstatus.SelectedValue = gdvPersonas.SelectedRow.Cells[6].Text;
        }

        protected void gdvPersonas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        LinkButton button = control as LinkButton;
                        if (button != null && button.Text == " Eliminar")
                        {
                            button.Enabled = permisos.D;
                            button.OnClientClick = "return checkMe()";
                        }
                    }
                }
            }
        }

        protected void gdvPersonas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblResultado.Text = string.Empty;
            int IdPersona = Convert.ToInt32(gdvPersonas.Rows[e.RowIndex].Cells[1].Text);
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            resultado = Negocio.Seguridad.Personas.Eliminar(new Entidades.Personas()
            {
                IdPersona = IdPersona,
                Estatus = null
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
                pnlResultado.Attributes["style"] =  "background: rgba(147, 252, 55, 0.22);";
                //pnlResultado.ForeColor = System.Drawing.Color.Green;
                
                llenarGdvPersonas();
            }
            pnlResultado.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Personas persona = new Entidades.Personas();
            persona.Nombre = txtNombre.Text.Trim();
            persona.Puesto = txtPuesto.Text.Trim();
            persona.Extension = txtExtension.Text.Trim();
            persona.Correo = txtCorreo.Text.Trim();
            persona.Estatus.IdEstatus = Convert.ToInt32(ddlEstatus.SelectedValue);
            if (hdfEstado.Value == "1" && permisos.C == true && ddlEstatus.SelectedValue != "0")
            {
                resultado = Negocio.Seguridad.Personas.Nuevo(persona);
            }
            else if (hdfEstado.Value == "2" && permisos.U == true && ddlEstatus.SelectedValue != "0")
            {
                persona.IdPersona = Convert.ToInt32(lblIdPersona.Text);
                resultado = Negocio.Seguridad.Personas.Actualizar(persona);
            }
            else if (ddlEstatus.SelectedValue == "0")
            {
                lblResultado.Text = "Debe tener un Estatus.";
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
                pnlPersonas.Visible = true;
                pnlFormulario.Visible = false;
                btnNuevo.Visible = true;
                llenarGdvPersonas();
            }
            pnlResultado.Visible = true;
        }
    }
}