using System;
using System.Runtime.CompilerServices;

namespace Cadenas
{
	internal class Filtro
	{
		Directorio dir = new Directorio();

		public Filtro(Directorio dir)
		{
			this.Dir = dir;
		}

		internal Directorio Dir { get => dir; set => dir = value; }

		public void FiltrarPorPais(string input_pais)
		{
			for (int i = 0; i < this.dir.Dir.Count; i++)
			{
				if (this.CompararPais(input_pais, this.dir.Dir[i].Pais))
				{
					Console.WriteLine("\n------------------------------------------");
					Console.WriteLine($"Código: {this.dir.Dir[i].Codigo}");
					Console.WriteLine($"País: {this.dir.Dir[i].Pais}");
					Console.WriteLine($"Departamento: {this.dir.Dir[i].Departamento}");
					Console.WriteLine($"Municipio: {this.dir.Dir[i].Municipio}");
					Console.WriteLine($"Localidad: {this.dir.Dir[i].Localidad}");
					Console.WriteLine($"Calle: {this.dir.Dir[i].Calle}");
					Console.WriteLine($"Número de casa: {this.dir.Dir[i].NumCasa}");
					Console.Write("------------------------------------------");
					Console.ReadKey();
					return;
				}
			}

			Console.WriteLine("\nNo se encontraron domicilios en el país ingresado!");
			Console.ReadKey();
		}

		public void FiltrarPorDepartamento(string input_dept)
		{
			for (int i = 0; i < this.dir.Dir.Count; i++)
			{
				if (this.CompararDept(input_dept, this.dir.Dir[i].Pais))
				{
					Console.WriteLine("\n------------------------------------------");
					Console.WriteLine($"Código: {this.dir.Dir[i].Codigo}");
					Console.WriteLine($"País: {this.dir.Dir[i].Pais}");
					Console.WriteLine($"Departamento: {this.dir.Dir[i].Departamento}");
					Console.WriteLine($"Municipio: {this.dir.Dir[i].Municipio}");
					Console.WriteLine($"Localidad: {this.dir.Dir[i].Localidad}");
					Console.WriteLine($"Calle: {this.dir.Dir[i].Calle}");
					Console.WriteLine($"Número de casa: {this.dir.Dir[i].NumCasa}");
					Console.Write("------------------------------------------");
					Console.ReadKey();
					return;
				}
			}

			Console.WriteLine("\nNo se encontraron domicilios en el departamento ingresado!");
			Console.ReadKey();
		}

		public void FiltrarPorMunicipio(string input_muni)
		{
			for (int i = 0; i < this.dir.Dir.Count; i++)
			{
				if (this.CompararMunicipio(input_muni, this.dir.Dir[i].Pais))
				{
					Console.WriteLine("\n------------------------------------------");
					Console.WriteLine($"Código: {this.dir.Dir[i].Codigo}");
					Console.WriteLine($"País: {this.dir.Dir[i].Pais}");
					Console.WriteLine($"Departamento: {this.dir.Dir[i].Departamento}");
					Console.WriteLine($"Municipio: {this.dir.Dir[i].Municipio}");
					Console.WriteLine($"Localidad: {this.dir.Dir[i].Localidad}");
					Console.WriteLine($"Calle: {this.dir.Dir[i].Calle}");
					Console.WriteLine($"Número de casa: {this.dir.Dir[i].NumCasa}");
					Console.Write("------------------------------------------");
					Console.ReadKey();
					return;
				}
			}

			Console.WriteLine("\nNo se encontraron domicilios en el municipio ingresado!");
			Console.ReadKey();
		}

		private bool CompararPais(string pais1, string pais2)
		{
			if (pais1.ToLower().CompareTo(pais2.ToLower()) == 0) return true;
			else return false;
		}

		private bool CompararDept(string dept1, string dept2)
		{
			if (dept1.ToLower().CompareTo(dept2.ToLower()) == 0) return true;
			else return false;
		}

		private bool CompararMunicipio(string muni1, string muni2)
		{
			if (muni1.ToLower().CompareTo(muni2.ToLower()) == 0) return true;
			else return false;
		}
	}
}
