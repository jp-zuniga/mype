
/* 
 * Autor: Joaquín A. Pérez Z.
 * Fecha de creación: 30/08/2024; Fecha de modificación: 04/09/2024
 * Versión: 1.0
 * *************************************************************************************************************
 * Desarollo de una aplicación para registrar una factura comercial, teniendo en cuenta las siguientes restricciones:
 * 1. El máximo de productos por factura es 3
 * 2. Por la compra de más de 3 unidades por producto se descuenta el 10%
 * 3. Por un monto de factura entre 1500 y 3000 se descuenta el 10% 
 * 4. El impuesto de valor agregado (IVA) es del 15%
 * 5. Por la compra de un producto en promoción se acumula 3 puntos
 * 6. El cliente puede pagar con puntos (10 puntos = C$100)
 * 7. Se debe mostrar el efectivo del pago y el cambio
 * 8. Imprimir la factura
 * -------------------------------------------------------------------------------------------------------------
 */

namespace Facturacion
{
    internal class Program
    {
        static void Main()
        {
            Factura test = new Factura();
            test.LeerDatos();
            test.CalcularSubtotal();
            test.CalcularDesc();
            test.CalcularSubtotal();
            test.CalcularCambio();
            test.ImprimirFactura();
        }
    }
}
