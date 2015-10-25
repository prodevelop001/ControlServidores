using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Controles
{
    public partial class StorageC : System.Web.UI.UserControl
    {
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
                hdfIdServidor.Value = _IdServidor.ToString();
                llenarDdlTipoSt();
                llenarGdvStorage();
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
            if (ddlTipoStorageForm.SelectedValue != "0" && ddlCapacidad.SelectedValue != "0")
            {
                Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
                ObtenerParametros();

                Entidades.Storage storage = new Entidades.Storage();
                storage.Servidor.IdServidor = _IdServidor;
                storage.TipoStorage.IdTipoStorage = Convert.ToInt32(ddlTipoStorageForm.SelectedValue);
                storage.Estatus = null;
                storage.CapacidadAsignada = txtCapacidad.Text.Trim() + " " + ddlCapacidad.SelectedValue;
                if(hdfEstado.Value == "1")
                {
                    resultado = Negocio.Inventarios.Storage.Nuevo(storage);
                }
                else
                {
                    storage.IdStorage = Convert.ToInt32(hdfStorage.Value);
                    resultado = Negocio.Inventarios.Storage.Actualizar(storage);
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
    }
}