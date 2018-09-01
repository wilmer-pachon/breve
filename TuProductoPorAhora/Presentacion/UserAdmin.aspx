<%@ Page Language="C#" MasterPageFile="~/Presentacion/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Logica/UserAdmin.aspx.cs" Inherits="Presentacion_Admin" Title="Usuarios" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2008" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style6
    {
        width: 90%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<table class="style1">
    <tr>
        <td class="style6">
            <br />
            <asp:GridView ID="GV_MostrarUsuarios" runat="server" 
                onrowcancelingedit="GV_MostrarUsuarios_RowCancelingEdit" 
                onrowdeleting="GV_MostrarUsuarios_RowDeleting" 
                onrowediting="GV_MostrarUsuarios_RowEditing" 
                onrowupdating="GV_MostrarUsuarios_RowUpdating" 
                AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                GridLines="None" ShowHeader="False" Height="433px" Width="550px" >
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:TemplateField HeaderText="Datos de Usuario">
                        <EditItemTemplate>
                            <asp:Label ID="L_Id" runat="server" Text='<%# Eval("[id_user]") %>' 
                                Visible="False"></asp:Label>
                            Nombre:&nbsp;
                            <asp:TextBox ID="T_Nombre" runat="server" Text='<%# Eval("[nombre]") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RV_Nombre" runat="server" 
                                ControlToValidate="T_Nombre" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="REV_Nom" runat="server" 
                                ControlToValidate="T_Nombre" ErrorMessage="Solo Puede Digitar Letras!" 
                                Font-Italic="True" Font-Names="Century Gothic" Font-Size="Small" 
                                ValidationExpression="[A-Za-z ]*"></asp:RegularExpressionValidator>
                            <br />
                            <br />
                            Apellido:&nbsp;
                            <asp:TextBox ID="T_Apellido" runat="server" Text='<%# Eval("[apellido]") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RV_Apellido" runat="server" 
                                ControlToValidate="T_Apellido" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="REV_Ape" runat="server" 
                                ControlToValidate="T_Apellido" ErrorMessage="Solo Puede Digitar Letras!" 
                                Font-Italic="True" Font-Names="Century Gothic" Font-Size="Small" 
                                ValidationExpression="[A-Za-z ]*"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="L_Id" runat="server" Text='<%# Eval("[id_user]") %>' 
                                Visible="False"></asp:Label>
                            <asp:Label ID="L_Nombre" runat="server" Text='<%# Eval("[nombre]") %>'></asp:Label>
                            &nbsp;<asp:Label ID="L_Apellido" runat="server" Text='<%# Eval("[apellido]") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="L_Usuario" runat="server" Text='<%# Eval("[usuario]") %>'></asp:Label>
                            <br />
                            <asp:Label ID="L_Correo" runat="server" Text='<%# Eval("[correo]") %>'></asp:Label>
                            <br />
                            <asp:Label ID="L_Contra" runat="server" Text="*******"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            Usuario:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="T_Usuario" runat="server" Text='<%# Eval("[usuario]") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RV_User" runat="server" 
                                ControlToValidate="T_Usuario" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="REV_User" runat="server" 
                                ControlToValidate="T_Usuario" 
                                ErrorMessage="Solo Puede Digitar Numeros, Letras  . y _" Font-Italic="True" 
                                Font-Names="Century Gothic" Font-Size="Small" 
                                ValidationExpression="[A-Za-z0-9._]*"></asp:RegularExpressionValidator>
                            <br />
                            Correo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="T_Correo" runat="server" Text='<%# Eval("[correo]") %>'></asp:TextBox>
                        
                            <asp:RequiredFieldValidator ID="RV_Correo" runat="server" 
                                ControlToValidate="T_Correo" ErrorMessage="*" ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="REV_Correo" runat="server" 
                                ControlToValidate="T_Correo" ErrorMessage="Compruebe el correo" 
                                Font-Italic="True" Font-Names="Century Gothic" Font-Size="Small" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        
                            <br />
                            <br />
                            Contraseña:&nbsp;
                            <asp:TextBox ID="T_Contrasena" runat="server" Text='<%# Eval("[passwd]") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RV_Contra" runat="server" 
                                ControlToValidate="T_Contrasena" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="REV_Contra" runat="server" 
                                ControlToValidate="T_Contrasena" 
                                ErrorMessage="Solo Puede Digitar Numeros y Letras!" Font-Italic="True" 
                                Font-Names="Century Gothic" Font-Size="Small" 
                                ValidationExpression="[A-Za-z0-9]*"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <EditItemTemplate>
                            Fecha de Nacimiento:
                            <br />
                            <asp:TextBox ID="T_Fecha" runat="server" Text='<%# Eval("[fecha_nac]") %>'></asp:TextBox>
                            &nbsp;<rjs:PopCalendar ID="PC_Fecha" runat="server" Control="T_Fecha" 
                                ControlFocusOnError="True" />
                            <asp:RequiredFieldValidator ID="RV_Fecha" runat="server" 
                                ControlToValidate="T_Fecha" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="REV_Fecha" runat="server" 
                                ControlToValidate="T_Fecha" 
                                ErrorMessage="Fomato de fecha incorrecto dd-mm-aaaa" Font-Italic="True" 
                                Font-Names="Century Gothic" Font-Size="Small" ValidationExpression="[0-9-]*"></asp:RegularExpressionValidator>
                            <br />
                            <br />
                            Sexo:
                            <br />
                            <asp:DropDownList ID="DL_Sexo" runat="server">
                                <asp:ListItem>Femenino</asp:ListItem>
                                <asp:ListItem>Masculino</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                            Ciudad:
                            <br />
                            <asp:DropDownList ID="DL_Ciudad" runat="server">
                                <asp:ListItem>Facatativa</asp:ListItem>
                                <asp:ListItem>Bogotá</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
                            <asp:Label ID="L_CamposR" runat="server" Font-Italic="True" Font-Size="Medium" 
                                ForeColor="Red" Text="* Campos Requeridos"></asp:Label>
                            <br />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="L_Fecha" runat="server" Text='<%# Eval("[fecha_nac]") %>'></asp:Label>
                            <br />
                            <asp:Label ID="L_Sexo" runat="server" Text='<%# Eval("[sexo]") %>'></asp:Label>
                            <br />
                            <asp:Label ID="L_Ciudad" runat="server" Text='<%# Eval("[ciudad]") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="White" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style6">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

