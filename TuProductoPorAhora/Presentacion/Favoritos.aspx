<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" 
CodeFile="~/Logica/Favoritos.aspx.cs" Inherits="Presentacion_Favoritos" 
Title="Tus Suscripciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Tema1/Prueba.css" rel="stylesheet" type="text/css" />
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />&nbsp;<asp:GridView 
        ID="GV_Suscripciones" runat="server" DataSourceID="ODS_Favoritos" 
        CellPadding="4" ForeColor="Black" GridLines="None" 
        Width="100%" CssClass="GV_Favoritos" 
        onselectedindexchanged="GV_Suscripciones_SelectedIndexChanged" 
    AutoGenerateColumns="False">
        <RowStyle BackColor="White" ForeColor="Black" />
        <Columns>
            <asp:TemplateField HeaderText="Tus Suscripciones">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="101px" Width="101px" 
                        ImageUrl='<%# Eval("[img_empresa]") %>' />
                    &nbsp;
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("[empresa]") %>'></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("[descripcion]") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#00FF99" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="Black" />
</asp:GridView>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
<asp:ObjectDataSource ID="ODS_Favoritos" runat="server" 
    SelectMethod="obtenerSuscripciones" TypeName="Usuario">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="" Name="user" SessionField="id_user" 
            Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
    <br />
</asp:Content>

