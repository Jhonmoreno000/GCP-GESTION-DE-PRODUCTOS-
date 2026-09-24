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
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// Método necesario para admitir el Diseñador. No se debe modificar
        /// el contenido de este método con el editor de código.
        /// Configura una interfaz gráfica moderna, con barra lateral y tarjetas.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Configuración del Formulario Principal
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GCP - Sistema de Gestión y Control de Productos";
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);

            // =========================================================================
            // 1. BARRA LATERAL (SIDEBAR DE NAVEGACIÓN MODERNA)
            // =========================================================================
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogoIcon = new System.Windows.Forms.Label();
            this.lblLogoTitulo = new System.Windows.Forms.Label();
            this.lblLogoSubtitulo = new System.Windows.Forms.Label();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavInventario = new System.Windows.Forms.Button();
            this.btnNavVentas = new System.Windows.Forms.Button();
            this.btnNavHistorial = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();

            // Estilos del Sidebar
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(30, 38, 56); // Azul pizarra oscuro
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Width = 240;
            this.panelSidebar.Padding = new System.Windows.Forms.Padding(0);

            // Panel de Marca / Logo superior en Sidebar
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Height = 100;
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(22, 28, 42);

            this.lblLogoIcon.Text = "📦";
            this.lblLogoIcon.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLogoIcon.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            this.lblLogoIcon.Location = new System.Drawing.Point(18, 22);
            this.lblLogoIcon.Size = new System.Drawing.Size(45, 50);

            this.lblLogoTitulo.Text = "GCP SYSTEM";
            this.lblLogoTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLogoTitulo.ForeColor = System.Drawing.Color.White;
            this.lblLogoTitulo.Location = new System.Drawing.Point(68, 26);
            this.lblLogoTitulo.Size = new System.Drawing.Size(160, 25);

            this.lblLogoSubtitulo.Text = "Gestión de Productos";
            this.lblLogoSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLogoSubtitulo.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblLogoSubtitulo.Location = new System.Drawing.Point(70, 51);
            this.lblLogoSubtitulo.Size = new System.Drawing.Size(155, 20);

            this.panelLogo.Controls.Add(this.lblLogoIcon);
            this.panelLogo.Controls.Add(this.lblLogoTitulo);
            this.panelLogo.Controls.Add(this.lblLogoSubtitulo);

            // Botones de navegación en la barra lateral
            EstilizarBotonSidebar(this.btnNavDashboard, "📊   Dashboard", 115);
            EstilizarBotonSidebar(this.btnNavInventario, "📦   Inventario", 170);
            EstilizarBotonSidebar(this.btnNavVentas, "🛒   Punto de Venta", 225);
            EstilizarBotonSidebar(this.btnNavHistorial, "📋   Historial Ventas", 280);

            this.btnNavDashboard.Click += (s, e) => MostrarModulo("dashboard");
            this.btnNavInventario.Click += (s, e) => MostrarModulo("inventario");
            this.btnNavVentas.Click += (s, e) => MostrarModulo("ventas");
            this.btnNavHistorial.Click += (s, e) => MostrarModulo("historial");

            this.lblVersion.Text = "v1.0.0 • .NET 8 / WinForms";
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
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
            // 2. ENCABEZADO SUPERIOR (HEADER BLANCO MODERNO)
            // =========================================================================
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTituloModulo = new System.Windows.Forms.Label();
            this.lblSubtituloModulo = new System.Windows.Forms.Label();
            this.lblReloj = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();

            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Height = 70;
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);

            this.lblTituloModulo.Text = "Panel de Control";
            this.lblTituloModulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTituloModulo.Location = new System.Drawing.Point(20, 12);
            this.lblTituloModulo.AutoSize = true;

            this.lblSubtituloModulo.Text = "Resumen general de métricas e inventario";
            this.lblSubtituloModulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSubtituloModulo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtituloModulo.Location = new System.Drawing.Point(22, 40);
            this.lblSubtituloModulo.AutoSize = true;

            this.lblReloj.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblReloj.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReloj.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblReloj.Location = new System.Drawing.Point(700, 15);
            this.lblReloj.Size = new System.Drawing.Size(220, 22);
            this.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.lblUsuario.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblUsuario.Text = "👤 Anderson Moreno (Admin)";
            this.lblUsuario.Location = new System.Drawing.Point(700, 40);
            this.lblUsuario.Size = new System.Drawing.Size(220, 20);
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            this.panelHeader.Controls.Add(this.lblTituloModulo);
            this.panelHeader.Controls.Add(this.lblSubtituloModulo);
            this.panelHeader.Controls.Add(this.lblReloj);
            this.panelHeader.Controls.Add(this.lblUsuario);

            // Reloj en tiempo real
            this.timerReloj = new System.Windows.Forms.Timer(this.components);
            this.timerReloj.Interval = 1000;
            this.timerReloj.Tick += (s, e) => ActualizarReloj();
            this.timerReloj.Start();

            // =========================================================================
            // 3. CONTENEDOR PRINCIPAL DE PANTALLAS
            // =========================================================================
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.panelContenedor.Padding = new System.Windows.Forms.Padding(20);

            // Inicializar las pantallas de cada módulo
            InicializarPantallaDashboard();
            InicializarPantallaInventario();
            InicializarPantallaVentas();
            InicializarPantallaHistorial();

            // Agregar controles principales al formulario
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelSidebar);

            this.ResumeLayout(false);
        }

        #endregion

        // Métodos auxiliares de diseño y estilo visual
        private void EstilizarBotonSidebar(System.Windows.Forms.Button btn, string texto, int top)
        {
            btn.Text = texto;
            btn.Top = top;
            btn.Left = 12;
            btn.Width = 216;
            btn.Height = 44;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = System.Drawing.Color.Transparent;
            btn.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        // =============================================================================
        // DECLARACIÓN DE CONTROLES
        // =============================================================================
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogoIcon;
        private System.Windows.Forms.Label lblLogoTitulo;
        private System.Windows.Forms.Label lblLogoSubtitulo;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavInventario;
        private System.Windows.Forms.Button btnNavVentas;
        private System.Windows.Forms.Button btnNavHistorial;
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
        private System.Windows.Forms.Label lblKpiTotalProductos;
        private System.Windows.Forms.Label lblKpiStockBajo;
        private System.Windows.Forms.Label lblKpiTotalVentas;
        private System.Windows.Forms.Label lblKpiNumVentas;
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
        private System.Windows.Forms.Button btnGuardarProducto;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.Button btnEliminarProducto;

        // Controles de Ventas
        private System.Windows.Forms.ComboBox cmbVentaProducto;
        private System.Windows.Forms.NumericUpDown numVentaCantidad;
        private System.Windows.Forms.Label lblVentaStockDisponible;
        private System.Windows.Forms.Label lblVentaPrecioUnitario;
        private System.Windows.Forms.Button btnAgregarAlCarrito;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Button btnQuitarDelCarrito;
        private System.Windows.Forms.TextBox txtVentaCliente;
        private System.Windows.Forms.ComboBox cmbVentaMetodoPago;
        private System.Windows.Forms.Label lblVentaSubtotal;
        private System.Windows.Forms.Label lblVentaTotal;
        private System.Windows.Forms.Button btnCompletarVenta;
        private System.Windows.Forms.Button btnCancelarVenta;

        // Controles de Historial
        private System.Windows.Forms.DataGridView dgvHistorialVentas;
    }
}
