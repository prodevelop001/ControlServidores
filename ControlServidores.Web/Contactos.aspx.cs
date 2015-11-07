using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace ControlServidores.Web
{
    public partial class Contactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 1;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    llenarGdvPersonas();
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }

        private void llenarGdvPersonas()
        {
            gdvPersonas.DataSource = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas() { Estatus = new Entidades.Estatus() { IdEstatus = 1 } });
            gdvPersonas.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Entidades.Personas> personasEncontradas = new List<Entidades.Personas>();
            if (!string.IsNullOrWhiteSpace(txtPorNombre.Text.Trim()))
            {
                List<Entidades.Personas> consultaPersona = new List<Entidades.Personas>();
                consultaPersona = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas() {
                    Nombre = "%" + txtPorNombre.Text.Trim() + "%",
                    Estatus = new Entidades.Estatus() { IdEstatus = 1 }
                });
                consultaPersona.ForEach(delegate (Entidades.Personas p)
                {
                    personasEncontradas.Add(p);
                });
            }
            if (!string.IsNullOrWhiteSpace(txtPorPuesto.Text.Trim()))
            {
                List<Entidades.Personas> consultaPersona = new List<Entidades.Personas>();
                consultaPersona = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas()
                {
                    Puesto = "%" + txtPorPuesto.Text.Trim() + "%"
                    ,
                    Estatus = new Entidades.Estatus() { IdEstatus = 1 }
                });
                consultaPersona.ForEach(delegate (Entidades.Personas p)
                {
                    personasEncontradas.Add(p);
                });
            }
            if (!string.IsNullOrWhiteSpace(txtPorExt.Text.Trim()))
            {
                List<Entidades.Personas> consultaPersona = new List<Entidades.Personas>();
                consultaPersona = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas()
                {
                    Extension = "%" + txtPorExt.Text.Trim() + "%",
                    Estatus = new Entidades.Estatus() { IdEstatus = 1 }
                });
                consultaPersona.ForEach(delegate (Entidades.Personas p)
                {
                    personasEncontradas.Add(p);
                });
            }
            if(string.IsNullOrWhiteSpace(txtPorNombre.Text.Trim()) && string.IsNullOrWhiteSpace(txtPorPuesto.Text.Trim()) && string.IsNullOrWhiteSpace(txtPorExt.Text.Trim()))
            {
                Response.Redirect("~/Contactos.aspx");
            }
            /*
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
                consultaServidor = Negocio.Inventarios.Servidor.Obtener(new Entidades.Servidor() { DescripcionUso = "%" + txtPorAplicacion.Text.Trim() + "%", IdVirtualizador = -1, Modelo = null, Especificacion = null, TipoServidor = null });
                consultaServidor.ForEach(delegate (Entidades.Servidor s)
                {
                    servidoresEncontrados.Add(s);
                });
            }
            */
            gdvPersonas.DataSource = personasEncontradas;
            gdvPersonas.DataBind();
        }
    }
}