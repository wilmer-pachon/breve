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

public partial class Presentacion_MasterAdmin : System.Web.UI.MasterPage
{
    int _id_user;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_rol"].Equals("null") || Session["id_user"].Equals("null"))
            Response.Redirect("index.aspx");

        Usuario userDatos = new Usuario();
         _id_user = int.Parse(Session["id_user"].ToString());
        userDatos.obtenerDatosEdit(_id_user);
        //TB_Buscar.Text = Session["palabra"].ToString();
    }
    protected void B_Buscar_Click(object sender, ImageClickEventArgs e)
    {
        Session["palabra"] = TB_Buscar.Text.ToString();
    }
    protected void IB_Salir_Click(object sender, ImageClickEventArgs e)
    {
        Session["id_rol"] = "null";
        Session["user"] = "null";
        Session["id_user"] = "null";
        Response.Redirect("index.aspx");
    }
}
