using System.Drawing.Drawing2D;

namespace WinFormsApp1.UI
{
    /// <summary>
    /// Proveedor de iconos vectoriales dibujados mediante GDI+ con anti-aliasing.
    /// Garantiza una nitidez perfecta en cualquier escala y elimina por completo los caracteres
    /// Unicode incompatibles (cajas cuadradas []) que fallan en Windows Forms.
    /// </summary>
    public static class VectorIconHelper
    {
        /// <summary>
        /// Dibuja un icono vectorial personalizado dentro del rectángulo especificado.
        /// </summary>
        /// <param name="g">Contexto de gráficos GDI+.</param>
        /// <param name="icono">Identificador del icono: 'dashboard', 'inventario', 'ventas', 'historial', 'caja', 'alerta', 'moneda', 'reporte', 'check', 'buscar'.</param>
        /// <param name="bounds">Límites donde se dibujará el icono.</param>
        /// <param name="color">Color principal del trazo o relleno.</param>
        public static void DibujarIcono(Graphics g, string icono, Rectangle bounds, Color color)
        {
            if (bounds.Width <= 0 || bounds.Height <= 0)
                return;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            int cx = bounds.X + bounds.Width / 2;
            int cy = bounds.Y + bounds.Height / 2;
            int size = Math.Min(bounds.Width, bounds.Height);
            if (size < 2)
                return;

            int half = size / 2;

            using var pen = new Pen(color, 2f) { StartCap = LineCap.Round, EndCap = LineCap.Round, LineJoin = LineJoin.Round };
            using var brush = new SolidBrush(color);

            switch (icono.ToLower())
            {
                case "dashboard":
                    // 4 cuadrículas modernas
                    int qs = size / 3;
                    g.DrawRectangle(pen, cx - qs - 2, cy - qs - 2, qs, qs);
                    g.DrawRectangle(pen, cx + 2, cy - qs - 2, qs, qs);
                    g.DrawRectangle(pen, cx - qs - 2, cy + 2, qs, qs);
                    g.FillRectangle(brush, cx + 2, cy + 2, qs, qs);
                    break;

                case "inventario":
                case "caja":
                    // Caja isométrica estilizada
                    int w = size * 7 / 10;
                    int h = size * 6 / 10;
                    var rectCaja = new Rectangle(cx - w / 2, cy - h / 2, w, h);
                    g.DrawRectangle(pen, rectCaja);
                    // Tapa y cinta
                    g.DrawLine(pen, rectCaja.Left, rectCaja.Top + 6, rectCaja.Right, rectCaja.Top + 6);
                    g.DrawLine(pen, cx, rectCaja.Top + 6, cx, rectCaja.Bottom);
                    break;

                case "alerta":
                    // Triángulo de advertencia con esquinas redondeadas y signo de exclamación
                    Point[] triangulo = {
                        new Point(cx, cy - half + 2),
                        new Point(cx + half - 2, cy + half - 2),
                        new Point(cx - half + 2, cy + half - 2)
                    };
                    g.DrawPolygon(pen, triangulo);
                    // Punto y línea de exclamación
                    g.DrawLine(pen, cx, cy - half / 3, cx, cy + 2);
                    g.FillEllipse(brush, cx - 1, cy + half / 2, 3, 3);
                    break;

                case "ventas":
                case "moneda":
                    // Moneda circular con signo de peso/dólar
                    int radioMoneda = size * 4 / 10;
                    g.DrawEllipse(pen, cx - radioMoneda, cy - radioMoneda, radioMoneda * 2, radioMoneda * 2);
                    using (var font = new Font("Segoe UI", size * 0.45f, FontStyle.Bold))
                    using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    {
                        g.DrawString("$", font, brush, cx, cy + 1, sf);
                    }
                    break;

                case "historial":
                case "reporte":
                    // Portapapeles con líneas de texto
                    int pw = size * 6 / 10;
                    int ph = size * 8 / 10;
                    var rectPapel = new Rectangle(cx - pw / 2, cy - ph / 2, pw, ph);
                    g.DrawRectangle(pen, rectPapel);
                    // Clip superior
                    g.DrawRectangle(pen, cx - 4, rectPapel.Top - 3, 8, 5);
                    // Líneas
                    g.DrawLine(pen, rectPapel.Left + 4, cy - 2, rectPapel.Right - 4, cy - 2);
                    g.DrawLine(pen, rectPapel.Left + 4, cy + 4, rectPapel.Right - 4, cy + 4);
                    g.DrawLine(pen, rectPapel.Left + 4, cy + 10, rectPapel.Right - 8, cy + 10);
                    break;

                case "check":
                    // Marca de verificación en círculo
                    int rc = size * 4 / 10;
                    g.DrawEllipse(pen, cx - rc, cy - rc, rc * 2, rc * 2);
                    g.DrawLine(pen, cx - 5, cy, cx - 1, cy + 4);
                    g.DrawLine(pen, cx - 1, cy + 4, cx + 5, cy - 3);
                    break;

                case "grafica":
                    // 3 Barras verticales crecientes
                    int bw = size / 6;
                    g.FillRectangle(brush, cx - bw * 2, cy + 1, bw, half - 2);
                    g.FillRectangle(brush, cx - bw / 2, cy - half / 3, bw, half + half / 3);
                    g.FillRectangle(brush, cx + bw, cy - half + 2, bw, size - 3);
                    break;

                case "target":
                case "dona":
                    // Anillo exterior y punto central
                    int rTarget = size * 4 / 10;
                    g.DrawEllipse(pen, cx - rTarget, cy - rTarget, rTarget * 2, rTarget * 2);
                    g.FillEllipse(brush, cx - 3, cy - 3, 6, 6);
                    break;

                default:
                    // Cuadrado con punto por defecto
                    g.DrawRectangle(pen, cx - half + 2, cy - half + 2, size - 4, size - 4);
                    break;
            }
        }
    }
}
