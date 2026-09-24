using System.Text.Json;
using WinFormsApp1.Models;

namespace WinFormsApp1.Services
{
    /// <summary>
    /// Servicio centralizado para gestionar la persistencia y operaciones de datos de productos y ventas.
    /// Guarda los datos en archivos JSON locales para que no se pierdan entre reinicios.
    /// </summary>
    public class GestorDatos
    {
        // Instancia única (patrón Singleton) para compartir los datos en toda la aplicación
        private static GestorDatos? _instancia;
        public static GestorDatos Instancia => _instancia ??= new GestorDatos();

        // Rutas locales para guardar los datos en formato JSON
        private readonly string _rutaArchivoProductos;
        private readonly string _rutaArchivoVentas;

        /// <summary>
        /// Colección en memoria de productos disponibles en el inventario.
        /// </summary>
        public List<Producto> Productos { get; private set; } = new();

        /// <summary>
        /// Colección en memoria del histórico de ventas realizadas.
        /// </summary>
        public List<Venta> Ventas { get; private set; } = new();

        private GestorDatos()
        {
            // Carpeta de almacenamiento local en la carpeta de la aplicación
            string carpetaApp = AppDomain.CurrentDomain.BaseDirectory;
            _rutaArchivoProductos = Path.Combine(carpetaApp, "productos.json");
            _rutaArchivoVentas = Path.Combine(carpetaApp, "ventas.json");

            // Cargar datos existentes o sembrar datos de ejemplo iniciales
            CargarDatos();
        }

        /// <summary>
        /// Carga los datos desde los archivos JSON locales. Si no existen, carga un conjunto de datos iniciales.
        /// </summary>
        public void CargarDatos()
        {
            try
            {
                if (File.Exists(_rutaArchivoProductos))
                {
                    string jsonProductos = File.ReadAllText(_rutaArchivoProductos);
                    var cargados = JsonSerializer.Deserialize<List<Producto>>(jsonProductos);
                    if (cargados != null)
                        Productos = cargados;
                }
                else
                {
                    // Genera datos iniciales profesionales para que la app se visualice completa desde el primer inicio
                    InicializarDatosEjemplo();
                    GuardarProductos();
                }

                if (File.Exists(_rutaArchivoVentas))
                {
                    string jsonVentas = File.ReadAllText(_rutaArchivoVentas);
                    var cargadas = JsonSerializer.Deserialize<List<Venta>>(jsonVentas);
                    if (cargadas != null)
                        Ventas = cargadas;
                }
            }
            catch (Exception ex)
            {
                // En caso de cualquier error de lectura, aseguramos datos iniciales seguros
                System.Diagnostics.Debug.WriteLine($"Error al cargar datos: {ex.Message}");
                if (Productos.Count == 0)
                {
                    InicializarDatosEjemplo();
                }
            }
        }

        /// <summary>
        /// Guarda el catálogo de productos en el archivo JSON local.
        /// </summary>
        public void GuardarProductos()
        {
            try
            {
                string json = JsonSerializer.Serialize(Productos, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_rutaArchivoProductos, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al guardar productos: {ex.Message}");
            }
        }

        /// <summary>
        /// Guarda el registro de ventas en el archivo JSON local.
        /// </summary>
        public void GuardarVentas()
        {
            try
            {
                string json = JsonSerializer.Serialize(Ventas, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_rutaArchivoVentas, json);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error al guardar ventas: {ex.Message}");
            }
        }

        /// <summary>
        /// Agrega o actualiza un producto en el catálogo.
        /// </summary>
        public void GuardarOActualizarProducto(Producto producto)
        {
            var existente = Productos.FirstOrDefault(p => p.Codigo.Equals(producto.Codigo, StringComparison.OrdinalIgnoreCase));
            if (existente != null)
            {
                existente.Nombre = producto.Nombre;
                existente.Categoria = producto.Categoria;
                existente.PrecioCompra = producto.PrecioCompra;
                existente.PrecioVenta = producto.PrecioVenta;
                existente.Stock = producto.Stock;
                existente.StockMinimo = producto.StockMinimo;
            }
            else
            {
                Productos.Add(producto);
            }
            GuardarProductos();
        }

        /// <summary>
        /// Elimina un producto por su código único.
        /// </summary>
        public bool EliminarProducto(string codigo)
        {
            var producto = Productos.FirstOrDefault(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                Productos.Remove(producto);
                GuardarProductos();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Registra una nueva venta, descuenta el stock de los productos vendidos y guarda cambios.
        /// </summary>
        public bool RegistrarVenta(Venta venta, out string mensajeError)
        {
            mensajeError = string.Empty;

            // Validar stock de cada ítem antes de procesar
            foreach (var detalle in venta.Detalles)
            {
                var prod = Productos.FirstOrDefault(p => p.Codigo.Equals(detalle.CodigoProducto, StringComparison.OrdinalIgnoreCase));
                if (prod == null)
                {
                    mensajeError = $"El producto con código '{detalle.CodigoProducto}' no existe en el catálogo.";
                    return false;
                }
                if (prod.Stock < detalle.Cantidad)
                {
                    mensajeError = $"Stock insuficiente para '{prod.Nombre}'. Disponible: {prod.Stock}, Solicitado: {detalle.Cantidad}.";
                    return false;
                }
            }

            // Descontar inventario
            foreach (var detalle in venta.Detalles)
            {
                var prod = Productos.First(p => p.Codigo.Equals(detalle.CodigoProducto, StringComparison.OrdinalIgnoreCase));
                prod.Stock -= detalle.Cantidad;
            }

            // Agregar a la lista de ventas
            Ventas.Add(venta);

            // Guardar ambos archivos
            GuardarProductos();
            GuardarVentas();

            return true;
        }

        /// <summary>
        /// Rellena datos iniciales de demostración para verificar el diseño del sistema.
        /// </summary>
        private void InicializarDatosEjemplo()
        {
            Productos = new List<Producto>
            {
                new() { Codigo = "P-101", Nombre = "Laptop ThinkPad L14", Categoria = "Tecnología", PrecioCompra = 650.00m, PrecioVenta = 899.99m, Stock = 12, StockMinimo = 4 },
                new() { Codigo = "P-102", Nombre = "Mouse Inalámbrico Logitech", Categoria = "Accesorios", PrecioCompra = 12.50m, PrecioVenta = 24.99m, Stock = 35, StockMinimo = 10 },
                new() { Codigo = "P-103", Nombre = "Teclado Mecánico RGB", Categoria = "Accesorios", PrecioCompra = 30.00m, PrecioVenta = 59.90m, Stock = 8, StockMinimo = 5 },
                new() { Codigo = "P-104", Nombre = "Monitor Dell 27' 4K", Categoria = "Tecnología", PrecioCompra = 220.00m, PrecioVenta = 349.50m, Stock = 3, StockMinimo = 5 }, // Stock bajo de alerta
                new() { Codigo = "P-105", Nombre = "Cable HDMI 2.1 Ultra HD", Categoria = "Cables", PrecioCompra = 4.20m, PrecioVenta = 11.99m, Stock = 45, StockMinimo = 15 },
                new() { Codigo = "P-106", Nombre = "Memoria RAM DDR4 16GB", Categoria = "Componentes", PrecioCompra = 28.00m, PrecioVenta = 45.00m, Stock = 2, StockMinimo = 5 }, // Stock bajo
                new() { Codigo = "P-107", Nombre = "Disco SSD NVMe 1TB Kingston", Categoria = "Componentes", PrecioCompra = 50.00m, PrecioVenta = 78.50m, Stock = 18, StockMinimo = 6 }
            };
        }
    }
}
