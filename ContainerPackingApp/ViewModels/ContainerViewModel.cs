using ReactiveUI;

namespace ContainerPackingApp.ViewModels
{
    public class ContainerViewModel : ReactiveObject // Изменено с ViewModelBase на ReactiveObject
    {
        private int _id;
        private int _length;
        private int _width;
        private int _height;
        private int _weight;

        public int Id
        {
            get => _id;
            set => this.RaiseAndSetIfChanged(ref _id, value);
        }

        public int Length
        {
            get => _length;
            set => this.RaiseAndSetIfChanged(ref _length, value);
        }

        public int Width
        {
            get => _width;
            set => this.RaiseAndSetIfChanged(ref _width, value);
        }

        public int Height
        {
            get => _height;
            set => this.RaiseAndSetIfChanged(ref _height, value);
        }

        public int Weight
        {
            get => _weight;
            set => this.RaiseAndSetIfChanged(ref _weight, value);
        }
    }
}