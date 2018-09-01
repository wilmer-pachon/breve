<%@ Page Language="C#" MasterPageFile="~/Presentacion/MasterAdmin.master" AutoEventWireup="true" 
CodeFile="~/Logica/MenuAdmin.aspx.cs" Inherits="Presentacion_MenuAdmin" Title="Administrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #Button1
        {
            height: 38px;
            width: 90px;
        }
        ul, ol
        {
            list-style: none;
        }
        .nav li a
        {
            background-color: White;
            color:Black;
            text-decoration:none;
            padding:10px 15px;
            display:block;
        }
        .nav li a:hover
        {
        	background-color:#ECECEC;
        }
        .nav > li 
        {
        	float:left;
        }
        .nav li ul 
        {
        	display:none;
        }
        .nav li:hover > ul 
        {
            display:block;
        }
        .nav li ul li 
        {
            position:relative;
        }
        .style6
        {
            width: 131px;
        }
        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<a>   Menu Administrador.</a>
</div><br />
<div>
    <ul class="nav">
            <li><a><asp:ImageButton ID="ImageButton13" runat="server" Height="200px" 
                    ImageUrl="~/Imagenes/Breve/ConfigAdmin.png" 
                    PostBackUrl="~/Presentacion/InfoAdmin.aspx" Width="200px" />
                <br />Mi Informacion</a>
            </li>
            <li><a><asp:ImageButton ID="ImageButton8" runat="server" Height="200px" 
                    ImageUrl="~/Imagenes/Breve/UsuariosAdmin.png" 
                    PostBackUrl="~/Presentacion/Admin.aspx" Width="200px" />
                <br />Usuarios</a>
            </li>
            <li><a><asp:ImageButton ID="ImageButton12" runat="server" Height="200px" 
                    ImageUrl="~/Imagenes/Breve/NotificarAdmin.png" 
                    PostBackUrl="~/Presentacion/Notificacion.aspx" Width="200px" />
                 <br />Notificar</a>
            </li>
            <li><a><asp:ImageButton ID="ImageButton10" runat="server" Height="200px" 
                    ImageUrl="~/Imagenes/Breve/SolicitudesAdmin.png" 
                    PostBackUrl="~/Presentacion/SolicitudAdmin.aspx" Width="200px" />
                <br />Solicitudes</a>
            </li>
            <li><a><asp:ImageButton ID="ImageButton2" runat="server" Height="200px" 
                    ImageUrl="~/Imagenes/Breve/PagoAdmin.png" 
                    PostBackUrl="~/Presentacion/Pagos.aspx" Width="200px" />
                <br />Pagos</a>
            </li>
            <li><a><asp:ImageButton ID="ImageButton11" runat="server" Height="200px" 
                    ImageUrl="~/Imagenes/Breve/MensajesAdmin.png" Width="200px" />
                 <br />Mensaje</a>
                 <ul>
                    <li><a href="MensajesAdmin.aspx"><span>Recibidos</span></a></li>
                    <li><a href="MensajeAdmin.aspx"><span>Enviar</span></a></li>
                 </ul>
            </li>
            <li><a><asp:ImageButton ID="ImageButton1" runat="server" Height="200px" 
                    ImageUrl="~/Imagenes/Breve/ReportesAdmin.png" Width="200px" />
                <br />Reportes</a>
                <ul>
                    <li><a href="ReporteUsers.aspx"><span>Usuarios</span></a></li>
                    <li><a href="ReporteCompany.aspx"><span>Empresas</span></a></li>
                    <li><a href="ReporteProductos.aspx"><span>Productos</span></a></li>
                    <li><a href="ReporteCarrito.aspx"><span>Carrito</span></a></li>
                </ul>
            </li>
    </ul>
</div>
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
<br />
</asp:Content>

