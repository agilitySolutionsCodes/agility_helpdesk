<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalhe.aspx.cs" Inherits="Site.Paginas.Chamados.Detalhe" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div id="right_side2">
        <table width="710">
            <tr>
                <td width="694" class="default2"><strong>Detalhe do chamado</strong></td>
            </tr>
        </table>
        <table width="707">
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td width="215" class="default2"><strong>Número do chamado:</strong>
                    <asp:Label ID="LblNumeroChamado" runat="server" />
                </td>
                <td width="28">&nbsp;</td>
                <td width="448" class="default2"><strong>Data da abertura:</strong>
                    <asp:Label ID="LblDataAbertura" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="default2"><strong>Prioridade:</strong>
                    <asp:Label ID="LblPrioridade" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td class="default2"><strong>Aberto por:</strong>
                    <asp:Label ID="LblSolicitante" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="default2"><strong>Categoria:</strong>
                    <asp:Label ID="LblCategoria" runat="server" />
                </td>
                <td>&nbsp;</td>
                <td class="default2"><strong>Status:</strong>
                    <asp:Label ID="LblStatus" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2" class="default2"><strong>Assunto:</strong>
                    <asp:Label ID="LblAssunto" runat="server" />
                </td>
                <td class="default2"><strong>Anexo:</strong>
                    <a href="" id="LinkAnexo" target="_blank" runat="server" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" class="default2"><strong>Descrição:</strong>
                    <asp:Literal ID="LtlDescricao" runat="server" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" class="default2">
                    <strong>
                        <asp:Label ID="LblComentario" Visible="false" Text="Comentário:" runat="server" />
                    </strong>
                    <textarea name="TxtComentario" visible="false" maxlength="255" cols="45" rows="5" class="comentarios" id="TxtComentario" runat="server"></textarea>
                    <asp:Label ID="LblComentarioII" Visible="false" Text="" runat="server" />
                </td>
            </tr>
        </table>
        <table width="504">
            <tr>
                <td width="153">&nbsp;</td>
                <td width="339">&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <button runat="server" id="BtnEncerrar" class="btnEncerrarr" onserverclick="BtnEncerrar_ServerClick" />
                </td>
                <td>
                    <button runat="server" id="BtnFinalizar" class="btnFinalizar" onserverclick="BtnFinalizar_ServerClick" />
                </td>
                <td>
                    <button runat="server" id="BtnCancelar" class="btnLimpar" onserverclick="BtnCancelar_ServerClick" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
