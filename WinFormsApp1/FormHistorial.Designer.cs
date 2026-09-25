namespace WinFormsApp1
{
    partial class FormHistorial
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
            pnlContainer = new Panel();
            dgvHistorial = new DataGridView();
            colHistId = new DataGridViewTextBoxColumn();
            colHistFecha = new DataGridViewTextBoxColumn();
            colHistArticulos = new DataGridViewTextBoxColumn();
            colHistTotal = new DataGridViewTextBoxColumn();
            pnlHeader = new Panel();
            lblHistorialSub = new Label();
            lblHistorialTitulo = new Label();
            pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContainer (Tarjeta Blanca para la Tabla)
            // 
            pnlContainer.BackColor = Color.White;
            pnlContainer.Controls.Add(dgvHistorial);
            pnlContainer.Controls.Add(pnlHeader);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(24, 24);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(20);
            pnlContainer.Size = new Size(892, 572);
            pnlContainer.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblHistorialSub);
            pnlHeader.Controls.Add(lblHistorialTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(20, 20);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(852, 60);
            pnlHeader.TabIndex = 0;
            // 
            // lblHistorialTitulo
            // 
            lblHistorialTitulo.AutoSize = true;
            lblHistorialTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblHistorialTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblHistorialTitulo.Location = new Point(4, 4);
            lblHistorialTitulo.Name = "lblHistorialTitulo";
            lblHistorialTitulo.Size = new Size(309, 25);
            lblHistorialTitulo.TabIndex = 0;
            lblHistorialTitulo.Text = "Registro Histórico de Ventas (GCP)";
            // 
            // lblHistorialSub
            // 
            lblHistorialSub.AutoSize = true;
            lblHistorialSub.Font = new Font("Segoe UI", 9F);
            lblHistorialSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblHistorialSub.Location = new Point(6, 32);
            lblHistorialSub.Name = "lblHistorialSub";
            lblHistorialSub.Size = new Size(325, 15);
            lblHistorialSub.TabIndex = 1;
            lblHistorialSub.Text = "Auditoría en tiempo real de recibos y facturas procesadas";
            // 
            // dgvHistorial (Columnas Visibles en el Diseñador Visual)
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = Color.White;
            dgvHistorial.BorderStyle = BorderStyle.None;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Columns.AddRange(new DataGridViewColumn[] { colHistId, colHistFecha, colHistArticulos, colHistTotal });
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.Location = new Point(20, 80);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.RowTemplate.Height = 42;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(852, 472);
            dgvHistorial.TabIndex = 1;
            // 
            // colHistId
            // 
            colHistId.DataPropertyName = "Id";
            colHistId.FillWeight = 40F;
            colHistId.HeaderText = "N° Venta";
            colHistId.Name = "colHistId";
            colHistId.ReadOnly = true;
            // 
            // colHistFecha
            // 
            colHistFecha.DataPropertyName = "Fecha";
            colHistFecha.FillWeight = 110F;
            colHistFecha.HeaderText = "Fecha y Hora";
            colHistFecha.Name = "colHistFecha";
            colHistFecha.ReadOnly = true;
            // 
            // colHistArticulos
            // 
            colHistArticulos.DataPropertyName = "ArticulosVendidos";
            colHistArticulos.FillWeight = 60F;
            colHistArticulos.HeaderText = "Cant. Artículos";
            colHistArticulos.Name = "colHistArticulos";
            colHistArticulos.ReadOnly = true;
            // 
            // colHistTotal
            // 
            colHistTotal.DataPropertyName = "Total";
            colHistTotal.FillWeight = 70F;
            colHistTotal.HeaderText = "Total Facturado";
            colHistTotal.Name = "colHistTotal";
            colHistTotal.ReadOnly = true;
            // 
            // FormHistorial
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(940, 620);
            Controls.Add(pnlContainer);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.Sizable;
            Name = "FormHistorial";
            Padding = new Padding(24);
            Text = "Historial GCP";
            pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.Panel pnlContainer;
        public System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblHistorialTitulo;
        public System.Windows.Forms.Label lblHistorialSub;
        public System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistArticulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistTotal;
    }
}
