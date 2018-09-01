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

public partial class Presentacion_ReporteProductos : System.Web.UI.Page
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
            Productos reporte = ObtenerInforme();
            CRS_ReporteProductos.ReportDocument.SetDataSource(reporte);
            CRV_ReporteProductos.ReportSource = CRS_ReporteProductos;
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected Productos ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable producto = new DataTable(); //dt
        Productos reporte = new Productos(); //ci
        producto = reporte.Tables["producto"];


        Usuario dao = new Usuario();
        DataTable Intermedio = dao.obtenerCarritoReporte();


        for (int i = 0; i < Intermedio.Rows.Count; i++)
        {
            fila = producto.NewRow();
            fila["producto"] = Intermedio.Rows[i]["producto"].ToString();
            fila["descripcion"] = Intermedio.Rows[i]["descripcion"].ToString();
            fila["categoria"] = Intermedio.Rows[i]["descripcion"].ToString();
            fila["precio_ant"] = int.Parse(Intermedio.Rows[i]["precio_ant"].ToString());
            fila["precio_act"] = int.Parse(Intermedio.Rows[i]["precio_act"].ToString());
            fila["fecha_ini"] = Intermedio.Rows[i]["fecha_ini"].ToString();
            fila["fecha_fin"] = Intermedio.Rows[i]["fecha_fin"].ToString();
            fila["img_producto"] = CargarByte(Server.MapPath(Intermedio.Rows[i]["img_producto"].ToString()));
            fila["empresa"] = Intermedio.Rows[i]["empresa"].ToString();
            //fila["hyperlink"] = Intermedio.Rows[i]["archivo"].ToString();
            //fila["hyperlinkk"] = Intermedio.Rows[i]["imagen"].ToString();
            producto.Rows.Add(fila);
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
}