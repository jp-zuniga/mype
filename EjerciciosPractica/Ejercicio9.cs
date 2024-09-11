// 9. Escriba un programa que lea un número y determine si es primo o no

using System;

namespace EjerciciosPractica
{
    internal partial class Program
    {
        public static void Primo()
        {
            Console.Write("\nIngresar número: ");
            int num = int.Parse(Console.ReadLine());
            bool primo = true;

            // saltarse 0, 1, numeros negativos, y todos los numeros pares (excepto 2)
            if (num == 2)
            {
                Console.WriteLine("\n2 es primo.");
                Console.ReadKey();
                return;
            }

            if ((num <= 1) || (num % 2 == 0))
            {
                Console.WriteLine($"\n{num} no es primo.");
                Console.ReadKey();
                return;
            }

            // como solo se estan checkeando numeros impares, solo checkear divisores impares
            for (int i = 3; i <= num; i += 2)
            {
                if (num % i == 0) primo = false;
            }

            Console.WriteLine($"\n{num} {(primo ? "si" : "no")} es primo.");
            Console.ReadKey();
        }
    }
}
