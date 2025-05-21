using System;
using System.Collections.Generic;
using System.Linq;
using ReactiveUI;

namespace ContainerPackingApp.ViewModels
{
    public class ContainerViewModel : ReactiveObject // Изменено с ViewModelBase на ReactiveObject
    {
        private int _id;
        private string _lengthInput = "10";
        private string _widthInput = "10";
        private string _heightInput = "10";
        private string _weightInput = "10";


        private string _lengthError = "";
        private string _widthError = "";
        private string _heightError = "";
        private string _weightError = "";

        public bool IsCorrect = true;


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
                this.RaiseAndSetIfChanged(ref _lengthInput, value);
                ValidateLength(value);
                UpdateCorrect();
            }
        }

        public string WidthInput
        {
            get => _widthInput;
            set
            {
                this.RaiseAndSetIfChanged(ref _widthInput, value);
                ValidateWidth(value);
                UpdateCorrect();
            }
        }

        public string HeightInput
        {
            get => _heightInput;
            set
            {
                this.RaiseAndSetIfChanged(ref _heightInput, value);
                ValidateHeight(value);
                UpdateCorrect();
            }
        }

        public string WeightInput
        {
            get => _weightInput;
            set
            {
                this.RaiseAndSetIfChanged(ref _weightInput, value);
                ValidateWeight(value);
                UpdateCorrect();
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


        private void ValidateLength(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                LengthError = "Обязательно для заполнения";
            }
            else if (!int.TryParse(value, out int num) || num <= 0)
            {
                LengthError = "Введите положительное число";
            }
            else
            {
                LengthError = "";
            }
        }


        private void ValidateWidth(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                WidthError = "Обязательно для заполнения";
            }
            else if (!int.TryParse(value, out int num) || num <= 0)
            {
                WidthError = "Введите положительное число";
            }
            else
            {
                WidthError = "";
            }
        }


        private void ValidateHeight(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                HeightError = "Обязательно для заполнения";
            }
            else if (!int.TryParse(value, out int num) || num <= 0)
            {
                HeightError = "Введите положительное число";
            }
            else
            {
                HeightError = "";
            }
        }


        private void ValidateWeight(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                WeightError = "Обязательно для заполнения";
            }
            else if (!int.TryParse(value, out int num) || num <= 0)
            {
                WeightError = "Введите положительное число";
            }
            else
            {
                WeightError = "";
            }
        }


        public int GetId() => _id;
        public int? GetLength() => TryParseInt(LengthInput);
        public int? GetWidth() => TryParseInt(WidthInput);
        public int? GetHeight() => TryParseInt(HeightInput);
        public int? GetWeight() => TryParseInt(WeightInput);

        private int? TryParseInt(string input) =>
            int.TryParse(input, out int result) ? result : (int?)null;


        public void UpdateCorrect()
        {
            IsCorrect = string.IsNullOrEmpty(LengthError) &&
                   string.IsNullOrEmpty(WidthError) &&
                   string.IsNullOrEmpty(HeightError) &&
                   string.IsNullOrEmpty(WeightError);
        }
    }
}