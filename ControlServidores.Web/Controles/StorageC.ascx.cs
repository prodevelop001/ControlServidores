using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Controles
{
    public partial class StorageC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarDdlTipoStorage();
                llenarGdvSTorage();
            }
        }//Fin de Void
        

        private void llenarDdlTipoStorage()
        {

        }//Fin de llenar DDL

        private void llenarGdvSTorage()
        {
            gdvStorage.DataSource = Negocio.Catalogos.TipoStorage.Obtener(new Entidades.TipoStorage()
            {

            });
            gdvStorage.DataBind();
        }//Fin de llenar Gdv
    }