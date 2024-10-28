
namespace Cadenas
{
	internal class Domicilio
	{
		private int codigo;
		private string pais;
		private string departamento;
		private string municipio;
		private string localidad;
		private string calle;
		private string num_casa;

		public int Codigo { get => codigo; set => codigo = value; }
		public string Pais { get => pais; set => pais = value; }
		public string Departamento { get => departamento; set => departamento = value; }
		public string Municipio { get => municipio; set => municipio = value; }
		public string Localidad { get => localidad; set => localidad = value; }
		public string Calle { get => calle; set => calle = value; }
		public string NumCasa { get => num_casa; set => num_casa = value; }
	}
}
