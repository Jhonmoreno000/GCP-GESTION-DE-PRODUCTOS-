using System;
using System.ComponentModel;

namespace WinFormsApp1
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total => Precio * Cantidad;
    }

    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ArticulosVendidos { get; set; }
        public decimal Total { get; set; }
    }

    public class ItemCarrito
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal => Precio * Cantidad;
    }

    // Datos globales compartidos entre todos los WinForms del sistema GCP
    public static class DatosGCP
    {
        public static BindingList<Producto> Productos { get; } = new BindingList<Producto>();
        public static BindingList<ItemCarrito> Carrito { get; } = new BindingList<ItemCarrito>();
        public static BindingList<Venta> Ventas { get; } = new BindingList<Venta>();

        static DatosGCP()
        {
            Productos.Add(new Producto { Id = 101, Nombre = "Arroz Extra Selección 1kg", Precio = 2.50m, Cantidad = 35 });
            Productos.Add(new Producto { Id = 102, Nombre = "Aceite Vegetal Puro 1L", Precio = 3.80m, Cantidad = 4 });
            Productos.Add(new Producto { Id = 103, Nombre = "Azúcar Blanca Refinada 1kg", Precio = 1.90m, Cantidad = 40 });
            Productos.Add(new Producto { Id = 104, Nombre = "Leche Entera Larga Vida 1L", Precio = 1.60m, Cantidad = 3 });
            Productos.Add(new Producto { Id = 105, Nombre = "Café Clásico Tostado 500g", Precio = 5.20m, Cantidad = 18 });
            Productos.Add(new Producto { Id = 106, Nombre = "Fideos Spaghetti 500g", Precio = 1.20m, Cantidad = 25 });
        }
    }
}
