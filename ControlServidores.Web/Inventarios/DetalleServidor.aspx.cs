using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlServidores.Web.Inventarios
{
    public partial class DetalleServidor : System.Web.UI.Page
    {
        private int _IdServidor;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ObtenerParametros();
                VMs();
                CaracteristicasC.IdServidor = _IdServidor;
                AlmacenamientoC.IdServidor = _IdServidor;
                InterfacesRedC.IdServidor = _IdServidor;
                SistemasOperativosC.IdServidor = _IdServidor;
                StorageC.IdServidor = _IdServidor;
                BitacoraC.IdServidor = _IdServidor;
            }
        }

        private void ObtenerParametros()
        {
            try
            {
            _IdServidor = Convert.ToInt32(Request.QueryString["IdServidor"] ?? "0");
            }
            catch
            {
                Response.Redirect("~/Inventarios/Servidores.aspx");
            }
            if (_IdServidor == 0)
            {
                Response.Redirect("~/Inventarios/Servidores.aspx");
            }
        }

        private void VMs()
        {
            gdvVMs.DataSource = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdVirtualizador = _IdServidor });
            gdvVMs.DataBind();
            if(gdvVMs.Rows.Count > 0)
            {
                pnlVms.Visible = true;
            }
        }
    }
}