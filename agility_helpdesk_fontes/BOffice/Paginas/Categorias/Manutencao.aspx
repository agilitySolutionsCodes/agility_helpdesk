<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manutencao.aspx.cs" Inherits="BOffice.Categorias.Manutencao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title><%: Page.Title %>- Manutenção de Categorias Gerenciador de Conteúdo </title>
    <meta name="description" content="Gerenciador de conteúdo sistema Web Help-Desk Agility Solutions" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="inner_content_">
        <div id="nav_status">
            <table width="970" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="20">
                        <img src="Style/Images/home_icon.png" width="16" height="16" /></td>
                    <td width="950"><a href="Home">Home</a>&nbsp;>>&nbsp;
                                    <a href="Selecionar-Categorias-Cadastro">Selecionar tipo de cadastro de categoria</a>
                        &nbsp;>>&nbsp; Manutenção de categorias</td>
                </tr>
            </table>
        </div>
        <div id="form_box3">
            <asp:Label ID="LblMsgmChamados" runat="server" Visible="false" Style="font-family: Verdana, Geneva, sans-serif; font-size: 12px;" />
            <asp:GridView ID="GrdCategorias" runat="server" CssClass="border_table" AutoGenerateColumns="False"
                RowStyle-HorizontalAlign="NotSet" AllowPaging="True" OnRowDeleting="GrdCategorias_RowDeleting"
                OnPageIndexChanging="GrdCategorias_PageIndexChanging" PageSize="10" PagerStyle-CssClass="paginacao"
                meta:resourcekey="GrdCategoriasResource1">
                <RowStyle BackColor="#ffede1" />
                <AlternatingRowStyle BackColor="#ffdfca" />
                <Columns>
                    <asp:TemplateField HeaderText="Ações" meta:resourcekey="TemplateFieldResource1">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="BtnDeletar" OnClick="BtnDeletar_Click" OnClientClick="javascript:return confirm('Deseja excluir este registro?');"
                                CausesValidation="False" CommandName="Deletar" CommandArgument='<%# Bind("IdCategoria") %>'
                                ImageUrl="~/Style/Images/excluir.png" meta:resourcekey="BtnDeletarResource1" Height="16px" Width="16px" BorderColor="Transparent" BackColor="Transparent" />
                            <asp:ImageButton runat="server" ID="BtnEditar" OnClick="BtnEditar_Click" OnClientClick="javascript:return confirm('Deseja alterar este registro?');"
                                CausesValidation="False" CommandName="Editar" ImageUrl="~/Style/Images/alterar.png"
                                meta:resourcekey="BtnEditarResource1" Height="16px" Width="16px" BorderColor="Transparent" BackColor="Transparent" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" CssClass="header_table" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Código" Visible="true" meta:resourcekey="TemplateFieldResource2">
                        <ItemTemplate>
                            <asp:Label ID="lblIdCategoria" runat="server" Text='<%# Bind("IdCategoria") %>' meta:resourcekey="lblIdUsuarioResource1" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" CssClass="header_table" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nome" Visible="true" meta:resourcekey="TemplateFieldResource3">
                        <ItemTemplate>
                            <asp:Label ID="lblNome" runat="server" Text='<%# Bind("Nome") %>' meta:resourcekey="lblNomeResource2" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" CssClass="header_table" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descrição" Visible="true" meta:resourcekey="TemplateFieldResource3">
                        <ItemTemplate>
                            <asp:Label ID="lblDescricao" runat="server" Text='<%# Bind("Descricao") %>' meta:resourcekey="lblNomeResource2" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" CssClass="header_table" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ativo" Visible="true" meta:resourcekey="TemplateFieldResource3">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkAtivo" runat="server" Enabled="false" CssClass="chkAtivo" Checked='<%#Bind("Ativo") %>' />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" CssClass="header_table" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
