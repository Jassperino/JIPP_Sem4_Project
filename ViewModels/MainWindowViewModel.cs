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

    public async Task UpdateUsersAsync()
    {
        await using var dbContext = new SchoolDbContext();

        var usersData = await dbContext.Users
            .AsNoTracking()
            .OrderBy(s => s.Username)
            .ToListAsync();
        
        Users.Clear();
        
        var sb = new StringBuilder();

        foreach (var user in usersData)
        {
            Users.Add(user);
            sb.AppendLine($"Id: {user.Id}, Username: {user.Username}, Password: {user.Password}");
        }

        ResultLabel = sb.ToString();
    }


}


