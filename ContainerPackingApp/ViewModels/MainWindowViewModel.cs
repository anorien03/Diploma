using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ContainerPackingApp.Models;
using ContainerPackingApp.Models.Diploma.Models;
using ContainerPackingApp.Packers;
using ReactiveUI;
using System.Reactive;
using ReactiveUI.Validation.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;
using System.IO;
using System.Globalization;
using System.Windows;
using System.Collections.Generic;
using Avalonia.Controls;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Avalonia.Threading;

namespace ContainerPackingApp.ViewModels
{
    public class MainWindowViewModel : ReactiveObject // Изменено с ViewModelBase на ReactiveObject
    {
        private string _populationSizeInput = "100";
        private string _generationsCountInput = "100";
        private string _mutationRateInput = "30";
        private string _tournamentSizeInput = "2";
        private string _elitismInput = "5";
        private string _shipHoldLengthInput = "100.0";
        private string _shipHoldWidthInput = "100.0";
        private string _shipHoldHeightInput = "100.0";
        private string _shipHoldMaxWeightInput = "10000";

        private string _resultText = "";
        private string _errorText = "";
        private bool _isRunning;


        private string _populationSizeError = "";
        private string _generationsCountError = "";
        private string _mutationRateError = "";
        private string _tournamentSizeError = "";
        private string _elitismError = "";
        private string _shipHoldLengthError = "";
        private string _shipHoldWidthError = "";
        private string _shipHoldHeightError = "";
        private string _shipHoldMaxWeightError = "";




        public ObservableCollection<ContainerViewModel> Containers { get; } = new ObservableCollection<ContainerViewModel>();
        private string _containersCount = "";
        private bool _hasResults = false;

        public bool HasResults
        {
            get => _hasResults;
            set => this.RaiseAndSetIfChanged(ref _hasResults, value);
        }

        private ObservableCollection<ContainerInfo> _packedContainers = new();
        public ObservableCollection<ContainerInfo> PackedContainers
        {
            get => _packedContainers;
            set => this.RaiseAndSetIfChanged(ref _packedContainers, value);
        }



        private List<int> _fitnessData = new();
        public List<int> FitnessData
        {
            get => _fitnessData;
            set => this.RaiseAndSetIfChanged(ref _fitnessData, value);
        }

