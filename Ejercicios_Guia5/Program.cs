/*
 * Autor: Joaquín A. Pérez Z.
 * Fecha de creación: 09/24/2024
 * Versión: 1.0
 * *************************************************************************************************************
 * Resolver los 5 ejercicios descritos en la Guía Didáctica #5
 * -------------------------------------------------------------------------------------------------------------
 */

using System;

namespace Ejercicios_Guia5
{
    internal class Program
    {
        static void Main()
        {
            Menu();
        }

        public static void Menu()
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("----> Menu: <----");
                Console.WriteLine("1. Ejercicio 1");
                Console.WriteLine("2. Ejercicio 2");
                Console.WriteLine("3. Ejercicio 3");
                Console.WriteLine("4. Ejercicio 4");
                Console.WriteLine("5. Ejercicio 5");
                Console.WriteLine("6. Salir\n");
                Console.Write("=> ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Dados ej1 = new Dados();

                        ej1.ContarDados();
                        Console.WriteLine("\nEjercicio 1:");
                        Console.WriteLine("Después de tirar dos dados 36,000 veces, las frecuencias de cada suma son:\n");
                        ej1.ImprimirCuenta();

                        Console.Write("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Reservaciones ej2 = new Reservaciones();

                        Console.WriteLine("\nEjercicio 2:");
                        ej2.ImprimirMenu();

                        break;
                    case 3: break;
                    case 4:
                        Console.Clear();
                        Salarios ej4 = new Salarios();

                        Console.WriteLine("\nEjercicio 4:");
                        ej4.LeerVentas();
                        ej4.ImprimirSalarios();

                        Console.Write("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Matrices ej5 = new Matrices();

                        Console.WriteLine("\nEjercicio 5:");
                        int[,] matriz = ej5.LeerMatriz();

                        Console.Clear();
                        Console.WriteLine("\nMatriz ingresada:\n");
                        ej5.ImprimirMatriz(matriz);
                        ej5.CategorizarMatriz(matriz);

                        Console.Write("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.Write("\nSaliendo del programa...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("\nOpción inválida!");
                        Console.ReadKey();
                        break;
                }
            } while (option != 6);
        }
    }
}
