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

public partial class Presentacion_Empresa : System.Web.UI.Page
{
    int _id_user;
    int _id_empresa;

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

        _id_user = int.Parse(Session["id_user"].ToString());
        _id_empresa = int.Parse(Session["id_empresa"].ToString());

        if (!IsPostBack)
        {
            Usuario user = new Usuario();
            GV_Datos.DataSource = user.obtenerEmpresa(_id_empresa);
            GV_Datos.DataBind();
            DV_FotoPerfil.DataSource = user.obtenerEmpresa(_id_empresa);
            DV_FotoPerfil.DataBind();
            GV_Productos.DataSource = user.obtenerProductos(_id_empresa);
            GV_Productos.DataBind();
        }
        
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

        if (!(string.Compare(extension, ".jpg", true) == 0 || string.Compare(extension, ".jpeg", true) == 0 || string.Compare(extension, ".gif", true) == 0 || string.Compare(extension, ".jpe", true) == 0))
        {
            cm.RegisterClientScriptBlock(this.GetType(), "", "<script type='text/javascript'>alert('Solo se admiten Imagenes');</script>");
            return;
        }

        int tamano = b.PostedFile.ContentLength;
        if (b.PostedFile.ContentLength > (1024 * 1024 * 4))
        {
            double tamanoMb = (double)((double)tamano / ((double)1024 * 1024));
            cm.RegisterClientScriptBlock(this.GetType(), "", string.Format("<script type='text/javascript'>alert('No se pueden agregar archivos adjuntos de más de 4 Megabytes. Tamaño del archivo: {0:F1}MB');</script>", tamanoMb));
            return;
        }

        string saveLocation = Server.MapPath("~\\Imagenes\\Empresas") + "\\" + nombreArchivo;

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
        FileUpload a = (FileUpload)DV_FotoPerfil.Rows[e.RowIndex].FindControl("FileUpload1");
        user.Url = "~\\Imagenes\\Empresas\\" + nombreArchivo;
        user.Id_user = _id_user;

        Usuario userDatos = new Usuario();
        userDatos.modificarImgEmpresa(user);


        DV_FotoPerfil.EditIndex = -1;

        Usuario userD = new Usuario();
        DV_FotoPerfil.DataSource = userD.obtenerEmpresa(_id_user);
        DV_FotoPerfil.DataBind();

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Los Datos se han actualizado!');window.location=\"Empresa.aspx\"</script>");
    }
    protected void DV_FotoPerfil_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        DV_FotoPerfil.EditIndex = -1;
        Usuario user = new Usuario();
        DV_FotoPerfil.DataSource = user.obtenerEmpresa(_id_user);
        DV_FotoPerfil.DataBind();
    }
    protected void DV_FotoPerfil_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DV_FotoPerfil.EditIndex = e.NewEditIndex;
        Usuario user = new Usuario();
        DV_FotoPerfil.DataSource = user.obtenerEmpresa(_id_user);
        DV_FotoPerfil.DataBind();
    }

    protected void GV_Datos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV_Datos.EditIndex = -1;
        Usuario user = new Usuario();
        GV_Datos.DataSource = user.obtenerEmpresa(_id_user);
        GV_Datos.DataBind();
    }
    protected void GV_Datos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GV_Datos.EditIndex = e.NewEditIndex;
        Usuario user = new Usuario();
        user.obtenerEmpresa(_id_empresa);
        GV_Datos.DataSource = user.obtenerEmpresa(_id_empresa);
        GV_Datos.DataBind();
    }
    protected void GV_Datos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DatosUsuario datos = new DatosUsuario();
        //id_empresa

        TextBox dir = (TextBox)GV_Datos.Rows[e.RowIndex].FindControl("TB_Direccion");
        datos.Direccion = ((TextBox)dir.FindControl("TB_Direccion")).Text;

        TextBox tel = (TextBox)GV_Datos.Rows[e.RowIndex].FindControl("TB_Telefono");
        datos.Telefono = ((TextBox)tel.FindControl("TB_Telefono")).Text;

        TextBox uss = (TextBox)GV_Datos.Rows[e.RowIndex].FindControl("TB_Descripcion");
        datos.Descrip = ((TextBox)uss.FindControl("TB_Descripcion")).Text;

        datos.Id_user = _id_user;

        Usuario user = new Usuario();
        user.modificarEmpresa(datos);

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Los Datos se han actualizado!');window.location=\"Empresa.aspx\"</script>");
    
    }
   
    protected void GV_Productos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DatosUsuario datos = new DatosUsuario();

        Label id_p = (Label)GV_Productos.Rows[e.RowIndex].FindControl("L_Id");
        string valor3 = ((Label)id_p.FindControl("L_Id")).Text;
        datos.Id_producto = int.Parse(valor3);

        TextBox producto = (TextBox)GV_Productos.Rows[e.RowIndex].FindControl("TB_Producto");
        datos.Producto = ((TextBox)producto.FindControl("TB_Producto")).Text;

        TextBox descripcion = (TextBox)GV_Productos.Rows[e.RowIndex].FindControl("TB_Descripcion");
        datos.Descripcion = ((TextBox)descripcion.FindControl("TB_Descripcion")).Text;

        datos.Categoria = ((DropDownList)GV_Productos.Rows[e.RowIndex].FindControl("DL_Cat")).SelectedItem.ToString();

        TextBox p_a = (TextBox)GV_Productos.Rows[e.RowIndex].FindControl("TB_PA");
        string valor1 = ((TextBox)p_a.FindControl("TB_PA")).Text;
        datos.Precio_a = int.Parse(valor1);

        TextBox p_p = (TextBox)GV_Productos.Rows[e.RowIndex].FindControl("TB_PP");
        string valor2 = ((TextBox)p_p.FindControl("TB_PP")).Text;
        datos.Precio_p = int.Parse(valor2);

        TextBox f_i = (TextBox)GV_Productos.Rows[e.RowIndex].FindControl("TB_FI");
        datos.Fecha_i = ((TextBox)f_i.FindControl("TB_FI")).Text;

        TextBox f_f = (TextBox)GV_Productos.Rows[e.RowIndex].FindControl("TB_FF");
        datos.Fecha_f = ((TextBox)f_f.FindControl("TB_FF")).Text;

        datos.Id_user = _id_user;

        Usuario user = new Usuario();
        user.modificarProducto(datos);

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Los datos del producto se han actualizado!');window.location=\"Empresa.aspx\"</script>");
    
    }
    protected void GV_Productos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GV_Productos.EditIndex = e.NewEditIndex;
        Usuario user = new Usuario();
        GV_Productos.DataSource = user.obtenerProductos(_id_empresa);
        GV_Productos.DataBind();
    }
    protected void GV_Productos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    { 
        GV_Productos.EditIndex = -1;
        Usuario user = new Usuario();
        GV_Productos.DataSource = user.obtenerProductos(_id_empresa);
        GV_Productos.DataBind();
    }
    protected void GV_Productos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label producto = (Label)GV_Productos.Rows[e.RowIndex].FindControl("L_Id");
        int id_producto = int.Parse(((Label)producto.FindControl("L_Id")).Text);
        
        Usuario user = new Usuario();
        user.eliminarProducto(id_producto);


        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El producto se ha eliminado!');window.location=\"Empresa.aspx\"</script>");
    
    }
    }
