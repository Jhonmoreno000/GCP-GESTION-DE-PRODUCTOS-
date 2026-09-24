namespace WinFormsApp1
{
    partial class GPC
    {
        /// <summary>
        /// Variable del diseñador requerida para la liberación de recursos.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpia los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método de inicialización visual de componentes con arquitectura responsiva y teoría de color.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 760);
            this.MinimumSize = new System.Drawing.Size(1060, 660);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GCP STUDIO • Sistema Inteligente de Gestión de Productos";
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // =========================================================================
            // 1. BARRA LATERAL (SIDEBAR PROFESIONAL CON BOTONES VECTORIALES)
            // =========================================================================
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pnlLogoBadge = new System.Windows.Forms.Panel();
            this.lblLogoBadgeText = new System.Windows.Forms.Label();
            this.lblLogoTitulo = new System.Windows.Forms.Label();
            this.lblLogoSubtitulo = new System.Windows.Forms.Label();

            this.btnNavDashboard = new WinFormsApp1.UI.BotonSidebar();
            this.btnNavInventario = new WinFormsApp1.UI.BotonSidebar();
            this.btnNavVentas = new WinFormsApp1.UI.BotonSidebar();
            this.btnNavHistorial = new WinFormsApp1.UI.BotonSidebar();
            this.lblVersion = new System.Windows.Forms.Label();

            // Fondo Midnight Slate 900
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Width = 230;
            this.panelSidebar.Padding = new System.Windows.Forms.Padding(0);

            // Panel de Marca / Logo superior
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Height = 100;
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(11, 17, 32);

            // Badge con las siglas GCP en Índigo Eléctrico
            this.pnlLogoBadge.Location = new System.Drawing.Point(16, 26);
            this.pnlLogoBadge.Size = new System.Drawing.Size(42, 42);
            this.pnlLogoBadge.BackColor = System.Drawing.Color.FromArgb(99, 102, 241);

            this.lblLogoBadgeText.Text = "GCP";
            this.lblLogoBadgeText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblLogoBadgeText.ForeColor = System.Drawing.Color.White;
            this.lblLogoBadgeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogoBadgeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlLogoBadge.Controls.Add(this.lblLogoBadgeText);

            this.lblLogoTitulo.Text = "GCP STUDIO";
            this.lblLogoTitulo.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblLogoTitulo.ForeColor = System.Drawing.Color.White;
            this.lblLogoTitulo.Location = new System.Drawing.Point(66, 26);
            this.lblLogoTitulo.Size = new System.Drawing.Size(155, 24);

            this.lblLogoSubtitulo.Text = "Gestión de Inventario";
            this.lblLogoSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLogoSubtitulo.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblLogoSubtitulo.Location = new System.Drawing.Point(68, 50);
            this.lblLogoSubtitulo.Size = new System.Drawing.Size(150, 18);

            this.panelLogo.Controls.Add(this.pnlLogoBadge);
            this.panelLogo.Controls.Add(this.lblLogoTitulo);
            this.panelLogo.Controls.Add(this.lblLogoSubtitulo);

            // Botones vectoriales de la barra lateral con iconos integrados
            this.btnNavDashboard.Text = "Dashboard";
            this.btnNavDashboard.Icono = "dashboard";
            this.btnNavDashboard.Top = 115;
            this.btnNavDashboard.Left = 8;
            this.btnNavDashboard.Width = 214;

            this.btnNavInventario.Text = "Inventario";
            this.btnNavInventario.Icono = "inventario";
            this.btnNavInventario.Top = 168;
            this.btnNavInventario.Left = 8;
            this.btnNavInventario.Width = 214;

            this.btnNavVentas.Text = "Punto de Venta";
            this.btnNavVentas.Icono = "ventas";
            this.btnNavVentas.Top = 221;
            this.btnNavVentas.Left = 8;
            this.btnNavVentas.Width = 214;

            this.btnNavHistorial.Text = "Historial Ventas";
            this.btnNavHistorial.Icono = "historial";
            this.btnNavHistorial.Top = 274;
            this.btnNavHistorial.Left = 8;
            this.btnNavHistorial.Width = 214;

            this.btnNavDashboard.Click += (s, e) => MostrarModulo("dashboard");
            this.btnNavInventario.Click += (s, e) => MostrarModulo("inventario");
            this.btnNavVentas.Click += (s, e) => MostrarModulo("ventas");
            this.btnNavHistorial.Click += (s, e) => MostrarModulo("historial");

            this.lblVersion.Text = "v2.0 • .NET 8 • WinForms";
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblVersion.Height = 35;
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.panelSidebar.Controls.Add(this.lblVersion);
            this.panelSidebar.Controls.Add(this.btnNavHistorial);
            this.panelSidebar.Controls.Add(this.btnNavVentas);
            this.panelSidebar.Controls.Add(this.btnNavInventario);
            this.panelSidebar.Controls.Add(this.btnNavDashboard);
            this.panelSidebar.Controls.Add(this.panelLogo);

            // =========================================================================
            // 2. ENCABEZADO SUPERIOR (HEADER LIMPIO)
            // =========================================================================
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTituloModulo = new System.Windows.Forms.Label();
            this.lblSubtituloModulo = new System.Windows.Forms.Label();
            this.lblReloj = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();

            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 70;
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);

            this.lblTituloModulo.Text = "Dashboard y Métricas en Tiempo Real";
            this.lblTituloModulo.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTituloModulo.Location = new System.Drawing.Point(22, 12);
            this.lblTituloModulo.AutoSize = true;

            this.lblSubtituloModulo.Text = "Gráficas interactivas, balance de stock y alertas críticas";
            this.lblSubtituloModulo.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.lblSubtituloModulo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtituloModulo.Location = new System.Drawing.Point(24, 39);
            this.lblSubtituloModulo.AutoSize = true;

            this.lblReloj.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblReloj.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblReloj.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblReloj.Location = new System.Drawing.Point(740, 15);
            this.lblReloj.Size = new System.Drawing.Size(235, 22);
            this.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblUsuario.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblUsuario.Text = "Anderson Moreno • Administrador";
            this.lblUsuario.Location = new System.Drawing.Point(740, 40);
            this.lblUsuario.Size = new System.Drawing.Size(235, 20);
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.panelHeader.Controls.Add(this.lblTituloModulo);
            this.panelHeader.Controls.Add(this.lblSubtituloModulo);
            this.panelHeader.Controls.Add(this.lblReloj);
            this.panelHeader.Controls.Add(this.lblUsuario);

            var lineaHeader = new System.Windows.Forms.Panel();
            lineaHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            lineaHeader.Height = 1;
            lineaHeader.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.panelHeader.Controls.Add(lineaHeader);

            this.timerReloj = new System.Windows.Forms.Timer(this.components);
            this.timerReloj.Interval = 1000;
            this.timerReloj.Tick += (s, e) => ActualizarReloj();
            this.timerReloj.Start();

            // =========================================================================
            // 3. CONTENEDOR PRINCIPAL
            // =========================================================================
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.panelContenedor.Padding = new System.Windows.Forms.Padding(18);

            InicializarPantallaDashboard();
            InicializarPantallaInventario();
            InicializarPantallaVentas();
            InicializarPantallaHistorial();

            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);

            this.ResumeLayout(false);
        }

        #endregion

        // DECLARACIÓN DE CONTROLES
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel pnlLogoBadge;
        private System.Windows.Forms.Label lblLogoBadgeText;
        private System.Windows.Forms.Label lblLogoTitulo;
        private System.Windows.Forms.Label lblLogoSubtitulo;

        private WinFormsApp1.UI.BotonSidebar btnNavDashboard;
        private WinFormsApp1.UI.BotonSidebar btnNavInventario;
        private WinFormsApp1.UI.BotonSidebar btnNavVentas;
        private WinFormsApp1.UI.BotonSidebar btnNavHistorial;
        private System.Windows.Forms.Label lblVersion;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTituloModulo;
        private System.Windows.Forms.Label lblSubtituloModulo;
        private System.Windows.Forms.Label lblReloj;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Timer timerReloj;

        private System.Windows.Forms.Panel panelContenedor;

        // Paneles de cada pantalla
        private System.Windows.Forms.Panel panelDashboard;
        private System.Windows.Forms.Panel panelInventario;
        private System.Windows.Forms.Panel panelVentas;
        private System.Windows.Forms.Panel panelHistorial;

        // Controles de Dashboard
        private WinFormsApp1.UI.TarjetaKpiModerna cardKpiProductos;
        private WinFormsApp1.UI.TarjetaKpiModerna cardKpiStockCritico;
        private WinFormsApp1.UI.TarjetaKpiModerna cardKpiVentas;
        private WinFormsApp1.UI.TarjetaKpiModerna cardKpiTransacciones;
        private System.Windows.Forms.TableLayoutPanel tlpKpis;
        private System.Windows.Forms.TableLayoutPanel tlpGraficas;
        private WinFormsApp1.UI.GraficaBarrasModerna graficaBarras;
        private WinFormsApp1.UI.GraficaDonaProgreso graficaDona;
        private System.Windows.Forms.DataGridView dgvDashboardStockBajo;

        // Controles de Inventario
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.ComboBox cmbFiltroCategoria;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.NumericUpDown numPrecioCompra;
        private System.Windows.Forms.NumericUpDown numPrecioVenta;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.NumericUpDown numStockMinimo;
        private WinFormsApp1.UI.BotonModerno btnGuardarProducto;
        private WinFormsApp1.UI.BotonModerno btnLimpiarCampos;
        private WinFormsApp1.UI.BotonModerno btnEliminarProducto;

        // Controles de Ventas
        private System.Windows.Forms.ComboBox cmbVentaProducto;
        private System.Windows.Forms.NumericUpDown numVentaCantidad;
        private System.Windows.Forms.Label lblVentaStockDisponible;
        private System.Windows.Forms.Label lblVentaPrecioUnitario;
        private WinFormsApp1.UI.BotonModerno btnAgregarAlCarrito;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private WinFormsApp1.UI.BotonModerno btnQuitarDelCarrito;
        private System.Windows.Forms.TextBox txtVentaCliente;
        private System.Windows.Forms.ComboBox cmbVentaMetodoPago;
        private System.Windows.Forms.Label lblVentaSubtotal;
        private System.Windows.Forms.Label lblVentaTotal;
        private WinFormsApp1.UI.BotonModerno btnCompletarVenta;
        private WinFormsApp1.UI.BotonModerno btnCancelarVenta;

        // Controles de Historial
        private System.Windows.Forms.DataGridView dgvHistorialVentas;
    }
}
