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

public partial class Presentacion_Productos : System.Web.UI.Page
{
    string ruta;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_rol"].Equals("null"))
        {
            Response.Redirect("index.aspx");
        }
        
        if (Session["verificar"].Equals("Verificada") && !Session["estado"].Equals("Normal"))
        {
            Response.Redirect("Configuracion.aspx");
        }
        if (!Session["verificar"].Equals("Verificada") && Session["estado"].Equals("Gratis"))
        {
            Response.Redirect("Configuracion.aspx");
        }
        if (Session["verificar"].Equals("null") && !Session["estado"].Equals("null"))
        {
            Response.Redirect("Configuracion.aspx");
        }
//        TB_Fecha_i.Text = C_Inicio.SelectedDate.Date.ToString();
  //      TB_Fecha_f.Text = C_Fin.SelectedDate.ToString();
    }
    protected void B_Guardar_Click(object sender, EventArgs e)
    {
        DatosUsuario datos = new DatosUsuario();
        datos.Producto = TB_Nombre.Text.ToString();
        datos.Precio_a = int.Parse(TB_PA.Text.ToString());
        datos.Precio_p = int.Parse(TB_PP.Text.ToString());
        datos.Fecha_i = TB_Fecha_i.Text.ToString();
        datos.Fecha_f = TB_Fecha_f.Text.ToString();
        datos.Descripcion = TB_Descripcion.Text.ToString();
        datos.Url = Session["ruta_p"].ToString();
        datos.Categoria = DL_Cat.SelectedItem.Text.ToString();

        Usuario user = new Usuario();
        user.crearProducto(datos);

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Tu Producto se ha registrado!');window.location=\"PerfilEmpresa.aspx\"</script>");

    }
    protected void B_AgregarImg_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        DataTable fotos;

        if (Session["fotos"] == null)
        {
            fotos = new DataTable();
            fotos.Columns.Add("ruta");
            Session["fotos"] = fotos;
        }

        fotos = (DataTable)Session["fotos"];

        if (fotos.Rows.Count == 1)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No se pueden agregar mas imagenes');</script>");
            return;
        }

        string nombreArchivo = System.IO.Path.GetFileName(FU_Logo.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FU_Logo.PostedFile.FileName);

        if (!(string.Compare(extension, ".jpg", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".gif", true) == 0 || string.Compare(extension, ".jpe", true) == 0))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o Gif');</script>");
            return;

        }

        int tamano = FU_Logo.PostedFile.ContentLength;
        if (tamano > (1024 * 1024))
        {
            double tamanoMb = (double)((double)tamano / ((double)1024 * 1024));
            cm.RegisterClientScriptBlock(this.GetType(), "", string.Format("<script type='text/javascript'>alert('Solo se admiten imagenes con un tamaño menor a 1 Megabyte. Tamaño del archivo: {0:F1}MB');</script>", tamanoMb));
            return;
        }
        string saveLocation = Server.MapPath("~\\Imagenes\\Productos") + "\\" + nombreArchivo;


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

        celdas[0] = "~\\Imagenes\\Productos\\" + nombreArchivo;
        Session["ruta_p"] = "~\\Imagenes\\Productos\\" + nombreArchivo;

        fotos.Rows.Add(celdas);

        Session["fotos"] = fotos;

        DV_ImgProducto.DataSource = fotos;
        DV_ImgProducto.DataBind();

       // DatosUsuario user = new DatosUsuario();
        //user.Url = celdas[0].ToString();

        // Usuario userDatos = new Usuario();
        // userDatos.guardarImagen(user);
    }



    protected void TB_Fecha_i_TextChanged(object sender, EventArgs e)
    {

    }
    protected void TB_Fecha_f_TextChanged(object sender, EventArgs e)
    {

    }
}
