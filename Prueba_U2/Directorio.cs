using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text;

namespace Cadenas
{
	internal class Directorio
	{
		string nombre_archivo = "domicilio.bin";
		List<Domicilio> dir = new List<Domicilio>();

		public string NombreArchivo { get => nombre_archivo; set => nombre_archivo = value; }

		internal List<Domicilio> Dir { get => dir; set => dir = value; }

		public bool CargarLista()
		{
			if (!File.Exists(NombreArchivo)) return false;

			using (var stream = File.Open(NombreArchivo, FileMode.Open, FileAccess.Read))
			{
				var reader = new BinaryReader(stream, Encoding.UTF8);
				while (stream.Position < reader.BaseStream.Length)
				{
					Domicilio domicilio = new Domicilio
					{
						Codigo = reader.ReadInt32(),
						Pais = reader.ReadString(),
						Departamento = reader.ReadString(),
						Municipio = reader.ReadString(),
						Localidad = reader.ReadString(),
						Calle = reader.ReadString(),
						NumCasa = reader.ReadString()
					};
					Dir.Add(domicilio);
				}
			}

			return true;
		}

		public void GuardarLista()
		{
			using (var stream = File.Open(NombreArchivo, FileMode.OpenOrCreate, FileAccess.Write))
			{
				var writer = new BinaryWriter(stream, Encoding.UTF8);
				foreach (Domicilio domicilio in Dir)
				{
					writer.Write(domicilio.Codigo);
					writer.Write(domicilio.Pais);
					writer.Write(domicilio.Departamento);
					writer.Write(domicilio.Municipio);
					writer.Write(domicilio.Localidad);
					writer.Write(domicilio.Calle);
					writer.Write(domicilio.NumCasa);
				}
			}

			Console.Write("\nDatos guardados exitosamente!");
			Console.ReadKey();
		}

		public void AgregarDomicilio()
		{
			this.Dir.Add(PedirDomicilio());
		}

		public Domicilio PedirDomicilio()
		{
			Domicilio domicilio_nuevo = new Domicilio();

			Console.Clear();
			Console.WriteLine($"\nIngrese los datos para el domicilio #{Dir.Count}:");
			Console.WriteLine("--------------------------------------------");

			Console.Write("Código: ");
			try { domicilio_nuevo.Codigo = int.Parse(Console.ReadLine()); }
			catch
			{
				Console.WriteLine("Error: Ingrese un número entero para el código del domicilio!");
				return this.PedirDomicilio();
			}

			Console.Write("País: ");
			domicilio_nuevo.Pais = Console.ReadLine();
			Console.Write("Departamento: ");
			domicilio_nuevo.Departamento = Console.ReadLine();
			Console.Write("Municipio: ");
			domicilio_nuevo.Municipio = Console.ReadLine();
			Console.Write("Localidad: ");
			domicilio_nuevo.Localidad = Console.ReadLine();
			Console.Write("Calle: ");
			domicilio_nuevo.Calle = Console.ReadLine();
			Console.Write("Número de casa: ");
			domicilio_nuevo.NumCasa = Console.ReadLine();

			return domicilio_nuevo;
		}

