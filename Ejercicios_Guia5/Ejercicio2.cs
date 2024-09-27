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
        private const int num_asientos = 15;
        private bool[] asientos = new bool[num_asientos];

        public void ImprimirMenu()
        {
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("\n----> Sistema de Reservaciones <----\n");
                Console.WriteLine("Seleccione una sección:");
                Console.WriteLine("1 – Economía");
                Console.WriteLine("2 - Plus");
                Console.WriteLine("3 - Premium");
                Console.WriteLine("4 - Salir");
                Console.Write("=> ");

                // validar inputs por si el usuario ingresa un valor no numerico
                try { option = int.Parse(Console.ReadLine()); }
                catch
                {
                    Console.Write("\nError: Ingrese un número entero!");
                    Console.ReadKey();
                    continue;
                }

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
                    case 4:
                        Console.Write("\nRegresando al menú principal...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("\nOpción inválida!");
                        Console.ReadKey();
                        break;
                }
            } while (option != 4);
        }

        private void AsignarAsiento(int inicio, int fin, string seccion)
        {
            // si todos los asientos estan marcados true, ya no hay asientos disponibles
            if (asientos.All(x => x))
            {
                Console.Write("\nLo sentimos, todos los asientos están llenos.");
                Console.ReadKey();
                return;
            }

            // buscar un asiento libre en la seccion indicada
            for (int i = inicio; i <= fin; i++)
            {
                if (!asientos[i]) // si se encuentra un asiento desocupado, asignarlo
                {
                    asientos[i] = true;
                    Console.Write($"\nExcelente! Se le ha asignado el asiento #{i+1} en la sección '{seccion}'!");
                    Console.ReadKey();
                    return;
                }
            }

            // si no se encontro un asiento libre en la seccion seleccionada, preguntarle al usuario si quiere escoger otra seccion
            Console.Write($"\nLastimosamente, la sección '{seccion}' está llena. ¿Desea ser colocado en otra sección? (s/n) ");
            string respuesta = Console.ReadLine().ToLower();

            if (respuesta == "s") // si deciden que si, intentar asignarles otro asiento
            {
                int exito = AsignarOtraSeccion();
                if (exito == 1) return; // si se pudo asignar asiento, salir de la funcion immediatamente
                else if (exito == 0) // mostrar mensaje informando que esta lleno el avion
                {
                    Console.Write("\nLo sentimos, todos los asientos están llenos.");
                    Console.ReadKey();
                    return;
                }

                else if (exito == -1) // si ingresaron una entrada invalida, informarlo y regresar al menu
                {
                    Console.Write("Opción inválida! Lo sentimos, debe intentar de nuevo!");
                    Console.ReadKey();
                    return;
                }
            }

            else if (respuesta == "n") // si no quieren, regresar al menu
            {
                Console.Write("De acuerdo! Regresando al menú de reservaciones...");
                Console.ReadKey();
                return;
            }

            else // si no ponen 's' o 'n', regresar al menu
            {
                Console.Write("Opción inválida! Lo sentimos, debe intentar de nuevo!");
                Console.ReadKey();
                return;
            }
        }

        public int AsignarOtraSeccion()
        {
            int i = 0, contador = 0; // contador es para contar las veces que se le han mostrado nuevos asientos libres al usuario
            while (i < num_asientos)
            {
                if (!asientos[i]) // mostrar el primer asiento libre que se encuentre
                {
                    // si i < 5, imprimir 'Economía'
                    // si no, revisar si i < 10 -- si lo es, imprimir 'Plus'
                    // y si tampoco es menor que 10, imprimir 'Premium'
                    string seccion = i < 5 ? "Economía" : i < 10 ? "Plus" : "Premium";
                    string otro = contador > 0 ? "otro " : ""; // si ya se le ha mostrado un asiento previamente, agregarle 'otro' al mensaje a imprimir

                    // preguntarle al usuario si quiere reservar el asiento encontrado, ya que talvez prefieran estar en otra seccion
                    Console.Write($"Tenemos {otro}un asiento libre en la sección '{seccion}', ¿desea reservarlo? (s/n) ");
                    string respuesta = Console.ReadLine().ToLower();

                    if (respuesta == "s") // si dicen que si, asignarles el asiento y retornar 1 (se encontro un asiento)
                    {
                        asientos[i] = true;
                        Console.Write($"De acuerdo! Se le ha asignado el asiento #{i+1} en la sección '{seccion}'!");
                        Console.ReadKey();
                        return 1;
                    }

                    else if (respuesta == "n") // si deciden que no, saltar a la proxima seccion para buscar asientos libres
                    {
                        // si i < 5, sumarle lo que le falte para ir a la proxima seccion (por ej. i = 1: se necesita sumarle 4 (o 5 - 1) para llegar al indice donde inicia la proxima seccion)
                        // si no, revisar si i < 10 -- si lo es, sumarle lo que le falte para saltarse al rango de 10-14
                        // y si tampoco es menor que 10, asignarle el valor de num_asientos para salir del bucle (ya que si el bucle esta en la ultima seccion, las primeras dos ya estan llenas)
                        i = i < 5 ? i += 5-i : i < 10 ? i += 10-i : num_asientos;
                        contador++;
                        continue;
                    }

                    else return -1; // si no ponen 's' o 'n', retornar -1 (para saber que hubo una entrada invalida)
                }

                i++; // ir al proximo asiento
            }

            // si se le asigno num_asientos a i, significa una de dos cosas:
            // 1) el bucle ha iterado hasta la ultima seccion y ya no hay otros asientos libres
            // 2) el usuario respondio que no queria ser asignado en todas las otras secciones
            // por lo tanto, hay que informarle que no hay asientos libres que se le pueden ofrecer
            if (contador >= 1)
            {
                Console.Write("Lo sentimos, no tenemos asientos libres en otra sección.");
                Console.ReadKey();
                return 1; // se retorna 1 para que no se impriman los otros mensajes y solo se retorne al menu de un solo
            }

            return 0; // si no se encontro ningun asiento libre, retornar 0 (ya esta lleno el avion)
        }
    }
}
