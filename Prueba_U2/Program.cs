using System;
using System.IO;

namespace Cadenas
{
	internal class Program
	{
		static void Main()
		{
			Directorio dir = new Directorio();

			try
			{
				bool exito = dir.CargarLista();
				if (!exito)
				{
					Console.Write($"\nEl fichero '{dir.NombreArchivo}' no existe!");
					Console.ReadKey();
				}
				else
				{
					Console.Write($"\nSe han cargado {dir.Dir.Count} domicilios desde el fichero 'domicilios.bin'!");
				}
			}

			catch (IOException e)
			{
				Console.Write(e);
				Console.ReadKey();
				return;
			}

			Filtro filtro = new Filtro(dir);

			Menu(dir, filtro);
		}

		static void Menu(Directorio dir, Filtro filtro)
		{
			int opcion = 0;
			while (opcion != 4)
			{
				Console.Clear();
				Console.WriteLine("Menú Principal");
				Console.WriteLine("--------------");
				Console.WriteLine("1. Agregar domicilio");
				Console.WriteLine("2. Filtrar domicilios");
				Console.WriteLine("3. Editar domicilio");
				Console.WriteLine("4. Eliminar domicilio");
				Console.WriteLine("5. Guardar datos");
				Console.WriteLine("6. Salir");
				Console.Write("\n=> ");
				try { opcion = int.Parse(Console.ReadLine()); }
				catch
				{
					Console.Write("Error: Ingrese una opción válida!");
					Console.ReadKey();
					continue;
				}

				switch (opcion)
				{
					case 1:
						dir.AgregarDomicilio();
						break;
					case 2:
						MenuFiltros(dir, filtro);
						break;
					case 3:
						dir.EditarDomicilio();
						break;
					case 4:
						dir.EliminarDomicilio();
						break;
					case 5:
						try { dir.GuardarLista(); }
						catch (IOException e)
						{
							Console.Write(e);
							Console.ReadKey();
						}

						break;
					case 6:
						Console.Write("Cerrando programa...");
						Console.ReadKey();
						return;
					default:
						Console.Write("Error: Ingrese una opción válida!");
						Console.ReadKey();
						break;
				}
			}
		}

		static void MenuFiltros(Directorio dir, Filtro filtro)
		{
			int opcion = 0;

			while (opcion != 4)
			{
				Console.Clear();
				Console.WriteLine("Menú de Filtros");
				Console.WriteLine("----------------");
				Console.WriteLine("1. Filtrar por país");
				Console.WriteLine("2. Filtrar por departamento");
				Console.WriteLine("3. Filtrar por municipio");
				Console.WriteLine("4. Regresar al menú principal");
				Console.Write("\n=> ");
				try { opcion = int.Parse(Console.ReadLine()); }
				catch
				{
					Console.Write("Error: Ingrese una opción válida!");
					Console.ReadKey();
					continue;
				}

				switch (opcion)
				{
					case 1:
						Console.Write("Ingrese el país a filtrar: ");
						string pais = Console.ReadLine();
						Console.Clear();
						filtro.FiltrarPorPais(pais);
						break;
					case 2:
						Console.Write("Ingrese el departamento a filtrar: ");
						string departamento = Console.ReadLine();
						Console.Clear();
						filtro.FiltrarPorDepartamento(departamento);
						break;
					case 3:
						Console.Write("Ingrese el municipio a filtrar: ");
						string municipio = Console.ReadLine();
						Console.Clear();
						filtro.FiltrarPorMunicipio(municipio);
						break;
					case 4:
						Console.Write("De acuerdo!\nRegresando al menú principal...");
						Console.ReadKey();
						return;
					default:
						Console.Write("Error: Ingrese una opción válida!");
						Console.ReadKey();
						break;
				}
			}
		}

	}
}
