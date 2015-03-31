<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="BOffice.Usuarios.Cadastro" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
    <title><%: Page.Title %>- Cadastro de Usuários Gerenciador de Conteúdo </title>
    <asp:PlaceHolder runat="server"></asp:PlaceHolder>
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
                            Cadastro de usuário
                        </td>
                    </tr>
                </table>
            </div>
            <div id="title_acesso_">
                <img src="Style/Images/tit_cad_novo_usuario.png" width="368" height="70" />
            </div>
            <div id="form_box">
                <table width="800" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="4" class="preencher">Preencha os campos abaixo</td>
                    </tr>
                    <tr>
                        <td colspan="4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="input_titulos">Nome</td>
                        <td colspan="3" class="input_titulos">E-mail</td>
                    </tr>
                    <tr>
                        <td>
                            <input name="TxtNome" type="text" class="nome" id="TxtNome" required="" maxlength="80" runat="server" />
                            <asp:RequiredFieldValidator ID="ValidatorNome" ControlToValidate="TxtNome" ValidationGroup="ValidacaoCadastro" runat="server" CssClass="field-validation-error" ErrorMessage="*Informe o nome." />
                        </td>
                        <td colspan="3">
                            <input name="TxtEmail" title="E-mail" type="text" class="email" id="TxtEmail" maxlength="100" required="" pattern="[^@]+@[^@]+\.[a-zA-Z]{2,6}" runat="server" />
                            <asp:RequiredFieldValidator ID="ValidatorEmail" ControlToValidate="TxtEmail" ValidationGroup="ValidacaoCadastro" runat="server" CssClass="field-validation-error" ErrorMessage="*Informe o e-mail." />
                        </td>
                    </tr>
                </table>
                <table width="881" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="465">&nbsp;</td>
                        <td width="490">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="input_titulos">Centro de custo</td>
                        <td class="input_titulos">Cargo</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DrpCentroCusto" CssClass="empresa_" DataTextField="Descricao" DataValueField="IdCentroCusto" runat="server">
                            </asp:DropDownList>
                            <br />
                            <asp:RequiredFieldValidator ID="ValidadorCentroCusto" InitialValue="" ValidationGroup="ValidacaoCadastro" runat="server"
                                ControlToValidate="DrpCentroCusto" CssClass="field-validation-error" ErrorMessage=" *Selecione o centro de custo" />
                        </td>
                        <td>
                            <input name="TxtCargo" type="text" class="cargo" id="TxtCargo" required="" maxlength="70" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="ValidatorCargo" ControlToValidate="TxtCargo" ValidationGroup="ValidacaoCadastro"
                                runat="server" CssClass="field-validation-error" ErrorMessage="*Informe o cargo." />
                        </td>
                    </tr>
                </table>
                <table width="944" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="291">&nbsp;</td>
                        <td width="140">&nbsp;</td>
                        <td width="515">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="input_titulos">Telefone</td>
                        <td class="input_titulos">Ramal</td>
                        <td colspan="4" class="input_titulos">Foto</td>
                    </tr>
                    <tr>
                        <td>
                            <input name="TxtTelefone" type="number" class="telefone" id="TxtTelefone" required="" maxlength="10" runat="server" />
                        </td>
                        <td>
                            <input name="TxtRamal" type="text" class="ramal" id="TxtRamal" maxlength="5" runat="server" />
                        </td>
                        <td>
                            <asp:FileUpload ID="UploadImagem" runat="server" Style="border: 0; padding: 1px 1px 1px 1px; height: 25px; width: 325px;" CssClass="uploadGeneric" />
                        </td>
                    </tr>
                </table>
                <table id="tableSenhas" width="798" border="0" cellpadding="0" cellspacing="0" runat="server">
                    <tr>
                        <td width="440">&nbsp;</td>
                        <td width="370">&nbsp;</td>
                    </tr>
                    <tr id="trSenhas" runat="server">
                        <td class="input_titulos">Senha</td>
                        <td class="input_titulos">Confirmação de senha</td>
                    </tr>
                    <tr>
                        <td>
                            <input name="TxtSenha" type="password" class="senhaconfsenha" required="" id="TxtSenha" maxlength="40" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="ValidatorSenha" ControlToValidate="TxtSenha" ValidationGroup="ValidacaoCadastro"
                                runat="server" CssClass="field-validation-error" ErrorMessage="*Informe uma senha." />
                        </td>
                        <td>
                            <input name="TxtConfirmacaoSenha" type="password" class="senhaconfsenha" required="" id="TxtConfirmacaoSenha" maxlength="40" runat="server" />
                            <br />
                            <asp:RequiredFieldValidator ID="ValidatorConfSenha" ControlToValidate="TxtConfirmacaoSenha" ValidationGroup="ValidacaoCadastro"
                                runat="server" CssClass="field-validation-error" ErrorMessage="*Confirme a senha." />
                        </td>
                    </tr>
                </table>
                <table width="798" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="input_titulos">Ativo</td>
                        <td class="input_titulos">Administrador</td>
                    </tr>
                    <tr>
                        <td width="440">
                            <asp:DropDownList ID="DrpAtivo" runat="server" CssClass="com_class_pri">
                                <asp:ListItem Text="Selecione" Value="" />
                                <asp:ListItem Text="Sim" Value="Sim" />
                                <asp:ListItem Text="Não" Value="Nao" />
                            </asp:DropDownList>
                            <br />
                            <asp:RequiredFieldValidator ID="ValidadorAtivo" InitialValue="" ValidationGroup="ValidacaoCadastro" runat="server"
                                ControlToValidate="DrpAtivo" CssClass="field-validation-error" ErrorMessage=" *Informe se o usuário esta ativo" />
                        </td>
                        <td width="370">
                            <asp:DropDownList ID="DrpAdmin" runat="server" CssClass="com_class_pri">
                                <asp:ListItem Text="Selecione" Value="" />
                                <asp:ListItem Text="Sim" Value="Sim" />
                                <asp:ListItem Text="Não" Value="Nao" />
                            </asp:DropDownList>
                            <br />
                            <asp:RequiredFieldValidator ID="ValidadorAdmin" InitialValue="" ValidationGroup="ValidacaoCadastro" runat="server"
                                ControlToValidate="DrpAtivo" CssClass="field-validation-error" ErrorMessage=" *Informe se o usuário é administrador" />
                        </td>
                    </tr>
                </table>
                <table width="798" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="24">&nbsp;</td>
                        <td width="62">&nbsp;</td>
                        <td width="24">&nbsp;</td>
                        <td width="330">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="input_titulos">Perfil usuário</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DrpPerfil" CssClass="com_class_pri" runat="server">
                                <asp:ListItem Text="Selecione" Value="" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Solicitante" Value="S "></asp:ListItem>
                                <asp:ListItem Text="Atendente" Value="A "></asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <asp:RequiredFieldValidator ID="ValidadorPerfil" InitialValue="" ValidationGroup="ValidacaoCadastro" runat="server"
                                ControlToValidate="DrpPerfil" CssClass="field-validation-error" ErrorMessage=" *Selecione o perfil do usuário" />
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
                            <button type="submit" runat="server" id="BtnCadastrar" class="btnGravar" onserverclick="BtnCadastrar_ServerClick" validationgroup="ValidacaoCadastro" />
                        </td>
                    </tr>
                </table>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
