<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Logica/BuscarDefault.aspx.cs" Inherits="Presentacion_BuscarDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  
    <title>breve. - Buscar</title>
    <style type="text/css">
        body
        {
        	overflow-x:hidden;
            text-align: center;
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
        .style1
        {
            width: 100%;
            height: 90%;
        }
        
        .style3
        {
            height: 44px;
            width: 30%;
        }
        .style5
        {
            height: 60%;
            width: 50%;
        }
        .style6
        {
            height: 20%;
            width: 92%;
        }
        .style2
        {
            height: 10%;
            width: 30%;
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
        
                &nbsp; &nbsp;<asp:TextBox ID="Usuario" runat="server" BorderColor="Silver" 
            BorderStyle="Dotted" Font-Names="Century Gothic"  Font-Overline="False" 
            Width="37%" Height="30px" value="Usuario" 
            onfocus="if(this.value=='Usuario')this.value='' "
            onblur="if(this.value=='')this.value='Usuario' "
            Font-Size="Medium" ForeColor="#999999" style="text-align: left" MaxLength="20" 
                    ValidationGroup="V_Listo"></asp:TextBox>
              </h1>
            <h1>
        
        <br />
        
        <tr>
        &nbsp;&nbsp;
        <asp:TextBox ID="Contraseña" runat="server" 
            BorderColor="Silver" BorderStyle="Dotted" Width="37%" Height="30px" 
            Font-Names="Century Gothic" value="Contraseña" 
            onfocus="if(this.value=='Contraseña')this.value='' "
            onblur="if(this.value=='')this.value='Contraseña' "
            Font-Size="Medium" ForeColor="#999999" TextMode="Password" MaxLength="30" 
                    ValidationGroup="V_Listo"></asp:TextBox>
              </h1>
            <h1>
        
        </tr>
        
                <br />
        &nbsp;&nbsp;
        <asp:Button ID="Listo" runat="server" Text="Listo" width="38%" 
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
                    ValidationGroup="none" />
            </td>
            <td class="style3">
                <asp:Button ID="Registro" runat="server" BackColor="#00FF99" BorderStyle="None" 
                    Font-Bold="True" Font-Names="Century Gothic" Font-Size="Large" 
                    ForeColor="White" Height="40px" PostBackUrl="~/Presentacion/Registro.aspx" 
                    Text="No tienes cuenta?" Width="100%" onclick="Registro_Click" 
                    ValidationGroup="none" />
            </td>
        </tr>
        <tr>
            <td class="style5" colspan="3" bgcolor="#F7F7F7">
                <asp:GridView ID="GV_BuscarSin" runat="server" CellPadding="4" 
                    ForeColor="Black" GridLines="None" 
                    Font-Names="Century Gothic" AutoGenerateColumns="False" 
                    style="text-align: center" Width="50%" HorizontalAlign="Center">
                    <RowStyle BackColor="White" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="Resultados..">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="93px" 
                                    ImageUrl='<%# Eval("[img_producto]") %>' Width="89px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="L_IdPro" runat="server" Text='<%# Eval("[id_producto]") %>' 
                                    Visible="False"></asp:Label>
                                <asp:Label ID="L_Producto" runat="server" Text='<%# Eval("[producto]") %>'></asp:Label>
                                <br />
                                <asp:Label ID="L_Descripcion" runat="server" 
                                    Text='<%# Eval("[descripcion]") %>'></asp:Label>
                                <br />
                                Antes:&nbsp; $<asp:Label ID="L_Precio1" runat="server" 
                                    Text='<%# Eval("[precio_ant]") %>'></asp:Label>
                                <br />
                                Ahora: $<asp:Label ID="L_Precio2" runat="server" ForeColor="Red" 
                                    Text='<%# Eval("[precio_act]") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LB_Producto" runat="server" onclick="LB_Producto_Click" 
                                    Text='<%# Eval("[producto]") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#00FF99" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#00FF99" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#F3F3F3" />
                    <AlternatingRowStyle BackColor="White" ForeColor="Black" />
                </asp:GridView>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
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