        // В методе RunAlgorithm после получения fitnessList:
        private void UpdateChart(List<int> fitnessList, ShipHold shipHold, int el)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                FitnessData = fitnessList;
                if (el != 0)
                {
                    FitnessData.Sort();
                    FitnessData.Reverse();
                }
            });
        }



        public string PopulationSizeInput
        {
            get => _populationSizeInput;
            set
            {
                this.RaiseAndSetIfChanged(ref _populationSizeInput, value);
                ValidatePopulationSize(value);
            }
        }

        private void ValidatePopulationSize(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                PopulationSizeError = "Поле обязательно для заполнения";
            }
            else if (!int.TryParse(value, out int num) || num <= 0)
            {
                PopulationSizeError = "Введите положительное число";
            }
            else
            {
                PopulationSizeError = "";
            }
        }

        public string PopulationSizeError
        {
            get => _populationSizeError;
            private set => this.RaiseAndSetIfChanged(ref _populationSizeError, value);
        }


        public int? GetPopulationSize()
        {
            if (int.TryParse(PopulationSizeInput, out int result))
                return result;
            return null;
        }




        public string GenerationsCountInput
        {
            get => _generationsCountInput;
            set
            {
                this.RaiseAndSetIfChanged(ref _generationsCountInput, value);
                ValidateGenerationsCount(value);
            }
        }


        public string GenerationsCountError
        {
            get => _generationsCountError;
            private set => this.RaiseAndSetIfChanged(ref _generationsCountError, value);
        }


        public string MutationRateInput
        {
            get => _mutationRateInput;
            set
            {
                this.RaiseAndSetIfChanged(ref _mutationRateInput, value);
                ValidateMutationRate(value);
            }
        }


        public string MutationRateError
        {
            get => _mutationRateError;
            private set => this.RaiseAndSetIfChanged(ref _mutationRateError, value);
        }


        public string TournamentSizeInput
        {
            get => _tournamentSizeInput;
            set
            {
                this.RaiseAndSetIfChanged(ref _tournamentSizeInput, value);
                ValidateTournamentSize(value);
            }
        }


        public string TournamentSizeError
        {
            get => _tournamentSizeError;
            private set => this.RaiseAndSetIfChanged(ref _tournamentSizeError, value);
        }


        public string ElitismInput
        {
            get => _elitismInput;
            set
            {
                this.RaiseAndSetIfChanged(ref _elitismInput, value);
                ValidateElitism(value);
            }
        }


        public string ElitismError
        {
            get => _elitismError;
            private set => this.RaiseAndSetIfChanged(ref _elitismError, value);
        }


        public string ShipHoldLengthInput
        {
            get => _shipHoldLengthInput;
            set
            {
                ValidateDecimalInput(value, out string formattedValue, out string error);
                this.RaiseAndSetIfChanged(ref _shipHoldLengthInput, formattedValue);
                ShipHoldLengthError = error;
            }
        }


        public string ShipHoldLengthError
        {
            get => _shipHoldLengthError;
            private set => this.RaiseAndSetIfChanged(ref _shipHoldLengthError, value);
        }


        public string ShipHoldWidthInput
        {
            get => _shipHoldWidthInput;
            set
            {
                ValidateDecimalInput(value, out string formattedValue, out string error);
                this.RaiseAndSetIfChanged(ref _shipHoldWidthInput, formattedValue);
                ShipHoldWidthError = error;
            }
        }


        public string ShipHoldWidthError
        {
            get => _shipHoldWidthError;
            private set => this.RaiseAndSetIfChanged(ref _shipHoldWidthError, value);
        }


        public string ShipHoldHeightInput
        {
            get => _shipHoldHeightInput;
            set
            {
                ValidateDecimalInput(value, out string formattedValue, out string error);
                this.RaiseAndSetIfChanged(ref _shipHoldHeightInput, formattedValue);
                ShipHoldHeightError = error;
            }
        }


        public string ShipHoldHeightError
        {
            get => _shipHoldHeightError;
            private set => this.RaiseAndSetIfChanged(ref _shipHoldHeightError, value);
        }


        public string ShipHoldMaxWeightInput
        {
            get => _shipHoldMaxWeightInput;
            set
            {
                this.RaiseAndSetIfChanged(ref _shipHoldMaxWeightInput, value);
                ValidateShipHoldMaxWeight(value);
            }
        }


        public string ShipHoldMaxWeightError
        {
            get => _shipHoldMaxWeightError;
            private set => this.RaiseAndSetIfChanged(ref _shipHoldMaxWeightError, value);
        }


        // Методы валидации
        private void ValidateGenerationsCount(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                GenerationsCountError = "Поле обязательно для заполнения";
            else if (!int.TryParse(value, out int num) || num <= 0)
                GenerationsCountError = "Введите положительное число";
            else
                GenerationsCountError = "";
        }

        private void ValidateMutationRate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                MutationRateError = "Поле обязательно для заполнения";
            else if (!int.TryParse(value, out int num) || num < 0 || num > 100)
                MutationRateError = "Введите число от 0 до 100";
            else
                MutationRateError = "";
        }

        private void ValidateTournamentSize(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                TournamentSizeError = "Поле обязательно для заполнения";
            else if (!int.TryParse(value, out int num) || num < 2 || num > 5)
                TournamentSizeError = "Введите число от 2 до 5";
            else
                TournamentSizeError = "";
        }

        private void ValidateElitism(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                ElitismError = "Поле обязательно для заполнения";
            else if (!int.TryParse(value, out int num) || num < 0 || num > 100)
                ElitismError = "Введите число от 0 до 100";
            else
                ElitismError = "";
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

        private void ValidateShipHoldMaxWeight(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                ShipHoldMaxWeightError = "Поле обязательно для заполнения";
            else if (!int.TryParse(value, out int num) || num <= 0)
                ShipHoldMaxWeightError = "Введите положительное число";
            else
                ShipHoldMaxWeightError = "";
        }

        private double? TryParseDouble(string input) =>
            double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double result) ? result : (double?)null;

        // Методы для получения числовых значений
        public int? GetGenerationsCount() => TryParseInt(GenerationsCountInput);
        public int? GetMutationRate() => TryParseInt(MutationRateInput);
        public int? GetTournamentSize() => TryParseInt(TournamentSizeInput);
        public int? GetElitism() => TryParseInt(ElitismInput);
        public int? GetShipHoldMaxWeight() => TryParseInt(ShipHoldMaxWeightInput);

        public double? GetShipHoldLength() => TryParseDouble(ShipHoldLengthInput);
        public double? GetShipHoldWidth() => TryParseDouble(ShipHoldWidthInput);
        public double? GetShipHoldHeight() => TryParseDouble(ShipHoldHeightInput);

        private int? TryParseInt(string input) =>
            int.TryParse(input, out int result) ? result : (int?)null;

        // Проверка перед запуском алгоритма
        public bool CanRunAlgorithm()
        {
            if (_isRunning)
            {
                ErrorText = "is running...";
                return false;
            }

            if ((string.IsNullOrEmpty(PopulationSizeError) &&
                   string.IsNullOrEmpty(GenerationsCountError) &&
                   string.IsNullOrEmpty(MutationRateError) &&
                   string.IsNullOrEmpty(TournamentSizeError) &&
                   string.IsNullOrEmpty(ElitismError)) == false)
            {
                ErrorText = "Неверно заданы параматеры генетического алгоритма";
                return false;
            }


            if ((string.IsNullOrEmpty(ShipHoldLengthError) &&
                   string.IsNullOrEmpty(ShipHoldWidthError) &&
                   string.IsNullOrEmpty(ShipHoldHeightError) &&
                   string.IsNullOrEmpty(ShipHoldMaxWeightError)) == false)
            {
                ErrorText = "Неверно заданы параматеры трюма";
                return false;
            }


            if (Containers.Count == 0)
            {
                ErrorText = "Необходимо ввести список контейнеров";
                return false;
            }


            foreach (var c in Containers)
            {
                if (!c.IsCorrect)
                {
                    ErrorText = "Неверно заданы параметры контейнеров";
                    return false;
                }
            }

            if (Containers.Count < 8)
            {
                var fact = 1;
                for (var a = 2; a <= Containers.Count; a++) { fact *= a; }

                if (fact < GetPopulationSize())
                {
                    ErrorText = "Cлишком мало контейнеров для заданного размера популяции";
                    return false;
                }
            }

            ErrorText = "";
            return true;
        }



        public string ResultText
        {
            get => _resultText;
            set => this.RaiseAndSetIfChanged(ref _resultText, value);
        }


        public bool IsRunning
        {
            get => _isRunning;
            set => this.RaiseAndSetIfChanged(ref _isRunning, value);
        }


        public string ErrorText
        {
            get => _errorText;
            set => this.RaiseAndSetIfChanged(ref _errorText, value);
        }


        public string ContainersCount
        {
            get => _containersCount;
            set => this.RaiseAndSetIfChanged(ref _containersCount, value);
        }


        private void UpdateContainersCount()
        {
            ContainersCount = $"   Всего: {Containers.Count()}";
        }


        public void AddContainer()
        {
            var existingIds = Containers.Select(c => c.GetId()).ToList();
            existingIds.Sort();
            int newId = 1;
            foreach (int id in existingIds)
            {
                if (id == newId)
                    newId++;
                else
                    break;
            }

            var newContainer = new ContainerViewModel(newId);

            Containers.Add(newContainer);
            UpdateContainersCount();
        }

        public void RemoveContainer(ContainerViewModel container)
        {
            Containers.Remove(container);
            UpdateContainersCount();
        }


        public void RemoveAllContainers()
        {
            Containers.Clear();
            UpdateContainersCount();
        }






        public async void RunAlgorithm()
        {
            if (!CanRunAlgorithm()) return;

            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                _isRunning = true;
                ErrorText = "is running...";
            });



            try
            {
                await Dispatcher.UIThread.InvokeAsync(async () =>
                {
                    var shipHold = new ShipHold(
                    (int)(GetShipHoldLength() * 10 ?? 0),
                    (int)(GetShipHoldWidth() * 10 ?? 0),
                    (int)(GetShipHoldHeight() * 10 ?? 0),
                    GetShipHoldMaxWeight() ?? 0);

                var containers = Containers.Select(c =>
                    new Container(c.GetId(), (int) (c.GetLength() * 10 ?? 0), (int)(c.GetWidth() * 10 ?? 0), (int)(c.GetHeight() * 10 ?? 0), c.GetWeight() ?? 0)).ToList();

                var el = GetElitism() ?? 5;
                var ga = new GeneticAlgorithm(
                    new PackerEMS(),
                    GetPopulationSize() ?? 200,
                    GetGenerationsCount() ?? 100,
                    GetMutationRate() ?? 30,
                    GetTournamentSize() ?? 2,
                    GetElitism() ?? 5);

                var fitnessList = new List<int>();
                var result = await Task.Run(() => ga.Run(shipHold, containers, out fitnessList));
                    UpdateChart(fitnessList, shipHold, el);
                    HasResults = true;
                PackedContainers.Clear();
                foreach (var container in result.PackedContainers)
                {
                    PackedContainers.Add(new ContainerInfo
                    {
                        Id = container.Container.Id,
                        StartCoordinates = $"({(double) container.X0 / 10.0}, {(double) container.Y0 / 10.0}, {(double) container.Z0 / 10.0})",
                        EndCoordinates = $"    ({(double) container.X1 / 10.0}, {(double) container.Y1 / 10.0}, {(double) container.Z1 / 10.0})"
                    });
                }

                ResultText = "С учетом ориентации:\n" +
                            $"Целевая функция: {(double)(shipHold.Volume - result.TotalVolume) / 1000}\n" +
                            $"Количество упакованных контейнеров: {result.PackedContainers.Count}\n" +
                             $"Суммарный объем упакованных контейнеров: {(double) result.TotalVolume / 1000} м³\n" +
                             $"Суммарный вес упакованных контейнеров: {result.TotalWeight} кг\n" +
                             $"Оставшийся объем трюма: {(double)(shipHold.Volume - result.TotalVolume) / 1000} м³\n" +
                             $"Заполненность трюма: {result.TotalVolume / (double)shipHold.Volume * 100:0.##}%\n" +
                             $"Количество неупакованных контейнеров (из-за ограниченного объема): {result.UnpackedSpaceContainersId.Count}\n" +
                             $"Количество неупакованных контейнеров (из-за ограниченной грузоподъемности) : {result.UnpackedWeightContainersId.Count}\n";
                });
            }
            catch (Exception ex)
            {
                await Dispatcher.UIThread.InvokeAsync(() => ResultText = $"Error: {ex.Message}");
            }
            finally
            {
                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    _isRunning = false;
                    ErrorText = "";
                });
            }


        }



        public async void RunAlgorithmNoOrint()
        {
            if (!CanRunAlgorithm()) return;

            _isRunning = true;
            ErrorText = "is running...";



            try
            {
                var shipHold = new ShipHold(
                    (int)(GetShipHoldLength() * 10 ?? 0),
                    (int)(GetShipHoldWidth() * 10 ?? 0),
                    (int)(GetShipHoldHeight() * 10 ?? 0),
                    GetShipHoldMaxWeight() ?? 0);

                var containers = Containers.Select(c =>
                    new Container(c.GetId(), (int)(c.GetLength() * 10 ?? 0), (int)(c.GetWidth() * 10 ?? 0), (int)(c.GetHeight() * 10 ?? 0), c.GetWeight() ?? 0)).ToList();

                var el = GetElitism() ?? 5;
                var ga = new GeneticAlgorithm(
                    new PackerEMSNoOrint(),
                    GetPopulationSize() ?? 200,
                    GetGenerationsCount() ?? 100,
                    GetMutationRate() ?? 30,
                    GetTournamentSize() ?? 2,
                    GetElitism() ?? 5);

                var fitnessList = new List<int>();
                var result = await Task.Run(() => ga.Run(shipHold, containers, out fitnessList));
                UpdateChart(fitnessList, shipHold, el);
                HasResults = true;
                PackedContainers.Clear();
                foreach (var container in result.PackedContainers)
                {
                    PackedContainers.Add(new ContainerInfo
                    {
                        Id = container.Container.Id,
                        StartCoordinates = $"({(double)container.X0 / 10.0}, {(double)container.Y0 / 10.0}, {(double)container.Z0 / 10.0})",
                        EndCoordinates = $"    ({(double)container.X1 / 10.0}, {(double)container.Y1 / 10.0}, {(double)container.Z1 / 10.0})"
                    });
                }

                ResultText = "Без учета ориентации:\n" +
                             $"Целевая функция: {shipHold.Volume - result.TotalVolume}\n" +
                             $"Количество упакованных контейнеров: {result.PackedContainers.Count}\n" +
                             $"Суммарный объем упакованных контейнеров: {(double)result.TotalVolume / 1000} м³\n" +
                             $"Суммарный вес упакованных контейнеров: {result.TotalWeight} кг\n" +
                             $"Заполненность трюма: {result.TotalVolume / (double)shipHold.Volume * 100:0.##}%\n" +
                             $"Количество неупакованных контейнеров (из-за ограниченного объема): {result.UnpackedSpaceContainersId.Count}\n" +
                             $"Количество неупакованных контейнеров (из-за ограниченной грузоподъемности) : {result.UnpackedWeightContainersId.Count}\n";
            }
            catch (Exception ex)
            {
                ResultText = $"Error: {ex.Message}";
            }
            finally
            {
                _isRunning = false;
                ErrorText = "";
            }
        }




        public async void LoadContainersFromCsv()
        {
            try
            {
                var dialog = new OpenFileDialog();
                dialog.Filters.Add(new FileDialogFilter() { Name = "CSV Files", Extensions = { "csv" } });
                dialog.AllowMultiple = false;

                var result = await dialog.ShowAsync((Window)VisualRoot);
                if (result != null && result.Any())
                {
                    var filePath = result.First();
                    var containers = ParseCsvFile(filePath);

                    foreach (var container in containers)
                    {
                        Containers.Add(container);
                    }

                    UpdateContainersCount();
                }
            }
            catch (Exception ex)
            {
                ErrorText = $"Ошибка при загрузке файла: {ex.Message}";
            }
        }

        private List<ContainerViewModel> ParseCsvFile(string filePath)
        {
            var containers = new List<ContainerViewModel>();
            var lines = File.ReadAllLines(filePath);
            var existingIds = Containers.Select(c => c.GetId()).ToList();

            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',');
                if (parts.Length >= 5)
                {
                    var id = int.Parse(parts[0].Trim());

                    if (existingIds.Contains(id))
                    {
                        continue;
                    }

                    var container = new ContainerViewModel(id)
                    {
                        LengthInput = parts[1].Trim(),
                        WidthInput = parts[2].Trim(),
                        HeightInput = parts[3].Trim(),
                        WeightInput = parts[4].Trim()
                    };



                    containers.Add(container);
                    existingIds.Add(id);
                }
            }

            return containers;
        }

        // Добавьте это свойство для доступа к корневому окну
        public Avalonia.Controls.Window VisualRoot { get; set; }

        private PlotModel _plotModel;
        public PlotModel PlotModel
        {
            get => _plotModel;
            set => this.RaiseAndSetIfChanged(ref _plotModel, value);
        }

    }



    public class ContainerInfo
    {
        public int Id { get; set; }
        public string StartCoordinates { get; set; }
        public string EndCoordinates { get; set; }
    }
}