using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace Calificaciones
{
	internal class Calificaciones
	{
		private const int num_clases = 6;
		private const int num_estudiantes = 5;

		private string[] clases = new string[num_clases] { "MyPE", "AyDS", "CyL II", "Cálculo I", "Electiva", "Inglés", };
		private string[] estudiantes = new string[num_estudiantes];
		private double[,] notas = new double[num_estudiantes, num_clases];
		private double[] promedios = new double[num_estudiantes];

		public void RegistrarEstudiantes()
		{
			Console.WriteLine();
			for (int i = 0; i < num_estudiantes; i++)
			{
				Console.Write($"Ingrese el nombre del estudiante #{i + 1}: ");
				this.estudiantes[i] = Console.ReadLine();
			}
		}

		public void RegistrarNotas()
		{
			int i = 0;
			while (i < num_estudiantes)
			{
				int j = 0;
				Console.WriteLine("\n-------------------------------");
				Console.WriteLine($"Notas de {this.estudiantes[i]}:");
				Console.WriteLine("-------------------------------");

				while (j < num_clases)
				{
					Console.Write("Ingrese la nota de " + this.clases[j] + ": ");

					try
					{
						this.notas[i, j] = double.Parse(Console.ReadLine());

                        // no dejar que el usuario ingrese un valor que no este entre 0 y 100
                        if (this.notas[i, j] < 0 || this.notas[i, j] > 100)
						{
							Console.WriteLine("Error: Nota inválida! Por favor ingrese un valor entre 0 y 100...");
							continue;
						}
					}

					catch // mandar un mensaje de error si el usuario no ingresa un numero
					{
						Console.WriteLine("Error: Debe ingresar un número real entre 0 y 100!");
						continue;
					}

					j++;
				}

				i++;
			}
		}

		public void CalcularPromedios()
		{
			for (int i = 0; i < num_estudiantes; i++)
			{
				double suma_notas = 0;
				for (int j = 0; j < num_clases; j++)
				{
					suma_notas += this.notas[i, j];
				}

				this.promedios[i] = suma_notas / num_clases;
			}
		}

		public void ImprimirNotas()
		{
			this.CalcularPromedios();

			// primero hay que calcular la longitud maxima de todos los elementos a imprimir, para poder alinearlos
			int max_ancho = 0;
			foreach (double nota in this.notas)
			{
				// iterar sobre cada nota, convertirlo a string y comparar su longitud con la maxima
				string s = nota.ToString("F2"); // Formatear las notas a dos decimales
				if (s.Length > max_ancho) max_ancho = s.Length;
			}

			foreach (double promedio in this.promedios)
			{
				string s = promedio.ToString("F2");
				if (s.Length > max_ancho) max_ancho = s.Length;
			}

			foreach (string clase in this.clases)
			{
				// si hay una clase que es mas larga que la nota mas larga, actualizar max_ancho
				if (clase.Length > max_ancho) max_ancho = clase.Length;
			}

			foreach (string nombre in this.estudiantes)
			{
				if (nombre.Length > max_ancho) max_ancho = nombre.Length;
			}

			// crear una linea de - para separar cada linea de la tabla:
			string separador = new string('-', (max_ancho + 3) * (num_clases + 2) - 1);
			// imprimir una celda vacia:
			Console.Write('\n' + new string(' ', max_ancho + 1));

			for (int i = 0; i < num_clases; i++)
			{
				// iterar del 1 al 6 para imprimir los nombres de las clases, centrados en la celda
				string clase = this.clases[i];
				string output = "| " + clase.PadLeft((max_ancho + clase.Length) / 2).PadRight(max_ancho) + ' ';
				Console.Write(output);
			}

			string pmd = "Promedio";
			Console.WriteLine("| " + pmd.PadLeft((max_ancho + pmd.Length) / 2).PadRight(max_ancho) + " |"); //imprimir el separador
			Console.WriteLine(separador); //imprimir el separador
			for (int j = 0; j < num_estudiantes; j++)
			{
				// recorrer todas las filas e imprimir la celda con el nombre del estudiante (centrado)
				string estudiante = this.estudiantes[j].PadLeft((max_ancho + estudiantes[j].Length) / 2).PadRight(max_ancho + 1);
				string str_promedio = this.promedios[j].ToString("F2");

				Console.Write(estudiante);
				for (int k = 0; k < num_clases; k++)
				{
					// imprimir todas las notas centradas en las celdas
					string nota = this.notas[j, k].ToString("F2");
					string output = $"| {nota.PadLeft((max_ancho + nota.Length) / 2).PadRight(max_ancho)} ";
					Console.Write(output);
				}

				Console.WriteLine($"| {str_promedio.PadLeft((max_ancho + str_promedio.Length) / 2).PadRight(max_ancho)} |");
				Console.WriteLine(separador); // imprimir el separador para cerrar la tabla
			}
		}

		public string CategorizarNota(double nota)
		{
			string rango;

			if (nota >= 90 && nota <= 100) rango = "Excelente";
			else if (nota >= 80 && nota <= 89) rango = "Bueno";
			else if (nota >= 70 && nota <= 79) rango = "Regular";
			else if (nota >= 60 && nota <= 69) rango = "Reprobado";
			else rango = "Abismal";

			return rango;
		}

		public void CategorizarEstudiantes()
		{
			this.CalcularPromedios();
			Console.WriteLine();
			for (int i = 0; i < num_estudiantes; i++)
			{
				Console.WriteLine(this.estudiantes[i] + ": " + CategorizarNota(this.promedios[i]));
			}
		}

		public void AsignaturaConMasX(string tipo)
		{
			Func<double, bool> criterio; // inicializar una funcion lambda

			// definir la comparacion que la funcion lambda hara dependiendo del tipo pasado a la funcion
			if (tipo == "aprobados") criterio = nota => nota >= 70;
			else if (tipo == "reprobados") criterio = nota => nota < 70;
			else
			{
                // si no se pasa "aprobados" o "reprobados", imprimir un mensaje de error y salir
                Console.Write("Error! Por favor ingrese 'aprobados' o 'reprobados'...");
				return;
			}

			int[] contador = new int[num_clases];
			for (int i = 0; i < num_clases; i++)
			{
				for (int j = 0; j < num_estudiantes; j++)
				{
					// contar todos los estudiantes que cumplen con el criterio en cada clase
					if (criterio(this.notas[j, i])) contador[i]++;
				}
			}

			int maxIndex = Array.IndexOf(contador, contador.Max()); // encontrar el valor maximo en el arreglo
			Console.WriteLine($"\nLa asignatura con más {tipo} es {this.clases[maxIndex]} con {contador[maxIndex]} {tipo}.");
		}
	}
}
