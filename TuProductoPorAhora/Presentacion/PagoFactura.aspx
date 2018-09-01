<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/PagoFactura.aspx.cs" Inherits="Presentacion_PagoFactura" Title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="font-family: 'century Gothic'">
        El pedido sera enviado a la dirección:</p>
    <p style="font-family: 'century Gothic'">
        <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="299px"></asp:TextBox>
    </p>
    <p style="font-family: 'century Gothic'">
        <asp:Button ID="B_pago" runat="server" Text="Generar Factura" />
    </p>
</asp:Content>

