﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Soporte.aspx.cs" Inherits="ControlServidores.Web.Inventarios.Soporte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
    <script type="text/javascript" src="../Scripts/jquery-2.1.1.js"></script>
    <script type="text/javascript" src="../Scripts/jquery_ui/jquery-ui.js"></script>
    <link href="../Scripts/jquery_ui/jquery-ui.css" rel="stylesheet" />
    <script type="text/javascript">
        function InIEvent() 
        {
            $('#<%= txtFechaIni.ClientID%>').datepicker({
                        changeMonth: true,
                        changeYear: true
            });
            $('#<%= txtFechaFin.ClientID%>').datepicker({
                        changeMonth: true,
                        changeYear: true
            });
        };
        $(document).ready(InIEvent);
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
    <div class="principal">
        <div class="ttlPrincipal">
            <h1>Soporte a Modelos de Servidores</h1>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
        </script>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div>
                    <asp:Panel ID="pnlResultado" CssClass="barraEstatus" runat="server">
                        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                    </asp:Panel>
                    
                    <div class="addNuevo">
                        <asp:HiddenField ID="hdfEstado" runat="server"></asp:HiddenField>
                        <asp:HiddenField ID="hdfIdSoporte" runat="server" />
                        <asp:Button ID="btnNuevo" CssClass="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                    </div>
                    <asp:Panel ID="pnlForm" Visible="false" runat="server">
                        <div class="formCampos">
                            <label>Empresa</label>
                            <asp:DropDownList ID="ddlEmpresa" runat="server"></asp:DropDownList>
                        </div>
                        <div class="formCampos">
                            <label>Marca</label>
                            <asp:DropDownList ID="ddlMarca" runat="server" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </div>
                        <div class="formCampos">
                            <label>Modelo</label>
                            <asp:DropDownList ID="ddlModelo" runat="server"></asp:DropDownList>
                        </div>
                        <div class="formCampos">
                            <label>Fecha inicio</label>
                            <asp:TextBox ID="txtFechaIni" runat="server"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvFechaIni" runat="server" ErrorMessage="*Fecha requerida." ControlToValidate="txtFechaIni" ForeColor="Red" ValidationGroup="Soporte"></asp:RequiredFieldValidator>
                        </div>
                        <div class="formCampos">
                            <label>Fecha fin</label>
                            <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                            <br />
                            <asp:RequiredFieldValidator ID="rfvFechaFin" runat="server" ErrorMessage="*Fecha requerida." ControlToValidate="txtFechaFin" ForeColor="Red" ValidationGroup="Soporte"></asp:RequiredFieldValidator>
                        </div>
                        <!-- Fecha con Calendario -->
                        <%--<div class="formCampos">
                            <label>FechaDentro INICIO:</label>
                            <asp:TextBox ID="pruebaFechaDentro" runat="server" ></asp:TextBox>
                        </div>
                        <div class="formCampos">
                            <label>FechaDentro FIN:</label>
                            <asp:TextBox ID="pruebaFechaDentroFin" runat="server" ></asp:TextBox>
                        </div>--%>
                        <div class="formBotones">
                            <asp:Button ID="btnGuardar" CssClass="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                            <asp:Button ID="btnCancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlSoporte" runat="server">
                        
                        
                        <asp:GridView ID="gdvSoporte" CssClass="miTabla" runat="server" AutoGenerateColumns="False" OnRowDataBound="gdvSoporte_RowDataBound" OnSelectedIndexChanged="gdvSoporte_SelectedIndexChanged" OnRowDeleting="gdvSoporte_RowDeleting">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdSoporte" HeaderText="IdSoporte">
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Empresa.IdEmpresa" HeaderText="IdEmpresa">
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Empresa.Nombre" HeaderText="Empresa" />
                                <asp:BoundField DataField="Modelo.IdMarca" HeaderText="IdMarca">
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Modelo.IdModelo" HeaderText="IdModelo">
                                    <HeaderStyle CssClass="hide" />
                                    <ItemStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Modelo.NombreModelo" HeaderText="Modelo" />
                                <asp:BoundField DataField="FechaInicio" DataFormatString="{0:d}" HeaderText="Fecha Inicio" />
                                <asp:BoundField DataField="FechaFin" DataFormatString="{0:d}" HeaderText="Fecha Fin" />
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

