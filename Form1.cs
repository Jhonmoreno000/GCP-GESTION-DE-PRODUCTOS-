using WinFormsApp1.Models;
using WinFormsApp1.Services;

namespace WinFormsApp1
{
    /// <summary>
    /// Formulario principal de la aplicación GCP (Gestión y Control de Productos).
    /// Controla la navegación entre módulos, operaciones de inventario, punto de venta y métricas en tiempo real.
    /// </summary>
    public partial class GPC : Form
    {
        // Lista temporal que almacena los ítems del carrito de venta actual antes de ser cobrados
        private readonly List<DetalleVenta> _carritoActual = new();

        /// <summary>
        /// Constructor principal del formulario GPC.
        /// </summary>
        public GPC()
        {
            // Inicializa todos los componentes gráficos definidos en el diseñador
            InitializeComponent();

            // Configura los eventos del ciclo de vida del formulario
            this.Load += GPC_Load;
        }

        /// <summary>
        /// Evento que se ejecuta inmediatamente después de que el formulario se carga por primera vez.
        /// </summary>
        private void GPC_Load(object? sender, EventArgs e)
        {
            // Configurar columnas de las tablas del sistema
            ConfigurarColumnasTablas();

            // Cargar datos en todos los módulos
            RefrescarTodo();

            // Iniciar visualmente en el módulo de Dashboard
            MostrarModulo("dashboard");

            // Actualizar la hora en el encabezado
            ActualizarReloj();
        }

        // =========================================================================
        // NAVEGACIÓN ENTRE PANTALLAS (CAMBIO DE MÓDULOS)
        // =========================================================================

        /// <summary>
        /// Cambia la vista activa del contenedor principal y actualiza los estilos visuales
        /// de los botones de la barra lateral para indicar el módulo seleccionado.
        /// </summary>
        /// <param name="modulo">Identificador del módulo: 'dashboard', 'inventario', 'ventas', 'historial'</param>
        private void MostrarModulo(string modulo)
        {
            // Ocultar todos los paneles para mostrar solo el seleccionado
            panelDashboard.Visible = false;
            panelInventario.Visible = false;
            panelVentas.Visible = false;
            panelHistorial.Visible = false;

            // Restablecer estilos de los botones del menú lateral
            RestablecerEstiloBotonesNav();

            switch (modulo.ToLower())
            {
                case "dashboard":
                    panelDashboard.Visible = true;
                    lblTituloModulo.Text = "📊 Dashboard y Métricas";
                    lblSubtituloModulo.Text = "Resumen general de inventario, alertas y ventas";
                    ActivarBotonNav(btnNavDashboard);
                    ActualizarMetricasDashboard();
                    break;

                case "inventario":
                    panelInventario.Visible = true;
                    lblTituloModulo.Text = "📦 Gestión de Inventario";
                    lblSubtituloModulo.Text = "Catálogo completo de productos, precios y control de stock";
                    ActivarBotonNav(btnNavInventario);
                    CargarTablaProductos(GestorDatos.Instancia.Productos);
                    break;

                case "ventas":
                    panelVentas.Visible = true;
                    lblTituloModulo.Text = "🛒 Punto de Venta (POS)";
                    lblSubtituloModulo.Text = "Generación de ventas, facturación y control de salida de mercancía";
                    ActivarBotonNav(btnNavVentas);
                    CargarComboProductosVenta();
                    break;

                case "historial":
                    panelHistorial.Visible = true;
                    lblTituloModulo.Text = "📋 Historial de Transacciones";
                    lblSubtituloModulo.Text = "Auditoría de todas las ventas procesadas en el sistema";
                    ActivarBotonNav(btnNavHistorial);
                    CargarTablaHistorial();
                    break;
            }
        }

        /// <summary>
        /// Restaura el color de fondo y texto de todos los botones de la barra lateral.
        /// </summary>
        private void RestablecerEstiloBotonesNav()
        {
            var botones = new[] { btnNavDashboard, btnNavInventario, btnNavVentas, btnNavHistorial };
            foreach (var b in botones)
            {
                b.BackColor = Color.Transparent;
                b.ForeColor = Color.FromArgb(203, 213, 225);
            }
        }

        /// <summary>
        /// Destaca visualmente el botón de la barra lateral que corresponde al módulo activo.
        /// </summary>
        private void ActivarBotonNav(Button btn)
        {
            btn.BackColor = Color.FromArgb(37, 99, 235); // Azul activo
            btn.ForeColor = Color.White;
        }

