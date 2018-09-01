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

public partial class Presentacion_PerfilEmpresa : System.Web.UI.Page
{
    int _id_user, _id_empresa;

    protected void Page_Load(object sender, EventArgs e)
    {
        _id_user = int.Parse(Session["id_user"].ToString());
        _id_empresa = int.Parse(Session["id_empresa"].ToString());

        if (Session["id_rol"].Equals("null"))
        {
            Response.Redirect("index.aspx");
        }
      /*  if (Session["verificar"].Equals("Verificada") && !Session["estado"].Equals("Normal"))
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
        }*/
        Usuario obtener = new Usuario();
        obtener.obtenerEmpresa(_id_empresa);

        GV_Empresa.DataSource = obtener.obtenerEmpresa(_id_empresa);
        GV_Empresa.DataBind();

        obtener.obtenerProductos(_id_empresa);

        GV_Productos.DataSource = obtener.obtenerProductos(_id_empresa);
        GV_Productos.DataBind();

        Usuario datos = new Usuario();
        DataTable informacion = datos.obtenerFactura(_id_empresa);

        if (informacion.Rows.Count == 0)
        {
            datos.crearFactura(_id_empresa);

            informacion = datos.obtenerFactura(_id_empresa);
            Session["id_factura"] = informacion.Rows[0]["id_factura"].ToString();
        }
        else
        {
            Session["id_factura"] = informacion.Rows[0]["id_factura"].ToString();

        }
       
    }

    protected void Suscribirse_Click(object sender, EventArgs e) {
        Response.Redirect("Perfil.aspx");
    }

    protected void GV_Empresa_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DatosUsuario datos = new DatosUsuario();

        Label Id_Emp = (Label)GV_Empresa.Rows[e.RowIndex].FindControl("L_IdEmpresa");
        string idemp = ((Label)Id_Emp.FindControl("L_IdEmpresa")).Text;
        datos.Id_empresa = int.Parse(idemp);

        datos.Id_producto = 0;

        datos.Id_user = _id_user;

        Usuario user = new Usuario();
        user.seguirEmpPro(datos);


        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Siguiendo!');</script>");
    }
    protected void GV_Empresa_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GV_Empresa.EditIndex = e.NewEditIndex;
        Usuario obtener = new Usuario();
        obtener.obtenerEmpresa(_id_empresa);

        GV_Empresa.DataSource = obtener.obtenerEmpresa(_id_empresa);
        GV_Empresa.DataBind();
    }
    protected void GV_Empresa_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV_Empresa.EditIndex = -1;
        Usuario obtener = new Usuario();
        obtener.obtenerEmpresa(_id_empresa);

        GV_Empresa.DataSource = obtener.obtenerEmpresa(_id_empresa);
        GV_Empresa.DataBind();
    }


    protected void GV_Productos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Usuario datos = new Usuario();
        DataTable informacion = datos.obtenerFactura(_id_user);

        if (informacion.Rows.Count == 0)
        {
            datos.crearFactura(_id_user);

            informacion = datos.obtenerFactura(_id_user);
            Session["id_factura"] = informacion.Rows[0]["id_factura"].ToString();
        }
            else
            {
                Session["id_factura"] = informacion.Rows[0]["id_factura"].ToString();
                
            }

        DatosUsuario user = new DatosUsuario();
        user.Id_factura = int.Parse(Session["id_factura"].ToString());
        
        Label Id_Pro = (Label)GV_Productos.Rows[e.RowIndex].FindControl("L_IdPro");
        user.Id_producto = int.Parse(((Label)Id_Pro.FindControl("L_IdPro")).Text);

        user.Cantidad = int.Parse(((DropDownList)GV_Productos.Rows[e.RowIndex].FindControl("DDL_Cant")).SelectedItem.ToString());
        
        Label L_Precio2 = (Label)GV_Productos.Rows[e.RowIndex].FindControl("L_Precio2");
        user.Precio_p = int.Parse(((Label)Id_Pro.FindControl("L_Precio2")).Text);

        Usuario enviar = new Usuario();
        enviar.insertarCompra(user);


        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Agregado al Carrito!');</script>");
    }
    protected void GV_Productos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GV_Productos.EditIndex = e.NewEditIndex;
        Usuario obtener = new Usuario();
        obtener.obtenerProductos(_id_empresa);

        GV_Productos.DataSource = obtener.obtenerProductos(_id_empresa);
        GV_Productos.DataBind();
    }
    protected void GV_Productos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV_Productos.EditIndex = -1;
        Usuario obtener = new Usuario();
        obtener.obtenerProductos(_id_empresa);

        GV_Productos.DataSource = obtener.obtenerProductos(_id_empresa);
        GV_Productos.DataBind();
    }
    protected void GV_Productos_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
