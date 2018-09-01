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


public partial class Presentacion_ReporteCompany : System.Web.UI.Page
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
            Cantidad_Company reporte = ObtenerInforme();
            CRS_ReporteCompanyy.ReportDocument.SetDataSource(reporte);
            CRV_ReporteCompanyy.ReportSource = CRS_ReporteCompanyy;

        }
        catch (Exception )
        {

            throw;
        }
    }
    protected Cantidad_Company ObtenerInforme()
    {
        DataRow fila;  //dr
        DataTable empresa = new DataTable(); //dt
        Cantidad_Company reporte = new Cantidad_Company(); //ci
        empresa = reporte.Tables["empresas"];

        Usuario dao = new Usuario();
        DataTable Intermedio = dao.obtenerCompanyReporte();

        for (int i = 0; i < Intermedio.Rows.Count; i++)
        {
            fila = empresa.NewRow();
            fila["id_empresa"] = int.Parse(Intermedio.Rows[i]["id_user"].ToString());
            fila["empresa"] = Intermedio.Rows[i]["empresa"].ToString();
            fila["nit"] = Intermedio.Rows[i]["nit"].ToString();
            fila["direccion"] = Intermedio.Rows[i]["direccion"].ToString();
            fila["telefono"] = Intermedio.Rows[i]["telefono"].ToString();
            fila["descripcion"] = Intermedio.Rows[i]["descripcion"].ToString();
            fila["img_empresa"] = CargarByte(Server.MapPath(Intermedio.Rows[i]["img_empresa"].ToString()));
            fila["cam_com"] = CargarByte(Server.MapPath(Intermedio.Rows[i]["cam_com"].ToString()));
            fila["rut"] = CargarByte(Server.MapPath(Intermedio.Rows[i]["rut"].ToString()));
            fila["id_user"] = int.Parse(Intermedio.Rows[i]["id_user"].ToString());
            fila["id_pago"] = int.Parse(Intermedio.Rows[i]["id_pago"].ToString());
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

    protected void CRV_ReporteCompanyy_Init(object sender, EventArgs e)
    {

    }
}