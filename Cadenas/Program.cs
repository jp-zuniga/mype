using System;

namespace Cadenas
{
	internal class Program
	{
		static void Main()
		{
			Filtro test = new Filtro();
			test.Inicializar();
			Domicilio busqueda = test.BuscarDomicilio_Objeto(3);

			if (busqueda != null) Console.Write('\n' + busqueda.Pais);
			else Console.Write("Domicilio no encontrado ;-;");
			Console.ReadKey();
		}
	}
}
