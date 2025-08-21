using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
//using JIPP_Projekt.Utilities;
using JIPP_Projekt_Sem4.ViewModels;

namespace JIPP_Projekt_Sem4.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    private async void ClickBtn_Clicked(object? sender, RoutedEventArgs e)
    {
        
        if (DataContext is not MainWindowViewModel vm)
            throw new InvalidOperationException("DataContext is not MainWindowViewModel");

        await ((MainWindowViewModel)DataContext!).UpdateUsersAsync();
    }

    private async void CryptoBtn_Clicked(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not MainWindowViewModel vm)
            throw new InvalidOperationException("DataContext is not MainWindowViewModel");

        await ((MainWindowViewModel)DataContext!).UpdateCryptocurrenciesAsync();
    }
    
}