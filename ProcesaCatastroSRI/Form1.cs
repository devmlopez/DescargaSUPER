using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcesaCatastroSRI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Timer _timer;
        decimal registrosprocesados = 0;
        decimal totaleslineas = 0;
        string rutaarchivo = "";
        string nombrearchivo = "";
        string rutafull = "";

        public void AbrirArchivo()
        {
            try
            {

                txtrutaarchivo.Text = "";
                txtrutaarchivo.Text = "";

                OpenFileDialog od = new OpenFileDialog();
                var d = od.ShowDialog();
                if (d.Equals(DialogResult.OK))
                {
                    rutafull = od.FileName;
                    rutaarchivo = rutafull;
                    nombrearchivo = rutaarchivo.Split('\\').LastOrDefault();
                    rutaarchivo = rutaarchivo.Replace(nombrearchivo, "");
                    txtrutaarchivo.Text = rutaarchivo;
                    textBox2.Text = nombrearchivo;
                }
            }
            catch (Exception exc)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IniciarTimer();
        }
        public void IniciarTimer()
        {
            _timer = new Timer();
            _timer.Interval = 50;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            lblcontadorlineasprocesadas.Text = registrosprocesados.ToString("0") + "/" + totaleslineas.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var lines = (string[])e.Argument;
            registrosprocesados = 0;

            bool ret = false;
            string strinconecctioncontribuyente = @"C:\DescargaInfoSuper\ProcesaCatastroSRI\base de datos\contribuyentes.mdb";
            OdbcConnection conncontribuyente = new OdbcConnection(Getstringconnection(strinconecctioncontribuyente));
           //  DataSet ds = new DataSet();
            conncontribuyente.Open();
            try
            {
                bool esprimerafila = false;
                int ORDEN = 1;
                foreach (var linea in lines)
                {
                   

                    if (esprimerafila == false)
                    {
                        esprimerafila = true;
                    }
                    else
                    {
                        ClassCatastro obj = new ClassCatastro(linea);
                        
                        obj.ORDEN = ORDEN++;
                        #region INSERT CONTRIBUYENTE
                        string sql = "insert into tbl_contribuyente (UIDCONTRIBUYENTE,ORDEN,NUMERO_RUC,RAZON_SOCIAL,NOMBRE_COMERCIAL,ESTADO_CONTRIBUYENTE,CLASE_CONTRIBUYENTE,FECHA_INICIO_ACTIVIDADES,FECHA_ACTUALIZACION,FECHA_SUSPENSION_DEFINITIVA,FECHA_REINICIO_ACTIVIDADES,OBLIGADO,TIPO_CONTRIBUYENTE,NUMERO_ESTABLECIMIENTO,NOMBRE_FANTASIA_COMERCIAL,CALLE,NUMERO,INTERSECCION,ESTADO_ESTABLECIMIENTO,DESCRIPCION_PROVINCIA,DESCRIPCION_CANTON,DESCRIPCION_PARROQUIA,CODIGO_CIIU,ACTIVIDAD_ECONOMICA) ";
                        sql += " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";


                        using (OdbcCommand cmd_contribuyente = new OdbcCommand(sql, conncontribuyente))
                        {

                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@UIDCONTRIBUYENTE", Value = obj.UIDCONTRIBUYENTE, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@ORDEN", Value = obj.ORDEN, Direction = ParameterDirection.Input, OdbcType = OdbcType.Int });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@NUMERO_RUC", Value = obj.NUMERO_RUC, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@RAZON_SOCIAL", Value = obj.RAZON_SOCIAL, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@NOMBRE_COMERCIAL", Value = obj.NOMBRE_COMERCIAL, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@ESTADO_CONTRIBUYENTE", Value = obj.ESTADO_CONTRIBUYENTE, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@CLASE_CONTRIBUYENTE", Value = obj.CLASE_CONTRIBUYENTE, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@FECHA_INICIO_ACTIVIDADES", Value = obj.FECHA_INICIO_ACTIVIDADES, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@FECHA_ACTUALIZACION", Value = obj.FECHA_ACTUALIZACION, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@FECHA_SUSPENSION_DEFINITIVA", Value = obj.FECHA_SUSPENSION_DEFINITIVA, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@FECHA_REINICIO_ACTIVIDADES", Value = obj.FECHA_REINICIO_ACTIVIDADES, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@OBLIGADO", Value = obj.OBLIGADO, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@TIPO_CONTRIBUYENTE", Value = obj.TIPO_CONTRIBUYENTE, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@NUMERO_ESTABLECIMIENTO", Value = obj.NUMERO_ESTABLECIMIENTO, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@NOMBRE_FANTASIA_COMERCIAL", Value = obj.NOMBRE_FANTASIA_COMERCIAL, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@CALLE", Value = obj.CALLE, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@NUMERO", Value = obj.NUMERO, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@INTERSECCION", Value = obj.INTERSECCION, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@ESTADO_ESTABLECIMIENTO", Value = obj.ESTADO_ESTABLECIMIENTO, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@DESCRIPCION_PROVINCIA", Value = obj.DESCRIPCION_PROVINCIA, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@DESCRIPCION_CANTON", Value = obj.DESCRIPCION_CANTON, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@DESCRIPCION_PARROQUIA", Value = obj.DESCRIPCION_PARROQUIA, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@CODIGO_CIIU", Value = obj.CODIGO_CIIU, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });
                            cmd_contribuyente.Parameters.Add(new OdbcParameter() { ParameterName = "@ACTIVIDAD_ECONOMICA", Value = obj.ACTIVIDAD_ECONOMICA, Direction = ParameterDirection.Input, OdbcType = OdbcType.Text });

                            ret = cmd_contribuyente.ExecuteNonQuery() > 0;

                            cmd_contribuyente.Dispose();
                        }
                        #endregion
                    }
                    registrosprocesados++;
                }
            }
            catch (Exception exc)
            {
                ret = false;
            }
            finally
            {
                conncontribuyente.Close();
            }

        }


        public string Getstringconnection(string nombrebasedatos)
        {
            string value = "Driver={Microsoft Access Driver (*.mdb)};DBQ=@nombrebasedatos;";//ConfigurationManager.AppSettings["connectionstring"];
            value = value.Replace("@nombrebasedatos", nombrebasedatos);
            return value;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var lines = File.ReadAllLines(rutafull);
                totaleslineas = lines.Count();
                backgroundWorker1.RunWorkerAsync(lines);
            }
            catch (Exception exc)
            {

            }
        }
    }
}
