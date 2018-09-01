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

public partial class Presentacion_Ver : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void B_Eliminar_Click(object sender, EventArgs e)
    {
        EliminarUsuario user = new EliminarUsuario();
        user.Cedula = int.Parse(TB_Eliminar.Text.ToString());

        Usuario userDatos = new Usuario();
        userDatos.elimUsuario(user);

    }
}
