using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ReactiveUI;

namespace ContainerPackingApp.ViewModels
{
    public class ContainerViewModel : ReactiveObject
    {
        private int _id;
        private string _lengthInput = "10.0";
        private string _widthInput = "10.0";
        private string _heightInput = "10.0";
        private string _weightInput = "10";

        private string _lengthError = "";
        private string _widthError = "";
        private string _heightError = "";
        private string _weightError = "";

        public bool IsCorrect =>
    string.IsNullOrEmpty(LengthError) &&
    string.IsNullOrEmpty(WidthError) &&
    string.IsNullOrEmpty(HeightError) &&
    string.IsNullOrEmpty(WeightError);

        public ContainerViewModel(int id)
        {
            _id = id;
        }

        public int Id
        {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }

        public string LengthInput
        {
            get => _lengthInput;
            set
            {
                ValidateDecimalInput(value, out string formattedValue, out string error);
                this.RaiseAndSetIfChanged(ref _lengthInput, formattedValue);
                LengthError = error;
            }
        }

        public string WidthInput
        {
            get => _widthInput;
            set
            {
                ValidateDecimalInput(value, out string formattedValue, out string error);
                this.RaiseAndSetIfChanged(ref _widthInput, formattedValue);
                WidthError = error;
            }
        }

        public string HeightInput
        {
            get => _heightInput;
            set
            {
                ValidateDecimalInput(value, out string formattedValue, out string error);
                this.RaiseAndSetIfChanged(ref _heightInput, formattedValue);
                HeightError = error;
            }
        }

        public string WeightInput
        {
            get => _weightInput;
            set
            {
                this.RaiseAndSetIfChanged(ref _weightInput, value);
                ValidateWeight(value);
            }
        }

        public string LengthError
        {
            get => _lengthError;
            private set => this.RaiseAndSetIfChanged(ref _lengthError, value);
        }

        public string WidthError
        {
            get => _widthError;
            private set => this.RaiseAndSetIfChanged(ref _widthError, value);
        }

        public string HeightError
        {
            get => _heightError;
            private set => this.RaiseAndSetIfChanged(ref _heightError, value);
        }

        public string WeightError
        {
            get => _weightError;
            private set => this.RaiseAndSetIfChanged(ref _weightError, value);
        }

        private void ValidateDecimalInput(string input, out string formattedValue, out string error)
        {
            formattedValue = input;
            error = "";

            // Пустая строка допустима (ошибка будет обработана в валидаторе)
            if (string.IsNullOrWhiteSpace(input))
            {
                error = "Обязательно для заполнения";
            }

            // Заменяем запятую на точку для унификации
            input = input.Replace(',', '.');
            int num = 0;

            // Проверяем формат числа
            var parts = input.Split('.');
            if (parts.Length == 2 && parts[1].Length >= 1)
            {
                if (!int.TryParse(parts[0], out num) || num <= 0)
                    error = "Введите положительное число (формат: 0.0)";

                if (!int.TryParse(parts[1], out num) || num < 0)
                    error = "Введите положительное число (формат: 0.0)";

                // Если больше одной цифры после точки - обрезаем
                formattedValue = $"{parts[0]}.{parts[1].Substring(0, 1)}";
            }
                
            else if (!input.Contains("."))
            {
                if (!int.TryParse(input, out num) || num <= 0)
                    error = "Введите положительное число (формат: 0.0)";

                // Добавляем .0 если нет дробной части
                formattedValue = $"{input}.0";
            }
            else if (parts.Length == 2 && parts[1].Length == 0)
            {
                if (!int.TryParse(parts[0], out num) || num <= 0)
                    error = "Введите положительное число (формат: 0.0)";

                // Добавляем .0 если нет дробной части
                formattedValue = $"{input}0";
            }
            else { error = "Введите положительное число (формат: 0.0)"; }

            
        }


        private void ValidateWeight(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                WeightError = "Обязательно для заполнения";
            }
            else if (!int.TryParse(value, out int num) || num <= 0)
            {
                WeightError = "Введите положительное целое число";
            }
            else
            {
                WeightError = "";
            }
        }

        public int GetId() => _id;
        public double? GetLength() => TryParseDouble(LengthInput);
        public double? GetWidth() => TryParseDouble(WidthInput);
        public double? GetHeight() => TryParseDouble(HeightInput);
        public int? GetWeight() => TryParseInt(WeightInput);

        private double? TryParseDouble(string input) =>
            double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double result) ? result : (double?)null;

        private int? TryParseInt(string input) =>
            int.TryParse(input, out int result) ? result : (int?)null;

    }
}