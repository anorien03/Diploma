using System;
using Avalonia.Controls;
using ContainerPackingApp.ViewModels;

namespace ContainerPackingApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.DataContextChanged += OnDataContextChanged;
    }


    private void OnDataContextChanged(object sender, EventArgs e)
    {
        if (DataContext is MainWindowViewModel vm)
        {
            vm.VisualRoot = this;
        }
    }
}