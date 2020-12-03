using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DescargaMasiva
{
    public class Info
    {
        private static string nombresistema = "DescargaMasivaInfo";
        public static string GetNombreSistema() => nombresistema;

        private static string versionLarga = "V1.0.0";
        public static string GetVersion() => versionLarga;

        static string Copyright = "©@anio Intuito S.A.";
        public static string GetCopyright() => Copyright.Replace("@anio", DateTime.Now.Year.ToString());

        public static string CodigodelSitio = "BNAF62B-508D-2CF0-9069-5AA970722D55";

    }
}
