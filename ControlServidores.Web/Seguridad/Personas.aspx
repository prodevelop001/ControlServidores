<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="ControlServidores.Web.Seguridad.Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/Scripts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
    <asp:updatepanel id="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <div>
                    <asp:HiddenField ID="hdfEstado" runat="server" />
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                </div>
                <asp:Panel ID="pnlFormulario" runat="server">
                    <div>
                        <asp:Label ID="lblIdPersona" CssClass="hide" runat="server" Text=""></asp:Label>
                        <label>Nombre</label>
                        <div>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="*Nombre requerido." ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="Personas"></asp:RequiredFieldValidator>
                        </div>
                        <label>Puesto</label>
                        <div>
                            <asp:TextBox ID="txtPuesto" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvPuesto" runat="server" ErrorMessage="*Puesto requerido." ControlToValidate="txtPuesto" ForeColor="Red" ValidationGroup="Personas"></asp:RequiredFieldValidator>
                        </div>
                        <label>Extensión</label>
                        <div>
                            <asp:TextBox ID="txtExtension" runat="server" TextMode="Number"></asp:TextBox><asp:RequiredFieldValidator ID="rfvExtension" runat="server" ErrorMessage="*Extensión requerida." ControlToValidate="txtExtension" ForeColor="Red" ValidationGroup="Personas"></asp:RequiredFieldValidator>
                        </div>
                        <label>Correo</label>
                        <div>
                            <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email"></asp:TextBox><asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ErrorMessage="*Correo requerido." ControlToValidate="txtCorreo" ForeColor="Red" ValidationGroup="Personas"></asp:RequiredFieldValidator>
                        </div>
                        <label>Estatus</label>
                        <div>
                            <asp:DropDownList ID="ddlEstatus" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div>
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" ValidationGroup="Personas" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlPersonas" runat="server">
                    <asp:GridView ID="gdvPersonas" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvPersonas_SelectedIndexChanged" OnRowDataBound="gdvPersonas_RowDataBound" OnRowDeleting="gdvPersonas_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdPersona" HeaderText="IdPersona">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Puesto" HeaderText="Puesto" />
                            <asp:BoundField DataField="Extension" HeaderText="Extension" />
                            <asp:BoundField DataField="Correo" HeaderText="Correo" />
                            <asp:BoundField DataField="IdEstatus" HeaderText="IdEstatus" >
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Estatus">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstatus" runat="server" Text=""></asp:Label>
                                </ItemTemplate>                               
                            </asp:TemplateField>
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <div>
                    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:updatepanel>
</asp:Content>
