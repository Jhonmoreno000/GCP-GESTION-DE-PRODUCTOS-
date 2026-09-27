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
            this.tblLayoutVentas = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFormVentas = new System.Windows.Forms.Panel();
            this.lblFormVentaTitulo = new System.Windows.Forms.Label();
            this.lblFormVentaSub = new System.Windows.Forms.Label();
            this.lblVentaProd = new System.Windows.Forms.Label();
            this.cbxVentaProd = new System.Windows.Forms.ComboBox();
            this.lblVentaCant = new System.Windows.Forms.Label();
            this.tblVentaAdd = new System.Windows.Forms.TableLayoutPanel();
            this.txtVentaCant = new System.Windows.Forms.TextBox();
            this.btnVentaAdd = new System.Windows.Forms.Button();
            this.pnlCobroContainer = new System.Windows.Forms.Panel();
            this.lblVentaTotalTit = new System.Windows.Forms.Label();
            this.lblVentaTotalVal = new System.Windows.Forms.Label();
            this.btnVentaCobrar = new System.Windows.Forms.Button();
            this.pnlGridContainer = new System.Windows.Forms.Panel();
            this.pnlGridHeader = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.btnVentaQuitar = new System.Windows.Forms.Button();
            this.btnVentaVaciar = new System.Windows.Forms.Button();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.colVentaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaCant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVentaSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.tblLayoutVentas.SuspendLayout();
            this.pnlFormVentas.SuspendLayout();
            this.tblVentaAdd.SuspendLayout();
            this.pnlCobroContainer.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            this.pnlGridHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();

            // 
            // tblLayoutVentas (Distribución Responsiva: 38% Caja | 62% Canasta)
            // 
            this.tblLayoutVentas.ColumnCount = 2;
            this.tblLayoutVentas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tblLayoutVentas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.tblLayoutVentas.Controls.Add(this.pnlFormVentas, 0, 0);
            this.tblLayoutVentas.Controls.Add(this.pnlGridContainer, 1, 0);
            this.tblLayoutVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutVentas.Location = new System.Drawing.Point(24, 24);
            this.tblLayoutVentas.Name = "tblLayoutVentas";
            this.tblLayoutVentas.RowCount = 1;
            this.tblLayoutVentas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutVentas.Size = new System.Drawing.Size(892, 572);
            this.tblLayoutVentas.TabIndex = 0;

            // 
            // pnlFormVentas (Tarjeta de Facturación)
            // 
            this.pnlFormVentas.BackColor = System.Drawing.Color.White;
            this.pnlFormVentas.Controls.Add(this.pnlCobroContainer);
            this.pnlFormVentas.Controls.Add(this.tblVentaAdd);
            this.pnlFormVentas.Controls.Add(this.lblVentaCant);
            this.pnlFormVentas.Controls.Add(this.cbxVentaProd);
            this.pnlFormVentas.Controls.Add(this.lblVentaProd);
            this.pnlFormVentas.Controls.Add(this.lblFormVentaSub);
            this.pnlFormVentas.Controls.Add(this.lblFormVentaTitulo);
            this.pnlFormVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormVentas.Location = new System.Drawing.Point(0, 0);
            this.pnlFormVentas.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlFormVentas.Name = "pnlFormVentas";
            this.pnlFormVentas.Padding = new System.Windows.Forms.Padding(22);
            this.pnlFormVentas.Size = new System.Drawing.Size(322, 572);
            this.pnlFormVentas.TabIndex = 0;

            // 
            // lblFormVentaTitulo
            // 
            this.lblFormVentaTitulo.AutoSize = true;
            this.lblFormVentaTitulo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFormVentaTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblFormVentaTitulo.Location = new System.Drawing.Point(18, 16);
            this.lblFormVentaTitulo.Name = "lblFormVentaTitulo";
            this.lblFormVentaTitulo.Size = new System.Drawing.Size(209, 25);
            this.lblFormVentaTitulo.TabIndex = 0;
            this.lblFormVentaTitulo.Text = "Caja Registradora GCP";

            // 
            // lblFormVentaSub
            // 
            this.lblFormVentaSub.AutoSize = true;
            this.lblFormVentaSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFormVentaSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFormVentaSub.Location = new System.Drawing.Point(20, 42);
            this.lblFormVentaSub.Name = "lblFormVentaSub";
            this.lblFormVentaSub.Size = new System.Drawing.Size(224, 15);
            this.lblFormVentaSub.TabIndex = 1;
            this.lblFormVentaSub.Text = "Selecciona artículos para generar la venta";

            // 
            // lblVentaProd
            // 
            this.lblVentaProd.AutoSize = true;
            this.lblVentaProd.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblVentaProd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblVentaProd.Location = new System.Drawing.Point(20, 80);
            this.lblVentaProd.Name = "lblVentaProd";
            this.lblVentaProd.Size = new System.Drawing.Size(166, 15);
            this.lblVentaProd.TabIndex = 2;
            this.lblVentaProd.Text = "SELECCIONAR UN ARTÍCULO";

            // 
            // cbxVentaProd
            // 
            this.cbxVentaProd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxVentaProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVentaProd.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbxVentaProd.FormattingEnabled = true;
            this.cbxVentaProd.Location = new System.Drawing.Point(20, 100);
            this.cbxVentaProd.Name = "cbxVentaProd";
            this.cbxVentaProd.Size = new System.Drawing.Size(282, 28);
            this.cbxVentaProd.TabIndex = 3;

            // 
            // lblVentaCant
            // 
            this.lblVentaCant.AutoSize = true;
            this.lblVentaCant.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblVentaCant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblVentaCant.Location = new System.Drawing.Point(20, 146);
            this.lblVentaCant.Name = "lblVentaCant";
            this.lblVentaCant.Size = new System.Drawing.Size(128, 15);
            this.lblVentaCant.TabIndex = 4;
            this.lblVentaCant.Text = "CANTIDAD A VENDER";

            // 
            // tblVentaAdd (Contenedor Responsivo: Cantidad + Botón de Añadir)
            // 
            this.tblVentaAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblVentaAdd.ColumnCount = 2;
            this.tblVentaAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblVentaAdd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tblVentaAdd.Controls.Add(this.txtVentaCant, 0, 0);
            this.tblVentaAdd.Controls.Add(this.btnVentaAdd, 1, 0);
            this.tblVentaAdd.Location = new System.Drawing.Point(20, 168);
            this.tblVentaAdd.Name = "tblVentaAdd";
            this.tblVentaAdd.RowCount = 1;
            this.tblVentaAdd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblVentaAdd.Size = new System.Drawing.Size(282, 38);
            this.tblVentaAdd.TabIndex = 5;

            // 
            // txtVentaCant
            // 
            this.txtVentaCant.BackColor = System.Drawing.Color.White;
            this.txtVentaCant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVentaCant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVentaCant.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtVentaCant.Location = new System.Drawing.Point(0, 4);
            this.txtVentaCant.Margin = new System.Windows.Forms.Padding(0, 4, 8, 4);
            this.txtVentaCant.Name = "txtVentaCant";
            this.txtVentaCant.Size = new System.Drawing.Size(90, 29);
            this.txtVentaCant.TabIndex = 0;

            // 
            // btnVentaAdd (Botón Responsivo Añadir a Canasta)
            // 
            this.btnVentaAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnVentaAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentaAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVentaAdd.FlatAppearance.BorderSize = 0;
            this.btnVentaAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(56)))), ((int)(((byte)(202)))));
            this.btnVentaAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(48)))), ((int)(((byte)(163)))));
            this.btnVentaAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentaAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnVentaAdd.ForeColor = System.Drawing.Color.White;
            this.btnVentaAdd.Location = new System.Drawing.Point(98, 0);
            this.btnVentaAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnVentaAdd.Name = "btnVentaAdd";
            this.btnVentaAdd.Size = new System.Drawing.Size(184, 38);
            this.btnVentaAdd.TabIndex = 1;
            this.btnVentaAdd.Text = "🛒 Añadir a Canasta";
            this.btnVentaAdd.UseVisualStyleBackColor = false;
            this.btnVentaAdd.Click += new System.EventHandler(this.btnVentaAdd_Click);

            // 
            // pnlCobroContainer (Panel Inferior Acoplado Responsivo)
            // 
            this.pnlCobroContainer.Controls.Add(this.lblVentaTotalTit);
            this.pnlCobroContainer.Controls.Add(this.lblVentaTotalVal);
            this.pnlCobroContainer.Controls.Add(this.btnVentaCobrar);
            this.pnlCobroContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCobroContainer.Location = new System.Drawing.Point(22, 398);
            this.pnlCobroContainer.Name = "pnlCobroContainer";
            this.pnlCobroContainer.Size = new System.Drawing.Size(278, 152);
            this.pnlCobroContainer.TabIndex = 6;

            // 
            // lblVentaTotalTit
            // 
            this.lblVentaTotalTit.AutoSize = true;
            this.lblVentaTotalTit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblVentaTotalTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblVentaTotalTit.Location = new System.Drawing.Point(2, 6);
            this.lblVentaTotalTit.Name = "lblVentaTotalTit";
            this.lblVentaTotalTit.Size = new System.Drawing.Size(120, 17);
            this.lblVentaTotalTit.TabIndex = 0;
            this.lblVentaTotalTit.Text = "TOTAL A COBRAR:";

            // 
            // lblVentaTotalVal
            // 
            this.lblVentaTotalVal.AutoSize = true;
            this.lblVentaTotalVal.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblVentaTotalVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblVentaTotalVal.Location = new System.Drawing.Point(0, 28);
            this.lblVentaTotalVal.Name = "lblVentaTotalVal";
            this.lblVentaTotalVal.Size = new System.Drawing.Size(117, 51);
            this.lblVentaTotalVal.TabIndex = 1;
            this.lblVentaTotalVal.Text = "$0.00";

            // 
            // btnVentaCobrar (Botón Verde Responsivo a Ancho Total)
            // 
            this.btnVentaCobrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnVentaCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentaCobrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnVentaCobrar.FlatAppearance.BorderSize = 0;
            this.btnVentaCobrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnVentaCobrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(120)))), ((int)(((byte)(87)))));
            this.btnVentaCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentaCobrar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnVentaCobrar.ForeColor = System.Drawing.Color.White;
            this.btnVentaCobrar.Location = new System.Drawing.Point(0, 98);
            this.btnVentaCobrar.Name = "btnVentaCobrar";
            this.btnVentaCobrar.Size = new System.Drawing.Size(278, 54);
            this.btnVentaCobrar.TabIndex = 2;
            this.btnVentaCobrar.Text = "💳 COBRAR Y FACTURAR";
            this.btnVentaCobrar.UseVisualStyleBackColor = false;
            this.btnVentaCobrar.Click += new System.EventHandler(this.btnVentaCobrar_Click);

            // 
            // pnlGridContainer (Tarjeta de la Tabla)
            // 
            this.pnlGridContainer.BackColor = System.Drawing.Color.White;
            this.pnlGridContainer.Controls.Add(this.dgvCarrito);
            this.pnlGridContainer.Controls.Add(this.pnlGridHeader);
            this.pnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridContainer.Location = new System.Drawing.Point(338, 0);
            this.pnlGridContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Padding = new System.Windows.Forms.Padding(16);
            this.pnlGridContainer.Size = new System.Drawing.Size(554, 572);
            this.pnlGridContainer.TabIndex = 1;

            // 
            // pnlGridHeader
            // 
            this.pnlGridHeader.Controls.Add(this.btnVentaVaciar);
            this.pnlGridHeader.Controls.Add(this.btnVentaQuitar);
            this.pnlGridHeader.Controls.Add(this.lblGridTitle);
            this.pnlGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridHeader.Location = new System.Drawing.Point(16, 16);
            this.pnlGridHeader.Name = "pnlGridHeader";
            this.pnlGridHeader.Size = new System.Drawing.Size(522, 40);
            this.pnlGridHeader.TabIndex = 0;

            // 
            // lblGridTitle
            // 
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblGridTitle.Location = new System.Drawing.Point(4, 8);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(210, 21);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "Canasta Actual de Compra";

            // 
            // btnVentaQuitar (Botón Responsivo Quitar Item)
            // 
            this.btnVentaQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVentaQuitar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnVentaQuitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentaQuitar.FlatAppearance.BorderSize = 0;
            this.btnVentaQuitar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            this.btnVentaQuitar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnVentaQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentaQuitar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnVentaQuitar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnVentaQuitar.Location = new System.Drawing.Point(260, 4);
            this.btnVentaQuitar.Name = "btnVentaQuitar";
            this.btnVentaQuitar.Size = new System.Drawing.Size(120, 32);
            this.btnVentaQuitar.TabIndex = 1;
            this.btnVentaQuitar.Text = "🗑️ Quitar Item";
            this.btnVentaQuitar.UseVisualStyleBackColor = false;
            this.btnVentaQuitar.Click += new System.EventHandler(this.btnVentaQuitar_Click);

            // 
            // btnVentaVaciar (Botón Responsivo Vaciar Carrito)
            // 
            this.btnVentaVaciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVentaVaciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnVentaVaciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentaVaciar.FlatAppearance.BorderSize = 0;
            this.btnVentaVaciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnVentaVaciar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnVentaVaciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentaVaciar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnVentaVaciar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnVentaVaciar.Location = new System.Drawing.Point(388, 4);
            this.btnVentaVaciar.Name = "btnVentaVaciar";
            this.btnVentaVaciar.Size = new System.Drawing.Size(130, 32);
            this.btnVentaVaciar.TabIndex = 2;
            this.btnVentaVaciar.Text = "🔄 Vaciar Canasta";
            this.btnVentaVaciar.UseVisualStyleBackColor = false;
            this.btnVentaVaciar.Click += new System.EventHandler(this.btnVentaVaciar_Click);

            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AllowUserToAddRows = false;
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarrito.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colVentaId,
                this.colVentaNombre,
                this.colVentaPrecio,
                this.colVentaCant,
                this.colVentaSubtotal
            });
            this.dgvCarrito.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarrito.Location = new System.Drawing.Point(16, 56);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.ReadOnly = true;
            this.dgvCarrito.RowHeadersVisible = false;
            this.dgvCarrito.RowTemplate.Height = 40;
            this.dgvCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarrito.Size = new System.Drawing.Size(522, 500);
            this.dgvCarrito.TabIndex = 1;

            // 
            // colVentaId
            // 
            this.colVentaId.DataPropertyName = "IdProducto";
            this.colVentaId.FillWeight = 40F;
            this.colVentaId.HeaderText = "ID";
            this.colVentaId.Name = "colVentaId";
            this.colVentaId.ReadOnly = true;

            // 
            // colVentaNombre
            // 
            this.colVentaNombre.DataPropertyName = "Nombre";
            this.colVentaNombre.FillWeight = 130F;
            this.colVentaNombre.HeaderText = "Artículo";
            this.colVentaNombre.Name = "colVentaNombre";
            this.colVentaNombre.ReadOnly = true;

            // 
            // colVentaPrecio
            // 
            this.colVentaPrecio.DataPropertyName = "Precio";
            this.colVentaPrecio.FillWeight = 60F;
            this.colVentaPrecio.HeaderText = "Precio Unit.";
            this.colVentaPrecio.Name = "colVentaPrecio";
            this.colVentaPrecio.ReadOnly = true;

            // 
            // colVentaCant
            // 
            this.colVentaCant.DataPropertyName = "Cantidad";
            this.colVentaCant.FillWeight = 50F;
            this.colVentaCant.HeaderText = "Cant.";
            this.colVentaCant.Name = "colVentaCant";
            this.colVentaCant.ReadOnly = true;

            // 
            // colVentaSubtotal
            // 
            this.colVentaSubtotal.DataPropertyName = "Subtotal";
            this.colVentaSubtotal.FillWeight = 65F;
            this.colVentaSubtotal.HeaderText = "Subtotal";
            this.colVentaSubtotal.Name = "colVentaSubtotal";
            this.colVentaSubtotal.ReadOnly = true;

            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(940, 620);
            this.Controls.Add(this.tblLayoutVentas);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "FormVentas";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.Text = "Punto de Venta GCP";
            this.tblLayoutVentas.ResumeLayout(false);
            this.pnlFormVentas.ResumeLayout(false);
            this.pnlFormVentas.PerformLayout();
            this.tblVentaAdd.ResumeLayout(false);
            this.tblVentaAdd.PerformLayout();
            this.pnlCobroContainer.ResumeLayout(false);
            this.pnlCobroContainer.PerformLayout();
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.pnlGridHeader.ResumeLayout(false);
            this.pnlGridHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tblLayoutVentas;
        public System.Windows.Forms.Panel pnlFormVentas;
        public System.Windows.Forms.Label lblFormVentaTitulo;
        public System.Windows.Forms.Label lblFormVentaSub;
        public System.Windows.Forms.Label lblVentaProd;
        public System.Windows.Forms.ComboBox cbxVentaProd;
        public System.Windows.Forms.Label lblVentaCant;
        public System.Windows.Forms.TableLayoutPanel tblVentaAdd;
        public System.Windows.Forms.TextBox txtVentaCant;
        public System.Windows.Forms.Button btnVentaAdd;
        public System.Windows.Forms.Panel pnlCobroContainer;
        public System.Windows.Forms.Label lblVentaTotalTit;
        public System.Windows.Forms.Label lblVentaTotalVal;
        public System.Windows.Forms.Button btnVentaCobrar;
        public System.Windows.Forms.Panel pnlGridContainer;
        public System.Windows.Forms.Panel pnlGridHeader;
        public System.Windows.Forms.Label lblGridTitle;
        public System.Windows.Forms.Button btnVentaQuitar;
        public System.Windows.Forms.Button btnVentaVaciar;
        public System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaCant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVentaSubtotal;
    }
}
