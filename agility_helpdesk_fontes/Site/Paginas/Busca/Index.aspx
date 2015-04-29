<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Site.Paginas.Busca.Index" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <div id="right_side">
        <asp:Label ID="LblMsgmChamados" runat="server" Visible="false" Style="font-family: Verdana, Geneva, sans-serif; font-size: 12px;" />
        <br />
        <asp:GridView ID="GrdChamados" runat="server" CssClass="border_table" AutoGenerateColumns="False" RowStyle-HorizontalAlign="NotSet"
            OnRowDeleting="GrdChamados_RowDeleting" OnPageIndexChanging="GrdChamados_PageIndexChanging" PageSize="10" AllowPaging="true"
            AllowSorting="true" OnSorting="GridView_Sorting" meta:resourcekey="GrdChamadosResource1" PagerStyle-CssClass="paginacao">
            <RowStyle BackColor="#ffede1" />
            <AlternatingRowStyle BackColor="#ffdfca" />
            <Columns>
                <asp:TemplateField HeaderText="Número" Visible="true" ControlStyle-Width="50px" meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <a class="lbllink" href='<%#"Detalhe.aspx?IdChamado="+ DataBinder.Eval(Container.DataItem,"Codigo") %>'>
                            <asp:Label ID="IdChamado" Style="float: left;" runat="server" Visible="true" Text='<%# Bind("Codigo") %>' meta:resourcekey="lblIdChamadoResource2" />
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="100" HorizontalAlign="Center" CssClass="header_table" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Assunto do Chamado" ControlStyle-Width="200px" Visible="true" meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <a class="lbllink" href='<%#"Detalhe.aspx?IdChamado="+ DataBinder.Eval(Container.DataItem,"Codigo") %>'>
                            <asp:Label ID="lblAssunto" Style="float: left;" runat="server" Visible="true" Text='<%# Bind("Assunto") %>' meta:resourcekey="lblIdChamadoResource2" />
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="100" HorizontalAlign="Center" CssClass="header_table" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Solicitante" Visible="true" ControlStyle-Width="70px" meta:resourcekey="TemplateFieldResource2">
                    <ItemTemplate>
                        <a class="lbllink" href='<%#"Detalhe.aspx?IdChamado="+ DataBinder.Eval(Container.DataItem,"Codigo") %>'>
                            <asp:Label ID="lblSolicitante" Style="float: left;" runat="server" Visible="true" Text='<%# Bind("Solicitante") %>' meta:resourcekey="lblIdChamadoResource2" />
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="100" HorizontalAlign="Center" CssClass="header_table" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prioridade" Visible="true" ControlStyle-Width="60px" meta:resourcekey="TemplateFieldResource3">
                    <ItemTemplate>
                        <a class="lbllink" href='<%#"Detalhe.aspx?IdChamado="+ DataBinder.Eval(Container.DataItem,"Codigo") %>'>
                            <asp:Label ID="lblPrioridade" Style="float: left;" runat="server" Text='<%# Bind("Prioridade") %>' meta:resourcekey="lblNomeResource2" />
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="131" HorizontalAlign="Center" CssClass="header_table" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data de Abertura" Visible="true" ControlStyle-Width="120px" meta:resourcekey="TemplateFieldResource3">
                    <ItemTemplate>
                        <a class="lbllink" href='<%#"Detalhe.aspx?IdChamado="+ DataBinder.Eval(Container.DataItem,"Codigo") %>'>
                            <asp:Label ID="lblData" Style="float: left;" runat="server" Text='<%# Bind("Abertura") %>' meta:resourcekey="lblNomeResource2" />
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="105" HorizontalAlign="Center" CssClass="header_table" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Classificação" Visible="false" meta:resourcekey="TemplateFieldResource3">
                    <ItemTemplate>
                        <a class="lbllink" href='<%#"Detalhe.aspx?IdChamado="+ DataBinder.Eval(Container.DataItem,"Codigo") %>'>
                            <asp:Label ID="lblClassificacao" Style="float: left;" runat="server" Text='<%# Bind("Classificacao") %>' meta:resourcekey="lblNomeResource2" />
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="167" HorizontalAlign="Center" CssClass="header_table" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Categoria" Visible="false" meta:resourcekey="TemplateFieldResource3">
                    <ItemTemplate>
                        <a class="lbllink" href='<%#"Detalhe.aspx?IdChamado="+ DataBinder.Eval(Container.DataItem,"Codigo") %>'>
                            <asp:Label ID="lblCategoria" Visible="false" Style="float: left;" runat="server" Text='<%# Bind("Categoria") %>' meta:resourcekey="lblNomeResource2" />
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="167" HorizontalAlign="Center" CssClass="header_table" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" Visible="true" ControlStyle-Width="50px" meta:resourcekey="TemplateFieldResource3">
                    <ItemTemplate>
                        <a class="lbllink" href='<%#"Detalhe.aspx?IdChamado="+ DataBinder.Eval(Container.DataItem,"Codigo") %>'>
                            <asp:Label ID="lblStatus" Style="float: left;" runat="server" Text='<%# Bind("StatusChamado") %>' meta:resourcekey="lblNomeResource2" />
                        </a>
                    </ItemTemplate>
                    <HeaderStyle Width="178" HorizontalAlign="Center" CssClass="header_table" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Atender" Visible="true" ControlStyle-Width="20px" meta:resourcekey="TemplateFieldResource3">
                    <ItemTemplate>
                        <button runat="server" id="BtnAtender" class="btnAtender" onserverclick="BtnAtender_ServerClick" meta:resourcekey="BtnAtenderResource"></button>
                    </ItemTemplate>
                    <HeaderStyle Width="88" HorizontalAlign="Center" CssClass="header_table" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
