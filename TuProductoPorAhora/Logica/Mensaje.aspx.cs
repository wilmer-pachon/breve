using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Presentacion_Mensaje : System.Web.UI.Page
{
    int _id_user;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_rol"].Equals("null") || !Session["id_rol"].Equals("3") || Session["id_user"].Equals("null"))
             Response.Redirect("index.aspx");

         _id_user = int.Parse(Session["id_user"].ToString());
        
    }
    protected void B_Enviar_Click(object sender, EventArgs e)
    {
        DatosUsuario user = new DatosUsuario();
        user.Id_empresa = int.Parse(DDL_Usuarios.SelectedValue.ToString());
        user.Asunto = TB_Asunto.Text.ToString();
        user.Mensaje = TB_Mensaje.Text.ToString();
        user.Id_user = _id_user;
        
        Usuario datos = new Usuario();
        datos.mensajeUser(user);
        ClientScriptManager cm = this.ClientScript;
        cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El mensaje se a enviado');</script>");
    }
   
}
