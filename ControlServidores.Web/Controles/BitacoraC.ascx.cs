using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Controles
{
    public partial class BitacoraC : System.Web.UI.UserControl
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
                Bitacora();
            }
        }

        private void ObtenerParametros()
        {
            try
            {
                _IdServidor = Convert.ToInt32(hdfIdServidor.Value);
            }
            catch
            {

            }
        }

        private void limpiar()
        {
            txtFechaProc.Text = DateTime.Now.ToShortDateString();
            txtDescripcion.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
        }

        private void Bitacora()
        {
            List<Entidades.PersonaXservidor> lista = new List<Entidades.PersonaXservidor>();
            lista = Negocio.Inventarios.PersonaXservidor.Obtener(new Entidades.PersonaXservidor() { Servidor = new Entidades.Servidor() { IdServidor = _IdServidor } });
            List<Entidades.PersonaXservidor> aux = new List<Entidades.PersonaXservidor>();
            aux = Negocio.Inventarios.PersonaXservidor.Obtener(new Entidades.PersonaXservidor() { Servidor = new Entidades.Servidor() { IdServidor = _IdServidor }, Personas = null });
            if (aux.Count > 0)
            {
                lista.Add(aux.First());
            }
            var todos = from l in lista
                        orderby l.IdPersonaServidor ascending
                        select l;

            gdvBitacora.DataSource = todos;
            gdvBitacora.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "1";
            btnAgregar.Text = "Agregar";
            pnlForm.Visible = true;
            pnlBitacora.Visible = false;
            limpiar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            pnlForm.Visible = false;
            pnlBitacora.Visible = true;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtFechaProc.Text.Trim()) && !string.IsNullOrWhiteSpace(txtDescripcion.Text.Trim()))
            {
                ObtenerParametros();
                Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
                Entidades.BitacoraMantenimiento bitacora = new Entidades.BitacoraMantenimiento();
                bitacora.FechaCaptura = DateTime.Now;
                bitacora.FechaMantenimiento = Convert.ToDateTime(txtFechaProc.Text.Trim());
                bitacora.DescripcionMantenimiento = txtDescripcion.Text.Trim();
                if(!string.IsNullOrWhiteSpace(txtObservaciones.Text.Trim()))
                {
                    bitacora.Observaciones = txtObservaciones.Text.Trim();
                }

                if(hdfEstado.Value == "1")
                {
                    resultado = Negocio.Bitacoras.BitacoraMantenimiento.Nuevo(bitacora);
                    if(resultado.resultado == true)
                    {
                        List<Entidades.BitacoraMantenimiento> conBit = new List<Entidades.BitacoraMantenimiento>();
                        conBit = Negocio.Bitacoras.BitacoraMantenimiento.Obtener(bitacora);
                        if(conBit.Count >  0)
                        {
                            Entidades.PersonaXservidor registro = new Entidades.PersonaXservidor();
                            registro.Bitacora.IdBitacora = conBit.First().IdBitacora;
                            registro.Servidor.IdServidor = _IdServidor;
                            registro.Personas.IdPersona = ((Entidades.Usuarios)Session["usuario"]).IdPersona.IdPersona;
                            resultado = Negocio.Inventarios.PersonaXservidor.Nuevo(registro);
                        }
                    }
                }
                else if(hdfEstado.Value == "2")
                {
                    bitacora.IdBitacora = Convert.ToInt32(hdfIdBitacora.Value);
                    resultado = Negocio.Bitacoras.BitacoraMantenimiento.Actualizar(bitacora);
                    if(resultado.resultado == true)
                    {
                        List<Entidades.PersonaXservidor> p = new List<Entidades.PersonaXservidor>();
                        p = Negocio.Inventarios.PersonaXservidor.Obtener(new Entidades.PersonaXservidor()
                        {
                            Bitacora = new Entidades.BitacoraMantenimiento() { IdBitacora = bitacora.IdBitacora }
                             , Servidor = new Entidades.Servidor() { IdServidor = _IdServidor }
                             
                        });
                        if(p.Count > 0)
                        {
                            Entidades.PersonaXservidor per = new Entidades.PersonaXservidor();
                            per.IdPersonaServidor = p.First().IdPersonaServidor;
                            per.Bitacora.IdBitacora = bitacora.IdBitacora;
                            per.Servidor.IdServidor = _IdServidor;
                            per.Personas.IdPersona = ((Entidades.Usuarios)Session["usuario"]).IdPersona.IdPersona;
                            resultado = Negocio.Inventarios.PersonaXservidor.Actualizar(per);
                        }
                     }
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
                    pnlBitacora.Visible = true;
                    ObtenerParametros();
                    Bitacora();
                }
            }
        }

        protected void gdvBitacora_SelectedIndexChanged(object sender, EventArgs e)
        {
            ObtenerParametros();
            hdfEstado.Value = "2";
            pnlForm.Visible = true;
            pnlBitacora.Visible = false;
            btnRegistrar.Text = "Actualizar";
            hdfIdBitacora.Value = gdvBitacora.SelectedRow.Cells[1].Text.Trim();
            int IdPersona = Convert.ToInt32(gdvBitacora.SelectedRow.Cells[2].Text.Trim());
            List<Entidades.PersonaXservidor> conPerSer = new List<Entidades.PersonaXservidor>();
            conPerSer = Negocio.Inventarios.PersonaXservidor.Obtener(new Entidades.PersonaXservidor()
            {
                 Bitacora = new Entidades.BitacoraMantenimiento() { IdBitacora = Convert.ToInt32(hdfIdBitacora.Value) }
                 ,Servidor = new Entidades.Servidor() { IdServidor = _IdServidor }
                 ,Personas = new Entidades.Personas() { IdPersona = IdPersona }
            });
            if(conPerSer.Count > 0)
            {
                txtFechaProc.Text = Convert.ToDateTime(conPerSer.First().Bitacora.FechaMantenimiento).ToShortDateString();
                txtDescripcion.Text = conPerSer.First().Bitacora.DescripcionMantenimiento;
                txtObservaciones.Text = conPerSer.First().Bitacora.Observaciones;
            }
        }

    }
} 