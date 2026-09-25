namespace WinFormsApp1
{
    partial class FormDashboard
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
            this.pnlChartContainer = new System.Windows.Forms.Panel();
            this.tblCharts = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChartBarras = new System.Windows.Forms.Panel();
            this.lblChartBarrasTitulo = new System.Windows.Forms.Label();
            this.lblChartBarrasSub = new System.Windows.Forms.Label();
            this.pnlChartDonut = new System.Windows.Forms.Panel();
            this.lblChartDonutTitulo = new System.Windows.Forms.Label();
            this.lblChartDonutSub = new System.Windows.Forms.Label();
            this.tmrAnimacion = new System.Windows.Forms.Timer(this.components);

            this.tblMetrics.SuspendLayout();
            this.pnlCardAlertas.SuspendLayout();
            this.pnlCardStockTotal.SuspendLayout();
            this.pnlCardVentas.SuspendLayout();
            this.pnlCardIngresos.SuspendLayout();
            this.pnlChartContainer.SuspendLayout();
            this.tblCharts.SuspendLayout();
            this.pnlChartBarras.SuspendLayout();
            this.pnlChartDonut.SuspendLayout();
            this.SuspendLayout();

            // 
            // tblMetrics (Contenedor Responsivo para Tarjetas: 4 columnas al 25%)
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
            this.tblMetrics.Size = new System.Drawing.Size(892, 115);
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
            this.pnlCardIngresos.Size = new System.Drawing.Size(213, 105);
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
            // pnlCardVentas (Tarjeta 2: Transacciones)
            // 
            this.pnlCardVentas.BackColor = System.Drawing.Color.White;
            this.pnlCardVentas.Controls.Add(this.lblCardVentasVal);
            this.pnlCardVentas.Controls.Add(this.lblCardVentasTit);
            this.pnlCardVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardVentas.Location = new System.Drawing.Point(223, 0);
            this.pnlCardVentas.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.pnlCardVentas.Name = "pnlCardVentas";
            this.pnlCardVentas.Padding = new System.Windows.Forms.Padding(18);
            this.pnlCardVentas.Size = new System.Drawing.Size(213, 105);
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
            // pnlCardStockTotal (Tarjeta 3: Total Productos)
            // 
            this.pnlCardStockTotal.BackColor = System.Drawing.Color.White;
            this.pnlCardStockTotal.Controls.Add(this.lblCardStockVal);
            this.pnlCardStockTotal.Controls.Add(this.lblCardStockTit);
            this.pnlCardStockTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardStockTotal.Location = new System.Drawing.Point(446, 0);
            this.pnlCardStockTotal.Margin = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.pnlCardStockTotal.Name = "pnlCardStockTotal";
            this.pnlCardStockTotal.Padding = new System.Windows.Forms.Padding(18);
            this.pnlCardStockTotal.Size = new System.Drawing.Size(213, 105);
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
            this.pnlCardAlertas.Location = new System.Drawing.Point(669, 0);
            this.pnlCardAlertas.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlCardAlertas.Name = "pnlCardAlertas";
            this.pnlCardAlertas.Padding = new System.Windows.Forms.Padding(18);
            this.pnlCardAlertas.Size = new System.Drawing.Size(223, 105);
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
            // pnlChartContainer
            // 
            this.pnlChartContainer.Controls.Add(this.tblCharts);
            this.pnlChartContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartContainer.Location = new System.Drawing.Point(24, 139);
            this.pnlChartContainer.Name = "pnlChartContainer";
            this.pnlChartContainer.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
            this.pnlChartContainer.Size = new System.Drawing.Size(892, 457);
            this.pnlChartContainer.TabIndex = 1;
            // 
            // tblCharts (Distribución Responsiva: 63% Barras | 37% Donut)
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
            this.tblCharts.Size = new System.Drawing.Size(892, 443);
            this.tblCharts.TabIndex = 0;
            // 
            // pnlChartBarras (Gráfica 1: Barras Verticales)
            // 
            this.pnlChartBarras.BackColor = System.Drawing.Color.White;
            this.pnlChartBarras.Controls.Add(this.lblChartBarrasSub);
            this.pnlChartBarras.Controls.Add(this.lblChartBarrasTitulo);
            this.pnlChartBarras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartBarras.Location = new System.Drawing.Point(0, 0);
            this.pnlChartBarras.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlChartBarras.Name = "pnlChartBarras";
            this.pnlChartBarras.Padding = new System.Windows.Forms.Padding(20);
            this.pnlChartBarras.Size = new System.Drawing.Size(547, 443);
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
            // pnlChartDonut (Gráfica 2: Donut Circular)
            // 
            this.pnlChartDonut.BackColor = System.Drawing.Color.White;
            this.pnlChartDonut.Controls.Add(this.lblChartDonutSub);
            this.pnlChartDonut.Controls.Add(this.lblChartDonutTitulo);
            this.pnlChartDonut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartDonut.Location = new System.Drawing.Point(561, 0);
            this.pnlChartDonut.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChartDonut.Name = "pnlChartDonut";
            this.pnlChartDonut.Padding = new System.Windows.Forms.Padding(20);
            this.pnlChartDonut.Size = new System.Drawing.Size(331, 443);
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
            // tmrAnimacion
            // 
            this.tmrAnimacion.Interval = 16;
            this.tmrAnimacion.Tick += new System.EventHandler(this.tmrAnimacion_Tick);
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(940, 620);
            this.Controls.Add(this.pnlChartContainer);
            this.Controls.Add(this.tblMetrics);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "FormDashboard";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.Text = "Dashboard GCP";
            this.tblMetrics.ResumeLayout(false);
            this.pnlCardAlertas.ResumeLayout(false);
            this.pnlCardAlertas.PerformLayout();
            this.pnlCardStockTotal.ResumeLayout(false);
            this.pnlCardStockTotal.PerformLayout();
            this.pnlCardVentas.ResumeLayout(false);
            this.pnlCardVentas.PerformLayout();
            this.pnlCardIngresos.ResumeLayout(false);
            this.pnlCardIngresos.PerformLayout();
            this.pnlChartContainer.ResumeLayout(false);
            this.tblCharts.ResumeLayout(false);
            this.pnlChartBarras.ResumeLayout(false);
            this.pnlChartBarras.PerformLayout();
            this.pnlChartDonut.ResumeLayout(false);
            this.pnlChartDonut.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

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
        private System.Windows.Forms.Timer tmrAnimacion;
    }
}
