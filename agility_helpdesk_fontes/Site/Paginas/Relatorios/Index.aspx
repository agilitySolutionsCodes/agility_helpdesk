<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Site.Paginas.Relatorios.Index" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">

    <div id="right_side">
        <asp:Label ID="LblMsgmChamados" runat="server" Visible="false" Style="font-family: Verdana, Geneva, sans-serif; font-size: 12px;" />
        <asp:Chart ID="ChartReport" CssClass="ChartControlStyle" runat="server" Width="795px" ImageLocation="" Palette="EarthTones" PaletteCustomColors="Red">
            <Series>
                <asp:Series Name="SeriesReport" ChartArea="ChartAreaReport">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartAreaReport">
                </asp:ChartArea>
            </ChartAreas>
            <BorderSkin BackGradientStyle="Center" PageColor="Transparent" />
        </asp:Chart>
    </div>
</asp:Content>

