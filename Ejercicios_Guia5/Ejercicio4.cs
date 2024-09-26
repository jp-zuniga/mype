/*
 * Ejercicio 4:
 * 
 * Una empresa le paga a su personal de ventas en base a comisiones.
 * Los vendedores reciben $200 por semana más el 9% de sus ventas brutas de dicha semana. Por ejemplo:
 * Un vendedor que vende $3.000 en ventas brutas en una semana, recibe $200 más 9% de 3.000, o sea un total de $470.
 * 
 * Escriba un programa en C# que determine cuántos de los vendedores ganaron salarios en cada uno de los rangos siguientes:
 *   => $200-$299
 *   => $300-$399
 *   => $400-$499
 *   => $500-$599
 *   => $600-$699
 *   => $700-$799
 *   => $800-$899
 *   => $900-$999
 *   => $1000 o superior
 * -----------------------------------------------------------------------------------------------------------------------------------
 */

using System;

namespace Ejercicios_Guia5
{
    internal class Salarios
    {
        private int[] rangos = new int[9];

        public void LeerVentas()
        {
            int num_vendedores = 0;
            Console.Write("\n¿Cuántos vendedores tiene la empresa? ");
            try { num_vendedores = int.Parse(Console.ReadLine()); }
            catch
            {
                Console.WriteLine("Error: Ingrese un número entero!");
                LeerVentas();
            }

            int[] ventas_brutas = new int[num_vendedores];
            int i = 0;

            Console.WriteLine();
            while (i < num_vendedores)
            {
                Console.Write($"Ingrese las ventas semanales del empleado {i+1}: ");
                try { ventas_brutas[i] = int.Parse(Console.ReadLine()); }
                catch
                {
                    Console.WriteLine("\nError: Ingrese un número entero!");
                    continue;
                }

                i++;
            }

            foreach (int venta in ventas_brutas)
            {
                double salario_comision = (venta * 0.09) + 200;
                if (salario_comision >= 200 && salario_comision <= 299) this.rangos[0]++;
                if (salario_comision >= 300 && salario_comision <= 399) this.rangos[1]++;
                if (salario_comision >= 400 && salario_comision <= 499) this.rangos[2]++;
                if (salario_comision >= 500 && salario_comision <= 599) this.rangos[3]++;
                if (salario_comision >= 600 && salario_comision <= 699) this.rangos[4]++;
                if (salario_comision >= 700 && salario_comision <= 799) this.rangos[5]++;
                if (salario_comision >= 800 && salario_comision <= 899) this.rangos[6]++;
                if (salario_comision >= 900 && salario_comision <= 999) this.rangos[7]++;
                if (salario_comision >= 1000) this.rangos[8]++;
            }
        }

        public void ImprimirSalarios()
        {
            Console.Clear();
            Console.WriteLine("\nSalarios de empleados clasificados en rangos:\n");
            Console.WriteLine($"$200-$299: {this.rangos[0]}");
            Console.WriteLine($"$300-$399: {this.rangos[1]}");
            Console.WriteLine($"$400-$499: {this.rangos[2]}");
            Console.WriteLine($"$500-$599: {this.rangos[3]}");
            Console.WriteLine($"$600-$699: {this.rangos[4]}");
            Console.WriteLine($"$700-$799: {this.rangos[5]}");
            Console.WriteLine($"$800-$899: {this.rangos[6]}");
            Console.WriteLine($"$900-$999: {this.rangos[7]}");
            Console.WriteLine($"$1000+: {this.rangos[8]}");
        }
    }
}
