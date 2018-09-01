<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/Home.aspx.cs" Inherits="Presentacion_Home" Title="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:GridView ID="GV_Noticias" runat="server" CellPadding="4" 
            ForeColor="#333333" GridLines="None" 
            AutoGenerateColumns="False" Width="100%" 
            onrowcancelingedit="GV_Noticias_RowCancelingEdit" 
            onrowediting="GV_Noticias_RowEditing" 
            onrowupdating="GV_Noticias_RowUpdating" Font-Names="Century Gothic">
            <RowStyle BackColor="White" ForeColor="Black" BorderColor="#D5D5D5" 
                BorderStyle="Double" BorderWidth="2px" Font-Bold="False" Wrap="True" />
            <EmptyDataRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Ultimas Noticias..">
                    <EditItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="104px" 
                            ImageUrl='<%# Eval("[img_producto]") %>' Width="107px" />
                        <br />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="104px" 
                            ImageUrl='<%# Eval("[img_producto]") %>' Width="107px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:Label ID="L_IdEmp" runat="server" Text='<%# Eval("[id_empresa]") %>' 
                            Visible="False"></asp:Label>
                        <asp:Label ID="L_IdPro" runat="server" Text='<%# Eval("[id_producto]") %>' 
                            Visible="False"></asp:Label>
                        <asp:Label ID="L_Producto" runat="server" Text='<%# Eval("[producto]") %>' 
                            Font-Bold="True"></asp:Label>
                        &nbsp;(<asp:Label ID="L_Empresa" runat="server" Text='<%# Eval("[empresa]") %>'></asp:Label>
                        )<br />
                        <asp:Label ID="L_Descripcion" runat="server" 
                            Text='<%# Eval("[descripcion]") %>'></asp:Label>
                        <asp:Label ID="L_Cant_disp" runat="server" Font-Bold="True" 
                            Text='<%# Eval("[cant_dispo]") %>' Visible="False"></asp:Label>
                        <br />
                        <br />
                        Antes: $<asp:Label ID="L_Precio1" runat="server" 
                            Text='<%# Eval("[precio_ant]") %>'></asp:Label>
                        <br />
                        Ahora: $<asp:Label ID="L_Precio2" runat="server" ForeColor="Red" 
                            Text='<%# Eval("[precio_act]") %>'></asp:Label>
                        &nbsp;<br />
                        <br />
                        Cantidad:
                        <asp:TextBox ID="TB_Cant" runat="server" BorderStyle="Dotted" Height="19px" 
                            Width="47px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RV_Cant" runat="server" 
                            ControlToValidate="TB_Cant" ErrorMessage="*Requerido" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REV_Cant" runat="server" 
                            ControlToValidate="TB_Cant" ErrorMessage="Solo Puede Digitar Numeros" 
                            Font-Italic="True" Font-Names="Century Gothic" Font-Size="Small" 
                            ValidationExpression="[0-9]*" ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="L_IdEmp" runat="server" Text='<%# Eval("[id_empresa]") %>' 
                            Visible="False"></asp:Label>
                        <asp:Label ID="L_IdPro" runat="server" Text='<%# Eval("[id_producto]") %>' 
                            Visible="False"></asp:Label>
                        <asp:Label ID="L_Producto" runat="server" Text='<%# Eval("[producto]") %>' 
                            Font-Bold="True"></asp:Label>
                        <br />
                        <asp:Label ID="L_Descripcion" runat="server" 
                            Text='<%# Eval("[descripcion]") %>'></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="L_Empresa" runat="server" Text='<%# Eval("[empresa]") %>'></asp:Label>
                        <asp:Label ID="L_Cant_disp" runat="server" Font-Bold="True" 
                            Text='<%# Eval("[cant_dispo]") %>' Visible="False"></asp:Label>
                        <br />
                        <br />
                        Antes: $<asp:Label ID="L_Precio1" runat="server" 
                            Text='<%# Eval("[precio_ant]") %>'></asp:Label>
                        <br />
                        Ahora: $<asp:Label ID="L_Precio2" runat="server" ForeColor="Red" 
                            Text='<%# Eval("[precio_act]") %>'></asp:Label>
                        <br />
                        <br />
                        Fecha Promo<br />
                        Desde
                        <asp:Label ID="L_Fecha1" runat="server" Text='<%# Eval("[fecha_ini]") %>'></asp:Label>
                        &nbsp;hasta
                        <asp:Label ID="L_Fecha2" runat="server" Text='<%# Eval("[fecha_fin]") %>'></asp:Label>
                        .
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField CancelText="Cancelar" EditText="Comprar" 
                    ShowEditButton="True" UpdateText="Aceptar" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#EFEFEF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#00FF99" Font-Bold="True" ForeColor="White" 
                Font-Italic="False" Font-Names="Century Gothic" />
            <EditRowStyle BackColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="Black" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ODS_Noticias" runat="server" 
            SelectMethod="obtenerNoticias" TypeName="Usuario">
            <SelectParameters>
                <asp:SessionParameter Name="user" SessionField="id_user" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
</asp:Content>

