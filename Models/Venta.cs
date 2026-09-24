namespace WinFormsApp1.Models
{
    /// <summary>
    /// Representa un artículo individual dentro de una transacción de venta (línea del carrito).
    /// </summary>
    public class DetalleVenta
    {
        /// <summary>
        /// Código del producto vendido.
        /// </summary>
        public string CodigoProducto { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del producto vendido.
        /// </summary>
        public string NombreProducto { get; set; } = string.Empty;

        /// <summary>
        /// Cantidad de unidades vendidas de este ítem.
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Precio unitario de venta al momento de la transacción.
        /// </summary>
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Subtotal calculado para esta línea (Cantidad * PrecioUnitario).
        /// </summary>
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }

    /// <summary>
    /// Representa una transacción completa de venta registrada en el sistema.
    /// </summary>
    public class Venta
    {
        /// <summary>
        /// Identificador único o número de recibo de la venta (ej: VNT-1001).
        /// </summary>
        public string IdVenta { get; set; } = string.Empty;

        /// <summary>
        /// Fecha y hora exacta en que se registró la transacción.
        /// </summary>
        public DateTime FechaHora { get; set; } = DateTime.Now;

        /// <summary>
        /// Nombre o identificación del cliente (opcional).
        /// </summary>
        public string Cliente { get; set; } = "Cliente General";

        /// <summary>
        /// Método de pago utilizado (ej: Efectivo, Tarjeta, Transferencia).
        /// </summary>
        public string MetodoPago { get; set; } = "Efectivo";

        /// <summary>
        /// Lista de todos los productos y cantidades incluidos en la venta.
        /// </summary>
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();

        /// <summary>
        /// Total final acumulado de la venta sumando todos los ítems.
        /// </summary>
        public decimal TotalVenta => Detalles.Sum(d => d.Subtotal);
    }
}
