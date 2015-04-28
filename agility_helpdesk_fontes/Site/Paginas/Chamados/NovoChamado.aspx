<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NovoChamado.aspx.cs" Inherits="Site.Paginas.Chamados.NovoChamado" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div id="right_side1">
        <table width="710">
            <tr>
                <td colspan="3" class="default2">Preencha os campos abaixo com os dados do seu chamado</td>
            </tr>
            <tr>
                <td width="210">&nbsp;</td>
                <td width="210">&nbsp;</td>
                <td width="274">&nbsp;</td>
            </tr>
            <tr>
                <td class="default2">Categoria</td>
                <td class="default2">Classificação</td>
                <td class="default2">Prioridade</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="DrpCategoria" CssClass="com_class_pri" DataTextField="Nome" DataValueField="IdCategoria" runat="server" />
                    <br />
                    <asp:RequiredFieldValidator ID="ValidadorCategoria" InitialValue="" ValidationGroup="ValidacaoChamado" runat="server"
                        ControlToValidate="DrpCategoria" CssClass="field-validation-error" ErrorMessage=" *Selecione uma categoria" />
                </td>
                <td>
                    <asp:DropDownList ID="DrpClassificacao" CssClass="com_class_pri" DataTextField="Nome" DataValueField="IdClassificacao" runat="server" />
                    <br />
                    <asp:RequiredFieldValidator ID="ValidadorClassificacao" InitialValue="" ValidationGroup="ValidacaoChamado" runat="server"
                        ControlToValidate="DrpClassificacao" CssClass="field-validation-error" ErrorMessage=" *Selecione uma classificação" />
                </td>
                <td>
                    <asp:DropDownList ID="DrpPrioridade" CssClass="com_class_pri" runat="server">
                        <asp:ListItem Text="Selecione" Value="" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Baixa" Value="B"></asp:ListItem>
                        <asp:ListItem Text="Média" Value="M"></asp:ListItem>
                        <asp:ListItem Text="Alta" Value="A"></asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:RequiredFieldValidator ID="ValidadorPrioridade" InitialValue="" ValidationGroup="ValidacaoChamado" runat="server"
                        ControlToValidate="DrpPrioridade" CssClass="field-validation-error" ErrorMessage=" *Selecione a prioridade do chamado" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="default2">Assunto</td>
                <td class="default2">Anexo</td>
                <td class="default2">Atendente</td>
            </tr>
            <tr>
                <td>
                    <input name="TxtAssunto" type="text" class="assuntoNew" id="TxtAssunto" runat="server" />
                    <br />
                    <asp:RequiredFieldValidator ID="ValidadorAssunto" runat="server" ControlToValidate="TxtAssunto" CssClass="field-validation-error"
                        ValidationGroup="ValidacaoChamado" ErrorMessage="*Preenchimento do campo assunto é obrigatório." />
                </td>
                <td>
                    <asp:FileUpload ID="UploadImagem" runat="server" Style="border: 0; margin-bottom: 30px; width: 200px;" CssClass="uploadGeneric" />
                </td>
                <td>
                    <asp:DropDownList ID="DrpAtendente" CssClass="com_class_pri" DataTextField="Nome" DataValueField="IdUsuario" runat="server" />
                    <br />
                    <asp:RequiredFieldValidator ID="ValidadorAtendente" InitialValue="" ValidationGroup="ValidacaoChamado" runat="server"
                        ControlToValidate="DrpAtendente" CssClass="field-validation-error" ErrorMessage=" *Selecione um atendente" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" class="default2">Descrição</td>
            </tr>
            <tr>
                <td colspan="3">
                    <textarea name="TxtDescricao" cols="45" rows="5" class="comentarios" id="TxtDescricao" runat="server"></textarea>
                    <br />
                    <asp:RequiredFieldValidator ID="ValidadorDescricao" ValidationGroup="ValidacaoChamado" runat="server" ControlToValidate="TxtDescricao"
                        CssClass="field-validation-error" ErrorMessage="*Preenchimento do campo descrição é obrigatório." />
                </td>
            </tr>
        </table>
        <table width="710">
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td width="102">
                    <button runat="server" id="BtnCadastrar" class="btnGravar" onserverclick="BtnCadastrar_ServerClick" validationgroup="ValidacaoChamado" />
                </td>
                <td width="596">
                    <button runat="server" id="BtnLimpar" class="btnLimpar" onserverclick="BtnLimpar_ServerClick" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
