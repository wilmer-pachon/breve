<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/ReporteCarrito.aspx.cs" Inherits="Presentacion_ReporteCarrito" Title="Reporte Compras" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CRV_Carrito" runat="server" AutoDataBind="True" 
        Height="1031px" ReportSourceID="CRS_Carrito" Width="892px" />
    <CR:CrystalReportSource ID="CRS_Carrito" runat="server">
        <Report FileName="F:\breve\TuProductoPorAhora\Presentacion\Crystal\Carrito.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

