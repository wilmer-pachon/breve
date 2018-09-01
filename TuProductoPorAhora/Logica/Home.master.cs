using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class Presentacion_Home : System.Web.UI.MasterPage
{
    int _id_user;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["id_rol"].Equals("null") || Session["id_user"].Equals("null"))
            Response.Redirect("index.aspx");

        Usuario userDatos = new Usuario();
        _id_user = int.Parse(Session["id_user"].ToString());
        userDatos.obtenerDatosEdit(_id_user);

        Usuario userDatos1 = new Usuario();
        userDatos1.obtenerNotificaUser(_id_user);

        Usuario userDatos2 = new Usuario();
        userDatos2.obtenerNotificacion(_id_user);

        //Session["palabra"] = TB_Buscar.Text.ToString();
        //no guardar cache
        //Response.Cache.SetNoStore();
    }
    protected void IB_Buscar_Click(object sender, ImageClickEventArgs e)
    {
        Session["palabra"] = TB_Buscar.Text.ToString();

        if (Session["palabra"].Equals(""))
        {
           // this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Digite palabra clave para buscar');</script>");
        }
        else
        {
            Response.Redirect("Busqueda.aspx");
        }
     
    }
    protected void IB_Notificacion_Click(object sender, ImageClickEventArgs e)
    {
        Usuario user = new Usuario();
        user.cambiarEstadoNotificacion(_id_user);
        
    }
    protected void IB_Mensajes_Click(object sender, ImageClickEventArgs e)
    {
        Usuario user = new Usuario();
        user.cambiarEstadoMensaje(_id_user);
    }
    protected void IB_Cerrar_Click(object sender, ImageClickEventArgs e)
    {
        Session["rol"] = "null";
        Session["id_user"] = "null";
        Session["id_empresa"] = "null";
        Session["estado"] = "null";
        Session["verificar"] = "null";
        Response.Cache.SetNoStore();
        Response.Redirect("index.aspx");
    }

}
