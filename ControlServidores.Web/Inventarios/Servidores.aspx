﻿<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Servidores.aspx.cs" Inherits="ControlServidores.Web.Inventarios.Servidores" %>--%>
<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Servidores.aspx.cs" Inherits="ControlServidores.Web.Inventarios.Servidores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
    <style>
        .marco
        {
            border: 1px solid gray;
            border-radius: 5px; 
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <div style="width: 40%; margin: 0;">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                </div>
                <asp:Panel ID="pnlNuevoServidor" Visible="false" runat="server">
                    <div style="width: 40%; margin: 0; float: left;">
                        <label>Alias de servidor</label>
                        <div>
                            <asp:TextBox ID="txtAliasServidor" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvAliasServidor" runat="server" ErrorMessage="*Alias requerido" ControlToValidate="txtAliasServidor" ForeColor="Red" ValidationGroup="Servidor"></asp:RequiredFieldValidator>
                        </div>
                        <label>Servidor para uso de</label>
                        <div>
                            <asp:TextBox ID="txtDescripcionUso" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="*Descripción requerida" ControlToValidate="txtDescripcionUso" ForeColor="Red" ValidationGroup="Servidor"></asp:RequiredFieldValidator>
			            </div>
                        
                        
                    </div>
                    <div style="width: 100%; margin: 0; float: left;">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="Servidor" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </asp:Panel>
                <div style="width: 100%; margin: 0; float: left;">
                    <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                </div>
                <asp:Panel ID="pnlServidores" Visible="false" runat="server">
                    <div>
                        <fieldset>
                            <legend>Busqueda avanzada</legend>
                            <label>Por alias:&nbsp;</label><asp:TextBox ID="txtPorAlias" runat="server"></asp:TextBox>
                            <label>Por IP:&nbsp;</label><asp:TextBox ID="txtPorIp" runat="server"></asp:TextBox>
                            <label>Por aplicación:&nbsp;</label><asp:TextBox ID="txtPorAplicacion" runat="server"></asp:TextBox>
                            &nbsp;
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" ValidationGroup="Servidor2" />
                            <asp:RegularExpressionValidator ID="revPorIp" runat="server" ErrorMessage="*Ip invalida." ControlToValidate="txtPorIp" ForeColor="Red" ValidationExpression="^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){2}(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))$" ValidationGroup="Servidor2"></asp:RegularExpressionValidator>
                        </fieldset>
                    </div>
                    <asp:Repeater ID="rptServidores" runat="server" OnItemDataBound="rptServidores_ItemDataBound">
                        <ItemTemplate>
                            <div class ="marco">
                                <asp:HiddenField ID="hdfIdServidor" Value='<%# Eval("IdServidor") %>' runat="server" />
                                <asp:HiddenField ID="hdfIdVirtualizador" Value='<%# Eval("IdVirtualizador") %>' runat="server" />
                                <div>
                                    <label>Server name:&nbsp;</label><a href='DetalleServidor.aspx?IdServidor=<%# Eval("IdServidor") %>'><%# Eval("AliasServidor") %></a>
                                </div>
                                <div>
                                    <label>Descripción uso : &nbsp;</label><asp:Label ID="LblDescripcion" runat="server" Text='<%# Eval("DescripcionUso") %>'></asp:Label>
                                </div>
                                <div>
                                    <asp:GridView ID="gdvServidoresHijos" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="#">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="AliasServidor" HeaderText="Server Name" />
                                            <asp:BoundField DataField="DescripcionUso" HeaderText="Description App" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href='DetalleServidor.aspx?IdServidor=<%# Eval("IdServidor") %>'>Ver detalle</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
