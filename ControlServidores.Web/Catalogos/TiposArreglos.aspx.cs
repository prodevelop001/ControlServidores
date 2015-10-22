using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Catalogos
{
    public partial class TiposArreglos : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 13;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    if (permisos.R == true)
                    {
                        pnlTipoArreglo.Visible = true;
                        pnlFormulario.Visible = false;
                        pnlResultado.Visible = false;
                        llenarGdvTiposArreglos();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }//Fin de Void

        private void llenarGdvTiposArreglos()
        {

            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();

            gdvTiposArreglos.DataSource = Negocio.Catalogos.TipoArregloDisco.Obtener(new Entidades.TipoArregloDisco());
            gdvTiposArreglos.DataBind();
        }//Fin de Llenar Gridview SOs

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "1";
            lblStatus.Text = string.Empty;
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = permisos.C;
            pnlTipoArreglo.Visible = false;
            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            lblIdTipoArreglo.Value = string.Empty;
            //lblIdSistemaOperativo.Attributes["style"] = "display: none;";
            txtTipoArreglo.Text = string.Empty;
            txtTipoArregloDesc.Text = string.Empty;
        }//Fin de Boton Nuevo

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            btnNuevo.Visible = true;
            btnNuevo.Text = "Nuevo";
            pnlTipoArreglo.Visible = true;
            pnlFormulario.Visible = false;
            pnlResultado.Visible = false;
        }//Fin de Boton Cancelar


        protected void gdvTiposArreglos_SelectedIndexChanged(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "2";
            lblStatus.Text = string.Empty;
            btnNuevo.Visible = false;
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = permisos.U;
            pnlTipoArreglo.Visible = false;
            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            lblIdTipoArreglo.Value = gdvTiposArreglos.SelectedRow.Cells[1].Text;

            txtTipoArreglo.Text = HttpUtility.HtmlDecode(gdvTiposArreglos.SelectedRow.Cells[2].Text);
            txtTipoArregloDesc.Text = HttpUtility.HtmlDecode(gdvTiposArreglos.SelectedRow.Cells[3].Text);
        }//Fin de Seleccionar en Gridview

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            lblStatus.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            if (hdfEstado.Value == "1" && permisos.C == true)
            {
                resultado = Negocio.Catalogos.TipoArregloDisco.Nuevo(new Entidades.TipoArregloDisco()
                {
                    Tipo = txtTipoArreglo.Text,
                    Descripcion = txtTipoArregloDesc.Text
                });
            }
            else if (hdfEstado.Value == "2" && permisos.U == true)
            {
                resultado = Negocio.Catalogos.TipoArregloDisco.Actualizar(new Entidades.TipoArregloDisco()
                {
                    IdTipoArreglo = Convert.ToInt32(lblIdTipoArreglo.Value),
                    Tipo = txtTipoArreglo.Text,
                    Descripcion = txtTipoArregloDesc.Text
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

            //lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Attributes["style"] = "color: #F00;";
            pnlResultado.Attributes["style"] = "background: rgba(252, 55, 55, 0.2);";
            if (resultado.resultado == true)
            {
                //lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Attributes["style"] = "color: #008000;";
                pnlResultado.Attributes["style"] = "background: rgba(147, 252, 55, 0.22);";
                hdfEstado.Value = "0";
                btnNuevo.Visible = true;
                btnNuevo.Text = "Nuevo";
                pnlTipoArreglo.Visible = true;
                pnlFormulario.Visible = false;
                llenarGdvTiposArreglos();
            }
            pnlResultado.Visible = true;
        }//Fin de boton Guardar

        protected void gdvTiposArreglos_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gdvTiposArreglos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblStatus.Text = string.Empty;
            int IdTipoArreglo = Convert.ToInt32(gdvTiposArreglos.Rows[e.RowIndex].Cells[1].Text);
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            resultado = Negocio.Catalogos.TipoArregloDisco.Eliminar(new Entidades.TipoArregloDisco()
            {
                IdTipoArreglo = IdTipoArreglo
            });

            resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
            {
                lblStatus.Text += error.descripcionCorta + "<br/>";
            });

            //lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Attributes["style"] = "color: #F00;";
            pnlResultado.Attributes["style"] = "background: rgba(252, 55, 55, 0.2);";
            if (resultado.resultado == true)
            {
                //lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Attributes["style"] = "color: #008000;";
                pnlResultado.Attributes["style"] = "background: rgba(147, 252, 55, 0.22);";
                llenarGdvTiposArreglos();
            }
            pnlResultado.Visible = true;
        }//Fin eliminar Fila

    }//Fin de la Clase
}