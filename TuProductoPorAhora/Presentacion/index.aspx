<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Logica/index.aspx.cs" Inherits="Presentacion_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>breve.</title>
    <style type="text/css">
        body
        {
        	overflow-x:hidden;
        }
        .vFlotante
        {
        	position:absolute;
        	left:98%;
        	top:0%;
        	width:700px;
        	height:100%;
        	background-color:#ECECEC;
        	-webkit-transition:all .10s eise-in;
        	
        }
        .vFlotante:hover
        {
        	left:70%;
        }
        .content {
            position: relative;
            width: 576px;
            float: left;
            background: none repeat scroll 0% 0% #FFF;
            padding: 35px 32px 20px;
            margin-bottom: 30px;
            z-index: 1;
            overflow: hidden;
            border-top-left-radius: 4px;
            border-bottom-left-radius: 4px;
            box-shadow: 0px 1px 1px 1px rgba(0, 0, 0, 0.1);
            transition: height 300ms ease 0s;
        }
        .text-center {
            text-align: center;
            text-shadow: 1px 1px 0px rgba(0, 0, 0, 0.1);
        }
                
        .style1
        {
            width: 100%;
            height: 90%;
        }
        .style2
        {
            height: 10%;
            width: 30%;
        }

        .style3
        {
            height: 10%;
            width: 30%;
        }
        .style4
        {
            height: 10%;
            width: 30%;
        }
        .style5
        {
            height: 60%;
            width: 92%;
        }
        .style6
        {
            height: 20%;
            width: 92%;
        }
        .style7
        {
            height: 100%;
            width: 8%;
        }
        </style>
    </head>
    
    
    
    
    
    
<body>
    <form id="form1" runat="server">
    <div class="vFlotante">
        <hgroup>
            <h1>
        
                &nbsp;</h1>
            <h1>
        
                &nbsp;</h1>
            <h1>
        
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src="../Imagenes/breve.png" 
                    style="width: 32%; height: 117px; text-align: left;" /></h1>
            <h1>
        
                &nbsp; <asp:TextBox ID="Usuario" runat="server" BorderColor="Silver" 
            BorderStyle="Dotted" Font-Names="Century Gothic"  Font-Overline="False" 
            Width="37%" Height="30px" value="Usuario" 
            onfocus="if(this.value=='Usuario')this.value='' "
            onblur="if(this.value=='')this.value='Usuario' "
            Font-Size="Medium" ForeColor="#999999" style="text-align: left" MaxLength="20" 
                    ontextchanged="Usuario_TextChanged"></asp:TextBox>
              </h1>
            <h1>   
        <tr>
        &nbsp;&nbsp;<asp:TextBox ID="Contraseña" runat="server" 
            BorderColor="Silver" BorderStyle="Dotted" Width="37%" Height="30px" 
            Font-Names="Century Gothic" value="Contraseña" 
            onfocus="if(this.value=='Contraseña')this.value='' "
            onblur="if(this.value=='')this.value='Contraseña' "
            Font-Size="Medium" ForeColor="#999999" TextMode="Password" MaxLength="30"></asp:TextBox>
              </h1>
            <h1>
        
        </tr>
    
        &nbsp;&nbsp;<asp:Button ID="Listo" runat="server" Text="Listo" width="38%" 
            BackColor="#00FF99" BorderStyle="None" Font-Bold="True"
            Font-Names="Century Gothic" Font-Size="Medium" ForeColor="White" Height="24px" 
                    onclick="Listo_Click" ValidationGroup="V_Listo"/>
              </h1>
        </hgroup>
    </div>
            <table class="style1" frame="none" 
            style="background-image: url('../../Imagenes/inicio.jpg')">
        <tr>
            <td class="style2">
           &nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:ImageButton ID="IB_Index" runat="server" Height="50px" 
                    ImageUrl="../Imagenes/breve.png" PostBackUrl="~/Presentacion/index.aspx" 
                    Width="112px" />
            </td>
            <td class="style3">
                <asp:TextBox ID="TB_Buscar" runat="server" Height="40%" Width="70%" 
                    BackColor="#F4F4FB" BorderColor="#999999" BorderStyle="Dotted" Font-Names="Century Gothic"
                    Font-Size="Medium" ForeColor="#999999" MaxLength="30" 
                    ></asp:TextBox>
                <asp:ImageButton ID="IB_Buscar" runat="server" Height="23px" 
                    ImageUrl="~/Imagenes/lupa.png" Width="21px" onclick="IB_Buscar_Click" 
                     />
                <br />
                <asp:RegularExpressionValidator ID="REV_Buscar" runat="server" 
                    ControlToValidate="TB_Buscar" 
                    ErrorMessage="Solo Puede Digitar Letras y Numeros!" Font-Italic="True" 
                    Font-Names="Century Gothic" Font-Size="Small" 
                    ValidationExpression="[A-Za-z0-9 ]*" 
                    ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
            </td>
            <td class="style4">
                <asp:Button ID="Registro" runat="server" BackColor="#00FF99" BorderStyle="None" 
                    Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" 
                    ForeColor="White" Height="40px" PostBackUrl="~/Presentacion/Registro.aspx" 
                    Text="No tienes cuenta?" Width="100%" onclick="Registro_Click" />
            </td>
            <td rowspan="3" class="style7">
                <asp:ImageButton ID="ImageButton2" runat="server" 
                    Height="80%" ImageUrl="~/Imagenes/init.png" Width="80%" />
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="3">
            <img src="../Imagenes/Imagen2.jpg" style="width: 100%; height: 80" /></td>
        </tr>
        <tr>
            <td class="style6" colspan="3">
                <marquee behavior="scroll" direction="right" style="margin-bottom: 0px">
                <br />
                <br />
                <img src="../Imagenes/logo9_marcas_260original.jpg" 
                    style="width: 131px; height: 136px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="../Imagenes/exito.png" style="width: 120px; height: 131px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="../Imagenes/Jumbo.png" 
                    style="width: 140px; height: 139px; margin-top: 0px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="../Imagenes/juan_valdez_cafe.png" 
                    style="width: 139px; height: 142px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="../Imagenes/Logotipo%20ADIDAS.png" 
                    style="width: 148px; height: 143px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <img src="../Imagenes/starbucks.png" style="width: 145px; height: 142px" /><br />
                <br /></marquee></td>
        </tr>
                </table>
        
    </form>
    </body>
</html>
