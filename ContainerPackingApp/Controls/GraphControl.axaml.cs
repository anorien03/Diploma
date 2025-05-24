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
        private Pen _linePen = new Pen(Brushes.Gray, 2);
        private Pen _axisPen = new Pen(Brushes.Black, 2);
        private Typeface _axisFont = new Typeface("Arial");
        private const int Padding = 40;
        private const int PointRadius = 3;

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
            context.DrawLine(_axisPen, new Point(Padding, height - Padding), new Point(width - Padding, height - Padding)); // X-axis
            context.DrawLine(_axisPen, new Point(Padding, Padding), new Point(Padding, height - Padding)); // Y-axis

            // Фиксированный максимум и округленный минимум
            const double maxY = 100;
            double minY = _dataPoints.Min();
            minY = Math.Floor(minY / 10) * 10; // Округляем до меньшего кратного 10
            double rangeY = maxY - minY;

            double graphWidth = width - 2 * Padding;
            double graphHeight = height - 2 * Padding;

            // Draw axis labels
            DrawAxisLabels(context, width, height, maxY, minY);

            // Draw data points and lines
            Point? previousPoint = null;
            for (int i = 0; i < _dataPoints.Count; i++)
            {
                double x = Padding + (i * graphWidth) / (_dataPoints.Count - 1);

                // Масштабируем к координатам графика
                double y = height - Padding - ((_dataPoints[i] - minY) * graphHeight / rangeY);

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

        private void DrawAxisLabels(DrawingContext context, double width, double height, double maxY, double minY)
        {
            // Y-axis labels (с шагом 10)
            int steps = (int)((maxY - minY) / 2);
            for (int i = 0; i <= steps; i++)
            {
                double value = minY + (maxY - minY) * i / steps;
                double y = height - Padding - (height - 2 * Padding) * i / steps;

                var text = new FormattedText(
                    value.ToString("0"),
                    CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    _axisFont,
                    10,
                    Brushes.Black);

                context.DrawText(text, new Point(5, y - text.Height / 2));
            }

            // X-axis labels (оставляем как было)
            if (_dataPoints.Count > 1)
            {
                // Определяем количество меток (не более 10)
                int labelCount = Math.Min(21, _dataPoints.Count);

                // Рассчитываем шаг для круглых чисел
                int step = (int)Math.Ceiling(_dataPoints.Count / 10.0);
                step = ((step + 9) / 10) * 10; // Округляем шаг до ближайшего большего кратного 10

                for (int i = 0; i < labelCount; i++)
                {
                    // Рассчитываем индекс для круглого числа
                    int index = i * step;
                    if (index >= _dataPoints.Count)
                        index = _dataPoints.Count - 1;

                    // Позиция по X
                    double x = Padding + (width - 2 * Padding) * index / (_dataPoints.Count - 1);

                    var text = new FormattedText(
                        index.ToString(),
                        CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight,
                        _axisFont,
                        10,
                        Brushes.Black);

                    context.DrawText(text, new Point(x - text.Width / 2, height - Padding + 5));
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