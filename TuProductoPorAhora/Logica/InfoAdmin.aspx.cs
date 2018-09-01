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

public partial class Presentacion_InfoAdmin : System.Web.UI.Page
{

    int _id_user;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_rol"].Equals("null") || !Session["id_rol"].Equals("1") || Session["id_user"].Equals("null"))
        {
            Response.Redirect("index.aspx");
        }
        Usuario userDatos = new Usuario();
        _id_user = int.Parse(Session["id_user"].ToString());
        userDatos.obtenerDatosEdit(_id_user);

        if (!IsPostBack)
        {
            Usuario obtener = new Usuario();
            obtener.obtenerDatosEdit(_id_user);

            DV_FotoPerfil.DataSource = obtener.obtenerDatosEdit(_id_user);
            DV_FotoPerfil.DataBind();

            GV_Datos.DataSource = obtener.obtenerDatosEdit(_id_user);
            GV_Datos.DataBind();
        }
        
        Usuario datos = new Usuario();
        DataTable informacion = datos.datosEmpresa(_id_user);

        
    }
    protected void DV_FotoPerfil_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DV_FotoPerfil.EditIndex = e.NewEditIndex;
        Usuario asp = new Usuario();
        asp.obtenerDatosEdit(_id_user);
        DV_FotoPerfil.DataSource = asp.obtenerDatosEdit(_id_user);
        DV_FotoPerfil.DataBind();
        
    }
    protected void DV_FotoPerfil_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;

        DataTable foto;

        FileUpload b = (FileUpload)DV_FotoPerfil.Rows[e.RowIndex].FindControl("FileUpload1");

        if (Session["foto"] == null)
        {
            foto = new DataTable();
            foto.Columns.Add("ruta");
            Session["foto"] = foto;
        }

        foto = (DataTable)Session["foto"];

        if (foto.Rows.Count == 1)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No se pueden agregar más fotos');</script>");
            return;
        }

        string nombreArchivo = System.IO.Path.GetFileName(b.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(b.PostedFile.FileName);

        if (!(string.Compare(extension, ".bmp", true) == 0 || string.Compare(extension, ".png", true) == 0 || string.Compare(extension, ".jpg", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".gif", true) == 0 || string.Compare(extension, ".jpe", true) == 0))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo se admiten Imagenes en formato .png .gif .jpg .jpeg .bmp');</script>");
            return;
        }

        int tamano = b.PostedFile.ContentLength;
        if (b.PostedFile.ContentLength > (1024 * 1024 * 4))
        {
            double tamanoMb = (double)((double)tamano / ((double)1024 * 1024));
            cm.RegisterClientScriptBlock(this.GetType(), "", string.Format("<script type='text/javascript'>alert('No se pueden agregar archivos adjuntos de más de 4 Megabytes. Tamaño del archivo: {0:F1}MB');</script>", tamanoMb));
            return;
        }

        string saveLocation = Server.MapPath("~\\Imagenes") + "\\Usuarios" + nombreArchivo;

        if (System.IO.File.Exists(saveLocation))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe un archivo adjunto en el servidor con ese nombre');</script>");
            return;
        }

        try
        {
            b.PostedFile.SaveAs(saveLocation);
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo adjunto ha sido cargado');</script>");
        }
        catch (Exception exc)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", string.Format("<script type='text/javascript'>alert('Error: {0}');</script>", exc.Message));
            return;
        }

        DatosUsuario user = new DatosUsuario();
       // user.Url = DV_FotoPerfil.DataKeys[e.RowIndex].Value.ToString();
       // user.Nombre = DV_FotoPerfil.DataKeys[e.RowIndex].Value.ToString();
        FileUpload a = (FileUpload)DV_FotoPerfil.Rows[e.RowIndex].FindControl("FileUpload1");
        user.Url = "~\\Imagenes\\Usuarios" + nombreArchivo;
        user.Id_user = int.Parse(_id_user.ToString());

        Usuario userDatos = new Usuario();
        userDatos.modificarImgPerfil(user);

        DV_FotoPerfil.EditIndex = -1;

        Usuario asp = new Usuario();
        asp.obtenerDatosEdit(_id_user);
        DV_FotoPerfil.DataSource = asp.obtenerDatosEdit(_id_user);
        DV_FotoPerfil.DataBind();

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Los Datos se han actualizado!');window.location=\"Infoadmin.aspx\"</script>");

    }
    protected void GV_Datos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GV_Datos.EditIndex = e.NewEditIndex;
        Usuario asp = new Usuario();
        asp.obtenerDatosEdit(_id_user);
        GV_Datos.DataSource = asp.obtenerDatosEdit(_id_user);
        GV_Datos.DataBind();
    }
    protected void GV_Datos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        DatosUsuario datos = new DatosUsuario();

        TextBox nombre = (TextBox)GV_Datos.Rows[e.RowIndex].FindControl("TextBox1");
        datos.Nombre = ((TextBox)nombre.FindControl("TextBox1")).Text;

        TextBox apellido = (TextBox)GV_Datos.Rows[e.RowIndex].FindControl("TextBox2");
        datos.Apellido = ((TextBox)apellido.FindControl("TextBox2")).Text;

        TextBox usuario = (TextBox)GV_Datos.Rows[e.RowIndex].FindControl("TextBox3");
        datos.Usuario = ((TextBox)usuario.FindControl("TextBox3")).Text;

        TextBox correo = (TextBox)GV_Datos.Rows[e.RowIndex].FindControl("TextBox4");
        datos.Correo = ((TextBox)correo.FindControl("TextBox4")).Text;

        TextBox contra = (TextBox)GV_Datos.Rows[e.RowIndex].FindControl("TextBox5");
        datos.Contra = ((TextBox)contra.FindControl("TextBox5")).Text;

        TextBox dia = (TextBox)GV_Datos.Rows[e.RowIndex].FindControl("TextBox6");
        datos.Dia = ((TextBox)dia.FindControl("TextBox6")).Text;

        datos.Sexo = ((DropDownList)GV_Datos.Rows[e.RowIndex].FindControl("DL_Sexo")).SelectedItem.ToString();

        datos.Ciudad = ((DropDownList)GV_Datos.Rows[e.RowIndex].FindControl("DL_Ciudad")).SelectedItem.ToString();

        datos.Id_user = _id_user;

        Usuario user = new Usuario();
        user.modificarUser(datos);

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Los Datos se han actualizado!');window.location=\"InfoAdmin.aspx\"</script>");
    }
    protected void GV_Datos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV_Datos.EditIndex = -1;
        Usuario asp = new Usuario();
        asp.obtenerDatosEdit(_id_user);
        GV_Datos.DataSource = asp.obtenerDatosEdit(_id_user);
        GV_Datos.DataBind();
    }
    protected void DV_FotoPerfil_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        DV_FotoPerfil.EditIndex = -1;
        Usuario asp = new Usuario();
        asp.obtenerDatosEdit(_id_user);
        DV_FotoPerfil.DataSource = asp.obtenerDatosEdit(_id_user);
        DV_FotoPerfil.DataBind();
    }
}
