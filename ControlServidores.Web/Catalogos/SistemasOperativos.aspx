<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="SistemasOperativos.aspx.cs" Inherits="ControlServidores.Web.Catalogos.SistemasOperativos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cuerpoPpal" runat="server">
<div  class="principal">
    <div id="numCols" class="hide">5</div>
    <div class="ttlPrincipal">
        <h1>Sistemas Operativos</h1>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlResultado" CssClass="barraEstatus" runat="server">
                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
            </asp:Panel>
            <div class="addNuevo">
                    <asp:HiddenField ID="hdfEstado" runat="server"></asp:HiddenField>
                    <asp:Button ID="btnNuevo" CssClass="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>
            </div>
            <asp:Panel ID="pnlFormulario" CssClass="miFormulario" runat="server">
                <div class="formCampos">
                    <asp:HiddenField ID="lblIdSistemaOperativo" runat="server" />
                    <div class="grpInput">
                        <label>Nombre de S.O. :</label>
                        <asp:TextBox ID="txtSO" runat="server" placeholder="Ej: Windows Server 2008 R2 x86_64"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSO" runat="server" ErrorMessage="*Concepto requerido." ControlToValidate="txtSO" ForeColor="Red" ValidationGroup="SistemasOperativos"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="formBotones">
                    <asp:Button ID="btnGuardar" CssClass="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="SistemasOperativos"></asp:Button>
                    <asp:Button ID="btnCancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlSO" runat="server">
                <asp:GridView ID="gdvSOs" runat="server" CssClass="miTabla" AutoGenerateColumns="False" OnRowDataBound="gdvSOs_RowDataBound" OnRowDeleting="gdvSOs_RowDeleting" OnSelectedIndexChanged="gdvSOs_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <%# Container.DisplayIndex + 1%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="IdSO" HeaderText="IdSO">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NombreSO" HeaderText="Nombre de S.O." />
                        <asp:CommandField ControlStyle-CssClass="icon-pencil" SelectText=" Seleccionar" ShowSelectButton="True" />
                        <asp:CommandField ControlStyle-CssClass="icon-cross" DeleteText=" Eliminar" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div> <%--Fin de Div Principal--%>
</asp:Content>
