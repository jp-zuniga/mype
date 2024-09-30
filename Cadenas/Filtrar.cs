using System;

namespace Cadenas
{
	internal class Filtro
	{
		private const int num_domicilios = 3;
		Domicilio[] domicilios = new Domicilio[num_domicilios];

		public void Inicializar()
		{
			for (int i = 0; i < num_domicilios; i++)
			{
				domicilios[i] = new Domicilio();
				Console.WriteLine($"\nIngrese los datos para el domicilio #{i+1}:");
				Console.WriteLine("--------------------------------------------");
				Console.Write("País: ");
				domicilios[i].Pais = Console.ReadLine();
				Console.Write("Departamento: ");
				domicilios[i].Departamento = Console.ReadLine();
				Console.Write("Municipio: ");
				domicilios[i].Municipio = Console.ReadLine();
				Console.Write("Localidad: ");
				domicilios[i].Localidad = Console.ReadLine();
				Console.Write("Calle: ");
				domicilios[i].Calle = Console.ReadLine();
				Console.Write("Número de casa: ");
				domicilios[i].NumCasa = Console.ReadLine();
			}
		}

		public void FiltrarPaises(string input_pais)
		{
			bool encontrado = false;
			for (int i = 0; i < num_domicilios; i++)
			{
				if (domicilios[i].CompararPais(input_pais))
				{
					encontrado = true;
					Console.WriteLine("\n------------------------------------------");
					Console.WriteLine($"País: {domicilios[i].Pais}");
					Console.WriteLine($"Departamento: {domicilios[i].Departamento}");
					Console.WriteLine($"Municipio: {domicilios[i].Municipio}");
					Console.WriteLine($"Localidad: {domicilios[i].Localidad}");
					Console.WriteLine($"Calle: {domicilios[i].Calle}");
					Console.WriteLine($"Número de casa: {domicilios[i].NumCasa}");
					Console.WriteLine("------------------------------------------");
				}
			}

			if (!encontrado) Console.WriteLine("\nNo se encontraron domicilios en el país ingresado!");
			Console.ReadKey();
		}
	}
}
