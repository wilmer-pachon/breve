using System;
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
using MySql.Data.MySqlClient;


/// <summary>
/// Descripción breve de Usuario
/// </summary>
public class Usuario
{
    string ipAddress;
    string MAC;

    public Usuario()
    {
        ipAddress = HttpContext.Current.Request.UserHostAddress;
        MAC = Utilidades.Mac.GetMAC(ref ipAddress);
    }
    public DataTable loginUsuario(string Login, string Pass)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("sp_login_usuario", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.Add("_user", MySqlDbType.VarChar, 30).Value = Login;
            dataAdapter.SelectCommand.Parameters.Add("_pass", MySqlDbType.VarChar, 30).Value = Pass;

            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerUsuarios()
    {
        MySqlConnection objetoConexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        DataTable dataTable = new DataTable();

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_MostrarUsusario", objetoConexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            objetoConexion.Open();
            dataAdapter.Fill(dataTable);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (objetoConexion != null)
            {
                objetoConexion.Close();
            }
        }
        return dataTable;
    }
    public void crearUsuario(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("sp_insertar_usuario", conection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("_nombre", MySqlDbType.VarChar, 30).Value = user.Nombre;
            command.Parameters.Add("_apellido", MySqlDbType.VarChar, 30).Value = user.Apellido;
            command.Parameters.Add("_usuario", MySqlDbType.VarChar, 30).Value = user.Usuario;
            command.Parameters.Add("_correo", MySqlDbType.VarChar, 30).Value = user.Correo;
            command.Parameters.Add("_contra", MySqlDbType.VarChar, 30).Value = user.Contra;
            command.Parameters.Add("_dia", MySqlDbType.VarChar, 30).Value = user.Dia;
            command.Parameters.Add("_mes", MySqlDbType.VarChar, 30).Value = user.Mes;
            command.Parameters.Add("_ano", MySqlDbType.VarChar, 30).Value = user.Ano;
            command.Parameters.Add("_sexo", MySqlDbType.VarChar, 30).Value = user.Sexo;
            command.Parameters.Add("_ciudad", MySqlDbType.VarChar, 30).Value = user.Ciudad;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;
            
            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public DataTable obtenerDatosEdit(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Obtener_Datos_Edit", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public void notificarUsuario(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_NotificaAuto", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_notificacion", MySqlDbType.VarChar, 140).Value = user.Notificacion;
            command.Parameters.Add("_nombre", MySqlDbType.VarChar, 30).Value = user.Nombre;
            command.Parameters.Add("_id_user", MySqlDbType.VarChar, 30).Value = user.Id_user;
            command.Parameters.Add("_url", MySqlDbType.VarChar, 210).Value = user.Url;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public DataTable obtenerNotificacion(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Obtener_Notificacion", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            
            
            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerSeguidores(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Obtener_Seguidores", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_empresa", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerNotificaUser(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Obtener_Notifica_User", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            

            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerNoticias(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Obtener_Noticias", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public void modificarUser(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_ModificarUser", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user.Id_user;
            command.Parameters.Add("_nombre", MySqlDbType.VarChar, 30).Value = user.Nombre;
            command.Parameters.Add("_apellido", MySqlDbType.VarChar, 30).Value = user.Apellido;
            command.Parameters.Add("_usuario", MySqlDbType.VarChar, 30).Value = user.Usuario;
            command.Parameters.Add("_correo", MySqlDbType.VarChar, 30).Value = user.Correo;
            command.Parameters.Add("_contra", MySqlDbType.VarChar, 30).Value = user.Contra;
            command.Parameters.Add("_dia", MySqlDbType.VarChar, 30).Value = user.Dia;
            command.Parameters.Add("_sexo", MySqlDbType.VarChar, 1).Value = user.Sexo;
            command.Parameters.Add("_ciudad", MySqlDbType.VarChar, 30).Value = user.Ciudad;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;
            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public DataTable busquedaUser(DatosUsuario user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_BusquedaUser", conection);
            dataAdapter.SelectCommand.Parameters.Add("_palabra", MySqlDbType.VarChar , 30).Value = user.Nombre;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public void mensajeUser(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_Mensaje", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_asunto", MySqlDbType.VarChar, 30).Value = user.Asunto;
            command.Parameters.Add("_mensaje", MySqlDbType.VarChar, 140).Value = user.Mensaje;
            command.Parameters.Add("_id_empresa", MySqlDbType.Int32).Value = user.Id_empresa;
            command.Parameters.Add("_id_user", MySqlDbType.VarChar, 210).Value = user.Id_user;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public DataTable obtenerMensajesUser(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_MensajeUser", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable cambiarEstadoNotificacion(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_CambiarEstadoNotificacion", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerSolicitud()
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_ObtenerSolicitud", conection);
            //dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerMensaje(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_ObtenerMensaje", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable cambiarEstadoMensaje(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_CambiarEstadoMensaje", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerEmpresa(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Obtener_Empresa", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerSolicitudAdmin()
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_ObtenerSolicitudAdmin", conection);
            //SP_Obtener_Empresa se cambio por
            //dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerProductos(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Obtener_ProductosEmp", conection);
            //SP_Obtener_Empresa se cambio por
            dataAdapter.SelectCommand.Parameters.Add("_id_empresa", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerCompra(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Obtener_Compra", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerTotalCompra(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_ObtenerTotalCompra", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerImgProductos()
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Obtener_ImgProducto", conection);
           // dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public void crearProducto(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("sp_insertar_producto", conection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("_producto", MySqlDbType.VarChar, 30).Value = user.Producto;
            command.Parameters.Add("_pa", MySqlDbType.Int32).Value = user.Precio_a;
            command.Parameters.Add("_pp", MySqlDbType.Int32).Value = user.Precio_p;
            command.Parameters.Add("_fecha_i", MySqlDbType.Date).Value = user.Fecha_i;
            command.Parameters.Add("_fecha_f", MySqlDbType.Date).Value = user.Fecha_f;
            command.Parameters.Add("_descripcion", MySqlDbType.VarChar, 60).Value = user.Descripcion;
            command.Parameters.Add("_categoria", MySqlDbType.VarChar, 30).Value = user.Categoria;
            command.Parameters.Add("_url", MySqlDbType.VarChar, 30).Value = user.Url;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public void modificarImgPerfil(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_Modificar_ImgPerfil", conection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("_id_user", MySqlDbType.VarChar, 30).Value = user.Id_user;
            command.Parameters.Add("_url", MySqlDbType.VarChar, 30).Value = user.Url;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public DataTable obtenerUsuariosReporte()
    {
        MySqlConnection objetoConexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        DataTable dataTable = new DataTable();

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_MostrarUsusariosReporte", objetoConexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            objetoConexion.Open();
            dataAdapter.Fill(dataTable);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (objetoConexion != null)
            {
                objetoConexion.Close();
            }
        }
        return dataTable;
    }
    public DataTable obtenerCompanyReporte()
    {
        MySqlConnection objetoConexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        DataTable dataTable = new DataTable();

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_MostrarCompanyReporte", objetoConexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            objetoConexion.Open();
            dataAdapter.Fill(dataTable);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (objetoConexion != null)
            {
                objetoConexion.Close();
            }
        }
        return dataTable;
    }
    public DataTable obtenerProductosReporte()
    {
        MySqlConnection objetoConexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        DataTable dataTable = new DataTable();

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_MostrarProductosReporte", objetoConexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            objetoConexion.Open();
            dataAdapter.Fill(dataTable);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (objetoConexion != null)
            {
                objetoConexion.Close();
            }
        }
        return dataTable;
    }

    public DataTable obtenerCarritoReporte()
    {
        MySqlConnection objetoConexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        DataTable dataTable = new DataTable();

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_MostrarCarritoReporte", objetoConexion);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            objetoConexion.Open();
            dataAdapter.Fill(dataTable);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (objetoConexion != null)
            {
                objetoConexion.Close();
            }
        }
        return dataTable;
    }


    public DataTable obtenerFacturaReporte(int user, int factura)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Reporte_Factura", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.Parameters.Add("_id_factura", MySqlDbType.Int32).Value = factura;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerCompraReporte(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Reporte_HIstorial_Compra", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerVentasReporte(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Reporte_Historial_Ventas", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }

    
    public DataTable obtenerCategoria()
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Obtener_Categoria", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public void crearEmpresa(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("sp_insertar_empresa", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user.Id_user;
            command.Parameters.Add("_empresa", MySqlDbType.VarChar, 30).Value = user.Empresa;
            command.Parameters.Add("_nit", MySqlDbType.VarChar, 15).Value = user.Nit;
            command.Parameters.Add("_direccion", MySqlDbType.VarChar, 30).Value = user.Direccion;
            command.Parameters.Add("_telefono", MySqlDbType.VarChar, 15).Value = user.Telefono;
            command.Parameters.Add("_descripcion", MySqlDbType.VarChar, 30).Value = user.Descrip;
            command.Parameters.Add("_logo", MySqlDbType.VarChar, 100).Value = user.Logo_emp;
            command.Parameters.Add("_rut", MySqlDbType.VarChar, 100).Value = user.Rut;
            command.Parameters.Add("_cc", MySqlDbType.VarChar, 100).Value = user.C_c;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public void modificarImgEmpresa(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_Modificar_ImgEmpresa", conection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("_id_user", MySqlDbType.VarChar, 30).Value = user.Id_user;
            command.Parameters.Add("_url", MySqlDbType.VarChar, 30).Value = user.Url;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public void modificarEmpresa(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_ModificarEmpresa", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user.Id_user;
            command.Parameters.Add("_direccion", MySqlDbType.VarChar, 30).Value = user.Direccion;
            command.Parameters.Add("_telefono", MySqlDbType.VarChar, 15).Value = user.Telefono;
            command.Parameters.Add("_descripcion", MySqlDbType.VarChar, 30).Value = user.Descrip;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public void modificarProducto(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_ModificarProducto", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user.Id_user;
            command.Parameters.Add("_producto", MySqlDbType.VarChar, 30).Value = user.Producto;
            command.Parameters.Add("_descripcion", MySqlDbType.VarChar, 100).Value = user.Descripcion;
            command.Parameters.Add("_categoria", MySqlDbType.VarChar, 30).Value = user.Categoria;
            command.Parameters.Add("_p_a", MySqlDbType.Int32).Value = user.Precio_a;
            command.Parameters.Add("_p_p", MySqlDbType.Int32).Value = user.Precio_p;
            command.Parameters.Add("_f_i", MySqlDbType.VarChar, 30).Value = user.Fecha_i;
            command.Parameters.Add("_f_f", MySqlDbType.VarChar, 30).Value = user.Fecha_f;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public DataTable datosEmpresa(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_DatosEmpresa", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public void InsertarImgSolicitud(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_InsertarImgSolicitud", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_imagen", MySqlDbType.VarChar, 200).Value = user.Url;
            command.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user.Id_user;
            command.Parameters.Add("_campo", MySqlDbType.VarChar, 30).Value = user.Nombre;
            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public DataTable obtenerImgSolicitud(string campo, int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_obtenerImgLogo", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.VarChar).Value = user;
            dataAdapter.SelectCommand.Parameters.Add("_campo", MySqlDbType.VarChar).Value = campo;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public void borrarImgSolicitud(int user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_BorrarImgSolicitud", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public void seguirEmpPro(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_seguir_Emp_Pro", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_empresa", MySqlDbType.Int32).Value = user.Id_empresa;
            command.Parameters.Add("_id_producto", MySqlDbType.Int32).Value = user.Id_producto;
            command.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user.Id_user;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public DataTable obtenerFactura(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Obtener_Factura", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public void crearFactura(int user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_Crear_Factura", conection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("_id_user", MySqlDbType.VarChar, 30).Value = user;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public void insertarCompra(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_Insertar_Compra", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_factura", MySqlDbType.Int32).Value = user.Id_factura;
            command.Parameters.Add("_id_producto", MySqlDbType.Int32).Value = user.Id_producto;
            command.Parameters.Add("_cantidad", MySqlDbType.Int32).Value = user.Cantidad;
            command.Parameters.Add("_precio", MySqlDbType.Int32).Value = user.Precio_p;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public void modificarCompra(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_ModificarCompra", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_producto", MySqlDbType.Int32).Value = user.Id_producto;
            command.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user.Id_user;
            command.Parameters.Add("_id_factura", MySqlDbType.Int32).Value = user.Id_factura;
            command.Parameters.Add("_precio", MySqlDbType.Int32).Value = user.Precio_p;
            command.Parameters.Add("_cantidad", MySqlDbType.Int32).Value = user.Cantidad;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public void eliminarProCom(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_EliminarProCom", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_producto", MySqlDbType.Int32).Value = user.Id_producto;
            command.Parameters.Add("_id_factura", MySqlDbType.Int32).Value = user.Id_factura;
            command.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user.Cantidad;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public void notificarUsuarioAuto(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_NotificaAuto", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_notificacion", MySqlDbType.VarChar, 140).Value = user.Notificacion;
            command.Parameters.Add("_nombre", MySqlDbType.VarChar, 30).Value = user.Nombre;
            command.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user.Id_user;
            command.Parameters.Add("_url", MySqlDbType.VarChar, 210).Value = user.Url;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public DataTable verificarUser(string user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_VerificarUser", conection);
            dataAdapter.SelectCommand.Parameters.Add("_user", MySqlDbType.VarChar,30).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;   
    }
    public DataTable obtenerSuscripciones(int user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_Obtener_Suscripciones", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public void eliminarProducto(int user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_Eliminar_Producto", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_producto", MySqlDbType.Int32).Value = user;
            //command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            //command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public void eliminarUser(int user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_EliminarUser", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;

            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
    public DataTable cambiarEstadoSolicitud(DatosUsuario user)
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_CambiarEstadoSolicitud", conection);
            dataAdapter.SelectCommand.Parameters.Add("_id_user", MySqlDbType.Int32).Value = user.Id_user;
            dataAdapter.SelectCommand.Parameters.Add("_nombre", MySqlDbType.Int32).Value = user.Id_empresa;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public DataTable obtenerPagos(int estado)
    {
        MySqlConnection objetoConexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        DataTable dataTable = new DataTable();

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_ObtenerPagos", objetoConexion);
            dataAdapter.SelectCommand.Parameters.Add("_estado", MySqlDbType.Int32).Value = estado;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            objetoConexion.Open();
            dataAdapter.Fill(dataTable);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (objetoConexion != null)
            {
                objetoConexion.Close();
            }
        }
        return dataTable;
    }
    public DataTable obtenerPagosFecha(string fecha)
    {
        MySqlConnection objetoConexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        DataTable dataTable = new DataTable();

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_obtenerPagosFecha", objetoConexion);
            dataAdapter.SelectCommand.Parameters.Add("_fecha", MySqlDbType.VarChar, 30).Value = fecha;
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            objetoConexion.Open();
            dataAdapter.Fill(dataTable);
        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (objetoConexion != null)
            {
                objetoConexion.Close();
            }
        }
        return dataTable;
    }
    public DataTable obtenerEstadoPago()
    {
        DataTable Usuario = new DataTable();
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SP_obtenerEstadoPago", conection);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            conection.Open();
            dataAdapter.Fill(Usuario);
        }
        catch (Exception Ex)
        {
            throw Ex;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
        return Usuario;
    }
    public void modificarEstadoPago(DatosUsuario user)
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["breve"].ConnectionString);

        try
        {
            conection.Open();
            MySqlCommand command = new MySqlCommand("SP_modificarEstadoPago", conection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("_id_pago", MySqlDbType.Int32).Value = user.Id_user;
            command.Parameters.Add("_fi", MySqlDbType.VarChar, 30).Value = user.Fecha_i;
            command.Parameters.Add("_ff", MySqlDbType.VarChar, 30).Value = user.Fecha_f;
            command.Parameters.Add("_id_estado", MySqlDbType.Int32).Value = user.Id_empresa;
            command.Parameters.Add("_ip", MySqlDbType.VarChar, 30).Value = ipAddress;
            command.Parameters.Add("_mac", MySqlDbType.VarChar, 40).Value = MAC;
            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            throw e;
        }
        finally
        {
            if (conection != null)
            {
                conection.Close();
            }
        }
    }
}
