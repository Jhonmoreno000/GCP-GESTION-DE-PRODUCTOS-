namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlNavIndicator = new System.Windows.Forms.Panel();
            this.btnNavHistorial = new System.Windows.Forms.Button();
            this.btnNavVentas = new System.Windows.Forms.Button();
            this.btnNavProductos = new System.Windows.Forms.Button();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.pnlBrand = new System.Windows.Forms.Panel();
            this.lblBrandBadge = new System.Windows.Forms.Label();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.lblBrandTitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.lblSectionTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            
            // Dashboard dentro de Form1
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.pnlChartContainer = new System.Windows.Forms.Panel();
            this.tblCharts = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChartBarras = new System.Windows.Forms.Panel();
            this.lblChartBarrasSub = new System.Windows.Forms.Label();
            this.lblChartBarrasTitulo = new System.Windows.Forms.Label();
            this.pnlChartDonut = new System.Windows.Forms.Panel();
            this.lblChartDonutSub = new System.Windows.Forms.Label();
            this.lblChartDonutTitulo = new System.Windows.Forms.Label();
            this.tblMetrics = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCardAlertas = new System.Windows.Forms.Panel();
            this.lblCardAlertasVal = new System.Windows.Forms.Label();
            this.lblCardAlertasTit = new System.Windows.Forms.Label();
            this.pnlCardStockTotal = new System.Windows.Forms.Panel();
            this.lblCardStockVal = new System.Windows.Forms.Label();
            this.lblCardStockTit = new System.Windows.Forms.Label();
            this.pnlCardVentas = new System.Windows.Forms.Panel();
            this.lblCardVentasVal = new System.Windows.Forms.Label();
            this.lblCardVentasTit = new System.Windows.Forms.Label();
            this.pnlCardIngresos = new System.Windows.Forms.Panel();
            this.lblCardIngresosVal = new System.Windows.Forms.Label();
            this.lblCardIngresosTit = new System.Windows.Forms.Label();

            this.tmrChartAnimacion = new System.Windows.Forms.Timer(this.components);

            this.pnlSidebar.SuspendLayout();
            this.pnlBrand.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.pnlChartContainer.SuspendLayout();
            this.tblCharts.SuspendLayout();
            this.pnlChartBarras.SuspendLayout();
            this.pnlChartDonut.SuspendLayout();
            this.tblMetrics.SuspendLayout();
            this.pnlCardAlertas.SuspendLayout();
            this.pnlCardStockTotal.SuspendLayout();
            this.pnlCardVentas.SuspendLayout();
            this.pnlCardIngresos.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlSidebar (Barra Lateral de Navegación Moderna)
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlSidebar.Controls.Add(this.pnlNavIndicator);
            this.pnlSidebar.Controls.Add(this.btnNavHistorial);
            this.pnlSidebar.Controls.Add(this.btnNavVentas);
            this.pnlSidebar.Controls.Add(this.btnNavProductos);
            this.pnlSidebar.Controls.Add(this.btnNavDashboard);
            this.pnlSidebar.Controls.Add(this.pnlBrand);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 720);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlBrand (Cabecera GCP)
            // 
            this.pnlBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlBrand.Controls.Add(this.lblBrandBadge);
            this.pnlBrand.Controls.Add(this.lblBrandSub);
            this.pnlBrand.Controls.Add(this.lblBrandTitle);
            this.pnlBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrand.Location = new System.Drawing.Point(0, 0);
            this.pnlBrand.Name = "pnlBrand";
            this.pnlBrand.Padding = new System.Windows.Forms.Padding(20, 20, 20, 16);
            this.pnlBrand.Size = new System.Drawing.Size(250, 95);
            this.pnlBrand.TabIndex = 0;
            // 
            // lblBrandTitle
            // 
            this.lblBrandTitle.AutoSize = true;
            this.lblBrandTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBrandTitle.ForeColor = System.Drawing.Color.White;
            this.lblBrandTitle.Location = new System.Drawing.Point(18, 14);
            this.lblBrandTitle.Name = "lblBrandTitle";
            this.lblBrandTitle.Size = new System.Drawing.Size(120, 37);
            this.lblBrandTitle.TabIndex = 0;
            this.lblBrandTitle.Text = "⚡ GCP";
            // 
            // lblBrandBadge
            // 
            this.lblBrandBadge.AutoSize = true;
            this.lblBrandBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.lblBrandBadge.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblBrandBadge.ForeColor = System.Drawing.Color.White;
            this.lblBrandBadge.Location = new System.Drawing.Point(145, 23);
            this.lblBrandBadge.Name = "lblBrandBadge";
            this.lblBrandBadge.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblBrandBadge.Size = new System.Drawing.Size(43, 17);
            this.lblBrandBadge.TabIndex = 1;
            this.lblBrandBadge.Text = "PRO";
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.AutoSize = true;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblBrandSub.Location = new System.Drawing.Point(22, 58);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(163, 13);
            this.lblBrandSub.TabIndex = 2;
            this.lblBrandSub.Text = "Control Integral de Inventario";
            // 
            // pnlNavIndicator
            // 
            this.pnlNavIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.pnlNavIndicator.Location = new System.Drawing.Point(0, 95);
            this.pnlNavIndicator.Name = "pnlNavIndicator";
            this.pnlNavIndicator.Size = new System.Drawing.Size(5, 54);
            this.pnlNavIndicator.TabIndex = 1;
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavDashboard.FlatAppearance.BorderSize = 0;
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.Location = new System.Drawing.Point(0, 95);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnNavDashboard.Size = new System.Drawing.Size(250, 54);
            this.btnNavDashboard.TabIndex = 1;
            this.btnNavDashboard.Text = "📊  Dashboard";
            this.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.UseVisualStyleBackColor = true;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNav_Click);
            this.btnNavDashboard.MouseEnter += new System.EventHandler(this.btnNav_MouseEnter);
            this.btnNavDashboard.MouseLeave += new System.EventHandler(this.btnNav_MouseLeave);
            // 
            // btnNavProductos
            // 
            this.btnNavProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavProductos.FlatAppearance.BorderSize = 0;
            this.btnNavProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavProductos.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNavProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavProductos.Location = new System.Drawing.Point(0, 149);
            this.btnNavProductos.Name = "btnNavProductos";
            this.btnNavProductos.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnNavProductos.Size = new System.Drawing.Size(250, 54);
            this.btnNavProductos.TabIndex = 2;
            this.btnNavProductos.Text = "📦  Catálogo GCP";
            this.btnNavProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavProductos.UseVisualStyleBackColor = true;
            this.btnNavProductos.Click += new System.EventHandler(this.btnNav_Click);
            this.btnNavProductos.MouseEnter += new System.EventHandler(this.btnNav_MouseEnter);
            this.btnNavProductos.MouseLeave += new System.EventHandler(this.btnNav_MouseLeave);
            // 
            // btnNavVentas
            // 
            this.btnNavVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavVentas.FlatAppearance.BorderSize = 0;
            this.btnNavVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavVentas.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNavVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavVentas.Location = new System.Drawing.Point(0, 203);
            this.btnNavVentas.Name = "btnNavVentas";
            this.btnNavVentas.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnNavVentas.Size = new System.Drawing.Size(250, 54);
            this.btnNavVentas.TabIndex = 3;
            this.btnNavVentas.Text = "⚡  Punto de Venta";
            this.btnNavVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavVentas.UseVisualStyleBackColor = true;
            this.btnNavVentas.Click += new System.EventHandler(this.btnNav_Click);
            this.btnNavVentas.MouseEnter += new System.EventHandler(this.btnNav_MouseEnter);
            this.btnNavVentas.MouseLeave += new System.EventHandler(this.btnNav_MouseLeave);
            // 
            // btnNavHistorial
            // 
            this.btnNavHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavHistorial.FlatAppearance.BorderSize = 0;
            this.btnNavHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavHistorial.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNavHistorial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavHistorial.Location = new System.Drawing.Point(0, 257);
            this.btnNavHistorial.Name = "btnNavHistorial";
            this.btnNavHistorial.Padding = new System.Windows.Forms.Padding(26, 0, 0, 0);
            this.btnNavHistorial.Size = new System.Drawing.Size(250, 54);
            this.btnNavHistorial.TabIndex = 4;
            this.btnNavHistorial.Text = "🧾  Historial Ventas";
            this.btnNavHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavHistorial.UseVisualStyleBackColor = true;
            this.btnNavHistorial.Click += new System.EventHandler(this.btnNav_Click);
            this.btnNavHistorial.MouseEnter += new System.EventHandler(this.btnNav_MouseEnter);
            this.btnNavHistorial.MouseLeave += new System.EventHandler(this.btnNav_MouseLeave);

            // 
            // pnlHeader (Cabecera Superior Moderna)
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblSystemStatus);
            this.pnlHeader.Controls.Add(this.lblSectionTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(250, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(930, 70);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblSectionTitle
            // 
            this.lblSectionTitle.AutoSize = true;
            this.lblSectionTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSectionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblSectionTitle.Location = new System.Drawing.Point(24, 20);
            this.lblSectionTitle.Name = "lblSectionTitle";
            this.lblSectionTitle.Size = new System.Drawing.Size(211, 30);
            this.lblSectionTitle.TabIndex = 0;
            this.lblSectionTitle.Text = "Dashboard General";
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystemStatus.AutoSize = true;
            this.lblSystemStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(253)))), ((int)(((byte)(245)))));
            this.lblSystemStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSystemStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.lblSystemStatus.Location = new System.Drawing.Point(705, 24);
            this.lblSystemStatus.Name = "lblSystemStatus";
            this.lblSystemStatus.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.lblSystemStatus.Size = new System.Drawing.Size(201, 25);
            this.lblSystemStatus.TabIndex = 1;
            this.lblSystemStatus.Text = "🟢 SISTEMA GCP EN LÍNEA";

            // 
            // pnlMain (Área de Trabajo Central)
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlMain.Controls.Add(this.pnlDashboard);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(250, 70);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(930, 650);
            this.pnlMain.TabIndex = 2;

            // 
            // ==================== DASHBOARD INTEGRADO CON 2 GRÁFICAS MODERNAS ====================
            // 
            this.pnlDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlDashboard.Controls.Add(this.pnlChartContainer);
            this.pnlDashboard.Controls.Add(this.tblMetrics);
            this.pnlDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Padding = new System.Windows.Forms.Padding(24);
            this.pnlDashboard.Size = new System.Drawing.Size(930, 650);
            this.pnlDashboard.TabIndex = 0;

            // 
            // tblMetrics (Tarjetas Métricas Editables)
            // 
            this.tblMetrics.ColumnCount = 4;
            this.tblMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMetrics.Controls.Add(this.pnlCardAlertas, 3, 0);
            this.tblMetrics.Controls.Add(this.pnlCardStockTotal, 2, 0);
            this.tblMetrics.Controls.Add(this.pnlCardVentas, 1, 0);
            this.tblMetrics.Controls.Add(this.pnlCardIngresos, 0, 0);
            this.tblMetrics.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblMetrics.Location = new System.Drawing.Point(24, 24);
            this.tblMetrics.Name = "tblMetrics";
            this.tblMetrics.RowCount = 1;
            this.tblMetrics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMetrics.Size = new System.Drawing.Size(882, 115);
            this.tblMetrics.TabIndex = 0;
            // 
            // pnlCardIngresos (Tarjeta 1: Ingresos)
            // 
            this.pnlCardIngresos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.pnlCardIngresos.Controls.Add(this.lblCardIngresosVal);
            this.pnlCardIngresos.Controls.Add(this.lblCardIngresosTit);
            this.pnlCardIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardIngresos.Location = new System.Drawing.Point(0, 0);
            this.pnlCardIngresos.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.pnlCardIngresos.Name = "pnlCardIngresos";
            this.pnlCardIngresos.Padding = new System.Windows.Forms.Padding(18);
            this.pnlCardIngresos.Size = new System.Drawing.Size(210, 105);
            this.pnlCardIngresos.TabIndex = 0;
            // 
            // lblCardIngresosTit
            // 
            this.lblCardIngresosTit.AutoSize = true;
            this.lblCardIngresosTit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardIngresosTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.lblCardIngresosTit.Location = new System.Drawing.Point(14, 14);
            this.lblCardIngresosTit.Name = "lblCardIngresosTit";
            this.lblCardIngresosTit.Size = new System.Drawing.Size(117, 15);
            this.lblCardIngresosTit.TabIndex = 0;
            this.lblCardIngresosTit.Text = "💰 INGRESOS (HOY)";
            // 
            // lblCardIngresosVal
            // 
            this.lblCardIngresosVal.AutoSize = true;
            this.lblCardIngresosVal.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardIngresosVal.ForeColor = System.Drawing.Color.White;
            this.lblCardIngresosVal.Location = new System.Drawing.Point(12, 38);
            this.lblCardIngresosVal.Name = "lblCardIngresosVal";
            this.lblCardIngresosVal.Size = new System.Drawing.Size(95, 41);
            this.lblCardIngresosVal.TabIndex = 1;
            this.lblCardIngresosVal.Text = "$0.00";
            // 
            // pnlCardVentas (Tarjeta 2: Ventas)
            // 
            this.pnlCardVentas.BackColor = System.Drawing.Color.White;
            this.pnlCardVentas.Controls.Add(this.lblCardVentasVal);
            this.pnlCardVentas.Controls.Add(this.lblCardVentasTit);
            this.pnlCardVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardVentas.Location = new System.Drawing.Point(220, 0);
            this.pnlCardVentas.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.pnlCardVentas.Name = "pnlCardVentas";
            this.pnlCardVentas.Padding = new System.Windows.Forms.Padding(18);
            this.pnlCardVentas.Size = new System.Drawing.Size(210, 105);
            this.pnlCardVentas.TabIndex = 1;
            // 
            // lblCardVentasTit
            // 
            this.lblCardVentasTit.AutoSize = true;
            this.lblCardVentasTit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardVentasTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCardVentasTit.Location = new System.Drawing.Point(14, 14);
            this.lblCardVentasTit.Name = "lblCardVentasTit";
            this.lblCardVentasTit.Size = new System.Drawing.Size(150, 15);
            this.lblCardVentasTit.TabIndex = 0;
            this.lblCardVentasTit.Text = "🧾 VENTAS REALIZADAS";
            // 
            // lblCardVentasVal
            // 
            this.lblCardVentasVal.AutoSize = true;
            this.lblCardVentasVal.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardVentasVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCardVentasVal.Location = new System.Drawing.Point(12, 38);
            this.lblCardVentasVal.Name = "lblCardVentasVal";
            this.lblCardVentasVal.Size = new System.Drawing.Size(35, 41);
            this.lblCardVentasVal.TabIndex = 1;
            this.lblCardVentasVal.Text = "0";
            // 
            // pnlCardStockTotal (Tarjeta 3: Artículos)
            // 
            this.pnlCardStockTotal.BackColor = System.Drawing.Color.White;
            this.pnlCardStockTotal.Controls.Add(this.lblCardStockVal);
            this.pnlCardStockTotal.Controls.Add(this.lblCardStockTit);
            this.pnlCardStockTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardStockTotal.Location = new System.Drawing.Point(440, 0);
            this.pnlCardStockTotal.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.pnlCardStockTotal.Name = "pnlCardStockTotal";
            this.pnlCardStockTotal.Padding = new System.Windows.Forms.Padding(18);
            this.pnlCardStockTotal.Size = new System.Drawing.Size(210, 105);
            this.pnlCardStockTotal.TabIndex = 2;
            // 
            // lblCardStockTit
            // 
            this.lblCardStockTit.AutoSize = true;
            this.lblCardStockTit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardStockTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblCardStockTit.Location = new System.Drawing.Point(14, 14);
            this.lblCardStockTit.Name = "lblCardStockTit";
            this.lblCardStockTit.Size = new System.Drawing.Size(149, 15);
            this.lblCardStockTit.TabIndex = 0;
            this.lblCardStockTit.Text = "📦 ARTÍCULOS ACTIVOS";
            // 
            // lblCardStockVal
            // 
            this.lblCardStockVal.AutoSize = true;
            this.lblCardStockVal.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardStockVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCardStockVal.Location = new System.Drawing.Point(12, 38);
            this.lblCardStockVal.Name = "lblCardStockVal";
            this.lblCardStockVal.Size = new System.Drawing.Size(35, 41);
            this.lblCardStockVal.TabIndex = 1;
            this.lblCardStockVal.Text = "0";
            // 
            // pnlCardAlertas (Tarjeta 4: Alertas)
            // 
            this.pnlCardAlertas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.pnlCardAlertas.Controls.Add(this.lblCardAlertasVal);
            this.pnlCardAlertas.Controls.Add(this.lblCardAlertasTit);
            this.pnlCardAlertas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardAlertas.Location = new System.Drawing.Point(660, 0);
            this.pnlCardAlertas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlCardAlertas.Name = "pnlCardAlertas";
            this.pnlCardAlertas.Padding = new System.Windows.Forms.Padding(18);
            this.pnlCardAlertas.Size = new System.Drawing.Size(222, 105);
            this.pnlCardAlertas.TabIndex = 3;
            // 
            // lblCardAlertasTit
            // 
            this.lblCardAlertasTit.AutoSize = true;
            this.lblCardAlertasTit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCardAlertasTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblCardAlertasTit.Location = new System.Drawing.Point(14, 14);
            this.lblCardAlertasTit.Name = "lblCardAlertasTit";
            this.lblCardAlertasTit.Size = new System.Drawing.Size(149, 15);
            this.lblCardAlertasTit.TabIndex = 0;
            this.lblCardAlertasTit.Text = "⚠️ STOCK CRÍTICO (≤5)";
            // 
            // lblCardAlertasVal
            // 
            this.lblCardAlertasVal.AutoSize = true;
            this.lblCardAlertasVal.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblCardAlertasVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblCardAlertasVal.Location = new System.Drawing.Point(12, 38);
            this.lblCardAlertasVal.Name = "lblCardAlertasVal";
            this.lblCardAlertasVal.Size = new System.Drawing.Size(35, 41);
            this.lblCardAlertasVal.TabIndex = 1;
            this.lblCardAlertasVal.Text = "0";
            // 
            // pnlChartContainer (Contenedor de Ambas Gráficas)
            // 
            this.pnlChartContainer.Controls.Add(this.tblCharts);
            this.pnlChartContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartContainer.Location = new System.Drawing.Point(24, 139);
            this.pnlChartContainer.Name = "pnlChartContainer";
            this.pnlChartContainer.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.pnlChartContainer.Size = new System.Drawing.Size(882, 487);
            this.pnlChartContainer.TabIndex = 1;
            // 
            // tblCharts (Distribución Responsiva: 62% Barras | 38% Donut)
            // 
            this.tblCharts.ColumnCount = 2;
            this.tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63F));
            this.tblCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.tblCharts.Controls.Add(this.pnlChartBarras, 0, 0);
            this.tblCharts.Controls.Add(this.pnlChartDonut, 1, 0);
            this.tblCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCharts.Location = new System.Drawing.Point(0, 14);
            this.tblCharts.Name = "tblCharts";
            this.tblCharts.RowCount = 1;
            this.tblCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCharts.Size = new System.Drawing.Size(882, 473);
            this.tblCharts.TabIndex = 0;
            // 
            // pnlChartBarras (Gráfica 1: Barras Verticales con Guías y Umbrales)
            // 
            this.pnlChartBarras.BackColor = System.Drawing.Color.White;
            this.pnlChartBarras.Controls.Add(this.lblChartBarrasSub);
            this.pnlChartBarras.Controls.Add(this.lblChartBarrasTitulo);
            this.pnlChartBarras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartBarras.Location = new System.Drawing.Point(0, 0);
            this.pnlChartBarras.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlChartBarras.Name = "pnlChartBarras";
            this.pnlChartBarras.Padding = new System.Windows.Forms.Padding(20);
            this.pnlChartBarras.Size = new System.Drawing.Size(541, 473);
            this.pnlChartBarras.TabIndex = 0;
            this.pnlChartBarras.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChartBarras_Paint);
            // 
            // lblChartBarrasSub
            // 
            this.lblChartBarrasSub.AutoSize = true;
            this.lblChartBarrasSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblChartBarrasSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblChartBarrasSub.Location = new System.Drawing.Point(18, 40);
            this.lblChartBarrasSub.Name = "lblChartBarrasSub";
            this.lblChartBarrasSub.Size = new System.Drawing.Size(325, 15);
            this.lblChartBarrasSub.TabIndex = 1;
            this.lblChartBarrasSub.Text = "Nivel de existencias en almacén frente a línea de alerta (5 u.)";
            // 
            // lblChartBarrasTitulo
            // 
            this.lblChartBarrasTitulo.AutoSize = true;
            this.lblChartBarrasTitulo.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblChartBarrasTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChartBarrasTitulo.Location = new System.Drawing.Point(16, 16);
            this.lblChartBarrasTitulo.Name = "lblChartBarrasTitulo";
            this.lblChartBarrasTitulo.Size = new System.Drawing.Size(306, 23);
            this.lblChartBarrasTitulo.TabIndex = 0;
            this.lblChartBarrasTitulo.Text = "📊 Nivel de Stock por Producto (Top)";
            // 
            // pnlChartDonut (Gráfica 2: Donut Circular de Salud del Inventario)
            // 
            this.pnlChartDonut.BackColor = System.Drawing.Color.White;
            this.pnlChartDonut.Controls.Add(this.lblChartDonutSub);
            this.pnlChartDonut.Controls.Add(this.lblChartDonutTitulo);
            this.pnlChartDonut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartDonut.Location = new System.Drawing.Point(555, 0);
            this.pnlChartDonut.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChartDonut.Name = "pnlChartDonut";
            this.pnlChartDonut.Padding = new System.Windows.Forms.Padding(20);
            this.pnlChartDonut.Size = new System.Drawing.Size(327, 473);
            this.pnlChartDonut.TabIndex = 1;
            this.pnlChartDonut.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChartDonut_Paint);
            // 
            // lblChartDonutSub
            // 
            this.lblChartDonutSub.AutoSize = true;
            this.lblChartDonutSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblChartDonutSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblChartDonutSub.Location = new System.Drawing.Point(18, 40);
            this.lblChartDonutSub.Name = "lblChartDonutSub";
            this.lblChartDonutSub.Size = new System.Drawing.Size(206, 15);
            this.lblChartDonutSub.TabIndex = 1;
            this.lblChartDonutSub.Text = "Proporción de artículos según estado";
            // 
            // lblChartDonutTitulo
            // 
            this.lblChartDonutTitulo.AutoSize = true;
            this.lblChartDonutTitulo.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblChartDonutTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblChartDonutTitulo.Location = new System.Drawing.Point(16, 16);
            this.lblChartDonutTitulo.Name = "lblChartDonutTitulo";
            this.lblChartDonutTitulo.Size = new System.Drawing.Size(232, 23);
            this.lblChartDonutTitulo.TabIndex = 0;
            this.lblChartDonutTitulo.Text = "🍩 Salud del Catálogo GCP";
            // 
            // tmrChartAnimacion
            // 
            this.tmrChartAnimacion.Interval = 16;
            this.tmrChartAnimacion.Tick += new System.EventHandler(this.tmrChartAnimacion_Tick);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.MinimumSize = new System.Drawing.Size(1050, 660);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GCP - Gestión y Control de Productos";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlBrand.ResumeLayout(false);
            this.pnlBrand.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.pnlChartContainer.ResumeLayout(false);
            this.tblCharts.ResumeLayout(false);
            this.pnlChartBarras.ResumeLayout(false);
            this.pnlChartBarras.PerformLayout();
            this.pnlChartDonut.ResumeLayout(false);
            this.pnlChartDonut.PerformLayout();
            this.tblMetrics.ResumeLayout(false);
            this.pnlCardAlertas.ResumeLayout(false);
            this.pnlCardAlertas.PerformLayout();
            this.pnlCardStockTotal.ResumeLayout(false);
            this.pnlCardStockTotal.PerformLayout();
            this.pnlCardVentas.ResumeLayout(false);
            this.pnlCardVentas.PerformLayout();
            this.pnlCardIngresos.ResumeLayout(false);
            this.pnlCardIngresos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.Panel pnlSidebar;
        public System.Windows.Forms.Panel pnlBrand;
        public System.Windows.Forms.Label lblBrandTitle;
        public System.Windows.Forms.Label lblBrandSub;
        public System.Windows.Forms.Label lblBrandBadge;
        public System.Windows.Forms.Panel pnlNavIndicator;
        public System.Windows.Forms.Button btnNavDashboard;
        public System.Windows.Forms.Button btnNavProductos;
        public System.Windows.Forms.Button btnNavVentas;
        public System.Windows.Forms.Button btnNavHistorial;
        public System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblSectionTitle;
        public System.Windows.Forms.Label lblSystemStatus;
        public System.Windows.Forms.Panel pnlMain;

        // Dashboard integrado directamente en Form1
        public System.Windows.Forms.Panel pnlDashboard;
        public System.Windows.Forms.TableLayoutPanel tblMetrics;
        public System.Windows.Forms.Panel pnlCardIngresos;
        public System.Windows.Forms.Label lblCardIngresosTit;
        public System.Windows.Forms.Label lblCardIngresosVal;
        public System.Windows.Forms.Panel pnlCardVentas;
        public System.Windows.Forms.Label lblCardVentasTit;
        public System.Windows.Forms.Label lblCardVentasVal;
        public System.Windows.Forms.Panel pnlCardStockTotal;
        public System.Windows.Forms.Label lblCardStockTit;
        public System.Windows.Forms.Label lblCardStockVal;
        public System.Windows.Forms.Panel pnlCardAlertas;
        public System.Windows.Forms.Label lblCardAlertasTit;
        public System.Windows.Forms.Label lblCardAlertasVal;
        public System.Windows.Forms.Panel pnlChartContainer;
        public System.Windows.Forms.TableLayoutPanel tblCharts;
        public System.Windows.Forms.Panel pnlChartBarras;
        public System.Windows.Forms.Label lblChartBarrasTitulo;
        public System.Windows.Forms.Label lblChartBarrasSub;
        public System.Windows.Forms.Panel pnlChartDonut;
        public System.Windows.Forms.Label lblChartDonutTitulo;
        public System.Windows.Forms.Label lblChartDonutSub;
        private System.Windows.Forms.Timer tmrChartAnimacion;
    }
}
