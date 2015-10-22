﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Servidores.aspx.cs" Inherits="ControlServidores.Web.Inventarios.Servidores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
<%--    <style>
        .marco {
            border: 1px solid gray;
            border-radius: 5px;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
    <div class="principal">
        <div class="ttlPrincipal">
            <h1>Servidores</h1>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <div class="addNuevo">
                        <asp:Button ID="btnNuevo" runat="server" CssClass="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click" />
                    </div>
                    <asp:Panel ID="pnlNuevoServidor" CssClass="nuevoServidor" Visible="false" runat="server">
                            
                            <div class="grpNuevoServidor">
                                <label>Alias de servidor</label>
                                <asp:RequiredFieldValidator ID="rfvAliasServidor" runat="server" ErrorMessage="*Alias requerido" ControlToValidate="txtAliasServidor" ForeColor="Red" ValidationGroup="Servidor"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtAliasServidor" runat="server" placeholder="Hostname"></asp:TextBox>
                            </div>
                            
                            <div class="grpNuevoServidor">
                                <label>Aplicación</label>
                                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="*Descripción requerida" ControlToValidate="txtDescripcionUso" ForeColor="Red" ValidationGroup="Servidor"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtDescripcionUso" runat="server" placeholder="¿Qué aplicación hospeda?"></asp:TextBox>
                            </div>
                            
                            <div class="grpNuevoServidor">
                                <label>Sistema Operativo</label>
                                <asp:DropDownList ID="ddlSO" runat="server"></asp:DropDownList>
                            </div>
                            
                            <div  class="grpNuevoServidor">
                                <label>Nombre de la interfaz</label>
                                <asp:RequiredFieldValidator ID="rfvNombreInterfaz" runat="server" ErrorMessage="*Campo requerido." ControlToValidate="txtInterfazRed" ForeColor="Red" ValidationGroup="Servidor"></asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtInterfazRed" runat="server" placeholder="Ej: eth0"></asp:TextBox>
                            </div>
                            
                            <div class="grpNuevoServidorRed">
                                <label>Dirección IP</label> 
                                <asp:RequiredFieldValidator ID="rfvDirIp" runat="server" ErrorMessage="*IP requerida" ControlToValidate="txtDirIP" ForeColor="Red" ValidationGroup="Servidor"></asp:RequiredFieldValidator><br />
                                <asp:RegularExpressionValidator ID="revDirIP" runat="server" ErrorMessage="*IP no valida." ValidationExpression="^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){2}(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))$" ValidationGroup="Servidor" ControlToValidate="txtDirIP" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txtDirIP" runat="server" placeholder="Ej: 10.1.16.129"></asp:TextBox>
                            </div>
                            
                            <div class="grpNuevoServidorRed">
                                <label>Masca Sub Red</label>
                                <asp:RequiredFieldValidator ID="rfvSubNet" runat="server" ErrorMessage="*Sub Red requerida." ControlToValidate="txtMascaraSubRed" ForeColor="Red" ValidationGroup="Servidor"></asp:RequiredFieldValidator><br />
                                <asp:RegularExpressionValidator ID="revSubNet" runat="server" ErrorMessage="*IP no valida." ControlToValidate="txtMascaraSubRed" ValidationExpression="^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){2}(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))$" ValidationGroup="Servidor" ForeColor="Red"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txtMascaraSubRed" runat="server" placeholder="Ej: 255.255.255.224"></asp:TextBox>
                            </div>
                            
                            <div class="grpNuevoServidor">
                                <label>Gateway</label>
                                <asp:RegularExpressionValidator ID="revGateway" runat="server" ErrorMessage="*IP no valida." ControlToValidate="txtGateway" ForeColor="Red" ValidationExpression="^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){2}(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))$" ValidationGroup="Servidor"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txtGateway" runat="server" placeholder="Ej: 10.1.16.158"></asp:TextBox>
                            </div>
                            
                            <div class="grpNuevoServidor">
                                <label>DNS</label>
                                <asp:RegularExpressionValidator ID="revDNS" runat="server" ErrorMessage="*IP no valida." ControlToValidate="txtDNS" ForeColor="Red" ValidationExpression="^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){2}(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))$" ValidationGroup="Servidor"></asp:RegularExpressionValidator>
                                <asp:TextBox ID="txtDNS" runat="server" placeholder="Ej: 10.1.70.40"></asp:TextBox>
                            </div>                 
                            
                            <div class="grpNuevoServidor">
                                <label>Estatus de Servidor</label>
                                <asp:DropDownList ID="ddlEstatusServidor" runat="server"></asp:DropDownList>
                            </div>
                        <div class="servidoresBotones">
                            <asp:Button ID="btnGuardar" runat="server" CssClass="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="Servidor" />
                            <asp:Button ID="btnCancelar" runat="server" CssClass="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" />
                        </div>
                    </asp:Panel>
                    <div style="width: 100%; margin: 0; float: left;">
                        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                    </div>
                    <asp:Panel ID="pnlServidores" Visible="false" runat="server">
                        <div class="formBusqueda">
                            <div class="busquedaGrp">
                                <label>Por alias:&nbsp;</label>
                                <asp:TextBox ID="txtPorAlias" runat="server"></asp:TextBox>
                            </div>
                            <div class="busquedaGrp">
                                <label>Por IP:&nbsp;</label>
                                <asp:TextBox ID="txtPorIp" runat="server"></asp:TextBox>
                            </div>
                            <div class="busquedaGrp">
                                <label>Por aplicación:&nbsp;</label>
                                <asp:TextBox ID="txtPorAplicacion" runat="server"></asp:TextBox>
                            </div>
                            <div class="busquedaBoton">
                                <asp:RegularExpressionValidator ID="revPorIp" runat="server" ErrorMessage="Ip invalida." ControlToValidate="txtPorIp" ForeColor="Red" ValidationExpression="^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){2}(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]))$" ValidationGroup="Servidor2"></asp:RegularExpressionValidator>
                                <asp:Button ID="btnBuscar" CssClass="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" ValidationGroup="Servidor2" />
                            </div>
                        </div>
                        <div class="listServidores">
                            <asp:Repeater ID="rptServidores" runat="server" OnItemDataBound="rptServidores_ItemDataBound">
                                <ItemTemplate>
                                    <div class="elemServidor">
                                        <asp:HiddenField ID="hdfIdServidor" Value='<%# Eval("IdServidor") %>' runat="server" />
                                        <asp:HiddenField ID="hdfIdVirtualizador" Value='<%# Eval("IdVirtualizador") %>' runat="server" />
                                        <div class="titulos">
                                            <%--<label>Server name:&nbsp;</label>--%>
                                            <a href='DetalleServidor.aspx?IdServidor=<%# Eval("IdServidor") %>'><%# Eval("AliasServidor") %></a></div>
                                        <div class="descripcion">
                                            <label>Descripción uso : &nbsp;</label>
                                            <asp:Label ID="LblDescripcion" runat="server" Text='<%# Eval("DescripcionUso") %>'></asp:Label>
                                            <label>Dirección IP : &nbsp;</label>
                                            
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
                        </div>
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
