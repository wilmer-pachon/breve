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

public partial class Presentacion_Busqueda : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //TB_Buscar.Text = Session["palabra"].ToString();

            DatosUsuario datos = new DatosUsuario();
            //datos.Nombre = TB_Buscar.Text.ToString();
            datos.Nombre = Session["palabra"].ToString();

            Usuario user = new Usuario();
            user.busquedaUser(datos);

            GV_Buscar.DataSource = user.busquedaUser(datos);
            GV_Buscar.DataBind();
        }

    }
    
   /* protected void IB_Buscar_Click(object sender, ImageClickEventArgs e)
    {
        DatosUsuario datos = new DatosUsuario();
        datos.Nombre = TB_Buscar.Text.ToString();

        Usuario user = new Usuario();
        user.busquedaUser(datos);

        GV_BuscarSin.DataSource = user.busquedaUser(datos);
        GV_BuscarSin.DataBind();
        Session["palabra"] = TB_Buscar.Text.ToString();
    }*/
   
    protected void GV_Buscar_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DatosUsuario datos = new DatosUsuario();

        datos.Id_empresa = int.Parse(((Label)GV_Buscar.Rows[e.RowIndex].FindControl("L_IdEmpresa")).Text);
        // Label Id_Emp = (Label)GV_Buscar.Rows[e.RowIndex].FindControl("L_IdEmpresa");
        // datos.Id_empresa = int.Parse(((Label)Id_Emp.FindControl("L_IdEmpresa")).Text);
        //punto de interrupcion
        Session["id_empresa"] = (datos.Id_empresa).ToString();

        if (Session["id_empresa"].Equals(""))
        {
            Label Id_Emp = (Label)GV_Buscar.Rows[e.RowIndex].FindControl("L_IdEmpresa");
            datos.Id_empresa = int.Parse(((Label)Id_Emp.FindControl("L_IdEmpresa")).Text);
        }
        else
        {
            Response.Redirect("PerfilEmpresa.aspx");
        } 
    }
}
