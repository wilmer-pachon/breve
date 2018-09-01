<%@ Page Language="C#" MasterPageFile="~/Presentacion/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Logica/ReporteUsers.aspx.cs" Inherits="Presentacion_ReporteUsers" Title="Reporte Usuarios" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <CR:CrystalReportViewer ID="CRV_ReportUsers" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1269px" ReportSourceID="CrystalReportSource1" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1082px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="Crystal\Reporte_User.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>

