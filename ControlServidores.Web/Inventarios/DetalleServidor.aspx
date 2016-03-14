<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="DetalleServidor.aspx.cs" Inherits="ControlServidores.Web.Inventarios.DetalleServidor" %>

<%@ Register Src="~/Controles/InterfacesRedC.ascx" TagPrefix="uc1" TagName="InterfacesRedC" %>
<%@ Register Src="~/Controles/SistemasOperativosC.ascx" TagPrefix="uc1" TagName="SistemasOperativosC" %>
<%@ Register Src="~/Controles/StorageC.ascx" TagPrefix="uc1" TagName="StorageC" %>
<%@ Register Src="~/Controles/AlmacenamientoC.ascx" TagPrefix="uc1" TagName="AlmacenamientoC" %>
<%@ Register Src="~/Controles/BitacoraC.ascx" TagPrefix="uc1" TagName="BitacoraC" %>
<%@ Register Src="~/Controles/CaracteristicasC.ascx" TagPrefix="uc1" TagName="CaracteristicasC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
   <script type="text/javascript" src="../Scripts/jquery-2.1.1.js"></script>
    <script type="text/javascript" src="../Scripts/jquery_ui/jquery-ui.js"></script>
    <link href="../Scripts/jquery_ui/jquery-ui.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="ttlPrincipal">
                <h1><asp:Label ID="lblNombreServidor" runat="server"></asp:Label></h1>
            </div>
                <div id="numCols" class="hide">9</div>
                <div class="detallesGenerales">
                    <div class="tituloDetalles">
                        <h4>Detalles Generales</h4>
                    </div>
                    <uc1:CaracteristicasC runat="server" id="CaracteristicasC" />
                </div>
                <%--Fin detalles General--%>
                <asp:Panel ID="pnlVms" Visible="false" CssClass="hostVirtual" runat="server">
                    <div class="tituloDetalles">
                        <h4>MVs que aloja</h4>
                    </div>
                    <asp:GridView ID="gdvVMs" CssClass="miTabla" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:BoundField DataField="AliasServidor" HeaderText="Máquina Virtual" />--%>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href='DetalleServidor.aspx?IdServidor=<%# Eval("IdServidor") %>'><%# Eval("AliasServidor") %></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>

                <div class="almacenammiento">
                    <div class="tituloDetalles">
                        <h4>Almacenamiento</h4>
                    </div>
                    <uc1:AlmacenamientoC runat="server" ID="AlmacenamientoC" />
                </div>
                <div class="interfRed">
                    <div class="tituloDetalles">
                        <h4>Interfaces de Red</h4>
                    </div>
                    <uc1:InterfacesRedC runat="server" ID="InterfacesRedC" />
                </div>
                <div class="sistemas">
                    <div class="tituloDetalles">
                        <h4>Sistema(s)</h4>
                    </div>
                    <uc1:SistemasOperativosC runat="server" ID="SistemasOperativosC" />
                </div>
                <div class="storage">
                    <div class="tituloDetalles">
                        <h4>Almacenamiento Externo</h4>
                    </div>
                    <uc1:StorageC runat="server" ID="StorageC" />
                </div>
                <div class="bitacora">
                    <div class="tituloDetalles">
                        <h4>Bitácora</h4>
                    </div>
                    <uc1:BitacoraC runat="server" ID="BitacoraC" />
                </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>
