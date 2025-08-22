using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
//using JIPP_Projekt.Utilities;
using JIPP_Projekt_Sem4.Models;
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
  
    
    private async void EditUser_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is User user)
        {
            var window = new UserEditWindow(user);
            var result = await window.ShowDialog<bool?>(this);
            if (result == true && DataContext is MainWindowViewModel vm)
            {
                await vm.UpdateUsersAsync();
            }
        }
    }

    private async void EditCrypto_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.DataContext is Cryptocurrency crypto)
        {
            var window = new CryptoEditWindow(crypto);
            var result = await window.ShowDialog<bool?>(this);
            if (result == true && DataContext is MainWindowViewModel vm)
            {
                await vm.UpdateCryptocurrenciesAsync();
            }
        }
    }

}