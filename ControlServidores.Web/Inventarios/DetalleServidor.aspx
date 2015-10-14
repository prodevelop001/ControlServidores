<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleServidor.aspx.cs" Inherits="ControlServidores.Web.Inventarios.DetalleServidor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%;">
                <div style="width: 30%; float: left; margin: 0; padding: 0">
                    <div class="marco" style="width: 100%;">
                        <div class="headCaja">
                            Detalles Generales
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
                    </div>
                    <asp:Panel ID="pnlVms" Visible="false" CssClass="marco" runat="server">
                        <div class="headCaja">
                            VMs que aloja.
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
                </div>
                <div class="marco" style="width: 350px; margin: 6px;">
                    <div class="headCaja">
                        Almacenamiento
                    </div>
                    <asp:GridView ID="gdvAlmacenamiento" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin Medios Registrados.">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Unidad" HeaderText="Unidad" />
                            <asp:BoundField DataField="TipoMemoria.Tipo" HeaderText="Tipo" />
                            <asp:BoundField DataField="Capacidad" HeaderText="Capacidad" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="marco" style="width: 350px; margin: 6px;">
                    <div class="headCaja">
                        Interfaces de Red
                    </div>
                    <asp:GridView ID="gdvInterfacesRed" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin Interfaces registradas.">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdConfRed" HeaderText="IdConfRed">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="InterfazRed" HeaderText="Interfaz" />
                            <asp:BoundField DataField="DirIp" HeaderText="Dirección IP" />
                            <asp:BoundField DataField="MascaraSubRed" HeaderText="SubNet" />
                            <asp:BoundField DataField="Estatus._Estatus" HeaderText="Estado" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="marco" style="width: 350px; margin: 6px;">
                    <div class="headCaja">
                        Sistema(s)
                    </div>
                    <asp:GridView ID="gdvSos" runat="server" AutoGenerateColumns="False" EmptyDataText="Sin SOs registrados.">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdSOxServidor" HeaderText="IdSOxServidor">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SO.NombreSO" HeaderText="Sistema" />
                            <asp:BoundField DataField="Estatus._Estatus" HeaderText="Estado" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="marco" style="width: 350px; margin: 6px;">
                    <div class="headCaja">
                        Storage
                    </div>
                    <asp:GridView ID="gdvStorage" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdStorage" HeaderText="IdStorage">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TipoStorage.Tipo" HeaderText="Storage" />
                            <asp:BoundField DataField="Estatus._Estatus" HeaderText="Estado" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="marco">
                    <div>
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" />
                    </div>
                    <asp:GridView ID="gdvBitacora" runat="server" AutoGenerateColumns="false">
                         <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Bitacora.IdBitacora" HeaderText="IdBitacora">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Personas.Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Bitacora.FechaCaptura" HeaderText="Fecha de Captura"/>
                             <asp:BoundField DataField="Bitacora.FechaMantenimiento" HeaderText="Fecha de procedimiento"/>
                             <asp:BoundField DataField="Bitacora.DescripcionMantenimiento" HeaderText="Descripcion"/>
                             <asp:BoundField DataField="Bitacora.Observaciones" HeaderText="Fecha de Captura"/>
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
