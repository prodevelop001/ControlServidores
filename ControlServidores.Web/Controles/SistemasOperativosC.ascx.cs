using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Controles
{
    public partial class SistemasOperativosC : System.Web.UI.UserControl
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
                hdfIdSoServidor.Value = _IdServidor.ToString();
                llenarGdvSO();
            }
        }

        private void ObtenerParametros()
        {
            _IdServidor = Convert.ToInt32(hdfIdSoServidor.Value);
        }

        private void llenarDdlSO()
        {
            ddlSO.DataTextField = "NombreSO";
            ddlSO.DataValueField = "IdSO";
            ddlSO.DataSource = Negocio.Catalogos.SO.Obtener(new Entidades.SO());
            ddlSO.DataBind();
        }

        private void llenarGdvSO()
        {
            gdvSO.DataSource = Negocio.Inventarios.SOxServidor.Obtener(new Entidades.SOxServidor() { Servidor= new Entidades.Servidor() { IdServidor= _IdServidor },Estatus= null });
            gdvSO.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "1";
            pnlForm.Visible = true;
            pnlSO.Visible = false;
            btnGuardar.Text = "Guardar";
            llenarGdvSO();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            pnlForm.Visible = false;
            pnlSO.Visible = true;
        }
    }
}