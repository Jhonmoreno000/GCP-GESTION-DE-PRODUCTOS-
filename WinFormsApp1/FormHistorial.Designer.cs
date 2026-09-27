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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.colHistId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistArticulos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHistTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnHistorialLimpiar = new System.Windows.Forms.Button();
            this.btnHistorialRefrescar = new System.Windows.Forms.Button();
            this.lblHistorialSub = new System.Windows.Forms.Label();
            this.lblHistorialTitulo = new System.Windows.Forms.Label();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContainer (Tarjeta Blanca para la Tabla)
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.Controls.Add(this.dgvHistorial);
            this.pnlContainer.Controls.Add(this.pnlHeader);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(24, 24);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContainer.Size = new System.Drawing.Size(892, 572);
            this.pnlContainer.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnHistorialLimpiar);
            this.pnlHeader.Controls.Add(this.btnHistorialRefrescar);
            this.pnlHeader.Controls.Add(this.lblHistorialSub);
            this.pnlHeader.Controls.Add(this.lblHistorialTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(20, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(852, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblHistorialTitulo
            // 
            this.lblHistorialTitulo.AutoSize = true;
            this.lblHistorialTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHistorialTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblHistorialTitulo.Location = new System.Drawing.Point(4, 4);
            this.lblHistorialTitulo.Name = "lblHistorialTitulo";
            this.lblHistorialTitulo.Size = new System.Drawing.Size(309, 25);
            this.lblHistorialTitulo.TabIndex = 0;
            this.lblHistorialTitulo.Text = "Registro Histórico de Ventas (GCP)";
            // 
            // lblHistorialSub
            // 
            this.lblHistorialSub.AutoSize = true;
            this.lblHistorialSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHistorialSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblHistorialSub.Location = new System.Drawing.Point(6, 32);
            this.lblHistorialSub.Name = "lblHistorialSub";
            this.lblHistorialSub.Size = new System.Drawing.Size(325, 15);
            this.lblHistorialSub.TabIndex = 1;
            this.lblHistorialSub.Text = "Auditoría en tiempo real de recibos y facturas procesadas";
            // 
            // btnHistorialRefrescar
            // 
            this.btnHistorialRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorialRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.btnHistorialRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorialRefrescar.FlatAppearance.BorderSize = 0;
            this.btnHistorialRefrescar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            this.btnHistorialRefrescar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(210)))), ((int)(((byte)(254)))));
            this.btnHistorialRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorialRefrescar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHistorialRefrescar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnHistorialRefrescar.Location = new System.Drawing.Point(560, 12);
            this.btnHistorialRefrescar.Name = "btnHistorialRefrescar";
            this.btnHistorialRefrescar.Size = new System.Drawing.Size(130, 36);
            this.btnHistorialRefrescar.TabIndex = 2;
            this.btnHistorialRefrescar.Text = "🔄 Actualizar";
            this.btnHistorialRefrescar.UseVisualStyleBackColor = false;
            this.btnHistorialRefrescar.Click += new System.EventHandler(this.btnHistorialRefrescar_Click);
            // 
            // btnHistorialLimpiar
            // 
            this.btnHistorialLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHistorialLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnHistorialLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistorialLimpiar.FlatAppearance.BorderSize = 0;
            this.btnHistorialLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.btnHistorialLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.btnHistorialLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorialLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHistorialLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnHistorialLimpiar.Location = new System.Drawing.Point(702, 12);
            this.btnHistorialLimpiar.Name = "btnHistorialLimpiar";
            this.btnHistorialLimpiar.Size = new System.Drawing.Size(142, 36);
            this.btnHistorialLimpiar.TabIndex = 3;
            this.btnHistorialLimpiar.Text = "🗑️ Vaciar Historial";
            this.btnHistorialLimpiar.UseVisualStyleBackColor = false;
            this.btnHistorialLimpiar.Click += new System.EventHandler(this.btnHistorialLimpiar_Click);
            // 
            // dgvHistorial (Columnas Visibles en el Diseñador Visual)
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colHistId,
                this.colHistFecha,
                this.colHistArticulos,
                this.colHistTotal
            });
            this.dgvHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistorial.Location = new System.Drawing.Point(20, 80);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.RowTemplate.Height = 42;
            this.dgvHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new System.Drawing.Size(852, 472);
            this.dgvHistorial.TabIndex = 1;
            // 
            // colHistId
            // 
            this.colHistId.DataPropertyName = "Id";
            this.colHistId.FillWeight = 40F;
            this.colHistId.HeaderText = "N° Venta";
            this.colHistId.Name = "colHistId";
            this.colHistId.ReadOnly = true;
            // 
            // colHistFecha
            // 
            this.colHistFecha.DataPropertyName = "Fecha";
            this.colHistFecha.FillWeight = 110F;
            this.colHistFecha.HeaderText = "Fecha y Hora";
            this.colHistFecha.Name = "colHistFecha";
            this.colHistFecha.ReadOnly = true;
            // 
            // colHistArticulos
            // 
            this.colHistArticulos.DataPropertyName = "ArticulosVendidos";
            this.colHistArticulos.FillWeight = 60F;
            this.colHistArticulos.HeaderText = "Cant. Artículos";
            this.colHistArticulos.Name = "colHistArticulos";
            this.colHistArticulos.ReadOnly = true;
            // 
            // colHistTotal
            // 
            this.colHistTotal.DataPropertyName = "Total";
            this.colHistTotal.FillWeight = 70F;
            this.colHistTotal.HeaderText = "Total Facturado";
            this.colHistTotal.Name = "colHistTotal";
            this.colHistTotal.ReadOnly = true;
            // 
            // FormHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(940, 620);
            this.Controls.Add(this.pnlContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "FormHistorial";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.Text = "Historial GCP";
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.Panel pnlContainer;
        public System.Windows.Forms.Panel pnlHeader;
        public System.Windows.Forms.Label lblHistorialTitulo;
        public System.Windows.Forms.Label lblHistorialSub;
        public System.Windows.Forms.Button btnHistorialRefrescar;
        public System.Windows.Forms.Button btnHistorialLimpiar;
        public System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistArticulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHistTotal;
    }
}
