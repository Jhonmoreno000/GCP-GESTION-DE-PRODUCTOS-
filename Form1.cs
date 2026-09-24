using System.Drawing.Drawing2D;
using WinFormsApp1.Models;
using WinFormsApp1.Services;
using WinFormsApp1.UI;

namespace WinFormsApp1
{
    /// <summary>
    /// Formulario principal de la aplicación GCP Studio.
    /// Controla la navegación dinámica, renderizado de gráficas con animación,
    /// dibujo de etiquetas (badges) en tablas y lógica transaccional de inventario y ventas.
    /// </summary>
    public partial class GPC : Form
    {
        // Carrito de compras temporal en memoria
        private readonly List<DetalleVenta> _carritoActual = new();

        public GPC()
        {
            InitializeComponent();
            this.Load += GPC_Load;
        }

        private void GPC_Load(object? sender, EventArgs e)
        {
            // Configurar columnas de las tablas y activar eventos de pintura personalizada (badges)
            ConfigurarColumnasTablas();
            ConfigurarPinturaPersonalizadaTablas();

            // Cargar datos en todos los módulos y refrescar métricas
            RefrescarTodo();

            // Iniciar en el módulo de Dashboard
            MostrarModulo("dashboard");

            // Actualizar la hora en el encabezado
            ActualizarReloj();
        }

        // =========================================================================
        // NAVEGACIÓN Y EFECTOS VISUALES ENTRE MÓDULOS
        // =========================================================================

        /// <summary>
        /// Muestra el panel seleccionado, actualiza títulos y anima la barra indicadora lateral.
        /// </summary>
        private void MostrarModulo(string modulo)
        {
            panelDashboard.Visible = false;
            panelInventario.Visible = false;
            panelVentas.Visible = false;
            panelHistorial.Visible = false;

            RestablecerEstiloBotonesNav();

            switch (modulo.ToLower())
            {
                case "dashboard":
                    panelDashboard.Visible = true;
                    lblTituloModulo.Text = "📊 Dashboard y Métricas en Tiempo Real";
                    lblSubtituloModulo.Text = "Gráficas interactivas, balance de stock y alertas críticas";
                    ActivarBotonNav(btnNavDashboard);
                    ActualizarMetricasDashboard();
                    // Disparar animación de crecimiento de las gráficas
                    graficaBarras.IniciarAnimacion();
                    graficaDona.IniciarAnimacion();
                    break;

                case "inventario":
                    panelInventario.Visible = true;
                    lblTituloModulo.Text = "📦 Gestión Integral de Inventario";
                    lblSubtituloModulo.Text = "Catálogo de productos, control de stock y edición ágil";
                    ActivarBotonNav(btnNavInventario);
                    CargarTablaProductos(GestorDatos.Instancia.Productos);
                    break;

                case "ventas":
                    panelVentas.Visible = true;
                    lblTituloModulo.Text = "🛒 Punto de Venta (POS Inteligente)";
                    lblSubtituloModulo.Text = "Facturación ágil, descuento automático de inventario y recibo digital";
                    ActivarBotonNav(btnNavVentas);
                    CargarComboProductosVenta();
                    break;

                case "historial":
                    panelHistorial.Visible = true;
                    lblTituloModulo.Text = "📋 Auditoría y Registro de Ventas";
                    lblSubtituloModulo.Text = "Historial completo de comprobantes y recaudación";
                    ActivarBotonNav(btnNavHistorial);
                    CargarTablaHistorial();
                    break;
            }
        }

        private void RestablecerEstiloBotonesNav()
        {
            var botones = new[] { btnNavDashboard, btnNavInventario, btnNavVentas, btnNavHistorial };
            foreach (var b in botones)
            {
                b.BackColor = Color.Transparent;
                b.ForeColor = Color.FromArgb(203, 213, 225);
            }
        }

        private void ActivarBotonNav(Button btn)
        {
            btn.BackColor = Color.FromArgb(30, 41, 59); // Slate 800 suave
            btn.ForeColor = Color.White;

            // Animar / desplazar el indicador visual lateral hacia la posición del botón activo
            panelIndicadorNav.Top = btn.Top;
            panelIndicadorNav.BringToFront();
        }

        private void ActualizarReloj()
        {
            lblReloj.Text = DateTime.Now.ToString("dd/MM/yyyy • hh:mm:ss tt");
        }

