<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" 
CodeFile="~/Logica/NotificacionUser.aspx.cs" Inherits="Presentacion_NotificacionUser" 
Title="Notificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
<asp:GridView ID="GV_Notificaciones" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataSourceID="ODS_Notificacion" ForeColor="#333333" 
        GridLines="None" Height="297px" Width="100%" 
        Font-Names="Century Gothic" 
    style="text-align: left" onrowupdating="GridView1_RowUpdating" 
        onrowcommand="GV_Notificaciones_RowCommand" 
        onrowediting="GV_Notificaciones_RowEditing" DataKeyNames="id_notificacion">
        <RowStyle BackColor="White" />
        <EmptyDataRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Tus notificaciones">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("[asunto]") %>' 
                        ForeColor="Black" Font-Names="Century Gothic"></asp:Label>
                    <br />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="162px" 
                        ImageUrl='<%# Eval("[url_img]") %>' Width="157px" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("[asunto]") %>' 
                        ForeColor="Black"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("[notificacion]") %>' 
                        ForeColor="Black"></asp:Label>
                    <br />
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("[fecha]") %>' 
                        ForeColor="Black"></asp:Label>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField CancelText="Volver" CausesValidation="False" 
                DeleteText="" EditText="Ver" InsertVisible="False" 
                ShowEditButton="True" UpdateText=""/>
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#00FF99" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="White" ForeColor="Black" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <br />
<br />
<br />
<br />
    <asp:ObjectDataSource ID="ODS_Notificacion" runat="server" 
        SelectMethod="obtenerNotificaUser" TypeName="Usuario">
        <SelectParameters>
            <asp:SessionParameter Name="user" SessionField="id_user" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

