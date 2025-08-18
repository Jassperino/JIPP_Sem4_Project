using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
//using JIPP_Projekt.Utilities;
using JIPP_Projekt.ViewModels;

namespace JIPP_Projekt.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void ClickBtn_Clicked(object? sender, RoutedEventArgs e)
    {
        
        if (DataContext is not MainWindowViewModel vm)
            throw new InvalidOperationException("DataContext is not MainWindowViewModel");

        await vm.UpdateUsersAsync();
    }

    private async void CryptoBtn_Clicked(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not MainWindowViewModel vm)
            throw new InvalidOperationException("DataContext is not MainWindowViewModel");

        await vm.UpdateCryptocurrenciesAsync();
    }
    
}