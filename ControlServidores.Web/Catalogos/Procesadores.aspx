<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="Procesadores.aspx.cs" Inherits="ControlServidores.Web.Catalogos.Procesadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
    <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
    <asp:updatepanel id="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="principal">
                <div id="numCols" class="hide">9</div>
                <div class="ttlPrincipal">
                    <h1>Procesadores</h1>
                </div>
                <div class="addNuevo">
                    <asp:HiddenField ID="hdfEstado" runat="server"></asp:HiddenField>
                    <asp:Button ID="btnNuevo" runat="server" CssClass="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click"></asp:Button>
                </div>
                <asp:Panel ID="pnlFormulario" runat="server">
                    <div class="formCampos">
                        <asp:HiddenField ID="lblIdProcesador" runat="server"></asp:HiddenField>
                        <div class="grpInput">
                            <label>Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="*Nombre requerido." ControlToValidate="txtNombre" ForeColor="Red" ValidationGroup="Procesadores"></asp:RequiredFieldValidator>
                        </div>
                        <div class="grpInput">
                            <label>Número de Cores</label>
                            <asp:TextBox ID="txtNumCores" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNumCores" runat="server" ErrorMessage="*Nombre requerido." ControlToValidate="txtNumCores" ForeColor="Red" ValidationGroup="Procesadores"></asp:RequiredFieldValidator>
                        </div>
                        <div class="grpInput">
                            <label>Velocidad</label>
                            <asp:TextBox ID="txtVelocidad" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvVelocidad" runat="server" ErrorMessage="*Nombre requerido." ControlToValidate="txtVelocidad" ForeColor="Red" ValidationGroup="Procesadores"></asp:RequiredFieldValidator>
                        </div>
                        <div class="grpInput">
                            <label>Caché</label>
                            <asp:TextBox ID="txtCache" runat="server"></asp:TextBox>
                        </div>
                        <div class="grpInput">
                            <label>Tamaño de Palaba</label>
                            <asp:DropDownList ID="ddlTamanoPalabra" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                        <div class="formBotones">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="Roles"></asp:Button>
                            <asp:Button ID ="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                        </div>
                </asp:Panel>
                <asp:Panel ID="pnlProcesadores" runat="server">
                    <asp:GridView ID="gdvProcesadores" runat="server" CssClass="miTabla9" AutoGenerateColumns="False" style="text-align: center" OnSelectedIndexChanged="gdvProcesadores_SelectedIndexChanged" OnRowDataBound="gdvProcesadores_RowDataBound" OnRowDeleting="gdvProcesadores_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DisplayIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdProcesador" HeaderText="IdProcesador">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="NumCores" HeaderText="Núm. Cores" />
                            <asp:BoundField DataField="Velocidad" HeaderText="Velocidad" />
                            <asp:BoundField DataField="Cache" HeaderText="Caché" />
                            <asp:BoundField DataField="TamanoPalabra" HeaderText="Tamaño de Palabra" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
                            <asp:CommandField DeleteText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                <br />
                <div>
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </ContentTemplate>
    </asp:updatepanel>
</asp:Content>
