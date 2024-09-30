/*
 * Autor: Joaquín A. Pérez Z.
 * Fecha de creación: 09/20/2024; Fecha de modificación: 9/29/24
 * Versión: 1.0
 * *************************************************************************************************************
 * Se requiere un programa que permita almacenar los nombres de 5 estudiantes en un arreglo, para luego solicitar
 * las calificaciones de cada estudiante en cada una de de las asignaturas que cursa y almacenarlas en una matriz.
 * A continuación, se debe presentar un menú para realizar las siguientes tareas:
 *     1. Listar estudiantes con sus notas y promedio
 *     2. Listar estudiantes clasificados por rango:
 *        -> 90-100: Excelente 
 *        -> 80-89:  Bueno
 *        -> 70-79:  Regular
 *        -> 60-69:  Reprobado
 *     3. Mostrar la asignatura con más estudiantes aprobados
 *     4. Mostrar la asignatura con más estudiantes reprobados
 * -------------------------------------------------------------------------------------------------------------
 */

using System;

namespace Calificaciones
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
            Calificaciones cals = new Calificaciones();
            do
            {
                Console.Clear();
                Console.WriteLine("----> Menu de Calificaciones: <----");
                Console.WriteLine("1. Registrar notas");
                Console.WriteLine("2. Mostrar notas");
                Console.WriteLine("3. Mostrar rango de notas");
                Console.WriteLine("4. Asignatura con más estudiantes aprobados");
                Console.WriteLine("5. Asignatura con más estudiantes reprobados");
                Console.WriteLine("6. Salir\n");
                Console.Write("=> ");
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.Clear();

                        cals.RegistrarEstudiantes();
                        cals.RegistrarNotas();

                        Console.Write("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        cals.ImprimirNotas();

                        Console.Write("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        cals.CategorizarEstudiantes();

                        Console.Write("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        cals.AsignaturaConMasX("aprobados");

                        Console.Write("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        cals.AsignaturaConMasX("reprobados");

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
