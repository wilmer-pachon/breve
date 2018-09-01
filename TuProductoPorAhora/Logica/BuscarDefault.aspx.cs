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

public partial class Presentacion_BuscarDefault : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            TB_Buscar.Text = Session["palabra"].ToString();

            DatosUsuario datos = new DatosUsuario();
            datos.Nombre = TB_Buscar.Text.ToString();
            
            Usuario user = new Usuario();
            user.busquedaUser(datos);

            GV_BuscarSin.DataSource = user.busquedaUser(datos);
            GV_BuscarSin.DataBind();
        }
        
    }

    protected void IB_Buscar_Click(object sender, ImageClickEventArgs e)
    {

        DatosUsuario datos = new DatosUsuario();
        datos.Nombre = TB_Buscar.Text.ToString();

        Usuario user = new Usuario();
        user.busquedaUser(datos);

        GV_BuscarSin.DataSource = user.busquedaUser(datos);
        GV_BuscarSin.DataBind();
        Session["palabra"] = TB_Buscar.Text.ToString(); 
    }
    protected void Registro_Click(object sender, EventArgs e)
    {
        Response.Redirect("Registro.aspx");
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
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Bienvenido Administrador!');window.location=\"admin.aspx\"</script>");
            }
            else
            {
                if (int.Parse(Session["id_rol"].ToString()) == 2)
                {
                    this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Bienvenido Empresa');window.location=\"Perfil.aspx\"</script>");
                }
                else
                {
                    if (int.Parse(Session["id_rol"].ToString()) == 3)
                    {
                        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Bienvenido Usuario');window.location=\"Perfil.aspx\"</script>");
                    }
                }
            }
        }
    }
    protected void LB_Producto_Click(object sender, EventArgs e)
    {
        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Registrate y podrás ver más información de este producto y otros productos!');window.location=\"Registro.aspx\"</script>");
                    
    }
}
