namespace WinFormsApp1.Models
{
    /// <summary>
    /// Representa un producto dentro del catálogo de inventario del sistema GCP.
    /// </summary>
    public class Producto
    {
        /// <summary>
        /// Código único o código de barras del producto (ej: PROD-001).
        /// </summary>
        public string Codigo { get; set; } = string.Empty;

        /// <summary>
        /// Nombre descriptivo del producto.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Categoría a la que pertenece el producto (ej: Bebidas, Abarrotes, Limpieza).
        /// </summary>
        public string Categoria { get; set; } = "General";

        /// <summary>
        /// Costo de adquisición o compra del producto.
        /// </summary>
        public decimal PrecioCompra { get; set; }

        /// <summary>
        /// Precio al público o venta final del producto.
        /// </summary>
        public decimal PrecioVenta { get; set; }

        /// <summary>
        /// Cantidad de unidades físicas disponibles en bodega o tienda.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Nivel mínimo de stock sugerido antes de generar una alerta de reabastecimiento.
        /// </summary>
        public int StockMinimo { get; set; } = 5;

        /// <summary>
        /// Indica si el producto se encuentra en alerta de stock bajo.
        /// </summary>
        public bool TieneStockBajo => Stock <= StockMinimo;

        /// <summary>
        /// Formato amigable para desplegar en ComboBoxes o listas de selección.
        /// </summary>
        public override string ToString()
        {
            return $"{Codigo} - {Nombre} (${PrecioVenta:N2}) [Stock: {Stock}]";
        }
    }
}
