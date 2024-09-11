/*
 *  2. Escribe un programa que pida un año de cuatro dígitos (YYYY) y determine si es un año bisiesto.
 *  El programa termina cuando el usuario digite el año 2024. Un año es bisiesto si cumple con las
 *  a) es divisible por 4, b) no es divisible por 100, y c) es divisible por 400.
 */

using System;

namespace EjerciciosPractica
{
    internal partial class Program
    {
        public static void Bisiesto()
        {
            int year = 0;

            while (true)
            {
                Console.Write("\nIngrese un año de cuatro dígitos: ");
                string input = Console.ReadLine();

                if (input.Length != 4)
                {
                    Console.WriteLine("El año ingresado no es válido.\n");
                    continue;
                }

                try { year = Convert.ToInt32(input); } // try catch por si se ingresan letras
                catch (FormatException)
                {
                    Console.WriteLine("El año ingresado no es válido.\n");
                    continue;
                }

                if (year == 2024)
                {
                    Console.WriteLine("El programa ha terminado.\n");
                    break;
                }

                bool bisiesto = (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);

                if (bisiesto) Console.WriteLine($"El año {year} es bisiesto.");
                else Console.WriteLine($"El año {year} no es bisiesto.");
                Console.ReadKey();
            }
        }
    }
}