        /// <summary>
        /// Actualiza la etiqueta del reloj en el encabezado con la fecha y hora del sistema.
        /// </summary>
        private void ActualizarReloj()
        {
            lblReloj.Text = DateTime.Now.ToString("dd/MM/yyyy • hh:mm:ss tt");
        }

        // =========================================================================
        // CONFIGURACIÓN DE ESTRUCTURA DE TABLAS (DATAGRIDVIEWS)
        // =========================================================================

        /// <summary>
        /// Define las columnas, formatos de texto y alineaciones para cada DataGridView.
        /// </summary>
        private void ConfigurarColumnasTablas()
        {
            // 1. Tabla de Inventario de Productos
            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add("Codigo", "Código");
            dgvProductos.Columns.Add("Nombre", "Descripción del Producto");
            dgvProductos.Columns.Add("Categoria", "Categoría");
            dgvProductos.Columns.Add("PrecioCompra", "P. Compra");
            dgvProductos.Columns.Add("PrecioVenta", "P. Venta");
            dgvProductos.Columns.Add("Stock", "Stock Actual");
            dgvProductos.Columns.Add("StockMinimo", "Mínimo");
            dgvProductos.Columns.Add("Estado", "Estado Stock");

            dgvProductos.Columns["Codigo"].Width = 90;
            dgvProductos.Columns["Nombre"].Width = 180;
            dgvProductos.Columns["PrecioCompra"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["PrecioCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["PrecioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["StockMinimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 2. Tabla de Stock Bajo en Dashboard
            dgvDashboardStockBajo.Columns.Clear();
            dgvDashboardStockBajo.Columns.Add("Codigo", "Código");
            dgvDashboardStockBajo.Columns.Add("Nombre", "Producto en Riesgo");
            dgvDashboardStockBajo.Columns.Add("Categoria", "Categoría");
            dgvDashboardStockBajo.Columns.Add("Stock", "Stock Disponible");
            dgvDashboardStockBajo.Columns.Add("Minimo", "Mínimo Requerido");
            dgvDashboardStockBajo.Columns.Add("Sugerencia", "Acción Sugerida");

            dgvDashboardStockBajo.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDashboardStockBajo.Columns["Minimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 3. Tabla del Carrito de Ventas
            dgvCarrito.Columns.Clear();
            dgvCarrito.Columns.Add("Codigo", "Código");
            dgvCarrito.Columns.Add("Nombre", "Producto");
            dgvCarrito.Columns.Add("Cantidad", "Cant.");
            dgvCarrito.Columns.Add("Precio", "P. Unit.");
            dgvCarrito.Columns.Add("Subtotal", "Subtotal");

            dgvCarrito.Columns["Cantidad"].Width = 60;
            dgvCarrito.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCarrito.Columns["Precio"].DefaultCellStyle.Format = "C2";
            dgvCarrito.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCarrito.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            dgvCarrito.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // 4. Tabla del Historial de Ventas
            dgvHistorialVentas.Columns.Clear();
            dgvHistorialVentas.Columns.Add("IdVenta", "N° Transacción");
            dgvHistorialVentas.Columns.Add("FechaHora", "Fecha y Hora");
            dgvHistorialVentas.Columns.Add("Cliente", "Cliente");
            dgvHistorialVentas.Columns.Add("MetodoPago", "Método de Pago");
            dgvHistorialVentas.Columns.Add("Articulos", "Total Artículos");
            dgvHistorialVentas.Columns.Add("Total", "Monto Total");

            dgvHistorialVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvHistorialVentas.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHistorialVentas.Columns["Articulos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // =========================================================================
        // MÓDULO DASHBOARD: CÁLCULO DE KPIS Y MÉTRICAS
        // =========================================================================

        /// <summary>
        /// Recalcula en tiempo real los indicadores de rendimiento (KPIs) y la tabla de alertas.
        /// </summary>
        private void ActualizarMetricasDashboard()
        {
            var productos = GestorDatos.Instancia.Productos;
            var ventas = GestorDatos.Instancia.Ventas;

            // 1. Total productos
            lblKpiTotalProductos.Text = productos.Count.ToString();

            // 2. Productos con stock menor o igual al mínimo
            int criticos = productos.Count(p => p.TieneStockBajo);
            lblKpiStockBajo.Text = criticos.ToString();

            // 3. Monto total vendido
            decimal sumaVentas = ventas.Sum(v => v.TotalVenta);
            lblKpiTotalVentas.Text = $"${sumaVentas:N2}";

            // 4. Número de ventas registradas
            lblKpiNumVentas.Text = ventas.Count.ToString();

            // Llenar tabla de alerta de stock crítico
            dgvDashboardStockBajo.Rows.Clear();
            foreach (var p in productos.Where(p => p.TieneStockBajo))
            {
                int rowIndex = dgvDashboardStockBajo.Rows.Add(
                    p.Codigo,
                    p.Nombre,
                    p.Categoria,
                    p.Stock,
                    p.StockMinimo,
                    p.Stock == 0 ? "⚠️ AGOTADO - PEDIR URGENTE" : "⚠️ Stock Bajo - Reabastecer"
                );

                // Destacar fila en tono suave de advertencia
                dgvDashboardStockBajo.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(254, 242, 242);
                dgvDashboardStockBajo.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
            }
        }

        // =========================================================================
        // MÓDULO INVENTARIO: CARGA, FILTRADO Y CRUD DE PRODUCTOS
        // =========================================================================

        /// <summary>
        /// Llena la tabla de inventario con una lista filtrada o completa de productos.
        /// </summary>
        private void CargarTablaProductos(IEnumerable<Producto> lista)
        {
            dgvProductos.Rows.Clear();
            foreach (var p in lista)
            {
                string estado = p.Stock == 0 ? "Agotado" : (p.TieneStockBajo ? "Stock Bajo" : "Normal");
                int idx = dgvProductos.Rows.Add(
                    p.Codigo,
                    p.Nombre,
                    p.Categoria,
                    p.PrecioCompra,
                    p.PrecioVenta,
                    p.Stock,
                    p.StockMinimo,
                    estado
                );

                // Resaltar en color si tiene stock bajo
                if (p.TieneStockBajo)
                {
                    dgvProductos.Rows[idx].DefaultCellStyle.BackColor = Color.FromArgb(254, 242, 242);
                    dgvProductos.Rows[idx].DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                }
            }
        }

        /// <summary>
        /// Filtra la lista de productos en tiempo real según el texto de búsqueda y la categoría seleccionada.
        /// </summary>
        private void FiltrarInventario()
        {
            string texto = txtBuscarProducto.Text.Trim().ToLower();
            string categoria = cmbFiltroCategoria.SelectedItem?.ToString() ?? "Todas";

            var filtrados = GestorDatos.Instancia.Productos.AsEnumerable();

            if (!string.IsNullOrEmpty(texto))
            {
                filtrados = filtrados.Where(p =>
                    p.Codigo.ToLower().Contains(texto) ||
                    p.Nombre.ToLower().Contains(texto)
                );
            }

            if (categoria != "Todas")
            {
                filtrados = filtrados.Where(p => p.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase));
            }

            CargarTablaProductos(filtrados);
        }

        /// <summary>
        /// Cuando el usuario hace click en una fila de la tabla, traslada los datos al formulario para editar.
        /// </summary>
        private void DgvProductos_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                var fila = dgvProductos.SelectedRows[0];
                string codigo = fila.Cells["Codigo"].Value?.ToString() ?? "";
                var prod = GestorDatos.Instancia.Productos.FirstOrDefault(p => p.Codigo == codigo);

                if (prod != null)
                {
                    txtCodigo.Text = prod.Codigo;
                    txtNombre.Text = prod.Nombre;
                    cmbCategoria.SelectedItem = prod.Categoria;
                    numPrecioCompra.Value = prod.PrecioCompra;
                    numPrecioVenta.Value = prod.PrecioVenta;
                    numStock.Value = prod.Stock;
                    numStockMinimo.Value = prod.StockMinimo;

                    // Deshabilitar edición de código si ya existe
                    txtCodigo.Enabled = false;
                    btnGuardarProducto.Text = "🔄 Actualizar Producto";
                }
            }
        }

        /// <summary>
        /// Guarda un nuevo producto o actualiza uno existente.
        /// </summary>
        private void BtnGuardarProducto_Click(object? sender, EventArgs e)
        {
            // Validaciones básicas de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Por favor ingresa un código para el producto.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor ingresa un nombre para el producto.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (numPrecioVenta.Value < numPrecioCompra.Value)
            {
                var confirm = MessageBox.Show(
                    "El precio de venta es menor que el precio de compra. ¿Deseas guardarlo de todas formas?",
                    "Advertencia de Margen",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
                if (confirm != DialogResult.Yes) return;
            }

            var prod = new Producto
            {
                Codigo = txtCodigo.Text.Trim().ToUpper(),
                Nombre = txtNombre.Text.Trim(),
                Categoria = cmbCategoria.SelectedItem?.ToString() ?? "General",
                PrecioCompra = numPrecioCompra.Value,
                PrecioVenta = numPrecioVenta.Value,
                Stock = (int)numStock.Value,
                StockMinimo = (int)numStockMinimo.Value
            };

            GestorDatos.Instancia.GuardarOActualizarProducto(prod);
            MessageBox.Show("¡Producto guardado exitosamente en el catálogo!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormularioProducto();
            RefrescarTodo();
        }

        /// <summary>
        /// Elimina el producto seleccionado tras confirmación del usuario.
        /// </summary>
        private void BtnEliminarProducto_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Selecciona un producto de la tabla para eliminarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"¿Estás seguro de que deseas eliminar permanentemente el producto '{txtNombre.Text}' ({txtCodigo.Text})?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                if (GestorDatos.Instancia.EliminarProducto(txtCodigo.Text.Trim()))
                {
                    MessageBox.Show("Producto eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormularioProducto();
                    RefrescarTodo();
                }
            }
        }

        /// <summary>
        /// Limpia los campos del formulario de producto para permitir registrar uno nuevo.
        /// </summary>
        private void LimpiarFormularioProducto()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtCodigo.Enabled = true;
            if (cmbCategoria.Items.Count > 0) cmbCategoria.SelectedIndex = 0;
            numPrecioCompra.Value = 0;
            numPrecioVenta.Value = 0;
            numStock.Value = 0;
            numStockMinimo.Value = 5;
            btnGuardarProducto.Text = "💾 Guardar Producto";
            txtCodigo.Focus();
        }

        // =========================================================================
        // MÓDULO VENTAS: PUNTO DE VENTA, CARRITO Y FACTURACIÓN
        // =========================================================================

        /// <summary>
        /// Llena el ComboBox de selección de productos para la venta.
        /// </summary>
        private void CargarComboProductosVenta()
        {
            cmbVentaProducto.Items.Clear();
            foreach (var p in GestorDatos.Instancia.Productos)
            {
                cmbVentaProducto.Items.Add(p);
            }

            if (cmbVentaProducto.Items.Count > 0)
                cmbVentaProducto.SelectedIndex = 0;
        }

        /// <summary>
        /// Actualiza los datos de precio y stock cuando el usuario cambia de producto en el ComboBox.
        /// </summary>
        private void CmbVentaProducto_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbVentaProducto.SelectedItem is Producto seleccionado)
            {
                lblVentaPrecioUnitario.Text = $"Precio: ${seleccionado.PrecioVenta:N2}";
                lblVentaStockDisponible.Text = $"Stock disponible: {seleccionado.Stock}";

                if (seleccionado.Stock <= 0)
                {
                    lblVentaStockDisponible.ForeColor = Color.Red;
                    lblVentaStockDisponible.Text = "⚠️ AGOTADO (Sin existencias)";
                }
                else
                {
                    lblVentaStockDisponible.ForeColor = Color.FromArgb(100, 116, 139);
                }

                numVentaCantidad.Maximum = Math.Max(1, seleccionado.Stock);
                numVentaCantidad.Value = 1;
            }
        }

        /// <summary>
        /// Agrega el producto seleccionado y la cantidad deseada al carrito de venta.
        /// </summary>
        private void BtnAgregarAlCarrito_Click(object? sender, EventArgs e)
        {
            if (cmbVentaProducto.SelectedItem is not Producto prod)
            {
                MessageBox.Show("Por favor selecciona un producto válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)numVentaCantidad.Value;

            if (prod.Stock <= 0)
            {
                MessageBox.Show("No hay existencias disponibles para este producto.", "Sin Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si el producto ya está en el carrito para sumar la cantidad
            var itemExistente = _carritoActual.FirstOrDefault(i => i.CodigoProducto == prod.Codigo);
            int cantidadTotal = cantidad + (itemExistente?.Cantidad ?? 0);

            if (cantidadTotal > prod.Stock)
            {
                MessageBox.Show($"La cantidad total solicitada ({cantidadTotal}) supera el stock disponible en bodega ({prod.Stock}).", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (itemExistente != null)
            {
                itemExistente.Cantidad = cantidadTotal;
            }
            else
            {
                _carritoActual.Add(new DetalleVenta
                {
                    CodigoProducto = prod.Codigo,
                    NombreProducto = prod.Nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = prod.PrecioVenta
                });
            }

            ActualizarTablaCarrito();
        }

        /// <summary>
        /// Elimina el ítem seleccionado del carrito de venta.
        /// </summary>
        private void BtnQuitarDelCarrito_Click(object? sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count > 0)
            {
                int index = dgvCarrito.SelectedRows[0].Index;
                if (index >= 0 && index < _carritoActual.Count)
                {
                    _carritoActual.RemoveAt(index);
                    ActualizarTablaCarrito();
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila del carrito para retirarla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Vacía por completo el carrito de compras actual.
        /// </summary>
        private void VaciarCarrito()
        {
            _carritoActual.Clear();
            ActualizarTablaCarrito();
        }

        /// <summary>
        /// Refresca la tabla del carrito y recalcula los totales acumulados.
        /// </summary>
        private void ActualizarTablaCarrito()
        {
            dgvCarrito.Rows.Clear();
            decimal total = 0;

            foreach (var item in _carritoActual)
            {
                dgvCarrito.Rows.Add(
                    item.CodigoProducto,
                    item.NombreProducto,
                    item.Cantidad,
                    item.PrecioUnitario,
                    item.Subtotal
                );
                total += item.Subtotal;
            }

            lblVentaSubtotal.Text = $"${total:N2}";
            lblVentaTotal.Text = $"${total:N2}";
        }

        /// <summary>
        /// Procesa la venta, descuenta inventario, genera el recibo y limpia el carrito.
        /// </summary>
        private void BtnCompletarVenta_Click(object? sender, EventArgs e)
        {
            if (_carritoActual.Count == 0)
            {
                MessageBox.Show("El carrito de compras está vacío. Agrega productos antes de procesar la venta.", "Carrito Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cliente = string.IsNullOrWhiteSpace(txtVentaCliente.Text) ? "Consumidor Final" : txtVentaCliente.Text.Trim();
            string metodoPago = cmbVentaMetodoPago.SelectedItem?.ToString() ?? "Efectivo";

            // Crear el objeto venta con número correlativo
            var nuevaVenta = new Venta
            {
                IdVenta = $"VNT-{DateTime.Now:yyyyMMdd}-{GestorDatos.Instancia.Ventas.Count + 1:D4}",
                FechaHora = DateTime.Now,
                Cliente = cliente,
                MetodoPago = metodoPago,
                Detalles = new List<DetalleVenta>(_carritoActual)
            };

            // Registrar venta y descontar stock
            if (GestorDatos.Instancia.RegistrarVenta(nuevaVenta, out string error))
            {
                MessageBox.Show(
                    $"¡Venta registrada con éxito!\n\n" +
                    $"N° Recibo: {nuevaVenta.IdVenta}\n" +
                    $"Cliente: {nuevaVenta.Cliente}\n" +
                    $"Método de Pago: {nuevaVenta.MetodoPago}\n" +
                    $"Total Cobrado: ${nuevaVenta.TotalVenta:N2}",
                    "Venta Procesada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Limpiar carrito y reiniciar controles
                VaciarCarrito();
                txtVentaCliente.Text = "Consumidor Final";
                RefrescarTodo();
            }
            else
            {
                MessageBox.Show($"No fue posible completar la venta:\n{error}", "Error al procesar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // MÓDULO HISTORIAL: AUDITORÍA DE TRANSACCIONES
        // =========================================================================

        /// <summary>
        /// Llena la tabla de historial con todas las ventas realizadas ordenadas por fecha reciente.
        /// </summary>
        private void CargarTablaHistorial()
        {
            dgvHistorialVentas.Rows.Clear();
            var ventasOrdenadas = GestorDatos.Instancia.Ventas.OrderByDescending(v => v.FechaHora);

            foreach (var v in ventasOrdenadas)
            {
                int totalArticulos = v.Detalles.Sum(d => d.Cantidad);
                dgvHistorialVentas.Rows.Add(
                    v.IdVenta,
                    v.FechaHora.ToString("dd/MM/yyyy HH:mm"),
                    v.Cliente,
                    v.MetodoPago,
                    totalArticulos,
                    v.TotalVenta
                );
            }
        }

        /// <summary>
        /// Refresca los datos en todos los módulos de la aplicación.
        /// </summary>
        private void RefrescarTodo()
        {
            FiltrarInventario();
            ActualizarMetricasDashboard();
            CargarComboProductosVenta();
            CargarTablaHistorial();
        }

        // =========================================================================
        // MÉTODOS HEREDADOS DEL FORMULARIO ORIGINAL (COMPATIBILIDAD CON RAMAS)
        // Se preservan para mantener compatibilidad con commits previos de git.
        // =========================================================================

        private void Form1_Load(object sender, EventArgs e) { }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label10_Click_1(object sender, EventArgs e) { }
        private void label16_Click(object sender, EventArgs e) { }
        private void label26_Click(object sender, EventArgs e) { }
        private void label30_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
