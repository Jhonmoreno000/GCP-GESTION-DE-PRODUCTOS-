namespace WinFormsApp1
{
    /// <summary>
    /// Extensión parcial de la clase GPC dedicada exclusivamente a la construcción visual y diseño
    /// de los diferentes paneles de contenido (Dashboard, Inventario, Punto de Venta e Historial).
    /// </summary>
    public partial class GPC
    {
        // =========================================================================
        // 1. PANTALLA DASHBOARD (MÉTRICAS Y RESUMEN GENERAL)
        // =========================================================================
        private void InicializarPantallaDashboard()
        {
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.BackColor = System.Drawing.Color.Transparent;

            // Contenedor horizontal para las 4 tarjetas KPI superiores
            var panelKpis = new System.Windows.Forms.FlowLayoutPanel();
            panelKpis.Dock = System.Windows.Forms.DockStyle.Top;
            panelKpis.Height = 130;
            panelKpis.BackColor = System.Drawing.Color.Transparent;
            panelKpis.Margin = new System.Windows.Forms.Padding(0);

            // Tarjeta 1: Total de Productos Registrados
            this.lblKpiTotalProductos = new System.Windows.Forms.Label();
            var card1 = CrearTarjetaKpi("TOTAL PRODUCTOS", this.lblKpiTotalProductos, "📦", System.Drawing.Color.FromArgb(37, 99, 235));

            // Tarjeta 2: Productos con Stock Bajo (Alerta)
            this.lblKpiStockBajo = new System.Windows.Forms.Label();
            var card2 = CrearTarjetaKpi("STOCK CRÍTICO", this.lblKpiStockBajo, "⚠️", System.Drawing.Color.FromArgb(220, 38, 38));

            // Tarjeta 3: Total Recaudado en Ventas
            this.lblKpiTotalVentas = new System.Windows.Forms.Label();
            var card3 = CrearTarjetaKpi("TOTAL VENTAS", this.lblKpiTotalVentas, "💰", System.Drawing.Color.FromArgb(5, 150, 105));

            // Tarjeta 4: Número de Transacciones
            this.lblKpiNumVentas = new System.Windows.Forms.Label();
            var card4 = CrearTarjetaKpi("TRANSACCIONES", this.lblKpiNumVentas, "📋", System.Drawing.Color.FromArgb(124, 58, 237));

            panelKpis.Controls.AddRange(new System.Windows.Forms.Control[] { card1, card2, card3, card4 });

            // Tarjeta inferior: Tabla de alertas de stock crítico
            var cardTablaAlerta = new System.Windows.Forms.Panel();
            cardTablaAlerta.Dock = System.Windows.Forms.DockStyle.Fill;
            cardTablaAlerta.BackColor = System.Drawing.Color.White;
            cardTablaAlerta.Padding = new System.Windows.Forms.Padding(20);

            var lblAlertaTitulo = new System.Windows.Forms.Label();
            lblAlertaTitulo.Text = "⚠️ Alerta de Reabastecimiento de Inventario (Stock Bajo o Agotado)";
            lblAlertaTitulo.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            lblAlertaTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblAlertaTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            lblAlertaTitulo.Height = 35;

            this.dgvDashboardStockBajo = CrearDataGridViewEstilizado();
            this.dgvDashboardStockBajo.Dock = System.Windows.Forms.DockStyle.Fill;

            cardTablaAlerta.Controls.Add(this.dgvDashboardStockBajo);
            cardTablaAlerta.Controls.Add(lblAlertaTitulo);

            this.panelDashboard.Controls.Add(cardTablaAlerta);
            this.panelDashboard.Controls.Add(panelKpis);
            this.panelContenedor.Controls.Add(this.panelDashboard);
        }

        // =========================================================================
        // 2. PANTALLA INVENTARIO (GESTIÓN COMPLETA DE PRODUCTOS)
        // =========================================================================
        private void InicializarPantallaInventario()
        {
            this.panelInventario = new System.Windows.Forms.Panel();
            this.panelInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInventario.BackColor = System.Drawing.Color.Transparent;

            // Barra superior de búsqueda y filtrado
            var panelFiltros = new System.Windows.Forms.Panel();
            panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            panelFiltros.Height = 60;
            panelFiltros.BackColor = System.Drawing.Color.White;
            panelFiltros.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);

            var lblBuscar = new System.Windows.Forms.Label();
            lblBuscar.Text = "Buscar:";
            lblBuscar.Location = new System.Drawing.Point(15, 18);
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.txtBuscarProducto.Location = new System.Drawing.Point(70, 15);
            this.txtBuscarProducto.Width = 260;
            this.txtBuscarProducto.PlaceholderText = "Escribe código o nombre...";
            this.txtBuscarProducto.TextChanged += (s, e) => FiltrarInventario();

            var lblCat = new System.Windows.Forms.Label();
            lblCat.Text = "Categoría:";
            lblCat.Location = new System.Drawing.Point(350, 18);
            lblCat.AutoSize = true;
            lblCat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);

            this.cmbFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.cmbFiltroCategoria.Location = new System.Drawing.Point(425, 15);
            this.cmbFiltroCategoria.Width = 180;
            this.cmbFiltroCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroCategoria.Items.AddRange(new object[] { "Todas", "Tecnología", "Accesorios", "Cables", "Componentes", "General" });
            this.cmbFiltroCategoria.SelectedIndex = 0;
            this.cmbFiltroCategoria.SelectedIndexChanged += (s, e) => FiltrarInventario();

            panelFiltros.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblBuscar, this.txtBuscarProducto, lblCat, this.cmbFiltroCategoria
            });

            // Contenedor dividido: Izquierda (Tabla de productos), Derecha (Formulario de creación/edición)
            var splitInventario = new System.Windows.Forms.SplitContainer();
            splitInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            splitInventario.SplitterDistance = 640;
            splitInventario.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            splitInventario.Panel1.Padding = new System.Windows.Forms.Padding(0, 15, 10, 0);
            splitInventario.Panel2.Padding = new System.Windows.Forms.Padding(10, 15, 0, 0);

            // Panel Izquierdo: DataGridView de Productos
            var cardTabla = new System.Windows.Forms.Panel();
            cardTabla.Dock = System.Windows.Forms.DockStyle.Fill;
            cardTabla.BackColor = System.Drawing.Color.White;
            cardTabla.Padding = new System.Windows.Forms.Padding(15);

            this.dgvProductos = CrearDataGridViewEstilizado();
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.SelectionChanged += DgvProductos_SelectionChanged;

            cardTabla.Controls.Add(this.dgvProductos);
            splitInventario.Panel1.Controls.Add(cardTabla);

            // Panel Derecho: Formulario de edición/creación estilizado
            var cardForm = new System.Windows.Forms.Panel();
            cardForm.Dock = System.Windows.Forms.DockStyle.Fill;
            cardForm.BackColor = System.Drawing.Color.White;
            cardForm.Padding = new System.Windows.Forms.Padding(20);
            cardForm.AutoScroll = true;

            var lblTituloForm = new System.Windows.Forms.Label();
            lblTituloForm.Text = "Detalles del Producto";
            lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTituloForm.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTituloForm.Location = new System.Drawing.Point(20, 15);
            lblTituloForm.Size = new System.Drawing.Size(250, 30);

            // Controles del Formulario
            int yPos = 55;
            CrearCampoFormulario(cardForm, "Código Único:", out this.txtCodigo, ref yPos);
            CrearCampoFormulario(cardForm, "Nombre del Producto:", out this.txtNombre, ref yPos);

            var lblCatForm = new System.Windows.Forms.Label { Text = "Categoría:", Location = new System.Drawing.Point(20, yPos), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            this.cmbCategoria = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(20, yPos + 22), Width = 260, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.cmbCategoria.Items.AddRange(new object[] { "Tecnología", "Accesorios", "Cables", "Componentes", "General" });
            this.cmbCategoria.SelectedIndex = 0;
            cardForm.Controls.AddRange(new System.Windows.Forms.Control[] { lblCatForm, this.cmbCategoria });
            yPos += 55;

            CrearCampoNumerico(cardForm, "Precio de Compra ($):", out this.numPrecioCompra, ref yPos, 2, 99999);
            CrearCampoNumerico(cardForm, "Precio de Venta ($):", out this.numPrecioVenta, ref yPos, 2, 99999);
            CrearCampoNumerico(cardForm, "Stock Actual (Unidades):", out this.numStock, ref yPos, 0, 99999);
            CrearCampoNumerico(cardForm, "Stock Mínimo de Alerta:", out this.numStockMinimo, ref yPos, 0, 99999);
            this.numStockMinimo.Value = 5;

            // Botones de acción del formulario
            this.btnGuardarProducto = CrearBotonAccion("💾 Guardar / Actualizar", System.Drawing.Color.FromArgb(37, 99, 235), 20, yPos, 260);
            this.btnGuardarProducto.Click += BtnGuardarProducto_Click;

            this.btnLimpiarCampos = CrearBotonAccion("🧹 Limpiar Campos", System.Drawing.Color.FromArgb(100, 116, 139), 20, yPos + 48, 125);
            this.btnLimpiarCampos.Click += (s, e) => LimpiarFormularioProducto();

            this.btnEliminarProducto = CrearBotonAccion("🗑️ Eliminar", System.Drawing.Color.FromArgb(220, 38, 38), 155, yPos + 48, 125);
            this.btnEliminarProducto.Click += BtnEliminarProducto_Click;

            cardForm.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblTituloForm, this.btnGuardarProducto, this.btnLimpiarCampos, this.btnEliminarProducto
            });

            splitInventario.Panel2.Controls.Add(cardForm);

            this.panelInventario.Controls.Add(splitInventario);
            this.panelInventario.Controls.Add(panelFiltros);
            this.panelContenedor.Controls.Add(this.panelInventario);
        }

        // =========================================================================
        // 3. PANTALLA VENTAS (PUNTO DE VENTA Y FACTURACIÓN)
        // =========================================================================
        private void InicializarPantallaVentas()
        {
            this.panelVentas = new System.Windows.Forms.Panel();
            this.panelVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVentas.BackColor = System.Drawing.Color.Transparent;

            var splitVentas = new System.Windows.Forms.SplitContainer();
            splitVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            splitVentas.SplitterDistance = 650;
            splitVentas.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            splitVentas.Panel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);

            // --- Panel Izquierdo: Selección de producto y carrito de compras ---
            var cardCarrito = new System.Windows.Forms.Panel();
            cardCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            cardCarrito.BackColor = System.Drawing.Color.White;
            cardCarrito.Padding = new System.Windows.Forms.Padding(20);

            var lblTituloVentas = new System.Windows.Forms.Label();
            lblTituloVentas.Text = "🛒 Carrito de Venta Actual";
            lblTituloVentas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTituloVentas.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTituloVentas.Location = new System.Drawing.Point(18, 15);
            lblTituloVentas.Size = new System.Drawing.Size(300, 25);

            // Selector de producto
            var lblProdVenta = new System.Windows.Forms.Label { Text = "Seleccionar Producto:", Location = new System.Drawing.Point(20, 50), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            this.cmbVentaProducto = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(20, 72), Width = 380, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.cmbVentaProducto.SelectedIndexChanged += CmbVentaProducto_SelectedIndexChanged;

            // Etiquetas informativas de precio y stock disponible
            this.lblVentaPrecioUnitario = new System.Windows.Forms.Label { Text = "Precio: $0.00", Location = new System.Drawing.Point(20, 105), AutoSize = true, ForeColor = System.Drawing.Color.FromArgb(37, 99, 235), Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold) };
            this.lblVentaStockDisponible = new System.Windows.Forms.Label { Text = "Stock disponible: 0", Location = new System.Drawing.Point(180, 105), AutoSize = true, ForeColor = System.Drawing.Color.FromArgb(100, 116, 139), Font = new System.Drawing.Font("Segoe UI", 9.5F) };

            // Cantidad y botón agregar
            var lblCant = new System.Windows.Forms.Label { Text = "Cantidad:", Location = new System.Drawing.Point(420, 50), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            this.numVentaCantidad = new System.Windows.Forms.NumericUpDown { Location = new System.Drawing.Point(420, 72), Width = 80, Minimum = 1, Maximum = 9999, Value = 1 };

            this.btnAgregarAlCarrito = CrearBotonAccion("➕ Agregar", System.Drawing.Color.FromArgb(37, 99, 235), 515, 68, 105);
            this.btnAgregarAlCarrito.Click += BtnAgregarAlCarrito_Click;

            // Tabla del carrito
            this.dgvCarrito = CrearDataGridViewEstilizado();
            this.dgvCarrito.Location = new System.Drawing.Point(20, 140);
            this.dgvCarrito.Size = new System.Drawing.Size(600, 390);
            this.dgvCarrito.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

            this.btnQuitarDelCarrito = CrearBotonAccion("❌ Quitar Seleccionado", System.Drawing.Color.FromArgb(220, 38, 38), 20, 545, 180);
            this.btnQuitarDelCarrito.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.btnQuitarDelCarrito.Click += BtnQuitarDelCarrito_Click;

            cardCarrito.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblTituloVentas, lblProdVenta, this.cmbVentaProducto,
                this.lblVentaPrecioUnitario, this.lblVentaStockDisponible,
                lblCant, this.numVentaCantidad, this.btnAgregarAlCarrito,
                this.dgvCarrito, this.btnQuitarDelCarrito
            });

            splitVentas.Panel1.Controls.Add(cardCarrito);

            // --- Panel Derecho: Cobro y Liquidación de Venta ---
            var cardCobro = new System.Windows.Forms.Panel();
            cardCobro.Dock = System.Windows.Forms.DockStyle.Fill;
            cardCobro.BackColor = System.Drawing.Color.White;
            cardCobro.Padding = new System.Windows.Forms.Padding(25);

            var lblCobroTitulo = new System.Windows.Forms.Label();
            lblCobroTitulo.Text = "💳 Resumen de Liquidación";
            lblCobroTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblCobroTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblCobroTitulo.Location = new System.Drawing.Point(20, 20);
            lblCobroTitulo.Size = new System.Drawing.Size(250, 30);

            int yCobro = 60;
            CrearCampoFormulario(cardCobro, "Nombre del Cliente:", out this.txtVentaCliente, ref yCobro);
            this.txtVentaCliente.Text = "Consumidor Final";

            var lblMetodo = new System.Windows.Forms.Label { Text = "Método de Pago:", Location = new System.Drawing.Point(20, yCobro), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            this.cmbVentaMetodoPago = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(20, yCobro + 22), Width = 260, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.cmbVentaMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta de Crédito / Débito", "Transferencia Bancaria" });
            this.cmbVentaMetodoPago.SelectedIndex = 0;
            cardCobro.Controls.AddRange(new System.Windows.Forms.Control[] { lblMetodo, this.cmbVentaMetodoPago });
            yCobro += 65;

            // Tarjeta destacada con el Total
            var panelTotalCard = new System.Windows.Forms.Panel();
            panelTotalCard.Location = new System.Drawing.Point(20, yCobro);
            panelTotalCard.Size = new System.Drawing.Size(260, 110);
            panelTotalCard.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            panelTotalCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            var lblSubEtiqueta = new System.Windows.Forms.Label { Text = "Subtotal:", Location = new System.Drawing.Point(15, 12), AutoSize = true, ForeColor = System.Drawing.Color.FromArgb(100, 116, 139) };
            this.lblVentaSubtotal = new System.Windows.Forms.Label { Text = "$0.00", Location = new System.Drawing.Point(140, 12), Size = new System.Drawing.Size(100, 18), TextAlign = System.Drawing.ContentAlignment.MiddleRight, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };

            var lblTotalEtiqueta = new System.Windows.Forms.Label { Text = "TOTAL A PAGAR", Location = new System.Drawing.Point(15, 45), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(30, 41, 59) };
            this.lblVentaTotal = new System.Windows.Forms.Label { Text = "$0.00", Location = new System.Drawing.Point(15, 65), Size = new System.Drawing.Size(230, 35), Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(5, 150, 105) };

            panelTotalCard.Controls.AddRange(new System.Windows.Forms.Control[] { lblSubEtiqueta, this.lblVentaSubtotal, lblTotalEtiqueta, this.lblVentaTotal });
            cardCobro.Controls.Add(panelTotalCard);
            yCobro += 130;

            // Botones de acción de venta
            this.btnCompletarVenta = CrearBotonAccion("✅ REGISTRAR Y COBRAR VENTA", System.Drawing.Color.FromArgb(5, 150, 105), 20, yCobro, 260);
            this.btnCompletarVenta.Height = 48;
            this.btnCompletarVenta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCompletarVenta.Click += BtnCompletarVenta_Click;

            this.btnCancelarVenta = CrearBotonAccion("❌ Cancelar / Vaciar Carrito", System.Drawing.Color.FromArgb(100, 116, 139), 20, yCobro + 58, 260);
            this.btnCancelarVenta.Click += (s, e) => VaciarCarrito();

            cardCobro.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblCobroTitulo, this.btnCompletarVenta, this.btnCancelarVenta
            });

            splitVentas.Panel2.Controls.Add(cardCobro);

            this.panelVentas.Controls.Add(splitVentas);
            this.panelContenedor.Controls.Add(this.panelVentas);
        }

        // =========================================================================
        // 4. PANTALLA HISTORIAL (REGISTRO AUDITABLE DE TRANSACCIONES)
        // =========================================================================
        private void InicializarPantallaHistorial()
        {
            this.panelHistorial = new System.Windows.Forms.Panel();
            this.panelHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHistorial.BackColor = System.Drawing.Color.White;
            this.panelHistorial.Padding = new System.Windows.Forms.Padding(20);

            var lblTituloHistorial = new System.Windows.Forms.Label();
            lblTituloHistorial.Text = "📋 Registro Histórico de Ventas Realizadas";
            lblTituloHistorial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTituloHistorial.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTituloHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            lblTituloHistorial.Height = 40;

            this.dgvHistorialVentas = CrearDataGridViewEstilizado();
            this.dgvHistorialVentas.Dock = System.Windows.Forms.DockStyle.Fill;

            this.panelHistorial.Controls.Add(this.dgvHistorialVentas);
            this.panelHistorial.Controls.Add(lblTituloHistorial);
            this.panelContenedor.Controls.Add(this.panelHistorial);
        }

        // =========================================================================
        // MÉTODOS AUXILIARES PARA CREACIÓN DE ELEMENTOS VISUALES
        // =========================================================================

        /// <summary>
        /// Crea una tarjeta KPI moderna con icono, título en miniatura y número grande destacado.
        /// </summary>
        private System.Windows.Forms.Panel CrearTarjetaKpi(string titulo, System.Windows.Forms.Label lblValor, string icono, System.Drawing.Color colorBorde)
        {
            var pnl = new System.Windows.Forms.Panel();
            pnl.Width = 215;
            pnl.Height = 105;
            pnl.BackColor = System.Drawing.Color.White;
            pnl.Margin = new System.Windows.Forms.Padding(0, 0, 15, 15);
            pnl.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);

            // Borde superior o lateral de color para indicar la categoría
            var indicadorColor = new System.Windows.Forms.Panel();
            indicadorColor.Dock = System.Windows.Forms.DockStyle.Left;
            indicadorColor.Width = 4;
            indicadorColor.BackColor = colorBorde;
            pnl.Controls.Add(indicadorColor);

            var lblIcon = new System.Windows.Forms.Label();
            lblIcon.Text = icono;
            lblIcon.Font = new System.Drawing.Font("Segoe UI", 18F);
            lblIcon.Location = new System.Drawing.Point(160, 15);
            lblIcon.Size = new System.Drawing.Size(40, 40);

            var lblTit = new System.Windows.Forms.Label();
            lblTit.Text = titulo;
            lblTit.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            lblTit.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblTit.Location = new System.Drawing.Point(15, 15);
            lblTit.Size = new System.Drawing.Size(140, 18);

            lblValor.Text = "0";
            lblValor.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblValor.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblValor.Location = new System.Drawing.Point(15, 38);
            lblValor.Size = new System.Drawing.Size(150, 35);

            pnl.Controls.Add(lblTit);
            pnl.Controls.Add(lblValor);
            pnl.Controls.Add(lblIcon);

            return pnl;
        }

        /// <summary>
        /// Crea y estiliza un DataGridView con cabeceras oscuras, filas alternadas y selección suave.
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
            dgv.RowTemplate.Height = 34;

            // Encabezado moderno
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            // Estilos de filas
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);

            return dgv;
        }

        /// <summary>
        /// Crea una etiqueta y campo de texto estándar para un formulario.
        /// </summary>
        private void CrearCampoFormulario(System.Windows.Forms.Panel parent, string label, out System.Windows.Forms.TextBox txt, ref int yPos)
        {
            var lbl = new System.Windows.Forms.Label { Text = label, Location = new System.Drawing.Point(20, yPos), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(30, 41, 59) };
            txt = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(20, yPos + 20), Width = 260 };
            parent.Controls.Add(lbl);
            parent.Controls.Add(txt);
            yPos += 55;
        }

        /// <summary>
        /// Crea una etiqueta y campo numérico estándar para un formulario.
        /// </summary>
        private void CrearCampoNumerico(System.Windows.Forms.Panel parent, string label, out System.Windows.Forms.NumericUpDown num, ref int yPos, int decimales, decimal max)
        {
            var lbl = new System.Windows.Forms.Label { Text = label, Location = new System.Drawing.Point(20, yPos), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(30, 41, 59) };
            num = new System.Windows.Forms.NumericUpDown { Location = new System.Drawing.Point(20, yPos + 20), Width = 260, DecimalPlaces = decimales, Maximum = max };
            parent.Controls.Add(lbl);
            parent.Controls.Add(num);
            yPos += 55;
        }

        /// <summary>
        /// Crea un botón de acción plano con color de acento y tipografía destacada.
        /// </summary>
        private System.Windows.Forms.Button CrearBotonAccion(string texto, System.Drawing.Color color, int x, int y, int ancho)
        {
            var btn = new System.Windows.Forms.Button();
            btn.Text = texto;
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new System.Drawing.Size(ancho, 38);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White;
            btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            return btn;
        }
    }
}
