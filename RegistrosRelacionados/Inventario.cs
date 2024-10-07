
using System;

namespace RegistrosRelacionados
{
	public class Inventario
	{
		private const int num_productos = 10;
		private Producto[] inventario = new Producto[num_productos];

		public int NumProductos => num_productos;

		public void InicializarProductos()
		{
			for (int i = 0; i < num_productos; i++) inventario[i] = new Producto { Codigo = i };

			inventario[0].Nombre = "Arroz";
			inventario[0].Precio = 2.5f;
			inventario[1].Nombre = "Azúcar";
			inventario[1].Precio = 1.75f;
			inventario[2].Nombre = "Aceite";
			inventario[2].Precio = 3.25f;
			inventario[3].Nombre = "Sal";
			inventario[3].Precio = 0.75f;
			inventario[4].Nombre = "Café";
			inventario[4].Precio = 4.5f;
			inventario[5].Nombre = "Té";
			inventario[5].Precio = 3.0f;
			inventario[6].Nombre = "Leche";
			inventario[6].Precio = 2.75f;
			inventario[7].Nombre = "Galletas";
			inventario[7].Precio = 1.35f;
			inventario[8].Nombre = "Chocolate";
			inventario[8].Precio = 2.0f;
			inventario[9].Nombre = "Mantequilla";
			inventario[9].Precio = 1.8f;
		}

		public bool ValidarCodigo(int codigo)
		{
			if (codigo < 0 || codigo >= num_productos) return false;
			else return true;
		}

		public string BuscarNombre(int codigo)
		{
			for (int i = 0; i < num_productos; i++)
			{
				if (inventario[i].Codigo == codigo)
				{
					return inventario[i].Nombre;
				}
			}

			return "";
		}

		public float BuscarPrecio(int codigo)
		{
			for (int i = 0; i < num_productos; i++)
			{
				if (inventario[i].Codigo == codigo)
				{
					return inventario[i].Precio;
				}
			}

			return -1f;
		}
	}
}
