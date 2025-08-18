using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using JIPP_Projekt_Sem4.Models;
using JIPP_Projekt.Data;
using Microsoft.EntityFrameworkCore;

namespace JIPP_Projekt.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _resultLabel = "Dane";

    public ObservableCollection<User> Users { get; } = [];
    public ObservableCollection<Cryptocurrency> Cryptocurrencies { get; } = [];

    public async Task UpdateUsersAsync()
    {
        await using var dbContext = new SchoolDbContext();

        var usersData = await dbContext.Users
            .AsNoTracking()
            .OrderBy(s => s.Username)
            .ToListAsync();
        
        Users.Clear();
        
        var cryptocurrencyData = await dbContext.Cryptocurrencies
            .AsNoTracking()
            .Include(c => c.User)
            .OrderBy(c => c.User.Username)
            .ToListAsync();

        Cryptocurrencies.Clear();

        var sb = new StringBuilder();
        
        sb.AppendLine($"{"Id",-10} {"Username",-20} {"Password"}");

        foreach (var user in usersData)
        {
            Users.Add(user);
            sb.AppendLine($"{user.Id,-10} {user.Username,-20} {user.Password}");
        }
        
        sb.AppendLine();
        sb.AppendLine($"{"User",-20} {"Bitcoin",-10} {"Ethereum",-10} {"Tether",-10} {"ZCash"}");

        foreach (var crypto in cryptocurrencyData)
        {
            Cryptocurrencies.Add(crypto);
            sb.AppendLine($"{crypto.User.Username,-20} {crypto.Bitcoin,-10} {crypto.Ethereum,-10} {crypto.Tether,-10} {crypto.ZCash}");
        }


        ResultLabel = sb.ToString();
    }


}


