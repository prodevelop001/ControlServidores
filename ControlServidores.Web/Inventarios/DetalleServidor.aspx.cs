using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                datosPrincipales();
                InterfacesRed();
                VMs();
                Almacenamiento();
                SistemasO();
                Storage();
                Bitacora();
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

        private void datosPrincipales()
        {
            List<Entidades.Servidor> servidores = new List<Entidades.Servidor>();
            servidores = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdServidor = _IdServidor, IdVirtualizador = -1 });
            if(servidores.Count > 0)
            {
                lblAliasServidor.Text = servidores.First().AliasServidor;
                lblDescripcionUso.Text = servidores.First().DescripcionUso;
                lblTipoServidor.Text = servidores.First().TipoServidor.Tipo;
                hdfIdModelo.Value = servidores.First().IdModelo.ToString();
                lblModelo.Text = servidores.First().Modelo.NombreModelo;
                lblNumProcesadores.Text = servidores.First().Especificacion.NumProcesadores.ToString();
                lblCapacidadRam.Text = servidores.First().Especificacion.CapacidadRAM;
                lblProcesador.Text = servidores.First().Especificacion.Procesador.Nombre + "<br>";
                lblProcesador.Text += servidores.First().Especificacion.Procesador.NumCores.ToString() + " Core(s) <br>";
                lblProcesador.Text += "Velocidad de " + servidores.First().Especificacion.Procesador.Velocidad + "<br>";
                lblProcesador.Text += "Cache " + servidores.First().Especificacion.Procesador.Cache + "<br>";
                lblProcesador.Text += "Tamaño de instrucción " + servidores.First().Especificacion.Procesador.TamanoPalabra + "<br>";
                lblArregloDiscos.Text = servidores.First().Especificacion.TipoArregloDisco.Tipo;
            }
            lblSoporte.ForeColor = System.Drawing.Color.Red;
            List<Entidades.Soporte> soporte = new List<Entidades.Soporte>();
            int IdModelo = !string.IsNullOrEmpty(hdfIdModelo.Value) ? Convert.ToInt32(hdfIdModelo.Value) : -1;
            soporte = Negocio.Inventarios.Soporte.Obtener(new Entidades.Soporte() { IdModelo = IdModelo });
            if(soporte.Count > 0)
            {
                lblSoporte.ForeColor = System.Drawing.Color.Green;
                lblSoporte.Text = " de ";
                lblSoporte.Text += ((DateTime)soporte.First().FechaInicio).ToString("dd/MM/yyyy") + " a ";
                lblSoporte.Text += ((DateTime)soporte.First().FechaFin).ToString("dd/MM/yyyy") + "<br>";
                lblSoporte.Text += soporte.First().Empresa.Nombre + "<br>";
                lblSoporte.Text += "Tel:" + soporte.First().Empresa.Telefono + "<br>";
            }
        }

        private void InterfacesRed()
        {
            gdvInterfacesRed.DataSource = Negocio.Inventarios.ConfRed.Obtener(new Entidades.ConfRed() { IdServidor = _IdServidor });
            gdvInterfacesRed.DataBind();
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

        private void Almacenamiento()
        {
            gdvAlmacenamiento.DataSource = Negocio.Inventarios.Almacenamiento.Obtener(new Entidades.Almacenamiento() { IdServidor = _IdServidor });
            gdvAlmacenamiento.DataBind();
        }

        private void SistemasO()
        {
            gdvSos.DataSource = Negocio.Inventarios.SOxServidor.Obtener(new Entidades.SOxServidor() { IdServidor = _IdServidor });
            gdvSos.DataBind();
        }

        private void Storage()
        {
            gdvStorage.DataSource = Negocio.Inventarios.Storage.Obtener(new Entidades.Storage() { IdServidor = _IdServidor });
            gdvStorage.DataBind();
        }

        private void Bitacora()
        {
            gdvBitacora.DataSource = Negocio.Inventarios.PersonaXservidor.Obtener(new Entidades.PersonaXservidor() { IdServidor = _IdServidor });
            gdvBitacora.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}