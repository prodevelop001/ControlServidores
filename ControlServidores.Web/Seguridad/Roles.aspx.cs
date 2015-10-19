using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlServidores.Web.Seguridad
{
    public partial class Roles : System.Web.UI.Page
    {
        Entidades.RolUsuario permisos = new Entidades.RolUsuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Este ID debe coincidir con el Menú registrado en la BD
            int IdPagina = 8;
            if (Negocio.Seguridad.Seguridad.AccesoPagina(IdPagina) == true)
            {
                if (!IsPostBack)
                {
                    permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
                    if (permisos.R == true)
                    {
                        pnlFormRol.Visible = false;
                        llenarGdvRoles();
                    }
                    btnNuevo.Enabled = permisos.C;
                }
            }
            else
            {
                Response.Redirect("~/errorAcceso.aspx");
            }
        }

        private void llenarGdvRoles()
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            gdvRoles.DataSource = Negocio.Seguridad.RolUsuario.Obtener(new Entidades.RolUsuario());
            gdvRoles.DataBind();
        }

        private void llenarMenu()
        {
            rptMenu.DataSource = Negocio.Seguridad.Menu.Obtener(new Entidades.Menu()
            {
                Nodo = 0,
                Sesion = 1
            });
            rptMenu.DataBind();
        }

        protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField idMenu = (HiddenField)e.Item.FindControl("hdfIdMenu");
            int IdMenu = Convert.ToInt32(idMenu.Value);

            CheckBox cbxMenu = (CheckBox)e.Item.FindControl("cbxMenu");
            cbxMenu.Visible = false;
            CheckBoxList cblSubmenu1 = (CheckBoxList)e.Item.FindControl("cblSubmenu1");
            cblSubmenu1.DataTextField = "Nombre";
            cblSubmenu1.DataValueField = "IdMenu";
            cblSubmenu1.DataSource = Negocio.Seguridad.Menu.Obtener(new Entidades.Menu()
            {
                Nodo = IdMenu,
                Sesion = 1
            });
            cblSubmenu1.DataBind();
            if(cblSubmenu1.Items.Count == 0)
            {
                cbxMenu.Visible = true;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "1";
            btnGuardar.Text = "Guardar";
            btnGuardar.Enabled = permisos.C;
            txtNombre.Text = string.Empty;
            lblResultado.Text = string.Empty;
            pnlRoles.Visible = false;
            pnlFormRol.Visible = true;
            llenarMenu();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            hdfEstado.Value = "0";
            lblResultado.Text = string.Empty;
            pnlRoles.Visible = true;
            pnlFormRol.Visible = false;
            btnNuevo.Visible = true;
        }

        protected void gdvRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            hdfEstado.Value = "2";
            btnNuevo.Visible = false;
            btnGuardar.Text = "Actualizar";
            btnGuardar.Enabled = permisos.U;            
            lblIdRol.Text = gdvRoles.SelectedRow.Cells[1].Text;
            int IdRol = Convert.ToInt32(gdvRoles.SelectedRow.Cells[1].Text);
            txtNombre.Text = HttpUtility.HtmlDecode(gdvRoles.SelectedRow.Cells[2].Text);
            lblResultado.Text = string.Empty;
            pnlRoles.Visible = false;
            pnlFormRol.Visible = true;
            cbxCrear.Checked = ((CheckBox)gdvRoles.SelectedRow.Cells[3].Controls[0]).Checked;
            cbxConsultar.Checked = ((CheckBox)gdvRoles.SelectedRow.Cells[4].Controls[0]).Checked;
            cbxEditar.Checked = ((CheckBox)gdvRoles.SelectedRow.Cells[5].Controls[0]).Checked;
            cbxEliminar.Checked = ((CheckBox)gdvRoles.SelectedRow.Cells[6].Controls[0]).Checked;
            llenarMenu();
            List<Entidades.MenuXrol> menuRol = Negocio.Seguridad.MenuXrol.Obtener(new Entidades.MenuXrol()
            {
                IdRol = new Entidades.RolUsuario() { IdRol = IdRol }
            });

            foreach (RepeaterItem item in rptMenu.Items)
            {
                HiddenField idMenu = (HiddenField)item.FindControl("hdfIdMenu");
                CheckBox cbxMenu = (CheckBox)item.FindControl("cbxMenu");
                CheckBoxList cblSubmenu1 = (CheckBoxList)item.FindControl("cblSubmenu1");
                
                menuRol.ForEach(delegate (Entidades.MenuXrol m)
                {
                    if (cbxMenu.Visible)
                    {
                        if(idMenu.Value == m.IdMenu.IdMenu.ToString())
                        {
                            cbxMenu.Checked = true;
                        }
                    }
                    foreach (ListItem cbxItem in cblSubmenu1.Items)
                    {
                        if (cbxItem.Value == m.IdMenu.IdMenu.ToString())
                        {
                            cbxItem.Selected = true;
                        }
                    }
                });
            }
        }

        protected void gdvRoles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    foreach (Control control in cell.Controls)
                    {
                        LinkButton button = control as LinkButton;
                        if (button != null && button.Text == "Eliminar")
                        {
                            button.Enabled = permisos.D;
                            if(button.Enabled)
                                button.OnClientClick = "return checkMe()";
                        }
                    }
                }
            }
        }

        protected void gdvRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            lblResultado.Text = string.Empty;
            int IdRol = Convert.ToInt32(gdvRoles.Rows[e.RowIndex].Cells[1].Text);
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            resultado = Negocio.Seguridad.RolUsuario.Borrar(new Entidades.RolUsuario()
            {
                IdRol = IdRol
            });

            resultado.errores.ForEach(delegate (Entidades.Logica.Error error)
            {
                lblResultado.Text += error.descripcionCorta + "<br/>";
            });

            lblResultado.ForeColor = System.Drawing.Color.Red;
            if (resultado.resultado == true)
            {
                lblResultado.ForeColor = System.Drawing.Color.Green;
                llenarGdvRoles();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            permisos = Negocio.Seguridad.Seguridad.verificarPermisos();
            Entidades.Logica.Ejecucion resultado = new Entidades.Logica.Ejecucion();
            
            List<Entidades.MenuXrol> listMenu = new List<Entidades.MenuXrol>();

            if (hdfEstado.Value == "1" && permisos.C)
            {
                Entidades.RolUsuario nuevoRol = new Entidades.RolUsuario()
                {
                    NombreRol = txtNombre.Text,
                    C = cbxCrear.Checked,
                    R = cbxConsultar.Checked,
                    U = cbxEditar.Checked,
                    D = cbxEliminar.Checked
                };
                foreach (RepeaterItem item in rptMenu.Items)
                {
                    int cont = 0;
                    HiddenField idMenu = (HiddenField)item.FindControl("hdfIdMenu");
                    int IdMenu = Convert.ToInt32(idMenu.Value);
                    CheckBox cbxMenu = (CheckBox)item.FindControl("cbxMenu");
                    CheckBoxList cblSubmenu1 = (CheckBoxList)item.FindControl("cblSubmenu1");
                    foreach (ListItem cbxItem in cblSubmenu1.Items)
                    {
                        if (cbxItem.Selected)
                        {
                            Entidades.MenuXrol m = new Entidades.MenuXrol();
                            m.IdMenu.IdMenu = Convert.ToInt32(cbxItem.Value);
                            listMenu.Add(m);
                            cont++;
                        }
                    }
                    if(cont > 0)
                    {
                        Entidades.MenuXrol m = new Entidades.MenuXrol();
                        m.IdMenu.IdMenu = IdMenu;
                        listMenu.Add(m);
                    }
                    if(cbxMenu.Visible)
                    {
                        if(cbxMenu.Checked)
                        {
                            Entidades.MenuXrol m = new Entidades.MenuXrol();
                            m.IdMenu.IdMenu = Convert.ToInt32(IdMenu);
                            listMenu.Add(m);
                        }
                    }
                }

                resultado = Negocio.Seguridad.RolUsuario.Nuevo(nuevoRol,listMenu);
            }
            else if (hdfEstado.Value == "2" && permisos.U)
            {
                int IdRol = Convert.ToInt32(lblIdRol.Text);
                Entidades.RolUsuario nuevoRol = new Entidades.RolUsuario()
                {
                    IdRol = Convert.ToInt32(lblIdRol.Text),
                    NombreRol = txtNombre.Text,
                    C = cbxCrear.Checked,
                    R = cbxConsultar.Checked,
                    U = cbxEditar.Checked,
                    D = cbxEliminar.Checked
                };

                foreach (RepeaterItem item in rptMenu.Items)
                {
                    int cont = 0;
                    HiddenField idMenu = (HiddenField)item.FindControl("hdfIdMenu");
                    int IdMenu = Convert.ToInt32(idMenu.Value);
                    CheckBox cbxMenu = (CheckBox)item.FindControl("cbxMenu");
                    CheckBoxList cblSubmenu1 = (CheckBoxList)item.FindControl("cblSubmenu1");
                    foreach (ListItem cbxItem in cblSubmenu1.Items)
                    {
                        if (cbxItem.Selected)
                        {
                            Entidades.MenuXrol m = new Entidades.MenuXrol();
                            m.IdMenu.IdMenu = Convert.ToInt32(cbxItem.Value);
                            m.IdRol.IdRol = IdRol;
                            listMenu.Add(m);
                            cont++;
                        }
                    }
                    if (cont > 0)
                    {
                        Entidades.MenuXrol m = new Entidades.MenuXrol();
                        m.IdMenu.IdMenu = IdMenu;
                        m.IdRol.IdRol = IdRol;
                        listMenu.Add(m);
                    }
                    if (cbxMenu.Visible)
                    {
                        if (cbxMenu.Checked)
                        {
                            Entidades.MenuXrol m = new Entidades.MenuXrol();
                            m.IdMenu.IdMenu = Convert.ToInt32(IdMenu);
                            m.IdRol.IdRol = IdRol;
                            listMenu.Add(m);
                        }
                    }
                }

                resultado = Negocio.Seguridad.RolUsuario.Actualizar(nuevoRol, listMenu);
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
                btnNuevo.Visible = true;
                btnNuevo.Text = "Nuevo";
                pnlFormRol.Visible = false;
                pnlRoles.Visible = true;
                llenarGdvRoles();
            }
        }

    }
}