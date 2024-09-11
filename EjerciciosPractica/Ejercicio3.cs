/*
 *  3. Escribe un programa en C# que reciba una hora de inicio y una hora de fin, y calcule
 *  el tiempo total transcurrido entre ambas horas. El programa debe manejar horas en
 *  formato de 24 horas (por ejemplo, 14:30) y debe tomar en cuenta si la hora de fin es
 *  el día siguiente.
 */

using System;

namespace EjerciciosPractica
{
    internal partial class Program
    {
        public static void CalcularTiempo()
        {
            Console.Write("\nIngrese la hora de inicio (HH:mm): ");
            string horaInicioStr = Console.ReadLine();
            Console.Write("Ingrese la hora de fin (HH:mm): ");
            string horaFinStr = Console.ReadLine();

            TimeSpan horaInicio;
            TimeSpan horaFin;

            if (TimeSpan.TryParse(horaInicioStr, out horaInicio) && TimeSpan.TryParse(horaFinStr, out horaFin))
            {
                TimeSpan duracion;

                // si la hora de fin es menos, asumir que es el dia siguiente
                if (horaFin < horaInicio) duracion = (horaFin + TimeSpan.FromDays(1)) - horaInicio;

                else duracion = horaFin - horaInicio;

                Console.WriteLine($"El tiempo total transcurrido es: {duracion.Hours} horas y {duracion.Minutes} minutos.");
            }

            else Console.WriteLine("Formato de hora no válido. Por favor, use el formato HH:mm.");
            Console.ReadKey();
        }
    }
}
