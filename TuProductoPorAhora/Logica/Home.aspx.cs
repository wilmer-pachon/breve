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

public partial class Presentacion_Home : System.Web.UI.Page
{
    int _id_user, _id_empresa;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_rol"].Equals("null") || !Session["id_rol"].Equals("3") || Session["id_user"].Equals("null"))
            Response.Redirect("index.aspx");

        _id_user = int.Parse(Session["id_user"].ToString());

        if (!IsPostBack) {
            Usuario user = new Usuario();
            user.obtenerNoticias(_id_user);
            GV_Noticias.DataSource = user.obtenerNoticias(_id_user);
            GV_Noticias.DataBind();
        }
    }
    protected void GV_Noticias_RowUpdating(object sender, GridViewUpdateEventArgs e)
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

        Label valor1 = (Label)GV_Noticias.Rows[e.RowIndex].FindControl("L_Cant_disp");
        string cd = ((Label)valor1.FindControl("L_Cant_disp")).Text;
        int C_D = int.Parse(cd);

        TextBox can = (TextBox)GV_Noticias.Rows[e.RowIndex].FindControl("TB_Cant");
        string ca = ((TextBox)can.FindControl("TB_Cant")).Text;
        int C_A= int.Parse(ca);

        if(C_A > C_D || C_A <= 0)
        {

            this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('La Cantidad a comprar no esta disponible!');</script>");
        
        }
        else
        {

        user.Id_factura = int.Parse(Session["id_factura"].ToString());

        Label Id_Pro = (Label)GV_Noticias.Rows[e.RowIndex].FindControl("L_IdPro");
        string valor2 = ((Label)Id_Pro.FindControl("L_IdPro")).Text;
        user.Id_producto = int.Parse(valor2);

        user.Cantidad = C_A;

        Label L_Precio2 = (Label)GV_Noticias.Rows[e.RowIndex].FindControl("L_Precio2");
        string valor3 = ((Label)L_Precio2.FindControl("L_Precio2")).Text;
        user.Precio_p = int.Parse(valor3);

        Usuario enviar = new Usuario();
        enviar.insertarCompra(user);

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('El producto se agrego al carrito de compras!');window.location=\"Home.aspx\"</script>");
        }

    }
    protected void GV_Noticias_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GV_Noticias.EditIndex = e.NewEditIndex;
        Usuario obtener = new Usuario();
        obtener.obtenerNoticias(_id_user);

        GV_Noticias.DataSource = obtener.obtenerNoticias(_id_user);
        GV_Noticias.DataBind();
    }
    protected void GV_Noticias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV_Noticias.EditIndex = -1;
        Usuario obtener = new Usuario();
        obtener.obtenerNoticias(_id_user);

        GV_Noticias.DataSource = obtener.obtenerNoticias(_id_user);
        GV_Noticias.DataBind();
    }
   
}
