using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica2doParcial
{
    internal class Validador
    {
        public string pedirStringNoVacio(string mensaje)
        {
            string retorno = "";
            do
            {
                Console.WriteLine(mensaje);
                retorno = Console.ReadLine().ToUpper();
                if (retorno == "")
                {
                    Console.WriteLine("Debe ingresar un valor NO vacio.");
                }
            } while (retorno == "");
            return retorno;
        }

        public double pedirDouble(string mensaje)
        {
            double retorno;
            bool pudeConvertir;
            do
            {
                Console.WriteLine(mensaje);
                pudeConvertir = Double.TryParse(Console.ReadLine(), out retorno);

                if (!pudeConvertir)
                {
                    Console.WriteLine("Ingrese un valor numerico.");
                }
                if (retorno < 0)
                {
                    Console.WriteLine("Debe ingresar un valor positivo.");
                }
            } while (retorno < 0 || (!pudeConvertir));
            return retorno;
        }
    }
}
