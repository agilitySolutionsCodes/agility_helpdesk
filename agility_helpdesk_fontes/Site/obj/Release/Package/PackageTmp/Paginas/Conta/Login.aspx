<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Site.Paginas.Conta.Login" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div id="middle_contnt">
            <div id="login_left">
                <div id="title_login">
                    <img src="Style/Images/tit-login-left.png" width="448" height="71" />
                </div>
                <div id="txt_login">
                    Lorem ipsum dolor sit amet, consectetur adipisicing elit, nostrud quis
                    <br />
                    quis nostrud exercitation laboris nisi ut aliquip ex ea commodo consequat ipsum . 
                </div>
            </div>
            <div id="login_divisoria"></div>
            <div id="login_right">

                <table width="400" border="0" cellpadding="4" cellspacing="4">
                    <tr>
                        <td class="txt_form">LOGIN</td>
                        <td>
                            <input title="E-mail" runat="server" id="TxtUsuario" type="email" required="required" pattern="[^@]+@[^@]+\.[a-zA-Z]{2,6}" /></td>
                        <asp:RequiredFieldValidator ID="ValidadorEmail" ValidationGroup="ValidacaoCadastro" runat="server" ControlToValidate="TxtUsuario" CssClass="field-validation-error" ErrorMessage="*Preenchimento do campo E-mail é obrigatório." />
                    </tr>
                    <tr>
                        <td class="txt_form">SENHA</td>
                        <td>
                            <input name="TxtSenha" runat="server" id="TxtSenha" type="password" /></td>
                        <asp:RequiredFieldValidator ID="ValidadorSenha" ValidationGroup="ValidacaoCadastro" runat="server" ControlToValidate="TxtSenha" CssClass="field-validation-error" ErrorMessage="*Preenchimento do campo senha   é obrigatório." />
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="problems">
                            <a href="Conta-Recuperar-Senha">Problemas para acessar sua conta?</a>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <button runat="server" id="BtnLogar" class="btnLogar" onserverclick="BtnLogar_ServerClick" validationgroup="ValidacaoCadastro" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
