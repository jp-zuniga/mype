// 1. Escribe un programa que reciba el número de un mes del año e imprima si tiene 28, 29, 30 o 31 días.

using System;
using System.Collections.Generic;

namespace EjerciciosPractica
{
    internal partial class Program
    {
        public static void CheckearMes()
        {
            Dictionary<string, int> meses = new Dictionary<string, int>
            {
                { "enero", 31 },
                { "febrero", 28 },
                { "marzo", 31 },
                { "abril", 30 },
                { "mayo", 30 },
                { "junio", 30 },
                { "julio", 31 },
                { "agosto", 31 },
                { "septiembre", 30 },
                { "octubre", 31 },
                { "noviembre", 30 },
                { "diciembre", 31 }
            };

            while (true)
            {
                Console.Write("\nIngrese el nombre de un mes: ");
                string input = Console.ReadLine().ToLower();

                if (meses.ContainsKey(input))
                {
                    Console.WriteLine($"El mes de {input} tiene {meses[input]} días.");
                    break;
                }

                else Console.WriteLine("El mes ingresado no es válido.");
            }

            Console.ReadKey();
        }
    }
}
