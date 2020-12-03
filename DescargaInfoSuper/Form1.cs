using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using System.IO;
using LibIntuito;

namespace DescargaInfoIntuito
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            iniciarTimer();

        }
        int milisegundosTranscurrido = 0;

        Timer _timer;

        Timer _timerIniciaSitio;

        public void iniciarTimer()
        {

            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += _timer_Tick;
          

          _timerIniciaSitio = new Timer();
            _timerIniciaSitio.Interval = 200;
            _timerIniciaSitio.Tick += _timerIniciaSitio_Tick;
        }
        bool seIngresandoAlsitio = false; bool seIngresoAlsitio = false;
        bool seAbriendoElPanel = false; bool seAbrioElPanel = false;
        bool seguardandoLaData = false; bool seguardoLaData = false;

        int reintentosCargaSitiomaximo = 5;
        int reintentosCargaSitio = 0;


        int reintentosAbrirPanelmaximo = 10;
        int reintentosAbrirPanel = 0;

        private void _timer_Tick(object sender, EventArgs e)
        {
            bool ExisteRegistro = SqlAccess.ExisteRegistro("" + index.ToString(), nombrebasedatos);
            if (ExisteRegistro == false)
            {

             if (SeCargoconErrorLapagina()==true)
            {
                    reintentosCargaSitio++;

                if (reintentosCargaSitio > reintentosCargaSitiomaximo)
                {
                        reintentosCargaSitio = 0;
                    index++;
                }
                seIngresoAlsitio = false;
                seAbrioElPanel = false;
                seguardoLaData = false;

                seIngresandoAlsitio = false;
                seAbriendoElPanel = false;
                seguardandoLaData = false;
            }else
            {
                    reintentosCargaSitio = 0;
            }

                if (seIngresandoAlsitio == true && seIngresoAlsitio == false)  // && seAbrioElPanel == false && seguardoLaData == false)
                {
                    var SeCargolapagina = SeingresoAlaPagina();
                    if (SeCargolapagina == true)
                    {
                        seIngresoAlsitio = true;
                        seAbrioElPanel = false;
                        seguardoLaData = false;

                        seIngresandoAlsitio = true;
                        seAbriendoElPanel = false;
                        seguardandoLaData = false;

                    }
                    else
                    {
                        //seIngresoAlsitio = false;
                        //seAbrioElPanel = false;
                        //seguardoLaData = false;

                        //seIngresandoAlsitio = false;
                        //seAbriendoElPanel = false;
                        //seguardandoLaData = false;
                    }
              
            }

            if (seIngresandoAlsitio==true && seIngresoAlsitio == true && 
                    seAbriendoElPanel==true && seAbrioElPanel == false)
            {
                var SeCargoelpanel = SeabrioelPanel();
                if (SeCargoelpanel == true)
                {
                    seIngresoAlsitio = true;
                    seAbrioElPanel = true;
                    seguardoLaData = false;


                    seIngresandoAlsitio = true;
                    seAbriendoElPanel = true;
                    seguardandoLaData = false;

                        reintentosAbrirPanel = 0;
                    }
                else
                {

                        reintentosAbrirPanel++;

                            if (reintentosAbrirPanel > reintentosAbrirPanelmaximo)
                            {
                            reintentosAbrirPanel = 0;
                            seIngresoAlsitio = true;
                            seAbrioElPanel = false;
                            seguardoLaData = false;

                            seIngresandoAlsitio = true;
                            seAbriendoElPanel = false;
                            seguardandoLaData = false;
                          // index++;
                            }
                         
                        

                    }
                }
            }

        }

        private void _timerIniciaSitio_Tick(object sender, EventArgs e)
        {
            NombreFormulario();
            string IndexScriptEjecutar = index.ToString();
            if (index > fin)
            {
                CerrarPrograma = true;
                _timerIniciaSitio.Stop();
                this.Close();
            }

            int MilisegundosEsperarConsultaregistro = Convert.ToInt32(ConfigurationManager.AppSettings["MilisegundosEsperarConsultaregistro"]);
            int MilisegundosAbrirModal = MilisegundosEsperarConsultaregistro + Convert.ToInt32(ConfigurationManager.AppSettings["MilisegundosAbrirModal"]);
            int MilisegundosEsperarExtraerDatos = MilisegundosAbrirModal + Convert.ToInt32(ConfigurationManager.AppSettings["MilisegundosEsperarExtraerDatos"]);

            _timerIniciaSitio.Stop();

            bool ExisteRegistro = SqlAccess.ExisteRegistro("" + IndexScriptEjecutar.ToString(), nombrebasedatos);
            if (ExisteRegistro == false)
            {
                if (seIngresandoAlsitio == false && seIngresoAlsitio == false)
                {
                    seIngresandoAlsitio = true;
                    Consultarregistros(ExisteRegistro);
                }


                if (seIngresandoAlsitio == true && seIngresoAlsitio == true && seAbriendoElPanel == false &&  seAbrioElPanel == false)
                {
                    // seIngresandoAlsitio = true;
                    seAbriendoElPanel = true;
                    AbrirModalDatos();
                }

                if (seIngresandoAlsitio == true && seIngresoAlsitio == true && seAbriendoElPanel == true && seAbrioElPanel == true)
                {
                    //  _timer.Stop();
                    seguardandoLaData = true;
                    ExtraerDatos();
                    seIngresoAlsitio = false;
                    seAbrioElPanel = false;
                    seguardoLaData = false;

                    seIngresandoAlsitio = false;
                    seAbriendoElPanel = false;
                    seguardandoLaData = false;

                    //  _timer.Start();
                    //  index++;
                }
            }
            else
            {
                index++;
            }

            _timerIniciaSitio.Start();


            txtexpedienteActual.Text = IndexScriptEjecutar;

        }

        public Form1(string inicio, string fin, string nombrebasedatos)
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            txtInicial.Text = inicio;
            txtFinal.Text = fin;
            this.nombrebasedatos = nombrebasedatos;
            CrearBaseDatos(nombrebasedatos);
            iniciarTimer();
            webBrowser1.Visible = ((ConfigurationManager.AppSettings["visiblenavegador"] + "").ToUpper() == "TRUE");
        }
        public Form1(string[] args)
        {
            try
            {
                if (args != null && args.Count() >= 2)
                {
                    string inicio = args[0];
                    string fin = args[1];
                    nombrebasedatos = args[2];

                    CrearBaseDatos(nombrebasedatos);
                    InitializeComponent();
                    webBrowser1.ScriptErrorsSuppressed = true;
                    txtInicial.Text = inicio;
                    txtFinal.Text = fin;

                    iniciarTimer();
                    Iniciar();

                    webBrowser1.Visible = ((ConfigurationManager.AppSettings["visiblenavegador"] + "").ToUpper() == "TRUE");
                }
            }
            catch (Exception exc)
            {
                Mensaje(exc);
            }
        }
        public void Mensaje(Exception exc)
        {
            if (exc != null)
            {
                //  MessageBox.Show("ERROR: "+exc.Message+ "| Pilas:" +exc.StackTrace);
            }
        }
        public void CrearBaseDatos(string nombrebasedatosnueva)
        {
            // MessageBox.Show("Iniciamos creacion de base de datos["+nombrebasedatos+"]");
            nombrebasedatosnueva = nombrebasedatosnueva + ".mdb";

            if (nombrebasedatosnueva.Replace(".mdb", "").Trim().Count() > 0)
            {
                string nombrebasedatosbase = Application.StartupPath + "\\" + "base.mdb";
                //  nombrebasedatosbase = @"C:\DescargaInfoIntuito\DescargaMasivaInfoSuper\bin\Debug\Ejecutar\base.mdb";

                //   MessageBox.Show("En proceso creacion de base de datos[Existe Origen =" + nombrebasedatosbase+ " " + File.Exists(nombrebasedatosbase) + " Existe destino=" + File.Exists(nombrebasedatosnueva) + "]");
                if (File.Exists(nombrebasedatosbase))
                {

                    if (!File.Exists(nombrebasedatosnueva))
                    {
                        File.Copy(nombrebasedatosbase, nombrebasedatosnueva);
                    }
                }
            }
            else
            {
                //  this.Close();
            }
            //MessageBox.Show("Finalizamos creacion de base de datos[Existe Origen =" + File.Exists("base.mdb") + " Existe destino="+ File.Exists(nombrebasedatosnueva) + "]");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NombreFormulario();
        }
        public void NombreFormulario()
        {
            this.Text = "" + inicio.ToString() + "-" + fin.ToString() + " [" + (index - inicio).ToString() + "/" + index.ToString() + "]";
        }
        public bool GetCerrarPrograma()
        {
            return index > fin;
        }
        int ordenejecucion = 0;
        string nombrebasedatos = "";
       
       int inicio = 0;
        int fin = 0;
        int index = 0;

        public bool? SeingresoAlaPagina()
        {
            bool? ret = null;
            string html = "";

            int reintentos = 1;
            while (true) 
            { 
                html = ObtenercodigoHTML();

                if(html.Contains("class=texto>Información General</DIV>") == true)
                {
                    ret = true;
                    break;
                } else
                if (reintentos <= 0) {
                   
                    ret = false;
                    break;
                }
                System.Threading.Thread.Sleep(100);
                reintentos--;
            }
            return ret;
        }

        public bool? SeCargoconErrorLapagina()
        {
            bool? ret = null;
            string html = "";

            int reintentos = 1;
            while (true)
            {
                html = ObtenercodigoHTML();

                if (html.Contains(">PORTAL DE INFORMACIÓN</SPAN>") == true ||
                    html.Contains("Error 503") == true)
                {
                    ret = true;
                    break;
                }
                else
                if (reintentos <= 0)
                {

                    ret = false;
                    break;
                }
                System.Threading.Thread.Sleep(100);
                reintentos--;
            }
             
            return ret;
        }
        public bool? SeabrioelPanel()
        {
            bool? ret = null;
            string html = "";

            int reintentos = 1;
            while (true)
            {
                html = ObtenercodigoHTML();

                if (html.Contains(">INFORMACIÓN GENERAL DE LA COMPAÑÍA</SPAN>") == true)
                {
                    ret = true;
                    break;
                }
                else
                if (reintentos <= 0)
                {
                  //  System.Threading.Thread.Sleep(500);
                    ret = false;
                    break;
                }
                System.Threading.Thread.Sleep(100);
                reintentos--;
            }
            return ret;
        }  
        bool BloquearProcesos = false;
        public void Consultarregistros(bool ExisteRegistro)
        {
            try
            {
                string IndexScriptEjecutar = index.ToString();
                webBrowser1.Navigate("https://appscvsmovil.supercias.gob.ec/portaldeinformacion/consulta_cia_menu.zul?expediente=" + IndexScriptEjecutar + "&tipo=1");
                   
            }
            catch (Exception exc)
            {
                Mensaje(exc);
            }
        }
        bool CerrarPrograma = false;
        public void AbrirModalDatos()
        {
            string script = ""; // "$('#'+$(' a[class=m_iconos]:eq(1)').attr('id').substring(0, 4)+'e').click();";
            script = "document.getElementsByTagName('a')[0].click();";
            //  script = "alert('hello');";
          //  seAbriendoElPanel = true;
            EjecutarScript(script, 100);
        }  
        private void button2_Click(object sender, EventArgs e)
        {
            AbrirModalDatos();
        }   
        public string ObtenercodigoHTML()
        {
            string html = "";
            int cont = 5;
            while (string.IsNullOrEmpty(html))
            {
                cont--;
                html = GetHtml(); 
                if (string.IsNullOrEmpty(html))
                {
                   // int MilisegundosEsperarExtraerDatosDetectaHTML = Convert.ToInt32(ConfigurationManager.AppSettings["MilisegundosEsperarExtraerDatosDetectaHTML"]);
                    System.Threading.Thread.Sleep(500);
                }
                else
                {
                    break;
                }
                if (cont <= 0)
                {
                    break;
                }   
            }  
            return html;
        }
        public void ExtraerDatos()
        {
            try
            { 
                string html = ObtenercodigoHTML();
                if (html.Contains("INFORMACIÓN GENERAL DE LA COMPAÑÍA"))
                {
                    ProcesarPorExpediente(html, nombrebasedatos);
                    index++;
                  //  int MilisegundosEsperarExtraerDatos = Convert.ToInt32(ConfigurationManager.AppSettings["MilisegundosEsperarExtraerDatos"]);
                }
            }
            catch (Exception exc)
            {  
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ExtraerDatos();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Consultarregistros(false);
        }
        private static string StripHtml(string source)
        {
            string output;

            //get rid of HTML tags
            output = Regex.Replace(source, "<[^>]*>", string.Empty);

            //get rid of multiple blank lines
            output = Regex.Replace(output, @"^\s*$\n", string.Empty, RegexOptions.Multiline);

            return output;
        }
        public static string ExtraerInput(string html)
        {
            string tag = "<input";
            int indexInicio = html.IndexOf(tag);
            string acumulaTag = "";
            if (indexInicio >= 0)
            {
                for (int i = indexInicio; i < html.Count(); i++)
                {
                    acumulaTag += html[i];
                    if (html[i] == '>')
                    {
                        break;
                    }
                }
            }
            return acumulaTag;
        }
        public static List<string> GetInputTagEnHTML(string html)
        {
            List<string> ret = new List<string>();

            html = html.Replace("<INPUT", "<input");

            while (true)
            {
                string inputTag = ExtraerInput(html);

                if (string.IsNullOrEmpty(inputTag))
                {
                    break;
                }
                else
                {
                    if (!string.IsNullOrEmpty(inputTag))
                    {
                        html = html.Replace(inputTag, "");
                    }
                    if (inputTag.Contains("value=\""))
                    {
                        var a = (inputTag + "$");
                        var b = a.Replace("value=", "$");
                        var c = b.Split('$')[1];
                        var d = c.Replace("value=", "$");
                        var e = (d + "\"").Split('"')[1];
                        inputTag = e;
                        // ((inputTag + "$").Replace("value=", "$")).Split('$')[1].Split('"')[0];
                    }
                    else
                    if (inputTag.Contains("value="))
                    {
                        inputTag = ((inputTag + "$").Replace("value=", "$")).Split('$')[1].Split(' ')[0];
                    }
                    else
                    {
                        inputTag = "";
                    }

                    ret.Add(inputTag);
                }
            }
            return ret;
        }


        public void ProcesarPorExpediente(string html, string nombrebasedatos)
        {
            var Resultado = GetInputTagEnHTML(html);

            List<string> Values = new List<string>();
            foreach (var x in Resultado)
            {
                Values.Add(x);
            }
            if (Values.Count() >= 33)
            {
                string TextoHtml = StripHtml(html);
                var RazonSocial = (TextoHtml + "\n\n\n\n\n\n").Split('\n')[2];

                RazonSocial = RazonSocial.Trim();
                RazonSocial = (RazonSocial == "Información General" ? "" : RazonSocial);
                var obj = new InfoGeneralCompania();

                obj.b_ig_RazonSocial = RazonSocial;
                #region
                int index = 0;
                obj.a_ig_Expediente = Values[index]; index++;
                obj.b_ig_NombreComercial = Values[index]; index++;
                obj.c_ig_Ruc = Values[index]; index++;
                obj.d_ig_FechadeConstitucion = Values[index]; index++;
                obj.e_ig_Nacionalidad = Values[index]; index++;
                obj.f_ig_PlazoSocial = Values[index]; index++;
                obj.g_ig_TipoCompania = Values[index]; index++;
                obj.h_ig_OficinadeControl = Values[index]; index++;
                obj.i_ig_SituacionLegal = Values[index]; index++;
                obj.j_ubi_Provincia = Values[index]; index++;
                obj.k_ubi_Canton = Values[index]; index++;
                obj.l_ubi_Ciudad = Values[index]; index++;
                obj.m_ubi_Parroquia = Values[index]; index++;
                obj.n_ubi_Calle = Values[index]; index++;
                obj.o_ubi_Numero = Values[index]; index++;
                obj.p_ubi_Interseccion = Values[index]; index++;
                obj.q_ubi_Ciudadela = Values[index];
                ;
                obj.r_ubi_Conjunto = Values[index]; index++;
                obj.ra_ubi_Edificio_CentroComercial = Values[index]; index++;
                obj.s_ubi_Barrio = Values[index]; index++;
                obj.t_ubi_km = Values[index]; index++;
                obj.u_ubi_Camino = Values[index]; index++;
                obj.v_ubi_Piso = Values[index]; index++;
                obj.w_ubi_Bloque = Values[index]; index++;
                obj.x_ubi_ReferenciaUbicacion = Values[index]; index++;
                obj.y_cont_CasilleroPostal = Values[index]; index++;
                 obj.z_cont_Celular = Values[index]; index++;
                obj.za_cont_Fax = Values[index]; index++;
                obj.zb_cont_Telefono1 = Values[index]; index++;
                obj.zc_cont_Telefono2 = Values[index]; index++;
                obj.zd_cont_SitioWeb = Values[index]; index++;
                obj.ze_cont_Correo1 = Values[index]; index++;
                obj.zf_cont_Correo2 = Values[index]; index++;
                #endregion
                ActualizaDataExpedienteEnBD(obj, nombrebasedatos);
            }
        }

        public void EjecutarScript(string script, int milisegundosantesdeejecutar, bool esFuncionCSaharep = false)
        {
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    string nombrefuncion = Guid.NewGuid().ToString().Replace("-", "");
                    HtmlDocument doc = webBrowser1.Document;
                    HtmlElement head = doc.GetElementsByTagName("head")[0];
                    HtmlElement s = doc.CreateElement("script");
                    s.SetAttribute("text", "function " + nombrefuncion + "() { " + script + " }");
                    head.AppendChild(s);
                    webBrowser1.Document.InvokeScript(nombrefuncion);
                    System.Threading.Thread.Sleep(milisegundosantesdeejecutar);
                }
                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception exc)
            {
                Mensaje(exc);
            }
        }

        public string GetHtml()
        {
            string html = "";
            try
            {
                html = webBrowser1.Document.GetElementsByTagName("body")[0].InnerHtml;
            }
            catch (Exception exc)
            {
                Mensaje(exc);
            }
            return html;
        }
        public void ActualizaDataExpedienteEnBD(InfoGeneralCompania obj, string nombrebasedatos)
        {
            try
            {

                bool SeRegistro = SqlAccess.AgregarRegistro(obj, nombrebasedatos);

                if (SeRegistro)
                {

                }


            }
            catch (Exception exc)
            {
                Mensaje(exc);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Iniciar();
        }
        public void Iniciar()
        {
            try
            {
                _timerIniciaSitio.Start();
                _timer.Start();

                inicio = Convert.ToInt32(txtInicial.Text);
                fin = Convert.ToInt32(txtFinal.Text);
                index = inicio;
                BloquearProcesos = false;
                ordenejecucion = 0;
                CerrarPrograma = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error:" + exc.Message);
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            CerrarPrograma = true;
            _timerIniciaSitio.Stop();

        }
    }


}


