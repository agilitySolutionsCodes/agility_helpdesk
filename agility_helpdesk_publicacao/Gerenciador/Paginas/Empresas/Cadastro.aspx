<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="BOffice.Empresas.Cadastro" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title><%: Page.Title %>- Cadastro de Empresas Gerenciador de Conteúdo </title>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
        <%: Scripts.Render("~/bundles/JQueryValidator") %>
    </asp:PlaceHolder>
    <meta name="description" content="Gerenciador de conteúdo sistema Web Help-Desk Agility Solutions" />
</asp:Content>

<asp:Content ID="MainContentUsuarios" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content_acesso">
        <div id="inner_content_">
            <div id="nav_status">
                <table width="970" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20">
                            <img src="Style/Images/home_icon.png" width="16" height="16" /></td>
                        <td width="950"><a href="Home">Home</a>&nbsp;>>&nbsp;
                            <a href="Selecionar-Usuarios-Cadastro">Selecionar tipo de cadastro</a>&nbsp;>>&nbsp;
                            Cadastro de empresa
                        </td>
                    </tr>
                </table>
            </div>
            <div id="title_acesso_">
                <img src="Style/Images/cadastrar_nova_empresa.png" width="373" height="70" />
            </div>
            <div id="form_box2">
                <table width="842" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="4" class="preencher">Preencha os campos abaixo</td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="input_titulos">Razão Social</td>
                        <td class="input_titulos">Endereço</td>
                    </tr>
                    <tr>
                        <td>
                            <input name="TxtRazaoSocial" type="text" class="razaosocial" id="TxtRazaoSocial" maxlength="100" runat="server" />
                            <asp:RequiredFieldValidator ID="ValidatorRazaoSocial" ControlToValidate="TxtRazaoSocial" runat="server" CssClass="field-validation-error" ErrorMessage="*Informe a razão social." />
                        </td>
                        <td colspan="3">
                            <input name="TxtEndereco" type="text" class="endereco" id="TxtEndereco" maxlength="120" runat="server" />
                            <asp:RequiredFieldValidator ID="ValidatorEndereco" ControlToValidate="TxtEndereco" runat="server" CssClass="field-validation-error" ErrorMessage="*Informe o endereço." />
                        </td>
                    </tr>
                </table>
                <table width="843" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="422">&nbsp;</td>
                        <td width="421">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="input_titulos">Nome Fantasia</td>
                        <td class="input_titulos">CNPJ</td>
                    </tr>
                    <tr>
                        <td>
                            <input name="TxtNomeFantasia" type="text" class="nomefantasia" id="TxtNomeFantasia" maxlength="100" runat="server" />
                            <asp:RequiredFieldValidator ID="ValidatorNomeFantasia" ControlToValidate="TxtNomeFantasia" runat="server" CssClass="field-validation-error" ErrorMessage="*Informe o nome fantasia." />
                        </td>
                        <td>
                            <input name="TxtCNPJ" type="text" class="cnpj" id="TxtCNPJ" runat="server" maxlength="18" />
                            <asp:RequiredFieldValidator ID="ValidatorCNPJ" ControlToValidate="TxtCNPJ" runat="server" CssClass="field-validation-error" ErrorMessage="*Informe o CNPJ." />
                        </td>
                    </tr>
                </table>
                <table width="846" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="750">&nbsp;</td>
                        <td width="306">&nbsp;</td>
                        <td width="227">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="input_titulos">Estado</td>
                        <td class="input_titulos">&nbsp;&nbsp;Cidade</td>
                        <td class="input_titulos">&nbsp;&nbsp;CEP</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DrpEstado" CssClass="com_class_pri" runat="server">
                                <asp:ListItem Text="Selecione" Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="AC" Value="AC"></asp:ListItem>
                                <asp:ListItem Text="AL" Value="AL"></asp:ListItem>
                                <asp:ListItem Text="AP" Value="AP"></asp:ListItem>
                                <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                <asp:ListItem Text="BA" Value="BA"></asp:ListItem>
                                <asp:ListItem Text="CE" Value="CE"></asp:ListItem>
                                <asp:ListItem Text="DF" Value="DF"></asp:ListItem>
                                <asp:ListItem Text="ES" Value="ES"></asp:ListItem>
                                <asp:ListItem Text="GO" Value="GO"></asp:ListItem>
                                <asp:ListItem Text="MA" Value="MA"></asp:ListItem>
                                <asp:ListItem Text="MT" Value="MT"></asp:ListItem>
                                <asp:ListItem Text="MS" Value="MS"></asp:ListItem>
                                <asp:ListItem Text="MG" Value="MG"></asp:ListItem>
                                <asp:ListItem Text="PR" Value="PR"></asp:ListItem>
                                <asp:ListItem Text="PB" Value="PB"></asp:ListItem>
                                <asp:ListItem Text="PA" Value="PA"></asp:ListItem>
                                <asp:ListItem Text="PE" Value="PE"></asp:ListItem>
                                <asp:ListItem Text="PI" Value="PI"></asp:ListItem>
                                <asp:ListItem Text="RJ" Value="RJ"></asp:ListItem>
                                <asp:ListItem Text="RN" Value="RN"></asp:ListItem>
                                <asp:ListItem Text="RS" Value="RS"></asp:ListItem>
                                <asp:ListItem Text="RO" Value="RO"></asp:ListItem>
                                <asp:ListItem Text="RR" Value="RR"></asp:ListItem>
                                <asp:ListItem Text="SC" Value="SC"></asp:ListItem>
                                <asp:ListItem Text="SE" Value="SE"></asp:ListItem>
                                <asp:ListItem Text="SP" Value="SP"></asp:ListItem>
                                <asp:ListItem Text="TO" Value="TO"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;&nbsp;
                            <input name="TxtCidade" type="text" class="cidade" id="TxtCidade" maxlength="70" runat="server" />
                            <asp:RequiredFieldValidator ID="ValidatorCidade" ControlToValidate="TxtCidade" runat="server" CssClass="field-validation-error" ErrorMessage="*Informe a cidade." />
                        </td>
                        <td>&nbsp;&nbsp;
                            <input name="TxtCep" type="text" class="cep" id="TxtCep" maxlength="10" runat="server" />
                            <asp:RequiredFieldValidator ID="ValidatorCep" ControlToValidate="TxtCep" runat="server" CssClass="field-validation-error" ErrorMessage="*Informe o cep." />
                        </td>
                    </tr>
                </table>
                <table width="798" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="500">&nbsp;</td>
                        <td width="427">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="input_titulos">E-mail</td>
                        <td class="input_titulos">Filial</td>
                    </tr>
                    <tr>
                        <td>
                            <input title="E-mail" name="TxtEmail" type="text" class="email" id="TxtEmail" maxlength="100" runat="server" required="required" pattern="[^@]+@[^@]+\.[a-zA-Z]{2,6}" />
                            <asp:RequiredFieldValidator ID="ValidatorEmail" ControlToValidate="TxtEmail" runat="server" CssClass="field-validation-error" ErrorMessage="*Informe o email." />
                        </td>
                        <td width="495">
                            <asp:DropDownList ID="DrpFilial" AutoPostBack="true" OnSelectedIndexChanged="DrpFilial_EventClick" runat="server" CssClass="com_class_pri">
                                <asp:ListItem Text="Selecione" Value="" />
                                <asp:ListItem Text="Sim" Value="Sim" />
                                <asp:ListItem Text="Não" Value="Nao" />
                            </asp:DropDownList>
                            <br />
                            <asp:RequiredFieldValidator ID="ValidadorFilial" InitialValue="" ValidationGroup="ValidacaoCadastro" runat="server"
                                ControlToValidate="DrpFilial" CssClass="field-validation-error" ErrorMessage=" *Informe se o cadastro é matriz ou filial" />
                        </td>
                    </tr>
                </table>
                <br />
                <table width="798" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="input_titulos">Ativo</td>
                        <td class="input_titulos">Empresa</td>
                    </tr>
                    <tr>
                        <td width="450">
                            <asp:DropDownList ID="DrpAtivo" runat="server" CssClass="com_class_pri">
                                <asp:ListItem Text="Selecione" Value="" />
                                <asp:ListItem Text="Sim" Value="Sim" />
                                <asp:ListItem Text="Não" Value="Nao" />
                            </asp:DropDownList>
                            <br />
                            <asp:RequiredFieldValidator ID="ValidadorAtivo" InitialValue="" ValidationGroup="ValidacaoCadastro" runat="server"
                                ControlToValidate="DrpAtivo" CssClass="field-validation-error" ErrorMessage=" *Informe se o cadastro esta ativo" />
                        </td>
                        <td width="395">
                            <asp:DropDownList ID="DrpEmpresaMatriz" Enabled="false" DataTextField="RazaoSocial" DataValueField="IdEmpresa" runat="server" CssClass="com_class_pri">
                            </asp:DropDownList>
                            <br />
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
                            <button runat="server" id="BtnCadastrar" class="btnGravar" onserverclick="BtnCadastrar_ServerClick" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