		public void EditarDomicilio()
		{
			int codigo = -1;
			Console.Write("\nIngrese el código del domicilio a editar: ");
			try { codigo = int.Parse(Console.ReadLine()); }
			catch
			{
				Console.Write("Error: Ingrese un número entero para el código del domicilio!");
				Console.ReadKey();
				return;
			}

			int indice = this.Dir.FindIndex(x => x.Codigo == codigo);
			if (indice == -1)
			{
				Console.WriteLine("Error: Domicilio no encontrado!");
				Console.ReadKey();
				return;
			}

			Console.Clear();
			Console.WriteLine($"\nDatos actuales del domicilio #{codigo}:");
			Console.WriteLine("--------------------------------------------");
			Console.WriteLine(this.ObtenerDatos(codigo));
			Console.WriteLine("--------------------------------------------");
			Console.WriteLine("¿Cuál dato desea editar?");
			Console.WriteLine("1. País");
			Console.WriteLine("2. Departamento");
			Console.WriteLine("3. Municipio");
			Console.WriteLine("4. Localidad");
			Console.WriteLine("5. Calle");
			Console.WriteLine("6. Número de casa");
			Console.WriteLine("7. Cancelar");
			Console.Write("Opción: ");

			int opcion = -1;
			try { opcion = int.Parse(Console.ReadLine()); }
			catch
			{
				Console.WriteLine("Error: Ingrese una opción válida!");
				Console.ReadKey();
				return;
			}

			switch (opcion)
			{
				case 1:
					Console.Write("Nuevo país: ");
					this.Dir[indice].Pais = Console.ReadLine();
					break;
				case 2:
					Console.Write("Nuevo departamento: ");
					this.Dir[indice].Departamento = Console.ReadLine();
					break;
				case 3:
					Console.Write("Nuevo municipio: ");
					this.Dir[indice].Municipio = Console.ReadLine();
					break;
				case 4:
					Console.Write("Nueva localidad: ");
					this.Dir[indice].Localidad = Console.ReadLine();
					break;
				case 5:
					Console.Write("Nueva calle: ");
					this.Dir[indice].Calle = Console.ReadLine();
					break;
				case 6:
					Console.Write("Nuevo número de casa: ");
					this.Dir[indice].NumCasa = Console.ReadLine();
					break;
				case 7:
					Console.Write("De acuerdo!\nRegresando al menú principal...");
					Console.ReadKey();
					return;
				default:
					Console.Write("Error: Opción inválida!\nRegresando al menú principal...");
					Console.ReadKey();
					return;
			}

			Console.Write("Domicilio editado exitosamente!");
			Console.ReadKey();
		}

		public void EliminarDomicilio()
		{
			int codigo = -1;
			Console.Write("\nIngrese el código del domicilio a eliminar: ");
			try { codigo = int.Parse(Console.ReadLine()); }
			catch
			{
				Console.Write("Error: Ingrese un número entero para el código del domicilio!");
				Console.ReadKey();
				return;
			}

			int indice = this.Dir.FindIndex(x => x.Codigo == codigo);
			if (indice == -1)
			{
				Console.WriteLine("Error: Domicilio no encontrado!");
				Console.ReadKey();
				return;
			}

			Console.Clear();
			Console.WriteLine($"\nDatos del domicilio #{codigo} a eliminar:");
			Console.WriteLine("--------------------------------------------");
			Console.WriteLine(this.ObtenerDatos(codigo));
			Console.WriteLine("--------------------------------------------");
			Console.Write("¿Desea eliminar este domicilio? (s/n): ");
			string confirmacion = Console.ReadLine();

			if (confirmacion.ToLower() == "s")
			{
				this.Dir.RemoveAt(indice);
				Console.WriteLine("Domicilio eliminado exitosamente!");
			}
			else if (confirmacion.ToLower() == "n")
			{
				Console.Write("De acuerdo!\nRegresando al menú principal...");
			}
			else
			{
				Console.Write("Opción inválida!\nRegresando al menú principal...");
			}

			Console.ReadKey();
		}


		public string ObtenerDatos(int codigo)
		{
			string domicilio = "";
			int indice = this.Dir.FindIndex(x => x.Codigo == codigo);

			if (indice == -1) return "Domicilio no encontrado!";

			domicilio += this.Dir[indice].Pais + " - " + this.Dir[indice].Departamento + " - ";
			domicilio += this.Dir[indice].Municipio + ":\n" + this.Dir[indice].Localidad + ", ";
			domicilio += this.Dir[indice].Calle + ", #" + this.Dir[indice].NumCasa;
			return domicilio;
		}

		public Domicilio ExtrarDomicilio(int codigo)
		{
			int indice = this.Dir.FindIndex(x => x.Codigo == codigo);

			if (indice == -1) return null;
			return this.Dir[indice];
		}
	}
}
