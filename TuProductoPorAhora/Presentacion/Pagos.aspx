<%@ Page Language="C#" MasterPageFile="~/Presentacion/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Logica/Pagos.aspx.cs" Inherits="Presentacion_Pagos" Title="Pagos" %>

<%@ Register assembly="RJS.Web.WebControl.PopCalendar.Net.2008" namespace="RJS.Web.WebControl" tagprefix="rjs" %>

<script runat="server">

   
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table class="style1">
        <tr>
            <td colspan="2">
                Estado de pago de las empresas:</td>
        </tr>
        <tr>
            <td>
                Seleccione el estado:
    <asp:DropDownList ID="DDL_Estado" runat="server" DataSourceID="ODS_EstadoPago" 
        DataTextField="estado" DataValueField="id_estado">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="ODS_EstadoPago" runat="server" 
        SelectMethod="obtenerEstadoPago" TypeName="Usuario"></asp:ObjectDataSource>
            </td>
            <td>
                Seleccione la fecha:
                <br />
                <asp:TextBox ID="TB_Fecha" runat="server"></asp:TextBox>
                <rjs:PopCalendar ID="PC_Fecha" runat="server" Control="TB_Fecha" />
                <asp:RegularExpressionValidator ID="REV_Fecha" runat="server" 
                    ControlToValidate="TB_Fecha" 
                    ErrorMessage="Solo Puede Digitar Numeros y -" Font-Italic="True" 
                    Font-Names="Century Gothic" Font-Size="Medium" 
                    ValidationExpression="[0-9-]*" 
                    ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="B_Estado" runat="server" onclick="B_Estado_Click" 
        Text="Ver" />
            </td>
            <td>
                <asp:Button ID="B_Fecha" runat="server" onclick="B_Fecha_Click" 
        Text="Ver" />
            </td>
        </tr>
    </table>
&nbsp;<br />
&nbsp;<asp:GridView ID="GV_Pagos" runat="server" 
        onrowcancelingedit="GV_Pagos_RowCancelingEdit" 
        onrowediting="GV_Pagos_RowEditing" onrowupdating="GV_Pagos_RowUpdating" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
        GridLines="None" style="margin-right: 251px">
        <RowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="55px" 
                        ImageUrl='<%# Eval("[img_empresa]") %>' Width="50px" />
                    <br />
                    <asp:Label ID="L_Id" runat="server" Text='<%# Eval("[id_empresa]") %>'></asp:Label>
                    <br />
                    <asp:Label ID="L_Empresa" runat="server" Text='<%# Eval("[empresa]") %>'></asp:Label>
                    <br />
                    <asp:Label ID="L_Nit" runat="server" Text='<%# Eval("[nit]") %>'></asp:Label>
                    <br />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="55px" 
                        ImageUrl='<%# Eval("[img_empresa]") %>' Width="50px" />
                    <br />
                    <asp:Label ID="L_Id" runat="server" Text='<%# Eval("[id_empresa]") %>'></asp:Label>
                    <br />
                    <asp:Label ID="L_Empresa" runat="server" Text='<%# Eval("[empresa]") %>'></asp:Label>
                    <br />
                    <asp:Label ID="L_Nit" runat="server" Text='<%# Eval("[nit]") %>'></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="L_Idpago" runat="server" Text='<%# Eval("[id_pago]") %>'></asp:Label>
                    <br />
                    Fecha Inicio:
                    <asp:Label ID="L_FI" runat="server" Text='<%# Eval("[fecha_ini]") %>'></asp:Label>
                    <br />
                    Fecha Fin:
                    <asp:Label ID="L_FF" runat="server" Text='<%# Eval("[fecha_fin]") %>'></asp:Label>
                    <br />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="L_Idpago" runat="server" Text='<%# Eval("[id_pago]") %>'></asp:Label>
                    <br />
                    Fecha Inicio:
                    <asp:Label ID="L_FI" runat="server" Text='<%# Eval("[fecha_ini]") %>'></asp:Label>
                    <br />
                    Fecha Fin:
                    <asp:Label ID="L_FF" runat="server" Text='<%# Eval("[fecha_fin]") %>'></asp:Label>
                    <br />
                    <br />
                    Cambiar el estado de pago:
                    <asp:DropDownList ID="DDL_Estado" runat="server" DataSourceID="ODS_EstadoPago" 
                        DataTextField="estado" DataValueField="id_estado">
                    </asp:DropDownList>
                    <br />
                    Amplie el perido de prueba<br />
                    *Solo si eligio Gratis<br />
                    <br />
                    Fecha Inicio:<br />
                    <asp:TextBox ID="TB_FI" runat="server"></asp:TextBox>
                    <rjs:PopCalendar ID="PC_Fecha0" runat="server" Control="TB_FI" />
                    <br />
                    <br />
                    Fecha Fin:<br />
                    <asp:TextBox ID="TB_FF" runat="server"></asp:TextBox>
                    <rjs:PopCalendar ID="PC_Fecha" runat="server" Control="TB_FF" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</asp:Content>

