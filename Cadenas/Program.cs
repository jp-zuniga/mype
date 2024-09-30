
namespace Cadenas
{
	internal class Program
	{
		static void Main()
		{
			Filtro test = new Filtro();
			test.Inicializar();
			test.FiltrarPaises("Nicaragua");
		}
	}
}
