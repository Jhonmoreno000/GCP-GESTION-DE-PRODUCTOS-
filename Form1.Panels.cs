using WinFormsApp1.UI;

namespace WinFormsApp1
{
    /// <summary>
    /// Extensión parcial de la clase GPC dedicada a la construcción modular y diseño visual
    /// de los paneles (Dashboard, Inventario, Punto de Venta e Historial) con estructura responsiva y componentes modernos.
    /// </summary>
    public partial class GPC
    {
        // =========================================================================
        // 1. PANTALLA DASHBOARD (MÉTRICAS, GRÁFICAS ANIMADAS Y TABLA DE ALERTAS)
        // =========================================================================
        private void InicializarPantallaDashboard()
        {
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.BackColor = System.Drawing.Color.Transparent;

            // --- A. Contenedor Responsivo para las 4 Tarjetas KPI (1 Fila, 4 Columnas del 25%) ---
            this.tlpKpis = new System.Windows.Forms.TableLayoutPanel();
            this.tlpKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKpis.Height = 115;
            this.tlpKpis.ColumnCount = 4;
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.RowCount = 1;
            this.tlpKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.lblKpiTotalProductos = new System.Windows.Forms.Label();
            this.lblKpiStockBajo = new System.Windows.Forms.Label();
            this.lblKpiTotalVentas = new System.Windows.Forms.Label();
            this.lblKpiNumVentas = new System.Windows.Forms.Label();

            var card1 = CrearTarjetaKpiModerna("TOTAL PRODUCTOS", this.lblKpiTotalProductos, "📦", System.Drawing.Color.FromArgb(99, 102, 241));
            var card2 = CrearTarjetaKpiModerna("STOCK CRÍTICO", this.lblKpiStockBajo, "⚠️", System.Drawing.Color.FromArgb(239, 68, 68));
            var card3 = CrearTarjetaKpiModerna("TOTAL VENTAS", this.lblKpiTotalVentas, "💰", System.Drawing.Color.FromArgb(16, 185, 129));
            var card4 = CrearTarjetaKpiModerna("TRANSACCIONES", this.lblKpiNumVentas, "📋", System.Drawing.Color.FromArgb(245, 158, 11));

            this.tlpKpis.Controls.Add(card1, 0, 0);
            this.tlpKpis.Controls.Add(card2, 1, 0);
            this.tlpKpis.Controls.Add(card3, 2, 0);
            this.tlpKpis.Controls.Add(card4, 3, 0);

            // --- B. Contenedor Responsivo para las Gráficas Visuales (1 Fila: 65% Barras, 35% Dona) ---
            this.tlpGraficas = new System.Windows.Forms.TableLayoutPanel();
            this.tlpGraficas.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpGraficas.Height = 260;
            this.tlpGraficas.ColumnCount = 2;
            this.tlpGraficas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tlpGraficas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tlpGraficas.RowCount = 1;
            this.tlpGraficas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGraficas.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);

