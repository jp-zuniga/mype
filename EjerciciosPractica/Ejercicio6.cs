/*
 *  6. Escribe un programa en C# que solicite al usuario ingresar una fecha específica en
 *  formato de día, mes y año, y luego pida la cantidad de días que se desean sumar a
 *  esa fecha. El programa debe calcular y mostrar la nueva fecha resultante después de
 *  sumar los días indicados
 */

using System;

namespace EjerciciosPractica
{
    internal partial class Program
    {
        public static void SumarDias()
        {
            int year, mes, dia;
            DateTime fecha_inicio;
            Console.WriteLine();

            while (true)
            {
                Console.Write("Ingrese un año: ");
                year = int.Parse(Console.ReadLine());
                Console.Write("Ingrese un mes: ");
                mes = int.Parse(Console.ReadLine());
                Console.Write("Ingrese un día: ");
                dia = int.Parse(Console.ReadLine());

                try
                {
                    fecha_inicio = new DateTime(year, mes, dia);
                    break;
                }

                catch (FormatException)
                {
                    Console.WriteLine("La fecha ingresada no es válida.");
                }
            }

            Console.Write("¿Cuántos días desea sumar a la fecha ingresada? ");
            int agregar = int.Parse(Console.ReadLine());
            DateTime fecha_final = fecha_inicio.AddDays(agregar);

            Console.WriteLine($"\nLa fecha original es {year}-{mes}-{dia}");
            Console.WriteLine($"La nueva fecha despues de agregar {agregar} días es: {fecha_final.ToString("yyyy-MM-dd")}");
            Console.ReadKey();
        }
    }
}
