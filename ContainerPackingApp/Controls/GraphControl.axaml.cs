using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ContainerPackingApp.Controls
{
    public class GraphControl : Control
    {
        private List<int> _dataPoints = new();
        private Pen _linePen = new Pen(Brushes.Blue, 2);
        private Pen _axisPen = new Pen(Brushes.Black, 2);
        private Typeface _axisFont = new Typeface("Arial");
        private const int Padding = 40;
        private const int PointRadius = 0;
        private const int YAxisLabelCount = 20; // Фиксированное количество делений на оси Y
        private const int LeftPadding = 80; // Увеличенный отступ для оси Y
        private const int BottomPadding = 40;

        public static readonly DirectProperty<GraphControl, List<int>> DataPointsProperty =
            AvaloniaProperty.RegisterDirect<GraphControl, List<int>>(
                nameof(DataPoints),
                o => o.DataPoints,
                (o, v) => o.DataPoints = v);

        public List<int> DataPoints
        {
            get => _dataPoints;
            set => SetAndRaise(DataPointsProperty, ref _dataPoints, value);
        }

        public GraphControl()
        {
            ClipToBounds = true;
        }

        public override void Render(DrawingContext context)
        {
            if (Background != null)
            {
                context.FillRectangle(Background, new Rect(0, 0, Bounds.Width, Bounds.Height));
            }

            base.Render(context);

            if (_dataPoints == null || _dataPoints.Count == 0)
                return;

            var bounds = Bounds;
            var width = bounds.Width;
            var height = bounds.Height;

            // Draw axes
            context.DrawLine(_axisPen, new Point(LeftPadding, height - BottomPadding),
                new Point(width - Padding, height - BottomPadding)); // X-axis
            context.DrawLine(_axisPen, new Point(LeftPadding, Padding),
                new Point(LeftPadding, height - BottomPadding)); // Y-axis

            // Рассчитываем minY и maxY с округлением
            double maxY = _dataPoints.Max();
            double minY = _dataPoints.Min();

            // Округляем до ближайших целых чисел с небольшим отступом
            maxY = Math.Ceiling(maxY * 1.02); // Добавляем 10% сверху
            minY = Math.Floor(minY * 0.98); // Добавляем 10% снизу

            // Если все значения одинаковые, добавляем диапазон
            if (maxY <= minY)
            {
                maxY = minY + 2;
                minY = minY - 2;
            }

            double rangeY = maxY - minY;

            double graphWidth = width - LeftPadding - Padding;
            double graphHeight = height - 2 * BottomPadding;

            // Draw axis labels
            DrawAxisLabels(context, width, height, maxY, minY, rangeY);

            // Draw data points and lines
            Point? previousPoint = null;
            for (int i = 0; i < _dataPoints.Count; i++)
            {
                double x = LeftPadding + (i * graphWidth) / (_dataPoints.Count - 1);
                double y = height - BottomPadding - ((_dataPoints[i] - minY) * graphHeight / rangeY);

                var currentPoint = new Point(x, y);

                // Draw point
                context.DrawEllipse(Brushes.Blue, null, currentPoint, PointRadius, PointRadius);

                // Draw line to previous point
                if (previousPoint.HasValue)
                {
                    context.DrawLine(_linePen, previousPoint.Value, currentPoint);
                }

                previousPoint = currentPoint;
            }
        }

        private void DrawAxisLabels(DrawingContext context, double width, double height,
                          double maxY, double minY, double rangeY)
        {
            // Y-axis labels - 20 отрезков
            for (int i = 0; i <= YAxisLabelCount; i++)
            {
                double value = minY + (rangeY * i / YAxisLabelCount);
                double y = height - BottomPadding - ((height - 2 * BottomPadding) * i / YAxisLabelCount);

                // Форматируем значение: делим на 1000 и оставляем одну цифру после точки
                string formattedValue = (value / 1000).ToString("0.0", CultureInfo.InvariantCulture);

                var text = new FormattedText(
                    formattedValue,
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    _axisFont,
                    12,
                    Brushes.Black);

                // Рисуем текст значения
                context.DrawText(text, new Point(LeftPadding - text.Width - 10, y - text.Height / 2));

                // Рисуем маленький отрезок (тик) на оси Y
                double tickLength = 5;
                context.DrawLine(
                    _axisPen,
                    new Point(LeftPadding - tickLength, y),
                    new Point(LeftPadding, y));
            }

            // X-axis labels
            if (_dataPoints.Count > 1)
            {
                int labelCount = Math.Min(10, _dataPoints.Count);
                int step = _dataPoints.Count / labelCount;
                if (step < 1) step = 1;

                for (int i = 0; i < _dataPoints.Count; i += step)
                {
                    double x = LeftPadding + (width - LeftPadding - Padding) * i / (_dataPoints.Count - 1);

                    var text = new FormattedText(
                        i.ToString(),
                        CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight,
                        _axisFont,
                        12,
                        Brushes.Black);

                    context.DrawText(text, new Point(x - text.Width / 2, height - BottomPadding + 5));
                }
            }

            // Подпись оси X
            var xLabel = new FormattedText(
                "Номер поколения",
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                _axisFont,
                13,
                Brushes.Black);
            context.DrawText(xLabel, new Point(width / 2 - xLabel.Width / 2, height - BottomPadding + 20));

            // Подпись оси Y (вертикальный текст)
            string yLabelText = "Целевая функция";
            double letterSpacing = 9;
            double startY = height / 2 + (yLabelText.Length * letterSpacing) / 2;
            double xPos = 10; // Увеличенный отступ для подписи оси Y

            for (int i = 0; i < yLabelText.Length; i++)
            {
                var letter = new FormattedText(
                    yLabelText[i].ToString(),
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    _axisFont,
                    12,
                    Brushes.Black);

                var transform = Matrix.CreateRotation(-Math.PI / 2) *
                               Matrix.CreateTranslation(xPos, startY - i * letterSpacing);

                using (context.PushTransform(transform))
                {
                    context.DrawText(letter, new Point(0, 0));
                }
            }
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == DataPointsProperty)
            {
                InvalidateVisual();
            }
        }

        public static readonly StyledProperty<IBrush> BackgroundProperty =
            AvaloniaProperty.Register<GraphControl, IBrush>(nameof(Background), inherits: true);

        public IBrush Background
        {
            get => GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }
    }
}