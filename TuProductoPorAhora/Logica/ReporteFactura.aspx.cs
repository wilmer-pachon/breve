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

public partial class Presentacion_ReporteFactura : System.Web.UI.Page
{
    int _id_user;
    int _id_factura;

    protected void Page_Load(object sender, EventArgs e)
    {
        _id_user = int.Parse(Session["id_user"].ToString());
        
       

        if (Session["id_rol"].Equals("null") || !Session["id_rol"].Equals("3"))
            Response.Redirect("index.aspx");

        PoblarReporte();

        
       

    }
    protected void PoblarReporte()
    {
        try
        {
            Factura reporte = ObtenerInforme();
            CRS_Factura.ReportDocument.SetDataSource(reporte);
            CRV_Factura.ReportSource = CRS_Factura;
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected Factura ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable factura = new DataTable(); //dt
        Factura reporte = new Factura(); //ci
        factura = reporte.Tables["factura"];

        Usuario dao = new Usuario();
        DataTable Intermedio = dao.obtenerFacturaReporte(_id_user, _id_factura);


        for (int i = 0; i < Intermedio.Rows.Count; i++)
        {
            fila = factura.NewRow();
            fila["img_producto"] = CargarByte(Server.MapPath(Intermedio.Rows[i]["img_producto"].ToString()));
            fila["producto"] = Intermedio.Rows[i]["producto"].ToString();
            fila["total"] = int.Parse(Intermedio.Rows[i]["total"].ToString());
            fila["precio_act"] = int.Parse(Intermedio.Rows[i]["precio_act"].ToString());
            fila["cantidad"] = int.Parse(Intermedio.Rows[i]["cantidad"].ToString());
            fila["precio_total"] = int.Parse(Intermedio.Rows[i]["precio_total"].ToString());
            fila["empresa"] = Intermedio.Rows[i]["producto"].ToString();
            fila["fecha"] = Intermedio.Rows[i]["fecha"].ToString();

            //fila["hyperlink"] = Intermedio.Rows[i]["archivo"].ToString();
            //fila["hyperlinkk"] = Intermedio.Rows[i]["imagen"].ToString();
            factura.Rows.Add(fila);
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
