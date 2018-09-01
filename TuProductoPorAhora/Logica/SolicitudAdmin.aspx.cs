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

public partial class Presentacion_SolicitudAdmin : System.Web.UI.Page
{
    int _id_user;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_rol"].Equals("null") || !Session["id_rol"].Equals("1") || Session["id_user"].Equals("null"))
            Response.Redirect("index.aspx");

        _id_user = int.Parse(Session["id_user"].ToString());
   
        if (!IsPostBack)
        {
            Usuario obtener = new Usuario();
            obtener.obtenerSolicitudAdmin();
            
            Usuario datos = new Usuario();
            DataTable informacion = datos.obtenerSolicitudAdmin();

            if (informacion.Rows.Count == 0)
            {
                L_Msj.Text = "No hay solicitudes por el momento!";
            }
            else
            {
                GV_SolicituAdmin.DataSource = obtener.obtenerSolicitudAdmin();
                GV_SolicituAdmin.DataBind();
            }

        }
    }

    protected void GV_SolicituAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DatosUsuario datos =  new DatosUsuario();

        Label id = (Label)GV_SolicituAdmin.Rows[e.RowIndex].FindControl("L_Id");
        datos.Id_user = int.Parse(((Label)id.FindControl("L_Id")).Text);

        TextBox noti = (TextBox)GV_SolicituAdmin.Rows[e.RowIndex].FindControl("T_Mensaje");
        string valor1 = ((TextBox)noti.FindControl("T_Mensaje")).Text;

        string valor2 = ((DropDownList)GV_SolicituAdmin.Rows[e.RowIndex].FindControl("DL_Cat")).SelectedItem.ToString();

        if (valor2.Equals("Devolver"))
        {
            datos.Notificacion = valor1 + " su solicitud a sido: Devuelta";
            Usuario metodo = new Usuario();
            DatosUsuario sol = new DatosUsuario();
            Label i_d = (Label)GV_SolicituAdmin.Rows[e.RowIndex].FindControl("L_Id");
            sol.Id_user = int.Parse(((Label)i_d.FindControl("L_Id")).Text);
            sol.Id_empresa = 4;
            metodo.cambiarEstadoSolicitud(sol);
        }
        else
        {
            if (valor2.Equals("Rechazada"))
            {
                datos.Notificacion = valor1 + " su solicitud a sido: Rechazada";
                Usuario met = new Usuario();
                DatosUsuario sol = new DatosUsuario();

                Label id_ = (Label)GV_SolicituAdmin.Rows[e.RowIndex].FindControl("L_Id");
                sol.Id_user = int.Parse(((Label)id_.FindControl("L_Id")).Text);

                sol.Id_empresa = 3;

                met.cambiarEstadoSolicitud(sol);
            }
            else
            {
                datos.Notificacion = valor1 + " su solicitud a sido: " + valor2;
            }
        }
        
        datos.Nombre= "Respuesta a Solicitud";
        
        datos.Url = "~\\Imagenes\\Breve\\breve.png";

        Usuario user = new Usuario();
        user.notificarUsuarioAuto(datos);

        Usuario obtener = new Usuario();
        obtener.obtenerSolicitudAdmin();

        GV_SolicituAdmin.DataSource = obtener.obtenerSolicitudAdmin();
        GV_SolicituAdmin.DataBind();


        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Se ha notificado a el Usuario!');window.location=\"Solicitudadmin.aspx\"</script>");

    }
    protected void GV_SolicituAdmin_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GV_SolicituAdmin_RowEditing(object sender, GridViewEditEventArgs e)
    {

        GV_SolicituAdmin.EditIndex = e.NewEditIndex;
        Usuario obtener = new Usuario();
        obtener.obtenerSolicitudAdmin();

        GV_SolicituAdmin.DataSource = obtener.obtenerSolicitudAdmin();
        GV_SolicituAdmin.DataBind();
    }
    protected void GV_SolicituAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV_SolicituAdmin.EditIndex = -1;
        Usuario obtener = new Usuario();
        obtener.obtenerSolicitudAdmin();

        GV_SolicituAdmin.DataSource = obtener.obtenerSolicitudAdmin();
        GV_SolicituAdmin.DataBind();
    }
}
