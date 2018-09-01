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

public partial class Presentacion_NotificacionUser : System.Web.UI.Page
{
    int _id_user;
    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario userDatos = new Usuario();
        _id_user = int.Parse(Session["id_user"].ToString());
        userDatos.obtenerNotificaUser(_id_user);

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        
        //int id_notificacion = int.Parse(GV_Notificaciones.SelectedDataKey.ToString());
        
    }
    protected void GV_Notificaciones_RowEditing(object sender, GridViewEditEventArgs e)
    {
       // string id_notificacion = GV_Notificaciones.DataKeyNames;
        //int notificacion = int.Parse(id_notificacion);
    //    Usuario user = new Usuario();
    //    user.cambiarEstadoNotificacion(_id_user);
      //  int i = int.Parse(GV_Notificaciones.SelectedDataKey.Value.ToString());
    }
    protected void GV_Notificaciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        int i = int.Parse(GV_Notificaciones.SelectedDataKey.Value.ToString());
    }
}
