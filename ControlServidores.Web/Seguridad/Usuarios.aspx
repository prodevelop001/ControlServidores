<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="ControlServidores.Web.Seguridad.Usuarios" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="ControlServidores.Web.Seguridad.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
    <%--<script src="../Scripts/Scripts.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">
    <div id="numCols" class="hide">9</div>
        <div class="ttlPrincipal">
            <h1>Usuarios</h1>
        </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:Panel ID="pnlResultado" CssClass="barraEstatus" runat="server">
                    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <div class="addNuevo">
                    <asp:HiddenField ID="hdfEstado" runat="server" />
                    <asp:Button ID="btnNuevo" runat="server" CssClass="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click" />
                </div>
                <asp:Panel ID="pnlFormulario" runat="server">
                    <div class="formCampos">
                        <asp:Label ID="lblIdUsuario" runat="server" CssClass="hide" Text="Label"></asp:Label>
                        <div class="grpInput">
                            <label>Nombre de Usuario :</label>
                            <asp:TextBox ID="txtNombreUsuario" runat="server" placeholder="Ej: mramirez"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="*Nombre de usuario requerido." ControlToValidate="txtNombreUsuario" ForeColor="Red" ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                        </div>
                        <div class="grpInput">
                            <label>Rol :</label>
                            <asp:DropDownList ID="ddlRol" runat="server"></asp:DropDownList>   
                        </div> 
                        <div class="grpInput">                   
                            <label>Ligar a :</label>
                            <asp:DropDownList ID="ddlPersona" runat="server"></asp:DropDownList>
                        </div>
                        <div class="grpInput">
                            <label>Contraseña :</label>
                            <asp:TextBox ID="txtPass1" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPass1" runat="server" ErrorMessage="*Contraseña requerida." ControlToValidate="txtPass1" ForeColor="Red" ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                        </div>
                        <div class="grpInput">
                            <label>Confirmar Contraseña :</label>
                            <asp:TextBox ID="txtPass2" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPass2" runat="server" ErrorMessage="*Confirmacion requerida." ControlToValidate="txtPass2" ForeColor="Red" ValidationGroup="Usuarios"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="formBotones">
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btnGuardar" Text="Guardar" ValidationGroup="Usuarios" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlUsuarios" runat="server">
                    <asp:GridView ID="gdvUsuarios" runat="server" CssClass="miTabla" AutoGenerateColumns="False" OnRowDataBound="gdvUsuarios_RowDataBound" OnRowDeleting="gdvUsuarios_RowDeleting" OnSelectedIndexChanged="gdvUsuarios_SelectedIndexChanged">
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
                            <asp:CommandField ControlStyle-CssClass="icon-pencil" SelectText=" Seleccionar" ShowSelectButton="True" />
                            <asp:CommandField ControlStyle-CssClass="icon-cross" DeleteText=" Eliminar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
