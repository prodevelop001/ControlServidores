using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Controles
{
    public partial class StorageC : System.Web.UI.UserControl
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
            if(!IsPostBack)
            {
                permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                if (permisos.R == true)
                {
                    hdfIdServidor.Value = _IdServidor.ToString();
                    llenarDdlTipoSt();
                    llenarGdvStorage();
                }
                btnAgregar.Enabled = permisos.C;
            }
        }

        private void ObtenerParametros()
        {
            _IdServidor = Convert.ToInt32(hdfIdServidor.Value);
        }

        private void llenarDdlTipoSt()
        {
            ddlTipoStorageForm.Items.Clear();
            ddlTipoStorageForm.AppendDataBoundItems = true;
            ddlTipoStorageForm.Items.Add(new ListItem("-- Seleccionar --","0"));
            ddlTipoStorageForm.DataTextField = "Tipo";
            ddlTipoStorageForm.DataValueField = "IdTipoStorage";
            ddlTipoStorageForm.DataSource = Negocio.Catalogos.TipoStorage.Obtener(new Entidades.TipoStorage());
            ddlTipoStorageForm.DataBind();

            ddlTipoStorage.Items.Clear();
            ddlTipoStorage.AppendDataBoundItems = true;
            ddlTipoStorage.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlTipoStorage.DataTextField = "Tipo";
            ddlTipoStorage.DataValueField = "IdTipoStorage";
            ddlTipoStorage.DataSource = Negocio.Catalogos.TipoStorage.Obtener(new Entidades.TipoStorage());
            ddlTipoStorage.DataBind();
        }

        private void llenarGdvStorage()
        {
            Entidades.Storage storage = new Entidades.Storage();
            storage.Servidor.IdServidor = _IdServidor;
            storage.TipoStorage.IdTipoStorage = Convert.ToInt32(ddlTipoStorage.SelectedValue);
            storage.Estatus = null;
            gdvStorage.DataSource = Negocio.Inventarios.Storage.Obtener(storage);
            gdvStorage.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            hdfEstado.Value = "1";
            btnGuardar.Text = "Guardar";
            pnlForm.Visible = true;
            pnlStorage.Visible = false;
            ddlTipoStorage.SelectedValue = "0";
            ddlCapacidad.SelectedValue = "0";
            txtCapacidad.Text = string.Empty;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
            pnlStorage.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            lblResultado.ForeColor = System.Drawing.Color.Red;
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            if (ddlTipoStorageForm.SelectedValue != "0" && ddlCapacidad.SelectedValue != "0")
            {
                Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
                ObtenerParametros();

                Entidades.Storage storage = new Entidades.Storage();
                storage.Servidor.IdServidor = _IdServidor;
                storage.TipoStorage.IdTipoStorage = Convert.ToInt32(ddlTipoStorageForm.SelectedValue);
                storage.Estatus = null;
                storage.CapacidadAsignada = txtCapacidad.Text.Trim() + " " + ddlCapacidad.SelectedValue;

                if (hdfEstado.Value == "1" && permisos.C == true)
                {
                    resultado = Negocio.Inventarios.Storage.Nuevo(storage);
                }
                else
                {
                    lblResultado.Text = "No tienes privilegios para agregar items.";
                }

                if (hdfEstado.Value == "2" && permisos.U == true)
                {
                    storage.IdStorage = Convert.ToInt32(hdfStorage.Value);
                    resultado = Negocio.Inventarios.Storage.Actualizar(storage);
                }
                else
                {
                    lblResultado.Text = "No tienes privilegios para actualizar información";
                }

                resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                {
                    lblResultado.Text += error.descripcionCorta + "<br/>";
                });

                if (resultado.resultado == true)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Green;
                    hdfEstado.Value = "0";
                    pnlForm.Visible = false;
                    pnlStorage.Visible = true;
                    ObtenerParametros();
                    llenarGdvStorage();
                }
            }
            else
            {
                lblResultado.Text = "Revise el formulario, hay campos que no han sido seleccionados.";
            }
        }

        protected void ddlTipoStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerParametros();
            llenarGdvStorage();
        }

        protected void gdvStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            hdfEstado.Value = "2";
            pnlForm.Visible = true;
            pnlStorage.Visible = false;
            hdfStorage.Value = gdvStorage.SelectedRow.Cells[1].Text.Trim();
            ddlTipoStorageForm.SelectedValue = gdvStorage.SelectedRow.Cells[3].Text.Trim();
            txtCapacidad.Text = gdvStorage.SelectedRow.Cells[4].Text.Split(' ').ElementAt(0);
            ddlCapacidad.SelectedValue = gdvStorage.SelectedRow.Cells[4].Text.Split(' ').ElementAt(1);
        }

        protected void gdvStorage_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void gdvStorage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblResultado.Text = string.Empty;
            lblResultado.ForeColor = System.Drawing.Color.Red;
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            Entidades.Storage storage = new Entidades.Storage();
            storage.IdStorage = Convert.ToInt32(gdvStorage.Rows[e.RowIndex].Cells[1].Text);
            storage.Servidor = null;
            storage.TipoStorage = null;
            storage.Estatus = null;

            if(permisos.D == true)
            { 
                resultado = Negocio.Inventarios.Storage.Eliminar(storage);
                resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                {
                    lblResultado.Text += error.descripcionCorta + "<br/>";
                });

                if (resultado.resultado == true)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Green;
                    ObtenerParametros();
                    llenarGdvStorage();
                }
            }
            else
            {
                lblResultado.Text = "No tienes privilegios para eliminar información.";
            }
        }
    }
}