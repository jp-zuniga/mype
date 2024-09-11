namespace Facturacion
{
    internal class Cliente
    {
        private int id;
        private string nombre;
        private int puntos;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Puntos { get => puntos; set => puntos = value; }

        // Convierte los puntos en cordobas: 10 puntos = C$100; 1 punto = C$10
        public float Convertir() { return (this.puntos * 10); }

        // Calcula a cuantos puntos equivale el monto dado
        public int ContarPuntos(float monto) { return (int)(monto / 10); }
    }
}