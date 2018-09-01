<%@ Page Language="C#" MasterPageFile="~/Presentacion/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Logica/Buscar.aspx.cs" Inherits="Presentacion_Buscar" Title="Busqueda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
    DataSourceID="ODS_BuscarAdmin" ForeColor="#333333" GridLines="None" 
        ShowHeader="False">
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
</asp:GridView>
<asp:ObjectDataSource ID="ODS_BuscarAdmin" runat="server" 
    SelectMethod="busquedaUser" TypeName="Usuario" OnSelecting="ODS_BuscarAdmin_Selecting">
    <SelectParameters>
        <asp:SessionParameter Name="palabra" SessionField="palabra" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
</asp:Content>

