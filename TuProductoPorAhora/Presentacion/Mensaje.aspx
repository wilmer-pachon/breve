<%@ Page Language="C#" MasterPageFile="~/Presentacion/Home.master" AutoEventWireup="true" CodeFile="~/Logica/Mensaje.aspx.cs" Inherits="Presentacion_Mensaje" Title="Mensajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../App_Themes/Tema1/Prueba.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
    <asp:DropDownList ID="DDL_Usuarios" runat="server" DataSourceID="ODS_Usuarios" 
        DataTextField="empresa" DataValueField="id_empresa" 
        Font-Names="Century Gothic">
    </asp:DropDownList>
    <asp:ObjectDataSource ID="ODS_Usuarios" runat="server" 
        SelectMethod="obtenerNoticias" TypeName="Usuario">
        <SelectParameters>
            <asp:SessionParameter Name="user" SessionField="id_user" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:TextBox ID="TB_Asunto" runat="server" Font-Names="Century Gothic" 
        Font-Size="Medium" MaxLength="30" Width="286px" 
        placeholder="Digite Asunto" CssClass="CajaMensaje" ></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="RV_Asunto" runat="server" 
                    ControlToValidate="TB_Asunto" ErrorMessage="*" 
                    ValidationGroup="VG_Mensaje"></asp:RequiredFieldValidator>
    
    <asp:RegularExpressionValidator ID="REV_Asunto" runat="server" 
                    ControlToValidate="TB_Asunto" 
                    ErrorMessage="Solo Puede Digitar Numeros y Letras" Font-Italic="True" 
                    Font-Names="Century Gothic" Font-Size="Medium" 
                    ValidationExpression="[A-Za-z0-9. ]*" 
                    ValidationGroup="VG_Mensaje"></asp:RegularExpressionValidator>
                    
    <asp:TextBox ID="TB_Mensaje" runat="server" Font-Names="Century Gothic" 
        Font-Size="Medium" Height="249px" MaxLength="240" 
         TextMode="MultiLine" Width="287px" placeholder="Digite Mensaje" 
        CssClass="CajaMensaje"></asp:TextBox>
    <br />
    <asp:RequiredFieldValidator ID="RV_Mensaje" runat="server" 
                    ControlToValidate="TB_Mensaje" ErrorMessage="*" 
                    ValidationGroup="VG_Mensaje"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="REV_Mensaje" runat="server" 
                    ControlToValidate="TB_Mensaje" 
                    ErrorMessage="Solo Puede Digitar Numeros y Letras" Font-Italic="True" 
                    Font-Names="Century Gothic" Font-Size="Medium" 
                    ValidationExpression="[A-Za-z0-9 ]*" 
                    ValidationGroup="VG_Mensaje"></asp:RegularExpressionValidator>
                    <asp:Label ID="Label9" runat="server" Font-Bold="False" Font-Italic="True" 
                        Font-Names="Century Gothic" Font-Size="Medium" ForeColor="#FF3300" 
                        Text="           * Campos Requeridos"></asp:Label>
                <asp:Button ID="B_Enviar" runat="server" onclick="B_Enviar_Click" 
        Text="Enviar" BackColor="#00FF99" Font-Names="Century Gothic" 
        Font-Size="Medium" ForeColor="White" Height="44px" Width="117px" 
        BorderStyle="None" CssClass="BotonEnviarMensaje" 
            ValidationGroup="VG_Mensaje" />
    <br />
    <br />
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    </asp:Content>

