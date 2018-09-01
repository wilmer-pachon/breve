<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/Configuracion.aspx.cs" Inherits="Presentacion_Configuracion" Title="Configuracion" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2008" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Tema1/Prueba.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" 
    style="font-family: 'Century Gothic', Large; height: 1866px;">
        <br />
        <asp:GridView ID="DV_FotoPerfil" runat="server" AutoGenerateColumns="False" onrowediting="DV_FotoPerfil_RowEditing" 
            CellPadding="4" ForeColor="#333333" GridLines="None" ShowHeader="False" 
            onrowupdating="DV_FotoPerfil_RowUpdating" 
            onrowcancelingedit="DV_FotoPerfil_RowCancelingEdit" Width="100%">
            <RowStyle BackColor="White" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField HeaderText="Foto de Perfil">
                    <EditItemTemplate>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="152px" 
                            ImageUrl='<%# Eval("[img_perfil]") %>' Width="152px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" EditText="Editar" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="Black" />
        </asp:GridView>
        <asp:GridView ID="GV_Datos" runat="server" 
            AutoGenerateColumns="False" GridLines="None" 
            onrowediting="GV_Datos_RowEditing" onrowupdating="GV_Datos_RowUpdating" 
            CellPadding="4" ForeColor="#333333" ShowHeader="False" 
            onrowcancelingedit="GV_Datos_RowCancelingEdit" HorizontalAlign="Center" 
            Width="100%">
            <RowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Información Personal">
                    <EditItemTemplate>
                        <br />
                        Nombre:
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("[nombre]") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RV_Nombre" runat="server" 
                            ControlToValidate="TextBox1" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REV_Nom" runat="server" 
                            ControlToValidate="TextBox1" ErrorMessage="Solo Puede Digitar Letras!" 
                            Font-Italic="True" Font-Names="Century Gothic" Font-Size="Small" 
                            ValidationExpression="[A-Za-z]*" ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
                        <br />
                        <br />
                        Apellido:
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("[apellido]") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RV_Apellido" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REV_Ape" runat="server" 
                            ControlToValidate="TextBox2" ErrorMessage="Solo Puede Digitar Letras!" 
                            Font-Italic="True" Font-Names="Century Gothic" Font-Size="Small" 
                            ValidationExpression="[A-Za-z]*"></asp:RegularExpressionValidator>
                        <br />
                        <br />
                        Usuario:
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("[usuario]") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RV_User" runat="server" 
                            ControlToValidate="TextBox3" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REV_User" runat="server" 
                            ControlToValidate="TextBox3" 
                            ErrorMessage="Solo Puede Digitar Numeros, Letras  . y _" Font-Italic="True" 
                            Font-Names="Century Gothic" Font-Size="Small" 
                            ValidationExpression="[A-Za-z0-9._]*"></asp:RegularExpressionValidator>
                        <br />
                        <br />
                        Correo:
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("[correo]") %>'></asp:TextBox>
                        <br />
                        <asp:RegularExpressionValidator ID="REV_Correo" runat="server" 
                            ControlToValidate="TextBox4" ErrorMessage="Compruebe el correo" 
                            Font-Italic="True" Font-Names="Century Gothic" Font-Size="Small" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <br />
                        <br />
                        Contraseña:
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("[passwd]") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RV_Contra" runat="server" 
                            ControlToValidate="TextBox5" ErrorMessage="*" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REV_Contra" runat="server" 
                            ControlToValidate="TextBox5" 
                            ErrorMessage="Solo Puede Digitar Numeros y Letras!" Font-Italic="True" 
                            Font-Names="Century Gothic" Font-Size="Small" 
                            ValidationExpression="[A-Za-z0-9]*" ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
                        <br />
                        <br />
                        Fecha de Nacimiento:
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("[fecha_nac]") %>'></asp:TextBox>
                        <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="TextBox6" />
                        <asp:RequiredFieldValidator ID="RV_Fecha" runat="server" 
                            ControlToValidate="TextBox6" ErrorMessage="*" ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        Sexo:&nbsp;
                        <asp:DropDownList ID="DL_Sexo" runat="server">
                            <asp:ListItem>Femenino</asp:ListItem>
                            <asp:ListItem>Masculino</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <br />
                        Ciudad:
                        <asp:DropDownList ID="DL_Ciudad" runat="server">
                            <asp:ListItem>Bogotá</asp:ListItem>
                            <asp:ListItem>Facatativa</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;
                    </EditItemTemplate>
                    <ItemTemplate>
                        &nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("[nombre]") %>' 
                            Font-Bold="True"></asp:Label>
                        &nbsp;<asp:Label ID="Label3" runat="server" Text='<%# Eval("[apellido]") %>' 
                            Font-Bold="True"></asp:Label>
                        &nbsp;(<asp:Label ID="Label4" runat="server" Text='<%# Eval("[usuario]") %>'></asp:Label>
                        )<br />
                        <br />
                        Correo:
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("[correo]") %>'></asp:Label>
                        <br />
                        <br />
                        Contraseña:
                        <asp:Label ID="Label6" runat="server" Text="*******"></asp:Label>
                        <br />
                        <br />
                        Fecha de Nacimiento:
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("[fecha_nac]") %>'></asp:Label>
                        <br />
                        <br />
                        Sexo: 
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("[sexo]") %>'></asp:Label>
                        <br />
                        <br />
                        Ciudad: 
                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("[ciudad]") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" EditText="Editar" />
            </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
        <asp:ObjectDataSource ID="ODS_Datos_User" runat="server" 
            SelectMethod="obtenerDatosEdit" TypeName="Usuario">
            <SelectParameters>
                <asp:SessionParameter Name="user" SessionField="id_user" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:LinkButton ID="LB_CrearEmpresa" runat="server" 
            PostBackUrl="~/Presentacion/Configuracion.aspx" 
            CssClass="hyperlinCrearEmpresa"></asp:LinkButton>
        <br />
        <br />
    </div>
</asp:Content>

