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

public partial class Presentacion_ReporteCarrito : System.Web.UI.Page
   
{
    int _id_user;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Session["est_com"].Equals("COMPRO"))
            Response.Redirect("home.aspx");

        _id_user = int.Parse(Session["id_user"].ToString());
        PoblarReporte();

    }
    protected void PoblarReporte()
    {
        try
        {
            Carrito reporte = ObtenerInforme();
            CRS_Carrito.ReportDocument.SetDataSource(reporte);
            CRV_Carrito.ReportSource = CRS_Carrito;
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected Carrito ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable compras = new DataTable(); //dt
        Carrito reporte = new Carrito(); //ci
        compras = reporte.Tables["Carrito"];

        Usuario dao = new Usuario();
        DataTable Intermedio = dao.obtenerCarritoReporte(_id_user);

        for (int i = 0; i < Intermedio.Rows.Count; i++)
        {
            fila = compras.NewRow();
            fila["img_perfil"] = CargarByte(Server.MapPath(Intermedio.Rows[i]["img_perfil"].ToString()));
            fila["usuario"] = Intermedio.Rows[i]["usuario"].ToString();
            fila["producto"] = Intermedio.Rows[i]["producto"].ToString();
            fila["img_producto"] = CargarByte(Server.MapPath(Intermedio.Rows[i]["img_producto"].ToString()));
            fila["cantidad"] = int.Parse(Intermedio.Rows[i]["cantidad"].ToString());
            fila["precio_act"] = int.Parse(Intermedio.Rows[i]["precio_act"].ToString());
            fila["precio_total"] = int.Parse(Intermedio.Rows[i]["precio_total"].ToString());
           // fila["id_user"] = int.Parse(Intermedio.Rows[i]["id_user"].ToString());
            //fila["fecha"] = int.Parse(Intermedio.Rows[i]["fecha"].ToString());
            
            //fila["hyperlink"] = Intermedio.Rows[i]["archivo"].ToString();
            //fila["hyperlinkk"] = Intermedio.Rows[i]["imagen"].ToString();
            compras.Rows.Add(fila);
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