        // =========================================================================
        // CONFIGURACIÓN DE TABLAS Y BADGES (EFECTOS ESPECIALES DE DISEÑO)
        // =========================================================================

        private void ConfigurarColumnasTablas()
        {
            // 1. Inventario
            dgvProductos.Columns.Clear();
            dgvProductos.Columns.Add("Codigo", "Código");
            dgvProductos.Columns.Add("Nombre", "Descripción del Producto");
            dgvProductos.Columns.Add("Categoria", "Categoría");
            dgvProductos.Columns.Add("PrecioCompra", "P. Compra");
            dgvProductos.Columns.Add("PrecioVenta", "P. Venta");
            dgvProductos.Columns.Add("Stock", "Stock Actual");
            dgvProductos.Columns.Add("StockMinimo", "Mínimo");
            dgvProductos.Columns.Add("Estado", "Estado de Stock");

            dgvProductos.Columns["Codigo"].Width = 95;
            dgvProductos.Columns["Nombre"].Width = 190;
            dgvProductos.Columns["PrecioCompra"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            dgvProductos.Columns["PrecioCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["PrecioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["StockMinimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Estado"].Width = 120;
            dgvProductos.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // 2. Dashboard Stock Bajo
            dgvDashboardStockBajo.Columns.Clear();
            dgvDashboardStockBajo.Columns.Add("Codigo", "Código");
            dgvDashboardStockBajo.Columns.Add("Nombre", "Producto");
            dgvDashboardStockBajo.Columns.Add("Categoria", "Categoría");
            dgvDashboardStockBajo.Columns.Add("Stock", "Stock");
            dgvDashboardStockBajo.Columns.Add("Minimo", "Mín.");
            dgvDashboardStockBajo.Columns.Add("Sugerencia", "Alerta");

            dgvDashboardStockBajo.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDashboardStockBajo.Columns["Minimo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDashboardStockBajo.Columns["Sugerencia"].Width = 140;

            // 3. Carrito Ventas
            dgvCarrito.Columns.Clear();
            dgvCarrito.Columns.Add("Codigo", "Código");
            dgvCarrito.Columns.Add("Nombre", "Producto");
            dgvCarrito.Columns.Add("Cantidad", "Cant.");
            dgvCarrito.Columns.Add("Precio", "P. Unit.");
            dgvCarrito.Columns.Add("Subtotal", "Subtotal");

            dgvCarrito.Columns["Cantidad"].Width = 65;
            dgvCarrito.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCarrito.Columns["Precio"].DefaultCellStyle.Format = "C2";
            dgvCarrito.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCarrito.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            dgvCarrito.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // 4. Historial
            dgvHistorialVentas.Columns.Clear();
            dgvHistorialVentas.Columns.Add("IdVenta", "N° Transacción");
            dgvHistorialVentas.Columns.Add("FechaHora", "Fecha y Hora");
            dgvHistorialVentas.Columns.Add("Cliente", "Cliente");
            dgvHistorialVentas.Columns.Add("MetodoPago", "Método de Pago");
            dgvHistorialVentas.Columns.Add("Articulos", "Artículos");
            dgvHistorialVentas.Columns.Add("Total", "Monto Total");

            dgvHistorialVentas.Columns["Total"].DefaultCellStyle.Format = "C2";
            dgvHistorialVentas.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHistorialVentas.Columns["Articulos"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Vincula el evento CellPainting para renderizar badges (pastillas) redondeadas modernas en lugar de texto plano.
        /// </summary>
        private void ConfigurarPinturaPersonalizadaTablas()
        {
            dgvProductos.CellPainting += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgvProductos.Columns["Estado"].Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                    string texto = e.Value?.ToString() ?? "";
                    Color colorFondo;
                    Color colorTexto;

                    if (texto.Contains("Agotado"))
                    {
                        colorFondo = Color.FromArgb(254, 226, 226); // Rojo pastel
                        colorTexto = Color.FromArgb(185, 28, 28);
                    }
                    else if (texto.Contains("Stock Bajo"))
                    {
                        colorFondo = Color.FromArgb(254, 243, 199); // Ámbar pastel
                        colorTexto = Color.FromArgb(180, 83, 9);
                    }
                    else
                    {
                        colorFondo = Color.FromArgb(220, 252, 231); // Verde pastel
                        colorTexto = Color.FromArgb(21, 128, 61);
                    }

                    if (e.Graphics != null)
                    {
                        DibujarPillBadge(e.Graphics, e.CellBounds, texto, colorFondo, colorTexto);
                    }
                    e.Handled = true;
                }
            };

            dgvDashboardStockBajo.CellPainting += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgvDashboardStockBajo.Columns["Sugerencia"].Index)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
                    string texto = e.Value?.ToString() ?? "";
                    Color colorFondo = Color.FromArgb(254, 226, 226);
                    Color colorTexto = Color.FromArgb(185, 28, 28);

                    if (e.Graphics != null)
                    {
                        DibujarPillBadge(e.Graphics, e.CellBounds, texto, colorFondo, colorTexto);
                    }
                    e.Handled = true;
                }
            };
        }

