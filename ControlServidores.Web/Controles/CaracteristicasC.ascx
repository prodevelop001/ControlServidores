<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaracteristicasC.ascx.cs" Inherits="ControlServidores.Web.Controles.CaracteristicasC" %>
<div>
    <div>
        <asp:HiddenField ID="hdfIdServidor" runat="server" />
        <asp:HiddenField ID="hdfIdModelo" runat="server" />
        <asp:HiddenField ID="hdfIdEspecificacion" runat="server" />
        <asp:HiddenField ID="hdfIdTipoServidor" runat="server" />
        <asp:HiddenField ID="hdfEstatus" runat="server" />
        <div class="agregarNuevo">
            <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
        </div>
    </div>
    <asp:Panel ID="pnlForm" Visible="false" runat="server">
        <%--<div style="width: 40%; margin: 0; float: left;">--%>
            <div class="formCampos">
                <label>Alias Servidor :</label>
                <asp:TextBox ID="txtAliasServidor" runat="server" placeholder="Ej: server-web"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAliasServidor" runat="server" ErrorMessage="*Campo requerido." ControlToValidate="txtAliasServidor" ForeColor="Red" ValidationGroup="Caracteristicas"></asp:RequiredFieldValidator>
            </div>
            <div class="formCampos">
                <label>Descripción :</label>
                <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Ej: Pagina Web principal"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ErrorMessage="*Campo requerido." ControlToValidate="txtDescripcion" ForeColor="Red" ValidationGroup="Caracteristicas"></asp:RequiredFieldValidator>
            </div>
            <div class="formCampos">
                <label>Marca :</label>
                <asp:DropDownList ID="ddlMarca" runat="server" OnSelectedIndexChanged="ddlMarca_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </div>
            <div class="formCampos">
                <label>Modelo :</label>
                <asp:DropDownList ID="ddlModelo" runat="server"></asp:DropDownList>
            </div>
            <div class="formCampos">
                <label>Tipo de servidor :</label>
                <asp:DropDownList ID="ddlTipoServidor" runat="server" OnSelectedIndexChanged="ddlTipoServidor_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </div>
            <div class="formCampos">
                <label>VM alojada en :</label>
                <asp:DropDownList ID="ddlVirtualizador" runat="server" Enabled="False"></asp:DropDownList>
            </div>
            <div class="formCampos">
                <label>Estatus :</label>
                <asp:DropDownList ID="ddlEstatus" runat="server"></asp:DropDownList>
            </div>
        <%--</div>--%>
        <%--<div style="width: 60%; margin: 0; float: left;">--%>
            <div class="formCampos">
                <label>Procesador :</label>
                <asp:DropDownList ID="ddlProcesador" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProcesador_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="formCampos">
                <label>Caracteristicas : </label>
                <asp:Label ID="lblCaracteristicasProc" runat="server" Text=""></asp:Label>
            </div>
            <div class="formCampos">
                <label>Número de procesadores :</label>
                <asp:TextBox ID="txtNumProcesadores" TextMode="Number" runat="server" placeholder="Ej: 2"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNumProcesadores" runat="server" ErrorMessage="*Campo requerido" ControlToValidate="txtNumProcesadores" ForeColor="Red" ValidationGroup="Caracteristicas"></asp:RequiredFieldValidator>
            </div>
            <div class="formCamposDdl">
                <label>Capacidad de RAM :</label>
                <asp:TextBox ID="txtCapacidadRam" runat="server" TextMode="Number" placeholder="Ej: 128"></asp:TextBox>
                <asp:DropDownList ID="ddlCapacidadRam" runat="server">
                    <asp:ListItem Value="0" Text="-- Selccionar --" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="MB" Text="MB"></asp:ListItem>
                    <asp:ListItem Value="GB" Text="GB"></asp:ListItem>
                    <asp:ListItem Value="TB" Text="TB"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCapacidadRam" runat="server" ErrorMessage="*Capacidad de RAM requerida" ControlToValidate="txtCapacidadRam" ForeColor="Red" ValidationGroup="Caracteristicas"></asp:RequiredFieldValidator>
            </div>
            <div class="formCampos">
                <label>Arreglo de discos :</label>
            <asp:DropDownList ID="ddlArregloDiscos" runat="server"></asp:DropDownList>
            </div>
            <div class="formCampos">
                <label>Númer de serie :</label>
                <asp:TextBox ID="txtNumSerie" runat="server" placeholder="Ej: 423950000006436"></asp:TextBox>
            </div>
            <div class="formCamposDdl">
                <label>Persona a cargo :</label>
                <asp:DropDownList ID="ddlPersona" runat="server" ></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvPersonaCargo" runat="server" InitialValue="0" ErrorMessage="*Persona requerida" ControlToValidate="ddlPersona" ForeColor="Red" ValidationGroup="Caracteristicas" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
        <%--</div>--%>
        <div class="formBotones">
            <asp:Button ID="btnActualizar" CssClass="btnGuardar" runat="server" Text="Actualizar" ValidationGroup="Caracteristicas" OnClick="btnActualizar_Click" />
            <asp:Button ID="Cancelar" CssClass="btnCancelar" runat="server" Text="Cancelar" OnClick="Cancelar_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlCaracteristicas" class="detallesSrvs" runat="server">        
        <%--<div class="elementoDetalle">
            <label>Alias Servidor:</label>
            <asp:Label ID="lblAliasServidor" runat="server" Text=""></asp:Label>
        </div>--%>
        <div class="elementoDetalle">
            <label>Descripción:</label>
            <asp:Label ID="lblDescripcionUso" runat="server" Text=""></asp:Label>
        </div>
         <div class="elementoDetalle">
            <label>Estatus:</label>
            <asp:Label ID="lblEstatusServidor" runat="server" Text=""></asp:Label>
        </div>
        <div class="elementoDetalle">
            <label>Tipo de servidor:</label>
            <asp:Label ID="lblTipoServidor" runat="server" Text=""></asp:Label>
        </div>
        <div class="elementoDetalle">
            <label>Modelo:</label>
            <asp:Label ID="lblModelo" runat="server" Text=""></asp:Label>
        </div>
        <div class="elementoDetalle">
            <label>Procesador:</label>
            <asp:Label ID="lblProcesador" runat="server" Text=""></asp:Label>
        </div>
        <div class="elementoDetalle">
            <label>Núm. de Procesadores:</label>
            <asp:Label ID="lblNumProcesadores" runat="server" Text=""></asp:Label>
        </div>
        <div class="elementoDetalle">
            <label>Capacidad de RAM:</label>
            <asp:Label ID="lblCapacidadRam" runat="server" Text=""></asp:Label>
        </div>
        <div class="elementoDetalle">
            <label>Arreglo de discos:</label>
            <asp:Label ID="lblArregloDiscos" runat="server" Text=""></asp:Label>
        </div>
        <div class="elementoDetalle">
            <label>Soporte:</label>
            <asp:Label ID="lblSoporte" runat="server" Text="Sin Soporte"></asp:Label>
        </div>
        <div class="elementoDetalle">
            <label>Persona encargada:</label>
            <asp:Label ID="lblPersonaEncargada" runat="server" Text=""></asp:Label>
        </div>
        <div class="elementoDetalle">
            <!--<label>Virtualizador:</label>-->
            <asp:Label ID="lblVirtualizador" runat="server" Text="Virtualizador: "></asp:Label>
            <asp:HyperLink ID="hlkVirtualizador" runat="server"></asp:HyperLink>
        </div>
    </asp:Panel>
    <div>
        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
    </div>
</div>
