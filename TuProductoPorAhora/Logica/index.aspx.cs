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

public partial class Presentacion_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["id_rol"] = "null";
        Session["estado_v"] = "1";
    }
    protected void Listo_Click(object sender, EventArgs e)
    {
        DatosUsuario user = new DatosUsuario();
        
        user.Login = Usuario.Text.ToString();
        user.Pass = Contraseña.Text.ToString();

        Usuario datos = new Usuario();
        DataTable informacion = datos.loginUsuario(user.Login, user.Pass);

        if (informacion.Rows.Count == 0)
        {
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Usuario o contraseña invalido, intente nuevamente!');window.location=\"index.aspx\"</script>");
        }
        else
        {
            Session["id_rol"] = informacion.Rows[0]["id_rol"].ToString();
            Session["usuario"] = informacion.Rows[0]["nombre"].ToString();
            Session["palabra"] = "Buscar"; 
            Session["id_user"] = informacion.Rows[0]["id_user"].ToString();
            if (int.Parse(Session["id_rol"].ToString()) == 1)
            {
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Bienvenido Administrador!');window.location=\"Menuadmin.aspx\"</script>");
            }
            else
            {
                if (int.Parse(Session["id_rol"].ToString()) == 2)
                {
                    this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Bienvenido Empresa');window.location=\"Home.aspx\"</script>");
                }
                else
                {
                    if (int.Parse(Session["id_rol"].ToString()) == 3)
                    {
                        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Bienvenido Usuario!');window.location=\"Home.aspx\"</script>");
                    }
                }
            }
        }
    }

    protected void Registro_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registro.aspx");
    }

    protected void IB_Buscar_Click(object sender, ImageClickEventArgs e)
    {
        Session["palabra"] = TB_Buscar.Text.ToString();

        if (Session["palabra"].Equals(""))
        {
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Digite palabra clave para buscar');</script>");
        }
        else
        {
            Response.Redirect("BuscarDefault.aspx");
        }
    }
    protected void Usuario_TextChanged(object sender, EventArgs e)
    {

    }
}