        /// <summary>
        /// Dibuja una pastilla (pill badge) suave con esquinas redondeadas y texto centrado.
        /// </summary>
        private void DibujarPillBadge(Graphics g, Rectangle cellBounds, string texto, Color fondo, Color textoColor)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int badgeHeight = 22;
            int badgeWidth = Math.Min(cellBounds.Width - 16, 110);
            int x = cellBounds.X + (cellBounds.Width - badgeWidth) / 2;
            int y = cellBounds.Y + (cellBounds.Height - badgeHeight) / 2;

            var rectBadge = new Rectangle(x, y, badgeWidth, badgeHeight);
            using var path = TarjetaModerna.CrearPathRectanguloRedondeado(rectBadge, badgeHeight / 2);

            using var brushFondo = new SolidBrush(fondo);
            g.FillPath(brushFondo, path);

            using var font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            using var brushTexto = new SolidBrush(textoColor);
            using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(texto, font, brushTexto, rectBadge, sf);
        }

        // =========================================================================
        // MÓDULO DASHBOARD: KPIS Y ACTUALIZACIÓN DE GRÁFICAS
        // =========================================================================

        private void ActualizarMetricasDashboard()
        {
            var productos = GestorDatos.Instancia.Productos;
            var ventas = GestorDatos.Instancia.Ventas;

            // 1. KPIs
            lblKpiTotalProductos.Text = productos.Count.ToString();
            int criticos = productos.Count(p => p.TieneStockBajo);
            lblKpiStockBajo.Text = criticos.ToString();
            decimal sumaVentas = ventas.Sum(v => v.TotalVenta);
            lblKpiTotalVentas.Text = $"${sumaVentas:N2}";
            lblKpiNumVentas.Text = ventas.Count.ToString();

            // 2. Gráfica de Barras por Categoría (Calcula el stock total disponible por categoría)
            var paletaColores = new[]
            {
                Color.FromArgb(99, 102, 241),  // Indigo
                Color.FromArgb(6, 182, 212),   // Cyan
                Color.FromArgb(16, 185, 129),  // Esmeralda
                Color.FromArgb(245, 158, 11),  // Ámbar
                Color.FromArgb(236, 72, 153),  // Rosa
                Color.FromArgb(139, 92, 246)   // Violeta
            };

            var datosPorCategoria = productos
                .GroupBy(p => p.Categoria)
                .Select((g, index) => new BarraDato
                {
                    Etiqueta = g.Key,
                    Valor = g.Sum(p => p.Stock),
                    ValorFormateado = $"{g.Sum(p => p.Stock)} unidades",
                    ColorBarra = paletaColores[index % paletaColores.Length]
                })
                .OrderByDescending(b => b.Valor)
                .ToList();

            graficaBarras.CargarDatos(datosPorCategoria);

            // 3. Gráfica de Dona: Porcentaje de productos con stock óptimo
            float porcentajeSaludable = productos.Count > 0
                ? ((productos.Count - criticos) * 100f / productos.Count)
                : 100f;
            graficaDona.PorcentajeOptimo = porcentajeSaludable;

            // 4. Llenar tabla de alerta de stock bajo
            dgvDashboardStockBajo.Rows.Clear();
            foreach (var p in productos.Where(p => p.TieneStockBajo))
            {
                dgvDashboardStockBajo.Rows.Add(
                    p.Codigo,
                    p.Nombre,
                    p.Categoria,
                    p.Stock,
                    p.StockMinimo,
                    p.Stock == 0 ? "Agotado" : "Stock Bajo"
                );
            }
        }

        // =========================================================================
        // MÓDULO INVENTARIO: CRUD Y FILTRADO
        // =========================================================================

