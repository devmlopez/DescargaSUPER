using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibIntuito
{
    public class SqlAccess
    {
        public static string EncriptarTexo(string value)
        {
            string encriptar = ConfigurationManager.AppSettings["encriptar"];
            bool seencripta = true;
            seencripta = ((encriptar + "").ToUpper() == "FALSE" ? false : true);

            if (seencripta)
            {
                return CLR_UTIL.Encriptacion.MetodosEncriptacion.MD5Crypto_Encriptar(value, "super12345");
            }
            else
            {
                return value;
            }


            //  return value;
        }
        public static string DesencriptarTexo(string value)
        {
          return CLR_UTIL.Encriptacion.MetodosEncriptacion.MD5Crypto_Desencriptar(value, "super12345");
         }
        // static string stringconnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbruntax.accdb;Persist Security Info=True;Password=runtax$2020;";
        public static string Getstringconnection(string nombrebasedatos)
        {
            string value = ConfigurationManager.AppSettings["connectionstring"];
            value = value.Replace("@nombrebasedatos", nombrebasedatos);
            return value;
        }
        public static bool EstaConectado(string nombrebasedatos)
        {
            bool ret = false;
            try
            {
                OdbcConnection conn = new OdbcConnection(Getstringconnection(nombrebasedatos));
                //  String connection = stringconnection;
                string sql = "SELECT *  FROM tbl_registro";
                //   conn.ConnectionString = connection;
                conn.Open();
                DataSet ds = new DataSet();
                OdbcDataAdapter adapter = new OdbcDataAdapter(sql, conn);
                adapter.Fill(ds);
                ret = (ds.Tables.Count > 0);
            }
            catch (Exception exc)
            {
                ret = false;
            }
            return ret;
        }

        public static bool AgregarRegistro(InfoGeneralCompania obj, string nombrebasedatos)
        {
            bool ret = false;
            OdbcConnection conn = new OdbcConnection(Getstringconnection(nombrebasedatos));
            try
            {
                string sql = "insert into tbl_registro (a_ig_Expediente,b_ig_RazonSocial,b_ig_NombreComercial,c_ig_Ruc,d_ig_FechadeConstitucion,e_ig_Nacionalidad,f_ig_PlazoSocial,g_ig_TipoCompania,h_ig_OficinadeControl,i_ig_SituacionLegal,j_ubi_Provincia,k_ubi_Canton,l_ubi_Ciudad,m_ubi_Parroquia,n_ubi_Calle,o_ubi_Numero,p_ubi_Interseccion,q_ubi_Ciudadela,r_ubi_Conjunto,ra_ubi_Edificio_CentroComercial,s_ubi_Barrio,t_ubi_km,u_ubi_Camino,v_ubi_Piso,w_ubi_Bloque,x_ubi_ReferenciaUbicacion,y_cont_CasilleroPostal,z_cont_Celular,za_cont_Fax,zb_cont_Telefono1,zc_cont_Telefono2,zd_cont_SitioWeb,ze_cont_Correo1,zf_cont_Correo2,fechacreacion) ";
                sql += " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                conn.Open();
                DataSet ds = new DataSet();
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@a_ig_Expediente", Direction = ParameterDirection.Input, OdbcType = OdbcType.Int, Value = Convert.ToInt32("0" + obj.a_ig_Expediente) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@b_ig_RazonSocial", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.b_ig_RazonSocial) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@b_ig_NombreComercial", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.b_ig_NombreComercial) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@c_ig_Ruc", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.c_ig_Ruc) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@d_ig_FechadeConstitucion", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.d_ig_FechadeConstitucion) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@e_ig_Nacionalidad", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.e_ig_Nacionalidad) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@f_ig_PlazoSocial", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.f_ig_PlazoSocial) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@g_ig_TipoCompania", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.g_ig_TipoCompania) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@h_ig_OficinadeControl", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.h_ig_OficinadeControl) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@i_ig_SituacionLegal", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.i_ig_SituacionLegal) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@j_ubi_Provincia", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.j_ubi_Provincia) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@k_ubi_Canton", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.k_ubi_Canton) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@l_ubi_Ciudad", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.l_ubi_Ciudad) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@m_ubi_Parroquia", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.m_ubi_Parroquia) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@n_ubi_Calle", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.n_ubi_Calle) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@o_ubi_Numero", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.o_ubi_Numero) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@p_ubi_Interseccion", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.p_ubi_Interseccion) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@q_ubi_Ciudadela", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.q_ubi_Ciudadela) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@r_ubi_Conjunto", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.r_ubi_Conjunto) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@ra_ubi_Edificio_CentroComercial", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.ra_ubi_Edificio_CentroComercial) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@s_ubi_Barrio", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.s_ubi_Barrio) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@t_ubi_km", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.t_ubi_km) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@u_ubi_Camino", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.u_ubi_Camino) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@v_ubi_Piso", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.v_ubi_Piso) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@w_ubi_Bloque", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.w_ubi_Bloque) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@x_ubi_ReferenciaUbicacion", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.x_ubi_ReferenciaUbicacion) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@y_cont_CasilleroPostal", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.y_cont_CasilleroPostal) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@z_cont_Celular", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.z_cont_Celular) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@za_cont_Fax", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.za_cont_Fax) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@zb_cont_Telefono1", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.zb_cont_Telefono1) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@zc_cont_Telefono2", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.zc_cont_Telefono2) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@zd_cont_SitioWeb", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.zd_cont_SitioWeb) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@ze_cont_Correo1", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.ze_cont_Correo1) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@zf_cont_Correo2", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = EncriptarTexo(obj.zf_cont_Correo2) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@fechacreacion", Direction = ParameterDirection.Input, OdbcType = OdbcType.DateTime, Value = DateTime.Now });
                ret = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception exc)
            {
                ret = false;
            }
            finally
            {
                conn.Close();
            }
            return ret;

        }

        public static bool ModificarRegistro(InfoGeneralCompania obj, string nombrebasedatos)
        {
            bool ret = false;
            OdbcConnection conn = new OdbcConnection(Getstringconnection(nombrebasedatos));
            try
            {
                string sql = "update tbl_registro ";
                sql += " set b_ig_RazonSocial=?,";
                sql += "  b_ig_NombreComercial=?,";
                sql += "  c_ig_Ruc=?,";
                sql += "  d_ig_FechadeConstitucion=?,";
                sql += "  e_ig_Nacionalidad=?,";
                sql += "  f_ig_PlazoSocial=?,";
                sql += "  g_ig_TipoCompania=?,";
                sql += "  h_ig_OficinadeControl=?,";
                sql += "  i_ig_SituacionLegal=?,";
                sql += "  j_ubi_Provincia=?,";
                sql += "  k_ubi_Canton=?,";
                sql += "  l_ubi_Ciudad=?,";
                sql += "  m_ubi_Parroquia=?,";
                sql += "  n_ubi_Calle=?,";
                sql += "  o_ubi_Numero=?,";
                sql += "  p_ubi_Interseccion=?,";
                sql += "  q_ubi_Ciudadela=?,";
                sql += "  r_ubi_Conjunto=?,";
                sql += "  ra_ubi_Edificio_CentroComercial=?,";
                sql += "  s_ubi_Barrio=?,";
                sql += "  t_ubi_km=?,";
                sql += "  u_ubi_Camino=?,";
                sql += "  v_ubi_Piso=?,";
                sql += "  w_ubi_Bloque=?,";
                sql += "  x_ubi_ReferenciaUbicacion=?,";
                sql += "  y_cont_CasilleroPostal=?,";
                sql += "  z_cont_Celular=?,";
                sql += "  za_cont_Fax=?,";
                sql += "  zb_cont_Telefono1=?,";
                sql += "  zc_cont_Telefono2=?,";
                sql += "  zd_cont_SitioWeb=?,";
                sql += "  ze_cont_Correo1=?,";
                sql += "  zf_cont_Correo2=?,";   
                sql += "  sedecodifico=?    where a_ig_Expediente=" + obj.a_ig_Expediente;

                conn.Open();
                DataSet ds = new DataSet();
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                //  cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@a_ig_Expediente", Direction = ParameterDirection.Input, OdbcType = OdbcType.Int, Value = Convert.ToInt32("0" + obj.a_ig_Expediente) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@b_ig_RazonSocial", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.b_ig_RazonSocial) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@b_ig_NombreComercial", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.b_ig_NombreComercial) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@c_ig_Ruc", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.c_ig_Ruc) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@d_ig_FechadeConstitucion", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.d_ig_FechadeConstitucion) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@e_ig_Nacionalidad", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.e_ig_Nacionalidad) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@f_ig_PlazoSocial", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.f_ig_PlazoSocial) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@g_ig_TipoCompania", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.g_ig_TipoCompania) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@h_ig_OficinadeControl", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.h_ig_OficinadeControl) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@i_ig_SituacionLegal", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.i_ig_SituacionLegal) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@j_ubi_Provincia", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.j_ubi_Provincia) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@k_ubi_Canton", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.k_ubi_Canton) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@l_ubi_Ciudad", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.l_ubi_Ciudad) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@m_ubi_Parroquia", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.m_ubi_Parroquia) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@n_ubi_Calle", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.n_ubi_Calle) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@o_ubi_Numero", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.o_ubi_Numero) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@p_ubi_Interseccion", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.p_ubi_Interseccion) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@q_ubi_Ciudadela", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.q_ubi_Ciudadela) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@r_ubi_Conjunto", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.r_ubi_Conjunto) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@ra_ubi_Edificio_CentroComercial", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.ra_ubi_Edificio_CentroComercial) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@s_ubi_Barrio", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.s_ubi_Barrio) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@t_ubi_km", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.t_ubi_km) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@u_ubi_Camino", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.u_ubi_Camino) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@v_ubi_Piso", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.v_ubi_Piso) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@w_ubi_Bloque", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.w_ubi_Bloque) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@x_ubi_ReferenciaUbicacion", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.x_ubi_ReferenciaUbicacion) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@y_cont_CasilleroPostal", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.y_cont_CasilleroPostal) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@z_cont_Celular", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.z_cont_Celular) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@za_cont_Fax", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.za_cont_Fax) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@zb_cont_Telefono1", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.zb_cont_Telefono1) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@zc_cont_Telefono2", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.zc_cont_Telefono2) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@zd_cont_SitioWeb", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.zd_cont_SitioWeb) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@ze_cont_Correo1", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.ze_cont_Correo1) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@zf_cont_Correo2", Direction = ParameterDirection.Input, OdbcType = OdbcType.Text, Value = DesencriptarTexo(obj.zf_cont_Correo2) });
                cmd.Parameters.Add(new OdbcParameter() { ParameterName = "@sedecodifico", Direction = ParameterDirection.Input, OdbcType = OdbcType.Bit, Value = obj.sedecodifico });
                ret = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception exc)
            {
                ret = false;

                Console.WriteLine("error: "+ exc.Message);
            }
            finally
            {
                conn.Close();
            }
            return ret;

        }

        public static List<InfoGeneralCompania> SelectTodo(string nombrebasedatos)
        {

            List<InfoGeneralCompania> ret = new List<InfoGeneralCompania>();
            OdbcConnection conn = new OdbcConnection(Getstringconnection(nombrebasedatos));
            try
            {
                string sql = "select * from tbl_registro  where sedecodifico=0";
                DataSet ds = new DataSet();
                conn.Open();
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(ds);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        foreach (var item in ds.Tables[0].AsEnumerable())
                        {
                            try
                            {
                                ret.Add(new InfoGeneralCompania()
                                {
                                    a_ig_Expediente = Convert.ToString(item.Field<int>("a_ig_Expediente")),
                                    b_ig_RazonSocial = item.Field<string>("b_ig_RazonSocial"),
                                    b_ig_NombreComercial = item.Field<string>("b_ig_NombreComercial"),
                                    c_ig_Ruc = item.Field<string>("c_ig_Ruc"),
                                    d_ig_FechadeConstitucion = item.Field<string>("d_ig_FechadeConstitucion"),
                                    e_ig_Nacionalidad = item.Field<string>("e_ig_Nacionalidad"),
                                    f_ig_PlazoSocial = item.Field<string>("f_ig_PlazoSocial"),
                                    g_ig_TipoCompania = item.Field<string>("g_ig_TipoCompania"),
                                    h_ig_OficinadeControl = item.Field<string>("h_ig_OficinadeControl"),
                                    i_ig_SituacionLegal = item.Field<string>("i_ig_SituacionLegal"),
                                    j_ubi_Provincia = item.Field<string>("j_ubi_Provincia"),
                                    k_ubi_Canton = item.Field<string>("k_ubi_Canton"),
                                    l_ubi_Ciudad = item.Field<string>("l_ubi_Ciudad"),
                                    m_ubi_Parroquia = item.Field<string>("m_ubi_Parroquia"),
                                    n_ubi_Calle = item.Field<string>("n_ubi_Calle"),
                                    o_ubi_Numero = item.Field<string>("o_ubi_Numero"),
                                    p_ubi_Interseccion = item.Field<string>("p_ubi_Interseccion"),
                                    q_ubi_Ciudadela = item.Field<string>("q_ubi_Ciudadela"),
                                    r_ubi_Conjunto = item.Field<string>("r_ubi_Conjunto"),
                                    ra_ubi_Edificio_CentroComercial = item.Field<string>("ra_ubi_Edificio_CentroComercial"),
                                    s_ubi_Barrio = item.Field<string>("s_ubi_Barrio"),
                                    t_ubi_km = item.Field<string>("t_ubi_km"),
                                    u_ubi_Camino = item.Field<string>("u_ubi_Camino"),
                                    v_ubi_Piso = item.Field<string>("v_ubi_Piso"),
                                    w_ubi_Bloque = item.Field<string>("w_ubi_Bloque"),
                                    x_ubi_ReferenciaUbicacion = item.Field<string>("x_ubi_ReferenciaUbicacion"),
                                    y_cont_CasilleroPostal = item.Field<string>("y_cont_CasilleroPostal"),
                                    z_cont_Celular = item.Field<string>("z_cont_Celular"),
                                    za_cont_Fax = item.Field<string>("za_cont_Fax"),
                                    zb_cont_Telefono1 = item.Field<string>("zb_cont_Telefono1"),
                                    zc_cont_Telefono2 = item.Field<string>("zc_cont_Telefono2"),
                                    zd_cont_SitioWeb = item.Field<string>("zd_cont_SitioWeb"),
                                    ze_cont_Correo1 = item.Field<string>("ze_cont_Correo1"),
                                    zf_cont_Correo2 = item.Field<string>("zf_cont_Correo2"),
                                    // fechacreacion = item.Field<string>("fechacreacion"),
                                    sedecodifico = item.Field<bool>("sedecodifico"),
                                });
                            }catch(Exception exc)
                            {

                            }
                        }
                    }
                }


            }
            catch (Exception exc)
            {

            }
            finally
            {
                conn.Close();
            }
            return ret;

        }


        /// <summary>
        /// Consulta de todos los registros de la base de datos de access de las empresas sin filtros
        /// </summary>
        /// <param name="nombrebasedatos"></param>
        /// <returns></returns>
        public static List<InfoGeneralCompania> Selectall(string nombrebasedatos)
        {

            List<InfoGeneralCompania> ret = new List<InfoGeneralCompania>();
            OdbcConnection conn = new OdbcConnection(Getstringconnection(nombrebasedatos));
            try
            {
                string sql = "select * from tbl_registro";
                DataSet ds = new DataSet();
                conn.Open();
                OdbcCommand cmd = new OdbcCommand(sql, conn);
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(ds);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        foreach (var item in ds.Tables[0].AsEnumerable())
                        {
                            try
                            {
                                ret.Add(new InfoGeneralCompania()
                                {
                                    a_ig_Expediente = Convert.ToString(item.Field<int>("a_ig_Expediente")),
                                    b_ig_RazonSocial = item.Field<string>("b_ig_RazonSocial"),
                                    b_ig_NombreComercial = item.Field<string>("b_ig_NombreComercial"),
                                    c_ig_Ruc = item.Field<string>("c_ig_Ruc"),
                                    d_ig_FechadeConstitucion = item.Field<string>("d_ig_FechadeConstitucion"),
                                    e_ig_Nacionalidad = item.Field<string>("e_ig_Nacionalidad"),
                                    f_ig_PlazoSocial = item.Field<string>("f_ig_PlazoSocial"),
                                    g_ig_TipoCompania = item.Field<string>("g_ig_TipoCompania"),
                                    h_ig_OficinadeControl = item.Field<string>("h_ig_OficinadeControl"),
                                    i_ig_SituacionLegal = item.Field<string>("i_ig_SituacionLegal"),
                                    j_ubi_Provincia = item.Field<string>("j_ubi_Provincia"),
                                    k_ubi_Canton = item.Field<string>("k_ubi_Canton"),
                                    l_ubi_Ciudad = item.Field<string>("l_ubi_Ciudad"),
                                    m_ubi_Parroquia = item.Field<string>("m_ubi_Parroquia"),
                                    n_ubi_Calle = item.Field<string>("n_ubi_Calle"),
                                    o_ubi_Numero = item.Field<string>("o_ubi_Numero"),
                                    p_ubi_Interseccion = item.Field<string>("p_ubi_Interseccion"),
                                    q_ubi_Ciudadela = item.Field<string>("q_ubi_Ciudadela"),
                                    r_ubi_Conjunto = item.Field<string>("r_ubi_Conjunto"),
                                    ra_ubi_Edificio_CentroComercial = item.Field<string>("ra_ubi_Edificio_CentroComercial"),
                                    s_ubi_Barrio = item.Field<string>("s_ubi_Barrio"),
                                    t_ubi_km = item.Field<string>("t_ubi_km"),
                                    u_ubi_Camino = item.Field<string>("u_ubi_Camino"),
                                    v_ubi_Piso = item.Field<string>("v_ubi_Piso"),
                                    w_ubi_Bloque = item.Field<string>("w_ubi_Bloque"),
                                    x_ubi_ReferenciaUbicacion = item.Field<string>("x_ubi_ReferenciaUbicacion"),
                                    y_cont_CasilleroPostal = item.Field<string>("y_cont_CasilleroPostal"),
                                    z_cont_Celular = item.Field<string>("z_cont_Celular"),
                                    za_cont_Fax = item.Field<string>("za_cont_Fax"),
                                    zb_cont_Telefono1 = item.Field<string>("zb_cont_Telefono1"),
                                    zc_cont_Telefono2 = item.Field<string>("zc_cont_Telefono2"),
                                    zd_cont_SitioWeb = item.Field<string>("zd_cont_SitioWeb"),
                                    ze_cont_Correo1 = item.Field<string>("ze_cont_Correo1"),
                                    zf_cont_Correo2 = item.Field<string>("zf_cont_Correo2"),
                                    // fechacreacion = item.Field<string>("fechacreacion"),
                                 //   sedecodifico = item.Field<bool>("sedecodifico"),
                                });
                            }
                            catch (Exception exc)
                            {

                            }
                        }
                    }
                }


            }
            catch (Exception exc)
            {

            }
            finally
            {
                conn.Close();
            }
            return ret;

        }

        public static bool ExisteRegistro(string a_ig_Expediente, string nombrebasedatos)
        {
            bool ret = false;
            OdbcConnection conn = new OdbcConnection(Getstringconnection(nombrebasedatos));
            try
            {
                string sql = "select * from  tbl_registro ";
                sql += " where a_ig_Expediente=?";
                conn.Open();
                DataSet ds = new DataSet();
                OdbcCommand cmd = new OdbcCommand(sql, conn);

                cmd.Parameters.Add(new OdbcParameter()
                {
                    ParameterName = "@a_ig_Expediente",
                    Direction = ParameterDirection.Input,
                    OdbcType = OdbcType.Text,
                    Value = a_ig_Expediente
                });
                OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    ret = ds.Tables[0].Rows.Count > 0;
                }
            }
            catch (Exception exc)
            {
                ret = false;
            }
            finally
            {
                conn.Close();
            }
            return ret;
        }

    }
}
