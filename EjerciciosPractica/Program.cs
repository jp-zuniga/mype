/* 
 * Autor: Joaquín A. Pérez Z.
 * Fecha de creacion: 03/09/2024; Fecha de modificación: 07/09/2024
 * Version: 1.0
 * *****************************************************************************************************
 * 10. Escriba un programa que presente un menú para acceder a cada uno de los 9
 *     ejercicios anteriores. El menú debe repetirse hasta seleccionar la opción Salir.
 */

using System;

namespace EjerciciosPractica
{
    internal partial class Program
    {
        static void Main()
        {
            Menu();
        }

        public static void Menu()
        {
            int option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("----> Menu: <----");
                Console.WriteLine("1. Ejercicio 1");
                Console.WriteLine("2. Ejercicio 2");
                Console.WriteLine("3. Ejercicio 3");
                Console.WriteLine("4. Ejercicio 4");
                Console.WriteLine("5. Ejercicio 5");
                Console.WriteLine("6. Ejercicio 6");
                Console.WriteLine("7. Ejercicio 7");
                Console.WriteLine("8. Ejercicio 8");
                Console.WriteLine("9. Ejercicio 9");
                Console.WriteLine("10. Salir\n");
                Console.Write("=> ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        CheckearMes();
                        break;
                    case 2:
                        Bisiesto();
                        break;
                    case 3:
                        CalcularTiempo();
                        break;
                    case 4:
                        DevolverCambio();
                        break;
                    case 5:
                        Fibonacci();
                        break;
                    case 6:
                        SumarDias();
                        break;
                    case 7:
                        MCD_MCM();
                        break;
                    case 8:
                        LeerNumeros();
                        break;
                    case 9:
                        Primo();
                        break;
                    case 10:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            } while (option != 10);
        }
    }
}