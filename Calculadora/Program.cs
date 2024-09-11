/*
 * Autor: Joaquín A. Pérez Z.
 * Fecha de creación: 06/07/2024
 * Versión: 1.0
 * *************************************************************************************************************
 * La calculadora contiene una memoria limitada, pero proporciona las siguientes funcionalidades:
 * 1. Multiplicación de dos enteros basada en sumas sucesivas.
 * 2. División de dos enteros basada en restas sucesivas.
 * 3. Potencia basada en multiplicaciones sucesivas.
 * 4. Suma basada en sumador.
 * 5. Conteo basado en contador.
 * 6. Promedio basado en centinela.
 * 7. Número primo basado en bandera.
 */

using System;
using System.Collections.Generic;

namespace Calculadora
{
    internal class Program
    {
        static void Main()
        {
            Menu();
        }

        public static void Menu()
        {
            int option, num1, num2;
            Calculadora Calc = new Calculadora();

            do
            {
                Console.Clear();
                Console.WriteLine("\n----------   Calculadora   ----------\n");
                Console.WriteLine("   1. Sumar");
                Console.WriteLine("   2. Multiplicar");
                Console.WriteLine("   3. Dividir");
                Console.WriteLine("   4. Potencia");
                Console.WriteLine("   5. Contar");
                Console.WriteLine("   6. Promediar");
                Console.WriteLine("   7. Número primo");
                Console.WriteLine("   8. Salir\n");
                Console.Write("   => ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        int suma = Calc.Sumar();
                        Console.Write($"\n   Suma total = {suma}");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Write("\n   Ingrese el primer número: ");
                        num1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("   Ingrese el segundo número: ");
                        num2 = Convert.ToInt32(Console.ReadLine());

                        Console.Write($"\n   {num1} * {num2} = {Calc.Multiplicar(num1, num2)}");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Write("\n   Ingrese el primer número: ");
                        num1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("   Ingrese el segundo número: ");
                        num2 = Convert.ToInt32(Console.ReadLine());

                        List<int> resultado = Calc.Dividir(num1, num2);
                        Console.Write($"\n   {num1} / {num2} = {resultado[0]} (con un residuo de: {resultado[1]})");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Write("\n   Ingrese la base: ");
                        num1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("   Ingrese el exponente: ");
                        num2 = Convert.ToInt32(Console.ReadLine());

                        Console.Write($"\n   {num1} ^ {num2} = {Calc.Potenciar(num1, num2)}");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Write("\n   Ingrese la cantidad de veces a contar: ");
                        int cantidad = Convert.ToInt32(Console.ReadLine());
                        Console.Write("   Ingrese el intérvalo de conteo: ");
                        int intervalo = Convert.ToInt32(Console.ReadLine());

                        Console.Write($"\n   Conteo total = {Calc.Contar(cantidad, intervalo)}");
                        Console.ReadKey();
                        break;

                     case 6:
                        float promedio = Calc.Promediar();
                        Console.Write($"\n   Promedio = {promedio}");
                        Console.ReadKey();
                        break;

                    case 7:
                        Console.Write("\n   Ingrese un número para verificar si es primo: ");
                        num1 = Convert.ToInt32(Console.ReadLine());

                        Console.Write($"\n   {num1} {(Calc.EsPrimo(num1) ? "si" : "no")} es primo");
                        Console.ReadKey();
                        break;

                    case 8:
                        Console.Write("\n   Cerrando...");
                        Console.ReadKey();
                        break;

                    default:
                        Console.Write("\n   Opción inválida...");
                        Console.ReadKey();
                        break;
                }

            } while (option != 8);

            Console.WriteLine();
        }
    }
}
