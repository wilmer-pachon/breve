<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/ConfigEmpresa.aspx.cs" Inherits="Presentacion_ConfigEmpresa" Title="Configuracion Empresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div class="AlignHtml"> <head>
   
<meta charset='utf-8'>
   
<meta http-equiv="X-UA-Compatible" content="IE=edge">
   
<meta name="viewport" content="width=device-width, initial-scale=1">
   
<link rel="stylesheet" href="../Librerias/styles.css">
   
         <link href="../App_Themes/Tema1/Prueba.css" rel="stylesheet" type="text/css" />
   
<script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
 
 
  <title>CSS MenuMaker</title>
</head>
<body>

<div id='cssmenu'>
<ul>
 <li><a href="Productos.aspx"><span>Registrar Productos</span></a></li>
 <li class='active has-sub'><a href=""><span>Reportes</span></a>
 <ul>     
      <li><a href="ReporteVentas.aspx"><span>Ventas</span></a></li>
    <!-- <li><a href="#"><span>Reporte ****</span></a></li>
      <li><a href="#"><span>Reporte ****</span></a></li> -->
      </ul>
   </li>
 <li><a href="PerfilEmpresa.aspx"><span>Perfil Empresa</span></a></li>
 <li><a href="Empresa.aspx"><span>Editar Información</span></a></li>
 <li><a href="Seguidores.aspx"><span>Ver Seguidores</span></a></li>
 
 
</ul>
</div></div>
</asp:Content>

