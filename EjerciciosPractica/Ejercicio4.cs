/*
 *  4. Escribe un programa en C# que solicite al usuario el monto de una compra y la
 *  cantidad de efectivo recibido. El programa debe calcular el cambio a devolver y
 *  desglosarlo en las denominaciones de billetes de 100, 50, 20, 10, y 5.
 */

using System;

namespace EjerciciosPractica
{
    internal partial class Program
    {
        public static void DevolverCambio()
        {
            Console.Write("\nIngrese el monto de la compra: ");
            float monto = float.Parse(Console.ReadLine());
            Console.Write("\nIngrese el efectivo entregado: ");
            float efectivo = float.Parse(Console.ReadLine());

            if (efectivo == monto)
            {
                Console.WriteLine("No se necesita dar cambio.");
                return;
            }

            else if (efectivo < monto)
            {
                Console.WriteLine("No se pago suficiente.");
                return;
            }

            int cien = 0, cincuenta = 0, veinte = 0, diez = 0, cinco = 0;
            float cambio = efectivo - monto;

            while (cambio > 0)
            {
                if (cambio >= 100)
                {
                    cien++;
                    cambio -= 100;
                }

                else if (cambio >= 50)
                {
                    cincuenta++;
                    cambio -= 50;
                }

                else if (cambio >= 20)
                {
                    veinte++;
                    cambio -= 20;
                }

                else if (cambio >= 10)
                {
                    diez++;
                    cambio -= 10;
                }

                else if (cambio >= 5)
                {
                    cinco++;
                    cambio -= 5;
                }
            }

            Console.WriteLine("Se deben devolver:");
            Console.WriteLine($"{cien} billetes de 100");
            Console.WriteLine($"{cincuenta} billetes de 50");
            Console.WriteLine($"{veinte} billetes de 20");
            Console.WriteLine($"{diez} billetes de 10");
            Console.WriteLine($"{cinco} billetes de 5");
            Console.ReadKey();
        }
    }
}
