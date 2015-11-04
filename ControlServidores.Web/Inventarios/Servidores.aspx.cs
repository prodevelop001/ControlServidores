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
            int IdPagina = 2;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    pnlServidores.Visible = false;
                    if (permisos.R == true)
                    {
                        pnlServidores.Visible = true;
                        pnlResultado.Visible = false;
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

        private void llenarRprServidores()
        {
            _Servidores = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdVirtualizador = -1, Modelo = null, Especificacion = null });
            var _servidores = from l in _Servidores
                              where l.IdVirtualizador == 0
                              select l;
            rptServidores.DataSource = _servidores;
            rptServidores.DataBind();
        }

        private void llenarDdlEstatusRed()
        {
            //ddlEstatusRed.Items.Clear();
            //ddlEstatusRed.AppendDataBoundItems = true;
            //ddlEstatusRed.Items.Add(new ListItem("-- Seleccionar --", "0"));
            //ddlEstatusRed.DataTextField = "_Estatus";
            //ddlEstatusRed.DataValueField = "IdEstatus";
            //ddlEstatusRed.DataSource = Negocio.Catalogos.Estatus.Obtener(new Entidades.Estatus()
            //{
            //    IdConceptoEstatus = 2
            //});
            //ddlEstatusRed.DataBind();
        }

        private void llenarDdlSo()
        {
            ddlSO.Items.Clear();
            ddlSO.AppendDataBoundItems = true;
            ddlSO.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlSO.DataTextField = "NombreSO";
            ddlSO.DataValueField = "IdSO";
            ddlSO.DataSource = Negocio.Catalogos.SO.Obtener(new Entidades.SO());
            ddlSO.DataBind();
        }

        private void llenarDdlEstatusSo()
        {
            //ddlEstatusSo.Items.Clear();
            //ddlEstatusSo.AppendDataBoundItems = true;
            //ddlEstatusSo.Items.Add(new ListItem("-- Seleccionar --", "0"));
            //ddlEstatusSo.DataTextField = "_Estatus";
            //ddlEstatusSo.DataValueField = "IdEstatus";
            //ddlEstatusSo.DataSource = Negocio.Catalogos.Estatus.Obtener(new Entidades.Estatus()
            //{
            //    IdConceptoEstatus = 4
            //});
            //ddlEstatusSo.DataBind();
        }

        private void llenarDdlEstatusSer()
        {
            ddlEstatusServidor.Items.Clear();
            ddlEstatusServidor.AppendDataBoundItems = true;
            ddlEstatusServidor.Items.Add(new ListItem("-- Seleccionar --", "0"));
            ddlEstatusServidor.DataTextField = "_Estatus";
            ddlEstatusServidor.DataValueField = "IdEstatus";
            ddlEstatusServidor.DataSource = Negocio.Catalogos.Estatus.Obtener(new Entidades.Estatus()
            {
                IdConceptoEstatus = 6
            });
            ddlEstatusServidor.DataBind();
        }

        protected void rptServidores_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField IdServidor = (HiddenField)e.Item.FindControl("hdfIdServidor");
            //HiddenField IdTipoServidor = (HiddenField)e.Item.FindControl("hdfIdTipoServidor");
            Label lblIp = (Label)e.Item.FindControl("lblIp");
            int _IdServidor = Convert.ToInt32(IdServidor.Value);
            var _servidores = from l in _Servidores
                              where l.IdVirtualizador == _IdServidor
                              select l;

            List<Entidades.ConfRed> conRed = new List<Entidades.ConfRed>();
            conRed = Negocio.Inventarios.ConfRed.Obtener(
                new Entidades.ConfRed()
                {    Estatus = null,
                     Servidor= new Entidades.Servidor() { IdServidor = Convert.ToInt32(IdServidor.Value) }
                });
            if(conRed.Count > 0)
            {
                lblIp.Text = conRed.First().DirIP.Trim();
            }
            
            GridView gdvServidoresHijos = (GridView)e.Item.FindControl("gdvServidoresHijos");
            //gdvServidoresHijos.DataSource = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdVirtualizador = _IdServidor });
            gdvServidoresHijos.DataSource = _servidores;
            gdvServidoresHijos.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            if (permisos.C == true)
            {
                lblResultado.Text = string.Empty;
                pnlNuevoServidor.Visible = true;
                pnlServidores.Visible = false;
                pnlResultado.Visible = false;
                txtAliasServidor.Text = string.Empty;
                txtDescripcionUso.Text = string.Empty;
                txtInterfazRed.Text = string.Empty;
                //txtDirMAC.Text = string.Empty;
                txtDirIP.Text = string.Empty;
                txtGateway.Text = string.Empty;
                txtMascaraSubRed.Text = string.Empty;
                txtDNS.Text = string.Empty;
                llenarDdlSo();
                llenarDdlEstatusSo();
                llenarDdlEstatusRed();
                llenarDdlEstatusSer();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlNuevoServidor.Visible = false;
            pnlServidores.Visible = true;
            pnlResultado.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            //lblResultado.ForeColor = System.Drawing.Color.Red;
            lblResultado.Attributes["style"] = "color: #F00;";
            pnlResultado.Attributes["style"] = "background: rgba(252, 55, 55, 0.2);";
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            if (ddlEstatusServidor.SelectedValue != "0" && ddlSO.SelectedValue != "0")
            {
                resultado.resultado = true;
                List<Entidades.ConfRed> consultaRed = new List<Entidades.ConfRed>();
                consultaRed = Negocio.Inventarios.ConfRed.Obtener(new Entidades.ConfRed() { DirIP = txtDirIP.Text.Trim() });
                if (consultaRed.Count > 0)
                {
                    Entidades.Logica.Error error = new Entidades.Logica.Error();
                    resultado.resultado = false;
                    error = new Entidades.Logica.Error();
                    error.idError = 4;
                    error.descripcionCorta = "Dirección de IP duplicada.";
                    resultado.errores.Add(error);
                }
                resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                {
                    lblResultado.Text += error.descripcionCorta + "<br>";
                });
                Entidades.Servidor servidor = new Entidades.Servidor();
                if (resultado.resultado == true)
                {                    
                    servidor.AliasServidor = txtAliasServidor.Text.Trim();
                    servidor.DescripcionUso = txtDescripcionUso.Text.Trim();
                    servidor.Modelo = null;
                    servidor.Especificacion = null;
                    servidor.TipoServidor = null;
                    servidor.IdEstatus = Convert.ToInt32(ddlEstatusServidor.SelectedValue);
                    resultado = Negocio.Inventarios.Servidor.Nuevo(servidor);
                    resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                    {
                        lblResultado.Text += error.descripcionCorta + "<br>";
                    });
                }
                if(resultado.resultado == true)
                {
                    List<Entidades.Servidor> consultaServidor = new List<Entidades.Servidor>();
                    consultaServidor = Negocio.Inventarios.Servidor.Obtener(servidor);
                    if (consultaServidor.Count > 0)
                    {
                        int idSer = consultaServidor.First().IdServidor;

                        Entidades.SOxServidor so = new Entidades.SOxServidor();
                        so.Servidor.IdServidor = idSer;
                        so.SO.IdSO = Convert.ToInt32(ddlSO.SelectedValue);
                        so.Estatus = null;
                        resultado = Negocio.Inventarios.SOxServidor.Nuevo(so);
                        resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                        {
                            lblResultado.Text += error.descripcionCorta + "<br>";
                        });

                        Entidades.ConfRed red = new Entidades.ConfRed();
                        red.Servidor.IdServidor = idSer;
                        red.InterfazRed = txtInterfazRed.Text.Trim();
                        //red.DirMac = txtDirMAC.Text.Trim();
                        red.DirIP = txtDirIP.Text.Trim();
                        red.MascaraSubRed = txtMascaraSubRed.Text.Trim();
                        if(!string.IsNullOrWhiteSpace(txtGateway.Text.Trim()))
                            red.Gateway = txtGateway.Text.Trim();
                        if (!string.IsNullOrWhiteSpace(txtDNS.Text.Trim()))
                            red.DNS = txtDNS.Text.Trim();
                        //if (!string.IsNullOrWhiteSpace(txtVlan.Text.Trim()))
                        //    red.VLAN = txtVlan.Text.Trim();
                        //red.Estatus.IdEstatus = Convert.ToInt32(ddlEstatusRed.SelectedValue);
                        red.Estatus = null;
                        resultado = Negocio.Inventarios.ConfRed.Nuevo(red);
                        resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                        {
                            lblResultado.Text += error.descripcionCorta + "<br>";
                        });

                        Entidades.BitacoraMantenimiento bitacora = new Entidades.BitacoraMantenimiento();
                        bitacora.FechaCaptura = DateTime.Now;
                        bitacora.FechaMantenimiento = DateTime.Now;
                        bitacora.DescripcionMantenimiento = "Servidor registrado en el sistema.";
                        bitacora.Observaciones = "Sin observaciones.";
                        resultado = Negocio.Bitacoras.BitacoraMantenimiento.Nuevo(bitacora);
                        resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                        {
                            lblResultado.Text += error.descripcionCorta + "<br>";
                        });

                        if (resultado.resultado == true)
                        {
                            List<Entidades.BitacoraMantenimiento> conBitacor = new List<Entidades.BitacoraMantenimiento>();
                            conBitacor = Negocio.Bitacoras.BitacoraMantenimiento.Obtener(bitacora);
                            if (conBitacor.Count > 0)
                            {
                                int idBit = conBitacor.First().IdBitacora;
                                Entidades.PersonaXservidor asoc = new Entidades.PersonaXservidor();
                                asoc.Servidor.IdServidor = idSer;
                                asoc.Bitacora.IdBitacora = idBit;
                                asoc.Personas.IdPersona = ((Entidades.Usuarios)Session["usuario"]).IdPersona.IdPersona;
                                resultado = Negocio.Inventarios.PersonaXservidor.Nuevo(asoc);
                                resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                                {
                                    lblResultado.Text += error.descripcionCorta + "<br>";
                                });

                                if(resultado.resultado ==  true)
                                {
                                    pnlNuevoServidor.Visible = false;
                                    pnlServidores.Visible = true;
                                    llenarRprServidores();
                                }
                            }
                        }
                    }
                }
                if(resultado.resultado == true)
                {
                    //lblResultado.ForeColor = System.Drawing.Color.Green;
                    lblResultado.Attributes["style"] = "color: #008000;";
                    pnlResultado.Attributes["style"] = "background: rgba(147, 252, 55, 0.22);";
                }
            }
            else
            {
                lblResultado.Text = "Falta seleecionar algun item, revise y vuelva a intentar.";
            }
            pnlResultado.Visible = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            bool todos = true;
            List<Entidades.Servidor> servidoresEncontrados = new List<Entidades.Servidor>();
            if (!string.IsNullOrWhiteSpace(txtPorAlias.Text.Trim()))
            {
                List<Entidades.Servidor> consultaServidor = new List<Entidades.Servidor>();
                consultaServidor = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { AliasServidor = "%" + txtPorAlias.Text.Trim() + "%", IdVirtualizador = -1, Modelo =  null, Especificacion = null, TipoServidor = null });
                consultaServidor.ForEach(delegate (Entidades.Servidor s)
                {
                    servidoresEncontrados.Add(s);
                });
                todos = false;
            }
            if (!string.IsNullOrWhiteSpace(txtPorIp.Text.Trim()))
            {
                List<Entidades.ConfRed> consultaIps = new List<Entidades.ConfRed>();
                consultaIps = Negocio.Inventarios.ConfRed.Obtener(new Entidades.ConfRed() { DirIP = "%" + txtPorIp.Text.Trim() + "%" });
                consultaIps.ForEach(delegate (Entidades.ConfRed s)
                {
                    servidoresEncontrados.Add(s.Servidor);
                });
                todos = false;
            }
            if (!string.IsNullOrWhiteSpace(txtPorAplicacion.Text.Trim()))
            {
                List<Entidades.Servidor> consultaServidor = new List<Entidades.Servidor>();
                consultaServidor = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { DescripcionUso = "%" + txtPorAplicacion.Text.Trim() + "%", IdVirtualizador = -1, Modelo = null, Especificacion = null, TipoServidor = null });
                consultaServidor.ForEach(delegate (Entidades.Servidor s)
                {
                    servidoresEncontrados.Add(s);
                });
                todos = false;
            }

            if(todos== true)
            {
                //llenarRprServidores();
                Response.Redirect("~/Inventarios/Servidores.aspx");
            }
            else
            {
                rptServidores.DataSource = servidoresEncontrados;
                rptServidores.DataBind();
            }
            pnlResultado.Visible = false;
        }
    }
}