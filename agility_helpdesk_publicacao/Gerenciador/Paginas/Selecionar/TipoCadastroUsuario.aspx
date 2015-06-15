<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipoCadastroUsuario.aspx.cs" Inherits="BOffice.CentroCustos.Selecionar.TipoCadastro" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
    <title><%: Page.Title %>- Selecionar tipo de cadastro Gerenciador de Conteúdo </title>
    <meta name="description" content="Gerenciador de conteúdo sistema Web Help-Desk Agility Solutions" />
</asp:Content>

<asp:Content ID="MainContentTipo" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content_acesso">
        <div id="inner_content_">
            <div id="nav_status">
                <table width="970" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20">
                            <img src="Style/Images/home_icon.png" width="16" height="16" /></td>
                        <td width="950"><a href="Home">Home</a>&nbsp;>>&nbsp;Selecionar tipo de cadastro</td>
                    </tr>
                </table>
            </div>
            <div id="title_acesso_">
                <img src="Style/Images/title_acesso.png" width="436" height="70" />
            </div>
            <div id="options_box">
                <a href="Usuarios-Cadastro">
                    <img src="Style/Images/cad_novo_usuario.png" width="394" height="59" border="0" id="Image2" onmouseover="MM_swapImage('Image2','','Style/Images/cad_novo_usuario_hover.png',1)" onmouseout="MM_swapImgRestore()" /></a>
                <a href="Usuarios-Manutencao">
                    <img src="Style/Images/manutencao_de_usuario.png" width="394" height="60" border="0" id="Image4" onmouseover="MM_swapImage('Image4','','Style/Images/manutencao_de_usuario_hover.png',1)" onmouseout="MM_swapImgRestore()" /></a>
            </div>
        </div>
    </div>
</asp:Content>
