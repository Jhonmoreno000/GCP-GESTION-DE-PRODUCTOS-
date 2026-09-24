using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace WinFormsApp1.UI
{
    /// <summary>
    /// Modelo de datos para representar una barra individual dentro del control de gráficas.
    /// </summary>
    public class BarraDato
    {
        public string Etiqueta { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string ValorFormateado { get; set; } = string.Empty;
        public Color ColorBarra { get; set; } = Color.FromArgb(79, 70, 229);
        public string Subtexto { get; set; } = string.Empty;
    }

    /// <summary>
    /// Panel contenedor moderno con bordes redondeados, borde sutil y efecto hover reactivo.
    /// </summary>
    public class TarjetaModerna : Panel
    {
        private int _radioBorde = 14;
        private Color _colorBorde = Color.FromArgb(226, 232, 240);
        private Color _colorFondo = Color.White;
        private bool _isHovered = false;
        private bool _habilitarEfectoHover = true;

        public int RadioBorde
        {
            get => _radioBorde;
            set { _radioBorde = value; Invalidate(); }
        }

        public Color ColorBorde
        {
            get => _colorBorde;
            set { _colorBorde = value; Invalidate(); }
        }

        public bool HabilitarEfectoHover
        {
            get => _habilitarEfectoHover;
            set => _habilitarEfectoHover = value;
        }

        public TarjetaModerna()
        {
            // Habilita doble búfer para evitar parpadeos visuales en animaciones y redibujado
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.Transparent;
            this.Padding = new Padding(16);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (_habilitarEfectoHover)
            {
                _isHovered = true;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (_habilitarEfectoHover)
            {
                _isHovered = false;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using var path = CrearPathRectanguloRedondeado(rect, _radioBorde);

            // Relleno de la tarjeta
            using var brushFondo = new SolidBrush(_colorFondo);
            g.FillPath(brushFondo, path);

            // Borde con efecto hover interactivo (se ilumina sutilmente al pasar el mouse)
            Color colorBordeActual = _isHovered ? Color.FromArgb(99, 102, 241) : _colorBorde;
            int grosorBorde = _isHovered ? 2 : 1;
            using var penBorde = new Pen(colorBordeActual, grosorBorde);
            g.DrawPath(penBorde, path);
        }

        /// <summary>
        /// Genera un GraphicsPath con esquinas redondeadas para cualquier rectángulo dado.
        /// </summary>
        public static GraphicsPath CrearPathRectanguloRedondeado(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            var path = new GraphicsPath();

            if (radius <= 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

            // Esquina superior izquierda
            path.AddArc(arc, 180, 90);

            // Esquina superior derecha
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Esquina inferior derecha
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Esquina inferior izquierda
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }

    /// <summary>
    /// Control personalizado que dibuja una gráfica de barras horizontales moderna con animación fluida de entrada.
    /// </summary>
    public class GraficaBarrasModerna : UserControl
    {
        private readonly List<BarraDato> _datos = new();
        private System.Windows.Forms.Timer? _timerAnimacion;
        private float _progreso = 0f;
        public string Titulo { get; set; } = "Métricas por Categoría";
        public string Subtitulo { get; set; } = "Distribución y valor en inventario";

        public GraficaBarrasModerna()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;
            this.Padding = new Padding(15);
        }

        /// <summary>
        /// Asigna nuevos datos y dispara la animación de crecimiento de las barras.
        /// </summary>
        public void CargarDatos(List<BarraDato> nuevosDatos)
        {
            _datos.Clear();
            _datos.AddRange(nuevosDatos);
            IniciarAnimacion();
        }

        /// <summary>
        /// Inicia un temporizador a 60 FPS que incrementa suavemente las barras con efecto de desaceleración (Ease-Out).
        /// </summary>
        public void IniciarAnimacion()
        {
            _progreso = 0f;
            _timerAnimacion?.Stop();
            _timerAnimacion?.Dispose();

            _timerAnimacion = new System.Windows.Forms.Timer { Interval = 16 }; // ~60 fotogramas por segundo
            _timerAnimacion.Tick += (s, e) =>
            {
                _progreso += 0.05f;
                if (_progreso >= 1f)
                {
                    _progreso = 1f;
                    _timerAnimacion.Stop();
                }
                Invalidate();
            };
            _timerAnimacion.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // 1. Título y Subtítulo de la Gráfica
            using var fontTitulo = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            using var fontSubtitulo = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            using var brushTextoPrincipal = new SolidBrush(Color.FromArgb(15, 23, 42));
            using var brushTextoMuted = new SolidBrush(Color.FromArgb(100, 116, 139));

            g.DrawString(Titulo, fontTitulo, brushTextoPrincipal, 15, 12);
            g.DrawString(Subtitulo, fontSubtitulo, brushTextoMuted, 15, 34);

            if (_datos.Count == 0)
            {
                g.DrawString("No hay datos disponibles para graficar.", fontSubtitulo, brushTextoMuted, 15, 70);
                return;
            }

            // 2. Cálculo del valor máximo para la escala porcentual
            decimal maxValor = _datos.Max(d => d.Valor);
            if (maxValor <= 0) maxValor = 1;

            // Función de suavizado cúbico para la animación (Ease-Out Cubic)
            float factorSuavizado = 1f - (float)Math.Pow(1f - _progreso, 3);

            int yActual = 65;
            int altoBarra = 14;
            int margenInferior = 36;
            int anchoTotalArea = Width - 30;
            int anchoEtiqueta = 110;
            int anchoValor = 110;
            int anchoPista = Math.Max(50, anchoTotalArea - anchoEtiqueta - anchoValor);

            using var fontEtiqueta = new Font("Segoe UI", 9F, FontStyle.Bold);
            using var fontValor = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            using var brushPista = new SolidBrush(Color.FromArgb(241, 245, 249));

            foreach (var item in _datos)
            {
                // Etiqueta a la izquierda
                g.DrawString(item.Etiqueta, fontEtiqueta, brushTextoPrincipal, 15, yActual - 2);

                // Pista de fondo gris redondeada
                int xPista = 15 + anchoEtiqueta;
                var rectPista = new Rectangle(xPista, yActual + 1, anchoPista, altoBarra);
                using var pathPista = TarjetaModerna.CrearPathRectanguloRedondeado(rectPista, altoBarra / 2);
                g.FillPath(brushPista, pathPista);

                // Barra de color animada
                float porcentaje = (float)(item.Valor / maxValor);
                int anchoBarraActual = (int)(anchoPista * porcentaje * factorSuavizado);
                if (anchoBarraActual > 4)
                {
                    var rectBarra = new Rectangle(xPista, yActual + 1, anchoBarraActual, altoBarra);
                    using var pathBarra = TarjetaModerna.CrearPathRectanguloRedondeado(rectBarra, altoBarra / 2);
                    using var brushBarra = new LinearGradientBrush(rectBarra, item.ColorBarra, ControlPaint.Light(item.ColorBarra, 0.2f), LinearGradientMode.Horizontal);
                    g.FillPath(brushBarra, pathBarra);
                }

                // Valor numérico a la derecha
                string textoMostrar = string.IsNullOrEmpty(item.ValorFormateado) ? item.Valor.ToString("N0") : item.ValorFormateado;
                g.DrawString(textoMostrar, fontValor, brushTextoMuted, xPista + anchoPista + 12, yActual - 1);

                yActual += margenInferior;
            }
        }
    }

    /// <summary>
    /// Gráfica circular estilo Dona (Donut Ring Chart) moderna con animación para indicar la salud y porcentaje del inventario.
    /// </summary>
    public class GraficaDonaProgreso : UserControl
    {
        private float _progreso = 0f;
        private float _porcentajeOptimo = 85f;
        private System.Windows.Forms.Timer? _timer;

        public string Titulo { get; set; } = "Salud del Catálogo";
        public float PorcentajeOptimo
        {
            get => _porcentajeOptimo;
            set
            {
                _porcentajeOptimo = Math.Clamp(value, 0f, 100f);
                IniciarAnimacion();
            }
        }

        public GraficaDonaProgreso()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;
            this.Padding = new Padding(15);
        }

        public void IniciarAnimacion()
        {
            _progreso = 0f;
            _timer?.Stop();
            _timer?.Dispose();

            _timer = new System.Windows.Forms.Timer { Interval = 16 };
            _timer.Tick += (s, e) =>
            {
                _progreso += 0.05f;
                if (_progreso >= 1f)
                {
                    _progreso = 1f;
                    _timer.Stop();
                }
                Invalidate();
            };
            _timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // Título
            using var fontTitulo = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            using var fontSubtitulo = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            using var brushTitulo = new SolidBrush(Color.FromArgb(15, 23, 42));
            using var brushMuted = new SolidBrush(Color.FromArgb(100, 116, 139));

            g.DrawString(Titulo, fontTitulo, brushTitulo, 15, 12);
            g.DrawString("Porcentaje de productos con stock suficiente", fontSubtitulo, brushMuted, 15, 34);

            // Dimensiones del anillo de la dona
            int radioExterior = Math.Min(Width - 60, Height - 130);
            if (radioExterior <= 20) radioExterior = 20;

            int centroX = Width / 2;
            int centroY = 65 + radioExterior / 2;
            int grosorAnillo = 16;

            var rectAnillo = new Rectangle(centroX - radioExterior / 2, centroY - radioExterior / 2, radioExterior, radioExterior);

            // Anillo base gris (Stock en riesgo o bajo)
            using var penBase = new Pen(Color.FromArgb(254, 226, 226), grosorAnillo) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            g.DrawArc(penBase, rectAnillo, 0, 360);

            // Arco activo verde / esmeralda animado (Stock Saludable)
            float factorSuavizado = 1f - (float)Math.Pow(1f - _progreso, 3);
            float sweepAngle = (_porcentajeOptimo / 100f) * 360f * factorSuavizado;

            if (sweepAngle > 0)
            {
                using var penProgreso = new Pen(Color.FromArgb(16, 185, 129), grosorAnillo) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                g.DrawArc(penProgreso, rectAnillo, -90, sweepAngle);
            }

            // Texto central con el porcentaje grande
            int valorMostrar = (int)(_porcentajeOptimo * factorSuavizado);
            using var fontPorcentaje = new Font("Segoe UI", 20F, FontStyle.Bold);
            using var fontEstado = new Font("Segoe UI", 8F, FontStyle.Bold);

            string textoPorcentaje = $"{valorMostrar}%";
            var tamPorcentaje = g.MeasureString(textoPorcentaje, fontPorcentaje);
            g.DrawString(textoPorcentaje, fontPorcentaje, brushTitulo, centroX - (tamPorcentaje.Width / 2), centroY - (tamPorcentaje.Height / 2) - 6);

            string textoEstado = valorMostrar >= 70 ? "ÓPTIMO" : "ALERTA";
            Color colorEstado = valorMostrar >= 70 ? Color.FromArgb(16, 185, 129) : Color.FromArgb(239, 68, 68);
            using var brushEstado = new SolidBrush(colorEstado);
            var tamEstado = g.MeasureString(textoEstado, fontEstado);
            g.DrawString(textoEstado, fontEstado, brushEstado, centroX - (tamEstado.Width / 2), centroY + 14);

            // Leyendas inferiores
            int yLeyenda = centroY + (radioExterior / 2) + 20;
            DibujarPuntoLeyenda(g, 25, yLeyenda, Color.FromArgb(16, 185, 129), "Stock Saludable");
            DibujarPuntoLeyenda(g, Width / 2 + 10, yLeyenda, Color.FromArgb(239, 68, 68), "Stock Crítico");
        }

        private void DibujarPuntoLeyenda(Graphics g, int x, int y, Color color, string texto)
        {
            using var brushPunto = new SolidBrush(color);
            using var font = new Font("Segoe UI", 8F, FontStyle.Regular);
            using var brushTexto = new SolidBrush(Color.FromArgb(100, 116, 139));

            g.FillEllipse(brushPunto, x, y + 2, 9, 9);
            g.DrawString(texto, font, brushTexto, x + 15, y);
        }
    }

    /// <summary>
    /// Botón moderno con bordes redondeados, degradados suaves y efectos hover/click interactivos.
    /// </summary>
    public class BotonModerno : Button
    {
        private int _radioBorde = 10;
        private Color _colorNormal = Color.FromArgb(79, 70, 229);
        private Color _colorHover = Color.FromArgb(67, 56, 202);
        private Color _colorClick = Color.FromArgb(55, 48, 163);
        private bool _isHover = false;
        private bool _isClick = false;

        public int RadioBorde
        {
            get => _radioBorde;
            set { _radioBorde = value; Invalidate(); }
        }

        public Color ColorNormal
        {
            get => _colorNormal;
            set
            {
                _colorNormal = value;
                _colorHover = ControlPaint.Dark(value, 0.1f);
                _colorClick = ControlPaint.Dark(value, 0.2f);
                Invalidate();
            }
        }

        public BotonModerno()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
            this.Size = new Size(130, 40);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHover = false;
            _isClick = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            _isClick = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _isClick = false;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            var g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using var path = TarjetaModerna.CrearPathRectanguloRedondeado(rect, _radioBorde);

            Color colorActual = _isClick ? _colorClick : (_isHover ? _colorHover : _colorNormal);
            using var brushFondo = new SolidBrush(colorActual);
            g.FillPath(brushFondo, path);

            // Dibujar texto centrado
            using var brushTexto = new SolidBrush(ForeColor);
            using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(Text, Font, brushTexto, rect, sf);
        }
    }
}
