<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contato.aspx.cs" Inherits="Site.Paginas.Institucional.Contato" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div id="right_side2">
        <table width="710">
            <tr>
                <td colspan="3" class="default2">Preencha os campos abaixo para contato</td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" class="default2">Nome completo</td>
            </tr>
            <tr>
                <td colspan="3">
                    <input name="TxtNome" type="text" class="assunto" id="TxtNome" runat="server" />
                    <br />
                    <asp:RequiredFieldValidator ID="ValidadorNome" runat="server" ControlToValidate="TxtNome" CssClass="field-validation-error" ErrorMessage="*Preenchimento do nome é obrigatório." />
                </td>
            </tr>
            <tr>
                <td colspan="3" class="default2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3"><span class="default2">E-mail</span></td>
            </tr>
            <tr>
                <td colspan="3" class="default2">
                    <input name="TxtEmail" title="E-mail" type="text" class="assunto" id="TxtEmail" runat="server" required="required" pattern="[^@]+@[^@]+\.[a-zA-Z]{2,6}" />
                    <br />
                    <asp:RequiredFieldValidator ID="ValidadorEmail" runat="server" ControlToValidate="TxtEmail" CssClass="field-validation-error" ErrorMessage="*Preenchimento do e-mail é obrigatório." />
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td width="210" class="default2">Assunto</td>
                <td width="210">&nbsp;</td>
                <td width="274">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <input name="TxtAssunto" type="text" class="assunto" id="TxtAssunto" runat="server" />
                    <br />
                    <asp:RequiredFieldValidator ID="ValidadorAssunto" runat="server" ControlToValidate="TxtAssunto" CssClass="field-validation-error" ErrorMessage="*Preenchimento do assunto é obrigatório." />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" class="default2">Comentário</td>
            </tr>
            <tr>
                <td colspan="3">
                    <label for="textarea"></label>
                    <textarea name="TxtMensagem" cols="45" rows="5" class="comentarios" id="TxtMensagem" runat="server"></textarea>
                    <br />
                    <asp:RequiredFieldValidator ID="ValidadorMensagem" runat="server" ControlToValidate="TxtMensagem" CssClass="field-validation-error" ErrorMessage="*Preenchimento da mensagem é obrigatório." />
                </td>
            </tr>
        </table>
        <table width="710">
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td width="102">
                    <button runat="server" id="BtnCadastrar" class="btnGravar" onserverclick="BtnCadastrar_ServerClick" />
                </td>
                <td width="596">
                    <button runat="server" id="BtnLimpar" class="btnLimpar" onserverclick="BtnLimpar_ServerClick" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
