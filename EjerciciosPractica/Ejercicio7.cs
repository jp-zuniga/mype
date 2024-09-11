/*
 *  7. Desarrolla un programa en C# que permita al usuario ingresar dos números enteros
 *  positivos y calcule tanto el Máximo Común Divisor (MCD) como el Mínimo Común
 *  Múltiplo (MCM) de dichos números.
 */

using System;

namespace EjerciciosPractica
{
    internal partial class Program
    {
        public static void MCD_MCM()
        {
            Console.Write("\nIngrese el primer número: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el segundo número: ");
            int b = int.Parse(Console.ReadLine());

            // para calcular el mcm y poder imprimir los valores que se ingresaron
            int a_original = a;
            int b_original = b;

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            int mcd = a;
            int mcm = (a_original * b_original) / mcd;

            Console.WriteLine($"El MCD de {a_original} y {b_original} es {mcd}.");
            Console.WriteLine($"El MCM de {a_original} y {b_original} es {mcm}.");
            Console.ReadKey();
        }
    }
}
