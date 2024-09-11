using System;

namespace Facturacion
{
    internal class Factura
    {
        private int num_factura;
        private DateTime date;
        private float iva;
        private float efectivo;
        private float cambio;
        private float monto_total;
        private float descuento;
        private string tienda;
        private float efectivo_puntos;
        private float subtotal;
        private Cliente cliente = new Cliente();
        private Producto[] productos = new Producto[3];

        public int NumFactura { get => num_factura; set => num_factura = value; }
        public DateTime Date { get => date; set => date = value; }
        public float Iva { get => iva; set => iva = value; }
        public float Efectivo { get => efectivo; set => efectivo = value; }
        public float Cambio { get => cambio; set => cambio = value; }
        public float MontoTotal { get => monto_total; set => monto_total = value; }
        public float Descuento { get => descuento; set => descuento = value; }
        public string Tienda { get => tienda; set => tienda = value; }
        public float EfectivoPuntos { get => efectivo_puntos; set => efectivo_puntos = value; }
        public float Subtotal { get => subtotal; set => subtotal = value; }
        internal Cliente Cliente { get => cliente; set => cliente = value; }
        internal Producto[] Productos { get => productos; set => productos = value; }

        public void LeerDatos()
        {
            Console.Write("******************************************************");
            Console.Write("****************  TIENDA EL EDÉN   *******************");
            Console.Write("******************************************************\n");

            // Datos del cliente:
            Console.Write("Digite el código del cliente: ");
            this.Cliente.Id = int.Parse(Console.ReadLine());
            Console.Write("Digite el nombre del cliente: ");
            this.Cliente.Nombre = Console.ReadLine();
            Console.Write("Digite los puntos disponibles del cliente: ");
            this.Cliente.Puntos = int.Parse(Console.ReadLine());
            
            // Datos de los productos:
            for (int i = 0; i < 3; i++)
            {
                this.Productos[i] = new Producto(); // Inicializar el elemento del arreglo con un nuevo objeto

                Console.Write($"\nDigite el código del producto {i + 1}: ");
                this.Productos[i].Id = int.Parse(Console.ReadLine());
                Console.Write($"Digite el nombre del producto {i + 1}: ");
                this.Productos[i].Nombre = Console.ReadLine();
                Console.Write($"Digite el precio del producto {i + 1}: ");
                this.Productos[i].Precio = float.Parse(Console.ReadLine());
                Console.Write($"Digite la cantidad comprada del producto {i + 1}: ");
                this.Productos[i].Cantidad = int.Parse(Console.ReadLine());
            }
        }

        public void CalcularSubtotal()
        {
            subtotal = 0;

            foreach (var compra in productos)
            {
                this.subtotal += compra.Precio * compra.Cantidad;
            }
        }

        public void CalcularDesc()
        {
            this.descuento = 0;

            if (this.subtotal >= 1500 && this.subtotal <= 3000) this.descuento += this.subtotal * 0.1f;

            foreach (var compra in productos)
            {
                if (compra.Cantidad > 3) this.descuento += compra.Precio * 0.1f;
            }
        }

        public void CalcularIva() { this.iva = this.subtotal * 0.15f; }

        public void CalcularPuntos() { this.efectivo_puntos = this.cliente.Convertir(); }

        public void CalcularCambio()
        {
            Console.Write($"Tiene {this.cliente.Puntos} puntos disponibles, equivalentes a {this.cliente.Convertir()} córdobas. ¿Desea utilizar sus puntos? (s/n)");
            string respuesta = Console.ReadLine();
            bool usar_puntos = false;

            this.efectivo_puntos = cliente.Convertir();

            if (respuesta.ToLower() == "s") usar_puntos = true;
            else if (respuesta.ToLower() == "n") usar_puntos = false;
            else
            {
                Console.WriteLine();
            }

            if (usar_puntos)
            {
                if (this.efectivo_puntos >= this.monto_total)
                {
                    Console.Write("Factura cancelada con puntos!");
                    this.cliente.Puntos -= this.cliente.ContarPuntos(this.monto_total);
                }

                else
                {
                    float saldo = this.monto_total - this.efectivo_puntos;
                    Console.Write($"Digite el efectivo para completar " + "{saldo} cordobas ");
                    this.efectivo = float.Parse(Console.ReadLine());
                    this.cambio = this.efectivo - saldo;
                    Console.Write($"Su cambio es: {this.cambio} córdobas");
                    this.cliente.Puntos -= this.cliente.ContarPuntos(saldo);
                }
            }

            else
            {
                Console.Write("Digite el efectivo para pagar: ");
                this.efectivo = float.Parse(Console.ReadLine());
                this.cambio = this.monto_total - this.efectivo;
                Console.Write("Su cambio es: {0} córdobas", this.cambio);
            }
        }

        public void ImprimirFactura()
        {
            Console.Clear();
            Console.Write("*********   Tienda El Edén   *********");
            Console.Write($"Factura #{this.num_factura}");
            Console.Write($"Fecha: {this.date}");
            Console.Write("********************************");

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"ID: {this.productos[i].Id}");
                Console.Write($"Nombre: {this.productos[i].Nombre}");
                Console.Write($"Cantidad: {this.productos[i].Cantidad}");
                Console.Write($"Precio: {this.productos[i].Precio * this.productos[i].Cantidad}");
                if (i != 2) Console.Write("-------------------------------");
            }

            Console.Write("*********************************");
            Console.Write($"Subtotal: {this.subtotal}");
            Console.Write($"IVA: {this.iva}");
            Console.Write($"Descuento total: {this.Descuento}");
            Console.Write($"Total a pagar: {this.monto_total}");
            Console.Write("*********************************");
            Console.ReadKey();
            Console.Write("");
            this.CalcularCambio();
        }
    }
}