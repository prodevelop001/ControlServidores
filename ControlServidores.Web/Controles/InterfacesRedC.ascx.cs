﻿using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Controles
{
    public partial class InterfacesRedC : System.Web.UI.UserControl
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();

        private int _IdServidor;

        public int IdServidor
        {
            get { return _IdServidor; }

            set { _IdServidor = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            if (permisos.R == true)
            {
                if (!IsPostBack)
                {
                    hdfIdServidor.Value = _IdServidor.ToString();
                    InterfacesRed();
                }
                btnAdd.Enabled = permisos.C;
            }
        }

        private void ObtenerParametros()
        {
            _IdServidor = Convert.ToInt32(hdfIdServidor.Value);
        }

        private void InterfacesRed()
        {
            gdvInterfacesRed.DataSource = Negocio.Inventarios.ConfRed.Obtener(new Entidades.ConfRed() { Servidor = new Entidades.Servidor() { IdServidor = _IdServidor, Modelo = null, Especificacion = null, TipoServidor = null }, Estatus = null});
            gdvInterfacesRed.DataBind();
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
                IdConceptoEstatus = 2
            });
            ddlEstatus.DataBind();
        }

        private void Limpiar()
        {
            txtInterfazRed.Text = string.Empty;
            txtDirMAC.Text = string.Empty;
            txtDirIP.Text = string.Empty;
            txtMascaraSubRed.Text = string.Empty;
            txtGateway.Text = string.Empty;
            txtDNS.Text = string.Empty;
            txtVlan.Text = string.Empty;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Limpiar();
            lblResultado.Text = string.Empty;
            pnlFormIntRed.Visible = true;
            gdvInterfacesRed.Visible = false;
            llenarDdlEstatus();
            hdfEstado.Value = "1";
            btnGuardar.Text = "Guardar";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            pnlFormIntRed.Visible = false;
            gdvInterfacesRed.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            lblResultado.ForeColor = System.Drawing.Color.Red;
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();

            if (ddlEstatus.SelectedValue != "0")
            {
                Entidades.ConfRed nuevaInterfaz = new Entidades.ConfRed();
                nuevaInterfaz.Servidor.IdServidor = Convert.ToInt32(hdfIdServidor.Value);
                nuevaInterfaz.InterfazRed = txtInterfazRed.Text.Trim();
                nuevaInterfaz.DirMac = txtDirMAC.Text.Trim();
                nuevaInterfaz.DirIP = txtDirIP.Text.Trim();
                nuevaInterfaz.MascaraSubRed = txtMascaraSubRed.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtGateway.Text.Trim()))
                    nuevaInterfaz.Gateway = txtGateway.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtDNS.Text.Trim()))
                    nuevaInterfaz.DNS = txtDNS.Text.Trim();
                if (!string.IsNullOrWhiteSpace(txtVlan.Text.Trim()))
                    nuevaInterfaz.VLAN = txtVlan.Text.Trim();
                nuevaInterfaz.Estatus.IdEstatus = Convert.ToInt32(ddlEstatus.SelectedValue);

                //Guardar
                if (hdfEstado.Value == "1" && permisos.C == true)
                {
                    resultado = Negocio.Inventarios.ConfRed.Nuevo(nuevaInterfaz);
                }
                else if (hdfEstado.Value == "2" && permisos.U == true) //actualizar
                {
                    nuevaInterfaz.IdConfRed = Convert.ToInt32(hdfIdConfRed.Value);
                    resultado = Negocio.Inventarios.ConfRed.Actualizar(nuevaInterfaz);
                }
                else
                {
                    lblResultado.Text = "No tienes privilegios para realizar esta acción.";
                }

                resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                {
                    lblResultado.Text += error.descripcionCorta + "<br/>";
                });

                lblResultado.ForeColor = System.Drawing.Color.Red;
                if (resultado.resultado == true)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Green;
                    hdfEstado.Value = "0";
                    pnlFormIntRed.Visible = false;
                    gdvInterfacesRed.Visible = true;
                    ObtenerParametros();
                    InterfacesRed();
                }
            }
            else
            {
                lblResultado.Text = "Debe seleccionar un estatus.";
            }
            
        }

        protected void gdvInterfacesRed_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlFormIntRed.Visible = true;
            gdvInterfacesRed.Visible = false;
            llenarDdlEstatus();

            hdfEstado.Value = "2";
            hdfIdConfRed.Value = gdvInterfacesRed.SelectedRow.Cells[1].Text.Trim();
            List<Entidades.ConfRed> redlist = new List<Entidades.ConfRed>();
            redlist = Negocio.Inventarios.ConfRed.Obtener(new Entidades.ConfRed() { IdConfRed = Convert.ToInt32(hdfIdConfRed.Value), Servidor= null});

            redlist.ForEach(delegate (Entidades.ConfRed r)
            {
                txtInterfazRed.Text = r.InterfazRed;
                txtDirMAC.Text = r.DirMac;
                txtDirIP.Text = r.DirIP;
                txtMascaraSubRed.Text = r.MascaraSubRed;
                txtGateway.Text = r.Gateway;
                txtDNS.Text = r.DNS;
                txtVlan.Text = r.VLAN;
                ddlEstatus.SelectedValue = r.Estatus!= null ? r.Estatus.IdEstatus.ToString(): "0";
            });

        }

        protected void gdvInterfacesRed_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        //LinkButton button = (LinkButton)control;
                        LinkButton button = control as LinkButton;
                        if (button != null && button.Text == " Eliminar")
                        {
                            //button.Enabled = permisos.D;
                            if (button.Enabled)
                                button.OnClientClick = "return checkMe()";
                        }
                    }
                }
            }
        }

        protected void gdvInterfacesRed_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblResultado.Text = string.Empty;
            lblResultado.ForeColor = System.Drawing.Color.Red;
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            if(permisos.D == true)
            { 
                Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
                Entidades.ConfRed red = new Entidades.ConfRed();
                red.IdConfRed = Convert.ToInt32(gdvInterfacesRed.Rows[e.RowIndex].Cells[1].Text);
                red.Servidor = null;
                red.Estatus = null;

                resultado = Negocio.Inventarios.ConfRed.Eliminar(red);
                resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
                {
                    lblResultado.Text += error.descripcionCorta + "<br/>";
                });

                if (resultado.resultado == true)
                {
                    lblResultado.ForeColor = System.Drawing.Color.Green;
                    ObtenerParametros();
                    InterfacesRed();
                }
            }
            else
            {
                lblResultado.Text = "No tienes privilegios para eliminar información";
            }
        }
    }
}