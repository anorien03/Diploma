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

namespace ContainerPackingApp.ViewModels
{
    public class MainWindowViewModel : ReactiveObject // Изменено с ViewModelBase на ReactiveObject
    {
        private string _populationSizeInput = "200";
        private string _generationsCountInput = "100";
        private string _mutationRateInput = "30";
        private string _tournamentSizeInput = "2";
        private string _elitismInput = "5";
        private string _shipHoldLengthInput = "100";
        private string _shipHoldWidthInput = "100";
        private string _shipHoldHeightInput = "100";
        private string _shipHoldMaxWeightInput = "100";

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
        private void UpdateChart(List<int> fitnessList, ShipHold shipHold)
        {
            var size = shipHold.Length * shipHold.Width * shipHold.Height;
            FitnessData = fitnessList.Select(f => (size - f) * 100 / size).ToList();
            FitnessData.Sort();
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
                this.RaiseAndSetIfChanged(ref _shipHoldLengthInput, value);
                ValidateShipHoldLength(value);
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
                this.RaiseAndSetIfChanged(ref _shipHoldWidthInput, value);
                ValidateShipHoldWidth(value);
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
                this.RaiseAndSetIfChanged(ref _shipHoldHeightInput, value);
                ValidateShipHoldHeight(value);
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
            else if (!int.TryParse(value, out int num) || num < 2)
                TournamentSizeError = "Введите число не менее 2";
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

        private void ValidateShipHoldLength(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                ShipHoldLengthError = "Поле обязательно для заполнения";
            else if (!int.TryParse(value, out int num) || num <= 0)
                ShipHoldLengthError = "Введите положительное число";
            else
                ShipHoldLengthError = "";
        }

        private void ValidateShipHoldWidth(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                ShipHoldWidthError = "Поле обязательно для заполнения";
            else if (!int.TryParse(value, out int num) || num <= 0)
                ShipHoldWidthError = "Введите положительное число";
            else
                ShipHoldWidthError = "";
        }

        private void ValidateShipHoldHeight(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                ShipHoldHeightError = "Поле обязательно для заполнения";
            else if (!int.TryParse(value, out int num) || num <= 0)
                ShipHoldHeightError = "Введите положительное число";
            else
                ShipHoldHeightError = "";
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

        // Методы для получения числовых значений
        public int? GetGenerationsCount() => TryParseInt(GenerationsCountInput);
        public int? GetMutationRate() => TryParseInt(MutationRateInput);
        public int? GetTournamentSize() => TryParseInt(TournamentSizeInput);
        public int? GetElitism() => TryParseInt(ElitismInput);
        public int? GetShipHoldLength() => TryParseInt(ShipHoldLengthInput);
        public int? GetShipHoldWidth() => TryParseInt(ShipHoldWidthInput);
        public int? GetShipHoldHeight() => TryParseInt(ShipHoldHeightInput);
        public int? GetShipHoldMaxWeight() => TryParseInt(ShipHoldMaxWeightInput);

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
                    ResultText = "Неверно заданы параметры контейнеров";
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

            _isRunning = true;
            ErrorText = "is running...";



            try
            {
                var shipHold = new ShipHold(
                    GetShipHoldLength() ?? 0,
                    GetShipHoldWidth() ?? 0,
                    GetShipHoldHeight() ?? 0,
                    GetShipHoldMaxWeight() ?? 0);

                var containers = Containers.Select(c =>
                    new Container(c.GetId(), c.GetLength() ?? 0, c.GetWidth() ?? 0, c.GetHeight() ?? 0, c.GetWeight() ?? 0)).ToList();

                var ga = new GeneticAlgorithm(
                    new PackerEMS(),
                    GetPopulationSize() ?? 200,
                    GetGenerationsCount() ?? 100,
                    GetMutationRate() ?? 30,
                    GetTournamentSize() ?? 2,
                    GetElitism() ?? 5);

                var fitnessList = new List<int>();
                var result = await Task.Run(() => ga.Run(shipHold, containers, out fitnessList));
                UpdateChart(fitnessList, shipHold);
                HasResults = true;
                PackedContainers.Clear();
                foreach (var container in result.PackedContainers)
                {
                    PackedContainers.Add(new ContainerInfo
                    {
                        Id = container.Container.Id,
                        StartCoordinates = $"({container.X0}, {container.Y0}, {container.Z0})",
                        EndCoordinates = $"({container.X1}, {container.Y1}, {container.Z1})"
                    });
                }

                ResultText = $"Количество упакованных контейнеров: {result.PackedContainers.Count}\n" +
                             $"Суммарный объем упакованных контейнеров: {result.TotalVolume}\n" +
                             $"Суммарный вес упакованных контейнеров: {result.TotalWeight}\n" +
                             $"Заполненность трюма: {result.TotalVolume / (double)shipHold.Volume * 100:0.##}\n%" +
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
                ResultText = $"Ошибка при загрузке файла: {ex.Message}";
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