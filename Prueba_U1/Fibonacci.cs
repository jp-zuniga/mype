using System;
using System.Collections.Generic;

namespace Prueba_U1
{
    internal class Fibonacci
    {
        public List<int> PedirTerna()
        {
            List<int> terna = new List<int>(); // para guardar los valores ingresados y retornarlos
            Console.Write("Ingrese una terna (con el formato x,y,z): ");

            // separar el string ingresado por comas y guardar los elementos resultantes en un arreglo
            string[] input = Console.ReadLine().Split(',');

            if (input.Length != 3) // si el arreglo no tiene 3 elementos, no es una terna valida
            {
                Console.WriteLine("Error: Ingrese una terna válida!");
                return PedirTerna(); // llamar la funcion recursivamente para pedir los datos de nuevo
            }

            // por cada elemento ingresado, convertirlo a un int y agregarlo a terna
            foreach (var num in input)
            {
                try { terna.Add(int.Parse(num)); }
                catch // si hubo un error al convertir num, no es una terna valida y hay que volver a pedir los datos
                {
                    Console.WriteLine("Error: Ingrese un número válido!");
                    return PedirTerna();
                }
            }

            return terna; // retornar la terna con los numeros ingresados por el usuario
        }

        public bool TernaZero(List<int> terna)
        {
            // valida si la terna ingresada tiene la forma [0,0,0]
            return terna[0] == 0 && terna[1] == 0 && terna[2] == 0;
        }

        public void ImprimirFibonacci(List<int> terna)
        {
            int x = terna[0], y = terna[1], z = terna[2]; // guardar los valores de x,y,z ingresados
            List<int> secuencia = new List<int> { x, y }; // inicializar la secuencia con x,y

            // calcular los primeros z terminos de la secuencia:
            for (int i = 2; i < z; i++)
            {
                secuencia.Add(secuencia[i-1] + secuencia[i-2]);
            }

            // imprimir cada termino en la secuencia
            foreach (int num in secuencia)
            {
                // si el termino actual no es el ultimo, imprimirlo con una coma al final
                if (num != secuencia[secuencia.Count - 1]) Console.Write(num + ", ");
                // si es el ultimo termino, imprimirlo sin coma
                else Console.WriteLine(num);
            }

            Console.WriteLine(); // imprimir un salto de linea para separar las secuencias
        }
    }
}
