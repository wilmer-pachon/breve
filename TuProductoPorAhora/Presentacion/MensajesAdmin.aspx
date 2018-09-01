﻿<%@ Page Language="C#" MasterPageFile="~/Presentacion/MasterAdmin.master" 
AutoEventWireup="true" CodeFile="~/Logica/MensajesAdmin.aspx.cs" Inherits="Presentacion_MensajesAdmin" Title="Mensajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <asp:GridView ID="GV_MensajesUser" runat="server" 
    DataSourceID="ODS_MensajesUser" CellPadding="4" ForeColor="#333333" 
    GridLines="None" Font-Names="Century Gothic" Width="100%" Font-Bold="False">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#00FF99" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ODS_MensajesUser" runat="server" 
    SelectMethod="obtenerMensajesUser" TypeName="Usuario">
        <SelectParameters>
            <asp:SessionParameter Name="user" SessionField="id_user" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

