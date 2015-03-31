<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BOffice.Conta.Login" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title><%: Page.Title %>- Login Gerenciador de Conteúdo </title>
    <meta name="description" content="Gerenciador de conteúdo sistema Web Help-Desk Agility Solutions" />
</asp:Content>

<asp:Content ID="MainContentLogin" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div id="content_area_login">
            <div id="title_login">
                <img src="Style/Images/acesso.png" width="399" height="70" />
            </div>
            <div id="form_login">
                <table width="408" border="0" cellpadding="4" cellspacing="4">
                    <tr>
                        <td width="110" class="txt_form">LOGIN</td>
                        <td colspan="2">
                            <label for="textfield"></label>
                            <input title="E-mail" runat="server" id="TxtUsuario" maxlength="100" type="email" required="" pattern="[^@]+@[^@]+\.[a-zA-Z]{2,6}" />
                            <br />
                            <asp:RequiredFieldValidator ID="ValidadorEmail" runat="server" ControlToValidate="TxtUsuario"
                                CssClass="field-validation-error" ErrorMessage="*Preenchimento do campo E-mail é obrigatório." ValidationGroup="ValidacaoCadastro" />
                        </td>
                    </tr>
                    <tr>
                        <td class="txt_form">SENHA</td>
                        <td colspan="2">
                            <input title="Senha" name="TxtSenha" runat="server" required="" id="TxtSenha" maxlength="20" type="password" />
                            <br />
                            <asp:RequiredFieldValidator ID="ValidadorSenha" runat="server" ControlToValidate="TxtSenha" CssClass="field-validation-error"
                                ErrorMessage="*Preenchimento do campo senha é obrigatório." ValidationGroup="ValidacaoCadastro" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td width="99"></td>
                        <td width="291">
                            <button title="Entrar" runat="server" id="BtnLogar" class="btnLogar" onserverclick="BtnLogar_ServerClick" validationgroup="ValidacaoCadastro" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

