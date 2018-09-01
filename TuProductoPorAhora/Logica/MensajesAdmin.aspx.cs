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

public partial class Presentacion_MensajesAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Usuario userDatos = new Usuario();
        int _id_user = int.Parse(Session["id_user"].ToString());
        userDatos.obtenerMensajesUser(_id_user);
    }
}

