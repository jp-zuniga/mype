namespace Facturacion
{
    internal class Producto
    {
        private int id;
        private string nombre;
        private float precio;
        private int cantidad;
        private bool promo;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public float Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public bool Promo { get => promo; set => promo = value; }
    }
}