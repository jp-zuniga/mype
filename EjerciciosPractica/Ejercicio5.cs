/*
 *  5. Escribe un programa en C# que genere la serie de Fibonacci hasta un número de
 *  términos especificado por el usuario. La serie de Fibonacci es una secuencia de
 *  números en la que cada número es la suma de los dos anteriores, comenzando con 0 y 1.
 */

using System;

namespace EjerciciosPractica
{
    internal partial class Program
    {
        public static void Fibonacci()
        {
            Console.Write("\nIngrese el número de términos de la serie de Fibonacci a calcular: ");
            int max = int.Parse(Console.ReadLine());

            // usando long ints pq si el usuario ingresa un numero muy grande en max, los terminos fibonacci seran muy grandes para un int normal
            long a = 0, b = 1;
            Console.WriteLine($"F_1: {a}");

            if (max > 1) Console.WriteLine("F_2: {b}");

            for (int contador = 3; contador < max; contador++)
            {
                long temp = a + b;
                a = b;
                b = temp;
                Console.WriteLine($"F_{contador}: {b}");
            }

            Console.ReadKey();
        }
    }
}
