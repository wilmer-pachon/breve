<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/Empresa.aspx.cs" Inherits="Presentacion_Empresa" Title="Empresa" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2008" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Tema1/Prueba.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style7
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:GridView ID="DV_FotoPerfil" runat="server" AutoGenerateColumns="False" 
            onrowcancelingedit="DV_FotoPerfil_RowCancelingEdit" 
            onrowediting="DV_FotoPerfil_RowEditing" 
            onrowupdating="DV_FotoPerfil_RowUpdating" BackColor="White" 
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        Selecciona el nuevo logo:<br />
                        <br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="100px" 
                            ImageUrl='<%# Eval("[img_empresa]") %>' Width="100px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" EditText="Cambiar" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:GridView ID="GV_Datos" runat="server" AutoGenerateColumns="False" 
            onrowcancelingedit="GV_Datos_RowCancelingEdit" 
            onrowediting="GV_Datos_RowEditing" onrowupdating="GV_Datos_RowUpdating" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="550px">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:Label ID="L_Empresa" runat="server" Text='<%# Eval("[empresa]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="L_Nit" runat="server" Text='<%# Eval("[nit]") %>'></asp:Label>
                        <br />
                        <br />
                        Dirección:&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TB_Direccion" runat="server" Text='<%# Eval("[direccion]") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RV_Dir" runat="server" 
                            ControlToValidate="TB_Direccion" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <br />
                        Telefono:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TB_Telefono" runat="server" Text='<%# Eval("[telefono]") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RV_tel" runat="server" 
                            ControlToValidate="TB_Telefono" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <br />
                        Descripción:
                        <asp:TextBox ID="TB_Descripcion" runat="server" Text='<%# Eval("[descripcion]") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RV_Des" runat="server" 
                            ControlToValidate="TB_Descripcion" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="L_Empresa" runat="server" Text='<%# Eval("[empresa]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="L_Nit" runat="server" Text='<%# Eval("[nit]") %>'></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="L_Direccion" runat="server" Text='<%# Eval("[direccion]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="L_Telefono" runat="server" Text='<%# Eval("[telefono]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="L_Descripcion" runat="server" 
                            Text='<%# Eval("[descripcion]") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:GridView ID="GV_Productos" runat="server" AutoGenerateColumns="False" 
            onrowcancelingedit="GV_Productos_RowCancelingEdit" 
            onrowdeleting="GV_Productos_RowDeleting" onrowediting="GV_Productos_RowEditing" 
            onrowupdating="GV_Productos_RowUpdating" CellPadding="4" 
            ForeColor="#333333" GridLines="None" Width="550px">
            <RowStyle BackColor="#EFF3FB" />
            <Columns>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Image ID="Image2" runat="server" Height="100px" 
                            ImageUrl='<%# Eval("[img_producto]") %>' Width="100px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:Label ID="L_Id" runat="server" Text='<%# Eval("[id_producto]") %>'></asp:Label>
                        <br />
                        Producto:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TB_Producto" runat="server" 
                            Text='<%# Eval("[producto]") %>'></asp:TextBox>
                        <br />
                        Descripción:&nbsp;
                        <asp:TextBox ID="TB_Descripcion" runat="server" 
                            Text='<%# Eval("[descripcion]") %>'></asp:TextBox>
                        <br />
                        Categoria:&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList ID="DL_Cat" runat="server" DataSourceID="ODS_Catego" 
                            DataTextField="categoria" DataValueField="id_cat">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ODS_Catego" runat="server" 
                            SelectMethod="obtenerCategoria" TypeName="Usuario"></asp:ObjectDataSource>
                        <br />
                        Precio Anterior:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; $<asp:TextBox ID="TB_PA" runat="server" 
                            Text='<%# Eval("[precio_ant]") %>'></asp:TextBox>
                        <br />
                        Precio Promoción:&nbsp;&nbsp;&nbsp;&nbsp; $<asp:TextBox ID="TB_PP" runat="server" 
                            Text='<%# Eval("[precio_act]") %>'></asp:TextBox>
                        <br />
                        <table class="style1">
                            <tr>
                                <td colspan="2">
                                    Fecha Promoción:</td>
                            </tr>
                            <tr>
                                <td>
                                    Inicio</td>
                                <td>
                                    Fin</td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    <asp:TextBox ID="TB_FI" runat="server" Text='<%# Eval("[fecha_ini]") %>'></asp:TextBox>
                                    <rjs:PopCalendar ID="PC_FechaIni" runat="server" AutoPostBack="True" />
                                </td>
                                <td class="style7">
                                    <asp:TextBox ID="TB_FF" runat="server" Text='<%# Eval("[fecha_fin]") %>'></asp:TextBox>
                                    <rjs:PopCalendar ID="PC_FechaFin" runat="server" AutoPostBack="True" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="L_Id" runat="server" Text='<%# Eval("[id_producto]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("[producto]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("[descripcion]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("[categoria]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("[precio_ant]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("[precio_act]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("[fecha_ini]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("[fecha_fin]") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
    </p>
</asp:Content>
