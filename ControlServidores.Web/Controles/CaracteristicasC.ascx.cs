using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Controles
{
    public partial class CaracteristicasC : System.Web.UI.UserControl
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();

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
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            if (permisos.R == true)
            {
                if (!IsPostBack)
                {
                    hdfIdServidor.Value = _IdServidor.ToString();
                    datosPrincipales(1);
                }
                btnEditar.Enabled = permisos.U;
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

        private void limpiar()
        {
            txtAliasServidor.Text =
            txtCapacidadRam.Text =
            txtDescripcion.Text =
            txtNumProcesadores.Text =
            txtNumSerie.Text = string.Empty;
        }

        private void datosPrincipales(int opcion)
        {
            List<Entidades.Servidor> servidores = new List<Entidades.Servidor>();
            servidores = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdServidor = _IdServidor, IdVirtualizador = -1 });
            if(opcion == 1)
            {
                if (servidores.Count > 0)
                {
                    //lblAliasServidor.Text = servidores.First().AliasServidor;
                    lblDescripcionUso.Text = servidores.First().DescripcionUso;
                    if(servidores.First().Estatus != null)
                    {
                        lblEstatusServidor.Text = servidores.First().Estatus._Estatus;
                    }
                    if(servidores.First().TipoServidor != null)
                        lblTipoServidor.Text = servidores.First().TipoServidor.Tipo;
                    hdfIdModelo.Value = servidores.First().IdModelo.ToString();
                    if (servidores.First().Modelo != null)
                        lblModelo.Text = servidores.First().Modelo.NombreModelo;
                    if (servidores.First().Especificacion != null)
                    {
                        lblNumProcesadores.Text = servidores.First().Especificacion.NumProcesadores.ToString();
                        lblCapacidadRam.Text = servidores.First().Especificacion.CapacidadRAM;
                        lblProcesador.Text = servidores.First().Especificacion.Procesador.Nombre + "<br>";
                        lblProcesador.Text += servidores.First().Especificacion.Procesador.NumCores.ToString() + " Core(s) <br>";
                        lblProcesador.Text += "Velocidad de " + servidores.First().Especificacion.Procesador.Velocidad + "<br>";
                        lblProcesador.Text += "Cache " + servidores.First().Especificacion.Procesador.Cache + "<br>";
                        lblProcesador.Text += "Tamaño de instrucción " + servidores.First().Especificacion.Procesador.TamanoPalabra + "<br>";
                    }
                    if (servidores.First().Especificacion != null)
                    {
                        if (servidores.First().Especificacion.TipoArregloDisco != null)
                            lblArregloDiscos.Text = servidores.First().Especificacion.TipoArregloDisco.Tipo;
                    }

                }
                lblSoporte.ForeColor = System.Drawing.Color.Red;
                List<Entidades.Soporte> soporte = new List<Entidades.Soporte>();
                int IdModelo = !string.IsNullOrEmpty(hdfIdModelo.Value) ? Convert.ToInt32(hdfIdModelo.Value) : -1;
                soporte = Negocio.Inventarios.Soporte.Obtener(new Entidades.Soporte() { IdModelo = IdModelo });
                if (soporte.Count > 0)
                {                    
                    if(soporte.First().FechaFin > DateTime.Now)
                    {
                        lblSoporte.ForeColor = System.Drawing.Color.Green;
                        lblSoporte.Text = " de ";
                        lblSoporte.Text += ((DateTime)soporte.First().FechaInicio).ToString("dd/MM/yyyy") + " a ";
                        lblSoporte.Text += ((DateTime)soporte.First().FechaFin).ToString("dd/MM/yyyy") + "<br>";
                        lblSoporte.Text += soporte.First().Empresa.Nombre + "<br>";
                        lblSoporte.Text += "Tel:" + soporte.First().Empresa.Telefono + "<br>";
                    }
                    else
                    {
                        lblSoporte.Text = "Sin soporte.";
                    }
                }

                Entidades.PersonaXservidor persona = new Entidades.PersonaXservidor();
                persona.Servidor.IdServidor = _IdServidor;
                persona.Personas = null;
                persona.Bitacora = null;

                List<Entidades.PersonaXservidor> pso = new List<Entidades.PersonaXservidor>();
                pso = Negocio.Inventarios.PersonaXservidor.Obtener(persona);
                var enc = from l in pso
                          where l.Bitacora == null
                          select l;
                pso = enc.ToList();
                if (pso.Count > 0)
                {                   
                    lblPersonaEncargada.Text = pso.First().Personas.Nombre.Trim();
                }
            }
            else if(opcion == 2)
            {
                limpiar();
                if (servidores.Count > 0)
                {
                    txtAliasServidor.Text = servidores.First().AliasServidor;
                    txtDescripcion.Text = servidores.First().DescripcionUso;
                    if(servidores.First().IdVirtualizador != 0)
                    {
                        ddlVirtualizador.Enabled = true;
                        ddlVirtualizador.SelectedValue = servidores.First().IdVirtualizador.ToString();
                    }
                    if (servidores.First().TipoServidor != null)
                        ddlTipoServidor.SelectedValue = servidores.First().TipoServidor.IdTipoServidor.ToString();                    
                    if (servidores.First().Modelo != null)
                    {
                        hdfIdModelo.Value = servidores.First().IdModelo.ToString();
                        ddlMarca.SelectedValue = servidores.First().Modelo.IdMarca.ToString();
                        llenarDdlModelo();
                        ddlModelo.SelectedValue = servidores.First().Modelo.IdModelo.ToString();
                    }                       
                    if (servidores.First().Especificacion != null)
                    {
                        txtNumProcesadores.Text = servidores.First().Especificacion.NumProcesadores.ToString();
                        txtCapacidadRam.Text = servidores.First().Especificacion.CapacidadRAM.Split(' ').ElementAt(0);
                        ddlCapacidadRam.SelectedValue = servidores.First().Especificacion.CapacidadRAM.Split(' ').ElementAt(1);
                        ddlProcesador.SelectedValue = servidores.First().Especificacion.Procesador.IdProcesador.ToString();
                        
                        lblCaracteristicasProc.Text = servidores.First().Especificacion.Procesador.NumCores.ToString();
                        lblCaracteristicasProc.Text += " " + servidores.First().Especificacion.Procesador.Velocidad.Trim();
                        lblCaracteristicasProc.Text += " " + servidores.First().Especificacion.Procesador.Cache.Trim();
                        lblCaracteristicasProc.Text += " " + servidores.First().Especificacion.Procesador.TamanoPalabra.Trim();

                        txtNumProcesadores.Text = servidores.First().Especificacion.NumProcesadores.ToString();
                        
                    }
                    if (servidores.First().Especificacion != null)
                    {
                        if (servidores.First().Especificacion.TipoArregloDisco != null)
                            ddlArregloDiscos.SelectedValue = servidores.First().Especificacion.TipoArregloDisco.IdTipoArreglo.ToString();
                    }
                    ddlEstatus.SelectedValue = servidores.First().Estatus.IdEstatus.ToString();

                    Entidades.PersonaXservidor persona = new Entidades.PersonaXservidor();
                    persona.Servidor.IdServidor = _IdServidor;
                    persona.Personas = null;
                    persona.Bitacora = null;

                    List<Entidades.PersonaXservidor> pso = new List<Entidades.PersonaXservidor>();
                    pso = Negocio.Inventarios.PersonaXservidor.Obtener(persona);
                    pso = Negocio.Inventarios.PersonaXservidor.Obtener(persona);
                    var enc = from l in pso
                              where l.Bitacora == null
                              select l;
                    pso = enc.ToList();
                    if (pso.Count > 0)
                    {
                        ddlPersona.SelectedValue = pso.First().Personas.IdPersona.ToString();
                    }
                }
            }
            
        }

        private void llenarDdlMarcas()
        {
            ddlMarca.Items.Clear();
            ddlMarca.AppendDataBoundItems = true;
            ddlMarca.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlMarca.DataTextField = "NombreMarca";
            ddlMarca.DataValueField = "IdMarca";
            ddlMarca.DataSource = Negocio.Catalogos.MarcaServidor.obtenerMarcaServidor(new Entidades.MarcaServidor());
            ddlMarca.DataBind();
        }

        private void llenarDdlModelo()
        {
            ddlModelo.Items.Clear();
            ddlModelo.AppendDataBoundItems = true;
            ddlModelo.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlModelo.DataTextField = "NombreModelo";
            ddlModelo.DataValueField = "IdModelo";
            ddlModelo.DataSource = Negocio.Catalogos.Modelo.Obtener(new Entidades.Modelo() { IdMarca = Convert.ToInt32(ddlMarca.SelectedValue) });
            ddlModelo.DataBind();
        }

        private void llenarDdlTipoServidor()
        {
            ddlTipoServidor.Items.Clear();
            ddlTipoServidor.AppendDataBoundItems = true;
            ddlTipoServidor.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlTipoServidor.DataTextField = "Tipo";
            ddlTipoServidor.DataValueField = "IdTipoServidor";
            ddlTipoServidor.DataSource = Negocio.Catalogos.TipoServidor.Obtener(new Entidades.TipoServidor());
            ddlTipoServidor.DataBind();
        }

        private void virtualizadoresDisponibles()
        {
            ddlVirtualizador.Items.Clear();
            ddlVirtualizador.AppendDataBoundItems = true;
            ddlVirtualizador.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlVirtualizador.DataTextField = "AliasServidor";
            ddlVirtualizador.DataValueField = "IdServidor";
            ddlVirtualizador.DataSource = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdVirtualizador = 0, TipoServidor = new Entidades.TipoServidor() { IdTipoServidor = 2 } });
            ddlVirtualizador.DataBind();
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
                IdConceptoEstatus = 6
            });
            ddlEstatus.DataBind();
        }

        private void llenarDdlProcesador()
        {
            ddlProcesador.Items.Clear();
            ddlProcesador.AppendDataBoundItems = true;
            ddlProcesador.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlProcesador.DataTextField = "Nombre";
            ddlProcesador.DataValueField = "IdProcesador";
            ddlProcesador.DataSource = Negocio.Catalogos.Procesador.Obtener(new Entidades.Procesador());
            ddlProcesador.DataBind();
        }

        private void llenarDdlArregloDiscos()
        {
            ddlArregloDiscos.Items.Clear();
            ddlArregloDiscos.AppendDataBoundItems = true;
            ddlArregloDiscos.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlArregloDiscos.DataTextField = "Tipo";
            ddlArregloDiscos.DataValueField = "IdTipoArreglo";
            ddlArregloDiscos.DataSource = Negocio.Catalogos.TipoArregloDisco.Obtener(new Entidades.TipoArregloDisco());
            ddlArregloDiscos.DataBind();
        }

        private void llenarDdlPersona()
        {
            ddlPersona.Items.Clear();
            ddlPersona.AppendDataBoundItems = true;
            ddlPersona.Items.Add(new ListItem("-- Seleccionar --","0"));
            ddlPersona.DataTextField = "Nombre";
            ddlPersona.DataValueField = "IdPersona";
            ddlPersona.DataSource = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas());
            ddlPersona.DataBind();
        }

        protected void ddlProcesador_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Entidades.Procesador> lista = new List<Entidades.Procesador>();
            lista = Negocio.Catalogos.Procesador.Obtener(new Entidades.Procesador() { IdProcesador = Convert.ToInt32(ddlProcesador.SelectedValue) });
            if (lista.Count > 0)
            {
                lblCaracteristicasProc.Text = lista.First().NumCores.ToString();
                lblCaracteristicasProc.Text += " " + lista.First().Velocidad.Trim();
                lblCaracteristicasProc.Text += " " + lista.First().Cache.Trim();
                lblCaracteristicasProc.Text += " " + lista.First().TamanoPalabra.Trim();
            }
            else
            {
                lblCaracteristicasProc.Text = "";
            }
            if (ddlProcesador.SelectedValue == "0")
                lblCaracteristicasProc.Text = "";
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            ddlVirtualizador.Enabled = false;
            ObtenerDatos();
            pnlForm.Visible = true;
            pnlCaracteristicas.Visible = false;
            llenarDdlMarcas();
            llenarDdlModelo();
            llenarDdlTipoServidor();
            virtualizadoresDisponibles();
            llenarDdlEstatus();
            llenarDdlProcesador();
            llenarDdlArregloDiscos();
            llenarDdlPersona();
            datosPrincipales(2);
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarDdlModelo();
        }

        protected void ddlTipoServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlVirtualizador.Enabled = false;
            if (ddlTipoServidor.SelectedValue == "3")
            {
                ddlVirtualizador.Enabled = true;
            }
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            pnlCaracteristicas.Visible = true;
            pnlForm.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            lblResultado.ForeColor = System.Drawing.Color.Red;
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            if (permisos.U == true)
            {
                if (ddlModelo.SelectedValue != "0" && ddlTipoServidor.SelectedValue != "0" && ddlEstatus.SelectedValue != "0" && ddlProcesador.SelectedValue != "0" && ddlCapacidadRam.SelectedValue != "0" && ddlArregloDiscos.SelectedValue != "0")
                {
                    resultado.resultado = true;
                    if (ddlTipoServidor.SelectedValue == "3")
                    {
                        if (ddlVirtualizador.SelectedValue == "0")
                            resultado.resultado = false;
                    }

                    if (resultado.resultado == true)
                    {
                        //TODO
                        //Empieza la recolección de datos para actualizar el servidor
                        ObtenerDatos();

                        Entidades.EspServidor especificacion = new Entidades.EspServidor();
                        especificacion.IdServidor = _IdServidor;

                        List<Entidades.EspServidor> esp = new List<Entidades.EspServidor>();
                        esp = Negocio.Inventarios.EspServidor.Obtener(especificacion);

                        especificacion.Procesador.IdProcesador = Convert.ToInt32(ddlProcesador.SelectedValue);
                        especificacion.NumProcesadores = Convert.ToInt32(txtNumProcesadores.Text.Trim());
                        especificacion.CapacidadRAM = txtCapacidadRam.Text.Trim() + " " + ddlCapacidadRam.SelectedValue.Trim();
                        especificacion.TipoArregloDisco.IdTipoArreglo = Convert.ToInt32(ddlArregloDiscos.SelectedValue);
                        if (!string.IsNullOrWhiteSpace(txtNumSerie.Text.Trim()))
                        {
                            especificacion.NumSerie = txtNumSerie.Text.Trim();
                        }
                        
                        if(esp.Count > 0)
                        {
                            especificacion.IdEspecificacion = esp.First().IdEspecificacion;
                            resultado = Negocio.Inventarios.EspServidor.Actualizar(especificacion);
                        }
                        else
                        {
                            resultado = Negocio.Inventarios.EspServidor.Nuevo(especificacion);
                        }             
                                   
                        if (resultado.resultado == true)
                        {
                            List<Entidades.EspServidor> conEsp = new List<Entidades.EspServidor>();
                            conEsp = Negocio.Inventarios.EspServidor.Obtener(especificacion);
                            if (conEsp.Count > 0)
                            {
                                Entidades.Servidor servidor = new Entidades.Servidor();
                                servidor.IdServidor = _IdServidor;
                                servidor.AliasServidor = txtAliasServidor.Text.Trim();
                                servidor.Modelo.IdModelo = Convert.ToInt32(ddlModelo.SelectedValue);
                                servidor.Especificacion.IdEspecificacion = conEsp.First().IdEspecificacion;
                                servidor.TipoServidor.IdTipoServidor = Convert.ToInt32(ddlTipoServidor.SelectedValue);
                                servidor.IdVirtualizador = 0;
                                if (ddlVirtualizador.SelectedValue != "0")
                                    servidor.IdVirtualizador = Convert.ToInt32(ddlVirtualizador.SelectedValue);
                                servidor.DescripcionUso = txtDescripcion.Text.Trim();
                                servidor.Estatus.IdEstatus = Convert.ToInt32(ddlEstatus.SelectedValue);

                                Entidades.PersonaXservidor persona = new Entidades.PersonaXservidor();
                                persona.Servidor.IdServidor = _IdServidor;
                                persona.Personas.IdPersona = Convert.ToInt32(ddlPersona.SelectedValue);
                                persona.Bitacora = null;

                                List<Entidades.PersonaXservidor> pso = new List<Entidades.PersonaXservidor>();
                                pso = Negocio.Inventarios.PersonaXservidor.Obtener(persona);                               

                                var enc = from l in pso
                                          where l.Bitacora == null
                                          select l;
                                pso = enc.ToList();
                                if (pso.Count > 0)
                                {
                                    persona.IdPersonaServidor = pso.First().IdPersonaServidor;
                                    resultado = Negocio.Inventarios.PersonaXservidor.Actualizar(persona);
                                }
                                else
                                {
                                    resultado = Negocio.Inventarios.PersonaXservidor.Nuevo(persona);
                                }

                                resultado = Negocio.Inventarios.Servidor.Actualizar(servidor);
                            }
                        }
                    }
                    else
                    {
                        lblResultado.Text = "Debe seleccionar un virtualzador";
                    }

                    resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Red;
                        lblResultado.Text += error.descripcionCorta + "<br/>";
                    });

                    
                    if (resultado.resultado == true)
                    {
                        lblResultado.ForeColor = System.Drawing.Color.Green;
                        pnlForm.Visible = false;
                        pnlCaracteristicas.Visible = true;
                        ObtenerDatos();
                        datosPrincipales(1);
                    }

                }
                else
                {
                    lblResultado.Text = "Revise el formulario, hay campos que no han sido seleccionados.";
                }
            }
            else
            {
                lblResultado.Text = "No tienes privilegios para actualizar la información.";
            }
        }
    }
}