using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Catalogos
{
    public partial class TipoStorage : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 19;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    if (permisos.R == true)
                    {
                        pnlTipoStorage.Visible = true;
                        pnlFormulario.Visible = false;
                        pnlResultado.Visible = false;
                        llenarGdvTiposStorage();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }//Fin de Void

        private void llenarGdvTiposStorage()
        {

            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();

            gdvTiposStorage.DataSource = Negocio.Catalogos.TipoStorage.Obtener(new Entidades.TipoStorage());
            gdvTiposStorage.DataBind();
        }//Fin de Llenar Gridview SOs

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "1";
            lblStatus.Text = string.Empty;
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = permisos.C;
            pnlTipoStorage.Visible = false;
            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            lblIdTipoStorage.Value = string.Empty;
            //lblIdSistemaOperativo.Attributes["style"] = "display: none;";
            txtTipoStorage.Text = string.Empty;
        }//Fin de Boton Nuevo

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            btnNuevo.Visible = true;
            btnNuevo.Text = "Nuevo";
            pnlTipoStorage.Visible = true;
            pnlFormulario.Visible = false;
            pnlResultado.Visible = false;
        }//Fin de Boton Cancelar


        protected void gdvTiposStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "2";
            lblStatus.Text = string.Empty;
            btnNuevo.Visible = false;
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = permisos.U;
            pnlTipoStorage.Visible = false;
            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            lblIdTipoStorage.Value = gdvTiposStorage.SelectedRow.Cells[1].Text;

            txtTipoStorage.Text = HttpUtility.HtmlDecode(gdvTiposStorage.SelectedRow.Cells[2].Text);
        }//Fin de Seleccionar en Gridview

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            lblStatus.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            if (hdfEstado.Value == "1" && permisos.C == true)
            {
                resultado = Negocio.Catalogos.TipoStorage.Nuevo(new Entidades.TipoStorage()
                {
                    Tipo = txtTipoStorage.Text
                });
            }
            else if (hdfEstado.Value == "2" && permisos.U == true)
            {
                resultado = Negocio.Catalogos.TipoStorage.Actualizar(new Entidades.TipoStorage()
                {
                    IdTipoStorage = Convert.ToInt32(lblIdTipoStorage.Value),
                    Tipo = txtTipoStorage.Text
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
                pnlTipoStorage.Visible = true;
                pnlFormulario.Visible = false;
                llenarGdvTiposStorage();
            }
            pnlResultado.Visible = true;
        }//Fin de boton Guardar

        protected void gdvTiposStorage_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gdvTiposStorage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblStatus.Text = string.Empty;
            int IdTipoStorage = Convert.ToInt32(gdvTiposStorage.Rows[e.RowIndex].Cells[1].Text);
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            resultado = Negocio.Catalogos.TipoStorage.Eliminar(new Entidades.TipoStorage()
            {
                IdTipoStorage = IdTipoStorage
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
                llenarGdvTiposStorage();
            }
            pnlResultado.Visible = true;
        }//Fin eliminar Fila

    }//Fin de la Clase
}