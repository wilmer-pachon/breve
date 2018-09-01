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

public partial class Presentacion_ConfigEmpresa : System.Web.UI.Page
{
    int _id_user;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_rol"].Equals("null")) {
            Response.Redirect("index.aspx");
        }
        if (Session["verificar"].Equals("Verificada") && !Session["estado"].Equals("Normal"))
        {
            Response.Redirect("Configuracion.aspx");
        }
        if (!Session["verificar"].Equals("Verificada") && Session["estado"].Equals("Gratis"))
        {
            Response.Redirect("Configuracion.aspx");
        }
        if (Session["verificar"].Equals("null") && !Session["estado"].Equals("null"))
        {
            Response.Redirect("Configuracion.aspx");
        }
        _id_user = int.Parse(Session["id_user"].ToString());


        
    }

    protected void B_RegistroProducto_Click(object sender, EventArgs e)
    {

    }
}
