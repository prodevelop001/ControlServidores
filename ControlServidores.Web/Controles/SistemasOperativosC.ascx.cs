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
            if(!IsPostBack)
            {
                permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                if (permisos.R == true)
                {
                    hdfIdServidor.Value = _IdServidor.ToString();
                    llenarGdvSO();
                }
                btnAdd.Enabled = permisos.C;
            }
        }

        private void ObtenerParametros()
        {
            _IdServidor = Convert.ToInt32(hdfIdServidor.Value);
        }

        private void llenarDdlSO()
        {
            ddlSO.Items.Clear();
            ddlSO.AppendDataBoundItems = true;
            ddlSO.Items.Add(new ListItem("-- Seleccionar --","0"));
            ddlSO.DataTextField = "NombreSO";
            ddlSO.DataValueField = "IdSO";
            ddlSO.DataSource = Negocio.Catalogos.SO.Obtener(new Entidades.SO());
            ddlSO.DataBind();
        }

        private void llenarGdvSO()
        {
            gdvSO.DataSource = Negocio.Inventarios.SOxServidor.Obtener(new Entidades.SOxServidor() { Servidor= new Entidades.Servidor() { IdServidor= _IdServidor },Estatus= null });
            gdvSO.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            hdfEstado.Value = "1";
            pnlForm.Visible = true;
            pnlSO.Visible = false;
            btnGuardar.Text = "Guardar";
            llenarDdlSO();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            pnlForm.Visible = false;
            pnlSO.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            lblResultado.ForeColor = System.Drawing.Color.Red;
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            if(ddlSO.SelectedValue != "0")
            {
                ObtenerParametros();
                Entidades.SOxServidor so = new Entidades.SOxServidor();
                so.Servidor.IdServidor = _IdServidor;
                so.SO.IdSO = Convert.ToInt32(ddlSO.SelectedValue);
                so.Estatus = null;
                if (hdfEstado.Value == "1" && permisos.C == true)
                {
                    resultado = Negocio.Inventarios.SOxServidor.Nuevo(so);
                }
                else if (hdfEstado.Value == "2" && permisos.U == true)
                {
                    so.IdSOxServidor = Convert.ToInt32(hdfIdSoServidor);
                    resultado = Negocio.Inventarios.SOxServidor.Nuevo(so);
                }
                else
                {
                    lblResultado.Text = "No tiene privilegios para realizar esta acción.";
                }

                resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                {
                    lblResultado.Text += error.descripcionCorta + "<br/>";
                });

                if (resultado.resultado == true)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Green;
                    hdfEstado.Value = "0";
                    pnlForm.Visible = false;
                    pnlSO.Visible = true;
                    ObtenerParametros();
                    llenarGdvSO();
                }
            }
            {
                lblResultado.Text = "Seleccione un sistema operativo.";
            }         
        }

        protected void gdvSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            hdfEstado.Value = "2";
            pnlForm.Visible = true;
            pnlSO.Visible = false;
            btnGuardar.Text = "Actualizar";
            llenarDdlSO();
            ddlSO.SelectedValue = gdvSO.SelectedRow.Cells[3].Text.Trim();
        }

        protected void gdvSO_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        //LinkButton button = (LinkButton)control;
                        LinkButton button = control as LinkButton;
                        if (button != null && button.Text == "Eliminar")
                        {
                            //button.Enabled = permisos.D;
                            if (button.Enabled)
                                button.OnClientClick = "return checkMe()";
                        }
                    }
                }
            }
        }

        protected void gdvSO_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblResultado.Text = string.Empty;
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            lblResultado.ForeColor = System.Drawing.Color.Red;
            Entidades.SOxServidor so = new Entidades.SOxServidor();
            so.IdSOxServidor = Convert.ToInt32(gdvSO.Rows[e.RowIndex].Cells[1].Text);
            so.Servidor = null;
            so.SO = null;
            so.Estatus = null;
            if(permisos.D)
            { 
                Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
                resultado = Negocio.Inventarios.SOxServidor.Eliminar(so);

                resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                {
                    lblResultado.Text += error.descripcionCorta + "<br/>";
                });

                if (resultado.resultado == true)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Green;
                    ObtenerParametros();
                    llenarGdvSO();
                }
            }
            else
            {
                lblResultado.Text = "No tienes privilegios para eliminar información";
            }
        }
    }
}