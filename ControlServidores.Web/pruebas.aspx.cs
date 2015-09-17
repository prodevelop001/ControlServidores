using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web
{
    public partial class pruebas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                llenarGrid();
            }
        }

        private void llenarGrid()
        {
            gdvPrueba.DataSource = Negocio.Catalogos.ConceptoEstatus.Obtener(new Entidades.ConceptoEstatus());
            gdvPrueba.DataBind();
        }

        protected void btnPrueba_Click(object sender, EventArgs e)
        {
            Negocio.Catalogos.ConceptoEstatus.Eliminar(new Entidades.ConceptoEstatus()
            {   IdConceptoEstatus = 8,
                Concepto = "Nuevo concepto"
            });

            llenarGrid();
        }
    }
}