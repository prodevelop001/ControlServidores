using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Catalogos
{
    public partial class SistemasOperativos : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 16;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    if (permisos.R == true)
                    {
                        pnlSO.Visible = true;
                        pnlFormulario.Visible = false;
                        llenarGdvSOs();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }//Fin de Void

        private void llenarGdvSOs()
        {

            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();

            gdvSOs.DataSource = Negocio.Catalogos.SO.Obtener(new Entidades.SO());
            gdvSOs.DataBind();
        }//Fin de Llenar Gridview SOs

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "1";
            lblStatus.Text = string.Empty;
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = permisos.C;
            pnlSO.Visible = false;
            pnlFormulario.Visible = true;
            lblIdSistemaOperativo.Value = string.Empty;
            //lblIdSistemaOperativo.Attributes["style"] = "display: none;";
            txtSO.Text = string.Empty;
        }//Fin de Boton Nuevo

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            btnNuevo.Visible = true;
            btnNuevo.Text = "Nuevo";
            pnlSO.Visible = true;
            pnlFormulario.Visible = false;
        }//Fin de Boton Cancelar


        protected void gdvSOs_SelectedIndexChanged(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "2";
            lblStatus.Text = string.Empty;
            btnNuevo.Visible = false;
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = permisos.U;
            pnlSO.Visible = false;
            pnlFormulario.Visible = true;
            lblIdSistemaOperativo.Value = gdvSOs.SelectedRow.Cells[1].Text;
            
            txtSO.Text = gdvSOs.SelectedRow.Cells[2].Text;
        }//Fin de Seleccionar en Gridview

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            lblStatus.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            if (hdfEstado.Value == "1" && permisos.C == true)
            {
                resultado = Negocio.Catalogos.SO.Nuevo(new Entidades.SO()
                {
                    NombreSO = txtSO.Text
                });
            }
            else if (hdfEstado.Value == "2" && permisos.U == true)
            {
                resultado = Negocio.Catalogos.SO.Actualizar(new Entidades.SO()
                {
                    IdSO = Convert.ToInt32(lblIdSistemaOperativo.Value),
                    NombreSO = txtSO.Text
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
                pnlSO.Visible = true;
                pnlFormulario.Visible = false;
                llenarGdvSOs();
            }
        }//Fin de boton Guardar

        protected void gdvSOs_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gdvSOs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblStatus.Text = string.Empty;
            int IdSO = Convert.ToInt32(gdvSOs.Rows[e.RowIndex].Cells[1].Text);
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            resultado = Negocio.Catalogos.SO.Eliminar(new Entidades.SO()
            {
                IdSO = IdSO
            });

            resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
            {
                lblStatus.Text += error.descripcionCorta + "<br/>";
            });

            lblStatus.ForeColor = System.Drawing.Color.Red;
            if (resultado.resultado == true)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                llenarGdvSOs();
            }
        }//Fin eliminar Fila

    }//Fin de class SistemasOperativos
}