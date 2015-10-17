using System;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Controles
{
    public partial class InterfacesRedC : System.Web.UI.UserControl
    {
        private int _IdServidor;

        public int IdServidor
        {
            get { return _IdServidor; }

            set { _IdServidor = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdfIdConfRed.Value = _IdServidor.ToString();
                InterfacesRed();
            }
        }

        private void InterfacesRed()
        {
            gdvInterfacesRed.DataSource = Negocio.Inventarios.ConfRed.Obtener(new Entidades.ConfRed() { Servidor=new Entidades.Servidor() { IdServidor = _IdServidor } });
            gdvInterfacesRed.DataBind();
        }

        private void llenarDdlEstatus()
        {
            ddlEstatus.Items.Clear();
            ddlEstatus.AppendDataBoundItems = true;
            ddlEstatus.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlEstatus.DataTextField = "_Estatus";
            ddlEstatus.DataValueField = "IdEstatus";
            ddlEstatus.DataSource = Negocio.Catalogos.Estatus.Obtener(new Entidades.Estatus()
            {
                IdConceptoEstatus = 2
            });
            ddlEstatus.DataBind();
        }

        private void Limpiar()
        {
            txtInterfazRed.Text = string.Empty;
            txtDirMAC.Text = string.Empty;
            txtDirIP.Text = string.Empty;
            txtMascaraSubRed.Text = string.Empty;
            txtGateway.Text = string.Empty;
            txtDNS.Text = string.Empty;
            txtVlan.Text = string.Empty;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Limpiar();
            lblResultado.Text = string.Empty;
            pnlFormIntRed.Visible = true;
            gdvInterfacesRed.Visible = false;
            llenarDdlEstatus();
            hdfEstado.Value = "1";
            btnGuardar.Text = "Guardar";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            pnlFormIntRed.Visible = false;
            gdvInterfacesRed.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = "";
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
    
            if (ddlEstatus.SelectedValue != "0")
            {
                Entidades.ConfRed nuevaInterfaz = new Entidades.ConfRed();
                nuevaInterfaz.Servidor.IdServidor = Convert.ToInt32(hdfIdConfRed.Value);
                nuevaInterfaz.InterfazRed = txtInterfazRed.Text.Trim();
                nuevaInterfaz.DirMac = txtDirMAC.Text.Trim();
                nuevaInterfaz.DirIP = txtDirIP.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtGateway.Text.Trim()))
                    nuevaInterfaz.Gateway = txtGateway.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtDNS.Text.Trim()))
                    nuevaInterfaz.DNS = txtDNS.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtVlan.Text.Trim()))
                    nuevaInterfaz.VLAN = txtVlan.Text.Trim();
                nuevaInterfaz.Estatus.IdEstatus = Convert.ToInt32(ddlEstatus.SelectedValue);
                
                //Guardar
                if(hdfEstado.Value == "1")
                {
                    resultado = Negocio.Inventarios.ConfRed.Nuevo(nuevaInterfaz);
                }
                else if(hdfEstado.Value == "2") //actualizar
                {
                    nuevaInterfaz.IdConfRed = Convert.ToInt32(hdfIdConfRed.Value);
                    resultado = Negocio.Inventarios.ConfRed.Actualizar(nuevaInterfaz);
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
                    pnlFormIntRed.Visible = false;
                    gdvInterfacesRed.Visible = true;
                }
            }
            else
            {
                lblResultado.Text = "Debe seleccionar un estatus.";
            }
        }
    }
}