<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="DetalleServidor.aspx.cs" Inherits="ControlServidores.Web.Inventarios.DetalleServidor" %>

<%@ Register Src="~/Controles/InterfacesRedC.ascx" TagPrefix="uc1" TagName="InterfacesRedC" %>
<%@ Register Src="~/Controles/SistemasOperativosC.ascx" TagPrefix="uc1" TagName="SistemasOperativosC" %>
<%@ Register Src="~/Controles/StorageC.ascx" TagPrefix="uc1" TagName="StorageC" %>
<%@ Register Src="~/Controles/AlmacenamientoC.ascx" TagPrefix="uc1" TagName="AlmacenamientoC" %>
<%@ Register Src="~/Controles/BitacoraC.ascx" TagPrefix="uc1" TagName="BitacoraC" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
<%--    <style>
        .marco {
            float: left;
            border: 1px solid gray;
            border-radius: 5px;
            margin: 2px;
            padding: 0;
            z-index: 5;
        }

        .headCaja {
            height: 20px;
            /*border: 1px solid gray;
            border-top-left-radius:5px;
            border-top-right-radius:5px;*/
            text-align: right;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="principal">
                <div id="numCols" class="hide">9</div>
                <div class="detallesGenerales">
                    <div class="tituloDetalles">
                        <h4>Detalles Generales</h4>
                    </div>
                    <label>Server name:</label>
                    <div>
                        <asp:Label ID="lblAliasServidor" runat="server" Text=""></asp:Label>
                    </div>
                    <label>Descripción:</label>
                    <div>
                        <asp:Label ID="lblDescripcionUso" runat="server" Text=""></asp:Label>
                    </div>
                    <label>Tipo de servidor:</label>
                    <div>
                        <asp:Label ID="lblTipoServidor" runat="server" Text=""></asp:Label>
                    </div>
                    <label>Modelo:</label>
                    <div>
                        <asp:HiddenField ID="hdfIdModelo" runat="server" />
                        <asp:Label ID="lblModelo" runat="server" Text=""></asp:Label>
                    </div>
                    <label>Procesador:</label>
                    <div>
                        <asp:Label ID="lblProcesador" runat="server" Text=""></asp:Label>
                    </div>
                    <label>Número de procesadores:</label>
                    <div>
                        <asp:Label ID="lblNumProcesadores" runat="server" Text=""></asp:Label>
                    </div>
                    <label>Capacidad de RAM:</label>
                    <div>
                        <asp:Label ID="lblCapacidadRam" runat="server" Text=""></asp:Label>
                    </div>
                    <label>Arreglo de discos:</label>
                    <div>
                        <asp:Label ID="lblArregloDiscos" runat="server" Text=""></asp:Label>
                    </div>
                    <label>Soporte:</label>
                    <div>
                        <asp:Label ID="lblSoporte" runat="server" Text="Sin Soporte"></asp:Label>
                    </div>
                </div><%--Fin detalles General--%>
                    <asp:Panel ID="pnlVms" Visible="false" CssClass="hostVirtual" runat="server">
                        <div class="tituloDetalles">
                            <h4>VMs que aloja</h4>
                        </div>
                        <asp:GridView ID="gdvVMs" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="AliasServidor" HeaderText="VM" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>

                <div class="almacenammiento">
                    <div class="tituloDetalles">
                        <h4>Almacenamiento</h4>
                    </div>
                    <uc1:AlmacenamientoC runat="server" id="AlmacenamientoC" />
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
                    <uc1:SistemasOperativosC runat="server" id="SistemasOperativosC" />
                </div>
                <div class="storage">
                    <div class="tituloDetalles">
                        <h4>Storage</h4>
                    </div>
                    <uc1:StorageC runat="server" id="StorageC" />
                </div>
                <div class="bitacora">
                    <div class="tituloDetalles">
                        <h4>Bitacora</h4>
                    </div>
                    <uc1:BitacoraC runat="server" id="BitacoraC" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
