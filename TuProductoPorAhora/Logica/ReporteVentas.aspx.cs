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

public partial class Presentacion_ReporteVentas : System.Web.UI.Page
{
    int _id_user;
    int _id_empresa;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["id_rol"].Equals("null") || Session["id_user"].Equals("null"))
            Response.Redirect("index.aspx");
         
        _id_user = int.Parse(Session["id_user"].ToString());

         Usuario datos = new Usuario();
        DataTable informacion = datos.datosEmpresa(_id_user);

        if (informacion.Rows.Count == 0)
        {
            Session["id_empresa"] = "null";
            Response.Redirect("index.aspx");
        }
        else
        {
            Session["id_empresa"] = informacion.Rows[0]["id_empresa"].ToString();
            _id_empresa = int.Parse(Session["id_empresa"].ToString());
        }


        PoblarReporte();

    }
    protected void PoblarReporte()
    {
        try
        {
           ReporteVentas reporte = ObtenerInforme();
            //DatosEmpresa reporte1 = ObtenerInforme1();
            CRS_Ventas.ReportDocument.SetDataSource(reporte);
            //CRS_Ventas.ReportDocument.Subreports[0].SetDataSource(reporte);
            //CRS_Ventas.ReportDocument.SetDataSource(reporte1);
            CRV_Ventas.ReportSource = CRS_Ventas;


        }
        catch (Exception)
        {

            throw;
        }
    }

    protected ReporteVentas ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable ventas = new DataTable(); //dt
        ReporteVentas reporte = new ReporteVentas(); //ci
        ventas = reporte.Tables["ventas"];


        Usuario dao = new Usuario();
        DataTable Intermedio = dao.obtenerVentasReporte(_id_empresa);


        for (int i = 0; i < Intermedio.Rows.Count; i++)
        {
            fila = ventas.NewRow();
            fila["img_producto"] = CargarByte(Server.MapPath(Intermedio.Rows[i]["img_producto"].ToString()));
            fila["producto"] = Intermedio.Rows[i]["producto"].ToString();
            fila["precio_act"] = int.Parse(Intermedio.Rows[i]["precio_act"].ToString());
            fila["fecha"] = Intermedio.Rows[i]["fecha"].ToString();
            fila["cantidad"] = int.Parse(Intermedio.Rows[i]["cantidad"].ToString());
            fila["total"] = int.Parse(Intermedio.Rows[i]["total"].ToString());
            fila["usuario"] = Intermedio.Rows[i]["usuario"].ToString();
           
            //fila["hyperlink"] = Intermedio.Rows[i]["archivo"].ToString();
            //fila["hyperlinkk"] = Intermedio.Rows[i]["imagen"].ToString();
            ventas.Rows.Add(fila);
        }

        return reporte;
    }


    protected DatosEmpresa ObtenerInforme1()
    {
        DataRow fila;  //dr
        DataTable empresa = new DataTable(); //dt
        DatosEmpresa reporte = new DatosEmpresa(); //ci
        empresa = reporte.Tables["datosEmpresa"];


        Usuario dao = new Usuario();
        DataTable Intermedio = dao.obtenerEmpresa(_id_user);


        for (int i = 0; i < Intermedio.Rows.Count; i++)
        {
            fila = empresa.NewRow();
            fila["img_empresa"] = CargarByte(Server.MapPath(Intermedio.Rows[i]["img_empresa"].ToString()));
            fila["empresa"] = Intermedio.Rows[i]["empresa"].ToString();
            fila["direccion"] = Intermedio.Rows[i]["direccion"].ToString();
            fila["telefono"] = Intermedio.Rows[i]["telefono"].ToString();
            fila["nit"] = Intermedio.Rows[i]["nit"].ToString();
            //fila["hyperlink"] = Intermedio.Rows[i]["archivo"].ToString();
            //fila["hyperlinkk"] = Intermedio.Rows[i]["imagen"].ToString();
            empresa.Rows.Add(fila);
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
