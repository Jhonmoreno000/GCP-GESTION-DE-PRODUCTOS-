using WinFormsApp1.UI;

namespace WinFormsApp1
{
    /// <summary>
    /// Extensión parcial de la clase GPC dedicada a la construcción de paneles visuales
    /// con diseño responsivo, teoría de color aplicada y eliminación de caracteres no soportados.
    /// </summary>
    public partial class GPC
    {
        // =========================================================================
        // 1. PANTALLA DASHBOARD
        // =========================================================================
        private void InicializarPantallaDashboard()
        {
            this.panelDashboard = new System.Windows.Forms.Panel();
            this.panelDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboard.BackColor = System.Drawing.Color.Transparent;

            // --- A. Contenedor Responsivo para las 4 Tarjetas KPI (1 Fila, 4 Columnas del 25%) ---
            this.tlpKpis = new System.Windows.Forms.TableLayoutPanel();
            this.tlpKpis.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKpis.Height = 105;
            this.tlpKpis.ColumnCount = 4;
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKpis.RowCount = 1;
            this.tlpKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            // Tarjetas con armonía cromática y badges vectoriales
            this.cardKpiProductos = new TarjetaKpiModerna
            {
                Titulo = "TOTAL PRODUCTOS",
                Valor = "0",
                Subtitulo = "Catálogo activo",
                Icono = "caja",
                ColorAcento = System.Drawing.Color.FromArgb(99, 102, 241), // Índigo
                ColorFondoIcono = System.Drawing.Color.FromArgb(238, 242, 255)
            };

            this.cardKpiStockCritico = new TarjetaKpiModerna
            {
                Titulo = "STOCK CRÍTICO",
                Valor = "0",
                Subtitulo = "Requiere atención",
                Icono = "alerta",
                ColorAcento = System.Drawing.Color.FromArgb(239, 68, 68), // Rojo carmesí
                ColorFondoIcono = System.Drawing.Color.FromArgb(254, 242, 242)
            };

            this.cardKpiVentas = new TarjetaKpiModerna
            {
                Titulo = "TOTAL VENTAS",
                Valor = "$0,00",
                Subtitulo = "Ingresos acumulados",
                Icono = "moneda",
                ColorAcento = System.Drawing.Color.FromArgb(16, 185, 129), // Verde esmeralda
                ColorFondoIcono = System.Drawing.Color.FromArgb(236, 253, 245)
            };

            this.cardKpiTransacciones = new TarjetaKpiModerna
            {
                Titulo = "TRANSACCIONES",
                Valor = "0",
                Subtitulo = "Ventas procesadas",
                Icono = "reporte",
                ColorAcento = System.Drawing.Color.FromArgb(245, 158, 11), // Ámbar cálido
                ColorFondoIcono = System.Drawing.Color.FromArgb(255, 251, 235)
            };

            this.tlpKpis.Controls.Add(this.cardKpiProductos, 0, 0);
            this.tlpKpis.Controls.Add(this.cardKpiStockCritico, 1, 0);
            this.tlpKpis.Controls.Add(this.cardKpiVentas, 2, 0);
            this.tlpKpis.Controls.Add(this.cardKpiTransacciones, 3, 0);

            // --- B. Contenedor Responsivo para las Gráficas Visuales ---
            this.tlpGraficas = new System.Windows.Forms.TableLayoutPanel();
            this.tlpGraficas.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpGraficas.Height = 235;
            this.tlpGraficas.ColumnCount = 2;
            this.tlpGraficas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tlpGraficas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tlpGraficas.RowCount = 1;
            this.tlpGraficas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGraficas.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);

