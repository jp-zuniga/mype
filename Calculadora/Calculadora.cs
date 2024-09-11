using System;
using System.Collections.Generic;

namespace Calculadora
{
    internal class Calculadora
    {
        public int Sumar()
        {
            int sumador = 0;
            bool respuesta;
            do {
                Console.Write("\n   Digite el número a sumar: ");
                sumador += Convert.ToInt32(Console.ReadLine());

                Console.Write("  ¿Desea seguir sumando? (s/n) ");
                respuesta = char.Parse(Console.ReadLine().ToLower()) == 's';
            } while (respuesta);

            return sumador;
        }

        public int Multiplicar(int num1, int num2)
        {
            int resultado = 0;

            for (int i = 1; i <= num2; i++) resultado += num1;

            return resultado;
        }

        public List<int> Dividir(int num1, int num2)
        {
            int resultado = 0;

            while (num1 >= num2)
            {
                num1 -= num2;
                resultado++;
            }

            return new List<int> { resultado, num1 };
        }

        public int Potenciar(int num, int exponente)
        {
            int resultado = 1;

            for (int i = 1; i <= exponente; i++) resultado *= num;

            return resultado;
        }

        public int Contar(int cantidad, int intervalo)
        {
            int contador = 0;

            for (int i = 1; i <= cantidad; i++) contador += intervalo;

            return contador;
        }

        public float Promediar()
        {
            int contador = 0, suma = 0, input;
            Console.WriteLine();

            do
            {
                Console.Write("   Digite un número para añadirlo al total (o un número negativo para finalizar): ");
                input = Convert.ToInt32(Console.ReadLine());

                if (input >= 0)
                {
                    suma += input;
                    contador++;
                }

            } while (input >= 0);

            return suma / contador;
        }

        public bool EsPrimo(int num)
        {
            // saltarse 0, 1, numeros negativos, y todos los numeros pares (excepto 2)
            if (num == 2) return true;
            if ((num <= 1) || (num % 2 == 0)) return false;

            // como solo se estan checkeando numeros impares, solo checkear divisores impares
            for (int i = 3; i <= num; i += 2)
            {
                if (num % i == 0) return false;
            }

            return true;
        }
    }
}
