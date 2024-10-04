namespace Registros
{
	internal struct Domicilio
	{
		private string departamento;
		private string municipio;
		private string direccion;

		public Domicilio(string dept, string mun, string dir)
		{
			this.departamento = dept;
			this.municipio = mun;
			this.direccion = dir;
		}

		public string Departamento { get => departamento; set => departamento = value; }
		public string Municipio { get => municipio; set => municipio = value; }
		public string Direccion { get => direccion; set => direccion = value; }
	}
}
