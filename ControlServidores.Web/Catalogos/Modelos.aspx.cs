using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Catalogos
{
    public partial class Modelos : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 14;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    if (permisos.R == true)
                    {
                        pnlNombreModelo.Visible = true;
                        pnlFormulario.Visible = false;
                        llenarGdvModelos();
                        llenarDdlMarcas();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }//Fin de Void

        private void llenarGdvModelos()
        {

            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();

            gdvNombreModelo.DataSource = Negocio.Catalogos.Modelo.Obtener(new Entidades.Modelo());
            gdvNombreModelo.DataBind();
        }//Fin de Llenar Gridview SOs

        private void llenarDdlMarcas()
        {
            ddlMarca.Items.Clear();
            ddlMarca.AppendDataBoundItems = true;
            ddlMarca.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlMarca.DataTextField = "NombreMarca";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataSource = Negocio.Catalogos.MarcaServidor.obtenerMarcaServidor(new Entidades.MarcaServidor());
            ddlMarca.DataBind();
        }//Fin de Llenar Marca

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "1";
            lblStatus.Text = string.Empty;
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = permisos.C;
            pnlNombreModelo.Visible = false;
            pnlFormulario.Visible = true;
            lblIdModelo.Value = string.Empty;
            //lblIdSistemaOperativo.Attributes["style"] = "display: none;";
            //txtMarca.Text = string.Empty;
            txtNombreModelo.Text = string.Empty;
        }//Fin de Boton Nuevo

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            btnNuevo.Visible = true;
            btnNuevo.Text = "Nuevo";
            pnlNombreModelo.Visible = true;
            pnlFormulario.Visible = false;
        }//Fin de Boton Cancelar


        protected void gdvNombreModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "2";
            lblStatus.Text = string.Empty;
            btnNuevo.Visible = false;
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = permisos.U;
            pnlNombreModelo.Visible = false;
            pnlFormulario.Visible = true;
            lblIdModelo.Value = gdvNombreModelo.SelectedRow.Cells[1].Text;

            txtMarca.Text = gdvNombreModelo.SelectedRow.Cells[2].Text;
            txtNombreModelo.Text = gdvNombreModelo.SelectedRow.Cells[3].Text;
        }//Fin de Seleccionar en Gridview

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            lblStatus.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            if (hdfEstado.Value == "1" && permisos.C == true)
            {
                resultado = Negocio.Catalogos.Modelo.Nuevo(new Entidades.Modelo()
                {
                    IdMarca = Convert.ToInt32(txtMarca.Text),
                    NombreModelo = txtNombreModelo.Text
                });
            }
            else if (hdfEstado.Value == "2" && permisos.U == true)
            {
                resultado = Negocio.Catalogos.Modelo.Actualizar(new Entidades.Modelo()
                {
                    IdModelo = Convert.ToInt32(lblIdModelo.Value),
                    IdMarca = Convert.ToInt32(txtMarca.Text),
                    NombreModelo = txtNombreModelo.Text
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
                pnlNombreModelo.Visible = true;
                pnlFormulario.Visible = false;
                llenarGdvModelos();
            }
        }//Fin de boton Guardar

        protected void gdvNombreModelo_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gdvNombreModelo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblStatus.Text = string.Empty;
            int IdModelo = Convert.ToInt32(gdvNombreModelo.Rows[e.RowIndex].Cells[1].Text);
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            resultado = Negocio.Catalogos.Modelo.Eliminar(new Entidades.Modelo()
            {
                IdModelo = IdModelo
            });

            resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
            {
                lblStatus.Text += error.descripcionCorta + "<br/>";
            });

            lblStatus.ForeColor = System.Drawing.Color.Red;
            if (resultado.resultado == true)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                llenarGdvModelos();
            }
        }//Fin eliminar Fila

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            //llenarDdlMarcas();
            llenarGdvModelos();
        }
    }//Fin de Clase
}