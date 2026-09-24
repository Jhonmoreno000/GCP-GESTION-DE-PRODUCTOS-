using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace WinFormsApp1.UI
{
    /// <summary>
    /// Modelo de datos para las barras de la gráfica por categoría.
    /// </summary>
    public class BarraDato
    {
        public string Etiqueta { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string ValorFormateado { get; set; } = string.Empty;
        public Color ColorInicio { get; set; } = Color.FromArgb(99, 102, 241);
        public Color ColorFin { get; set; } = Color.FromArgb(129, 140, 248);
    }

    /// <summary>
    /// Panel contenedor moderno con bordes redondeados y efecto hover interactivo.
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
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
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
            // Durante el primer layout algunos controles todavía pueden tener tamaño cero.
            // Evita pasar rectángulos negativos a GDI+, que termina lanzando
            // ArgumentException: "Parameter is not valid".
            if (Width <= 1 || Height <= 1)
                return;

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using var path = CrearPathRectanguloRedondeado(rect, _radioBorde);

            // Relleno de la superficie
            using var brushFondo = new SolidBrush(_colorFondo);
            g.FillPath(brushFondo, path);

            // Borde interactivo con iluminación suave al pasar el cursor
            Color colorBordeActual = _isHovered ? Color.FromArgb(99, 102, 241) : _colorBorde;
            int grosorBorde = _isHovered ? 2 : 1;
            using var penBorde = new Pen(colorBordeActual, grosorBorde);
            g.DrawPath(penBorde, path);
        }

        public static GraphicsPath CrearPathRectanguloRedondeado(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();

            if (bounds.Width <= 0 || bounds.Height <= 0)
                return path;

            int maxRadius = Math.Min(bounds.Width, bounds.Height) / 2;
            radius = Math.Clamp(radius, 0, maxRadius);

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            int diameter = radius * 2;
            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }

    /// <summary>
    /// Tarjeta de indicador clave (KPI) con badge vectorial coloreado según teoría del color.
    /// Resuelve por completo el solapamiento de texto e iconos no soportados.
    /// </summary>
    public class TarjetaKpiModerna : TarjetaModerna
    {
        private string _titulo = "INDICADOR";
        private string _valor = "0";
        private string _subtitulo = "";
        private string _icono = "caja";
        private Color _colorAcento = Color.FromArgb(99, 102, 241);
        private Color _colorFondoIcono = Color.FromArgb(238, 242, 255);

        public string Titulo
        {
            get => _titulo;
            set { _titulo = value; Invalidate(); }
        }

        public string Valor
        {
            get => _valor;
            set { _valor = value; Invalidate(); }
        }

        public string Subtitulo
        {
            get => _subtitulo;
            set { _subtitulo = value; Invalidate(); }
        }

        public string Icono
        {
            get => _icono;
            set { _icono = value; Invalidate(); }
        }

        public Color ColorAcento
        {
            get => _colorAcento;
            set { _colorAcento = value; Invalidate(); }
        }

        public Color ColorFondoIcono
        {
            get => _colorFondoIcono;
            set { _colorFondoIcono = value; Invalidate(); }
        }

        public TarjetaKpiModerna()
        {
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(6);
            this.Padding = new Padding(16, 14, 16, 14);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // 1. Título superior en mayúsculas atenuadas
            using var fontTitulo = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            using var brushTitulo = new SolidBrush(Color.FromArgb(100, 116, 139));
            g.DrawString(_titulo, fontTitulo, brushTitulo, 16, 14);

            // 2. Badge circular/redondeado para el icono a la derecha
            int tamBadge = 38;
            int xBadge = Width - tamBadge - 16;
            int yBadge = 14;
            var rectBadge = new Rectangle(xBadge, yBadge, tamBadge, tamBadge);
            using var pathBadge = CrearPathRectanguloRedondeado(rectBadge, 10);
            using var brushBadge = new SolidBrush(_colorFondoIcono);
            g.FillPath(brushBadge, pathBadge);

            // Dibujar icono vectorial exacto sin caracteres rotos
            var rectIcono = new Rectangle(xBadge + 8, yBadge + 8, 22, 22);
            VectorIconHelper.DibujarIcono(g, _icono, rectIcono, _colorAcento);

            // 3. Valor numérico en negrita grande y tipografía clara
            using var fontValor = new Font("Segoe UI", 18F, FontStyle.Bold);
            using var brushValor = new SolidBrush(Color.FromArgb(15, 23, 42));
            g.DrawString(_valor, fontValor, brushValor, 16, 36);

            // 4. Subtítulo o indicador de tendencia en la parte inferior
            if (!string.IsNullOrEmpty(_subtitulo))
            {
                using var fontSub = new Font("Segoe UI", 8F, FontStyle.Regular);
                using var brushSub = new SolidBrush(_colorAcento);
                g.DrawString(_subtitulo, fontSub, brushSub, 16, 72);
            }
        }
    }

    /// <summary>
    /// Botón de navegación para la barra lateral con icono vectorial, estados interactivos y excelente contraste.
    /// </summary>
    public class BotonSidebar : Button
    {
        private string _icono = "dashboard";
        private bool _estaActivo = false;
        private bool _isHover = false;

        public string Icono
        {
            get => _icono;
            set { _icono = value; Invalidate(); }
        }

        public bool EstaActivo
        {
            get => _estaActivo;
            set { _estaActivo = value; Invalidate(); }
        }

        public BotonSidebar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.FromArgb(148, 163, 184); // Slate 400 legible
            this.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.Cursor = Cursors.Hand;
            this.Height = 44;
            this.Width = 224;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.Padding = new Padding(48, 0, 0, 0);
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
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (Width <= 1 || Height <= 1)
                return;

            var g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // Limpiar el buffer sucio de memoria gráfica con el color del Sidebar.
            // Esto soluciona los solapamientos de texto y "artefactos fantasmas" en los botones.
            g.Clear(Color.FromArgb(15, 23, 42));

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);

            // Fondo según estado (Activo, Hover, Normal)
            Color colorFondo = Color.Transparent;
            Color colorTexto = Color.FromArgb(148, 163, 184);
            Color colorIcono = Color.FromArgb(148, 163, 184);

            if (_estaActivo)
            {
                colorFondo = Color.FromArgb(30, 41, 59); // Slate 800
                colorTexto = Color.White;
                colorIcono = Color.FromArgb(99, 102, 241); // Indigo acento
            }
            else if (_isHover)
            {
                colorFondo = Color.FromArgb(20, 29, 47); // Ligeramente más claro
                colorTexto = Color.White;
                colorIcono = Color.White;
            }

            if (colorFondo != Color.Transparent)
            {
                using var path = TarjetaModerna.CrearPathRectanguloRedondeado(rect, 8);
                using var brush = new SolidBrush(colorFondo);
                g.FillPath(brush, path);
            }

            // Indicador vertical a la izquierda si está activo
            if (_estaActivo)
            {
                using var brushIndicador = new SolidBrush(Color.FromArgb(99, 102, 241));
                g.FillRectangle(brushIndicador, 2, 8, 4, Height - 16);
            }

            // Icono vectorial a la izquierda
            var rectIcono = new Rectangle(16, (Height - 18) / 2, 18, 18);
            VectorIconHelper.DibujarIcono(g, _icono, rectIcono, colorIcono);

            // Texto del botón
            Font fontActual = _estaActivo ? new Font(Font, FontStyle.Bold) : Font;
            using var brushTexto = new SolidBrush(colorTexto);
            using var sf = new StringFormat { LineAlignment = StringAlignment.Center };
            var rectTexto = new Rectangle(46, 0, Width - 50, Height);
            g.DrawString(Text, fontActual, brushTexto, rectTexto, sf);
            
            if (_estaActivo) 
            {
                fontActual.Dispose();
            }
        }
    }

    /// <summary>
    /// Gráfica de barras horizontales moderna y animada con icono vectorial y sin caracteres rotos.
    /// </summary>
    public class GraficaBarrasModerna : UserControl
    {
        private readonly List<BarraDato> _datos = new();
        private System.Windows.Forms.Timer? _timerAnimacion;
        private float _progreso = 0f;
        public string Titulo { get; set; } = "Distribución de Stock por Categoría";
        public string Subtitulo { get; set; } = "Comparativa de unidades disponibles en almacén";

        public GraficaBarrasModerna()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            this.Padding = new Padding(15);
        }

        public void CargarDatos(List<BarraDato> nuevosDatos)
        {
            _datos.Clear();
            _datos.AddRange(nuevosDatos);
            IniciarAnimacion();
        }

        public void IniciarAnimacion()
        {
            _progreso = 0f;
            _timerAnimacion?.Stop();
            _timerAnimacion?.Dispose();

            _timerAnimacion = new System.Windows.Forms.Timer { Interval = 16 };
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

            // 1. Icono vectorial y Título
            var rectIcono = new Rectangle(14, 12, 18, 18);
            VectorIconHelper.DibujarIcono(g, "grafica", rectIcono, Color.FromArgb(99, 102, 241));

            using var fontTitulo = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            using var fontSubtitulo = new Font("Segoe UI", 8.2F, FontStyle.Regular);
            using var brushTitulo = new SolidBrush(Color.FromArgb(15, 23, 42));
            using var brushSubtitulo = new SolidBrush(Color.FromArgb(100, 116, 139));

            g.DrawString(Titulo, fontTitulo, brushTitulo, 38, 11);
            g.DrawString(Subtitulo, fontSubtitulo, brushSubtitulo, 38, 31);

            if (_datos.Count == 0)
            {
                g.DrawString("No hay datos de inventario para mostrar.", fontSubtitulo, brushSubtitulo, 38, 65);
                return;
            }

            decimal maxValor = _datos.Max(d => d.Valor);
            if (maxValor <= 0) maxValor = 1;

            float factorSuavizado = 1f - (float)Math.Pow(1f - _progreso, 3);

            int yActual = 60;
            int altoBarra = 15;
            int margenInferior = 34;
            int anchoTotalArea = Width - 32;
            int anchoEtiqueta = 100;
            int anchoValor = 105;
            int anchoPista = Math.Max(60, anchoTotalArea - anchoEtiqueta - anchoValor);

            using var fontEtiqueta = new Font("Segoe UI", 8.8F, FontStyle.Bold);
            using var fontValor = new Font("Segoe UI", 8.2F, FontStyle.Bold);
            using var brushPista = new SolidBrush(Color.FromArgb(241, 245, 249));

            foreach (var item in _datos)
            {
                g.DrawString(item.Etiqueta, fontEtiqueta, brushTitulo, 14, yActual - 2);

                int xPista = 14 + anchoEtiqueta;
                var rectPista = new Rectangle(xPista, yActual + 1, anchoPista, altoBarra);
                using var pathPista = TarjetaModerna.CrearPathRectanguloRedondeado(rectPista, altoBarra / 2);
                g.FillPath(brushPista, pathPista);

                float porcentaje = (float)(item.Valor / maxValor);
                int anchoBarraActual = (int)(anchoPista * porcentaje * factorSuavizado);
                if (anchoBarraActual > 6)
                {
                    var rectBarra = new Rectangle(xPista, yActual + 1, anchoBarraActual, altoBarra);
                    using var pathBarra = TarjetaModerna.CrearPathRectanguloRedondeado(rectBarra, altoBarra / 2);
                    using var brushBarra = new LinearGradientBrush(rectBarra, item.ColorInicio, item.ColorFin, LinearGradientMode.Horizontal);
                    g.FillPath(brushBarra, pathBarra);
                }

                // Badge de valor a la derecha
                string textoMostrar = string.IsNullOrEmpty(item.ValorFormateado) ? item.Valor.ToString("N0") : item.ValorFormateado;
                g.DrawString(textoMostrar, fontValor, brushSubtitulo, xPista + anchoPista + 10, yActual - 1);

                yActual += margenInferior;
            }
        }
    }

    /// <summary>
    /// Gráfica circular estilo Dona moderna con icono vectorial y sin caracteres rotos.
    /// </summary>
    public class GraficaDonaProgreso : UserControl
    {
        private float _progreso = 0f;
        private float _porcentajeOptimo = 85f;
        private System.Windows.Forms.Timer? _timer;

        public string Titulo { get; set; } = "Salud del Inventario";
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
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
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

            // Icono vectorial y Título
            var rectIcono = new Rectangle(14, 12, 18, 18);
            VectorIconHelper.DibujarIcono(g, "target", rectIcono, Color.FromArgb(16, 185, 129));

            using var fontTitulo = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            using var fontSubtitulo = new Font("Segoe UI", 8.2F, FontStyle.Regular);
            using var brushTitulo = new SolidBrush(Color.FromArgb(15, 23, 42));
            using var brushSub = new SolidBrush(Color.FromArgb(100, 116, 139));

            g.DrawString(Titulo, fontTitulo, brushTitulo, 38, 11);
            g.DrawString("Porcentaje de productos con stock suficiente", fontSubtitulo, brushSub, 38, 31);

            int diametro = Math.Min(Width - 50, Height - 110);
            if (diametro <= 30) diametro = 30;

            int centroX = Width / 2;
            int centroY = 56 + diametro / 2;
            int grosorAnillo = 15;

            var rectAnillo = new Rectangle(centroX - diametro / 2, centroY - diametro / 2, diametro, diametro);

            // Anillo base gris
            using var penBase = new Pen(Color.FromArgb(241, 245, 249), grosorAnillo) { StartCap = LineCap.Round, EndCap = LineCap.Round };
            g.DrawArc(penBase, rectAnillo, 0, 360);

            // Arco activo verde esmeralda animado
            float factorSuavizado = 1f - (float)Math.Pow(1f - _progreso, 3);
            float sweepAngle = (_porcentajeOptimo / 100f) * 360f * factorSuavizado;

            Color colorArco = _porcentajeOptimo >= 70 ? Color.FromArgb(16, 185, 129) : Color.FromArgb(239, 68, 68);
            if (sweepAngle > 0)
            {
                using var penProgreso = new Pen(colorArco, grosorAnillo) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                g.DrawArc(penProgreso, rectAnillo, -90, sweepAngle);
            }

            // Texto central grande
            int valorMostrar = (int)(_porcentajeOptimo * factorSuavizado);
            using var fontPorcentaje = new Font("Segoe UI", 19F, FontStyle.Bold);
            using var fontEstado = new Font("Segoe UI", 7.5F, FontStyle.Bold);

            string textoPorcentaje = $"{valorMostrar}%";
            var tamPorcentaje = g.MeasureString(textoPorcentaje, fontPorcentaje);
            g.DrawString(textoPorcentaje, fontPorcentaje, brushTitulo, centroX - (tamPorcentaje.Width / 2), centroY - (tamPorcentaje.Height / 2) - 6);

            string textoEstado = valorMostrar >= 70 ? "ÓPTIMO" : "ALERTA";
            Color colorEstado = valorMostrar >= 70 ? Color.FromArgb(16, 185, 129) : Color.FromArgb(239, 68, 68);
            using var brushEstado = new SolidBrush(colorEstado);
            var tamEstado = g.MeasureString(textoEstado, fontEstado);
            g.DrawString(textoEstado, fontEstado, brushEstado, centroX - (tamEstado.Width / 2), centroY + 12);

            // Leyendas inferiores
            int yLeyenda = centroY + (diametro / 2) + 16;
            DibujarPuntoLeyenda(g, 20, yLeyenda, Color.FromArgb(16, 185, 129), "Stock Saludable");
            DibujarPuntoLeyenda(g, Width / 2 + 10, yLeyenda, Color.FromArgb(239, 68, 68), "Stock Crítico");
        }

        private void DibujarPuntoLeyenda(Graphics g, int x, int y, Color color, string texto)
        {
            using var brushPunto = new SolidBrush(color);
            using var font = new Font("Segoe UI", 8F, FontStyle.Regular);
            using var brushTexto = new SolidBrush(Color.FromArgb(100, 116, 139));

            g.FillEllipse(brushPunto, x, y + 2, 8, 8);
            g.DrawString(texto, font, brushTexto, x + 14, y);
        }
    }

    /// <summary>
    /// Botón moderno con bordes redondeados y micro-interacciones.
    /// </summary>
    public class BotonModerno : Button
    {
        private int _radioBorde = 10;
        private Color _colorNormal = Color.FromArgb(99, 102, 241);
        private Color _colorHover = Color.FromArgb(79, 70, 229);
        private Color _colorClick = Color.FromArgb(67, 56, 202);
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
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
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

            // Limpiar las esquinas fuera del radio para evitar artefactos negros
            g.Clear(Color.White);

            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using var path = TarjetaModerna.CrearPathRectanguloRedondeado(rect, _radioBorde);

            Color colorActual = _isClick ? _colorClick : (_isHover ? _colorHover : _colorNormal);
            using var brushFondo = new SolidBrush(colorActual);
            g.FillPath(brushFondo, path);

            using var brushTexto = new SolidBrush(ForeColor);
            using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(Text, Font, brushTexto, rect, sf);
        }
    }
}
