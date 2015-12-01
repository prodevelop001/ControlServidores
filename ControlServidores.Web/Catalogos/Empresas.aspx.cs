using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web
{
    public partial class Empresas : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 11;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    if (permisos.R == true)
                    {
                        pnlEmpresa.Visible = true;
                        pnlFormulario.Visible = false;
                        pnlResultado.Visible = false;
                        llenarGdvEmpresas();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }

        private void llenarGdvEmpresas()
        {

            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();

            gdvEmpresas.DataSource = Negocio.Catalogos.Empresa.Obtener(new Entidades.Empresa());
            gdvEmpresas.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "1";
            lblStatus.Text = string.Empty;
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = permisos.C;
            pnlEmpresa.Visible = false;
            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            lblIdNombreEmpresa.Value = string.Empty;
            //lblIdNombreEmpresa.Attributes["style"] = "display: none;";
            txtEmpresa.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            btnNuevo.Visible = true;
            btnNuevo.Text = "Nuevo";
            pnlEmpresa.Visible = true;
            pnlFormulario.Visible = false;
            pnlResultado.Visible = false;
        }

        protected void gdvEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "2";
            lblStatus.Text = string.Empty;
            btnNuevo.Visible = false;
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = permisos.U;
            pnlEmpresa.Visible = false;
            pnlFormulario.Visible = true;
            pnlResultado.Visible = false;
            lblIdNombreEmpresa.Value = gdvEmpresas.SelectedRow.Cells[1].Text;
            //lblIdNombreEmpresa.Visible=true;
            txtEmpresa.Text = HttpUtility.HtmlDecode(gdvEmpresas.SelectedRow.Cells[2].Text);
            txtTelefono.Text = HttpUtility.HtmlDecode(gdvEmpresas.SelectedRow.Cells[3].Text);
            txtDireccion.Text = HttpUtility.HtmlDecode(gdvEmpresas.SelectedRow.Cells[4].Text);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            lblStatus.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            if (hdfEstado.Value == "1" && permisos.C == true)
            //if (hdfEstado.Value == "1")
            {
                resultado = Negocio.Catalogos.Empresa.Nuevo(new Entidades.Empresa()
                {
                    Nombre = txtEmpresa.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                });
            }
            else if (hdfEstado.Value == "2" && permisos.U == true)
            //else if (hdfEstado.Value == "2")
            {
                resultado = Negocio.Catalogos.Empresa.Actualizar(new Entidades.Empresa()
                {
                    IdEmpresa = Convert.ToInt32(lblIdNombreEmpresa.Value),
                    Nombre = txtEmpresa.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
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
                pnlEmpresa.Visible = true;
                pnlFormulario.Visible = false;
                llenarGdvEmpresas();
            }
            pnlResultado.Visible = true;
        }

        protected void gdvEmpresas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        //LinkButton button = (LinkButton)control;
                        LinkButton button = control as LinkButton;
                        if (button != null && button.Text == " Eliminar")
                        {
                            button.Enabled = permisos.D;
                            if (button.Enabled)
                                button.OnClientClick = "return checkMe()";
                        }
                    }
                }
            }
        }

        protected void gdvConceptos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblStatus.Text = string.Empty;
            int IdEmpresa = Convert.ToInt32(gdvEmpresas.Rows[e.RowIndex].Cells[1].Text);
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            resultado = Negocio.Catalogos.Empresa.Eliminar(new Entidades.Empresa()
            {
                IdEmpresa = IdEmpresa
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
                llenarGdvEmpresas();
            }
            pnlResultado.Visible = true;
        }



    }
}