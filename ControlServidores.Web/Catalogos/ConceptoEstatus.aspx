<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConceptoEstatus.aspx.cs" Inherits="ControlServidores.Web.Catalogos.ConceptoEstatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <script src="../Scripts/Scripts.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:HiddenField ID="hdfEstado" runat="server"></asp:HiddenField>
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                <asp:Panel ID="pnlFormulario" runat="server">
                    <asp:Label ID="lblIdConceptoEstatus" runat="server" CssClass="hide"></asp:Label>
                    <label>Concepto </label>
                    <div>
                        <asp:TextBox ID="txtConcepto" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"></asp:Button>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"></asp:Button>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlCatalogo" runat="server">
                    <asp:GridView ID="gdvConceptos" runat="server" AutoGenerateColumns="False" Style="margin-right: 0px" OnSelectedIndexChanged="gdvConceptos_SelectedIndexChanged" OnRowDataBound="gdvConceptos_RowDataBound" OnRowDeleting="gdvConceptos_RowDeleting">
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
    </asp:UpdatePanel>
</asp:Content>
