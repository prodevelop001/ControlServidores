using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Catalogos
{
    public partial class Procesadores : System.Web.UI.Page
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
                        pnlProcesadores.Visible = true;
                        pnlFormulario.Visible = false;
                        llenarGdvProcesadores();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }//Fin de Void

        private void llenarGdvProcesadores()
        {

            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();

            gdvProcesadores.DataSource = Negocio.Catalogos.Procesador.Obtener(new Entidades.Procesador());
            gdvProcesadores.DataBind();
        }//Fin de Llenar Gridview SOs

        private void llenarDdlTamanoPalabra()
        {
            ddlTamanoPalabra.Items.Clear();
            ddlTamanoPalabra.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlTamanoPalabra.Items.Add(new ListItem("32", "32"));
            ddlTamanoPalabra.Items.Add(new ListItem("32-64", "32-64"));
        }//Fin de llenar DDL

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "1";
            lblStatus.Text = string.Empty;
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = permisos.C;
            pnlProcesadores.Visible = false;
            pnlFormulario.Visible = true;
            lblIdProcesador.Value = string.Empty;
            //lblIdSistemaOperativo.Attributes["style"] = "display: none;";
            txtNombre.Text = string.Empty;
            txtNumCores.Text = string.Empty;
            txtVelocidad.Text = string.Empty;
            txtCache.Text = string.Empty;
            llenarDdlTamanoPalabra();
        }//Fin de Boton Nuevo

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            btnNuevo.Visible = true;
            btnNuevo.Text = "Nuevo";
            pnlProcesadores.Visible = true;
            pnlFormulario.Visible = false;
        }//Fin de Boton Cancelar


        protected void gdvProcesadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "2";
            lblStatus.Text = string.Empty;
            btnNuevo.Visible = false;
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = permisos.U;
            pnlProcesadores.Visible = false;
            pnlFormulario.Visible = true;
            lblIdProcesador.Value = gdvProcesadores.SelectedRow.Cells[1].Text;

            txtNombre.Text = HttpUtility.HtmlDecode(gdvProcesadores.SelectedRow.Cells[2].Text);
            txtNumCores.Text = HttpUtility.HtmlDecode(gdvProcesadores.SelectedRow.Cells[3].Text);
            txtVelocidad.Text = HttpUtility.HtmlDecode(gdvProcesadores.SelectedRow.Cells[4].Text);
            txtCache.Text = HttpUtility.HtmlDecode(gdvProcesadores.SelectedRow.Cells[5].Text);
            llenarDdlTamanoPalabra();
            ddlTamanoPalabra.SelectedValue = gdvProcesadores.SelectedRow.Cells[6].Text == "&nbsp;" ? "0" : gdvProcesadores.SelectedRow.Cells[6].Text;

        }//Fin de Seleccionar en Gridview

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            lblStatus.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            if (hdfEstado.Value == "1" && permisos.C == true)
            {
                resultado = Negocio.Catalogos.Procesador.Nuevo(new Entidades.Procesador()
                {
                    Nombre = txtNombre.Text,
                    NumCores = Convert.ToInt32(txtNumCores.Text),
                    Velocidad = txtVelocidad.Text,
                    Cache = txtCache.Text,
                    TamanoPalabra = !string.IsNullOrWhiteSpace(ddlTamanoPalabra.SelectedValue)? ddlTamanoPalabra.SelectedValue:null
                });
            }
            else if (hdfEstado.Value == "2" && permisos.U == true)
            {
                resultado = Negocio.Catalogos.Procesador.Actualizar(new Entidades.Procesador()
                {
                    IdProcesador = Convert.ToInt32(lblIdProcesador.Value),
                    Nombre = txtNombre.Text,
                    NumCores = Convert.ToInt32(txtNumCores.Text),
                    Velocidad = txtVelocidad.Text,
                    Cache = txtCache.Text,
                    TamanoPalabra = !string.IsNullOrWhiteSpace(ddlTamanoPalabra.SelectedValue) ? ddlTamanoPalabra.SelectedValue : null
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
                pnlProcesadores.Visible = true;
                pnlFormulario.Visible = false;
                llenarGdvProcesadores();
            }
        }//Fin de boton Guardar

        protected void gdvProcesadores_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gdvProcesadores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblStatus.Text = string.Empty;
            int IdProcesador = Convert.ToInt32(gdvProcesadores.Rows[e.RowIndex].Cells[1].Text);
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            resultado = Negocio.Catalogos.Procesador.Eliminar(new Entidades.Procesador()
            {
                IdProcesador = IdProcesador
            });

            resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
            {
                lblStatus.Text += error.descripcionCorta + "<br/>";
            });

            lblStatus.ForeColor = System.Drawing.Color.Red;
            if (resultado.resultado == true)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                llenarGdvProcesadores();
            }
        }//Fin eliminar Fila

    }//Fin de la Clase
}