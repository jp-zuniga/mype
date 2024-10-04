using System;

namespace Registros
{
	internal struct Grupo
	{
		private const int num_estudiantes = 15;
		private int num;
		private string descripcion;
		private Estudiante estudiante;

		public Grupo(int num, string desc, string cif, string nom, float prom, string dept, string mun, string dir)
		{
			this.num = num;
			this.descripcion = desc;
			this.estudiante = new Estudiante(cif, nom, prom, dept, mun, dir);
		}

		public void ImprimirDatos()
		{
			Console.WriteLine($"Número de grupo: {this.num}");
			Console.WriteLine($"Descripción: {this.descripcion}");
			Console.WriteLine("-----------------------------------------------------------------------------");
			Console.WriteLine($"CIF de estudiante: {this.estudiante.Cif}");
			Console.WriteLine($"Nombre de estudiante: {this.estudiante.Nombre}");
			Console.WriteLine($"Promedio de estudiante: {this.estudiante.Promedio}");
			Console.WriteLine("-----------------------------------------------------------------------------");
			Console.WriteLine($"Departamento de estudiante: {this.estudiante.Dir.Departamento}");
			Console.WriteLine($"Municipio de estudiante: {this.estudiante.Dir.Municipio}");
			Console.WriteLine($"Dirección de estudiante: {this.estudiante.Dir.Direccion}");
			Console.WriteLine("-----------------------------------------------------------------------------");
		}

		public int Num { get => num; set => num = value; }
		public string Descripcion { get => descripcion; set => descripcion = value; }
	}
}
