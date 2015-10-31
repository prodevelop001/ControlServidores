using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Controles
{
    public partial class CaracteristicasC : System.Web.UI.UserControl
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
                datosPrincipales();
            }
        }

        private void ObtenerDatos()
        {
            try
            {
                _IdServidor = Convert.ToInt32(hdfIdServidor.Value);
            }
            catch
            {

            }
        }

        private void datosPrincipales()
        {
            List<Entidades.Servidor> servidores = new List<Entidades.Servidor>();
            servidores = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdServidor = _IdServidor, IdVirtualizador = -1 });
            if (servidores.Count > 0)
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
            if (soporte.Count > 0)
            {
                lblSoporte.ForeColor = System.Drawing.Color.Green;
                lblSoporte.Text = " de ";
                lblSoporte.Text += ((DateTime)soporte.First().FechaInicio).ToString("dd/MM/yyyy") + " a ";
                lblSoporte.Text += ((DateTime)soporte.First().FechaFin).ToString("dd/MM/yyyy") + "<br>";
                lblSoporte.Text += soporte.First().Empresa.Nombre + "<br>";
                lblSoporte.Text += "Tel:" + soporte.First().Empresa.Telefono + "<br>";
            }
        }
    }
}