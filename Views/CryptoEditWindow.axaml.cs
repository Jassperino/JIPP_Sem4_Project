using System.Globalization;
using Avalonia.Controls;
using Avalonia.Interactivity;
using JIPP_Projekt_Sem4.Data;
using JIPP_Projekt_Sem4.Models;

namespace JIPP_Projekt_Sem4.Views;

public partial class CryptoEditWindow : Window
{
    private readonly Cryptocurrency _crypto;

    public CryptoEditWindow(Cryptocurrency crypto)
    {
        InitializeComponent();
        _crypto = crypto;
        BitcoinBox.Text = crypto.Bitcoin.ToString(CultureInfo.InvariantCulture);
        EthereumBox.Text = crypto.Ethereum.ToString(CultureInfo.InvariantCulture);
        TetherBox.Text = crypto.Tether.ToString(CultureInfo.InvariantCulture);
        ZCashBox.Text = crypto.ZCash.ToString(CultureInfo.InvariantCulture);
    }

    private async void Save_Click(object? sender, RoutedEventArgs e)
    {
        await using var dbContext = new SchoolDbContext();
        var entity = await dbContext.Cryptocurrencies.FindAsync(_crypto.Id);
        if (entity != null)
        {
            if (decimal.TryParse(BitcoinBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var btc))
                entity.Bitcoin = btc;
            if (decimal.TryParse(EthereumBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var eth))
                entity.Ethereum = eth;
            if (decimal.TryParse(TetherBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var usd))
                entity.Tether = usd;
            if (decimal.TryParse(ZCashBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var zec))
                entity.ZCash = zec;
            await dbContext.SaveChangesAsync();
        }
        Close(true);
    }

    private void Cancel_Click(object? sender, RoutedEventArgs e) => Close(false);
}