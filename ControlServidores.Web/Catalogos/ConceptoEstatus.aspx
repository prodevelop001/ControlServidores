<%@ Page Title="" Language="C#" MasterPageFile="~/Sitio.Master" AutoEventWireup="true" CodeBehind="ConceptoEstatus.aspx.cs" Inherits="ControlServidores.Web.Catalogos.ConceptoEstatus" %>
<%--<%@ Page Title="" Language="C#" MasterPageFile="~/prueba.Master" AutoEventWireup="true" CodeBehind="ConceptoEstatus.aspx.cs" Inherits="ControlServidores.Web.Catalogos.ConceptoEstatus" %>--%>

<%--<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">--%>
<asp:Content ID="Content1" ContentPlaceHolderID="cabecera" runat="server">
        <script src="../Scripts/Scripts.js"></script>
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">--%>
<asp:Content ID="Content3" ContentPlaceHolderID="cuerpoPpal" runat="server">
    <div  class="principal">
    <div id="numCols" class="hide">5</div>
    <div class="ttlPrincipal">
        <h1>Concepto Estatus</h1>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div >
                <asp:Panel ID="pnlResultado" CssClass="barraEstatus" runat="server">
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                </asp:Panel>
                <div class="addNuevo">
                    <asp:HiddenField ID="hdfEstado" runat="server"></asp:HiddenField>
                    <asp:Button ID="btnNuevo" CssClass="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click"/>
                </div>
                
                <asp:Panel ID="pnlFormulario" CssClass="miFormulario" runat="server" Visible="False">
                    <div class="formCampos">
                        <asp:Label ID="lblIdConceptoEstatus" runat="server" CssClass="hide"></asp:Label>
                        <label>Concepto :</label>
                        <asp:TextBox ID="txtConcepto" runat="server" placeholder="Ej: Marca"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvConcepto" runat="server" ErrorMessage="*Concepto requerido." ControlToValidate="txtConcepto" ForeColor="Red" ValidationGroup="Conceptos"></asp:RequiredFieldValidator>
                    </div>
                    <div class="formBotones">
                        <asp:Button ID="btnGuardar" CssClass="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="Conceptos"></asp:Button>
                        <asp:Button ID="btnCancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlCatalogo" runat="server" Visible="False">
                    <asp:GridView ID="gdvConceptos" runat="server" CssClass="miTabla" AutoGenerateColumns="False" Style="margin-right: 0px" OnSelectedIndexChanged="gdvConceptos_SelectedIndexChanged" OnRowDataBound="gdvConceptos_RowDataBound" OnRowDeleting="gdvConceptos_RowDeleting">
                        <Columns>
                            <asp:TemplateField HeaderText="#">
                                <ItemTemplate>
                                    <%# Container.DisplayIndex + 1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdConceptoEstatus" HeaderText="IdConceptoEstatus">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Concepto" HeaderText="Concepto" />
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