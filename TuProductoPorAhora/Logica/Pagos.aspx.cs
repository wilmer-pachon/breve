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

public partial class Presentacion_Pagos : System.Web.UI.Page
{
    int _id_user, estado;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["id_rol"].Equals("null") || !Session["id_rol"].Equals("1") || Session["id_user"].Equals("null"))
            Response.Redirect("index.aspx");

        _id_user = int.Parse(Session["id_user"].ToString());

    }
    protected void GV_Pagos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DatosUsuario datos = new DatosUsuario();

        Label id = (Label)GV_Pagos.Rows[e.RowIndex].FindControl("L_Idpago");
        string valor1 = ((Label)id.FindControl("L_Idpago")).Text;
        datos.Id_user = int.Parse(valor1);

        string valor = ((DropDownList)GV_Pagos.Rows[e.RowIndex].FindControl("DDL_Estado")).SelectedValue.ToString();

        if (!valor.Equals("En Deuda"))
        {

            TextBox fi = (TextBox)GV_Pagos.Rows[e.RowIndex].FindControl("TB_FI");
            datos.Fecha_i = ((TextBox)fi.FindControl("TB_FI")).Text;

            TextBox ff = (TextBox)GV_Pagos.Rows[e.RowIndex].FindControl("TB_FF");
            datos.Fecha_f = ((TextBox)fi.FindControl("TB_FF")).Text;

            datos.Id_empresa = int.Parse(valor);
        
        }

        Usuario user = new Usuario();
        user.modificarEstadoPago(datos);

        this.RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('Los Datos se han actualizado!');window.location=\"Pagos.aspx\"</script>");
    
    }
    protected void GV_Pagos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GV_Pagos.EditIndex = e.NewEditIndex;
        Usuario obtener = new Usuario();
        obtener.obtenerPagos(estado);

        GV_Pagos.DataSource = obtener.obtenerPagos(estado);
        GV_Pagos.DataBind();
    }
    protected void GV_Pagos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GV_Pagos.EditIndex = -1;
        Usuario obtener = new Usuario();
        obtener.obtenerPagos(estado);

        GV_Pagos.DataSource = obtener.obtenerPagos(estado);
        GV_Pagos.DataBind();
    }
    protected void B_Estado_Click(object sender, EventArgs e)
    {
        string valor1 = DDL_Estado.SelectedValue.ToString();
        estado = int.Parse(valor1);
        Usuario user = new Usuario();
        user.obtenerPagos(estado);

        GV_Pagos.DataSource = user.obtenerPagos(estado);
        GV_Pagos.DataBind();
    }
    protected void B_Fecha_Click(object sender, EventArgs e)
    {
        string fecha = TB_Fecha.Text.ToString();
        
        Usuario user = new Usuario();
        user.obtenerPagosFecha(fecha);

        GV_Pagos.DataSource = user.obtenerPagosFecha(fecha);
        GV_Pagos.DataBind();
    }
}
