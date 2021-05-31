using LibIntuito;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdooMigraCorreos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void CopiarPortapapeles(string contenido)
        {
            try
            {
                Clipboard.SetDataObject(contenido, true);
                MessageBox.Show("Texto copiado al portapapeles de Windows.",
                    "Copiado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al copiar texto al portapapeles: " +
                    Environment.NewLine + err.Message, "Error al copiar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopiarTodo_Click(object sender, EventArgs e)
        {
            CopiarPortapapeles(txcontenido.Text);   
        }

        private void btnAbrirAccess_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Access files (*.mdb)|*.mdb|All files (*.*)|*.*"; ;
            var result = ofd.ShowDialog();
            if(result.Equals(DialogResult.OK))
            {
                textBox1.Text = ofd.FileName;
                textBox1.Enabled = false;
                btnCopiarTodo.Text = "copiar todo (0) registros";
                btnCopiarTodo.Width = 160;
                string urlbaseaccess = ofd.FileName;
                ProcesarRegistros(urlbaseaccess);
            }
        }

        public void ProcesarRegistros(string urlbaseaccess)
        {
            var Todoslosregistros = SqlAccess.Selectall(urlbaseaccess);
            List<string> ListaCorreo1 = new List<string>();
            foreach(var item in Todoslosregistros)
            {
                if ((item.ze_cont_Correo1 + "").Contains("@"))
                {    
                    ListaCorreo1.Add("\t" + item.b_ig_RazonSocial + "\t\t" + item.ze_cont_Correo1 + "\t0\tFALSO\tFALSO\n");
                }
                if ((item.zf_cont_Correo2 + "").Contains("@"))
                {
                    ListaCorreo1.Add("\t" + item.b_ig_RazonSocial + "\t\t" + item.zf_cont_Correo2 + "\t0\tFALSO\tFALSO\n");
                }
            }
            string lineas = "";
            foreach(var linea in ListaCorreo1)
            {
                lineas +=linea;
            }
            txcontenido.Text = lineas;
            btnCopiarTodo.Text = "copiar todo ("+ ListaCorreo1 .Count().ToString()+ ") registros";
        }
    }
}
