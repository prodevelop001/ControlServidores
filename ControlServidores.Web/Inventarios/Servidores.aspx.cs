using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Inventarios
{
    public partial class Servidores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarRprServidores();
            }
        }

        private void llenarDdlMarcas()
        {
            ddlMarca.Items.Clear();
            ddlMarca.AppendDataBoundItems = true;
            ddlMarca.Items.Add(new ListItem("-- Seleccionar --","0"));
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
            ddlVirtualizador.DataSource = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdVirtualizador = 0, TipoServidor= new Entidades.TipoServidor() { IdTipoServidor = 2 } });
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
            rptServidores.DataSource = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdVirtualizador = 0 });
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

        protected void ddlProcesador_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Entidades.Procesador> lista = new List<Entidades.Procesador>();
            lista = Negocio.Catalogos.Procesador.Obtener(new Entidades.Procesador() { IdProcesador = Convert.ToInt32(ddlProcesador.SelectedValue) });
            if (lista.Count > 0)
            {
                lblCaracteristicasProc.Text  = lista.First().NumCores.ToString();
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
            GridView gdvServidoresHijos = (GridView)e.Item.FindControl("gdvServidoresHijos");
            gdvServidoresHijos.DataSource = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { IdVirtualizador = _IdServidor });
            gdvServidoresHijos.DataBind();
        }

        protected void ddlMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarDdlModelo();
        }

        protected void ddlTipoServidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlVirtualizador.Enabled = false;
            if (ddlTipoServidor.SelectedValue == "2")
            {
                ddlVirtualizador.Enabled = true;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
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
            if (ddlProcesador.SelectedValue == "0")
                lblCaracteristicasProc.Text = "";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlNuevoServidor.Visible = false;
            pnlServidores.Visible = true;
        }

    }
}