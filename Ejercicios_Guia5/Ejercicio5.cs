/*
 * Ejercicio 4:
 * 
 * Una escuela de matemáticas requiere un programa que valide, dada una matriz de enteros de 6x6 como entrada, si la matriz es:
 * 
 * 1. Matriz Diagonal:
 *    Una matriz es diagonal si todos los elementos fuera de la diagonal principal son cero.
 *    Es decir, solo los elementos donde la fila y la columna son iguales (i == j) pueden ser diferentes de cero.
 * 
 * 2. Matriz Identidad:
 *    Una matriz es identidad si es diagonal y todos los elementos de la diagonal principal son 1.
 * 
 * 3. Matriz Simétrica:
 *    Una matriz es simétrica si es cuadrada y el elemento de la posición [i, j] es igual al de la posición [j, i]
 *    para todos los valores de i y j. Básicamente, es reflejada respecto a la diagonal principal.
 * 
 * 4. Matriz Escalar:
 *    Una matriz es escalar si es diagonal y todos los elementos de la diagonal principal son iguales.
 * ---------------------------------------------------------------------------------------------------------------------------------------
 */

using System;
using System.Linq;
using System.Collections.Generic;

namespace Ejercicios_Guia5
{
    internal class Matrices
    {
        private const int filas = 6;
        private const int columnas = 6;
        private int[,] matriz = new int[filas,columnas];

        public int[,] LeerMatriz()
        {
            int i = 0;
            Console.WriteLine("\nIngrese los datos de la matriz:");

            while (i < filas)
            {
                int j = 0;
                while (j < columnas)
                {
                    Console.Write($"=> Elemento [{i+1},{j+1}]: ");
                    try { this.matriz[i,j] = int.Parse(Console.ReadLine()); }
                    catch
                    {
                        Console.WriteLine("\nError: Ingrese un número entero!");
                        continue;
                    }

                    j++;
                }

                i++;
            }

            return this.matriz;
        }

        public void ImprimirMatriz(int[,] matriz)
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    // si es el primer elemento, imprimir el | y una coma despues del elemento
                    if (j == 0) Console.Write($"| {matriz[i,j]}, ");

                    // si es el ultimo elemento, cerrar el | e imprimir un salto de línea
                    else if (j == columnas-1) Console.WriteLine($"{matriz[i,j]} |");

                    // si es un elemento en medio, solo imprimir la coma despues del elemento    
                    else Console.Write($"{matriz[i,j]}, ");
                }
            }
        }

        public void CategorizarMatriz(int[,] matriz)
        {
            Console.WriteLine();
            if (EsDiagonal(matriz))
            {
                if (EsIdentidad(matriz))
                {
                    Console.WriteLine("La matriz es una matriz Identidad.");
                    return;
                }

                else if (EsEscalar(matriz))
                {
                    Console.WriteLine("La matriz es una matriz Escalar.");
                    return;
                }

                Console.WriteLine("La matriz es una matriz Diagonal.");
                return;
            }

            else if (EsSimetrica(matriz))
            {
                Console.WriteLine("La matriz es una matriz Simétrica.");
                return;
            }

            Console.WriteLine("La matriz no pertenece a ninguna categoría específica.");
        }

        private bool EsDiagonal(int[,] matriz)
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if ((i != j) && (matriz[i,j] != 0)) return false;
                    else if (i == j && matriz[i,j] == 0) return false;
                }
            }

            return true;
        }

        private bool EsIdentidad(int[,] matriz)
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (i == j && matriz[i,j] != 1) return false;
                }
            }

            return true;
        }

        private bool EsSimetrica(int[,] matriz)
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if ((i != j) && (matriz[i, j] != matriz[j, i])) return false;
                }
            }

            return true;
        }

        private bool EsEscalar(int[,] matriz)
        {
            List<int> diagonales = new List<int>();

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (i == j) diagonales.Add(matriz[i,j]);
                }
            }

            if (!diagonales.All(x => x == diagonales[0] && x != 1)) return false;
            return true;
        }
    }
}
