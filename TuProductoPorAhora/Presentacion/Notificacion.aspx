<%@ Page Language="C#" MasterPageFile="~/Presentacion/MasterAdmin.master" 
AutoEventWireup="true" CodeFile="~/Logica/Notificacion.aspx.cs" 
Inherits="Presentacion_Notificacion" Title="Notificaciones" %>

<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style8
        {   
            height: 100%;
        }
    </style>
    <link href="../App_Themes/Tema1/Prueba.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" style="text-align: center">
        <tr>
            <td style="font-family: 'Century Gothic'; text-align: center;" class="style8">
                <br />
                Usuario:<br />
                <br />
                <asp:DropDownList ID="DDL_Usuarios" runat="server" DataSourceID="ODS_Usuarios" 
                    DataTextField="nombre" DataValueField="id_user">
                    <asp:ListItem Selected="True">Seleccione...</asp:ListItem>
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ODS_Usuarios" runat="server" 
                    SelectMethod="obtenerUsuarios" TypeName="Usuario"></asp:ObjectDataSource>
                <br />
                <br />
                <!--Asunto:<br /> -->
                <br />
                <asp:TextBox ID="TB_NomreImg" runat="server" Height="44px" Width="43%" 
                    MaxLength="30" CssClass="CajaNotificacion" placeholder="Digite Asunto" 
                    Font-Size="Medium"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_Asunto" runat="server" 
                    ControlToValidate="TB_NomreImg" ErrorMessage="* Requerido" 
                    ValidationGroup="V_Notifica"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RV_User" runat="server" 
                    ControlToValidate="TB_NomreImg" ErrorMessage="*" 
                    ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REV_User" runat="server" 
                    ControlToValidate="TB_NomreImg" 
                    ErrorMessage="Solo Puede Digitar Numeros y Letras" Font-Italic="True" 
                    Font-Names="Century Gothic" Font-Size="Medium" 
                    ValidationExpression="[A-Za-z0-9. ]*" 
                    ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
                <br />
                <br />
                <!--Describe la notificación.<br /> -->
                <br />
                <asp:TextBox ID="TB_Notificar" runat="server" Height="197px" 
                    TextMode="MultiLine" Width="45%"  MaxLength="200" Font-Names="Century Gothic" 
                    Font-Size="Medium" ForeColor="Black" CssClass="CajaNotificacion" 
                    placeholder="Digite Notificación"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RV_Notifica" runat="server" 
                    ControlToValidate="TB_Notificar" ErrorMessage="*Requerido" 
                    ValidationGroup="V_Notifica"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="RV_User0" runat="server" 
                    ControlToValidate="TB_NomreImg" ErrorMessage="*" 
                    ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="REV_Not" runat="server" 
                    ControlToValidate="TB_Notificar" 
                    ErrorMessage="Solo Puede Digitar Numeros y Letras" Font-Italic="True" 
                    Font-Names="Century Gothic" Font-Size="Medium" 
                    ValidationExpression="[A-Za-z0-9. ]*" 
                    ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
                <br />
                <br />
                Acompaña la notificación con una imagen.<br />
                <br />
                <asp:FileUpload ID="FU_Logo" runat="server" Height="22px" Width="63%" 
                    BorderStyle="None" Font-Names="Century Gothic" Font-Size="Medium" />
                &nbsp;
                <asp:Button ID="B_Agregar" runat="server" onclick="B_Agregar_Click" 
                    Text="Adjuntar" />
                <br />
                <br />
                <br />
                <asp:GridView ID="GV_Img" runat="server" AutoGenerateColumns="False" 
                    onrowdeleting="GV_Img_RowDeleting">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="Image2" runat="server" Height="100px" 
                                    ImageUrl='<%# Eval("[ruta]") %>' Width="100px" />
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Image ID="Image1" runat="server" Height="200px" 
                            ImageUrl='<%# Eval("[ruta]") %>' Width="229px" />
                    </EmptyDataTemplate>
                </asp:GridView> 
                <br />
                <asp:Button ID="B_Notificar" runat="server" BackColor="#00FF99" 
                    Font-Names="Century Gothic" Font-Size="Large" ForeColor="White" Height="37px" 
                    onclick="B_Notificar_Click" Text="Notificar" Width="23%" 
                    BorderStyle="None" ValidationGroup="V_Notifica" 
                    CssClass="BotonCajaNotificacion" />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
        </table>
</asp:Content>

