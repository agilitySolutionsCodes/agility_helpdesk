<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recuperar.aspx.cs" Inherits="Site.Paginas.Conta.Recuperar" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <div id="middle_content">
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
                <table width="436" border="0" cellpadding="4" cellspacing="4">
                    <tr>
                        <td width="52" class="txt_form">
                            <img src="Style/Images/baloon.png" alt="" width="31" height="31" border="0" /></td>
                        <td width="384" class="problems">Informe o endereço de e-mail que foi cadastrado e reenviaremos uma nova senha.</td>
                    </tr>
                </table>
                <table width="436" border="0" cellpadding="4" cellspacing="4">
                    <tr>
                        <td width="62" class="txt_form">E-MAIL</td>
                        <td colspan="2">
                            <input title="E-mail" runat="server" id="TxtUsuario" type="email" required="required" pattern="[^@]+@[^@]+\.[a-zA-Z]{2,6}" />
                            <br />
                            <asp:RequiredFieldValidator ID="ValidadorEmail" ValidationGroup="ValidadorRecuperar" runat="server" ControlToValidate="TxtUsuario" CssClass="field-validation-error" ErrorMessage="*Preenchimento do campo E-mail é obrigatório." />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td width="92">
                            <button runat="server" id="BtnRecuperar" class="btnRecuperar" ValidationGroup="ValidadorRecuperar" onserverclick="BtnRecuperar_ServerClick" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
