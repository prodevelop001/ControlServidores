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
            _Servidores = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdVirtualizador = -1 });
            var _servidores = from l in _Servidores
                              where l.IdVirtualizador == 0
                              select l;
            rptServidores.DataSource = _servidores;
            rptServidores.DataBind();
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
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlNuevoServidor.Visible = false;
            pnlServidores.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
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