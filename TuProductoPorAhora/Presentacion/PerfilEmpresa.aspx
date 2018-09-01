<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/PerfilEmpresa.aspx.cs" 
Inherits="Presentacion_PerfilEmpresa" Title="Perfil" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .susc
        {
            background-color: White;
            color:Black;
            text-decoration:none;
            padding:10px 15px;
            display:block;
        }
        .susc:hover
        {
        	background-color:#ECECEC;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:ObjectDataSource ID="ODS_Empresa" runat="server" 
            SelectMethod="obtenerEmpresa" TypeName="Usuario">
            <SelectParameters>
                <asp:SessionParameter Name="user" SessionField="id_user" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <p>
        <asp:GridView ID="GV_Empresa" runat="server" AutoGenerateColumns="False" 
            onrowupdating="GV_Empresa_RowUpdating" 
            onrowcancelingedit="GV_Empresa_RowCancelingEdit" 
            onrowediting="GV_Empresa_RowEditing" BackColor="White" CellPadding="4" 
            ForeColor="#333333" GridLines="None" ShowHeader="False" Width="100%" 
            Font-Names="Century Gothic">
            <RowStyle BackColor="White" ForeColor="Black" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton6" runat="server" Height="171px" 
                            ImageUrl='<%# Eval("[img_empresa]") %>' Width="184px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:Label ID="L_IdEmpresa" runat="server" Font-Bold="True" 
                            Text='<%# Eval("[id_empresa]") %>' Visible="False"></asp:Label>
                        <asp:Label ID="L_Empresa" runat="server" Font-Bold="True" 
                            Text='<%# Eval("[empresa]") %>'></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="L_Direccion" runat="server" Text='<%# Eval("[direccion]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="L_Telefono" runat="server" Text='<%# Eval("[telefono]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="L_Descripcion" runat="server" 
                            Text='<%# Eval("[descripcion]") %>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="L_IdEmpresa" runat="server" Font-Bold="True" 
                            Text='<%# Eval("[id_empresa]") %>' Visible="False"></asp:Label>
                        <asp:Label ID="L_Empresa" runat="server" Font-Bold="True" 
                            Text='<%# Eval("[empresa]") %>'></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="L_Direccion" runat="server" Text='<%# Eval("[direccion]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="L_Telefono" runat="server" Text='<%# Eval("[telefono]") %>'></asp:Label>
                        <br />
                        <asp:Label ID="L_Descripcion" runat="server" Text='<%# Eval("[descripcion]") %>'></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                </asp:TemplateField>
                
                <asp:CommandField  
                ShowEditButton="True" EditText= "Suscribirse"
                    UpdateText="Aceptar" CancelText="Cancelar" />
              
                 
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="Black" />
        </asp:GridView>
    </p>
    <p>
        &nbsp;</p>
<p>
        <asp:GridView ID="GV_Productos" runat="server" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" HorizontalAlign="Center" Width="100%" 
            onrowcancelingedit="GV_Productos_RowCancelingEdit" 
            onrowediting="GV_Productos_RowEditing" 
            onrowupdating="GV_Productos_RowUpdating" Font-Names="century gothic "   
            >
            <RowStyle BackColor="White" ForeColor="#333333" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Label ID="Label3" runat="server" Text="Sus productos."></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Height="130px" 
                            ImageUrl='<%# Eval("[img_producto]") %>' Width="130px" />
                    
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <EditItemTemplate>
                        <asp:Label ID="L_IdPro" runat="server" Text='<%# Eval("[id_producto]") %>'></asp:Label>
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
                        <br />
                        <asp:DropDownList ID="DDL_Cant" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="L_IdPro" runat="server" Text='<%# Eval("[id_producto]") %>'></asp:Label>
                    
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
                        <br />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField EditText="Comprar" ShowEditButton="True" 
                    UpdateText="Aceptar" CancelText="Cancelar" />
            </Columns>
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#00FF99" Font-Bold="True" ForeColor="White" 
                Font-Names="Century Gothic" />
            <EditRowStyle BackColor="White" />
            <AlternatingRowStyle BackColor="White" ForeColor="Black" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ODS_Productos" runat="server" 
            SelectMethod="obtenerProductos" TypeName="Usuario">
            <SelectParameters>
                <asp:SessionParameter Name="user" SessionField="id_empresa" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    </asp:Content>

