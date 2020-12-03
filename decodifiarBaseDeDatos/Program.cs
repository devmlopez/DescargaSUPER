using LibIntuito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decodifiarBaseDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombrebasedatos = @"C:\Users\Miguel\Downloads\20000-30000.mdb";
            Procesar(nombrebasedatos);
        }
        public static void Procesar(string nombrebasedatos)
        {
            try
            {
                var Todoslosregistros = SqlAccess.SelectTodo(nombrebasedatos);

                Todoslosregistros = Todoslosregistros.OrderBy(x => x.a_ig_Expediente).ToList();
                foreach (var item in Todoslosregistros)
                {
                    item.sedecodifico = true;
                    bool SeActualizo = SqlAccess.ModificarRegistro(item, nombrebasedatos);

                    if (SeActualizo)
                    {
                        Console.WriteLine("SI Actualizó el expediente # " + item.a_ig_Expediente);
                    }
                    else
                    {
                        Console.WriteLine("NO Actualizó el expediente # " + item.a_ig_Expediente);
                    }
                }  
               
            }
            catch (Exception exc)
            {
                Mensaje(exc);
            }
        }

        public static void Mensaje(Exception exc)
        {
            if (exc != null)
            {
                Console.WriteLine("ERROR: " + exc.Message);
            }
        }
    }

   
}
