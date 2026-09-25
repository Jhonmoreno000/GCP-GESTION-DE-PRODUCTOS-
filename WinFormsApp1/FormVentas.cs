using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ConfigurarEstilos();
            dgvCarrito.AutoGenerateColumns = false;
            dgvCarrito.DataSource = DatosGCP.Carrito;
            FormatearMoneda();
            ActualizarCombo();
            CalcularTotal();
        }

        private void ConfigurarEstilos()
        {
            // Bordes suaves y limpios sin bucles de repintado
            pnlFormVentas.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1.5f))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlFormVentas.Width - 1, pnlFormVentas.Height - 1);
                }
            };

            pnlGridContainer.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1.5f))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlGridContainer.Width - 1, pnlGridContainer.Height - 1);
                }
            };

            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.BorderStyle = BorderStyle.None;
            dgvCarrito.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCarrito.GridColor = Color.FromArgb(241, 245, 249);
            dgvCarrito.DefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 242, 255);
            dgvCarrito.DefaultCellStyle.SelectionForeColor = Color.FromArgb(79, 70, 229);
            dgvCarrito.DefaultCellStyle.BackColor = Color.White;
            dgvCarrito.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvCarrito.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvCarrito.DefaultCellStyle.Padding = new Padding(8);
            
            dgvCarrito.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCarrito.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvCarrito.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCarrito.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvCarrito.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            dgvCarrito.EnableHeadersVisualStyles = false;
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.RowTemplate.Height = 44;
        }

        private void FormatearMoneda()
        {
            if (dgvCarrito.Columns["Precio"] != null) dgvCarrito.Columns["Precio"]!.DefaultCellStyle.Format = "C2";
            if (dgvCarrito.Columns["Subtotal"] != null) dgvCarrito.Columns["Subtotal"]!.DefaultCellStyle.Format = "C2";
        }

        public void ActualizarCombo()
        {
            cbxVentaProd.DataSource = null;
            var disponibles = DatosGCP.Productos.Where(p => p.Cantidad > 0).ToList();
            if (disponibles.Count > 0)
            {
                cbxVentaProd.DataSource = disponibles;
                cbxVentaProd.DisplayMember = "Nombre";
                cbxVentaProd.ValueMember = "Id";
            }
        }

        private void btnVentaAdd_Click(object sender, EventArgs e)
        {
            if (cbxVentaProd.SelectedItem is Producto prod)
            {
                if (int.TryParse(txtVentaCant.Text.Trim(), out int cant) && cant > 0)
                {
                    var existente = DatosGCP.Carrito.FirstOrDefault(i => i.IdProducto == prod.Id);
                    int yaEnCarrito = existente != null ? existente.Cantidad : 0;

                    if (yaEnCarrito + cant > prod.Cantidad)
                    {
                        MessageBox.Show($"Stock insuficiente en bodega. Solo quedan {prod.Cantidad} unidades.", "Alerta Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (existente != null)
                    {
                        existente.Cantidad += cant;
                    }
                    else
                    {
                        DatosGCP.Carrito.Add(new ItemCarrito
                        {
                            IdProducto = prod.Id,
                            Nombre = prod.Nombre,
                            Precio = prod.Precio,
                            Cantidad = cant
                        });
                    }

                    DatosGCP.Carrito.ResetBindings();
                    CalcularTotal();
                    txtVentaCant.Clear();
                    txtVentaCant.Focus();
                }
                else
                {
                    MessageBox.Show("Ingresa una cantidad mayor a 0.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un producto disponible del menú desplegable.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CalcularTotal()
        {
            decimal total = DatosGCP.Carrito.Sum(i => i.Subtotal);
            lblVentaTotalVal.Text = total.ToString("C");
        }

        private void btnVentaCobrar_Click(object sender, EventArgs e)
        {
            if (DatosGCP.Carrito.Count == 0)
            {
                MessageBox.Show("La canasta de venta está vacía. Añade artículos antes de cobrar.", "Canasta Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Descontar inventario automáticamente
            foreach (var item in DatosGCP.Carrito)
            {
                var prod = DatosGCP.Productos.FirstOrDefault(p => p.Id == item.IdProducto);
                if (prod != null)
                {
                    prod.Cantidad -= item.Cantidad;
                }
            }
            DatosGCP.Productos.ResetBindings();

            // Registrar Venta en Historial GCP
            Venta nuevaVenta = new Venta
            {
                Id = DatosGCP.Ventas.Count + 1,
                Fecha = DateTime.Now,
                ArticulosVendidos = DatosGCP.Carrito.Sum(i => i.Cantidad),
                Total = DatosGCP.Carrito.Sum(i => i.Subtotal)
            };
            DatosGCP.Ventas.Add(nuevaVenta);

            DatosGCP.Carrito.Clear();
            CalcularTotal();
            ActualizarCombo();

            MessageBox.Show($"✅ ¡Cobro procesado exitosamente por GCP!\nVenta #{nuevaVenta.Id} por un total de {nuevaVenta.Total:C}.", "Cobro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
