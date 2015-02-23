<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Selecionar.aspx.cs" Inherits="Site.Paginas.Relatorios.SelecionarTipoRelatorio" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div id="right_side">
        <button runat="server" id="BtnChamadosAbertos" class="btnChamadosAbertos" onserverclick="BtnChamadosAbertos_ServerClick" />
        <button runat="server" id="BtnChamadosFinalizados" class="btnChamadosFinalizados" onserverclick="BtnChamadosFinalizados_ServerClick" />
        <button runat="server" id="BtnTodosChamados" class="btnTotalChamados" onserverclick="BtnTodosChamados_ServerClick" />
    </div>
</asp:Content>
