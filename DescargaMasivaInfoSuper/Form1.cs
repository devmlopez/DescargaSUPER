using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DescargaMasiva
{
    public partial class Form1 : Form
    {

        CLR_SAPA.SAPAServicesV100.UserSystem User { get; set; }
        public Form1()
        {
            InitializeComponent();
            VisiblePanelUsuario(false);
            progressPanel1.Visible = false;
        }
        public void EjecutarCMD(string command, bool EsperarQueTermineEjecucion = true)
        {
            // int exitCode;
            ProcessStartInfo processInfo;
            Process process;

        
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);

        
            

            if (EsperarQueTermineEjecucion == true)
            {
                process.WaitForExit();
                var output = process.StandardOutput.ReadToEnd();
            }  
            process.Close();
        }

        //public void EjecutarPrograma(string filename, string command, bool EsperarQueTermineEjecucion = true)
        //{

        //    Process.Start(filename, command);
            

        //    //// int exitCode;
        //    //ProcessStartInfo processInfo;
        //    //Process process;


        //    //processInfo = new ProcessStartInfo(filename,command);
        //    //processInfo.CreateNoWindow = false;
        //    //processInfo.UseShellExecute = false;
        //    //// *** Redirect the output ***
        //    //processInfo.RedirectStandardError = true;
        //    //processInfo.RedirectStandardOutput = true;

        //    //process = Process.Start(processInfo);




        //    ////if (EsperarQueTermineEjecucion == true)
        //    ////{
        //    ////    process.WaitForExit();
        //    ////    var output = process.StandardOutput.ReadToEnd();
        //    ////}
        //    //process.Close();
        //}

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                int inicio = Convert.ToInt32(txtInicial.Text);
                int fin = Convert.ToInt32(txtFinal.Text);
                int particiones = Convert.ToInt32(txtparticiones.Text);

                int cantidadporparticion = (fin - inicio + 1) / particiones;

                int auxinicial = inicio;
                int auxfinal = inicio + cantidadporparticion - 1;


                EjecutarCMD("taskkill /IM DescargaInfoIntuito.exe");

                string urlbase = Application.StartupPath;
                for (int i = 0; i < particiones; i++)
                {
                    string cmdejecutar = (urlbase + @"\Ejecutar\DescargaInfoIntuito.exe").Replace(" ", " ") + " " + auxinicial.ToString() + " " + auxfinal.ToString() + " " + txtnombrebasedatos.Text;
                     // string cmdejecutar = ("%MY_PATH%\""+ @"\Ejecutar\DescargaInfoIntuito.exe").Replace(" ", "%20") + " " + auxinicial.ToString() + " " + auxfinal.ToString() + " " + txtnombrebasedatos.Text;
                       EjecutarCMD(cmdejecutar, false);  
                  //  string argumentos = auxinicial.ToString() + " " + auxfinal.ToString() + " " + txtnombrebasedatos.Text;
                  //  string filename = urlbase + @"\Ejecutar\DescargaInfoIntuito.exe";
                  //  EjecutarCMD(filename);
                    
                    //Lista.Add(new Form1(auxinicial.ToString(), auxfinal.ToString()));
                    auxinicial = auxinicial + cantidadporparticion;
                    auxfinal = auxfinal + cantidadporparticion;
                }
            }
            catch (Exception exc)
            {

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            EjecutarCMD("taskkill /IM DescargaInfoIntuito.exe", false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            progressPanel1.Visible = true;
            BotonLogear();
            
        }
        public void VisiblePanelUsuario(bool estadoLogueo)
        {
            //panel1.Dock = DockStyle.Fill;
            //panel2.Dock = DockStyle.Fill;
            progressPanel1.Visible = false;
            panel1.Top = 0;
            panel2.Top = 0;

            panel1.Left = 0;
            panel2.Left = 0;

            panel1.Visible = false;
            panel2.Visible = false;

            if (estadoLogueo == true)
            {    this.Width = panel1.Width;
                 this.Height = panel1.Height;
                panel1.Visible = estadoLogueo;
            }
            else
            {
                this.Width = panel2.Width;
                this.Height = panel2.Height;
                panel2.Visible = !estadoLogueo;
            }

        }
        private void BotonLogear()
        {

            try
            {
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception exc)
            {

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            bool EstaLogueado = Loguear();
            e.Result = EstaLogueado;
        }
        private bool Loguear()
        {
            bool retorno = false;
            try
            {
                string Ip = CLR_UTIL.PCLocal.Consultas.GetIpAdress();
                string Mac = CLR_UTIL.PCLocal.Consultas.ObtenerMacAdrs();


                CLR_SAPA.ClassParametrosLogin parametros = new CLR_SAPA.ClassParametrosLogin()
                {
                    usuario = txtusuario.Text,
                    contrasenia = txtconstrasenia.Text,
                    ip = Ip,
                    latitud = "",
                    longitud = "",
                    mac = Mac,
                    master = "",
                    puerto = "",
                    sitio = Info.CodigodelSitio,
                    tipoacceso = CLR_SAPA.TipoAcceso.Escritorio,
                    version = Info.GetVersion(),

                };

                string prametros = CLR_UTIL.xml.XmlUtil.SerializeObject(parametros).GetResultadoPorIndice(0).objecto as string;
                //   prametros = CLR_UTIL.Encriptacion.MetodosEncriptacion.MD5Crypto_Encriptar(prametros, key);
                CLR_SAPA.SAPAv100.SAPAv100 sapa = new CLR_SAPA.SAPAv100.SAPAv100();

                var _UserXML = sapa.Entrar(prametros);


                _UserXML = CLR_UTIL.Encriptacion.MetodosEncriptacion.MD5Crypto_Desencriptar(_UserXML);
                var _User = (CLR_SAPA.SAPAServicesV100.UserSystem)CLR_UTIL.xml.XmlUtil.DeserializeObject(new CLR_SAPA.SAPAServicesV100.UserSystem(), _UserXML).GetResultadoPorIndice(0).objecto;


                List<string> ListGruposValidos = new List<string>();
                ListGruposValidos.Add("0C7C33E8-C1A4-4C3B-8825-D5FAD9F9F3C1");
                //ListGruposValidos.Add("CB005E4B-1F7D-4181-98EF-3974709A2C97");

                if (_User.EstaConectado == true)
                {
                     if (_User.GruposdelUsuario.Where(x => ListGruposValidos.Contains(x.UIDGRUPO)).Count() > 0)
                    {
                    User = _User;
                    retorno = true;

                    }
                    else
                    {
                        MessageBox.Show("No tienes permiso para acceder al sistema!");
                    }
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas!");
                }

                //  }
            }
            catch (Exception exc)
            {
                string mensajedeError = "Parece que tienes problemas con los servicios Web, consulte a sistemas si tiene bloqueos en red restringida o escribanos a info@intuitosa.com";
                MessageBox.Show(mensajedeError);
            }
            return retorno;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool estadoLogueo = (bool)e.Result;
            VisiblePanelUsuario(estadoLogueo);
            progressPanel1.Visible = false;
            if (User != null)
            {
              if(User.DatosUsuario != null)
                {
                this.Text="Intuito S.A.    USUARIO["+ User.DatosUsuario.USUARIO+ " - "+ User.DatosUsuario.NOMBRE+ "]";  
                }
            }
        }
    }
}
