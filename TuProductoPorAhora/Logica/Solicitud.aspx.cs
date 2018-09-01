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

public partial class Presentacion_Solicitud : System.Web.UI.Page
{
    int _id_user;
    String ruta1, ruta2;
    string ruta3;

    protected void Page_Load(object sender, EventArgs e)
    {
        _id_user = int.Parse(Session["id_user"].ToString());

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
        if (!Session["verificar"].Equals("Verificada") && Session["estado"].Equals("Rechazada"))
        {
            Response.Redirect("Configuracion.aspx");
        }
        if (!IsPostBack)
        {
            Usuario obtener = new Usuario();
            obtener.obtenerImgSolicitud("LOGO", _id_user);
            GV_Logo.DataSource = obtener.obtenerImgSolicitud("LOGO", _id_user);
            GV_Logo.DataBind();

            obtener.obtenerImgSolicitud("RUT", _id_user);
            GV_Rut.DataSource = obtener.obtenerImgSolicitud("RUT", _id_user);
            GV_Rut.DataBind();

            obtener.obtenerImgSolicitud("CC", _id_user);
            GV_CC.DataSource = obtener.obtenerImgSolicitud("CC", _id_user);
            GV_CC.DataBind();
        }
        
    }
    protected void B_Guardar_Click(object sender, EventArgs e)
    {
        DatosUsuario datos = new DatosUsuario();
        datos.Empresa = TB_Nombre.Text.ToString();
        datos.Nit = TB_Nit.Text.ToString();
        datos.Direccion = TB_Direccion.Text.ToString();
        datos.Telefono = TB_Telefono.Text.ToString();
        datos.Descrip = TB_Descripcion.Text.ToString();
        datos.Logo_emp = Session["fotos_ruta1"].ToString();
        datos.Rut = Session["fotos_ruta1"].ToString();
        datos.C_c = Session["fotos_ruta1"].ToString();
        datos.Id_user = _id_user;

        Usuario user = new Usuario();
        user.crearEmpresa(datos);
        user.borrarImgSolicitud(_id_user);

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Tus datos se han registrado!');window.location=\"Perfil.aspx\"</script>");

    }
    protected void B_Logo_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        DataTable fotos;

        if (Session["fotos"] == null)
        {
            fotos = new DataTable();
            fotos.Columns.Add("ruta1");
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

        if (!(string.Compare(extension, ".png", true) == 0 || string.Compare(extension, ".jpg", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".gif", true) == 0 || string.Compare(extension, ".jpe", true) == 0))
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
        string saveLocation = Server.MapPath("~\\Imagenes\\Empresas") + "\\" + nombreArchivo;


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

        celdas[0] = "~\\Imagenes\\Empresas\\" + nombreArchivo;
        Session["fotos_ruta1"] = "~\\Imagenes\\Empresas\\" + nombreArchivo;
        fotos.Rows.Add(celdas);
        Session["fotos"] = fotos;

        DatosUsuario datos = new DatosUsuario();
        datos.Nombre = "LOGO";
        datos.Url = celdas[0].ToString();
        datos.Id_user = _id_user;

        Usuario obtener = new Usuario();
        obtener.InsertarImgSolicitud(datos);

        GV_Logo.DataSource = obtener.obtenerImgSolicitud("LOGO", _id_user);
        GV_Logo.DataBind();
    }
    protected void B_Rut_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        DataTable fotos2;

        if (Session["fotos2"] == null)
        {
            fotos2 = new DataTable();
            fotos2.Columns.Add("ruta2");
            Session["fotos2"] = fotos2;
        }

        fotos2 = (DataTable)Session["fotos2"];

