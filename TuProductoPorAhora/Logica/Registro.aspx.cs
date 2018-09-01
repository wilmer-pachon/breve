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

public partial class Presentacion_Registro : System.Web.UI.Page
{
    int estado = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (!Session["id_rol"].Equals("null")) {
            Response.Redirect("perfil.aspx");
        }
    }

    protected void B_Guardar_Click(object sender, EventArgs e)
    {
        DatosUsuario user = new DatosUsuario();
        user.Nombre = TB_Nombre.Text.ToString();
        user.Apellido = TB_Apellido.Text.ToString();
        user.Usuario = TB_Usuario.Text.ToString();
        user.Correo = TB_Correo.Text.ToString();
        user.Contra = TB_Contra.Text.ToString();
        user.Dia = DL_Dia.SelectedItem.ToString();
        user.Mes = DL_Mes.SelectedItem.ToString();
        user.Ano = DL_Ano.SelectedItem.ToString();
        user.Sexo = DL_Sexo.Text.ToString();
        user.Ciudad = DL_Ciudad.Text.ToString();

        if (Session["estado_v"].Equals("1"))
        {
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Verifique su usuario.');</script>");
        }
        else
        {
            if (DL_Dia.SelectedItem.ToString().Equals("Día") || DL_Ano.SelectedItem.ToString().Equals("Año") || DL_Mes.SelectedItem.ToString().Equals("Mes"))
            {
                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Olvidaste tu fecha de nacimiento.');</script>");
            }
            else
            {
                if (int.Parse(DL_Ano.SelectedItem.ToString()) > 1996)
                {
                    this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('No eres mayor de edad.');</script>");
                }
                else
                {
                    if (DL_Sexo.SelectedItem.ToString().Equals("Seleccionar..."))
                    {
                        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Seleccione su sexo.');</script>");
                    }
                    else
                    {
                        if (DL_Ciudad.SelectedItem.ToString().Equals("Donde vives..."))
                        {
                            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Seleccione donde vive.');</script>");
                        }
                        else
                        {
                            Usuario userDatos = new Usuario();
                            userDatos.crearUsuario(user);
                        }
                    }
                }
            }
        }


        Usuario datos = new Usuario();
        DataTable informacion = datos.loginUsuario(user.Usuario, user.Contra);

        if (informacion.Rows.Count == 0)
        {
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Usuario o contraseña invalido');window.location=\"Index.aspx\"</script>");
        }
        else
        {
            Session["id_rol"] = informacion.Rows[0]["id_rol"].ToString();
            Session["id_user"] = informacion.Rows[0]["id_user"].ToString();
            Session["usuario"] = informacion.Rows[0]["nombre"].ToString();
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

    protected void I_Verificar_Click(object sender, ImageClickEventArgs e)
    {
         Usuario datos = new Usuario();
        DataTable informacion = datos.verificarUser(TB_Usuario.Text.ToString());

        if (informacion.Rows.Count == 0)
        {
            Session["estado_v"] = "2";
            L_Verificar.Text = "Disponible";
            I_Verificar.ImageUrl = "~\\Imagenes\\Breve\\verificado.png";
            
        }
        else
        {
            Session["estado_v"] = "1";
            L_Verificar.Text = "No Disponible";
            I_Verificar.ImageUrl = "~\\Imagenes\\Breve\\nodisponible.png";
            
        }
    }
}
