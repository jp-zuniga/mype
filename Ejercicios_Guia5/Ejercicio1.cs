/*
 * Ejercicio 1:
 * 
 * Escriba un programa que simule el tirar dos dados. El programa deberá utilizar la clase Random para tirar
 * el primer dado, y después volverá a utilizar Random para tirar el segundo. A continuación, se suman los valores.
 * 
 * En vista de que cada dado puede mostrar un valor entero entre 1 y 6, entonces la suma de los dos valores
 * variará entre 2 y 12 -- 7 siendo la suma más frecuente, mientras que 2 y 12 las menos frecuentes.
 * 
 * El programa deberá tirar 36,000 veces los dos dados y en un arreglo de un subíndice
 * se llevará cuenta del número de veces que aparece cada suma posible.
 * -------------------------------------------------------------------------------------------------------------------------
 */

using System;

namespace Ejercicios_Guia5
{
    internal class Dados
    {
        private Random rand = new Random();
        private int[,] cuenta = new int[6, 6];

        public void ContarDados()
        {
            for (int j = 0; j < 36000; j++)
            {
                int dado1 = this.rand.Next(0, 6);
                int dado2 = this.rand.Next(0, 6);
                cuenta[dado1, dado2]++;
            }
        }

        public void ImprimirCuenta()
        {
            // primero hay que calcular la longitud maxima de los elementos en la matriz, para poder centrarlos
            int max_ancho = 0;
            foreach (int elemento in this.cuenta)
            {
                // iterar sobre cada elemento, convertirlo a string y comparar su longitud con la maxima
                string s = elemento.ToString();
                if (s.Length > max_ancho) max_ancho = s.Length;
            }

            // crear una linea de - para separar cada linea de la tabla:
            string separador = new string('-', (max_ancho + 3) * 7 - 1);
            // imprimir una celda vacia:
            Console.Write(new string(' ', max_ancho + 1));

            for (int i = 1; i <= 6; i++)
            {
                // iterar del 1 al 6 para imprimir los numeros de arriba, centrados en la celda
                string num = i.ToString();
                string output = "| " + num.PadLeft(num.Length + max_ancho/2).PadRight(max_ancho) + ' ';
                if (i == 6) output += "|";
                Console.Write(output);
            }

            Console.WriteLine('\n' + separador);

            for (int j = 0; j < 6; j++)
            {
                Console.Write(new string(' ', max_ancho/2) + $"{j + 1}" + new string(' ', max_ancho/2));
                for (int k = 0; k < 6; k++)
                {
                    string output = $"| {this.cuenta[j, k].ToString().PadLeft(max_ancho)} ";
                    if (k == 5) output += "|";
                    Console.Write(output);
                }

                Console.WriteLine('\n' + separador);
            }
        }

    }
}
