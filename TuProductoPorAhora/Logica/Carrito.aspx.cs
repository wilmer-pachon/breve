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

public partial class Presentacion_Carrito : System.Web.UI.Page
{
    int _id_user;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_rol"].Equals("null"))
            Response.Redirect("index.aspx");

        _id_user = int.Parse(Session["id_user"].ToString());

        Usuario obtener = new Usuario();
        obtener.obtenerCompra(_id_user);
        GV_Compras.DataSource = obtener.obtenerCompra(_id_user);
        GV_Compras.DataBind();
        GV_Total.DataSource = obtener.obtenerTotalCompra(_id_user);
        GV_Total.DataBind();
    }
    protected void GV_Compras_RowUpdating(object sender, GridViewUpdateEventArgs e)
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

        Label valor1 = (Label)GV_Compras.Rows[e.RowIndex].FindControl("L_CantDispo");
        string cd = ((Label)valor1.FindControl("L_CantDispo")).Text;
        int C_D = int.Parse(cd);

        TextBox can = (TextBox)GV_Compras.Rows[e.RowIndex].FindControl("TB_Cant");
        string ca = ((TextBox)can.FindControl("TB_Cant")).Text;
        int C_A = int.Parse(ca);

        if (C_A > C_D || C_A <= 0)
        {

            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('La Cantidad a comprar no esta disponible!');</script>");

        }
        else
        {

            user.Id_factura = int.Parse(Session["id_factura"].ToString());

            Label Id_Pro = (Label)GV_Compras.Rows[e.RowIndex].FindControl("L_IdPro");
            string valor2 = ((Label)Id_Pro.FindControl("L_IdPro")).Text;
            user.Id_producto = int.Parse(valor2);

            user.Cantidad = C_A;

            Label L_Precio2 = (Label)GV_Compras.Rows[e.RowIndex].FindControl("L_Precio");
            string valor3 = ((Label)L_Precio2.FindControl("L_Precio")).Text;
            user.Precio_p = int.Parse(valor3);

            Usuario enviar = new Usuario();
            enviar.modificarCompra(user);

            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Actualizando Compra!');</script>");
    
        }

    }
    protected void GV_Compras_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GV_Compras.EditIndex = e.NewEditIndex;
        Usuario obtener = new Usuario();
        obtener.obtenerCompra(_id_user);

        GV_Compras.DataSource = obtener.obtenerCompra(_id_user);
        GV_Compras.DataBind();
    }
    protected void GV_Compras_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DatosUsuario datos = new DatosUsuario();

        datos.Id_factura = int.Parse(Session["id_factura"].ToString());

        Label Id_Pro = (Label)GV_Compras.Rows[e.RowIndex].FindControl("L_IdPro");
        datos.Id_producto = int.Parse(((Label)Id_Pro.FindControl("L_IdPro")).Text);

        datos.Id_user = _id_user;

        Usuario user = new Usuario();
        user.eliminarProCom(datos);

        GV_Compras.DataSource = user.obtenerCompra(_id_user);
        GV_Compras.DataBind();

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Producto Eliminado!');</script>");
    
    }
    protected void GV_Compras_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV_Compras.EditIndex = -1;
        Usuario obtener = new Usuario();
        obtener.obtenerCompra(_id_user);

        GV_Compras.DataSource = obtener.obtenerCompra(_id_user);
        GV_Compras.DataBind();
    }
    protected void B_Comprar_Click(object sender, EventArgs e)
    {
        //Usuario user = new Usuario();
        //user.comprarProductos(id_user);
    }

    protected void B_Comprar_Click(object sender, ImageClickEventArgs e)
    {
           
            Session["est_com"] = "COMPRO";
            Response.Redirect("ReporteFactura.aspx");
        

    }
    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ReporteCompra.aspx");
    }
}
