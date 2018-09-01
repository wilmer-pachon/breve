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

public partial class Presentacion_Admin : System.Web.UI.Page
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
            obtener.obtenerUsuarios();
            GV_MostrarUsuarios.DataSource = obtener.obtenerUsuarios();
            GV_MostrarUsuarios.DataBind();
        }
    }
    
    protected void GV_MostrarUsuarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        DatosUsuario user = new DatosUsuario();

        string id  =((Label)GV_MostrarUsuarios.Rows[e.RowIndex].FindControl("L_Id")).Text.ToString();
        user.Id_user = int.Parse(id);

        TextBox Nom = (TextBox)GV_MostrarUsuarios.Rows[e.RowIndex].FindControl("T_Nombre");
        user.Nombre  = ((TextBox)Nom.FindControl("T_Nombre")).Text;

        TextBox Ape = (TextBox)GV_MostrarUsuarios.Rows[e.RowIndex].FindControl("T_Apellido");
        user.Apellido = ((TextBox)Ape.FindControl("T_Apellido")).Text;

        TextBox Usu = (TextBox)GV_MostrarUsuarios.Rows[e.RowIndex].FindControl("T_Usuario");
        user.Usuario = ((TextBox)Usu.FindControl("T_Usuario")).Text;

        TextBox Pas = (TextBox)GV_MostrarUsuarios.Rows[e.RowIndex].FindControl("T_Contrasena");
        user.Contra = ((TextBox)Pas.FindControl("T_Contrasena")).Text;

        TextBox Cor = (TextBox)GV_MostrarUsuarios.Rows[e.RowIndex].FindControl("T_Correo");
        user.Correo = ((TextBox)Cor.FindControl("T_Correo")).Text;

        TextBox Dia = (TextBox)GV_MostrarUsuarios.Rows[e.RowIndex].FindControl("T_Fecha");
        user.Dia = ((TextBox)Dia.FindControl("T_Fecha")).Text;

        user.Sexo = ((DropDownList)GV_MostrarUsuarios.Rows[e.RowIndex].FindControl("DL_Sexo")).SelectedItem.ToString();

        user.Ciudad = ((DropDownList)GV_MostrarUsuarios.Rows[e.RowIndex].FindControl("DL_Ciudad")).SelectedItem.ToString();
 
        Usuario userDatos = new Usuario();
        userDatos.modificarUser(user);

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Los datos del usuario de han actualizado!');window.location=\"Admin.aspx\"</script>");                  
        
    }
    protected void GV_MostrarUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GV_MostrarUsuarios.EditIndex = e.NewEditIndex;
        Usuario obtener = new Usuario();
        obtener.obtenerUsuarios();
        GV_MostrarUsuarios.DataSource = obtener.obtenerUsuarios();
        GV_MostrarUsuarios.DataBind();
    }
    protected void GV_MostrarUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        string id = ((Label)GV_MostrarUsuarios.Rows[e.RowIndex].FindControl("L_Id")).Text.ToString();
        int _id_user_ = int.Parse(id);

        Usuario userDatos = new Usuario();
        userDatos.eliminarUser(_id_user_);

        Usuario obtener = new Usuario();
        obtener.obtenerUsuarios();
        GV_MostrarUsuarios.DataSource = obtener.obtenerUsuarios();
        GV_MostrarUsuarios.DataBind();

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El usuario se ha eliminado!');window.location=\"Admin.aspx\"</script>");                  
    }
    protected void GV_MostrarUsuarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV_MostrarUsuarios.EditIndex = -1;
        Usuario obtener = new Usuario();
        obtener.obtenerUsuarios();
        GV_MostrarUsuarios.DataSource = obtener.obtenerUsuarios();
        GV_MostrarUsuarios.DataBind();
    }
}
