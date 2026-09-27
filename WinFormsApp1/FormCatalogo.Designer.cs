namespace WinFormsApp1
{
    partial class FormCatalogo
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
            this.tblLayoutCatalogo = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFormProductos = new System.Windows.Forms.Panel();
            this.lblFormProdTitulo = new System.Windows.Forms.Label();
            this.lblFormProdSub = new System.Windows.Forms.Label();
            this.lblProdId = new System.Windows.Forms.Label();
            this.txtProdId = new System.Windows.Forms.TextBox();
            this.lblProdNombre = new System.Windows.Forms.Label();
            this.txtProdNombre = new System.Windows.Forms.TextBox();
            this.lblProdPrecio = new System.Windows.Forms.Label();
            this.txtProdPrecio = new System.Windows.Forms.TextBox();
            this.lblProdCantidad = new System.Windows.Forms.Label();
            this.txtProdCantidad = new System.Windows.Forms.TextBox();
            this.tblProdBotones = new System.Windows.Forms.TableLayoutPanel();
            this.btnProdGuardar = new System.Windows.Forms.Button();
            this.btnProdEditar = new System.Windows.Forms.Button();
            this.btnProdEliminar = new System.Windows.Forms.Button();
            this.btnProdLimpiar = new System.Windows.Forms.Button();
            this.pnlGridContainer = new System.Windows.Forms.Panel();
            this.pnlGridHeader = new System.Windows.Forms.Panel();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.btnProdRefrescar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.tblLayoutCatalogo.SuspendLayout();
            this.pnlFormProductos.SuspendLayout();
            this.tblProdBotones.SuspendLayout();
            this.pnlGridContainer.SuspendLayout();
            this.pnlGridHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();

            // 
            // tblLayoutCatalogo (Contenedor Responsivo Maestro: 35% Formulario | 65% Tabla)
            // 
            this.tblLayoutCatalogo.ColumnCount = 2;
            this.tblLayoutCatalogo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblLayoutCatalogo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tblLayoutCatalogo.Controls.Add(this.pnlFormProductos, 0, 0);
            this.tblLayoutCatalogo.Controls.Add(this.pnlGridContainer, 1, 0);
            this.tblLayoutCatalogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutCatalogo.Location = new System.Drawing.Point(24, 24);
            this.tblLayoutCatalogo.Name = "tblLayoutCatalogo";
            this.tblLayoutCatalogo.RowCount = 1;
            this.tblLayoutCatalogo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutCatalogo.Size = new System.Drawing.Size(892, 572);
            this.tblLayoutCatalogo.TabIndex = 0;

            // 
            // pnlFormProductos (Tarjeta de Entrada Responsiva)
            // 
            this.pnlFormProductos.BackColor = System.Drawing.Color.White;
            this.pnlFormProductos.Controls.Add(this.tblProdBotones);
            this.pnlFormProductos.Controls.Add(this.txtProdCantidad);
            this.pnlFormProductos.Controls.Add(this.lblProdCantidad);
            this.pnlFormProductos.Controls.Add(this.txtProdPrecio);
            this.pnlFormProductos.Controls.Add(this.lblProdPrecio);
            this.pnlFormProductos.Controls.Add(this.txtProdNombre);
            this.pnlFormProductos.Controls.Add(this.lblProdNombre);
            this.pnlFormProductos.Controls.Add(this.txtProdId);
            this.pnlFormProductos.Controls.Add(this.lblProdId);
            this.pnlFormProductos.Controls.Add(this.lblFormProdSub);
            this.pnlFormProductos.Controls.Add(this.lblFormProdTitulo);
            this.pnlFormProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormProductos.Location = new System.Drawing.Point(0, 0);
            this.pnlFormProductos.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlFormProductos.Name = "pnlFormProductos";
            this.pnlFormProductos.Padding = new System.Windows.Forms.Padding(20);
            this.pnlFormProductos.Size = new System.Drawing.Size(296, 572);
            this.pnlFormProductos.TabIndex = 0;

            // 
            // lblFormProdTitulo
            // 
            this.lblFormProdTitulo.AutoSize = true;
            this.lblFormProdTitulo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblFormProdTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblFormProdTitulo.Location = new System.Drawing.Point(18, 16);
            this.lblFormProdTitulo.Name = "lblFormProdTitulo";
            this.lblFormProdTitulo.Size = new System.Drawing.Size(183, 25);
            this.lblFormProdTitulo.TabIndex = 0;
            this.lblFormProdTitulo.Text = "Gestión de Artículo";

            // 
            // lblFormProdSub
            // 
            this.lblFormProdSub.AutoSize = true;
            this.lblFormProdSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblFormProdSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblFormProdSub.Location = new System.Drawing.Point(20, 42);
            this.lblFormProdSub.Name = "lblFormProdSub";
            this.lblFormProdSub.Size = new System.Drawing.Size(211, 15);
            this.lblFormProdSub.TabIndex = 1;
            this.lblFormProdSub.Text = "Ingresa los datos para actualizar stock";

            // 
            // lblProdId
            // 
            this.lblProdId.AutoSize = true;
            this.lblProdId.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblProdId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblProdId.Location = new System.Drawing.Point(20, 75);
            this.lblProdId.Name = "lblProdId";
            this.lblProdId.Size = new System.Drawing.Size(130, 13);
            this.lblProdId.TabIndex = 2;
            this.lblProdId.Text = "CÓDIGO DE BARRAS / ID";

            // 
            // txtProdId
            // 
            this.txtProdId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProdId.BackColor = System.Drawing.Color.White;
            this.txtProdId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdId.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtProdId.Location = new System.Drawing.Point(20, 93);
            this.txtProdId.Name = "txtProdId";
            this.txtProdId.Size = new System.Drawing.Size(256, 27);
            this.txtProdId.TabIndex = 3;

            // 
            // lblProdNombre
            // 
            this.lblProdNombre.AutoSize = true;
            this.lblProdNombre.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblProdNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblProdNombre.Location = new System.Drawing.Point(20, 132);
            this.lblProdNombre.Name = "lblProdNombre";
            this.lblProdNombre.Size = new System.Drawing.Size(130, 13);
            this.lblProdNombre.TabIndex = 4;
            this.lblProdNombre.Text = "NOMBRE DEL ARTÍCULO";

            // 
            // txtProdNombre
            // 
            this.txtProdNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProdNombre.BackColor = System.Drawing.Color.White;
            this.txtProdNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdNombre.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtProdNombre.Location = new System.Drawing.Point(20, 150);
            this.txtProdNombre.Name = "txtProdNombre";
            this.txtProdNombre.Size = new System.Drawing.Size(256, 27);
            this.txtProdNombre.TabIndex = 5;

            // 
            // lblProdPrecio
            // 
            this.lblProdPrecio.AutoSize = true;
            this.lblProdPrecio.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblProdPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblProdPrecio.Location = new System.Drawing.Point(20, 190);
            this.lblProdPrecio.Name = "lblProdPrecio";
            this.lblProdPrecio.Size = new System.Drawing.Size(122, 13);
            this.lblProdPrecio.TabIndex = 6;
            this.lblProdPrecio.Text = "PRECIO UNITARIO ($)";

            // 
            // txtProdPrecio
            // 
            this.txtProdPrecio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProdPrecio.BackColor = System.Drawing.Color.White;
            this.txtProdPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdPrecio.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtProdPrecio.Location = new System.Drawing.Point(20, 208);
            this.txtProdPrecio.Name = "txtProdPrecio";
            this.txtProdPrecio.Size = new System.Drawing.Size(256, 27);
            this.txtProdPrecio.TabIndex = 7;

            // 
            // lblProdCantidad
            // 
            this.lblProdCantidad.AutoSize = true;
            this.lblProdCantidad.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblProdCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblProdCantidad.Location = new System.Drawing.Point(20, 248);
            this.lblProdCantidad.Name = "lblProdCantidad";
            this.lblProdCantidad.Size = new System.Drawing.Size(116, 13);
            this.lblProdCantidad.TabIndex = 8;
            this.lblProdCantidad.Text = "CANTIDAD EN STOCK";

            // 
            // txtProdCantidad
            // 
            this.txtProdCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProdCantidad.BackColor = System.Drawing.Color.White;
            this.txtProdCantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProdCantidad.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtProdCantidad.Location = new System.Drawing.Point(20, 266);
            this.txtProdCantidad.Name = "txtProdCantidad";
            this.txtProdCantidad.Size = new System.Drawing.Size(256, 27);
            this.txtProdCantidad.TabIndex = 9;

            // 
            // tblProdBotones (Botonera Responsiva: 2 Columnas x 2 Filas al 50% con Ajuste Proporcional)
            // 
            this.tblProdBotones.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblProdBotones.ColumnCount = 2;
            this.tblProdBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblProdBotones.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblProdBotones.Controls.Add(this.btnProdGuardar, 0, 0);
            this.tblProdBotones.Controls.Add(this.btnProdEditar, 1, 0);
            this.tblProdBotones.Controls.Add(this.btnProdEliminar, 0, 1);
            this.tblProdBotones.Controls.Add(this.btnProdLimpiar, 1, 1);
            this.tblProdBotones.Location = new System.Drawing.Point(20, 312);
            this.tblProdBotones.Name = "tblProdBotones";
            this.tblProdBotones.RowCount = 2;
            this.tblProdBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblProdBotones.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblProdBotones.Size = new System.Drawing.Size(256, 96);
            this.tblProdBotones.TabIndex = 10;

            // 
            // btnProdGuardar (Botón Verde Esmeralda)
            // 
            this.btnProdGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnProdGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProdGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProdGuardar.FlatAppearance.BorderSize = 0;
            this.btnProdGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(150)))), ((int)(((byte)(105)))));
            this.btnProdGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(120)))), ((int)(((byte)(87)))));
            this.btnProdGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnProdGuardar.ForeColor = System.Drawing.Color.White;
            this.btnProdGuardar.Location = new System.Drawing.Point(0, 0);
            this.btnProdGuardar.Margin = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.btnProdGuardar.Name = "btnProdGuardar";
            this.btnProdGuardar.Size = new System.Drawing.Size(124, 44);
            this.btnProdGuardar.TabIndex = 0;
            this.btnProdGuardar.Text = "➕ Guardar";
            this.btnProdGuardar.UseVisualStyleBackColor = false;
            this.btnProdGuardar.Click += new System.EventHandler(this.btnProdGuardar_Click);

            // 
            // btnProdEditar (Botón Índigo)
            // 
            this.btnProdEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.btnProdEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProdEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProdEditar.FlatAppearance.BorderSize = 0;
            this.btnProdEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(56)))), ((int)(((byte)(202)))));
            this.btnProdEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(48)))), ((int)(((byte)(163)))));
            this.btnProdEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdEditar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnProdEditar.ForeColor = System.Drawing.Color.White;
            this.btnProdEditar.Location = new System.Drawing.Point(132, 0);
            this.btnProdEditar.Margin = new System.Windows.Forms.Padding(4, 0, 0, 4);
            this.btnProdEditar.Name = "btnProdEditar";
            this.btnProdEditar.Size = new System.Drawing.Size(124, 44);
            this.btnProdEditar.TabIndex = 1;
            this.btnProdEditar.Text = "✏️ Modificar";
            this.btnProdEditar.UseVisualStyleBackColor = false;
            this.btnProdEditar.Click += new System.EventHandler(this.btnProdEditar_Click);

            // 
            // btnProdEliminar (Botón Rosa/Rojo)
            // 
            this.btnProdEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnProdEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProdEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProdEliminar.FlatAppearance.BorderSize = 0;
            this.btnProdEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnProdEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnProdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnProdEliminar.ForeColor = System.Drawing.Color.White;
            this.btnProdEliminar.Location = new System.Drawing.Point(0, 52);
            this.btnProdEliminar.Margin = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.btnProdEliminar.Name = "btnProdEliminar";
            this.btnProdEliminar.Size = new System.Drawing.Size(124, 44);
            this.btnProdEliminar.TabIndex = 2;
            this.btnProdEliminar.Text = "🗑️ Eliminar";
            this.btnProdEliminar.UseVisualStyleBackColor = false;
            this.btnProdEliminar.Click += new System.EventHandler(this.btnProdEliminar_Click);

            // 
            // btnProdLimpiar (Botón Gris Suave)
            // 
            this.btnProdLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnProdLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProdLimpiar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProdLimpiar.FlatAppearance.BorderSize = 0;
            this.btnProdLimpiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnProdLimpiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnProdLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnProdLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnProdLimpiar.Location = new System.Drawing.Point(132, 52);
            this.btnProdLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 0, 0);
            this.btnProdLimpiar.Name = "btnProdLimpiar";
            this.btnProdLimpiar.Size = new System.Drawing.Size(124, 44);
            this.btnProdLimpiar.TabIndex = 3;
            this.btnProdLimpiar.Text = "🔄 Limpiar";
            this.btnProdLimpiar.UseVisualStyleBackColor = false;
            this.btnProdLimpiar.Click += new System.EventHandler(this.btnProdLimpiar_Click);

            // 
            // pnlGridContainer (Tarjeta de la Tabla)
            // 
            this.pnlGridContainer.BackColor = System.Drawing.Color.White;
            this.pnlGridContainer.Controls.Add(this.dgvProductos);
            this.pnlGridContainer.Controls.Add(this.pnlGridHeader);
            this.pnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridContainer.Location = new System.Drawing.Point(312, 0);
            this.pnlGridContainer.Margin = new System.Windows.Forms.Padding(0);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Padding = new System.Windows.Forms.Padding(16);
            this.pnlGridContainer.Size = new System.Drawing.Size(580, 572);
            this.pnlGridContainer.TabIndex = 1;

            // 
            // pnlGridHeader
            // 
            this.pnlGridHeader.Controls.Add(this.btnProdRefrescar);
            this.pnlGridHeader.Controls.Add(this.lblGridTitle);
            this.pnlGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridHeader.Location = new System.Drawing.Point(16, 16);
            this.pnlGridHeader.Name = "pnlGridHeader";
            this.pnlGridHeader.Size = new System.Drawing.Size(548, 40);
            this.pnlGridHeader.TabIndex = 0;
            // 
            // lblGridTitle
            // 
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblGridTitle.Location = new System.Drawing.Point(4, 8);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(209, 21);
            this.lblGridTitle.TabIndex = 0;
            this.lblGridTitle.Text = "Catálogo Disponible (GCP)";
            // 
            // btnProdRefrescar (Botón Responsivo Refrescar Catálogo)
            // 
            this.btnProdRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProdRefrescar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnProdRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProdRefrescar.FlatAppearance.BorderSize = 0;
            this.btnProdRefrescar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnProdRefrescar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnProdRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnProdRefrescar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnProdRefrescar.Location = new System.Drawing.Point(400, 4);
            this.btnProdRefrescar.Name = "btnProdRefrescar";
            this.btnProdRefrescar.Size = new System.Drawing.Size(140, 32);
            this.btnProdRefrescar.TabIndex = 1;
            this.btnProdRefrescar.Text = "🔄 Actualizar Tabla";
            this.btnProdRefrescar.UseVisualStyleBackColor = false;
            this.btnProdRefrescar.Click += new System.EventHandler(this.btnProdRefrescar_Click);

            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId,
                this.colNombre,
                this.colPrecio,
                this.colCantidad,
                this.colTotal
            });
            this.dgvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(16, 56);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowTemplate.Height = 40;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(548, 500);
            this.dgvProductos.TabIndex = 1;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);

            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.FillWeight = 50F;
            this.colId.HeaderText = "ID / Código";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;

            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "Nombre";
            this.colNombre.FillWeight = 130F;
            this.colNombre.HeaderText = "Nombre del Artículo";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;

            // 
            // colPrecio
            // 
            this.colPrecio.DataPropertyName = "Precio";
            this.colPrecio.FillWeight = 60F;
            this.colPrecio.HeaderText = "Precio Unit.";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;

            // 
            // colCantidad
            // 
            this.colCantidad.DataPropertyName = "Cantidad";
            this.colCantidad.FillWeight = 50F;
            this.colCantidad.HeaderText = "Stock";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;

            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.FillWeight = 60F;
            this.colTotal.HeaderText = "Valor Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;

            // 
            // FormCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(940, 620);
            this.Controls.Add(this.tblLayoutCatalogo);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "FormCatalogo";
            this.Padding = new System.Windows.Forms.Padding(24);
            this.Text = "Catálogo GCP";
            this.tblLayoutCatalogo.ResumeLayout(false);
            this.pnlFormProductos.ResumeLayout(false);
            this.pnlFormProductos.PerformLayout();
            this.tblProdBotones.ResumeLayout(false);
            this.pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.pnlGridHeader.ResumeLayout(false);
            this.pnlGridHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tblLayoutCatalogo;
        public System.Windows.Forms.Panel pnlFormProductos;
        public System.Windows.Forms.Label lblFormProdTitulo;
        public System.Windows.Forms.Label lblFormProdSub;
        public System.Windows.Forms.Label lblProdId;
        public System.Windows.Forms.TextBox txtProdId;
        public System.Windows.Forms.Label lblProdNombre;
        public System.Windows.Forms.TextBox txtProdNombre;
        public System.Windows.Forms.Label lblProdPrecio;
        public System.Windows.Forms.TextBox txtProdPrecio;
        public System.Windows.Forms.Label lblProdCantidad;
        public System.Windows.Forms.TextBox txtProdCantidad;
        public System.Windows.Forms.TableLayoutPanel tblProdBotones;
        public System.Windows.Forms.Button btnProdGuardar;
        public System.Windows.Forms.Button btnProdEditar;
        public System.Windows.Forms.Button btnProdEliminar;
        public System.Windows.Forms.Button btnProdLimpiar;
        public System.Windows.Forms.Panel pnlGridContainer;
        public System.Windows.Forms.Panel pnlGridHeader;
        public System.Windows.Forms.Label lblGridTitle;
        public System.Windows.Forms.Button btnProdRefrescar;
        public System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
    }
}
