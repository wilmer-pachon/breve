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

public partial class Presentacion_Notificacion : System.Web.UI.Page
{
    int _id_user;
    string ruta;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_rol"].Equals("null") || !Session["id_rol"].Equals("1") || Session["id_user"].Equals("null"))
            Response.Redirect("index.aspx");

        _id_user = int.Parse(Session["id_user"].ToString());
    }
    protected void B_Notificar_Click(object sender, EventArgs e)
    {
            DatosUsuario user = new DatosUsuario();
            user.Nombre = TB_NomreImg.Text.ToString();
            user.Url = Session["url1"].ToString();
            string valor = DDL_Usuarios.SelectedValue.ToString();
            if (valor.Equals("Seleccione..."))
            {

                this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Eliga un Usuario!')</script>");

            }
            
            user.Id_user = int.Parse(valor);
            
            user.Notificacion = TB_Notificar.Text.ToString();

            Usuario userDatos = new Usuario();
            userDatos.notificarUsuarioAuto(user);
            
            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Se ha notificado al usuario!');window.location=\"Menuadmin.aspx\"</script>");

    }
    protected void B_Agregar_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        DataTable fotos;

        if (Session["noti"] == null)
        {
            fotos = new DataTable();
            fotos.Columns.Add("ruta");
            Session["noti"] = fotos;
        }

        fotos = (DataTable)Session["noti"];

        if (fotos.Rows.Count == 1)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No se pueden agregar mas imagenes');</script>");
            return;
        }

        string nombreArchivo = System.IO.Path.GetFileName(FU_Logo.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FU_Logo.PostedFile.FileName);

        if (!(string.Compare(extension, ".bmp", true) == 0 || string.Compare(extension, ".png", true) == 0 || string.Compare(extension, ".jpg", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".gif", true) == 0 || string.Compare(extension, ".jpe", true) == 0))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo se admiten imagenes en formato Png, Jpeg o Gif');</script>");
            return;

        }

        int tamano = FU_Logo.PostedFile.ContentLength;
        if (tamano > (1024 * 1024))
        {
            double tamanoMb = (double)((double)tamano / ((double)1024 * 1024));
            cm.RegisterClientScriptBlock(this.GetType(), "", string.Format("<script type='text/javascript'>alert('Solo se admiten imagenes con un tamaño menor a 1 Megabyte. Tamaño del archivo: {0:F1}MB');</script>", tamanoMb));
            return;
        }
        string saveLocation = Server.MapPath("~\\Imagenes\\Notificaciones") + "\\" + nombreArchivo;


        if (System.IO.File.Exists(saveLocation))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe una imagen en el servidor con ese nombre');</script>");
            return;
        }

        try
        {
            FU_Logo.PostedFile.SaveAs(saveLocation);
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>");
        }
        catch (Exception exc)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", string.Format("<script type='text/javascript'>alert('Error: {0}');</script>", exc.Message));
            return;
        }

        string[] celdas = new string[1];

        celdas[0] = "~\\Imagenes\\Notificaciones\\" + nombreArchivo;
        Session["url1"] = "~\\Imagenes\\Notificaciones\\" + nombreArchivo;

        fotos.Rows.Add(celdas);

        Session["noti"] = fotos;

        GV_Img.DataSource = fotos;
        GV_Img.DataBind();

    }
    protected void GV_Img_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    
    }
}
