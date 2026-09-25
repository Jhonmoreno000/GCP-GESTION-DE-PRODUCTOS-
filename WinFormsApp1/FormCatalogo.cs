using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormCatalogo : Form
    {
        public FormCatalogo()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ConfigurarEstilos();
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = DatosGCP.Productos;
            FormatearMoneda();
        }

        private void ConfigurarEstilos()
        {
            // Borde sutil y elegante para la tarjeta del formulario sin bucles infinitos de repintado
            pnlFormProductos.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1.5f))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlFormProductos.Width - 1, pnlFormProductos.Height - 1);
                }
            };

            pnlGridContainer.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1.5f))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlGridContainer.Width - 1, pnlGridContainer.Height - 1);
                }
            };

            // Estilos tabla moderna
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProductos.GridColor = Color.FromArgb(241, 245, 249);
            dgvProductos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 242, 255);
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(79, 70, 229);
            dgvProductos.DefaultCellStyle.BackColor = Color.White;
            dgvProductos.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvProductos.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvProductos.DefaultCellStyle.Padding = new Padding(8);
            
            dgvProductos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvProductos.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowTemplate.Height = 44;
        }

        private void FormatearMoneda()
        {
            if (dgvProductos.Columns["Precio"] != null) dgvProductos.Columns["Precio"]!.DefaultCellStyle.Format = "C2";
            if (dgvProductos.Columns["Total"] != null) dgvProductos.Columns["Total"]!.DefaultCellStyle.Format = "C2";
        }

        private void btnProdGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtProdId.Text.Trim());
                if (DatosGCP.Productos.Any(p => p.Id == id))
                {
                    MessageBox.Show("Ya existe un producto registrado con este ID en GCP.", "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DatosGCP.Productos.Add(new Producto
                {
                    Id = id,
                    Nombre = txtProdNombre.Text.Trim(),
                    Precio = decimal.Parse(txtProdPrecio.Text.Trim()),
                    Cantidad = int.Parse(txtProdCantidad.Text.Trim())
                });

                LimpiarFormulario();
                MessageBox.Show("Artículo guardado correctamente en el Catálogo GCP.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor ingresa números válidos en Código, Precio y Stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProdEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is Producto prod)
            {
                try
                {
                    prod.Id = int.Parse(txtProdId.Text.Trim());
                    prod.Nombre = txtProdNombre.Text.Trim();
                    prod.Precio = decimal.Parse(txtProdPrecio.Text.Trim());
                    prod.Cantidad = int.Parse(txtProdCantidad.Text.Trim());

                    DatosGCP.Productos.ResetBindings();
                    LimpiarFormulario();
                    MessageBox.Show("Producto actualizado en el Catálogo GCP.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Datos numéricos no válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila de la tabla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnProdEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is Producto prod)
            {
                if (MessageBox.Show($"¿Eliminar definitivamente '{prod.Nombre}'?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DatosGCP.Productos.Remove(prod);
                    LimpiarFormulario();
                }
            }
        }

        private void btnProdLimpiar_Click(object sender, EventArgs e) => LimpiarFormulario();

        private void LimpiarFormulario()
        {
            txtProdId.Clear();
            txtProdNombre.Clear();
            txtProdPrecio.Clear();
            txtProdCantidad.Clear();
            txtProdId.Focus();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow?.DataBoundItem is Producto prod)
            {
                txtProdId.Text = prod.Id.ToString();
                txtProdNombre.Text = prod.Nombre;
                txtProdPrecio.Text = prod.Precio.ToString("0.00");
                txtProdCantidad.Text = prod.Cantidad.ToString();
            }
        }
    }
}
