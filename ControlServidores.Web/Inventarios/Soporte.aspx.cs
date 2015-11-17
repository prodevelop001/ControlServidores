using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Inventarios
{
    public partial class Soporte : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 7;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    if (permisos.R == true)
            {
                llenarGdvSoporte();
                Empresas();
                llenarDdlMarcas();
                llenarDdlModelo();
                pnlResultado.Visible = false;
                //pnlResultado.Visible = false;
                txtFechaIni.Text = DateTime.Now.ToShortDateString();
                txtFechaFin.Text = DateTime.Now.ToShortDateString();
            }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }

        private void Empresas()
        {
            ddlEmpresa.Items.Clear();
            ddlEmpresa.AppendDataBoundItems = true;
            ddlEmpresa.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlEmpresa.DataTextField = "Nombre";
            ddlEmpresa.DataValueField = "IdEmpresa";
            ddlEmpresa.DataSource = Negocio.Catalogos.Empresa.Obtener(new Entidades.Empresa());
            ddlEmpresa.DataBind();
        }

        private void llenarDdlMarcas()
        {
            ddlMarca.Items.Clear();
            ddlMarca.AppendDataBoundItems = true;
            ddlMarca.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlMarca.DataTextField = "NombreMarca";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataSource = Negocio.Catalogos.MarcaServidor.obtenerMarcaServidor(new Entidades.MarcaServidor());
            ddlMarca.DataBind();
        }

        private void llenarDdlModelo()
        {
            ddlModelo.Items.Clear();
            ddlModelo.AppendDataBoundItems = true;
            ddlModelo.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlModelo.DataTextField = "NombreModelo";
            ddlModelo.DataValueField = "IdModelo";
            ddlModelo.DataSource = Negocio.Catalogos.Modelo.Obtener(new Entidades.Modelo() { IdMarca = Convert.ToInt32(ddlMarca.SelectedValue) });
            ddlModelo.DataBind();
        }

        private void llenarGdvSoporte()
        {
            gdvSoporte.DataSource = Negocio.Inventarios.Soporte.Obtener(new Entidades.Soporte());
            gdvSoporte.DataBind();
        }

        private void Limpiar()
        {
            ddlEmpresa.SelectedValue = "0";
            ddlMarca.SelectedValue = "0";
            ddlModelo.SelectedValue = "0";
            txtFechaIni.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarDdlModelo();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "1";
            btnGuardar.Text = "Guardar";
            pnlForm.Visible = true;
            pnlSoporte.Visible = false;
            llenarGdvSoporte();
            Empresas();
            llenarDdlMarcas();
            llenarDdlModelo();
            pnlResultado.Visible = false;
            //pnlResultado.Visible = false;
            txtFechaIni.Text = DateTime.Now.ToShortDateString();
            txtFechaFin.Text = DateTime.Now.ToShortDateString();
            Limpiar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            pnlForm.Visible = false;
            //pnlResultado.Visible = false;
            pnlSoporte.Visible = true;
            pnlResultado.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            //lblResultado.ForeColor = System.Drawing.Color.Red;
            lblResultado.Attributes["style"] = "color: #F00;";
            pnlResultado.Attributes["style"] = "background: rgba(252, 55, 55, 0.2);";
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();

            if (ddlEmpresa.SelectedValue != "0" && ddlModelo.SelectedValue != "0")
            {
                Entidades.Soporte soporte = new Entidades.Soporte();
                soporte.Empresa.IdEmpresa = Convert.ToInt32(ddlEmpresa.SelectedValue);
                soporte.Modelo.IdModelo = Convert.ToInt32(ddlModelo.SelectedValue);
                soporte.FechaInicio = Convert.ToDateTime(txtFechaIni.Text.Trim());
                soporte.FechaFin = Convert.ToDateTime(txtFechaFin.Text.Trim());

                if (hdfEstado.Value == "1" && permisos.C == true)
                { 
                    resultado = Negocio.Inventarios.Soporte.Nuevo(soporte);
                }
                else if(hdfEstado.Value == "2" && permisos.U == true)
                {
                    soporte.IdSoporte = Convert.ToInt32(hdfIdSoporte.Value);
                    resultado = Negocio.Inventarios.Soporte.Actualizar(soporte);
                }
                else
                {
                    lblResultado.Text = "No tiene privilegios para realizar esta acción. <br>";
                }

                resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                {
                    lblResultado.Text += error.descripcionCorta + "<br>";
                });

                if (resultado.resultado == true)
                {
                    //lblResultado.ForeColor = System.Drawing.Color.Green;
                    lblResultado.Attributes["style"] = "color: #008000;";
                    pnlResultado.Attributes["style"] = "background: rgba(147, 252, 55, 0.22);";
                    pnlForm.Visible = false;
                    pnlSoporte.Visible = true;
                    llenarGdvSoporte();
                }
            }
            else
            {
                lblResultado.Text = "Hay campos que no han sido seleccionados.";
            }
            pnlResultado.Visible = true;
        }

        protected void gdvSoporte_SelectedIndexChanged(object sender, EventArgs e)
        {          
            lblResultado.Text = string.Empty;
            hdfEstado.Value = "2";
            pnlForm.Visible = true;
            pnlSoporte.Visible = false;
            hdfIdSoporte.Value = gdvSoporte.SelectedRow.Cells[1].Text;
            Empresas();
            ddlEmpresa.SelectedValue = gdvSoporte.SelectedRow.Cells[2].Text;
            llenarDdlMarcas();
            ddlMarca.SelectedValue = gdvSoporte.SelectedRow.Cells[4].Text;
            llenarDdlModelo();
            pnlResultado.Visible = false;
            ddlModelo.SelectedValue = gdvSoporte.SelectedRow.Cells[5].Text;
            txtFechaIni.Text = gdvSoporte.SelectedRow.Cells[7].Text;
            txtFechaFin.Text = gdvSoporte.SelectedRow.Cells[8].Text;
        }

        protected void gdvSoporte_RowDataBound(object sender, GridViewRowEventArgs e)
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
                            //button.Enabled = permisos.D;
                            if (button.Enabled)
                                button.OnClientClick = "return checkMe()";
                        }
                    }
                }
            }
        }

        protected void gdvSoporte_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblResultado.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();

            Entidades.Soporte soporte = new Entidades.Soporte();
            soporte.IdSoporte = Convert.ToInt32(gdvSoporte.Rows[e.RowIndex].Cells[1].Text.Trim());
            soporte.Modelo = null;
            soporte.Empresa = null;

            resultado.resultado = permisos.D;

            if(resultado.resultado == true)
            { 
                resultado = Negocio.Inventarios.Soporte.Eliminar(soporte);
            }
            else
            {
                lblResultado.Text = "No tienes privilegios para realizar esta acción.";
            }

            resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
            {
                lblResultado.Text += error.descripcionCorta + "<br/>";
            });
            lblResultado.Attributes["style"] = "color: #F00;";
            pnlResultado.Attributes["style"] = "background: rgba(252, 55, 55, 0.2);";
            if (resultado.resultado == true)
            {
                //lblResultado.ForeColor = System.Drawing.Color.Green;
                lblResultado.Attributes["style"] = "color: #008000;";
                pnlResultado.Attributes["style"] = "background: rgba(147, 252, 55, 0.22);";
                llenarGdvSoporte();
            }
            pnlResultado.Visible = true;
        }
    }
}