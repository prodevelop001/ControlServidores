using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Controles
{
    public partial class SistemasOperativosC : System.Web.UI.UserControl
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
                llenarGdvSO();
            }
        }

        private void llenarGdvSO()
        {
            gdvSO.DataSource = Negocio.Inventarios.SOxServidor.Obtener(new Entidades.SOxServidor() { Servidor= new Entidades.Servidor() { IdServidor= _IdServidor },Estatus= null });
            gdvSO.DataBind();
        }
    }
}