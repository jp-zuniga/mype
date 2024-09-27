using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class SolicitarDatos
    {
        public static int solicitarEntero(string mensaje, int minimo, int maximo)
        {
            int valor;
            do
            {
                Console.Write(mensaje);
                valor = int.Parse(Console.ReadLine());

                if (valor < minimo || valor > maximo)
                {
                    Console.WriteLine("Ingrese un numero entre {0} y {1}.", minimo, maximo);
                }
            } while (valor < minimo || valor > maximo);
            return valor;
        }

        public static float solicitarDecimal(string mensaje)
        {
            float valor;
            Console.Write(mensaje);
            valor = float.Parse(Console.ReadLine());
            return valor;
        }


    }
}