            var cardBarras = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(6), Margin = new System.Windows.Forms.Padding(0, 0, 6, 0) };
            this.graficaBarras = new GraficaBarrasModerna
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Titulo = "Distribución de Stock por Categoría",
                Subtitulo = "Comparativa de unidades disponibles en almacén"
            };
            cardBarras.Controls.Add(this.graficaBarras);

            var cardDona = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(6), Margin = new System.Windows.Forms.Padding(6, 0, 0, 0) };
            this.graficaDona = new GraficaDonaProgreso
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Titulo = "Salud del Inventario"
            };
            cardDona.Controls.Add(this.graficaDona);

            this.tlpGraficas.Controls.Add(cardBarras, 0, 0);
            this.tlpGraficas.Controls.Add(cardDona, 1, 0);

            // --- C. Tarjeta Inferior de Alertas de Stock Crítico ---
            var cardTablaAlerta = new TarjetaModerna();
            cardTablaAlerta.Dock = System.Windows.Forms.DockStyle.Fill;
            cardTablaAlerta.Padding = new System.Windows.Forms.Padding(18);

            var pnlTituloAlerta = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Top, Height = 28 };
            var pnlIconoAlerta = new System.Windows.Forms.Panel { Location = new System.Drawing.Point(0, 4), Size = new System.Drawing.Size(18, 18) };
            pnlIconoAlerta.Paint += (s, e) => VectorIconHelper.DibujarIcono(e.Graphics, "alerta", pnlIconoAlerta.ClientRectangle, System.Drawing.Color.FromArgb(239, 68, 68));

            var lblAlertaTitulo = new System.Windows.Forms.Label
            {
                Text = "Alerta de Reabastecimiento Inmediato (Productos con Stock Bajo o Agotados)",
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(15, 23, 42),
                Location = new System.Drawing.Point(24, 2),
                AutoSize = true
            };

            pnlTituloAlerta.Controls.Add(pnlIconoAlerta);
            pnlTituloAlerta.Controls.Add(lblAlertaTitulo);

            this.dgvDashboardStockBajo = CrearDataGridViewEstilizado();
            this.dgvDashboardStockBajo.Dock = System.Windows.Forms.DockStyle.Fill;

            cardTablaAlerta.Controls.Add(this.dgvDashboardStockBajo);
            cardTablaAlerta.Controls.Add(pnlTituloAlerta);

            this.panelDashboard.Controls.Add(cardTablaAlerta);
            this.panelDashboard.Controls.Add(this.tlpGraficas);
            this.panelDashboard.Controls.Add(this.tlpKpis);
            this.panelContenedor.Controls.Add(this.panelDashboard);
        }

        // =========================================================================
        // 2. PANTALLA INVENTARIO
        // =========================================================================
        private void InicializarPantallaInventario()
        {
            this.panelInventario = new System.Windows.Forms.Panel();
            this.panelInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInventario.BackColor = System.Drawing.Color.Transparent;

            var cardFiltros = new TarjetaModerna();
            cardFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            cardFiltros.Height = 60;
            cardFiltros.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            cardFiltros.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);

            var lblBuscar = new System.Windows.Forms.Label { Text = "Buscar:", Location = new System.Drawing.Point(16, 18), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            this.txtBuscarProducto = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(74, 15), Width = 300, Font = new System.Drawing.Font("Segoe UI", 9.5F), PlaceholderText = "Filtrar por código o nombre..." };
            this.txtBuscarProducto.TextChanged += (s, e) => FiltrarInventario();

            var lblCat = new System.Windows.Forms.Label { Text = "Categoría:", Location = new System.Drawing.Point(395, 18), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };
            this.cmbFiltroCategoria = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(470, 15), Width = 180, Font = new System.Drawing.Font("Segoe UI", 9.5F), DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.cmbFiltroCategoria.Items.AddRange(new object[] { "Todas", "Tecnología", "Accesorios", "Cables", "Componentes", "General" });
            this.cmbFiltroCategoria.SelectedIndex = 0;
            this.cmbFiltroCategoria.SelectedIndexChanged += (s, e) => FiltrarInventario();

            cardFiltros.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblBuscar, this.txtBuscarProducto, lblCat, this.cmbFiltroCategoria
            });

            var splitInventario = new System.Windows.Forms.SplitContainer();
            splitInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            splitInventario.SplitterDistance = 680;
            splitInventario.BackColor = System.Drawing.Color.Transparent;
            splitInventario.Panel1.Padding = new System.Windows.Forms.Padding(0, 8, 6, 0);
            splitInventario.Panel2.Padding = new System.Windows.Forms.Padding(6, 8, 0, 0);

            var cardTabla = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(16) };
            this.dgvProductos = CrearDataGridViewEstilizado();
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.SelectionChanged += DgvProductos_SelectionChanged;

            cardTabla.Controls.Add(this.dgvProductos);
            splitInventario.Panel1.Controls.Add(cardTabla);

            var cardForm = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(18), AutoScroll = true };

            var lblTituloForm = new System.Windows.Forms.Label();
            lblTituloForm.Text = "Ficha del Producto";
            lblTituloForm.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            lblTituloForm.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTituloForm.Location = new System.Drawing.Point(18, 14);
            lblTituloForm.Size = new System.Drawing.Size(260, 26);

            int yPos = 48;
            CrearCampoFormulario(cardForm, "Código de Producto:", out this.txtCodigo, ref yPos);
            CrearCampoFormulario(cardForm, "Nombre / Descripción:", out this.txtNombre, ref yPos);

            var lblCatForm = new System.Windows.Forms.Label { Text = "Categoría:", Location = new System.Drawing.Point(18, yPos), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Bold) };
            this.cmbCategoria = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(18, yPos + 20), Width = 280, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Font = new System.Drawing.Font("Segoe UI", 9.5F) };
            this.cmbCategoria.Items.AddRange(new object[] { "Tecnología", "Accesorios", "Cables", "Componentes", "General" });
            this.cmbCategoria.SelectedIndex = 0;
            cardForm.Controls.AddRange(new System.Windows.Forms.Control[] { lblCatForm, this.cmbCategoria });
            yPos += 56;

            CrearCampoNumerico(cardForm, "Precio de Compra ($):", out this.numPrecioCompra, ref yPos, 2, 99999);
            CrearCampoNumerico(cardForm, "Precio de Venta ($):", out this.numPrecioVenta, ref yPos, 2, 99999);
            CrearCampoNumerico(cardForm, "Stock Actual:", out this.numStock, ref yPos, 0, 99999);
            CrearCampoNumerico(cardForm, "Stock Mínimo de Alerta:", out this.numStockMinimo, ref yPos, 0, 99999);
            this.numStockMinimo.Value = 5;

            this.btnGuardarProducto = new BotonModerno
            {
                Text = "Guardar Producto",
                ColorNormal = System.Drawing.Color.FromArgb(99, 102, 241),
                Location = new System.Drawing.Point(18, yPos),
                Size = new System.Drawing.Size(280, 40)
            };
            this.btnGuardarProducto.Click += BtnGuardarProducto_Click;

            this.btnLimpiarCampos = new BotonModerno
            {
                Text = "Limpiar",
                ColorNormal = System.Drawing.Color.FromArgb(100, 116, 139),
                Location = new System.Drawing.Point(18, yPos + 48),
                Size = new System.Drawing.Size(135, 36)
            };
            this.btnLimpiarCampos.Click += (s, e) => LimpiarFormularioProducto();

            this.btnEliminarProducto = new BotonModerno
            {
                Text = "Eliminar",
                ColorNormal = System.Drawing.Color.FromArgb(239, 68, 68),
                Location = new System.Drawing.Point(163, yPos + 48),
                Size = new System.Drawing.Size(135, 36)
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
        // 3. PANTALLA VENTAS (POS)
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
            splitVentas.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            splitVentas.Panel2.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);

            var cardCarrito = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(18) };

            var lblTituloVentas = new System.Windows.Forms.Label();
            lblTituloVentas.Text = "Carrito de Compras / Facturación Activa";
            lblTituloVentas.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            lblTituloVentas.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTituloVentas.Location = new System.Drawing.Point(18, 14);
            lblTituloVentas.Size = new System.Drawing.Size(380, 24);

            var lblProdVenta = new System.Windows.Forms.Label { Text = "Seleccionar Producto:", Location = new System.Drawing.Point(18, 48), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Bold) };
            this.cmbVentaProducto = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(18, 70), Width = 390, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Font = new System.Drawing.Font("Segoe UI", 9.5F) };
            this.cmbVentaProducto.SelectedIndexChanged += CmbVentaProducto_SelectedIndexChanged;

            this.lblVentaPrecioUnitario = new System.Windows.Forms.Label { Text = "Precio: $0.00", Location = new System.Drawing.Point(18, 102), AutoSize = true, ForeColor = System.Drawing.Color.FromArgb(99, 102, 241), Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold) };
            this.lblVentaStockDisponible = new System.Windows.Forms.Label { Text = "Stock disponible: 0", Location = new System.Drawing.Point(190, 102), AutoSize = true, ForeColor = System.Drawing.Color.FromArgb(100, 116, 139), Font = new System.Drawing.Font("Segoe UI", 9F) };

            var lblCant = new System.Windows.Forms.Label { Text = "Cantidad:", Location = new System.Drawing.Point(425, 48), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Bold) };
            this.numVentaCantidad = new System.Windows.Forms.NumericUpDown { Location = new System.Drawing.Point(425, 70), Width = 80, Minimum = 1, Maximum = 9999, Value = 1, Font = new System.Drawing.Font("Segoe UI", 9.5F) };

            this.btnAgregarAlCarrito = new BotonModerno
            {
                Text = "Agregar",
                ColorNormal = System.Drawing.Color.FromArgb(99, 102, 241),
                Location = new System.Drawing.Point(520, 67),
                Size = new System.Drawing.Size(120, 34)
            };
            this.btnAgregarAlCarrito.Click += BtnAgregarAlCarrito_Click;

            this.dgvCarrito = CrearDataGridViewEstilizado();
            this.dgvCarrito.Location = new System.Drawing.Point(18, 135);
            this.dgvCarrito.Size = new System.Drawing.Size(650, 420);
            this.dgvCarrito.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);

            this.btnQuitarDelCarrito = new BotonModerno
            {
                Text = "Quitar Ítem",
                ColorNormal = System.Drawing.Color.FromArgb(239, 68, 68),
                Location = new System.Drawing.Point(18, 570),
                Size = new System.Drawing.Size(140, 36),
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

            var cardCobro = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(22) };

            var lblCobroTitulo = new System.Windows.Forms.Label();
            lblCobroTitulo.Text = "Resumen de Pago";
            lblCobroTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblCobroTitulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblCobroTitulo.Location = new System.Drawing.Point(18, 18);
            lblCobroTitulo.Size = new System.Drawing.Size(260, 26);

            int yCobro = 56;
            CrearCampoFormulario(cardCobro, "Nombre del Cliente:", out this.txtVentaCliente, ref yCobro);
            this.txtVentaCliente.Text = "Consumidor Final";

            var lblMetodo = new System.Windows.Forms.Label { Text = "Método de Pago:", Location = new System.Drawing.Point(18, yCobro), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Bold) };
            this.cmbVentaMetodoPago = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(18, yCobro + 20), Width = 280, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Font = new System.Drawing.Font("Segoe UI", 9.5F) };
            this.cmbVentaMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta Débito / Crédito", "Transferencia Digital (Nequi/Daviplata)" });
            this.cmbVentaMetodoPago.SelectedIndex = 0;
            cardCobro.Controls.AddRange(new System.Windows.Forms.Control[] { lblMetodo, this.cmbVentaMetodoPago });
            yCobro += 64;

            var panelTotalCard = new TarjetaModerna
            {
                Location = new System.Drawing.Point(18, yCobro),
                Size = new System.Drawing.Size(280, 110),
                ColorBorde = System.Drawing.Color.FromArgb(203, 213, 225),
                Padding = new System.Windows.Forms.Padding(14)
            };

            var lblSubEtiqueta = new System.Windows.Forms.Label { Text = "Subtotal Acumulado:", Location = new System.Drawing.Point(12, 12), AutoSize = true, ForeColor = System.Drawing.Color.FromArgb(100, 116, 139) };
            this.lblVentaSubtotal = new System.Windows.Forms.Label { Text = "$0.00", Location = new System.Drawing.Point(140, 12), Size = new System.Drawing.Size(120, 18), TextAlign = System.Drawing.ContentAlignment.MiddleRight, Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold) };

            var lblTotalEtiqueta = new System.Windows.Forms.Label { Text = "TOTAL FINAL A COBRAR", Location = new System.Drawing.Point(12, 42), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 8.2F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(30, 41, 59) };
            this.lblVentaTotal = new System.Windows.Forms.Label { Text = "$0.00", Location = new System.Drawing.Point(12, 62), Size = new System.Drawing.Size(250, 36), Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(16, 185, 129) };

            panelTotalCard.Controls.AddRange(new System.Windows.Forms.Control[] { lblSubEtiqueta, this.lblVentaSubtotal, lblTotalEtiqueta, this.lblVentaTotal });
            cardCobro.Controls.Add(panelTotalCard);
            yCobro += 130;

            this.btnCompletarVenta = new BotonModerno
            {
                Text = "REGISTRAR Y COBRAR",
                ColorNormal = System.Drawing.Color.FromArgb(16, 185, 129),
                Location = new System.Drawing.Point(18, yCobro),
                Size = new System.Drawing.Size(280, 46),
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold)
            };
            this.btnCompletarVenta.Click += BtnCompletarVenta_Click;

            this.btnCancelarVenta = new BotonModerno
            {
                Text = "Vaciar Carrito",
                ColorNormal = System.Drawing.Color.FromArgb(100, 116, 139),
                Location = new System.Drawing.Point(18, yCobro + 56),
                Size = new System.Drawing.Size(280, 36)
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
        // 4. PANTALLA HISTORIAL
        // =========================================================================
        private void InicializarPantallaHistorial()
        {
            this.panelHistorial = new System.Windows.Forms.Panel();
            this.panelHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHistorial.BackColor = System.Drawing.Color.Transparent;

            var cardHistorial = new TarjetaModerna { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(18) };

            var lblTituloHistorial = new System.Windows.Forms.Label();
            lblTituloHistorial.Text = "Registro Histórico de Ventas y Comprobantes";
            lblTituloHistorial.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            lblTituloHistorial.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTituloHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            lblTituloHistorial.Height = 34;

            this.dgvHistorialVentas = CrearDataGridViewEstilizado();
            this.dgvHistorialVentas.Dock = System.Windows.Forms.DockStyle.Fill;

            cardHistorial.Controls.Add(this.dgvHistorialVentas);
            cardHistorial.Controls.Add(lblTituloHistorial);
            this.panelHistorial.Controls.Add(cardHistorial);
            this.panelContenedor.Controls.Add(this.panelHistorial);
        }

        // =========================================================================
        // MÉTODOS AUXILIARES
        // =========================================================================

        /// <summary>
        /// Crea y estiliza un DataGridView eliminando el error visual de encabezados azules.
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

            // Encabezado Slate 900 consistente (sin selección azul no deseada)
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(15, 23, 42); // Evita el glitch de header azul
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;

            // Selección de filas en tinte muy suave
            dgv.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(238, 242, 255);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgv.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);

            return dgv;
        }

        private void CrearCampoFormulario(System.Windows.Forms.Panel parent, string label, out System.Windows.Forms.TextBox txt, ref int yPos)
        {
            var lbl = new System.Windows.Forms.Label { Text = label, Location = new System.Drawing.Point(18, yPos), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(30, 41, 59) };
            txt = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(18, yPos + 20), Width = 280, Font = new System.Drawing.Font("Segoe UI", 9.5F) };
            parent.Controls.Add(lbl);
            parent.Controls.Add(txt);
            yPos += 56;
        }

        private void CrearCampoNumerico(System.Windows.Forms.Panel parent, string label, out System.Windows.Forms.NumericUpDown num, ref int yPos, int decimales, decimal max)
        {
            var lbl = new System.Windows.Forms.Label { Text = label, Location = new System.Drawing.Point(18, yPos), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(30, 41, 59) };
            num = new System.Windows.Forms.NumericUpDown { Location = new System.Drawing.Point(18, yPos + 20), Width = 280, DecimalPlaces = decimales, Maximum = max, Font = new System.Drawing.Font("Segoe UI", 9.5F) };
            parent.Controls.Add(lbl);
            parent.Controls.Add(num);
            yPos += 56;
        }
    }
}
