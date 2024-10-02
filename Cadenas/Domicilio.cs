
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

		public bool CompararPais(string input_pais)
		{
			if (this.pais.ToLower().CompareTo(input_pais.ToLower()) == 0) return true;
			else return false;
		}

		public bool CompararDept(string input_dept)
		{
			if (this.departamento.ToLower().CompareTo(input_dept.ToLower()) == 0) return true;
			else return false;
		}

		public bool CompararMunicipio(string input_muni)
		{
			if (this.municipio.ToLower().CompareTo(input_muni.ToLower()) == 0) return true;
			else return false;
		}

		public string Pais { get => pais; set => pais = value; }
		public string Departamento { get => departamento; set => departamento = value; }
		public string Municipio { get => municipio; set => municipio = value; }
		public string Localidad { get => localidad; set => localidad = value; }
		public string Calle { get => calle; set => calle = value; }
		public string NumCasa { get => num_casa; set => num_casa = value; }
		public int Codigo { get => codigo; set => codigo = value; }
	}
}
