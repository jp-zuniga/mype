
namespace RegistrosRelacionados
{
	public struct Factura
	{
		private int num;
		private int c1, c2, c3;
		private string cliente;
		private float monto;

		public int Num { get => num; set => num = value; }
		public int C1 { get => c1; set => c1 = value; }
		public int C2 { get => c2; set => c2 = value; }
		public int C3 { get => c3; set => c3 = value; }
		public string Cliente { get => cliente; set => cliente = value; }
		public float Monto { get => monto; set => monto = value; }
	}
}
