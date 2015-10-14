using System;

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
            gdvPersonas.DataSource = Negocio.Seguridad.Personas.Obtener(new Entidades.Personas() { IdEstatus = 1 });
            gdvPersonas.DataBind();
        }
    }
}