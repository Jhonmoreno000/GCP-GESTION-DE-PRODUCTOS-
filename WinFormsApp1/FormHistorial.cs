using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormHistorial : Form
    {
        public FormHistorial()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ConfigurarEstilos();
            dgvHistorial.AutoGenerateColumns = false;
            dgvHistorial.DataSource = DatosGCP.Ventas;
            FormatearMoneda();
        }

        private void ConfigurarEstilos()
        {
            pnlContainer.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1.5f))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, pnlContainer.Width - 1, pnlContainer.Height - 1);
                }
            };

            dgvHistorial.BackgroundColor = Color.White;
            dgvHistorial.BorderStyle = BorderStyle.None;
            dgvHistorial.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistorial.GridColor = Color.FromArgb(241, 245, 249);
            dgvHistorial.DefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 242, 255);
            dgvHistorial.DefaultCellStyle.SelectionForeColor = Color.FromArgb(79, 70, 229);
            dgvHistorial.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvHistorial.DefaultCellStyle.Padding = new Padding(8);
            dgvHistorial.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHistorial.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
            dgvHistorial.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHistorial.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvHistorial.ColumnHeadersDefaultCellStyle.Padding = new Padding(8);
            dgvHistorial.EnableHeadersVisualStyles = false;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.RowTemplate.Height = 44;
        }

        private void FormatearMoneda()
        {
            if (dgvHistorial.Columns["Total"] != null) dgvHistorial.Columns["Total"]!.DefaultCellStyle.Format = "C2";
            if (dgvHistorial.Columns["Fecha"] != null) dgvHistorial.Columns["Fecha"]!.DefaultCellStyle.Format = "g";
        }
    }
}
