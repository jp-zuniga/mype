
using System;

namespace RegistrosRelacionados
{
	internal class Contabilidad
	{
		private const int num_ventas = 10;
		private Factura[] ventas = new Factura[num_ventas];

		public void PedirFactura(Inventario inv, int i)
		{
			ventas[i] = new Factura { Num = i };
			Console.Clear();
			Console.WriteLine($"\nIngresar datos de factura #{i+1}:");
			Console.WriteLine("-------------------------------");

			try
			{
				Console.Write("Código de Producto #1: ");
				ventas[i].C1 = int.Parse(Console.ReadLine());
				if (!inv.ValidarCodigo(ventas[i].C1)) throw new Exception();

				Console.Write("Código de Producto #2: ");
				ventas[i].C2 = int.Parse(Console.ReadLine());
				if (!inv.ValidarCodigo(ventas[i].C2)) throw new Exception();

				Console.Write("Código de Producto #3: ");
				ventas[i].C3 = int.Parse(Console.ReadLine());
				if (!inv.ValidarCodigo(ventas[i].C3)) throw new Exception();
			}

			catch
			{
				Console.Write($"\nError! Ingrese un código válido! (0 <= x < {inv.NumProductos})");
				Console.ReadKey();
				this.PedirFactura(inv, i);
			}

			Console.Write("Cliente: ");
			ventas[i].Cliente = Console.ReadLine();
			Console.Write("Monto: ");
			ventas[i].Monto = float.Parse(Console.ReadLine());
		}

		public void AgregarFacturas(Inventario inv)
		{
			for (int i = 0; i < num_ventas; i++)
			{
				this.PedirFactura(inv, i);
			}
		}
	}
}
