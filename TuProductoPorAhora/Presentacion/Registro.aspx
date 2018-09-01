<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Logica/Registro.aspx.cs" Inherits="Presentacion_Registro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Regístrate!</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            height: 80%;
            width: 70%;
        }
        .style7
        {
            width: 33%;
            height: 33%;
            text-align: center;
        }
        .style2
        {
            height: 20%;
        }

        .style9
        {
            height: 80%;
            width: 30%;
        }
    </style>
</head>
<body bgcolor="White">
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td class="style2" bgcolor="White" colspan="2">
           &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="IB_Index" runat="server" Height="50px" 
                    ImageUrl="../Imagenes/breve.png" PostBackUrl="~/Presentacion/index.aspx" 
                    Width="112px" ValidationGroup="none" />
                <br />
            </td>
            <td class="style2" bgcolor="White">
                <asp:TextBox ID="TextBox1" runat="server" Height="40%" Width="80%" 
                    BackColor="#F4F4FB" BorderColor="#999999" BorderStyle="Dotted" Font-Names="Century Gothic"
                    value=" Buscar" onfocus="if(this.value==' Buscar')this.value='' "
                    onblur="if(this.value=='')this.value=' Buscar' "
                    Font-Size="Medium" ForeColor="#999999" Visible="False"></asp:TextBox>
                <asp:ImageButton ID="IB_Buscar" runat="server" Height="23px" 
                    ImageUrl="~/Imagenes/lupa.png" Width="21px" ValidationGroup="none" 
                    Visible="False" />
            </td>
            <td class="style2" bgcolor="White">
                <asp:Button ID="B_Inicio" runat="server" BackColor="#00FF99" 
                    BorderStyle="None" Font-Names="Century Gothic" Font-Size="Large" 
                    ForeColor="White" Text="Ya tienes cuenta?" 
                    Width="100%" Height="40%" PostBackUrl="~/Presentacion/index.aspx" 
                    ValidationGroup="none" />
                </td>
        </tr>
        <tr>
            <td class="style9" bgcolor="White">
    <div>
    
        <br />
        <asp:Label ID="Label1" runat="server" CssClass="style7" 
            Font-Names="Century Gothic" ForeColor="#999999" Text="Nombre:"></asp:Label>
        <br />
    
        <asp:TextBox ID="TB_Nombre" runat="server" BorderStyle="Dotted" 
            Font-Names="Century Gothic" Width="90%" BorderColor="Silver" 
            ValidationGroup="*" MaxLength="30" ></asp:TextBox>
    
        <asp:RequiredFieldValidator ID="RV_Nombre" runat="server" 
            ControlToValidate="TB_Nombre" ErrorMessage="*" 
            ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
    
                <asp:RegularExpressionValidator ID="REV_Nom" runat="server" 
                    ControlToValidate="TB_Nombre" 
                    ErrorMessage="Solo Puede Digitar Letras!" Font-Italic="True" 
                    Font-Names="Century Gothic" Font-Size="Small" 
                    ValidationExpression="[A-Za-z]*" 
                    ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
    
        <br />
        <asp:Label ID="L_Apellido" runat="server" CssClass="style7" 
            Font-Names="Century Gothic" ForeColor="#999999" Text="Apellido:"></asp:Label>
        <br />
    
        <asp:TextBox ID="TB_Apellido" runat="server" BorderStyle="Dotted" 
            Font-Names="Century Gothic" Width="90%" BorderColor="Silver" 
            ValidationGroup="*" MaxLength="30" ></asp:TextBox>
    
        <asp:RequiredFieldValidator ID="RV_Apellido" runat="server" 
            ControlToValidate="TB_Apellido" ErrorMessage="*" 
            ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
    
                <asp:RegularExpressionValidator ID="REV_Ape" runat="server" 
                    ControlToValidate="TB_Apellido" 
                    ErrorMessage="Solo Puede Digitar Letras!" Font-Italic="True" 
                    Font-Names="Century Gothic" Font-Size="Small" 
                    ValidationExpression="[A-Za-z]*" 
                    ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
    
        <br />
    
    </div>
        <asp:Label ID="Label2" runat="server" CssClass="style7" 
            Font-Names="Century Gothic" ForeColor="#999999" Text="Usuario:"></asp:Label>
                <br />
                <asp:TextBox ID="TB_Usuario" runat="server" BorderStyle="Dotted" 
            Font-Names="Century Gothic" Width="150px" BorderColor="Silver" ValidationGroup="*" 
                    MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_User" runat="server" 
                    ControlToValidate="TB_Usuario" ErrorMessage="*" 
                    ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
                <asp:ImageButton ID="I_Verificar" runat="server" Height="20px" 
                    ImageUrl="~/Imagenes/Breve/pendiente.png" onclick="I_Verificar_Click" 
                    Width="20px" />
        <asp:Label ID="L_Verificar" runat="server" CssClass="style7" 
            Font-Names="Century Gothic" ForeColor="#999999" Text="Verifica tu usuario!"></asp:Label>
                <br />
        <asp:Label ID="Label7" runat="server" CssClass="style7" 
            Font-Names="Century Gothic" ForeColor="#999999" 
                    Text="Elige un usuario original, nadie más lo puede tener!" Font-Italic="True" 
                    Font-Size="Small"></asp:Label>
                <asp:RegularExpressionValidator ID="REV_User" runat="server" 
                    ControlToValidate="TB_Usuario" 
                    ErrorMessage="Solo Puede Digitar Numeros, Letras  . y _" Font-Italic="True" 
                    Font-Names="Century Gothic" Font-Size="Medium" 
                    ValidationExpression="[A-Za-z0-9._]*" 
                    ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
                <br />
                <br />
        <asp:Label ID="Label4" runat="server" CssClass="style7" 
            Font-Names="Century Gothic" ForeColor="#999999" Text="Correo:"></asp:Label>
                <br />
                <asp:TextBox ID="TB_Correo" runat="server" BorderStyle="Dotted" 
            Font-Names="Century Gothic" Width="90%" BorderColor="Silver" ValidationGroup="*" 
                    MaxLength="40"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_Correo" runat="server" 
                    ControlToValidate="TB_Correo" ErrorMessage="*" 
                    ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
                <br />
        <asp:Label ID="Label10" runat="server" CssClass="style7" 
            Font-Names="Century Gothic" ForeColor="#999999" 
                    Text="ejemplo@mail.com" Font-Italic="True" 
                    Font-Size="Small"></asp:Label>
                <br />
                <asp:RegularExpressionValidator ID="REV_Correo" runat="server" 
                    ControlToValidate="TB_Correo" 
                    ErrorMessage="Compruebe el correo" Font-Italic="True" 
                    Font-Names="Century Gothic" Font-Size="Small" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
                <br />
        <asp:Label ID="Label3" runat="server" CssClass="style7" 
            Font-Names="Century Gothic" ForeColor="#999999" Text="Contraseña:"></asp:Label>
                <br />
                <asp:TextBox ID="TB_Contra" runat="server" BorderStyle="Dotted" 
            Font-Names="Century Gothic" Width="90%" BorderColor="Silver" 
                    AutoCompleteType="Disabled" ValidationGroup="*" TextMode="Password" 
                    MaxLength="30">******</asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_Contra" runat="server" 
                    ControlToValidate="TB_Contra" ErrorMessage="*" 
                    ValidationGroup="VG_Registro" SetFocusOnError="True"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REV_Contra" runat="server" 
                    ControlToValidate="TB_Contra" 
                    ErrorMessage="Solo Puede Digitar Numeros y Letras!" Font-Italic="True" 
                    Font-Names="Century Gothic" Font-Size="Small" 
                    ValidationExpression="[A-Za-z0-9]*" 
                    ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
                <br />
                <br />
    <div>
    
        <asp:Label ID="Label5" runat="server" CssClass="style7" 
            Font-Names="Century Gothic" ForeColor="#999999" 
            Text="Fecha de Nacimiento:"></asp:Label>
        <br />
        &nbsp;<asp:DropDownList ID="DL_Dia" runat="server" 
            Font-Names="Century Gothic">
            <asp:ListItem Selected="True">Día</asp:ListItem>
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
        </asp:DropDownList>
    
                <asp:RequiredFieldValidator ID="RV_Dia" runat="server" 
            ControlToValidate="DL_Ano" ErrorMessage="*" ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
    
        <asp:DropDownList ID="DL_Mes" runat="server" Font-Names="Century Gothic">
            <asp:ListItem Selected="True">Mes</asp:ListItem>
            <asp:ListItem Value="01">Enero</asp:ListItem>
            <asp:ListItem Value="02">Febrero</asp:ListItem>
            <asp:ListItem Value="03">Marzo</asp:ListItem>
            <asp:ListItem Value="04">Abril</asp:ListItem>
            <asp:ListItem Value="05">Mayo</asp:ListItem>
            <asp:ListItem Value="06">Junio</asp:ListItem>
            <asp:ListItem Value="07">Julio</asp:ListItem>
            <asp:ListItem Value="08">Agosto</asp:ListItem>
            <asp:ListItem Value="09">Septiembre</asp:ListItem>
            <asp:ListItem Value="10">Octubre</asp:ListItem>
            <asp:ListItem Value="11">Noviembre</asp:ListItem>
            <asp:ListItem Value="12">Diciembre</asp:ListItem>
        </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RV_Mes" runat="server" 
            ControlToValidate="DL_Ano" ErrorMessage="*" ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
    
                <asp:DropDownList ID="DL_Ano" runat="server" 
            Font-Names="Century Gothic">
                    <asp:ListItem Selected="True">Año</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2010</asp:ListItem>
                    <asp:ListItem>2009</asp:ListItem>
                    <asp:ListItem>2008</asp:ListItem>
                    <asp:ListItem>2007</asp:ListItem>
                    <asp:ListItem>2006</asp:ListItem>
                    <asp:ListItem>2005</asp:ListItem>
                    <asp:ListItem>2004</asp:ListItem>
                    <asp:ListItem>2000</asp:ListItem>
                    <asp:ListItem>1999</asp:ListItem>
                    <asp:ListItem>1998</asp:ListItem>
                    <asp:ListItem>1997</asp:ListItem>
                    <asp:ListItem>1996</asp:ListItem>
                    <asp:ListItem>1995</asp:ListItem>
                    <asp:ListItem>1994</asp:ListItem>
                    <asp:ListItem>1993</asp:ListItem>
                    <asp:ListItem>1992</asp:ListItem>
                    <asp:ListItem>1991</asp:ListItem>
                    <asp:ListItem>1990</asp:ListItem>
                    <asp:ListItem>1989</asp:ListItem>
                    <asp:ListItem>1988</asp:ListItem>
                    <asp:ListItem>1987</asp:ListItem>
                    <asp:ListItem>1986</asp:ListItem>
                    <asp:ListItem>1985</asp:ListItem>
                    <asp:ListItem>1984</asp:ListItem>
                    <asp:ListItem>1983</asp:ListItem>
                    <asp:ListItem>1982</asp:ListItem>
                    <asp:ListItem>1981</asp:ListItem>
                    <asp:ListItem>1980</asp:ListItem>
                    <asp:ListItem>1979</asp:ListItem>
                    <asp:ListItem>1978</asp:ListItem>
                    <asp:ListItem>1977</asp:ListItem>
                    <asp:ListItem>1976</asp:ListItem>
                    <asp:ListItem>1975</asp:ListItem>
                    <asp:ListItem>1974</asp:ListItem>
                    <asp:ListItem>1973</asp:ListItem>
                    <asp:ListItem>1972</asp:ListItem>
                    <asp:ListItem>1971</asp:ListItem>
                    <asp:ListItem>1970</asp:ListItem>
                    <asp:ListItem>1969</asp:ListItem>
                    <asp:ListItem>1968</asp:ListItem>
                    <asp:ListItem>1967</asp:ListItem>
                    <asp:ListItem>1966</asp:ListItem>
                    <asp:ListItem>1965</asp:ListItem>
                    <asp:ListItem>1964</asp:ListItem>
                    <asp:ListItem>1963</asp:ListItem>
                    <asp:ListItem>1962</asp:ListItem>
                    <asp:ListItem>1961</asp:ListItem>
                    <asp:ListItem>1960</asp:ListItem>
                    <asp:ListItem>1959</asp:ListItem>
                    <asp:ListItem>1958</asp:ListItem>
                    <asp:ListItem>1957</asp:ListItem>
                    <asp:ListItem>1956</asp:ListItem>
                    <asp:ListItem>1955</asp:ListItem>
                    <asp:ListItem>1954</asp:ListItem>
                    <asp:ListItem>1953</asp:ListItem>
                    <asp:ListItem>1952</asp:ListItem>
                    <asp:ListItem>1951</asp:ListItem>
                    <asp:ListItem>1950</asp:ListItem>
                    <asp:ListItem>1949</asp:ListItem>
                    <asp:ListItem>1948</asp:ListItem>
        </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RV_Ano" runat="server" 
            ControlToValidate="DL_Ano" ErrorMessage="*" ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
    
        &nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:Label ID="Label8" runat="server" CssClass="style7" 
            Font-Names="Century Gothic" ForeColor="#999999" Text="Sexo:"></asp:Label>
        &nbsp;<asp:DropDownList ID="DL_Sexo" runat="server" Font-Names="Century Gothic">
            <asp:ListItem>Seleccionar...</asp:ListItem>
            <asp:ListItem Value="Femenino">Femenino</asp:ListItem>
            <asp:ListItem Value="Masculino">Masculino</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RV_Sexo" runat="server" 
            ControlToValidate="DL_Sexo" ErrorMessage="*" ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
                <br />
                <br />
    
        <div>
    
        <asp:Label ID="Label6" runat="server" CssClass="style7" 
            Font-Names="Century Gothic" ForeColor="#999999" Text="Ubicación:"></asp:Label>
            <asp:DropDownList ID="DL_Ciudad" runat="server" Font-Names="Century Gothic">
            <asp:ListItem>Bogotá</asp:ListItem>
                <asp:ListItem>Facatativá</asp:ListItem>
                <asp:ListItem Selected="True">Donde vives...</asp:ListItem>
        </asp:DropDownList>
    
            <asp:RequiredFieldValidator ID="RV_Ciudad" runat="server" 
                ControlToValidate="DL_Ciudad" ErrorMessage="*" 
                ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
    
    </div>
    
    </div>
                &nbsp;
                    <br />
                    <asp:Label ID="Label9" runat="server" Font-Bold="False" Font-Italic="True" 
                        Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#FF3300" 
                        Text="           * Campos Requeridos"></asp:Label>
                <br />
                <br />
                <asp:Button ID="B_Guardar" runat="server" BackColor="#00FF99" 
                    BorderStyle="None" Font-Names="Century Gothic" Font-Size="Large" 
                    ForeColor="White" Text="Listo!" Width="100%" onclick="B_Guardar_Click" 
                    ValidationGroup="VG_Registro" style="height: 29px" />
                <br />
                <br />
                <br />
                <br />
            </td>
            <td class="style3" bgcolor="White" colspan="3">
                <img alt="" src="../Imagenes/regis.jpg" style="width: 100%; height: " /></td>
        </tr>
        </table>
    </form>
</body>
</html>