using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Catalogos
{
    public partial class Marcas : System.Web.UI.Page
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
                        pnlMarca.Visible = true;
                        pnlFormulario.Visible = false;
                        pnlResultado.Visible = false;
                        llenarGdvMarcas();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }//Fin de Void

        private void llenarGdvMarcas()
        {

            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();

            gdvMarcas.DataSource = Negocio.Catalogos.MarcaServidor.obtenerMarcaServidor(new Entidades.MarcaServidor());
            gdvMarcas.DataBind();
        }//Fin de Llenar Gridview SOs

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "1";
            lblStatus.Text = string.Empty;
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = permisos.C;
            pnlMarca.Visible = false;
            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            lblIdMarca.Value = string.Empty;
            //lblIdSistemaOperativo.Attributes["style"] = "display: none;";
            txtMarca.Text = string.Empty;
        }//Fin de Boton Nuevo

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            btnNuevo.Visible = true;
            btnNuevo.Text = "Nuevo";
            pnlMarca.Visible = true;
            pnlFormulario.Visible = false;
            pnlResultado.Visible = false;
        }//Fin de Boton Cancelar


        protected void gdvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "2";
            lblStatus.Text = string.Empty;
            btnNuevo.Visible = false;
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = permisos.U;
            pnlMarca.Visible = false;
            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            lblIdMarca.Value = HttpUtility.HtmlDecode(gdvMarcas.SelectedRow.Cells[1].Text);

            txtMarca.Text = HttpUtility.HtmlDecode(gdvMarcas.SelectedRow.Cells[2].Text);
        }//Fin de Seleccionar en Gridview

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            lblStatus.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            if (hdfEstado.Value == "1" && permisos.C == true)
            {
                resultado = Negocio.Catalogos.MarcaServidor.Nuevo(new Entidades.MarcaServidor()
                {
                    NombreMarca = txtMarca.Text
                });
            }
            else if (hdfEstado.Value == "2" && permisos.U == true)
            {
                resultado = Negocio.Catalogos.MarcaServidor.Actualizar(new Entidades.MarcaServidor()
                {
                    IdMarca = Convert.ToInt32(lblIdMarca.Value),
                    NombreMarca = txtMarca.Text
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
                pnlMarca.Visible = true;
                pnlFormulario.Visible = false;
                llenarGdvMarcas();
            }
            pnlResultado.Visible = true;
        }//Fin de boton Guardar

        protected void gdvMarcas_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gdvMarcas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblStatus.Text = string.Empty;
            int IdMarca = Convert.ToInt32(gdvMarcas.Rows[e.RowIndex].Cells[1].Text);
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            resultado = Negocio.Catalogos.MarcaServidor.Eliminar(new Entidades.MarcaServidor()
            {
                IdMarca = IdMarca
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
                llenarGdvMarcas();
            }
            pnlResultado.Visible = true;
        }//Fin eliminar Fila
    }//Fin de la Clase
}