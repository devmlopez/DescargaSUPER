using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesaCatastroSRI
{
    public class ClassCatastro
    {
        public string UIDCONTRIBUYENTE { get; set; }
        public int ORDEN { get; set; }
        public string NUMERO_RUC { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string NOMBRE_COMERCIAL { get; set; }
        public string ESTADO_CONTRIBUYENTE { get; set; }
        public string CLASE_CONTRIBUYENTE { get; set; }
        public string FECHA_INICIO_ACTIVIDADES { get; set; }
        public string FECHA_ACTUALIZACION { get; set; }
        public string FECHA_SUSPENSION_DEFINITIVA { get; set; }
        public string FECHA_REINICIO_ACTIVIDADES { get; set; }
        public string OBLIGADO { get; set; }
        public string TIPO_CONTRIBUYENTE { get; set; }
        public string NUMERO_ESTABLECIMIENTO { get; set; }
        public string NOMBRE_FANTASIA_COMERCIAL { get; set; }
        public string CALLE { get; set; }
        public string NUMERO { get; set; }
        public string INTERSECCION { get; set; }
        public string ESTADO_ESTABLECIMIENTO { get; set; }
        public string DESCRIPCION_PROVINCIA { get; set; }
        public string DESCRIPCION_CANTON { get; set; }
        public string DESCRIPCION_PARROQUIA { get; set; }
        public string CODIGO_CIIU { get; set; }
        public string ACTIVIDAD_ECONOMICA { get; set; }

        public ClassCatastro()
        {

        }

        public ClassCatastro(string values)
        {
            try
            {
                int index= 0;
                var array=values.Split('\t');
                UIDCONTRIBUYENTE = Guid.NewGuid().ToString();
                
                NUMERO_RUC = array[index++];
                RAZON_SOCIAL = array[index++];
                NOMBRE_COMERCIAL = array[index++];
                ESTADO_CONTRIBUYENTE = array[index++];
                CLASE_CONTRIBUYENTE = array[index++];
                FECHA_INICIO_ACTIVIDADES = array[index++];
                FECHA_ACTUALIZACION = array[index++];
                FECHA_SUSPENSION_DEFINITIVA = array[index++];
                FECHA_REINICIO_ACTIVIDADES = array[index++];
                OBLIGADO = array[index++];
                TIPO_CONTRIBUYENTE = array[index++];
                NUMERO_ESTABLECIMIENTO = array[index++];
                NOMBRE_FANTASIA_COMERCIAL = array[index++];
                CALLE = array[index++];
                NUMERO = array[index++];
                INTERSECCION = array[index++];
                ESTADO_ESTABLECIMIENTO = array[index++];
                DESCRIPCION_PROVINCIA = array[index++];
                DESCRIPCION_CANTON = array[index++];
                DESCRIPCION_PARROQUIA = array[index++];
                CODIGO_CIIU = array[index++];
                ACTIVIDAD_ECONOMICA = array[index++];


            }
            catch (Exception exc)
            {

            }
        }
    }
}
