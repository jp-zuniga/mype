using System;

namespace Cadenas
{
	internal class Filtro
	{
		private const int num_domicilios = 3;
		Domicilio[] domicilios = new Domicilio[num_domicilios];

		public string BuscarDomicilio_Dato(int codigo)
		{
			string domicilio = "";
			for (int i = 0; i < num_domicilios; i++)
			{
				if (this.domicilios[i].Codigo == codigo)
				{
					domicilio += this.domicilios[i].Pais + " - " + this.domicilios[i].Departamento + " - ";
					domicilio += this.domicilios[i].Municipio + ": " + this.domicilios[i].Localidad + ", ";
					domicilio += this.domicilios[i].Calle + ", #" + this.domicilios[i].NumCasa;
					break;
				}
			}

			if (domicilio == "") domicilio = "Domicilio no encontrado ;-;";
			return domicilio;
		}

		public Domicilio BuscarDomicilio_Objeto(int codigo)
		{
			bool encontrado = false;
			Domicilio domicilio = new Domicilio();

			for (int i = 0; i < num_domicilios; i++)
			{
				if (this.domicilios[i].Codigo == codigo)
				{
					encontrado = true;
					domicilio.Codigo = this.domicilios[i].Codigo;
					domicilio.Pais = this.domicilios[i].Pais;
					domicilio.Departamento = this.domicilios[i].Departamento;
					domicilio.Municipio = this.domicilios[i].Municipio;
					domicilio.Localidad = this.domicilios[i].Localidad;
					domicilio.Calle = this.domicilios[i].Calle;
					domicilio.NumCasa = this.domicilios[i].NumCasa;
					break;
				}
			}

			if (!encontrado)
			{
				Console.Write("Domicilio no encontrado ;-;");
				Console.ReadKey();
				return null;
			}

			return domicilio;
		}

		public int BuscarDomicilio_Indice(int codigo)
		{
			for (int i = 0; i < num_domicilios; i++)
			{
				if (this.domicilios[i].Codigo == codigo) return i;
			}

			return -1;
		}

		public void Inicializar()
		{
			int i = 0;
			while (i < num_domicilios)
			{
				this.domicilios[i] = new Domicilio();
				Console.WriteLine($"\nIngrese los datos para el domicilio #{i+1}:");
				Console.WriteLine("--------------------------------------------");
				Console.Write("Código: ");
				try { this.domicilios[i].Codigo = int.Parse(Console.ReadLine()); }
				catch
				{
					Console.WriteLine("Por favor, ingrese un número entero para el código del domicilio!");
					continue;
				}

				Console.Write("País: ");
				this.domicilios[i].Pais = Console.ReadLine();
				Console.Write("Departamento: ");
				this.domicilios[i].Departamento = Console.ReadLine();
				Console.Write("Municipio: ");
				this.domicilios[i].Municipio = Console.ReadLine();
				Console.Write("Localidad: ");
				this.domicilios[i].Localidad = Console.ReadLine();
				Console.Write("Calle: ");
				this.domicilios[i].Calle = Console.ReadLine();
				Console.Write("Número de casa: ");
				this.domicilios[i].NumCasa = Console.ReadLine();
				i++;
			}
		}

		public void FiltrarPaises(string input_pais)
		{
			for (int i = 0; i < num_domicilios; i++)
			{
				if (this.domicilios[i].CompararPais(input_pais))
				{
					Console.WriteLine("\n------------------------------------------");
					Console.WriteLine($"Código: {this.domicilios[i].Codigo}");
					Console.WriteLine($"País: {this.domicilios[i].Pais}");
					Console.WriteLine($"Departamento: {this.domicilios[i].Departamento}");
					Console.WriteLine($"Municipio: {this.domicilios[i].Municipio}");
					Console.WriteLine($"Localidad: {this.domicilios[i].Localidad}");
					Console.WriteLine($"Calle: {this.domicilios[i].Calle}");
					Console.WriteLine($"Número de casa: {this.domicilios[i].NumCasa}");
					Console.Write("------------------------------------------");
					Console.ReadKey();
					return;
				}
			}

			Console.WriteLine("\nNo se encontraron domicilios en el país ingresado!");
			Console.ReadKey();
		}
	}
}
