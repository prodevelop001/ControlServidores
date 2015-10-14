  <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="ControlServidores.Web.Seguridad.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/Scripts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <div>
                    <asp:HiddenField ID="hdfEstado" runat="server" />
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                </div>
                <asp:Panel ID="pnlFormulario" runat="server">
                    <div>
                        <asp:Label ID="lblIdUsuario" runat="server" CssClass="hide" Text="Label"></asp:Label>
                    </div>
                    <label>Nombre de usuario</label>
                    <div>
                        <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="*Nombre de usuario requerido." ControlToValidate="txtNombreUsuario" ForeColor="Red" ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                    </div>
                    <label>Rol</label>
                    <div>
                        <asp:DropDownList ID="ddlRol" runat="server"></asp:DropDownList>
                    </div>
                    <label>Ligar a </label>
                    <div>
                        <asp:DropDownList ID="ddlPersona" runat="server"></asp:DropDownList>
                    </div>
                    <label>Contraseña</label>
                    <div>
                        <asp:TextBox ID="txtPass1" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPass1" runat="server" ErrorMessage="*Contraseña requerida." ControlToValidate="txtPass1" ForeColor="Red" ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                    </div>
                    <label>Confirmar contraseña</label>
                    <div>
                        <asp:TextBox ID="txtPass2" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPass2" runat="server" ErrorMessage="*Confirmacion requerida." ControlToValidate="txtPass2" ForeColor="Red" ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                    </div>
                    <div>
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="Usuarios" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlUsuarios" runat="server">
                    <asp:GridView ID="gdvUsuarios" runat="server" AutoGenerateColumns="False" OnRowDataBound="gdvUsuarios_RowDataBound" OnRowDeleting="gdvUsuarios_RowDeleting" OnSelectedIndexChanged="gdvUsuarios_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="IdRol.IdRol" HeaderText="IdRol">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Rol">
                                <ItemTemplate>
                                    <asp:Label ID="lblRol1" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdPersona.IdPersona" HeaderText="IdPersona">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Liagado a">
                                <ItemTemplate>
                                    <asp:Label ID="lblPersona1" runat="server" Text="Label"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="True" />
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <div>
                    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
