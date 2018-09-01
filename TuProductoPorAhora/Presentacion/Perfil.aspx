<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/Perfil.aspx.cs" Inherits="Presentacion_Perfil" Title="Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style7
    {
        text-align: left;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" style="font-family: 'Century Gothic', Large">
        <br />
        <asp:GridView ID="DV_FotoPerfil" runat="server" AutoGenerateColumns="False" onrowediting="DV_FotoPerfil_RowEditing" 
            onrowupdating="DV_FotoPerfil_RowUpdating" CellPadding="4" 
            ForeColor="#333333" GridLines="None" ShowHeader="False">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField HeaderText="Foto de Perfil" ShowHeader="False">
                    <AlternatingItemTemplate>
                        <span ID="idControl">DV_FotoPerfil</span> - Column[0] - Foto de Perfil
                    </AlternatingItemTemplate>
                    <EditItemTemplate>
                        <table cellpadding="0" cellspacing="0" 
                            style="margin: 5px 0px; border: 1px solid #A0A0A0; width: 100%; height: 100%">
                            <tr>
                                <td style="padding: 2px 4px; height: 17px; font-family: Segoe UI; font-style: normal; font-weight: normal; font-size: 9pt; text-decoration: none; background-color: buttonface; color: #102040; background-image: url(mvwres://Microsoft.Web.Design.Client, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a/TemplateHeaderBackground.gif); background-repeat: repeat-x; border-bottom: 1px solid #A0A0A0;">
                                    ItemTemplate
                                </td>
                            </tr>
                            <tr style="">
                                <td style="padding: 4px; height: 50px; vertical-align: top; color: #333333; background-color: #F7F6F3;">
                                    <asp:Image ID="Image1" runat="server" Height="91px" 
                                        ImageUrl='<%# Eval("[img_perfil]") %>' Width="91px" />
                                </td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="200px" 
                            ImageUrl='<%# Eval("[img_perfil]") %>' Width="200px" />
                    </ItemTemplate>
                    <ControlStyle BorderStyle="None" />
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#999999" />
            <AlternatingRowStyle BorderColor="White" BorderStyle="None" BackColor="White" 
                ForeColor="#284775" />
        </asp:GridView>
             <asp:GridView ID="GV_Datos" runat="server" DataSourceID="ODS_Datos_User" 
            AutoGenerateColumns="False" GridLines="None" 
            onrowediting="GV_Datos_RowEditing" onrowupdating="GV_Datos_RowUpdating" 
            ShowHeader="False">
            <Columns>
                <asp:TemplateField HeaderText="Información Personal" ShowHeader="False">
                    <EditItemTemplate>
                        <br />
                        Nombre:
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("[nombre]") %>'></asp:TextBox>
                        <br />
                        <br />
                        Apellido:
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("[apellido]") %>'></asp:TextBox>
                        <br />
                        <br />
                        Usuario:
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("[usuario]") %>'></asp:TextBox>
                        <br />
                        <br />
                        Correo:
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("[correo]") %>'></asp:TextBox>
                        <br />
                        <br />
                        Contraseña:
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Eval("[passwd]") %>'></asp:TextBox>
                        <br />
                        <br />
                        Fecha de Nacimiento:
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Eval("[dia]") %>'></asp:TextBox>
                        /<asp:TextBox ID="TextBox7" runat="server" Text='<%# Eval("[mes]") %>'></asp:TextBox>
                        /<asp:TextBox ID="TextBox8" runat="server" Text='<%# Eval("[ano]") %>'></asp:TextBox>
                        <br />
                        <br />
                        Sexo:
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Eval("[sexo]") %>'></asp:TextBox>
                        <br />
                        <br />
                        Ciudad:
                        
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Eval("[ciudad]") %>'></asp:TextBox>
                        
                    </EditItemTemplate>
                    <ItemTemplate>
                        <div class="style7">
                            <br />
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                                Text='<%# Eval("[nombre]") %>'></asp:Label>
&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("[apellido]") %>'></asp:Label>
                            &nbsp;(<asp:Label ID="Label4" runat="server" Text='<%# Eval("[usuario]") %>'></asp:Label>
                            )<br />
                            <br />
                            Correo:
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("[correo]") %>'></asp:Label>
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
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    <br />
        <asp:ObjectDataSource ID="ODS_Datos_User" runat="server" 
            SelectMethod="obtenerDatosEdit" TypeName="Usuario">
            <SelectParameters>
                <asp:SessionParameter Name="user" SessionField="id_user" Type="Int32" />
            </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
    <br />
</div>
</asp:Content>

