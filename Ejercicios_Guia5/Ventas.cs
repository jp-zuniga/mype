using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class Ventas
    {
        private double[,] ventas; // Arreglo para almacenar las ventas
        private int numProductos = 5;
        private int numVendedores = 4;

        public Ventas()
        {
            ventas = new double[numProductos, numVendedores];
        }

        // Registra una venta
        public void registrarVenta(int IDVendedor, int IDProdcuto, double valorVenta)
        {
            ventas[IDProdcuto, IDVendedor] += valorVenta;
        }

        // Muestra el informe de las ventas
        public void mostrarInformeVentas()
        {
            Console.WriteLine("Informe de ventas: ");
            Console.WriteLine("\t\t\tVendedor 1\tVendedor 2\tVendedor 3\tVendedor 4\tTotal por producto");

            for (int producto = 0; producto < numProductos; producto++)
            {
                double totalProducto = 0;
                Console.Write("Producto {0}\t\t", producto + 1);
                for (int vendedor = 0; vendedor < numVendedores; vendedor++)
                {
                    Console.Write("{0}\t\t", ventas[producto,vendedor]);
                    totalProducto += ventas[producto,vendedor];
                }
                Console.WriteLine("{0}", totalProducto);
            }

            Console.Write("Total por vendedor\t");
            for (int vendedor = 0; vendedor < numVendedores; vendedor++)
            {
                double totalVendedor = 0;
                for (int producto = 0; producto < numProductos; producto++)
                {
                    totalVendedor += ventas[producto, vendedor];
                }
                Console.Write("{0}\t\t", totalVendedor);
            }
            Console.WriteLine();
        }

    }
}
