<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Servidores.aspx.cs" Inherits="ControlServidores.Web.Inventarios.Servidores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <div>
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" />
                </div>
                <asp:Panel ID="pnlNuevoServidor" runat="server">
                    <label>Alias de servidor</label>
                    <div>
                        <asp:TextBox ID="txtAliasServidor" runat="server"></asp:TextBox>
                    </div>
                    <label>Marca</label>
                    <div>
                        <asp:DropDownList ID="ddlMarca" runat="server"></asp:DropDownList>
                    </div>
                    <label>Modelo</label>
                    <div>
                        <asp:DropDownList ID="ddlModelo" runat="server"></asp:DropDownList>
                    </div>
                    <label>Tipo de servidor</label>
                    <div>
                        <asp:DropDownList ID="ddlTipoServidor" runat="server"></asp:DropDownList>
                    </div>
                    <label>VM alojada en </label>
                    <div>
                        <asp:DropDownList ID="ddlVirtualizador" runat="server"></asp:DropDownList>
                    </div>
                    <label>Servidor para uso de</label>
                    <div>
                        <asp:TextBox ID="txtDescripcionUso" runat="server"></asp:TextBox>
                    </div>
                    <label>Estatus</label>
                    <div>
                        <asp:DropDownList ID="ddlEstatus" runat="server"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:Button ID="btnGuardar" runat="server" Text="Button" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Button" />
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
