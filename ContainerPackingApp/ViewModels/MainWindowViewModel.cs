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
            return string.IsNullOrEmpty(PopulationSizeError) &&
                   string.IsNullOrEmpty(GenerationsCountError) &&
                   string.IsNullOrEmpty(MutationRateError) &&
                   string.IsNullOrEmpty(TournamentSizeError) &&
                   string.IsNullOrEmpty(ElitismError) &&
                   string.IsNullOrEmpty(ShipHoldLengthError) &&
                   string.IsNullOrEmpty(ShipHoldWidthError) &&
                   string.IsNullOrEmpty(ShipHoldHeightError) &&
                   string.IsNullOrEmpty(ShipHoldMaxWeightError) &&
                   !IsRunning;
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

        public void AddContainer()
        {
            Containers.Add(new ContainerViewModel());
        }

        public void RemoveContainer(ContainerViewModel container)
        {
            Containers.Remove(container);
        }



        


        public async void RunAlgorithm()
        {
            if (!CanRunAlgorithm()) return;

            IsRunning = true;
            ResultText = "Running algorithm...";

            try
            {
                var shipHold = new ShipHold(
                    GetShipHoldLength() ?? 0,
                    GetShipHoldWidth() ?? 0,
                    GetShipHoldHeight() ?? 0,
                    GetShipHoldMaxWeight() ?? 0);

                var containers = Containers.Select(c =>
                    new Container(c.Id, c.Length, c.Width, c.Height, c.Weight)).ToList();

                var ga = new GeneticAlgorithm(
                    new PackerEMS(),
                    GetPopulationSize() ?? 200,
                    GetGenerationsCount() ?? 100,
                    GetMutationRate() ?? 30,
                    GetTournamentSize() ?? 2,
                    GetElitism() ?? 5);

                var result = await Task.Run(() => ga.Run(shipHold, containers));

                ResultText = $"Algorithm completed!\n" +
                             $"Packed volume: {result.TotalVolume}\n" +
                             $"Utilization: {result.TotalVolume / (double)shipHold.Volume * 100:0.##}%";
            }
            catch (Exception ex)
            {
                ResultText = $"Error: {ex.Message}";
            }
            finally
            {
                IsRunning = false;
            }
        }
    }
}