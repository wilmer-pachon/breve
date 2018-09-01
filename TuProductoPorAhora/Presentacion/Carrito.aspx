<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/Carrito.aspx.cs" 
Inherits="Presentacion_Carrito" Title="Carrito Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        ul, ol
        {
            list-style: none;
        }
        .botones li a
        {
            background-color: White;
            color:Black;
            text-decoration:none;
            padding:10px 15px;
            display:block;
        }
        .botones li a:hover
        {
        	background-color:#ECECEC;
        }
        .botones > li 
        {
        	float:right;
        }
        .botones li ul 
        {
        	display:none;
        }
        .botones li:hover > ul 
        {
            display:block;
        }
        .botones li ul li 
        {
            position:relative;
        }

        .style7
    {
        font-family: "Century Gothic";
        font-weight: bold;
    }
    .style8
    {
        font-size: century gothic;
        font-family: "Century Gothic";
        font-weight: bold;
    }

        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <br />

    <asp:GridView ID="GV_Compras" runat="server" 
    CellPadding="4" ForeColor="#333333" GridLines="None" 
        AutoGenerateColumns="False" 
        onrowcancelingedit="GV_Compras_RowCancelingEdit" 
        onrowdeleting="GV_Compras_RowDeleting" onrowediting="GV_Compras_RowEditing" 
        onrowupdating="GV_Compras_RowUpdating" Width="100%" 
    Font-Names="Century Gothic" AllowPaging="True" 
         ShowFooter="True">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField HeaderText="Productos">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="80px" 
                        ImageUrl='<%# Eval("[img_producto]") %>' Width="80px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:Label ID="L_Producto" runat="server" Text='<%# Eval("[producto]") %>'></asp:Label>
                    &nbsp;
                    <br />
                    Precio:
                    <asp:Label ID="L_Precio" runat="server" Text='<%# Eval("[precio_act]") %>'></asp:Label>
                    <asp:Label ID="L_CantDispo" runat="server" Text='<%# Eval("[cant_dispo]") %>' 
                        Visible="False"></asp:Label>
                    <asp:Label ID="L_IdPro" runat="server" Text='<%# Eval("[id_producto]") %>' 
                        Visible="False"></asp:Label>
                    <asp:Label ID="L_total" runat="server" Text='<%# Eval("[precio_total]") %>'></asp:Label>
                    <br />
                    Cantidad:&nbsp;
                    <asp:TextBox ID="TB_Cant" runat="server" BorderStyle="Dotted" Height="19px" 
                        Width="47px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RV_Cant" runat="server" 
                        ControlToValidate="TB_Cant" ErrorMessage="*Requerido" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REV_Cant" runat="server" 
                        ControlToValidate="TB_Cant" ErrorMessage="Solo Puede Digitar Numeros" 
                        Font-Italic="True" Font-Names="Century Gothic" Font-Size="Small" 
                        ValidationExpression="[0-9]*" ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
                    <br />
                    <br />
                    <br />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="L_Producto" runat="server" Text='<%# Eval("[producto]") %>'></asp:Label>
                    &nbsp;
                    <br />
                    Cantidad:
                    <asp:Label ID="L_Cantidad" runat="server" Text='<%# Eval("[cantidad]") %>'></asp:Label>
                    &nbsp;
                    <br />
                    Precio:
                    <asp:Label ID="L_Precio" runat="server" Text='<%# Eval("[precio_act]") %>'></asp:Label>
                    <asp:Label ID="L_CantDispo" runat="server" Text='<%# Eval("[cant_dispo]") %>' 
                        Visible="False"></asp:Label>
                    <asp:Label ID="L_IdPro" runat="server" Text='<%# Eval("[id_producto]") %>' 
                        Visible="False"></asp:Label>
                    <br />
                    Total:&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="L_total" runat="server" Text='<%# Eval("[precio_total]") %>'></asp:Label>
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField EditText="Editar Compra" ShowEditButton="True" 
                CancelText="Cancelar" DeleteText="Eliminar" UpdateText="Aceptar" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#00FF99" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="Black" />
    </asp:GridView>

    <asp:GridView ID="GV_Total" runat="server" 
    CellPadding="4" ForeColor="#333333" GridLines="None" 
        AutoGenerateColumns="False" 
        onrowcancelingedit="GV_Compras_RowCancelingEdit" 
        onrowdeleting="GV_Compras_RowDeleting" onrowediting="GV_Compras_RowEditing" 
        onrowupdating="GV_Compras_RowUpdating" Width="100%" 
    Font-Names="Century Gothic" ShowHeader="False">
        <RowStyle BackColor="White" ForeColor="#333333" />
        <Columns>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:Label ID="L_Producto0" runat="server" Text='<%# Eval("[producto]") %>'></asp:Label>
                    &nbsp;
                    <br />
                    Precio:
                    <asp:Label ID="L_Precio0" runat="server" Text='<%# Eval("[precio_act]") %>'></asp:Label>
                    <asp:Label ID="L_CantDispo0" runat="server" Text='<%# Eval("[cant_dispo]") %>' 
                        Visible="False"></asp:Label>
                    <asp:Label ID="L_IdPro0" runat="server" Text='<%# Eval("[id_producto]") %>' 
                        Visible="False"></asp:Label>
                    <asp:Label ID="L_total1" runat="server" Text='<%# Eval("[precio_total]") %>'></asp:Label>
                    <br />
                    Cantidad:&nbsp;
                    <asp:TextBox ID="TB_Cant0" runat="server" BorderStyle="Dotted" Height="19px" 
                        Width="47px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RV_Cant0" runat="server" 
                        ControlToValidate="TB_Cant" ErrorMessage="*Requerido" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REV_Cant0" runat="server" 
                        ControlToValidate="TB_Cant" ErrorMessage="Solo Puede Digitar Numeros" 
                        Font-Italic="True" Font-Names="Century Gothic" Font-Size="Small" 
                        ValidationExpression="[0-9]*" ValidationGroup="VG_Registro"></asp:RegularExpressionValidator>
                    <br />
                    <br />
                    <br />
                </EditItemTemplate>
                <ItemTemplate>
                    Total a Pagar: $<asp:Label ID="L_Total3" runat="server" ForeColor="Black" 
                        Text='<%# Eval("[total]") %>' Font-Size="X-Large"></asp:Label>
                    <br />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#00FF99" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="Black" />
    </asp:GridView>
    <br />
    <div>
        <ul class="botones">
            <li><a><asp:ImageButton ID="Button1" runat="server" 
                    PostBackUrl="~/Presentacion/ReporteCompra.aspx" Height="90px" 
                    ImageUrl="~/Imagenes/Breve/HistorialCompras.png" Width="90px" 
                    onclick="Button1_Click" />
                <br /><span class="style7">Compras.</span></a>
            </li>
            <li><a><asp:ImageButton ID="Button2" runat="server" onclick="B_Comprar_Click" 
                    Height="90px" ImageUrl="~/Imagenes/Breve/ComprarUser.png" Width="90px" />
                <br /><span class="style8">Comprar.</span></a>
            </li>
        </ul>
    </div>
    
    <br />
    <br />
    
    

</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
</asp:Content>
    
    


