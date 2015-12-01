using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Controles
{
    public partial class AlmacenamientoC : System.Web.UI.UserControl
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();

        private int _IdServidor;

        public int IdServidor
        {
            get
            {
                return _IdServidor;
            }

            set
            {
                _IdServidor = value;
            }
        }     

        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!IsPostBack)
            {
                permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                if (permisos.R == true)
                {
                    hdfIdServidor.Value = _IdServidor.ToString();
                    llenarGdvAlmacenamiento();
                }
                btnAgregar.Enabled = permisos.C;
            }            
        }

        private void ObtenerParametros()
        {
            _IdServidor = Convert.ToInt32(hdfIdServidor.Value);
        }

        private void Limpiar()
        {
            txtUnidad.Text = string.Empty;
            txtCapacidad.Text = string.Empty;
            ddlCapacidad.SelectedValue = "0";
        }

        private void llenarDdlTipoMemoria()
        {
            ddlTipoAlmacenamiento.Items.Clear();
            ddlTipoAlmacenamiento.AppendDataBoundItems = true;
            ddlTipoAlmacenamiento.Items.Add(new ListItem("-- Seleccionar --","0"));
            ddlTipoAlmacenamiento.DataTextField = "Tipo";
            ddlTipoAlmacenamiento.DataValueField = "IdTipoMemoria";
            ddlTipoAlmacenamiento.DataSource = Negocio.Catalogos.TipoMemoria.Obtener(new Entidades.TipoMemoria());
            ddlTipoAlmacenamiento.DataBind();
        }

        private void llenarGdvAlmacenamiento()
        {
            gdvAlmacenamiento.DataSource = Negocio.Inventarios.Almacenamiento.Obtener(new Entidades.Almacenamiento() { IdServidor = _IdServidor, TipoMemoria = null });
            gdvAlmacenamiento.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "1";
            lblResultado.Text = string.Empty;
            pnlForm.Visible = true;
            pnlAlmacenamiento.Visible = false;
            btnGuardar.Text = "Guardar";
            Limpiar();
            llenarDdlTipoMemoria();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            pnlForm.Visible = false;
            pnlAlmacenamiento.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            lblResultado.Text = string.Empty;
            lblResultado.ForeColor = System.Drawing.Color.Red;
            if (ddlTipoAlmacenamiento.SelectedValue != "0" && ddlCapacidad.SelectedValue != "0")
            {
                Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();

                Entidades.Almacenamiento alm = new Entidades.Almacenamiento();
                alm.IdServidor = Convert.ToInt32(hdfIdServidor.Value);
                alm.Unidad = txtUnidad.Text.Trim();
                alm.TipoMemoria.IdTipoMemoria = Convert.ToInt32(ddlTipoAlmacenamiento.SelectedValue);
                alm.Capacidad = txtCapacidad.Text.Trim() + " " + ddlCapacidad.SelectedValue;
                if(hdfEstado.Value == "1" && permisos.C == true)
                {
                    resultado = Negocio.Inventarios.Almacenamiento.Nuevo(alm);
                }
                else if(hdfEstado.Value == "2" && permisos.U == true)
                {
                    alm.IdAlmacenamiento = Convert.ToInt32(hdfIdAlmacenamiento.Value);
                    resultado = Negocio.Inventarios.Almacenamiento.Actualizar(alm);
                }
                else
                {
                    lblResultado.Text = "No tienes privilegios para realizar esta acción.";
                }

                resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                {
                    lblResultado.Text += error.descripcionCorta + "<br/>";
                });

                lblResultado.ForeColor = System.Drawing.Color.Red;
                if (resultado.resultado == true)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Green;
                    hdfEstado.Value = "0";
                    pnlForm.Visible = false;
                    pnlAlmacenamiento.Visible = true;
                    ObtenerParametros();
                    llenarGdvAlmacenamiento();
                }
            }
            else
            {
                lblResultado.Text = "Revise el formulario, hay campos que no han sido seleccionados.";
            }
        }

        protected void gdvAlmacenamiento_RowDataBound(object sender, GridViewRowEventArgs e)
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
                            //button.Enabled = permisos.D;
                            if (button.Enabled)
                                button.OnClientClick = "return checkMe()";
                        }
                    }
                }
            }
        }

        protected void gdvAlmacenamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdfEstado.Value = "2";
            btnGuardar.Text = "Actualizar";
            pnlForm.Visible = true;
            pnlAlmacenamiento.Visible = false;
            llenarDdlTipoMemoria();

            hdfIdAlmacenamiento.Value = gdvAlmacenamiento.SelectedRow.Cells[1].Text.Trim();
            txtUnidad.Text = gdvAlmacenamiento.SelectedRow.Cells[2].Text.Trim();
            ddlTipoAlmacenamiento.SelectedValue = gdvAlmacenamiento.SelectedRow.Cells[3].Text.Trim();
            txtCapacidad.Text = gdvAlmacenamiento.SelectedRow.Cells[5].Text.Split(' ').ElementAt(0);
            ddlCapacidad.SelectedValue = gdvAlmacenamiento.SelectedRow.Cells[5].Text.Split(' ').ElementAt(1);
        }

        protected void gdvAlmacenamiento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblResultado.Text = string.Empty;
            lblResultado.ForeColor = System.Drawing.Color.Red;
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            if(permisos.D)
            { 
                Entidades.Almacenamiento alm = new Entidades.Almacenamiento();
                alm.IdAlmacenamiento = Convert.ToInt32(gdvAlmacenamiento.Rows[e.RowIndex].Cells[1].Text);
                alm.TipoMemoria = null;

                Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
                resultado = Negocio.Inventarios.Almacenamiento.Eliminar(alm);

                resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                {
                    lblResultado.Text += error.descripcionCorta + "<br/>";
                });

                if (resultado.resultado == true)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Green;
                    ObtenerParametros();
                    llenarGdvAlmacenamiento();
                }
            }
            else
            {
                lblResultado.Text = "No tienes privilegios para eliminar información.";
            }
        }
    }
}