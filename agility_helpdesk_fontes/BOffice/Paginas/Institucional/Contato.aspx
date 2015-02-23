<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="BOffice.Contato.Enviar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bodyPageContato">
        <div class="dv-inputLeft">
            <label id="LblNome" class="lblGeneric">Nome:</label>
            <input runat="server" id="TxtNome" class="txtGeneric2" type="text" />
            <asp:RequiredFieldValidator ID="ValidadorNome" runat="server" ControlToValidate="TxtNome" CssClass="field-validation-error" ErrorMessage="*Informe o nome." />
        </div>
        <div class="dv-inputRight">
            <label id="LblEmail" class="lblGeneric">E-mail:</label>
            <input runat="server" title="E-mail" id="TxtEmail" class="txtGeneric2" type="text" required="required" pattern="[^@]+@[^@]+\.[a-zA-Z]{2,6}" />
            <asp:RequiredFieldValidator ID="ValidadorEmail" runat="server" ControlToValidate="TxtEmail" CssClass="field-validation-error" ErrorMessage="*Informe o e-mail." />
        </div>
        <div class="dv-inputLeft">
            <label id="LblAssunto" class="lblGeneric">Assunto:</label>
            <input runat="server" id="TxtAssunto" class="txtGeneric2" type="text" />
            <asp:RequiredFieldValidator ID="ValidadorAssunto" runat="server" ControlToValidate="TxtAssunto" CssClass="field-validation-error" ErrorMessage="*Informe o assunto." />
        </div>
        <div class="dv-inputTextArea">
            <label id="LblMensagem" class="lblGeneric">Mensagem:</label>
            <textarea runat="server" id="TxtMensagem" class="txtArea"></textarea>
            <asp:RequiredFieldValidator ID="ValidadorMensagem" runat="server" ControlToValidate="TxtNome" CssClass="field-validation-error" ErrorMessage="*Informe a mensagem." />
        </div>
        <div class="dv-inputLeft">
        </div>
        <div class="dv-inputRight">
            <button runat="server" id="BtnCadastrar" class="btn" onserverclick="BtnCadastrar_ServerClick">Cadastrar</button>
            <button runat="server" id="BtnLimpar" class="btn" onserverclick="BtnLimpar_ServerClick">Limpar</button>
        </div>
    </div>
</asp:Content>
