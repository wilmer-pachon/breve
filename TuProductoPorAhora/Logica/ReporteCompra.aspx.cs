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

public partial class Presentacion_ReporteCompra : System.Web.UI.Page
{
    int _id_user;
    //int _id_empresa;

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
            Compra reporte = ObtenerInforme();
            CRS_Compra.ReportDocument.SetDataSource(reporte);
            CRV_Compra.ReportSource = CRS_Compra;
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected Compra ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable compra = new DataTable(); //dt
        Compra reporte = new Compra(); //ci
        compra = reporte.Tables["compra"];


        Usuario dao = new Usuario();
        DataTable Intermedio = dao.obtenerCompraReporte(_id_user);


        for (int i = 0; i < Intermedio.Rows.Count; i++)
        {
            fila = compra.NewRow();
            fila["producto"] = Intermedio.Rows[i]["producto"].ToString();
            fila["precio_act"] = int.Parse(Intermedio.Rows[i]["precio_act"].ToString());
            fila["empresa"] = Intermedio.Rows[i]["empresa"].ToString();
            fila["fecha"] = Intermedio.Rows[i]["fecha"].ToString();
            fila["cantidad"] = int.Parse(Intermedio.Rows[i]["cantidad"].ToString());
            //fila["precio_ant"] = int.Parse(Intermedio.Rows[i]["precio_ant"].ToString());
            fila["precio_total"] = int.Parse(Intermedio.Rows[i]["precio_total"].ToString());
            fila["img_producto"] = CargarByte(Server.MapPath(Intermedio.Rows[i]["img_producto"].ToString()));
            
            //fila["hyperlink"] = Intermedio.Rows[i]["archivo"].ToString();
            //fila["hyperlinkk"] = Intermedio.Rows[i]["imagen"].ToString();
            compra.Rows.Add(fila);
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
