<%@ Page Language="C#" MasterPageFile="~/Presentacion/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Logica/ReporteProductos.aspx.cs" Inherits="Presentacion_ReporteProductos" Title="Reporte Productos" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        &nbsp;</p>
    <CR:CrystalReportViewer ID="CRV_ReporteProductos" runat="server" 
        AutoDataBind="true" ReportSourceID="CRS_ReporteProductos" />
    <p>
    </p>
    <p>
        <CR:CrystalReportSource ID="CRS_ReporteProductos" runat="server">
            <Report FileName="Crystal\Productoss.rpt">
            </Report>
        </CR:CrystalReportSource>
    </p>
</asp:Content>

