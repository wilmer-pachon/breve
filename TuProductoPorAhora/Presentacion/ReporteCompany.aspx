<%@ Page Language="C#" MasterPageFile="~/Presentacion/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Logica/ReporteCompany.aspx.cs" Inherits="Presentacion_ReporteCompany" Title="Reporte Empresas" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <CR:CrystalReportViewer ID="CRV_ReporteCompanyy" runat="server" 
        AutoDataBind="True" Height="1031px" ReportSourceID="CRS_ReporteCompanyy" 
        Width="892px" OnInit="CRV_ReporteCompanyy_Init" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="C:\Users\wilme\Desktop\SEXTO SEMESTRE\ING. SOFTWARE II\ING SOFTWARE II ( WILMER Y DAVID)\PROYECTO SOFTWARE II\breve\TuProductoPorAhora\Presentacion\Crystal\Cantidad_Company.rpt">
        </Report>
    </CR:CrystalReportSource>
    <br />
    <CR:CrystalReportSource ID="CRS_ReporteCompanyy" runat="server">
        <Report FileName="C:\Users\wilme\Desktop\SEXTO SEMESTRE\ING. SOFTWARE II\ING SOFTWARE II ( WILMER Y DAVID)\PROYECTO SOFTWARE II\breve\TuProductoPorAhora\Presentacion\Crystal\Cantidad_Company.rpt">
        </Report>
    </CR:CrystalReportSource>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

