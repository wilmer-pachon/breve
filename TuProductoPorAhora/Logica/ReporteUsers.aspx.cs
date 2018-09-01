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

public partial class Presentacion_ReporteUsers : System.Web.UI.Page
{
    int _id_user;

    protected void Page_Load(object sender, EventArgs e)
    {
        _id_user = int.Parse(Session["id_user"].ToString());

        if (Session["id_rol"].Equals("null") || !Session["id_rol"].Equals("1"))
            Response.Redirect("index.aspx");

        PoblarReporte();
      
    }
    protected void PoblarReporte()
    {
        try
        {
            Cantidad_Users reporte = ObtenerInforme();
            //Cantidad_Company reporte1 = ObtenerInforme1();
            //CrystalReportSource1.ReportDocument.Subreports[0].SetDataSource(reporte1);
            CrystalReportSource1.ReportDocument.SetDataSource(reporte);
            CRV_ReportUsers.ReportSource = CrystalReportSource1;
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected Cantidad_Users ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable usuarios = new DataTable(); //dt
        Cantidad_Users reporte = new Cantidad_Users(); //ci
        usuarios = reporte.Tables["Datos_Users"];

        Usuario dao = new Usuario();
        DataTable Intermedio = dao.obtenerUsuariosReporte();

        for (int i = 0; i < Intermedio.Rows.Count; i++)
        {
            fila = usuarios.NewRow();
            fila["id_user"] = int.Parse(Intermedio.Rows[i]["id_user"].ToString());
            fila["nombre"] = Intermedio.Rows[i]["nombre"].ToString();
            fila["apellido"] = Intermedio.Rows[i]["apellido"].ToString();
            fila["usuario"] = Intermedio.Rows[i]["usuario"].ToString();
            fila["sexo"] = Intermedio.Rows[i]["sexo"].ToString();
            fila["ciudad"] = Intermedio.Rows[i]["ciudad"].ToString();
            fila["correo"] = Intermedio.Rows[i]["correo"].ToString();
            fila["id_rol"] = int.Parse(Intermedio.Rows[i]["id_rol"].ToString());
            fila["img_perfil"] = CargarByte(Server.MapPath(Intermedio.Rows[i]["img_perfil"].ToString()));
            //fila["hyperlink"] = Intermedio.Rows[i]["archivo"].ToString();
            //fila["hyperlinkk"] = Intermedio.Rows[i]["imagen"].ToString();
            usuarios.Rows.Add(fila);
        }

        return reporte;
    }
    public byte[] CargarByte(string Ruta)
    {
        byte[] imagenBytes;
        string nombrearchivo = Ruta;

        if (File.Exists(nombrearchivo) == true)
            imagenBytes = File.ReadAllBytes(nombrearchivo);
        else
            imagenBytes = null;
        return imagenBytes;
    }
    /*protected void PoblarReporte1()
    {
        try
        {
            vendedores reporte1 = ObtenerInforme1();
            CRS_Reporte1.ReportDocument.SetDataSource(reporte1);
            CRV_Reporte1.ReportSource = CRS_Reporte1;

        }
        catch (Exception)
        {

            throw;
        }
    }
    protected vendedores ObtenerInforme1()
    {
       DataRow fila1;  //dr
       DataRow fila2;
       DataRow fila;
        DataTable vendedor1 = new DataTable();
        DataTable vendedor2 = new DataTable();
        DataTable vendedor3 = new DataTable(); //dt
        vendedores reporte = new vendedores();  //ci

        vendedor1 = reporte.Tables["usuario"];
        vendedor2 = reporte.Tables["productos"];
        vendedor3 = reporte.Tables["ventas"];

        Datos dao = new Datos();
        DataTable Intermedio = dao.obtenerVendedor();

        for (int i = 0; i < Intermedio.Rows.Count; i++)
        {
            fila1 = vendedor1.NewRow();
            fila1["id_user"] = int.Parse(Intermedio.Rows[i]["id_user"].ToString());
            fila1["nombre"] = Intermedio.Rows[i]["nombre"].ToString();
            fila2 = vendedor2.NewRow();
            fila2["nombre_producto"] = Intermedio.Rows[i]["nombre_producto"].ToString();
            fila2["id_producto"] = int.Parse(Intermedio.Rows[i]["id_producto"].ToString());
            fila = vendedor3.NewRow();
            fila["id_user"] = int.Parse(Intermedio.Rows[i]["id_user"].ToString());
            fila["id_venta"] = int.Parse(Intermedio.Rows[i]["id_venta"].ToString());
            fila["id_producto"] = int.Parse(Intermedio.Rows[i]["id_producto"].ToString());
            fila["precio"] = int.Parse(Intermedio.Rows[i]["precio"].ToString());
            fila["marca"] = Intermedio.Rows[i]["marca"].ToString();
            fila["modelo"] = Intermedio.Rows[i]["modelo"].ToString();
            fila["color"] = Intermedio.Rows[i]["color"].ToString();
            vendedor1.Rows.Add(fila1);
            vendedor2.Rows.Add(fila2);
            vendedor3.Rows.Add(fila);
        }
        return reporte;
    }*/

    protected void CRV_Reporte_Init(object sender, EventArgs e)
    {

    }
}