            // Gráfica de Barras moderna con animación
            var cardBarras = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(6), Margin = new System.Windows.Forms.Padding(0, 0, 8, 0) };
            this.graficaBarras = new GraficaBarrasModerna
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Titulo = "📊 Distribución de Stock por Categoría",
                Subtitulo = "Comparativa de unidades disponibles en almacén"
            };
            cardBarras.Controls.Add(this.graficaBarras);

            // Gráfica Circular de Dona para la salud del catálogo
            var cardDona = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(6), Margin = new System.Windows.Forms.Padding(8, 0, 0, 0) };
            this.graficaDona = new GraficaDonaProgreso
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Titulo = "🎯 Salud del Inventario"
            };
            cardDona.Controls.Add(this.graficaDona);

            this.tlpGraficas.Controls.Add(cardBarras, 0, 0);
            this.tlpGraficas.Controls.Add(cardDona, 1, 0);

            // --- C. Tarjeta Inferior de Alertas de Stock Crítico ---
            var cardTablaAlerta = new TarjetaModerna();
            cardTablaAlerta.Dock = System.Windows.Forms.DockStyle.Fill;
            cardTablaAlerta.Padding = new System.Windows.Forms.Padding(18);

            var lblAlertaTitulo = new System.Windows.Forms.Label();
            lblAlertaTitulo.Text = "⚠️ Alerta de Reabastecimiento Inmediato (Productos con Stock Bajo o Agotados)";
            lblAlertaTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblAlertaTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblAlertaTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            lblAlertaTitulo.Height = 32;

            this.dgvDashboardStockBajo = CrearDataGridViewEstilizado();
            this.dgvDashboardStockBajo.Dock = System.Windows.Forms.DockStyle.Fill;

            cardTablaAlerta.Controls.Add(this.dgvDashboardStockBajo);
            cardTablaAlerta.Controls.Add(lblAlertaTitulo);

            this.panelDashboard.Controls.Add(cardTablaAlerta);
            this.panelDashboard.Controls.Add(this.tlpGraficas);
            this.panelDashboard.Controls.Add(this.tlpKpis);
            this.panelContenedor.Controls.Add(this.panelDashboard);
        }

        // =========================================================================
        // 2. PANTALLA INVENTARIO (GESTIÓN RESPONSIVA DE PRODUCTOS)
        // =========================================================================
        private void InicializarPantallaInventario()
        {
            this.panelInventario = new System.Windows.Forms.Panel();
            this.panelInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInventario.BackColor = System.Drawing.Color.Transparent;

            // Barra superior de búsqueda y filtrado en tarjeta limpia
            var cardFiltros = new TarjetaModerna();
            cardFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            cardFiltros.Height = 65;
            cardFiltros.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            cardFiltros.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);

            var lblBuscar = new System.Windows.Forms.Label { Text = "🔍 Buscar:", Location = new System.Drawing.Point(16, 20), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold) };
            this.txtBuscarProducto = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(92, 17), Width = 300, Font = new System.Drawing.Font("Segoe UI", 9.5F), PlaceholderText = "Filtrar por código o nombre..." };
            this.txtBuscarProducto.TextChanged += (s, e) => FiltrarInventario();

            var lblCat = new System.Windows.Forms.Label { Text = "Categoría:", Location = new System.Drawing.Point(420, 20), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold) };
            this.cmbFiltroCategoria = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(500, 17), Width = 180, Font = new System.Drawing.Font("Segoe UI", 9.5F), DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.cmbFiltroCategoria.Items.AddRange(new object[] { "Todas", "Tecnología", "Accesorios", "Cables", "Componentes", "General" });
            this.cmbFiltroCategoria.SelectedIndex = 0;
            this.cmbFiltroCategoria.SelectedIndexChanged += (s, e) => FiltrarInventario();

            cardFiltros.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblBuscar, this.txtBuscarProducto, lblCat, this.cmbFiltroCategoria
            });

            // Contenedor responsivo dividido en 2 columnas: 65% tabla y 35% formulario
            var splitInventario = new System.Windows.Forms.SplitContainer();
            splitInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            splitInventario.SplitterDistance = 680;
            splitInventario.BackColor = System.Drawing.Color.Transparent;
            splitInventario.Panel1.Padding = new System.Windows.Forms.Padding(0, 10, 8, 0);
            splitInventario.Panel2.Padding = new System.Windows.Forms.Padding(8, 10, 0, 0);

            // Panel Izquierdo: DataGridView en tarjeta moderna
            var cardTabla = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(16) };
            this.dgvProductos = CrearDataGridViewEstilizado();
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.SelectionChanged += DgvProductos_SelectionChanged;

            cardTabla.Controls.Add(this.dgvProductos);
            splitInventario.Panel1.Controls.Add(cardTabla);

            // Panel Derecho: Formulario de creación y edición en tarjeta moderna
            var cardForm = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(20), AutoScroll = true };

            var lblTituloForm = new System.Windows.Forms.Label();
            lblTituloForm.Text = "📝 Ficha del Producto";
            lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTituloForm.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTituloForm.Location = new System.Drawing.Point(20, 16);
            lblTituloForm.Size = new System.Drawing.Size(260, 28);

            int yPos = 52;
            CrearCampoFormulario(cardForm, "Código de Producto:", out this.txtCodigo, ref yPos);
            CrearCampoFormulario(cardForm, "Nombre / Descripción:", out this.txtNombre, ref yPos);

            var lblCatForm = new System.Windows.Forms.Label { Text = "Categoría:", Location = new System.Drawing.Point(20, yPos), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            this.cmbCategoria = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(20, yPos + 22), Width = 280, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Font = new System.Drawing.Font("Segoe UI", 9.5F) };
            this.cmbCategoria.Items.AddRange(new object[] { "Tecnología", "Accesorios", "Cables", "Componentes", "General" });
            this.cmbCategoria.SelectedIndex = 0;
            cardForm.Controls.AddRange(new System.Windows.Forms.Control[] { lblCatForm, this.cmbCategoria });
            yPos += 58;

            CrearCampoNumerico(cardForm, "Precio de Compra ($):", out this.numPrecioCompra, ref yPos, 2, 99999);
            CrearCampoNumerico(cardForm, "Precio de Venta ($):", out this.numPrecioVenta, ref yPos, 2, 99999);
            CrearCampoNumerico(cardForm, "Stock Actual:", out this.numStock, ref yPos, 0, 99999);
            CrearCampoNumerico(cardForm, "Stock Mínimo de Alerta:", out this.numStockMinimo, ref yPos, 0, 99999);
            this.numStockMinimo.Value = 5;

            // Botones modernos con esquinas redondeadas y colores dinámicos
            this.btnGuardarProducto = new BotonModerno
            {
                Text = "💾 Guardar Producto",
                ColorNormal = System.Drawing.Color.FromArgb(79, 70, 229),
                Location = new System.Drawing.Point(20, yPos),
                Size = new System.Drawing.Size(280, 42)
            };
            this.btnGuardarProducto.Click += BtnGuardarProducto_Click;

            this.btnLimpiarCampos = new BotonModerno
            {
                Text = "🧹 Limpiar",
                ColorNormal = System.Drawing.Color.FromArgb(100, 116, 139),
                Location = new System.Drawing.Point(20, yPos + 50),
                Size = new System.Drawing.Size(135, 38)
            };
            this.btnLimpiarCampos.Click += (s, e) => LimpiarFormularioProducto();

            this.btnEliminarProducto = new BotonModerno
            {
                Text = "🗑️ Eliminar",
                ColorNormal = System.Drawing.Color.FromArgb(239, 68, 68),
                Location = new System.Drawing.Point(165, yPos + 50),
                Size = new System.Drawing.Size(135, 38)
            };
            this.btnEliminarProducto.Click += BtnEliminarProducto_Click;

            cardForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblTituloForm, this.btnGuardarProducto, this.btnLimpiarCampos, this.btnEliminarProducto
            });

            splitInventario.Panel2.Controls.Add(cardForm);

            this.panelInventario.Controls.Add(splitInventario);
            this.panelInventario.Controls.Add(cardFiltros);
            this.panelContenedor.Controls.Add(this.panelInventario);
        }

        // =========================================================================
        // 3. PANTALLA VENTAS (PUNTO DE VENTA Y CARRO DIGITAL)
        // =========================================================================
        private void InicializarPantallaVentas()
        {
            this.panelVentas = new System.Windows.Forms.Panel();
            this.panelVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVentas.BackColor = System.Drawing.Color.Transparent;

            var splitVentas = new System.Windows.Forms.SplitContainer();
            splitVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            splitVentas.SplitterDistance = 700;
            splitVentas.BackColor = System.Drawing.Color.Transparent;
            splitVentas.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            splitVentas.Panel2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);

            // --- Panel Izquierdo: Selección y Carrito en Tarjeta Moderna ---
            var cardCarrito = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(20) };

            var lblTituloVentas = new System.Windows.Forms.Label();
            lblTituloVentas.Text = "🛒 Carrito de Compras / Facturación Activa";
            lblTituloVentas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTituloVentas.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTituloVentas.Location = new System.Drawing.Point(20, 16);
            lblTituloVentas.Size = new System.Drawing.Size(400, 26);

            // Selector de producto
            var lblProdVenta = new System.Windows.Forms.Label { Text = "Seleccionar Producto:", Location = new System.Drawing.Point(20, 52), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            this.cmbVentaProducto = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(20, 74), Width = 400, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Font = new System.Drawing.Font("Segoe UI", 9.5F) };
            this.cmbVentaProducto.SelectedIndexChanged += CmbVentaProducto_SelectedIndexChanged;

            // Etiquetas de precio y stock
            this.lblVentaPrecioUnitario = new System.Windows.Forms.Label { Text = "Precio: $0.00", Location = new System.Drawing.Point(20, 108), AutoSize = true, ForeColor = System.Drawing.Color.FromArgb(79, 70, 229), Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold) };
            this.lblVentaStockDisponible = new System.Windows.Forms.Label { Text = "Stock disponible: 0", Location = new System.Drawing.Point(200, 108), AutoSize = true, ForeColor = System.Drawing.Color.FromArgb(100, 116, 139), Font = new System.Drawing.Font("Segoe UI", 9.5F) };

            // Cantidad y botón agregar
            var lblCant = new System.Windows.Forms.Label { Text = "Cantidad:", Location = new System.Drawing.Point(440, 52), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            this.numVentaCantidad = new System.Windows.Forms.NumericUpDown { Location = new System.Drawing.Point(440, 74), Width = 85, Minimum = 1, Maximum = 9999, Value = 1, Font = new System.Drawing.Font("Segoe UI", 9.5F) };

            this.btnAgregarAlCarrito = new BotonModerno
            {
                Text = "➕ Agregar",
                ColorNormal = System.Drawing.Color.FromArgb(79, 70, 229),
                Location = new System.Drawing.Point(540, 70),
                Size = new System.Drawing.Size(120, 36)
            };
            this.btnAgregarAlCarrito.Click += BtnAgregarAlCarrito_Click;

            // Tabla del carrito
            this.dgvCarrito = CrearDataGridViewEstilizado();
            this.dgvCarrito.Location = new System.Drawing.Point(20, 145);
            this.dgvCarrito.Size = new System.Drawing.Size(650, 410);
            this.dgvCarrito.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

            this.btnQuitarDelCarrito = new BotonModerno
            {
                Text = "❌ Quitar Ítem",
                ColorNormal = System.Drawing.Color.FromArgb(239, 68, 68),
                Location = new System.Drawing.Point(20, 570),
                Size = new System.Drawing.Size(150, 38),
                Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            };
            this.btnQuitarDelCarrito.Click += BtnQuitarDelCarrito_Click;

            cardCarrito.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblTituloVentas, lblProdVenta, this.cmbVentaProducto,
                this.lblVentaPrecioUnitario, this.lblVentaStockDisponible,
                lblCant, this.numVentaCantidad, this.btnAgregarAlCarrito,
                this.dgvCarrito, this.btnQuitarDelCarrito
            });

            splitVentas.Panel1.Controls.Add(cardCarrito);

            // --- Panel Derecho: Resumen de Cobro y Factura ---
            var cardCobro = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(24) };

            var lblCobroTitulo = new System.Windows.Forms.Label();
            lblCobroTitulo.Text = "💳 Resumen de Pago";
            lblCobroTitulo.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            lblCobroTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblCobroTitulo.Location = new System.Drawing.Point(20, 20);
            lblCobroTitulo.Size = new System.Drawing.Size(260, 28);

            int yCobro = 62;
            CrearCampoFormulario(cardCobro, "Nombre del Cliente:", out this.txtVentaCliente, ref yCobro);
            this.txtVentaCliente.Text = "Consumidor Final";

            var lblMetodo = new System.Windows.Forms.Label { Text = "Método de Pago:", Location = new System.Drawing.Point(20, yCobro), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            this.cmbVentaMetodoPago = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(20, yCobro + 22), Width = 280, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Font = new System.Drawing.Font("Segoe UI", 9.5F) };
            this.cmbVentaMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta Débito / Crédito", "Transferencia Digital (Nequi/Daviplata)" });
            this.cmbVentaMetodoPago.SelectedIndex = 0;
            cardCobro.Controls.AddRange(new System.Windows.Forms.Control[] { lblMetodo, this.cmbVentaMetodoPago });
            yCobro += 68;

            // Panel destacado de Total a pagar estilo Recibo Digital
            var panelTotalCard = new TarjetaModerna
            {
                Location = new System.Drawing.Point(20, yCobro),
                Size = new System.Drawing.Size(280, 115),
                ColorBorde = System.Drawing.Color.FromArgb(203, 213, 225),
                Padding = new System.Windows.Forms.Padding(16)
            };

            var lblSubEtiqueta = new System.Windows.Forms.Label { Text = "Subtotal Acumulado:", Location = new System.Drawing.Point(14, 14), AutoSize = true, ForeColor = System.Drawing.Color.FromArgb(100, 116, 139) };
            this.lblVentaSubtotal = new System.Windows.Forms.Label { Text = "$0.00", Location = new System.Drawing.Point(140, 14), Size = new System.Drawing.Size(120, 18), TextAlign = System.Drawing.ContentAlignment.MiddleRight, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };

            var lblTotalEtiqueta = new System.Windows.Forms.Label { Text = "TOTAL FINAL A COBRAR", Location = new System.Drawing.Point(14, 46), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(30, 41, 59) };
            this.lblVentaTotal = new System.Windows.Forms.Label { Text = "$0.00", Location = new System.Drawing.Point(14, 68), Size = new System.Drawing.Size(250, 36), Font = new System.Drawing.Font("Segoe UI", 19F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(16, 185, 129) };

            panelTotalCard.Controls.AddRange(new System.Windows.Forms.Control[] { lblSubEtiqueta, this.lblVentaSubtotal, lblTotalEtiqueta, this.lblVentaTotal });
            cardCobro.Controls.Add(panelTotalCard);
            yCobro += 135;

            // Botones de acción de venta
            this.btnCompletarVenta = new BotonModerno
            {
                Text = "⚡ REGISTRAR Y COBRAR",
                ColorNormal = System.Drawing.Color.FromArgb(16, 185, 129),
                Location = new System.Drawing.Point(20, yCobro),
                Size = new System.Drawing.Size(280, 48),
                Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold)
            };
            this.btnCompletarVenta.Click += BtnCompletarVenta_Click;

            this.btnCancelarVenta = new BotonModerno
            {
                Text = "❌ Vaciar Carrito",
                ColorNormal = System.Drawing.Color.FromArgb(100, 116, 139),
                Location = new System.Drawing.Point(20, yCobro + 58),
                Size = new System.Drawing.Size(280, 38)
            };
            this.btnCancelarVenta.Click += (s, e) => VaciarCarrito();

            cardCobro.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblCobroTitulo, this.btnCompletarVenta, this.btnCancelarVenta
            });

            splitVentas.Panel2.Controls.Add(cardCobro);

            this.panelVentas.Controls.Add(splitVentas);
            this.panelContenedor.Controls.Add(this.panelVentas);
        }

        // =========================================================================
        // 4. PANTALLA HISTORIAL (AUDITORÍA VISUAL)
        // =========================================================================
        private void InicializarPantallaHistorial()
        {
            this.panelHistorial = new System.Windows.Forms.Panel();
            this.panelHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHistorial.BackColor = System.Drawing.Color.Transparent;

            var cardHistorial = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(20) };

            var lblTituloHistorial = new System.Windows.Forms.Label();
            lblTituloHistorial.Text = "📋 Registro Histórico de Ventas y Salidas de Almacén";
            lblTituloHistorial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTituloHistorial.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTituloHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            lblTituloHistorial.Height = 36;

            this.dgvHistorialVentas = CrearDataGridViewEstilizado();
            this.dgvHistorialVentas.Dock = System.Windows.Forms.DockStyle.Fill;

            cardHistorial.Controls.Add(this.dgvHistorialVentas);
            cardHistorial.Controls.Add(lblTituloHistorial);
            this.panelHistorial.Controls.Add(cardHistorial);
            this.panelContenedor.Controls.Add(this.panelHistorial);
        }

        // =========================================================================
        // MÉTODOS AUXILIARES PARA CREACIÓN DE ELEMENTOS VISUALES
        // =========================================================================

        /// <summary>
        /// Crea una tarjeta KPI moderna responsiva con icono distintivo, borde coloreado y valor destacado.
        /// </summary>
        private TarjetaModerna CrearTarjetaKpiModerna(string titulo, System.Windows.Forms.Label lblValor, string icono, System.Drawing.Color colorIndicador)
        {
            var pnl = new TarjetaModerna
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Margin = new System.Windows.Forms.Padding(5),
                Padding = new System.Windows.Forms.Padding(14, 12, 14, 12)
            };

            // Indicador vertical a la izquierda
            var barraIndicador = new System.Windows.Forms.Panel
            {
                Dock = System.Windows.Forms.DockStyle.Left,
                Width = 4,
                BackColor = colorIndicador
            };
            pnl.Controls.Add(barraIndicador);

            var lblIcon = new System.Windows.Forms.Label
            {
                Text = icono,
                Font = new System.Drawing.Font("Segoe UI", 20F),
                Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right),
                Location = new System.Drawing.Point(pnl.Width - 55, 14),
                Size = new System.Drawing.Size(42, 42)
            };

            var lblTit = new System.Windows.Forms.Label
            {
                Text = titulo,
                Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(100, 116, 139),
                Location = new System.Drawing.Point(14, 12),
                Size = new System.Drawing.Size(160, 18)
            };

            lblValor.Text = "0";
            lblValor.Font = new System.Drawing.Font("Segoe UI", 16.5F, System.Drawing.FontStyle.Bold);
            lblValor.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblValor.Location = new System.Drawing.Point(14, 34);
            lblValor.Size = new System.Drawing.Size(160, 36);

            pnl.Controls.Add(lblTit);
            pnl.Controls.Add(lblValor);
            pnl.Controls.Add(lblIcon);

            return pnl;
        }

        /// <summary>
        /// Crea y estiliza un DataGridView con cabeceras slate oscuras, sin bordes toscos y selección suave.
        /// </summary>
        private System.Windows.Forms.DataGridView CrearDataGridViewEstilizado()
        {
            var dgv = new System.Windows.Forms.DataGridView();
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 36;

            // Encabezado moderno
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 42;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(15, 23, 42); // Slate 900
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.2F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            // Filas alternadas suaves
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 231, 255); // Indigo muy suave
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);

            return dgv;
        }

        private void CrearCampoFormulario(System.Windows.Forms.Panel parent, string label, out System.Windows.Forms.TextBox txt, ref int yPos)
        {
            var lbl = new System.Windows.Forms.Label { Text = label, Location = new System.Drawing.Point(20, yPos), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(30, 41, 59) };
            txt = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(20, yPos + 22), Width = 280, Font = new System.Drawing.Font("Segoe UI", 9.5F) };
            parent.Controls.Add(lbl);
            parent.Controls.Add(txt);
            yPos += 58;
        }

        private void CrearCampoNumerico(System.Windows.Forms.Panel parent, string label, out System.Windows.Forms.NumericUpDown num, ref int yPos, int decimales, decimal max)
        {
            var lbl = new System.Windows.Forms.Label { Text = label, Location = new System.Drawing.Point(20, yPos), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(30, 41, 59) };
            num = new System.Windows.Forms.NumericUpDown { Location = new System.Drawing.Point(20, yPos + 22), Width = 280, DecimalPlaces = decimales, Maximum = max, Font = new System.Drawing.Font("Segoe UI", 9.5F) };
            parent.Controls.Add(lbl);
            parent.Controls.Add(num);
            yPos += 58;
        }
    }
}
