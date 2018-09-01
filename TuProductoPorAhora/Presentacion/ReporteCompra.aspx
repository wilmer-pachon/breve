<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/ReporteCompra.aspx.cs" Inherits="Presentacion_ReporteCompra" Title="Reporte Compra" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CRV_Compra" runat="server" 
    AutoDataBind="True" Height="1031px" ReportSourceID="CRS_Compra" 
        Width="892px" />
    <CR:CrystalReportSource ID="CRS_Compra" runat="server">
        <Report FileName="C:\Users\ASUS-PC\Dropbox\breve\breve\TuProductoPorAhora\Presentacion\Crystal\Compraa.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

