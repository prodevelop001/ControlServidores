<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="ControlServidores.Web.Seguridad.Personas" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="ControlServidores.Web.Seguridad.Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
    <script src="../Scripts/Scripts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">
    <div id="numCols" class="hide">10</div>
    <div class="ttlPrincipal">
        <h1>Personas</h1>
    </div>
    <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
    <asp:updatepanel id="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:Panel ID="pnlResultado" CssClass="barraEstatus" runat="server">
                    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <div class="addNuevo">
                    <asp:HiddenField ID="hdfEstado" runat="server"></asp:HiddenField>
                    <asp:Button ID="btnNuevo" runat="server" CssClass="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click"></asp:Button>
                </div>
                <asp:Panel ID="pnlFormulario" runat="server">
                    <div class="formCampos">
                        <asp:Label ID="lblIdPersona" CssClass="hide" runat="server" Text=""></asp:Label>
                        <div class="grpInput">
                            <label>Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="*Nombre requerido." ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="Personas"></asp:RequiredFieldValidator>
                        </div>
                        <div class="grpInput">
                            <label>Puesto</label>
                            <asp:TextBox ID="txtPuesto" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="rfvPuesto" runat="server" ErrorMessage="*Puesto requerido." ControlToValidate="txtPuesto" ForeColor="Red" ValidationGroup="Personas"></asp:RequiredFieldValidator>
                        </div>
                        <div class="grpInput">
                            <label>Extensión</label>
                            <asp:TextBox ID="txtExtension" runat="server" TextMode="Number" MaxLength="4"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvExtension" runat="server" ErrorMessage="*Extensión requerida." ControlToValidate="txtExtension" ForeColor="Red" ValidationGroup="Personas"></asp:RequiredFieldValidator>
                        </div>
                        <div class="grpInput">
                            <label>Correo</label>
                            <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email"></asp:TextBox><asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ErrorMessage="*Correo requerido." ControlToValidate="txtCorreo" ForeColor="Red" ValidationGroup="Personas"></asp:RequiredFieldValidator>
                        </div>
                        <div class="grpInput">
                            <label>Estatus</label>
                            <asp:DropDownList ID="ddlEstatus" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="formBotones">
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btnGuardar" Text="Guardar" ValidationGroup="Personas" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" CssClass="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlPersonas" runat="server">
                    <asp:GridView ID="gdvPersonas" CssClass="miTabla" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gdvPersonas_SelectedIndexChanged" OnRowDataBound="gdvPersonas_RowDataBound" OnRowDeleting="gdvPersonas_RowDeleting">
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
                            <asp:CommandField ControlStyle-CssClass="icon-pencil" SelectText=" Seleccionar" ShowSelectButton="True" />
                            <asp:CommandField ControlStyle-CssClass="icon-cross" DeleteText=" Eliminar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                
            </div>
        </ContentTemplate>
    </asp:updatepanel>
</div>
</asp:Content>
