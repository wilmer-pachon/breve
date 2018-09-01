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
using System.IO;

public partial class Presentacion_Perfil : System.Web.UI.Page
{
    int _id_user;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["id_rol"].Equals("null") || Session["id_user"].Equals("null"))
            Response.Redirect("index.aspx");
  

        Usuario userDatos = new Usuario();
        _id_user = int.Parse(Session["id_user"].ToString());
        userDatos.obtenerDatosEdit(_id_user);
       
        Session["fotos"] = null;

        if (!IsPostBack)
        {
            Usuario obtener = new Usuario();
            obtener.obtenerDatosEdit(_id_user);
            DV_FotoPerfil.DataSource = obtener.obtenerDatosEdit(_id_user);
            DV_FotoPerfil.DataBind();
        }

       
    }
    protected void DV_FotoPerfil_RowEditing(object sender, GridViewEditEventArgs e)
    {
       
    }

    protected void DV_FotoPerfil_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
      

    }

    protected void GV_Datos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
       
    }
    protected void GV_Datos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        

    }
    
}
