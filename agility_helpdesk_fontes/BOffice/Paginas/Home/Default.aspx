<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BOffice._Default" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
    <title><%: Page.Title %>- Gerenciador de Conteúdo </title>
    <meta name="description" content="Gerenciador de conteúdo sistema Web Help-Desk Agility Solutions" />
</asp:Content>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <div id="content_acesso">
        <div id="inner_content_">
            <div id="nav_status">
                <table width="970" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20">
                            <img src="Style/Images/home_icon.png" width="16" height="16" />
                        </td>
                        <td width="950">Home</td>
                    </tr>
                </table>
            </div>
            <div id="title_acesso_">
                <img src="Style/Images/title_acesso.png" width="436" height="70" />
            </div>
            <div id="options_box">
                <a href="Selecionar-Usuarios-Cadastro">

                    <img src="Style/Images/cad_manut_usuario.png" width="394" height="59" border="0" id="Image2" onmouseover="MM_swapImage('Image2','','Style/Images/cad_manut_usuario_hover.png',1)" onmouseout="MM_swapImgRestore()" /></a>

                <a href="Selecionar-Categorias-Cadastro">

                    <img src="Style/Images/cad_manut_categoria.png" width="394" height="59" border="0" id="Image3" onmouseover="MM_swapImage('Image3','','Style/Images/cad_manut_categoria_hover.png',1)" onmouseout="MM_swapImgRestore()" /></a>

                <a href="Selecionar-Classificacoes-Cadastro">

                    <img src="Style/Images/cad_manut_classificacoes.png" width="395" height="59" border="0" id="Image4" onmouseover="MM_swapImage('Image4','','Style/Images/cad_manut_classificacoes_hover.png',1)" onmouseout="MM_swapImgRestore()" /></a>

                <a href="Selecionar-Centro-Custo-Cadastro">

                    <img src="Style/Images/cad_centro_custo.png" width="394" height="59" border="0" id="Image5" onmouseover="MM_swapImage('Image5','','Style/Images/cad_centro_custo_hover.png',1)" onmouseout="MM_swapImgRestore()" /></a>
            </div>
        </div>
    </div>
</asp:Content>
