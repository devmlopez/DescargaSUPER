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

namespace DescargaInfoIntuito
{
    public partial class FormsInicio : Form
    {
        public FormsInicio()
        {
            InitializeComponent();
        }

        
public void EjecutarCMD(string command,bool EsperarQueTermineEjecucion=true)
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
            }

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            //string output = process.StandardOutput.ReadToEnd();
            //string error = process.StandardError.ReadToEnd();

            //exitCode = process.ExitCode;

            //Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            //Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            //Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                int inicio = Convert.ToInt32(txtInicial.Text);
                int fin = Convert.ToInt32(txtFinal.Text);
                int particiones = Convert.ToInt32(txtparticiones.Text);

                int cantidadporparticion = (fin - inicio+1) / particiones;

                int auxinicial = inicio;
                int auxfinal = inicio + cantidadporparticion-1;


                EjecutarCMD("taskkill /IM DescargaInfoSuper.exe");

                for (int i = 0; i < particiones; i++)
                {
                    EjecutarCMD(@"C:\DescargaInfoSuper\DescargaInfoSuper\bin\Debug\ParaEjecutar\DescargaInfoSuper.exe "+ auxinicial.ToString()+" "+auxfinal.ToString() + " ",false);
                    //Lista.Add(new Form1(auxinicial.ToString(), auxfinal.ToString()));
                    auxinicial = auxinicial + cantidadporparticion;
                    auxfinal = auxfinal + cantidadporparticion;
                }
            }catch(Exception exc)
            {

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            EjecutarCMD("taskkill /IM DescargaInfoSuper.exe");

        }
    }
}
