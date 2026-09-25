namespace WinFormsApp1
{
    partial class FormVentas
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
            pnlFormVentas = new Panel();
            lblFormVentaSub = new Label();
            btnVentaCobrar = new Button();
            lblVentaTotalVal = new Label();
            lblVentaTotalTit = new Label();
            btnVentaAdd = new Button();
            txtVentaCant = new TextBox();
            lblVentaCant = new Label();
            cbxVentaProd = new ComboBox();
            lblVentaProd = new Label();
            lblFormVentaTitulo = new Label();
            pnlGridContainer = new Panel();
            dgvCarrito = new DataGridView();
            colVentaId = new DataGridViewTextBoxColumn();
            colVentaNombre = new DataGridViewTextBoxColumn();
            colVentaPrecio = new DataGridViewTextBoxColumn();
            colVentaCant = new DataGridViewTextBoxColumn();
            colVentaSubtotal = new DataGridViewTextBoxColumn();
            pnlGridHeader = new Panel();
            lblGridTitle = new Label();
            pnlFormVentas.SuspendLayout();
            pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            pnlGridHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFormVentas
            // 
            pnlFormVentas.BackColor = Color.White;
            pnlFormVentas.Controls.Add(lblFormVentaSub);
            pnlFormVentas.Controls.Add(btnVentaCobrar);
            pnlFormVentas.Controls.Add(lblVentaTotalVal);
            pnlFormVentas.Controls.Add(lblVentaTotalTit);
            pnlFormVentas.Controls.Add(btnVentaAdd);
            pnlFormVentas.Controls.Add(txtVentaCant);
            pnlFormVentas.Controls.Add(lblVentaCant);
            pnlFormVentas.Controls.Add(cbxVentaProd);
            pnlFormVentas.Controls.Add(lblVentaProd);
            pnlFormVentas.Controls.Add(lblFormVentaTitulo);
            pnlFormVentas.Dock = DockStyle.Left;
            pnlFormVentas.Location = new Point(24, 24);
            pnlFormVentas.Name = "pnlFormVentas";
            pnlFormVentas.Padding = new Padding(24);
            pnlFormVentas.Size = new Size(370, 572);
            pnlFormVentas.TabIndex = 0;
            // 
            // lblFormVentaSub
            // 
            lblFormVentaSub.AutoSize = true;
            lblFormVentaSub.Font = new Font("Segoe UI", 8.5F);
            lblFormVentaSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblFormVentaSub.Location = new Point(22, 46);
            lblFormVentaSub.Name = "lblFormVentaSub";
            lblFormVentaSub.Size = new Size(224, 15);
            lblFormVentaSub.TabIndex = 1;
            lblFormVentaSub.Text = "Selecciona artículos para generar la venta";
            // 
            // btnVentaCobrar
            // 
            btnVentaCobrar.BackColor = Color.FromArgb(16, 185, 129);
            btnVentaCobrar.Cursor = Cursors.Hand;
            btnVentaCobrar.FlatAppearance.BorderSize = 0;
            btnVentaCobrar.FlatStyle = FlatStyle.Flat;
            btnVentaCobrar.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            btnVentaCobrar.ForeColor = Color.White;
            btnVentaCobrar.Location = new Point(22, 505);
            btnVentaCobrar.Name = "btnVentaCobrar";
            btnVentaCobrar.Size = new Size(324, 52);
            btnVentaCobrar.TabIndex = 9;
            btnVentaCobrar.Text = "💳 COBRAR Y FACTURAR";
            btnVentaCobrar.UseVisualStyleBackColor = false;
            btnVentaCobrar.Click += btnVentaCobrar_Click;
            // 
            // lblVentaTotalVal
            // 
            lblVentaTotalVal.AutoSize = true;
            lblVentaTotalVal.Font = new Font("Segoe UI", 30F, FontStyle.Bold);
            lblVentaTotalVal.ForeColor = Color.FromArgb(16, 185, 129);
            lblVentaTotalVal.Location = new Point(16, 442);
            lblVentaTotalVal.Name = "lblVentaTotalVal";
            lblVentaTotalVal.Size = new Size(126, 54);
            lblVentaTotalVal.TabIndex = 8;
            lblVentaTotalVal.Text = "$0.00";
            // 
            // lblVentaTotalTit
            // 
            lblVentaTotalTit.AutoSize = true;
            lblVentaTotalTit.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblVentaTotalTit.ForeColor = Color.FromArgb(100, 116, 139);
            lblVentaTotalTit.Location = new Point(22, 420);
            lblVentaTotalTit.Name = "lblVentaTotalTit";
            lblVentaTotalTit.Size = new Size(120, 17);
            lblVentaTotalTit.TabIndex = 7;
            lblVentaTotalTit.Text = "TOTAL A COBRAR:";
            // 
            // btnVentaAdd
            // 
            btnVentaAdd.BackColor = Color.FromArgb(79, 70, 229);
            btnVentaAdd.Cursor = Cursors.Hand;
            btnVentaAdd.FlatAppearance.BorderSize = 0;
            btnVentaAdd.FlatStyle = FlatStyle.Flat;
            btnVentaAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVentaAdd.ForeColor = Color.White;
            btnVentaAdd.Location = new Point(164, 172);
            btnVentaAdd.Name = "btnVentaAdd";
            btnVentaAdd.Size = new Size(182, 30);
            btnVentaAdd.TabIndex = 6;
            btnVentaAdd.Text = "\U0001f6d2 Añadir a Canasta";
            btnVentaAdd.UseVisualStyleBackColor = false;
            btnVentaAdd.Click += btnVentaAdd_Click;
            // 
            // txtVentaCant
            // 
            txtVentaCant.BackColor = Color.White;
            txtVentaCant.BorderStyle = BorderStyle.FixedSingle;
            txtVentaCant.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtVentaCant.Location = new Point(22, 172);
            txtVentaCant.Name = "txtVentaCant";
            txtVentaCant.Size = new Size(130, 29);
            txtVentaCant.TabIndex = 5;
            // 
            // lblVentaCant
            // 
            lblVentaCant.AutoSize = true;
            lblVentaCant.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblVentaCant.ForeColor = Color.FromArgb(71, 85, 105);
            lblVentaCant.Location = new Point(20, 152);
            lblVentaCant.Name = "lblVentaCant";
            lblVentaCant.Size = new Size(128, 15);
            lblVentaCant.TabIndex = 4;
            lblVentaCant.Text = "CANTIDAD A VENDER";
            // 
            // cbxVentaProd
            // 
            cbxVentaProd.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxVentaProd.Font = new Font("Segoe UI", 11F);
            cbxVentaProd.FormattingEnabled = true;
            cbxVentaProd.Location = new Point(22, 105);
            cbxVentaProd.Name = "cbxVentaProd";
            cbxVentaProd.Size = new Size(324, 28);
            cbxVentaProd.TabIndex = 3;
            // 
            // lblVentaProd
            // 
            lblVentaProd.AutoSize = true;
            lblVentaProd.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblVentaProd.ForeColor = Color.FromArgb(71, 85, 105);
            lblVentaProd.Location = new Point(20, 85);
            lblVentaProd.Name = "lblVentaProd";
            lblVentaProd.Size = new Size(166, 15);
            lblVentaProd.TabIndex = 2;
            lblVentaProd.Text = "SELECCIONAR UN ARTÍCULO";
            // 
            // lblFormVentaTitulo
            // 
            lblFormVentaTitulo.AutoSize = true;
            lblFormVentaTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFormVentaTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblFormVentaTitulo.Location = new Point(20, 18);
            lblFormVentaTitulo.Name = "lblFormVentaTitulo";
            lblFormVentaTitulo.Size = new Size(211, 25);
            lblFormVentaTitulo.TabIndex = 0;
            lblFormVentaTitulo.Text = "Caja Registradora GCP";
            // 
            // pnlGridContainer
            // 
            pnlGridContainer.BackColor = Color.White;
            pnlGridContainer.Controls.Add(dgvCarrito);
            pnlGridContainer.Controls.Add(pnlGridHeader);
            pnlGridContainer.Dock = DockStyle.Fill;
            pnlGridContainer.Location = new Point(394, 24);
            pnlGridContainer.Name = "pnlGridContainer";
            pnlGridContainer.Padding = new Padding(16);
            pnlGridContainer.Size = new Size(522, 572);
            pnlGridContainer.TabIndex = 1;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.BorderStyle = BorderStyle.None;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Columns.AddRange(new DataGridViewColumn[] { colVentaId, colVentaNombre, colVentaPrecio, colVentaCant, colVentaSubtotal });
            dgvCarrito.Dock = DockStyle.Fill;
            dgvCarrito.Location = new Point(16, 56);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.RowTemplate.Height = 40;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(490, 500);
            dgvCarrito.TabIndex = 1;
            // 
            // colVentaId
            // 
            colVentaId.DataPropertyName = "IdProducto";
            colVentaId.FillWeight = 40F;
            colVentaId.HeaderText = "ID";
            colVentaId.Name = "colVentaId";
            colVentaId.ReadOnly = true;
            // 
            // colVentaNombre
            // 
            colVentaNombre.DataPropertyName = "Nombre";
            colVentaNombre.FillWeight = 130F;
            colVentaNombre.HeaderText = "Artículo";
            colVentaNombre.Name = "colVentaNombre";
            colVentaNombre.ReadOnly = true;
            // 
            // colVentaPrecio
            // 
            colVentaPrecio.DataPropertyName = "Precio";
            colVentaPrecio.FillWeight = 60F;
            colVentaPrecio.HeaderText = "Precio Unit.";
            colVentaPrecio.Name = "colVentaPrecio";
            colVentaPrecio.ReadOnly = true;
            // 
            // colVentaCant
            // 
            colVentaCant.DataPropertyName = "Cantidad";
            colVentaCant.FillWeight = 50F;
            colVentaCant.HeaderText = "Cant.";
            colVentaCant.Name = "colVentaCant";
            colVentaCant.ReadOnly = true;
            // 
            // colVentaSubtotal
            // 
            colVentaSubtotal.DataPropertyName = "Subtotal";
            colVentaSubtotal.FillWeight = 65F;
            colVentaSubtotal.HeaderText = "Subtotal";
            colVentaSubtotal.Name = "colVentaSubtotal";
            colVentaSubtotal.ReadOnly = true;
            // 
            // pnlGridHeader
            // 
            pnlGridHeader.Controls.Add(lblGridTitle);
            pnlGridHeader.Dock = DockStyle.Top;
            pnlGridHeader.Location = new Point(16, 16);
            pnlGridHeader.Name = "pnlGridHeader";
            pnlGridHeader.Size = new Size(490, 40);
            pnlGridHeader.TabIndex = 0;
            // 
            // lblGridTitle
            // 
            lblGridTitle.AutoSize = true;
            lblGridTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblGridTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblGridTitle.Location = new Point(4, 8);
            lblGridTitle.Name = "lblGridTitle";
            lblGridTitle.Size = new Size(210, 21);
            lblGridTitle.TabIndex = 0;
            lblGridTitle.Text = "Canasta Actual de Compra";
            // 
            // FormVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(940, 620);
            Controls.Add(pnlGridContainer);
            Controls.Add(pnlFormVentas);
            Font = new Font("Segoe UI", 9.5F);
            Name = "FormVentas";
            Padding = new Padding(24);
            Text = "3";
            pnlFormVentas.ResumeLayout(false);
            pnlFormVentas.PerformLayout();
            pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            pnlGridHeader.ResumeLayout(false);
            pnlGridHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.Panel pnlFormVentas;
        public System.Windows.Forms.Label lblFormVentaTitulo;
        public System.Windows.Forms.Label lblFormVentaSub;
        public System.Windows.Forms.Label lblVentaProd;
        public System.Windows.Forms.ComboBox cbxVentaProd;
        public System.Windows.Forms.Label lblVentaCant;
        public System.Windows.Forms.TextBox txtVentaCant;
        public System.Windows.Forms.Button btnVentaAdd;
        public System.Windows.Forms.Label lblVentaTotalTit;
        public System.Windows.Forms.Label lblVentaTotalVal;
        public System.Windows.Forms.Button btnVentaCobrar;
        public System.Windows.Forms.Panel pnlGridContainer;
        public System.Windows.Forms.Panel pnlGridHeader;
        public System.Windows.Forms.Label lblGridTitle;
        public System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaSubtotal;
    }
}
