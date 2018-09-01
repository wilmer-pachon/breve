<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" 
CodeFile="~/Logica/Seguidores.aspx.cs" Inherits="Presentacion_Seguidores" Title="Suscriptores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<br />
    <br />
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label6" runat="server" Font-Bold="True" 
        Font-Names="Century Gothic" Text="Tus Suscriptores"></asp:Label>
    <br />
&nbsp;<asp:GridView ID="GridView2" runat="server" CellPadding="4" 
        DataSourceID="ODS_Seguidores" ForeColor="Black" GridLines="None" 
        ShowHeader="False" Width="100%" HorizontalAlign="Center" 
        AutoGenerateColumns="False" Font-Names="Century Gothic">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="105px" 
                        ImageUrl='<%# Eval("[img_perfil]") %>' Width="114px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" 
                        Text='<%# Eval("[usuario]") %>'></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("[nombre]") %>'></asp:Label>
                    &nbsp;<asp:Label ID="Label4" runat="server" Text='<%# Eval("[apellido]") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ODS_Seguidores" runat="server" 
        SelectMethod="obtenerSeguidores" TypeName="Usuario">
        <SelectParameters>
            <asp:SessionParameter Name="user" SessionField="id_empresa" 
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
</asp:Content>

