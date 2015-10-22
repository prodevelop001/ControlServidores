<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="ControlServidores.Web.Seguridad.Roles" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="ControlServidores.Web.Seguridad.Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
    <script src="../Scripts/Scripts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">  
    <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
    <asp:updatepanel id="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="principal">

                <div id="numCols" class="hide">9</div>
                <div class="ttlPrincipal">
                    <h1>Roles</h1>
                </div>
                <asp:Panel ID="pnlResultado" CssClass="barraEstatus" runat="server">
                    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <div class="addNuevo">
                    <asp:HiddenField ID="hdfEstado" runat="server"></asp:HiddenField>
                    <asp:Button ID="btnNuevo" runat="server" CssClass="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click"></asp:Button>
                </div>
                <asp:Panel ID="pnlFormRol" runat="server">
                    <div class="formCampos">
                        <asp:Label ID="lblIdRol" CssClass="hide" runat="server" Text=""></asp:Label>
                        <div class="grpInput">
                            <label>Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="*Nombre requerido." ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="Roles"></asp:RequiredFieldValidator>
                        </div>
                        <div class="grpInputTitulo">
                            Permisos:
                        </div>
                        <div class="grpGridCbx">
                            <div class="grpInputCbx">
                                <asp:CheckBox ID="cbxCrear" Text="Crear" runat="server"></asp:CheckBox>
                            </div>
                            <div class="grpInputCbx">
                                <asp:CheckBox ID="cbxConsultar" Text="Consultar" runat="server"></asp:CheckBox>
                            </div>
                            <div class="grpInputCbx">
                                <asp:CheckBox ID="cbxEditar" Text="Editar" runat="server"></asp:CheckBox>
                            </div>
                            <div class="grpInputCbx">
                                <asp:CheckBox ID="cbxEliminar" Text="Eliminar" runat="server"></asp:CheckBox>
                            </div>
                        </div>
                        <div class="grpInputTitulo">
                            Accessos a:
                        </div>
                        <div class="grpGridAcc">
                            <asp:Repeater ID="rptMenu" runat="server" OnItemDataBound="rptMenu_ItemDataBound">
                               <ItemTemplate>
                                   <div class="grpAccCbx">
                                    <asp:HiddenField ID="hdfIdMenu" runat="server" Value='<%# Eval("IdMenu")%>'></asp:HiddenField>
                                    <span class="icon-list2"></span>
                                    <asp:CheckBox ID="cbxMenu" runat="server" />
                                    <label><%# Eval("Nombre")%></label>
                                    <br />
                                    <asp:CheckBoxList ID="cblSubMenu1" runat="server" CssClass="tablaBox"></asp:CheckBoxList>
                                   </div>
                               </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                        <div class="formBotones">
                            <asp:Button ID="btnGuardar" runat="server" CssClass="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="Roles"></asp:Button>
                            <asp:Button ID ="btnCancelar" runat="server" CssClass="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                        </div>
                </asp:Panel>
                <asp:Panel ID="pnlRoles" runat="server">
                    <asp:GridView ID="gdvRoles" runat="server" CssClass="miTabla9" AutoGenerateColumns="False" style="text-align: center" OnSelectedIndexChanged="gdvRoles_SelectedIndexChanged" OnRowDataBound="gdvRoles_RowDataBound" OnRowDeleting="gdvRoles_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DisplayIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdRol" HeaderText="IdRol">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NombreRol" HeaderText="Rol" />
                            <asp:CheckBoxField DataField="C" HeaderText="Crear" ReadOnly="True" />
                            <asp:CheckBoxField DataField="R" HeaderText="Consultar" ReadOnly="True" />
                            <asp:CheckBoxField DataField="U" HeaderText="Editar" ReadOnly="True" />
                            <asp:CheckBoxField DataField="D" HeaderText="Eliminar" ReadOnly="True" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:updatepanel>
</asp:Content>
