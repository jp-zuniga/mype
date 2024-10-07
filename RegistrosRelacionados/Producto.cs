
namespace RegistrosRelacionados
{
	public struct Producto
	{
		private int codigo;
		private string nombre;
		private float precio;

		public int Codigo { get => codigo; set => codigo = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public float Precio { get => precio; set => precio = value; }
	}
}
