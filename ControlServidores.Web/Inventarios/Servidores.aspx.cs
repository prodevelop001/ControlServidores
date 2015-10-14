using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Inventarios
{
    public partial class Servidores : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();
        private List<Entidades.Servidor> _Servidores = new List<Entidades.Servidor>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 3;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    pnlServidores.Visible = false;
                    if (permisos.R == true)
                    {
                        pnlServidores.Visible = true;
                        llenarRprServidores();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
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

        private void llenarRprServidores()
        {
            _Servidores = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdVirtualizador = -1 });
            var _servidores = from l in _Servidores
                              where l.IdVirtualizador == 0
                              select l;
            rptServidores.DataSource = _servidores;
            rptServidores.DataBind();
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

        private void llenarDdlPersonas()
        {
            ddlPersona.Items.Clear();
            ddlPersona.AppendDataBoundItems = true;
            ddlPersona.Items.Add(new ListItem("-- Seleccione --", "0"));
            ddlPersona.DataTextField = "Nombre";
            ddlPersona.DataValueField = "IdPersona";
            ddlPersona.DataSource = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas()
            {
                IdEstatus = 1
            });
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

        protected void rptServidores_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField IdServidor = (HiddenField)e.Item.FindControl("hdfIdServidor");
            int _IdServidor = Convert.ToInt32(IdServidor.Value);
            var _servidores = from l in _Servidores
                              where l.IdVirtualizador == _IdServidor
                              select l;

            GridView gdvServidoresHijos = (GridView)e.Item.FindControl("gdvServidoresHijos");
            //gdvServidoresHijos.DataSource = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdVirtualizador = _IdServidor });
            gdvServidoresHijos.DataSource = _servidores;
            gdvServidoresHijos.DataBind();
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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            if (permisos.C == true)
            {
                lblResultado.Text = string.Empty;
                pnlNuevoServidor.Visible = true;
                pnlServidores.Visible = false;
                txtAliasServidor.Text = string.Empty;
                txtDescripcionUso.Text = string.Empty;
                llenarDdlMarcas();
                llenarDdlModelo();
                llenarDdlTipoServidor();
                virtualizadoresDisponibles();
                llenarDdlProcesador();
                llenarDdlArregloDiscos();
                llenarDdlEstatus();
                llenarDdlPersonas();
                if (ddlProcesador.SelectedValue == "0")
                    lblCaracteristicasProc.Text = "";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlNuevoServidor.Visible = false;
            pnlServidores.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();

            if (ddlModelo.SelectedValue != "0" && ddlTipoServidor.SelectedValue != "0" && ddlEstatus.SelectedValue != "0" && ddlProcesador.SelectedValue != "0" && ddlCapacidadRam.SelectedValue != "0" && ddlArregloDiscos.SelectedValue != "0" && ddlPersona.SelectedValue != "0")
            {
                resultado.resultado = true;
                if (ddlTipoServidor.SelectedValue != "0")
                {
                    if (ddlVirtualizador.SelectedValue == "0")
                    {
                        resultado.resultado = false;
                    }
                }
            }
            if (resultado.resultado == true)
            {
                Entidades.Logica.Ejecucion resultado2 = new Entidades.Logica.Ejecucion();
                Entidades.EspServidor especificacion = new Entidades.EspServidor();
                especificacion.IdProcesador = Convert.ToInt32(ddlProcesador.SelectedValue);
                especificacion.NumProcesadores = Convert.ToInt32(txtNumProcesadores.Text.Trim());
                especificacion.CapacidadRAM = txtCapacidadRam.Text + " " + ddlCapacidadRam.SelectedValue;
                especificacion.IdTipoArreglo = Convert.ToInt32(ddlArregloDiscos.SelectedValue);
                if (!string.IsNullOrWhiteSpace(txtNumSerie.Text))
                {
                    especificacion.NumSerie = txtNumSerie.Text.Trim();
                }

                resultado = Negocio.Inventarios.EspServidor.Nuevo(especificacion);
                resultado.errores.ForEach(delegate (Entidades.Logica.Error err)
                {
                    resultado2.errores.Add(err);
                });
                if (resultado.resultado == true)
                {
                    int IdEspecificacion = 0;
                    List<Entidades.EspServidor> consultaEsp = new List<Entidades.EspServidor>();
                    consultaEsp = Negocio.Inventarios.EspServidor.Obtener(especificacion);
                    if (consultaEsp.Count > 0)
                    {
                        IdEspecificacion = consultaEsp.First().IdEspecificacion;
                        Entidades.Servidor servidorNuevo = new Entidades.Servidor();
                        servidorNuevo.AliasServidor = txtAliasServidor.Text.Trim();
                        servidorNuevo.Modelo.IdModelo = Convert.ToInt32(ddlModelo.SelectedValue);
                        servidorNuevo.Especificacion.IdEspecificacion = IdEspecificacion;
                        servidorNuevo.TipoServidor.IdTipoServidor = Convert.ToInt32(ddlTipoServidor.SelectedValue);
                        servidorNuevo.IdVirtualizador = Convert.ToInt32(ddlVirtualizador.SelectedValue);
                        servidorNuevo.DescripcionUso = txtDescripcionUso.Text.Trim();
                        servidorNuevo.IdEstatus = Convert.ToInt32(ddlEstatus.SelectedValue);

                        resultado = Negocio.Inventarios.Servidor.Nuevo(servidorNuevo);
                        resultado.errores.ForEach(delegate (Entidades.Logica.Error err)
                        {
                            resultado2.errores.Add(err);
                        });
                        if (resultado.resultado == true)
                        {
                            int IdServidor = 0;
                            List<Entidades.Servidor> consultaServidor = new List<Entidades.Servidor>();
                            consultaServidor = Negocio.Inventarios.Servidor.Obtener(servidorNuevo);
                            if (consultaServidor.Count > 0)
                            {
                                IdServidor = consultaServidor.First().IdServidor;
                                Entidades.BitacoraMantenimiento nuevoEvento = new Entidades.BitacoraMantenimiento();
                                nuevoEvento.FechaCaptura =
                                nuevoEvento.FechaMantenimiento = DateTime.Now;
                                nuevoEvento.DescripcionMantenimiento = "Servidor registrado en el sistema";
                                nuevoEvento.Observaciones = "Servidor registrado con una persona a cargo.";

                                resultado = Negocio.Bitacoras.BitacoraMantenimiento.Nuevo(nuevoEvento);
                                resultado.errores.ForEach(delegate (Entidades.Logica.Error err)
                                {
                                    resultado2.errores.Add(err);
                                });
                                if (resultado.resultado == true)
                                {
                                    int IdBitacora = 0;
                                    List<Entidades.BitacoraMantenimiento> consultaBitacora = new List<Entidades.BitacoraMantenimiento>();
                                    consultaBitacora = Negocio.Bitacoras.BitacoraMantenimiento.Obtener(nuevoEvento);
                                    if (consultaBitacora.Count > 0)
                                    {
                                        IdBitacora = consultaBitacora.First().IdBitacora;
                                        if (IdEspecificacion != 0 && IdServidor != 0 && IdBitacora != 0)
                                        {
                                            Entidades.PersonaXservidor asociacion = new Entidades.PersonaXservidor();
                                            asociacion.IdBitacora = IdBitacora;
                                            asociacion.IdServidor = IdServidor;
                                            asociacion.IdPersona = Convert.ToInt32(ddlPersona.SelectedValue);

                                            resultado = Negocio.Inventarios.PersonaXservidor.Nuevo(asociacion);
                                            resultado.errores.ForEach(delegate (Entidades.Logica.Error err)
                                            {
                                                resultado2.errores.Add(err);
                                            });
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

                resultado2.errores.ForEach(delegate (Entidades.Logica.Error error)
                {
                    lblResultado.Text += error.descripcionCorta + "<br/>";
                });

                lblResultado.ForeColor = System.Drawing.Color.Red;
                if (resultado.resultado == true)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Green;
                    pnlNuevoServidor.Visible = false;
                    pnlServidores.Visible = true;
                    llenarRprServidores();
                }

            }
            else
            {
                lblResultado.Text = "Falta seleccionar algun campo, revise la entrada de los datos y continue con la operación.";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Entidades.Servidor> servidoresEncontrados = new List<Entidades.Servidor>();
            if (!string.IsNullOrWhiteSpace(txtPorAlias.Text.Trim()))
            {
                List<Entidades.Servidor> consultaServidor = new List<Entidades.Servidor>();
                consultaServidor = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { AliasServidor = "%" + txtPorAlias.Text.Trim() + "%", IdVirtualizador = -1 });
                consultaServidor.ForEach(delegate (Entidades.Servidor s)
                {
                    servidoresEncontrados.Add(s);
                });
            }
            if (!string.IsNullOrWhiteSpace(txtPorIp.Text.Trim()))
            {
                List<Entidades.ConfRed> consultaIps = new List<Entidades.ConfRed>();
                consultaIps = Negocio.Inventarios.ConfRed.Obtener(new Entidades.ConfRed() { DirIP = "%" + txtPorIp.Text.Trim() + "%" });
                consultaIps.ForEach(delegate (Entidades.ConfRed s)
                {
                    servidoresEncontrados.Add(s.Servidor);
                });
            }
            if (!string.IsNullOrWhiteSpace(txtPorAplicacion.Text.Trim()))
            {
                List<Entidades.Servidor> consultaServidor = new List<Entidades.Servidor>();
                consultaServidor = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { DescripcionUso = "%" + txtPorAplicacion.Text.Trim() + "%", IdVirtualizador = -1 });
                consultaServidor.ForEach(delegate (Entidades.Servidor s)
                {
                    servidoresEncontrados.Add(s);
                });
            }

            rptServidores.DataSource = servidoresEncontrados;
            rptServidores.DataBind();
        }
    }
}