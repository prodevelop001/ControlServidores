using System;
using System.Collections.Generic;
using System.Linq;

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
                        imprimirTitulo();                        
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

        private void imprimirTitulo()
        {
            Entidades.Servidor nServidor = new Entidades.Servidor();

            List<Entidades.Servidor> s = new List<Entidades.Servidor>();
            s = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor()
            {
                IdServidor = _IdServidor,
                Modelo = null,
                Especificacion = null,
                TipoServidor = null,
                Estatus = null,
                AliasServidor = null,
                IdVirtualizador = -1,
                DescripcionUso = null
            }
            );
            if(s.Count > 0)
            {
                nServidor = s.First();
                lblNombreServidor.Text = nServidor.AliasServidor;
                lblNombreServidor.Attributes["style"] = "text-transform: uppercase;";
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