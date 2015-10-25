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
                datosPrincipales();
                VMs();
                InterfacesRedC.IdServidor = _IdServidor;
                SistemasOperativosC.IdServidor = _IdServidor;
                StorageC.IdServidor = _IdServidor;
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

        private void Almacenamiento()
        {
            gdvAlmacenamiento.DataSource = Negocio.Inventarios.Almacenamiento.Obtener(new Entidades.Almacenamiento() { IdServidor = _IdServidor });
            gdvAlmacenamiento.DataBind();
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

        private void Bitacora()
        {
            List<Entidades.PersonaXservidor> lista = new List<Entidades.PersonaXservidor>();
            lista = Negocio.Inventarios.PersonaXservidor.Obtener(new Entidades.PersonaXservidor() { Servidor = new Entidades.Servidor() { IdServidor = _IdServidor } });
            List<Entidades.PersonaXservidor> aux = new List<Entidades.PersonaXservidor>();
            aux = Negocio.Inventarios.PersonaXservidor.Obtener(new Entidades.PersonaXservidor() { Servidor = new Entidades.Servidor() { IdServidor = _IdServidor }, Personas= null });
            if(aux.Count> 0)
            {
                lista.Add(aux.First());
            }
            var todos = from l in lista
                        orderby l.IdPersonaServidor ascending
                        select l;

            gdvBitacora.DataSource = todos;
            gdvBitacora.DataBind();
        }
    }
}