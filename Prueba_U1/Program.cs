/*
 * Autor: Joaquín A. Pérez Z.
 * Fecha de creación: 09/23/2024
 * Versión: 1.0
 * *************************************************************************************************************
 * Se requiere un programa que lea ternas, y que por cada terna que el usuario ingrese (x,y,z),
 * se genere una serie Fibonacci que empieze con los términos x, y. Se debe generar la serie hasta el término z.
 * El programa deberá aceptar las ternas que el usuario digite hasta que ingrese 0,0,0.
 */

using System.Collections.Generic;

namespace Prueba_U1
{
    internal class Program
    {
        static void Main()
        {
            Fibonacci fib = new Fibonacci();
            List<int> input = new List<int>();

            while (true)
            {
                input = fib.PedirTerna();
                if (fib.TernaZero(input)) break; // si la terna tiene la forma [0,0,0], terminar el programa

                fib.ImprimirFibonacci(input);
            }
        }
    }
}
