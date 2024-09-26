/*
 * Ejercicio 2:
 * 
 * Una pequeña aerolínea acaba de adquirir una computadora para su sistema automatizado de reservaciones.
 * El presidente le ha solicitado a usted que programe el nuevo sistema en C#, que consiste en un programa
 * que asigne los asientos en cada vuelo del único avión de la aerolínea (capacidad: 15 asientos).
 * 
 * Su programa deberá mostrar el siguiente menú de alternativas:
 * => 1 – Económico
 * => 2 - Plus
 * => 3 - Premium
 * 
 * Si la persona escribe 1, entonces el programa deberá asignar un asiento en la sección económica (asientos del 1 al 5).
 * Si la persona escribe 2, entonces el programa deberá asignar un asiento en la sección plus (asientos del 6 al 10).
 * Si la persona escribe 3, entonces el programa deberá asignar un asiento en la sección premium (asientos del 11 al 15).
 * 
 * El programa no deberá, naturalmente, asignar nunca un asiento que ya haya sido asignado.
 * Cuando esté llena una sección, el programa deberá solicitar a la persona si le parece aceptable ser colocada en otra sección.
 * ------------------------------------------------------------------------------------------------------------------------------------
 */

using System;
using System.Linq;

namespace Ejercicios_Guia5
{
    internal class Reservaciones
    {
        private bool[] asientos = new bool[15];

        public void ImprimirMenu()
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine("----> Sistema de Reservaciones <----");
                Console.WriteLine("       Seleccione una opción:\n");
                Console.WriteLine("1 – Economía");
                Console.WriteLine("2 - Plus");
                Console.WriteLine("3 - Premium");
                Console.WriteLine("4 - Salir");

                option = int.Parse(Console.ReadLine());
                if (option == 4) break;

                switch (option)
                {
                    case 1:
                        AsignarAsiento(0, 4, "Economía");
                        break;
                    case 2:
                        AsignarAsiento(5, 9, "Plus");
                        break;
                    case 3:
                        AsignarAsiento(10, 14, "Premium");
                        break;
                    default:
                        Console.Write("Opción inválida!");
                        Console.ReadKey();
                        break;
                }
            } while (option != 4);
        }

        private void AsignarAsiento(int inicio, int fin, string seccion)
        {
            for (int i = inicio; i <= fin; i++)
            {
                if (!asientos[i])
                {
                    asientos[i] = true;
                    Console.Write($"Excelente! Se le ha asignado el asiento #{i+1} en la sección '{seccion}'!");
                    Console.ReadKey();
                    return;
                }
            }

            // si todos los asientos estan marcados true, ya no hay asientos disponibles
            if (asientos.All(x => x))
            {
                Console.Write("Lo sentimos, todos los asientos están llenos.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Lastimosamente, la sección '{seccion}' está llena. ¿Desea ser colocado en otra sección? (s/n)");
            string respuesta = Console.ReadLine().ToLower();

            if (respuesta == "s")
            {
                //if (AsignarEnOtraSeccion(fin)) return;

                Console.WriteLine("Lo sentimos, todos los asientos están llenos.");
            }
        }
    }
}
