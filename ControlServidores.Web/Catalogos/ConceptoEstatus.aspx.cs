using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Catalogos
{
    public partial class ConceptoEstatus : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 2;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    if (permisos.R == true)
                    {
                        pnlCatalogo.Visible = true;
                        pnlFormulario.Visible = false;
                        llenarGdvConceptos();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
            
        }

        private void llenarGdvConceptos()
        {
            
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            
            gdvConceptos.DataSource = Negocio.Catalogos.ConceptoEstatus.Obtener(new Entidades.ConceptoEstatus());
            gdvConceptos.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "1";
            lblStatus.Text = string.Empty;
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = permisos.C;
            pnlCatalogo.Visible = false;
            pnlFormulario.Visible = true;
            lblIdConceptoEstatus.Text = string.Empty;
            lblIdConceptoEstatus.Attributes["style"] = "display: none;";
            txtConcepto.Text = string.Empty;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            btnNuevo.Visible = true;
            btnNuevo.Text = "Nuevo";
            pnlCatalogo.Visible = true;
            pnlFormulario.Visible = false;
        }

        protected void gdvConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "2";
            lblStatus.Text = string.Empty;
            btnNuevo.Visible = false;
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = permisos.U;
            pnlCatalogo.Visible = false;
            pnlFormulario.Visible = true;
            lblIdConceptoEstatus.Text = gdvConceptos.SelectedRow.Cells[1].Text;
            lblIdConceptoEstatus.Attributes["style"] = "display: block;";
            txtConcepto.Text = gdvConceptos.SelectedRow.Cells[2].Text;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            lblStatus.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            if (hdfEstado.Value == "1" && permisos.C == true)
            {
                resultado = Negocio.Catalogos.ConceptoEstatus.Nuevo(new Entidades.ConceptoEstatus()
                {
                    Concepto = txtConcepto.Text
                });
            }
            else if(hdfEstado.Value == "2" && permisos.U == true)
            {
                resultado = Negocio.Catalogos.ConceptoEstatus.Actualizar(new Entidades.ConceptoEstatus()
                {
                    IdConceptoEstatus= Convert.ToInt32(lblIdConceptoEstatus.Text),
                    Concepto = txtConcepto.Text
                });
            }
            else
            {
                lblStatus.Text ="No tienes privilegios para realizar esta acción.";
            }           

            resultado.errores.ForEach(delegate(Entidades.Logica.Error error)
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
                pnlCatalogo.Visible = true;
                pnlFormulario.Visible = false;
                llenarGdvConceptos();
            }
        }

        protected void gdvConceptos_RowDataBound(object sender, GridViewRowEventArgs e)
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
                            if(button.Enabled)
                                button.OnClientClick = "return checkMe()";
                        }
                    }
                }
            }
        }

        protected void gdvConceptos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblStatus.Text = string.Empty;
            int IdConceptoEstatus = Convert.ToInt32(gdvConceptos.Rows[e.RowIndex].Cells[1].Text);
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            resultado = Negocio.Catalogos.ConceptoEstatus.Eliminar(new Entidades.ConceptoEstatus()
            {
                IdConceptoEstatus = IdConceptoEstatus
            });

            resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
            {
                lblStatus.Text += error.descripcionCorta + "<br/>";
            });

            lblStatus.ForeColor = System.Drawing.Color.Red;
            if (resultado.resultado == true)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                llenarGdvConceptos();
            }
        }
    }
}