        if (fotos2.Rows.Count == 2)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No se pueden agregar mas imagenes');</script>");
            return;
        }

        string nombreArchivo = System.IO.Path.GetFileName(FU_Rut.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FU_Rut.PostedFile.FileName);

        if (!(string.Compare(extension, ".png", true) == 0 || string.Compare(extension, ".jpg", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".gif", true) == 0 || string.Compare(extension, ".jpe", true) == 0))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o Gif');</script>");
            return;

        }

        int tamano = FU_Rut.PostedFile.ContentLength;
        if (tamano > (1024 * 1024))
        {
            double tamanoMb = (double)((double)tamano / ((double)1024 * 1024));
            cm.RegisterClientScriptBlock(this.GetType(), "", string.Format("<script type='text/javascript'>alert('Solo se admiten imagenes con un tamaño menor a 1 Megabyte. Tamaño del archivo: {0:F1}MB');</script>", tamanoMb));
            return;
        }
        string saveLocation = Server.MapPath("~\\Imagenes\\Empresas") + "\\" + nombreArchivo;


        if (System.IO.File.Exists(saveLocation))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe una imagen en el servidor con ese nombre');</script>");
            return;
        }

        try
        {
            FU_Rut.PostedFile.SaveAs(saveLocation);
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>");
        }
        catch (Exception exc)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", string.Format("<script type='text/javascript'>alert('Error: {0}');</script>", exc.Message));
            return;
        }

        string[] celdas = new string[1];

        celdas[0] = "~\\Imagenes\\Empresas\\" + nombreArchivo;
        Session["fotos_ruta2"] = "~\\Imagenes\\Empresas\\" + nombreArchivo;
        fotos2.Rows.Add(celdas);
        Session["fotos2"] = fotos2;

        DatosUsuario datos = new DatosUsuario();
        datos.Nombre = "RUT";
        datos.Url = celdas[0].ToString();
        datos.Id_user = _id_user;

        Usuario obtener = new Usuario();
        obtener.InsertarImgSolicitud(datos);

        GV_Rut.DataSource = obtener.obtenerImgSolicitud("RUT", _id_user);
        GV_Rut.DataBind();


    }
    protected void B_CC_Click(object sender, EventArgs e)
    {
        ClientScriptManager cm = this.ClientScript;
        DataTable fotos3;

        if (Session["fotos3"] == null)
        {
            fotos3 = new DataTable();
            fotos3.Columns.Add("ruta3");
            Session["fotos3"] = fotos3;
        }

        fotos3 = (DataTable)Session["fotos3"];

        if (fotos3.Rows.Count == 1)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('No se pueden agregar mas imagenes');</script>");
            return;
        }

        string nombreArchivo = System.IO.Path.GetFileName(FU_CC.PostedFile.FileName);
        string extension = System.IO.Path.GetExtension(FU_CC.PostedFile.FileName);

        if (!(string.Compare(extension, ".png", true) == 0 || string.Compare(extension, ".jpg", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".gif", true) == 0 || string.Compare(extension, ".jpe", true) == 0))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo se admiten imagenes en formato Jpeg o Gif');</script>");
            return;

        }

        int tamano = FU_CC.PostedFile.ContentLength;
        if (tamano > (1024 * 1024))
        {
            double tamanoMb = (double)((double)tamano / ((double)1024 * 1024));
            cm.RegisterClientScriptBlock(this.GetType(), "", string.Format("<script type='text/javascript'>alert('Solo se admiten imagenes con un tamaño menor a 1 Megabyte. Tamaño del archivo: {0:F1}MB');</script>", tamanoMb));
            return;
        }
        string saveLocation = Server.MapPath("~\\Imagenes\\Empresas") + "\\" + nombreArchivo;


        if (System.IO.File.Exists(saveLocation))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Ya existe una imagen en el servidor con ese nombre');</script>");
            return;
        }

        try
        {
            FU_CC.PostedFile.SaveAs(saveLocation);
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('El archivo de imagen ha sido cargado');</script>");
        }
        catch (Exception exc)
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", string.Format("<script type='text/javascript'>alert('Error: {0}');</script>", exc.Message));
            return;
        }

        string[] celdas = new string[1];

        celdas[0] = "~\\Imagenes\\Empresas\\" + nombreArchivo;
        Session["fotos_ruta3"] = "~\\Imagenes\\Empresas\\" + nombreArchivo;
        fotos3.Rows.Add(celdas);
        Session["fotos3"] = fotos3;

        DatosUsuario datos = new DatosUsuario();
        datos.Nombre = "CC";
        datos.Url = celdas[0].ToString();
        datos.Id_user = _id_user;

        Usuario obtener = new Usuario();
        obtener.InsertarImgSolicitud(datos);

        GV_CC.DataSource = obtener.obtenerImgSolicitud("CC", _id_user);
        GV_CC.DataBind();

    }
}
