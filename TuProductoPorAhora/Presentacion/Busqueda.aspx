<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/Busqueda.aspx.cs" Inherits="Presentacion_Busqueda" Title="Busqueda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
                <asp:GridView ID="GV_Buscar" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" 
                    Font-Names="Century Gothic" ShowHeader="False" 
        AutoGenerateColumns="False" onrowdeleting="GV_Buscar_RowDeleting" Width="100%">
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" Height="93px" 
                                    ImageUrl='<%# Eval("[img_producto]") %>' Width="89px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="L_IdEmpresa" runat="server" Text='<%# Eval("[id_empresa]") %>' 
                                    Visible="False"></asp:Label>
                                <asp:Label ID="L_IdPro" runat="server" Text='<%# Eval("[id_producto]") %>' 
                                    Visible="False"></asp:Label>
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
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField DeleteText="Ver más.." ShowDeleteButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#999999" />
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                </asp:GridView>
                <br />
</p>
<p>
    <br />
</p>
<p>
    <br />
</p>
</asp:Content>