        private void CargarTablaProductos(IEnumerable<Producto> lista)
        {
            dgvProductos.Rows.Clear();
            foreach (var p in lista)
            {
                string estado = p.Stock == 0 ? "Agotado" : (p.TieneStockBajo ? "Stock Bajo" : "Normal");
                dgvProductos.Rows.Add(
                    p.Codigo,
                    p.Nombre,
                    p.Categoria,
                    p.PrecioCompra,
                    p.PrecioVenta,
                    p.Stock,
                    p.StockMinimo,
                    estado
                );
            }
        }

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

                    txtCodigo.Enabled = false;
                    btnGuardarProducto.Text = "🔄 Actualizar Producto";
                }
            }
        }

        private void BtnGuardarProducto_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Por favor ingresa un código para el producto.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor ingresa una descripción para el producto.", "Campo Obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
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
            MessageBox.Show("¡Producto guardado exitosamente en el catálogo!", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormularioProducto();
            RefrescarTodo();
        }

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
        // MÓDULO VENTAS (POS)
        // =========================================================================

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

        private void CmbVentaProducto_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbVentaProducto.SelectedItem is Producto seleccionado)
            {
                lblVentaPrecioUnitario.Text = $"Precio: ${seleccionado.PrecioVenta:N2}";
                lblVentaStockDisponible.Text = $"Stock disponible: {seleccionado.Stock} uds";

                if (seleccionado.Stock <= 0)
                {
                    lblVentaStockDisponible.ForeColor = Color.FromArgb(239, 68, 68);
                    lblVentaStockDisponible.Text = "⚠️ AGOTADO (Sin stock)";
                }
                else if (seleccionado.TieneStockBajo)
                {
                    lblVentaStockDisponible.ForeColor = Color.FromArgb(245, 158, 11);
                }
                else
                {
                    lblVentaStockDisponible.ForeColor = Color.FromArgb(16, 185, 129);
                }

                numVentaCantidad.Maximum = Math.Max(1, seleccionado.Stock);
                numVentaCantidad.Value = 1;
            }
        }

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

            var itemExistente = _carritoActual.FirstOrDefault(i => i.CodigoProducto == prod.Codigo);
            int cantidadTotal = cantidad + (itemExistente?.Cantidad ?? 0);

            if (cantidadTotal > prod.Stock)
            {
                MessageBox.Show($"La cantidad total solicitada ({cantidadTotal}) supera el stock disponible ({prod.Stock}).", "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void VaciarCarrito()
        {
            _carritoActual.Clear();
            ActualizarTablaCarrito();
        }

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

        private void BtnCompletarVenta_Click(object? sender, EventArgs e)
        {
            if (_carritoActual.Count == 0)
            {
                MessageBox.Show("El carrito de compras está vacío. Agrega productos antes de procesar.", "Carrito Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cliente = string.IsNullOrWhiteSpace(txtVentaCliente.Text) ? "Consumidor Final" : txtVentaCliente.Text.Trim();
            string metodoPago = cmbVentaMetodoPago.SelectedItem?.ToString() ?? "Efectivo";

            var nuevaVenta = new Venta
            {
                IdVenta = $"VNT-{DateTime.Now:yyyyMMdd}-{GestorDatos.Instancia.Ventas.Count + 1:D4}",
                FechaHora = DateTime.Now,
                Cliente = cliente,
                MetodoPago = metodoPago,
                Detalles = new List<DetalleVenta>(_carritoActual)
            };

            if (GestorDatos.Instancia.RegistrarVenta(nuevaVenta, out string error))
            {
                MessageBox.Show(
                    $"🎉 ¡Venta procesada con éxito!\n\n" +
                    $"N° Recibo: {nuevaVenta.IdVenta}\n" +
                    $"Cliente: {nuevaVenta.Cliente}\n" +
                    $"Método de Pago: {nuevaVenta.MetodoPago}\n" +
                    $"Total Cobrado: ${nuevaVenta.TotalVenta:N2}",
                    "Venta Completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                VaciarCarrito();
                txtVentaCliente.Text = "Consumidor Final";
                RefrescarTodo();
            }
            else
            {
                MessageBox.Show($"No fue posible completar la venta:\n{error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // MÓDULO HISTORIAL
        // =========================================================================

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

        private void RefrescarTodo()
        {
            FiltrarInventario();
            ActualizarMetricasDashboard();
            CargarComboProductosVenta();
            CargarTablaHistorial();
        }

        // Métodos preservados para compatibilidad
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
