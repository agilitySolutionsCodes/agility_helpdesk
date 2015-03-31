<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipoCadastroCentroCusto.aspx.cs" Inherits="BOffice.CentroCustos.Selecionar.TipoCadastroCentroCusto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content_acesso">
        <div id="inner_content_">

            <div id="nav_status">
                <table width="970" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="20">
                            <img src="Style/Images/home_icon.png" width="16" height="16" /></td>
                        <td width="950"><a href="Home">Home</a>&nbsp;>>&nbsp;Selecionar tipo de cadastro de centro de custo
                        </td>
                    </tr>
                </table>
            </div>
            <div id="title_acesso_">
                <img src="Style/Images/title_acesso.png" width="436" height="70" />
            </div>
            <div id="options_box">
                <a href="Centro-Custo-Cadastro">
                    <img src="Style/Images/cad_centro_custo.png" width="395" height="59" border="0" id="Image2" onmouseover="MM_swapImage('Image2','','Style/Images/cad_centro_custo_hover.png',1)" onmouseout="MM_swapImgRestore()" />
                </a>
                <a href="Centro-Custo-Manutencao">
                    <img src="Style/Images/manutencaodecentrodecusto.png" width="395" height="59" border="0" id="Image3" onmouseover="MM_swapImage('Image3','','Style/Images/manutencaodecentrodecusto.png',1)" onmouseout="MM_swapImgRestore()" />
                </a>
            </div>
        </div>
    </div>
</asp:Content>
