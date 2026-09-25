using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormDashboard : Form
    {
        private int progresoAnimacion = 0;

        public FormDashboard()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AplicarEstilosDashboard();
            ActualizarMetricas();
            progresoAnimacion = 0;
            tmrAnimacion.Start();
        }

        private void AplicarEstilosDashboard()
        {
            pnlCardIngresos.Paint += (s, e) => DibujarBordeTarjeta(pnlCardIngresos, e);
            pnlCardVentas.Paint += (s, e) => DibujarBordeTarjeta(pnlCardVentas, e);
            pnlCardStockTotal.Paint += (s, e) => DibujarBordeTarjeta(pnlCardStockTotal, e);
            pnlCardAlertas.Paint += (s, e) => DibujarBordeTarjeta(pnlCardAlertas, e);

            HabilitarDobleBuffer(pnlChartBarras);
            HabilitarDobleBuffer(pnlChartDonut);
        }

        private void HabilitarDobleBuffer(Control control)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void DibujarBordeTarjeta(Panel pnl, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1.5f))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, pnl.Width - 1, pnl.Height - 1);
            }
        }

        public void ActualizarMetricas()
        {
            int ventasHoy = DatosGCP.Ventas.Count(v => v.Fecha.Date == DateTime.Today);
            decimal ingresosHoy = DatosGCP.Ventas.Where(v => v.Fecha.Date == DateTime.Today).Sum(v => v.Total);
            int stockCritico = DatosGCP.Productos.Count(p => p.Cantidad <= 5);

            lblCardIngresosVal.Text = ingresosHoy.ToString("C");
            lblCardVentasVal.Text = ventasHoy.ToString();
            lblCardStockVal.Text = DatosGCP.Productos.Count.ToString();
            lblCardAlertasVal.Text = stockCritico.ToString();
        }

        public void tmrAnimacion_Tick(object sender, EventArgs e)
        {
            progresoAnimacion += 5;
            if (progresoAnimacion >= 100)
            {
                progresoAnimacion = 100;
                tmrAnimacion.Stop();
            }
            pnlChartBarras.Invalidate();
            pnlChartDonut.Invalidate();
        }

        // ======================= GRÁFICA 1: BARRAS CON GRADIENTES Y LÍNEA DE ALERTA =======================
        public void pnlChartBarras_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Borde sutil del contenedor
                using (Pen pBorder = new Pen(Color.FromArgb(226, 232, 240), 1.5f))
                {
                    g.DrawRectangle(pBorder, 0, 0, pnlChartBarras.Width - 1, pnlChartBarras.Height - 1);
                }

                int chartLeft = 55;
                int chartRight = pnlChartBarras.Width - 30;
                int chartTop = 85;
                int chartBottom = pnlChartBarras.Height - 50;
                int chartHeight = chartBottom - chartTop;
                int chartWidth = chartRight - chartLeft;

                if (chartWidth <= 0 || chartHeight <= 0) return;

                bool esDiseno = DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;
                int anim = esDiseno ? 100 : progresoAnimacion;

                if (DatosGCP.Productos.Count == 0)
                {
                    using (Font fEmpty = new Font("Segoe UI", 10.5F, FontStyle.Regular))
                    using (SolidBrush bEmpty = new SolidBrush(Color.FromArgb(148, 163, 184)))
                    {
                        string msg = "No hay productos registrados en el catálogo aún.";
                        SizeF s = g.MeasureString(msg, fEmpty);
                        g.DrawString(msg, fEmpty, bEmpty, (pnlChartBarras.Width - s.Width) / 2, chartTop + chartHeight / 2);
                    }
                    return;
                }

                var top = DatosGCP.Productos.OrderByDescending(p => p.Cantidad).Take(6).ToList();
                int maxStock = top.Max(p => p.Cantidad);
                if (maxStock < 20) maxStock = 20;
                else maxStock = ((maxStock / 10) + 1) * 10;

                // Guías horizontales y escala Y
                int steps = 4;
                using (Pen gridPen = new Pen(Color.FromArgb(241, 245, 249), 1f))
                using (Font fAxis = new Font("Segoe UI", 8F))
                using (SolidBrush bAxis = new SolidBrush(Color.FromArgb(148, 163, 184)))
                {
                    for (int s = 0; s <= steps; s++)
                    {
                        float ratio = (float)s / steps;
                        int y = chartBottom - (int)(ratio * chartHeight);
                        int val = (int)(ratio * maxStock);

                        if (s > 0)
                        {
                            g.DrawLine(gridPen, chartLeft, y, chartRight, y);
                        }
                        string strVal = $"{val} u";
                        SizeF sz = g.MeasureString(strVal, fAxis);
                        g.DrawString(strVal, fAxis, bAxis, chartLeft - sz.Width - 6, y - sz.Height / 2);
                    }
                }

                // Línea de umbral de seguridad / Stock Crítico (5 unidades)
                if (5 <= maxStock)
                {
                    float alertRatio = 5f / maxStock;
                    int alertY = chartBottom - (int)(alertRatio * chartHeight);
                    using (Pen alertPen = new Pen(Color.FromArgb(244, 63, 94), 1.5f) { DashStyle = DashStyle.Dash })
                    {
                        g.DrawLine(alertPen, chartLeft, alertY, chartRight, alertY);
                    }
                    using (Font fAlert = new Font("Segoe UI", 7.5F, FontStyle.Bold))
                    using (SolidBrush bAlert = new SolidBrush(Color.FromArgb(244, 63, 94)))
                    {
                        string alertText = "⚠️ Límite Alerta (5 u.)";
                        SizeF szAlert = g.MeasureString(alertText, fAlert);
                        g.DrawString(alertText, fAlert, bAlert, chartRight - szAlert.Width, alertY - szAlert.Height - 2);
                    }
                }

                // Eje base X
                using (Pen basePen = new Pen(Color.FromArgb(203, 213, 225), 1.5f))
                {
                    g.DrawLine(basePen, chartLeft, chartBottom, chartRight, chartBottom);
                }

                // Dibujo de columnas de stock
                int count = top.Count;
                float slotWidth = (float)chartWidth / count;
                int barW = Math.Min(60, Math.Max(28, (int)(slotWidth * 0.52f)));

                for (int i = 0; i < count; i++)
                {
                    var prod = top[i];
                    float barCenter = chartLeft + (i + 0.5f) * slotWidth;
                    int barX = (int)(barCenter - barW / 2f);

                    int targetH = (int)(((float)prod.Cantidad / maxStock) * chartHeight);
                    int currentH = (int)(targetH * (anim / 100f));
                    if (currentH < 4 && prod.Cantidad > 0) currentH = 4;
                    int barY = chartBottom - currentH;

                    Color cTop = prod.Cantidad <= 5 ? Color.FromArgb(244, 63, 94) : Color.FromArgb(99, 102, 241);
                    Color cBottom = prod.Cantidad <= 5 ? Color.FromArgb(190, 18, 60) : Color.FromArgb(67, 56, 202);

                    if (currentH > 2)
                    {
                        using (GraphicsPath path = new GraphicsPath())
                        {
                            int r = Math.Min(8, barW / 2);
                            path.AddArc(barX, barY, r * 2, r * 2, 180, 90);
                            path.AddArc(barX + barW - r * 2, barY, r * 2, r * 2, 270, 90);
                            path.AddLine(barX + barW, chartBottom, barX + barW, chartBottom);
                            path.AddLine(barX, chartBottom, barX, chartBottom);
                            path.CloseFigure();

                            using (LinearGradientBrush lgb = new LinearGradientBrush(new Rectangle(barX, barY, barW, Math.Max(1, currentH)), cTop, cBottom, LinearGradientMode.Vertical))
                            {
                                g.FillPath(lgb, path);
                            }
                        }
                    }

                    if (anim >= 70)
                    {
                        // Placa superior con valor
                        using (Font fValor = new Font("Segoe UI", 9F, FontStyle.Bold))
                        {
                            string valText = $"{prod.Cantidad} u.";
                            SizeF szVal = g.MeasureString(valText, fValor);
                            int pillW = (int)szVal.Width + 10;
                            int pillH = (int)szVal.Height + 4;
                            int pillX = (int)barCenter - pillW / 2;
                            int pillY = barY - pillH - 4;
                            if (pillY < chartTop - 12) pillY = chartTop - 12;

                            using (GraphicsPath pill = GetRoundedRect(new Rectangle(pillX, pillY, pillW, pillH), 4))
                            using (SolidBrush pillBg = new SolidBrush(Color.FromArgb(241, 245, 249)))
                            using (Pen pillBorder = new Pen(Color.FromArgb(226, 232, 240), 1f))
                            {
                                g.FillPath(pillBg, pill);
                                g.DrawPath(pillBorder, pill);
                            }
                            using (SolidBrush bVal = new SolidBrush(Color.FromArgb(15, 23, 42)))
                            {
                                g.DrawString(valText, fValor, bVal, pillX + 5, pillY + 2);
                            }
                        }

                        // Etiqueta inferior con nombre del producto
                        using (Font fNombre = new Font("Segoe UI", 8.5F, FontStyle.Regular))
                        using (SolidBrush bNom = new SolidBrush(Color.FromArgb(71, 85, 105)))
                        {
                            string nombreCorto = prod.Nombre.Length > 10 ? prod.Nombre.Substring(0, 9) + ".." : prod.Nombre;
                            SizeF szNom = g.MeasureString(nombreCorto, fNombre);
                            g.DrawString(nombreCorto, fNombre, bNom, barCenter - szNom.Width / 2, chartBottom + 10);
                        }
                    }
                }
            }
            catch
            {
                // Manejo seguro para tiempo de diseño en Visual Studio
            }
        }

        // ======================= GRÁFICA 2: DONUT CIRCULAR DE SALUD DEL CATÁLOGO =======================
        public void pnlChartDonut_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Borde sutil del contenedor
                using (Pen pBorder = new Pen(Color.FromArgb(226, 232, 240), 1.5f))
                {
                    g.DrawRectangle(pBorder, 0, 0, pnlChartDonut.Width - 1, pnlChartDonut.Height - 1);
                }

                int total = DatosGCP.Productos.Count;
                int countOptimo = DatosGCP.Productos.Count(p => p.Cantidad > 15);
                int countMedio = DatosGCP.Productos.Count(p => p.Cantidad > 5 && p.Cantidad <= 15);
                int countCritico = DatosGCP.Productos.Count(p => p.Cantidad <= 5);

                int donutCenterX = pnlChartDonut.Width / 2;
                int donutCenterY = 175;
                int outerRadius = Math.Min(78, (pnlChartDonut.Width - 60) / 2);
                int innerRadius = (int)(outerRadius * 0.62f);

                bool esDiseno = DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;
                float anim = (esDiseno ? 100 : progresoAnimacion) / 100f;
                Rectangle outerRect = new Rectangle(donutCenterX - outerRadius, donutCenterY - outerRadius, outerRadius * 2, outerRadius * 2);
                Rectangle innerRect = new Rectangle(donutCenterX - innerRadius, donutCenterY - innerRadius, innerRadius * 2, innerRadius * 2);

                if (total == 0)
                {
                    using (SolidBrush b = new SolidBrush(Color.FromArgb(226, 232, 240)))
                    {
                        g.FillPie(b, outerRect, 0, 360);
                    }
                }
                else
                {
                    float startAngle = -90f;
                    float sweepOptimo = (countOptimo / (float)total) * 360f * anim;
                    float sweepMedio = (countMedio / (float)total) * 360f * anim;
                    float sweepCritico = (countCritico / (float)total) * 360f * anim;

                    if (sweepOptimo > 0)
                    {
                        using (SolidBrush b = new SolidBrush(Color.FromArgb(16, 185, 129)))
                        {
                            g.FillPie(b, outerRect, startAngle, sweepOptimo);
                        }
                        startAngle += sweepOptimo;
                    }
                    if (sweepMedio > 0)
                    {
                        using (SolidBrush b = new SolidBrush(Color.FromArgb(79, 70, 229)))
                        {
                            g.FillPie(b, outerRect, startAngle, sweepMedio);
                        }
                        startAngle += sweepMedio;
                    }
                    if (sweepCritico > 0)
                    {
                        using (SolidBrush b = new SolidBrush(Color.FromArgb(239, 68, 68)))
                        {
                            g.FillPie(b, outerRect, startAngle, sweepCritico);
                        }
                        startAngle += sweepCritico;
                    }
                }

                // Agujero central del Donut
                g.FillEllipse(Brushes.White, innerRect);
                using (Pen pInner = new Pen(Color.FromArgb(241, 245, 249), 2f))
                {
                    g.DrawEllipse(pInner, innerRect);
                }

                // Texto central (Total Productos)
                using (Font fCount = new Font("Segoe UI", 18F, FontStyle.Bold))
                using (SolidBrush bText = new SolidBrush(Color.FromArgb(15, 23, 42)))
                {
                    string totalStr = total.ToString();
                    SizeF s1 = g.MeasureString(totalStr, fCount);
                    g.DrawString(totalStr, fCount, bText, donutCenterX - s1.Width / 2, donutCenterY - s1.Height / 2 - 6);
                }
                using (Font fSub = new Font("Segoe UI", 7.5F, FontStyle.Bold))
                using (SolidBrush bSub = new SolidBrush(Color.FromArgb(148, 163, 184)))
                {
                    string subStr = "PRODUCTOS";
                    SizeF s2 = g.MeasureString(subStr, fSub);
                    g.DrawString(subStr, fSub, bSub, donutCenterX - s2.Width / 2, donutCenterY + 12);
                }

                // Leyenda moderna estructurada en tarjetas inferiores
                int legendStartY = donutCenterY + outerRadius + 28;
                int legendRowHeight = 44;
                int legendLeft = 24;
                int legendWidth = pnlChartDonut.Width - 48;

                if (legendWidth > 50)
                {
                    var legendItems = new[]
                    {
                        (Name: "Stock Óptimo (>15)", Count: countOptimo, Color: Color.FromArgb(16, 185, 129), Bg: Color.FromArgb(236, 253, 245)),
                        (Name: "Stock Medio (6-15)", Count: countMedio, Color: Color.FromArgb(79, 70, 229), Bg: Color.FromArgb(238, 242, 255)),
                        (Name: "Stock Crítico (≤5)", Count: countCritico, Color: Color.FromArgb(239, 68, 68), Bg: Color.FromArgb(254, 242, 242))
                    };

                    for (int i = 0; i < legendItems.Length; i++)
                    {
                        var item = legendItems[i];
                        int rowY = legendStartY + (i * legendRowHeight);
                        Rectangle cardRect = new Rectangle(legendLeft, rowY, legendWidth, 36);

                        using (GraphicsPath cardPath = GetRoundedRect(cardRect, 6))
                        using (SolidBrush cardBg = new SolidBrush(item.Bg))
                        {
                            g.FillPath(cardBg, cardPath);
                        }

                        // Punto indicador
                        using (SolidBrush dotBrush = new SolidBrush(item.Color))
                        {
                            g.FillEllipse(dotBrush, legendLeft + 12, rowY + 13, 10, 10);
                        }

                        // Título de la categoría
                        using (Font fLeg = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                        using (SolidBrush bLeg = new SolidBrush(Color.FromArgb(30, 41, 59)))
                        {
                            g.DrawString(item.Name, fLeg, bLeg, legendLeft + 30, rowY + 9);
                        }

                        // Cantidad y porcentaje
                        float pct = total > 0 ? (item.Count / (float)total) * 100f : 0f;
                        string statText = $"{item.Count}  ({pct:0.#}%)";
                        using (Font fStat = new Font("Segoe UI", 8.5F, FontStyle.Bold))
                        using (SolidBrush bStat = new SolidBrush(item.Color))
                        {
                            SizeF szStat = g.MeasureString(statText, fStat);
                            g.DrawString(statText, fStat, bStat, legendLeft + legendWidth - szStat.Width - 12, rowY + 9);
                        }
                    }
                }
            }
            catch
            {
                // Manejo seguro para tiempo de diseño en Visual Studio
            }
        }

        // ======================= HELPER: RECTÁNGULOS CON ESQUINAS REDONDEADAS =======================
        private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(bounds);
                return path;
            }
            int d = radius * 2;
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
