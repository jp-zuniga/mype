namespace Registros
{
	internal struct Estudiante
	{
		private string cif;
		private string nombre;
		private float promedio;
		private Domicilio dir;

		public Estudiante(string cif, string nom, float prom, string dept, string mun, string dir)
		{
			this.cif = cif;
			this.nombre = nom;
			this.promedio = prom;
			this.dir = new Domicilio(dept, mun, dir);
		}

		public string Cif { get => cif; set => cif = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public float Promedio { get => promedio; set => promedio = value; }
		internal Domicilio Dir { get => dir; set => dir = value; }
	}
}
