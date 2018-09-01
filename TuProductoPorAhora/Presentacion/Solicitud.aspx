<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/Solicitud.aspx.cs" Inherits="Presentacion_Solicitud" Title="Solicitud Empresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style7
        {
            width: 33%;
            height: 33%;
            text-align: center;
        }
        </style>
    <link href="../App_Themes/Tema1/Prueba.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <br />
        <asp:TextBox ID="TB_Nombre" runat="server" 
            Font-Names="Century Gothic" Width="46%" 
            ValidationGroup="*" MaxLength="30" CssClass="CajasSolicitud" 
            placeholder="Nombre"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TB_Nombre" ErrorMessage="*" 
            ValidationGroup="VG_Solicitud"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="TB_Nit" runat="server" 
            Font-Names="Century Gothic" Width="46%" 
            ValidationGroup="*" MaxLength="30" CssClass="CajasSolicitud" 
            placeholder="Nit"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
            ControlToValidate="TB_Nit" ErrorMessage="*" 
            ValidationGroup="VG_Solicitud"></asp:RequiredFieldValidator>
        <br />
    </div>
    <asp:TextBox ID="TB_Direccion" runat="server" 
            Font-Names="Century Gothic" Width="46%" ValidationGroup="*" 
                    MaxLength="30" CssClass="CajasSolicitud" 
        placeholder="Dirección"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TB_Direccion" ErrorMessage="*" 
                    ValidationGroup="VG_Solicitud"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="TB_Telefono" runat="server" 
            Font-Names="Century Gothic" Width="46%" ValidationGroup="*" 
                    MaxLength="40" CssClass="CajasSolicitud" 
        placeholder="Teléfono" ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="TB_Telefono" ErrorMessage="*" 
                    ValidationGroup="VG_Solicitud"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="TB_Descripcion" runat="server" 
            Font-Names="Century Gothic" Width="46%" 
                    AutoCompleteType="Disabled" ValidationGroup="*" TextMode="MultiLine" 
                    MaxLength="30" Height="207px" CssClass="CajasSolicitud" 
        placeholder="Descripción" ></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TB_Descripcion" ErrorMessage="*" 
                    ValidationGroup="VG_Solicitud" SetFocusOnError="True"></asp:RequiredFieldValidator>
    <br />
    
    <br />
    
    <asp:Label ID="Label5" runat="server" CssClass="CajasSolicitud" 
            Font-Names="Century Gothic" ForeColor="#999999" Text="Logotipo:"></asp:Label>
    <br />
    <asp:FileUpload ID="FU_Logo" runat="server" CssClass="CajasSolicitud2" 
        Width="310px" />
    <asp:Button ID="B_Logo" runat="server" Text="Adjuntar" onclick="B_Logo_Click" 
        CssClass="BotonAddenSolicitud" Height="27px" Width="75px" />
    <asp:GridView ID="GV_Logo" runat="server" AutoGenerateColumns="False" 
        CssClass="CajasSolicitud">
        <Columns>
            <asp:TemplateField HeaderText="Logo">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Height="200px" 
                        ImageUrl='<%# Eval("[imagen]") %>' Width="200px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    
    <asp:Label ID="Label6" runat="server" CssClass="CajasSolicitud" 
            Font-Names="Century Gothic" ForeColor="#999999" Text="Rut:"></asp:Label>
    <br />
    <asp:FileUpload ID="FU_Rut" runat="server" CssClass="CajasSolicitud2" />
    <asp:Button ID="B_Rut" runat="server" Text="Adjuntar" onclick="B_Rut_Click" 
        CssClass="BotonAddenSolicitud" Height="27px" Width="75px"/>
    <asp:GridView ID="GV_Rut" runat="server" AutoGenerateColumns="False" 
        CssClass="CajasSolicitud">
        <Columns>
            <asp:TemplateField HeaderText="Rut">
                <ItemTemplate>
                    <asp:Image ID="Image2" runat="server" Height="200px" 
                        ImageUrl='<%# Eval("[imagen]") %>' Width="200px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    
    <asp:Label ID="Label7" runat="server" CssClass="CajasSolicitud" 
            Font-Names="Century Gothic" ForeColor="#999999" 
        Text="Camara de Comercio:"></asp:Label>
    <br />
    <asp:FileUpload ID="FU_CC" runat="server" CssClass="CajasSolicitud2" />
    <asp:Button ID="B_CC" runat="server" Text="Adjuntar" 
        onclick="B_CC_Click" CssClass="BotonAddenSolicitud" Height="27px" 
        Width="75px" />
    &nbsp;<asp:GridView ID="GV_CC" runat="server" CssClass="CajasSolicitud" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Image ID="Image2" runat="server" Height="200px" 
                        ImageUrl='<%# Eval("[imagen]") %>' Width="200px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
&nbsp;<asp:Button ID="B_Guardar" runat="server" BackColor="#00FF99" 
                    BorderStyle="None" Font-Names="Century Gothic" Font-Size="Large" 
                    ForeColor="White" Text="Listo!" Width="15%" onclick="B_Guardar_Click" 
                    ValidationGroup="VG_Solicitud" CssClass="BotonEnviarMensaje" />
    <br />
</asp:Content>

