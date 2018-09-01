<%@ Page Language="C#" MasterPageFile="~/Presentacion/MasterAdmin.master" AutoEventWireup="true" CodeFile="~/Logica/SolicitudAdmin.aspx.cs" Inherits="Presentacion_SolicitudAdmin" Title="Solicitud Administrador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <br />
     <br />
      <asp:Label ID="L_Msj" runat="server" Text=""></asp:Label>
     <br />
    
    <asp:GridView ID="GV_SolicituAdmin" runat="server" CellPadding="4" ForeColor="Black" 
        GridLines="None" AutoGenerateColumns="False" 
          onrowupdating="GV_SolicituAdmin_RowUpdating" 
          onrowcancelingedit="GV_SolicituAdmin_RowCancelingEdit" 
          onrowediting="GV_SolicituAdmin_RowEditing" Width="100%">
        <RowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Solicitudes.">
                <EditItemTemplate>
                    <asp:Label ID="L_Id" runat="server" Text='<%# Eval("[id_user]") %>' 
                        Visible="False"></asp:Label>
                    -<asp:Label ID="L_Nombre" runat="server" Text='<%# Eval("[nombre]") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="99px" 
                        ImageUrl='<%# Eval("[img_empresa]") %>' Width="101px" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <EditItemTemplate>
                    Respuesta a solicitud:
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="L_Empresa" runat="server" Text='<%# Eval("[empresa]") %>' 
                        CssClass="font" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="L_Nit" runat="server" Text='<%# Eval("[nit]") %>' 
                        CssClass="font" Font-Bold="True" Font-Names="Century Gothic"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="L_Direccion" runat="server" Text='<%# Eval("[direccion]") %>' 
                        CssClass="font" Font-Names="Century Gothic"></asp:Label>
                    <br />
                    <asp:Label ID="L_Telefono" runat="server" Text='<%# Eval("[telefono]") %>' 
                        CssClass="font" Font-Names="Century Gothic"></asp:Label>
                    <br />
                    <asp:Label ID="L_Descripcion" runat="server" Text='<%# Eval("[descripcion]") %>' 
                        CssClass="font" Font-Names="Century Gothic"></asp:Label>
                    <br />
                    Solicitud de:
                    <asp:Label ID="L_Nombre" runat="server" Text='<%# Eval("[nombre]") %>' 
                        CssClass="font"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <EditItemTemplate>
                     <asp:TextBox ID="T_Mensaje" runat="server" TextMode="MultiLine"></asp:TextBox>
                     <br />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image2" runat="server" Height="99px" 
                        ImageUrl='<%# Eval("[rut]") %>' Width="100px" />
                    <br />
                    
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%# Eval("[rut]") %>' CssClass="hyperlinkver" 
                        Font-Size="Small">Ver Imagen</asp:HyperLink> 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <EditItemTemplate>
                    <br />
                    <asp:DropDownList ID="DL_Cat" runat="server" 
                        DataSourceID="ODS_ObtenerSolicitud" DataTextField="verificar" 
                        DataValueField="id_solicitud">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ODS_ObtenerSolicitud" runat="server" 
                        SelectMethod="obtenerSolicitud" TypeName="Usuario"></asp:ObjectDataSource>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Image ID="Image2" runat="server" Height="99px" 
                        ImageUrl='<%# Eval("[cam_com]") %>' Width="100px" />
                    <br />
                    
                        <asp:HyperLink ID="HyperLink2" runat="server" 
                        NavigateUrl='<%# Eval("[cam_com]") %>' CssClass="hyperlinkver" 
                        Font-Size="Small">Ver Imagen</asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField EditText="Responder" ShowEditButton="True" 
                UpdateText="Enviar" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <EmptyDataTemplate>
            <asp:ImageButton ID="ImageButton8" runat="server" Height="86px" 
                ImageUrl='<%# Eval("[img_empresa]") %>' Width="81px" />
            &nbsp;&nbsp;
        </EmptyDataTemplate>
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#00FF99" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ODS_SolicitudAdminn" runat="server" 
        SelectMethod="obtenerSolicitudAdmin" TypeName="Usuario">
    </asp:ObjectDataSource>
   
</asp:Content>

