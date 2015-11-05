using System;

namespace ControlServidores.Web.Inventarios
{
    public partial class DetalleServidor : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();

        private int _IdServidor;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 2;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    if (permisos.R == true)
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
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
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