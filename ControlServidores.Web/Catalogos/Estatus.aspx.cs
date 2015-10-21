using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Catalogos
{
    public partial class Estatus : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 12;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    if (permisos.R == true)
                    {
                        pnlNombreEstatus.Visible = true;
                        pnlFormulario.Visible = false;
                        llenarDdlConceptoEstatus();
                        llenarGdvEstatus();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }//Fin de Void

        private void llenarGdvEstatus()
        {

            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();

            gdvNombreEstatus.DataSource = Negocio.Catalogos.ConceptoEstatus.Obtener(new Entidades.ConceptoEstatus()
            {
                IdConceptoEstatus = Convert.ToInt32(ddlConceptoEstatus.SelectedValue ?? "0")
            }
            );
            gdvNombreEstatus.DataBind();
        }//Fin de Llenar Gridview Estatus

        private void llenarDdlConceptoEstatus()
        {
            ddlConceptoEstatus.Items.Clear();
            ddlConceptoEstatus.AppendDataBoundItems = true;
            ddlConceptoEstatus.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlConceptoEstatus.DataTextField = "Concepto";
            ddlConceptoEstatus.DataValueField = "IdConceptoEstatus";
            ddlConceptoEstatus.DataSource = Negocio.Catalogos.ConceptoEstatus.Obtener(new Entidades.ConceptoEstatus());
            ddlConceptoEstatus.DataBind();
        }//Fin de Llenar Concepto Estatus

        private void llenarGdvEstatusForm()
        {
            ddlConceptoEstatusForm.Items.Clear();
            ddlConceptoEstatusForm.AppendDataBoundItems = true;
            ddlConceptoEstatusForm.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlConceptoEstatusForm.DataTextField = "Concepto";
            ddlConceptoEstatusForm.DataValueField = "IdConceptoEstatus";
            ddlConceptoEstatusForm.DataSource = Negocio.Catalogos.ConceptoEstatus.Obtener(new Entidades.ConceptoEstatus());
            ddlConceptoEstatusForm.DataBind();
        }//Fin de Llenar Estatus en Form

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "1";
            lblStatus.Text = string.Empty;
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = permisos.C;
            pnlNombreEstatus.Visible = false;
            pnlFormulario.Visible = true;
            lblIdEstatus.Value = string.Empty;
            //lblIdSistemaOperativo.Attributes["style"] = "display: none;";
            //txtMarca.Text = string.Empty;
            txtNombreEstatus.Text = string.Empty;
            llenarGdvEstatusForm();
        }//Fin de Boton Nuevo

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            btnNuevo.Visible = true;
            btnNuevo.Text = "Nuevo";
            pnlNombreEstatus.Visible = true;
            pnlFormulario.Visible = false;
            ddlConceptoEstatusForm.Enabled = true;
        }//Fin de Boton Cancelar


        protected void gdvNombreEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "2";
            lblStatus.Text = string.Empty;
            btnNuevo.Visible = false;
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = permisos.U;
            pnlNombreEstatus.Visible = false;
            pnlFormulario.Visible = true;
            lblIdEstatus.Value = HttpUtility.HtmlDecode(gdvNombreEstatus.SelectedRow.Cells[1].Text);
            llenarGdvEstatusForm();
            //ddlMarcaForm.SelectedItem.Text = ddlMarca.SelectedItem.ToString();
            ddlConceptoEstatusForm.Items.FindByText(ddlConceptoEstatus.SelectedItem.ToString()).Selected = true;
            ddlConceptoEstatusForm.Enabled = false;
            //txtMarca.Text = gdvNombreModelo.SelectedRow.Cells[2].Text;
            txtNombreEstatus.Text = HttpUtility.HtmlDecode(gdvNombreEstatus.SelectedRow.Cells[3].Text);
        }//Fin de Seleccionar en Gridview

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            lblStatus.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            if (hdfEstado.Value == "1" && permisos.C == true)
            {
                resultado = Negocio.Catalogos.Estatus.Nuevo(new Entidades.Estatus()
                {
                    IdConceptoEstatus = Convert.ToInt32(ddlConceptoEstatusForm.SelectedValue),
                    _Estatus = txtNombreEstatus.Text
                });
            }
            else if (hdfEstado.Value == "2" && permisos.U == true)
            {
                resultado = Negocio.Catalogos.Estatus.Actualizar(new Entidades.Estatus()
                {
                    IdEstatus = Convert.ToInt32(lblIdEstatus.Value),
                    IdConceptoEstatus = Convert.ToInt32(ddlConceptoEstatusForm.SelectedValue),
                    _Estatus = txtNombreEstatus.Text
                });
            }
            else
            {
                lblStatus.Text = "No tienes privilegios para realizar esta acción.";
            }

            resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
            {
                lblStatus.Text += error.descripcionCorta + "<br/>";
            });

            lblStatus.ForeColor = System.Drawing.Color.Red;
            if (resultado.resultado == true)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                hdfEstado.Value = "0";
                btnNuevo.Visible = true;
                btnNuevo.Text = "Nuevo";
                pnlNombreEstatus.Visible = true;
                pnlFormulario.Visible = false;
                llenarGdvEstatus();
            }
        }//Fin de boton Guardar

        protected void gdvNombreEstatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        //LinkButton button = (LinkButton)control;
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
        }//Fin de Row Data Bound

        protected void gdvNombreEstatus_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblStatus.Text = string.Empty;
            int IdEstatus = Convert.ToInt32(gdvNombreEstatus.Rows[e.RowIndex].Cells[1].Text);
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            resultado = Negocio.Catalogos.Estatus.Eliminar(new Entidades.Estatus()
            {
                IdEstatus = IdEstatus
            });

            resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
            {
                lblStatus.Text += error.descripcionCorta + "<br/>";
            });

            lblStatus.ForeColor = System.Drawing.Color.Red;
            if (resultado.resultado == true)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                llenarGdvEstatus();
            }
        }//Fin eliminar Fila

        protected void ddlConceptoEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarGdvEstatus();
        }

    }//Fin de la Clase
}