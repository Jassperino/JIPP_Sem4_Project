using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using JIPP_Projekt_Sem4.Models;
//using JIPP_Projekt_Sem4.Models;
using JIPP_Projekt_Sem4.Data;
using Microsoft.EntityFrameworkCore;

namespace JIPP_Projekt_Sem4.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    
    public ObservableCollection<User> Users { get; } = [];
    public ObservableCollection<Cryptocurrency> Cryptocurrencies { get; } = [];
    
    [ObservableProperty] private bool isUsersView;
    [ObservableProperty] private bool isCryptosView;

    partial void OnIsUsersViewChanged(bool value) => IsCryptosView = !value;
    
    [ObservableProperty]
    private IEnumerable? _displayItems;


    public async Task UpdateUsersAsync()
    {
        await using var dbContext = new SchoolDbContext();

        var usersData = await dbContext.Users
            .AsNoTracking()
            .OrderBy(s => s.Username)
            .ToListAsync();
        
        Users.Clear();
        foreach (var user in usersData) Users.Add(user);
        
        IsUsersView = true;
    }

    public async Task UpdateCryptocurrenciesAsync()
    {
        await using var dbContext = new SchoolDbContext();

        var cryptocurrencyData = await dbContext.Cryptocurrencies
            .AsNoTracking()
            .Include(c => c.User)
            .OrderBy(c => c.User.Username)
            .ToListAsync();

        Cryptocurrencies.Clear();
        foreach (var cryptocurrency in cryptocurrencyData) Cryptocurrencies.Add(cryptocurrency);
        
        IsUsersView = false; 

    }


}


