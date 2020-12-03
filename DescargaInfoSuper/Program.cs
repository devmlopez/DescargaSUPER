using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DescargaInfoIntuito
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new FormsInicio());
        //}
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

         //  args = new string[] { "183546", "183548", "1-1000" };
            Application.Run(new Form1(args));
          //  Application.Run(new Form1(,));
           
            //  Application.Run(new FormsInicio());
        }
    }
}
