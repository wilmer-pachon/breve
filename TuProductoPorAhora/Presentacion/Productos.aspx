<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/Productos.aspx.cs" Inherits="Presentacion_Productos" Title="Productos" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2008" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Tema1/Prueba.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style7
        {
            font-family: Century Gothic;
            margin: 0px 10px 0px 10px;
            width: 335px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    
        <asp:TextBox ID="TB_Nombre" runat="server" 
            Font-Names="Century Gothic" Width="55%" 
            ValidationGroup="*" MaxLength="30" CssClass="CajasProductos" 
            placeholder="Nombre"  ></asp:TextBox>
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TB_Nombre" ErrorMessage="*" 
            ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
    
    </div>
                <asp:TextBox ID="TB_PA" runat="server" 
            Font-Names="Century Gothic" Width="55%" ValidationGroup="*" 
                    MaxLength="30" CssClass="CajasProductos" 
        placeholder="Precio Actual"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TB_PA" ErrorMessage="*" 
                    ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TB_PP" runat="server" 
            Font-Names="Century Gothic" Width="55%" ValidationGroup="*" 
                    MaxLength="40" CssClass="CajasProductos" 
        placeholder="Precio Promoción"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="TB_PP" ErrorMessage="*" 
                    ValidationGroup="VG_Registro"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="TB_Descripcion" runat="server" 
            Font-Names="Century Gothic" Width="56%" 
                    AutoCompleteType="Disabled" ValidationGroup="*" TextMode="MultiLine" 
                    MaxLength="30" Height="207px" CssClass="CajasProductos" 
        placeholder="Digite Descripción"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TB_Descripcion" ErrorMessage="*" 
                    ValidationGroup="VG_Registro" SetFocusOnError="True"></asp:RequiredFieldValidator>
        <asp:Label ID="Label7" runat="server" CssClass="CajasProductos" 
            Font-Names="Century Gothic" ForeColor="#999999" Text="Categoria:"></asp:Label>
                <br />
        <br />
                        <asp:DropDownList ID="DL_Cat" runat="server" 
        AutoPostBack="True" DataSourceID="ODS_Categoria" DataTextField="categoria" 
        DataValueField="id_cat" CssClass="CajasProductos">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="ODS_Categoria" runat="server" 
        SelectMethod="obtenerCategoria" TypeName="Usuario"></asp:ObjectDataSource>
                        <br />
    <br />
        <asp:Label ID="Label5" runat="server" CssClass="CajasProductos" 
            Font-Names="Century Gothic" ForeColor="#999999" Text="Logo:"></asp:Label>
                <br />
                <asp:FileUpload ID="FU_Logo" runat="server" 
    CssClass="BotonAddenProductos2" ForeColor="Black" Width="325px" />
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="B_AgregarImg" runat="server" onclick="B_AgregarImg_Click" 
        Text="Agregar" CssClass="BotonAddenProductos" 
    Font-Names="Century Gothic" ForeColor="White" Height="36px" Width="102px" />
    &nbsp;<br />
    <br />
                        <asp:GridView ID="DV_ImgProducto" runat="server" 
        AutoGenerateColumns="False" CssClass="CajasProductos">
                            <Columns>
                                <asp:TemplateField HeaderText="Producto">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Height="171px" 
                                            ImageUrl='<%# Eval("[ruta]") %>' Width="138px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
    </asp:GridView>
                        <br />
                        <table class="style1">
                            <tr>
                                <td class="style7">
                                    &nbsp;&nbsp;&nbsp;
                                    Fecha Inicio Promo&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:TextBox ID="TB_Fecha_i" runat="server" AutoPostBack="True" Width="161px" 
                                        CssClass="CalendarProductos" ontextchanged="TB_Fecha_i_TextChanged"></asp:TextBox>
                                    <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="TB_Fecha_i" />
                                </td>
                                <td class="CalendarProductos">
                                    &nbsp;&nbsp;&nbsp;
                                    Fecha Fin Promo
                                    <br />
                                    <asp:TextBox ID="TB_Fecha_f" runat="server" AutoPostBack="True" Width="161px" 
                                        CssClass="CalendarProductos" ontextchanged="TB_Fecha_f_TextChanged"></asp:TextBox>
                                    <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="TB_Fecha_f" />
                                </td>
        </tr>
        <tr>
            <td class="CalendarProductos">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
                <br />
    <br />
                <br />
                <asp:Button ID="B_Guardar" runat="server" BackColor="#00FF99" 
                    BorderStyle="None" Font-Names="Century Gothic" Font-Size="Large" 
                    ForeColor="White" Text="Listo!" Width="20%" onclick="B_Guardar_Click" 
                    ValidationGroup="VG_Registro" CssClass="BotonListo" />
                <br />
                <br />
</asp:Content>

