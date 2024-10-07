
namespace RegistrosRelacionados
{
	internal class Program
	{
		static void Main()
		{
			Inventario inv = new Inventario();
			inv.InicializarProductos();

			Contabilidad facturas = new Contabilidad();
			facturas.AgregarFacturas(inv);
		}
	}
}
