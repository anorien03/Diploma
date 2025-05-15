using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ContainerPackingApp.Models;
using ContainerPackingApp.Models.Diploma.Models;
using ContainerPackingApp.Packers;
using ReactiveUI;

namespace ContainerPackingApp.ViewModels
{
    public class MainWindowViewModel : ReactiveObject // Изменено с ViewModelBase на ReactiveObject
    {
        private int _populationSize = 100;
        private int _generationsCount = 50;
        private int _mutationRate = 5;
        private int _tournamentSize = 5;
        private int _elitism = 10;

        private int _shipHoldLength;
        private int _shipHoldWidth;
        private int _shipHoldHeight;
        private int _shipHoldMaxWeight;

        private string _resultText = "";
        private bool _isRunning;

        public ObservableCollection<ContainerViewModel> Containers { get; } = new ObservableCollection<ContainerViewModel>();

        public int PopulationSize
        {
            get => _populationSize;
            set => this.RaiseAndSetIfChanged(ref _populationSize, value);
        }

        public int GenerationsCount
        {
            get => _generationsCount;
            set => this.RaiseAndSetIfChanged(ref _generationsCount, value);
        }

        public int MutationRate
        {
            get => _mutationRate;
            set => this.RaiseAndSetIfChanged(ref _mutationRate, value);
        }

        public int TournamentSize
        {
            get => _tournamentSize;
            set => this.RaiseAndSetIfChanged(ref _tournamentSize, value);
        }

        public int Elitism
        {
            get => _elitism;
            set => this.RaiseAndSetIfChanged(ref _elitism, value);
        }

        public int ShipHoldLength
        {
            get => _shipHoldLength;
            set => this.RaiseAndSetIfChanged(ref _shipHoldLength, value);
        }

        public int ShipHoldWidth
        {
            get => _shipHoldWidth;
            set => this.RaiseAndSetIfChanged(ref _shipHoldWidth, value);
        }

        public int ShipHoldHeight
        {
            get => _shipHoldHeight;
            set => this.RaiseAndSetIfChanged(ref _shipHoldHeight, value);
        }

        public int ShipHoldMaxWeight
        {
            get => _shipHoldMaxWeight;
            set => this.RaiseAndSetIfChanged(ref _shipHoldMaxWeight, value);
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
            if (IsRunning) return;

            IsRunning = true;
            ResultText = "Running algorithm...";

            try
            {
                // Convert UI models to domain models
                var shipHold = new ShipHold(ShipHoldLength, ShipHoldWidth, ShipHoldHeight, ShipHoldMaxWeight);
                var containers = Containers.Select(c =>
                    new Container(c.Id, c.Length, c.Width, c.Height, c.Weight)).ToList();

                // Create and run genetic algorithm
                var ga = new GeneticAlgorithm(
                    new PackerEMS(), // You need to implement this
                    PopulationSize,
                    GenerationsCount,
                    MutationRate,
                    TournamentSize,
                    Elitism);

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