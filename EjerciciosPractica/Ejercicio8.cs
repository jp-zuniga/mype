/*
 *  8. Escriba un programa que lea una serie de números enteros ingresados por el usuario
 *  hasta que se ingrese el número -1. El programa deberá imprimir: el mayor, el menor,
 *  el promedio, la cantidad de números pares y la cantidad de números impares.
 */

using System;

namespace EjerciciosPractica
{
    internal partial class Program
    {
        public static void LeerNumeros()
        {
            int num = 0, mayor = int.MinValue, menor = int.MaxValue, suma = 0, cantidad = 0, pares = 0, impares = 0;
            Console.WriteLine();

            do
            {
                Console.Write("Ingresar número: ");
                num = int.Parse(Console.ReadLine());

                if (num == -1) break;

                if (num > mayor) mayor = num;
                else if (num < menor) menor = num;

                if (num % 2 == 0) pares++;
                else impares++;

                cantidad++;
                suma += num;

            } while (num >= 0);

            if (cantidad == 0) Console.WriteLine("\nNo se ingresaron números.");

            else
            {
                Console.WriteLine($"\nNúmero máximo: {mayor}");
                Console.WriteLine($"Número mínimo: {menor}");
                Console.WriteLine($"Promedio de los números: {suma / cantidad}");
                Console.WriteLine($"Cantidad de números pares: {pares}");
                Console.WriteLine($"Cantidad de números impares: {impares}");
            }

            Console.ReadKey();
        }
    }
}
