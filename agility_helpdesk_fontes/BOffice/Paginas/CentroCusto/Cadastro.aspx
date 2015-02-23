<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="BOffice.CentroCustos.Cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content_acesso">
        <div id="inner_content_">
            <div id="nav_status">
                <table width="970" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20">
                            <img src="Style/Images/home_icon.png" width="16" height="16" />
                        </td>
                        <td width="950"><a href="Home">Home</a>&nbsp;>>&nbsp;
                                        <a href="Selecionar-Centro-Custo-Cadastro">Selecionar tipo de cadastro de centro de custo
                                        </a>&nbsp;>>&nbsp;Cadastro de centro de custo
                        </td>
                    </tr>
                </table>
            </div>
            <div id="title_acesso_">
                <img src="Style/Images/tit-cad-novo-centro-de-custo.png" width="395" height="70" />
            </div>
            <div id="form_box2">
                <table width="800" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="4" class="preencher">Preencha os campos abaixo</td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="input_titulos">Descrição do Centro de Custo</td>
                        <td colspan="3" class="input_titulos">&nbsp;</td>
                        <td class="input_titulos">Classe</td>
                        <td colspan="3" class="input_titulos">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <input name="TxtDescricao" type="text" class="nome" id="TxtDescricao" maxlength="80" runat="server" />
                            <asp:RequiredFieldValidator ID="ValidatorDescricao" ControlToValidate="TxtDescricao" runat="server"
                                CssClass="field-validation-error" ErrorMessage="*Informe a descricão." ValidationGroup="ValidacaoCadastro" />
                        </td>
                        <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:DropDownList ID="drpCentroCusto" CssClass="empresa_" runat="server">
                                <asp:ListItem Text="Selecione" Value=""></asp:ListItem>
                                <asp:ListItem Text="Sintética" Value="S"></asp:ListItem>
                                <asp:ListItem Text="Analítica" Value="A"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ValidadorCentroCusto" InitialValue="" ValidationGroup="ValidacaoCadastro" runat="server"
                                ControlToValidate="DrpAtivo" CssClass="field-validation-error" ErrorMessage=" *Informe a classe do centro de custo" />
                        <td colspan="3">&nbsp;</td>
                    </tr>
                </table>
                <table width="600" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="24">&nbsp;</td>
                        <td width="62">&nbsp;</td>
                        <td width="24">&nbsp;</td>
                        <td width="490">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4" class="input_titulos">Ativo</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DrpAtivo" runat="server" CssClass="com_class_pri">
                                <asp:ListItem Text="Selecione" Value="" />
                                <asp:ListItem Text="Sim" Value="Sim" />
                                <asp:ListItem Text="Não" Value="Nao" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="ValidadorAtivo" InitialValue="" ValidationGroup="ValidacaoCadastro" runat="server"
                                ControlToValidate="DrpAtivo" CssClass="field-validation-error" ErrorMessage=" *Informe se o cadastro esta ativo" />
                        </td>
                    </tr>
                </table>
                <table width="600" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="111">&nbsp;</td>
                        <td width="489">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <button runat="server" id="BtnLimpar" class="btnLimpar" onserverclick="BtnLimpar_ServerClick" />
                        </td>
                        <td>
                            <button runat="server" id="BtnCadastrar" class="btnGravar" onserverclick="BtnCadastrar_ServerClick" validationgroup="ValidacaoCadastro" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
