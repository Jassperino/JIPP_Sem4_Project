using System;
using System.Collections.ObjectModel;
using System.Linq;
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

    public void UpdateUsers()
    {
        using var dbContext = new SchoolDbContext();
        
        IQueryable<User> users = dbContext.Users.AsQueryable();

        users = users.OrderBy(s => s.Username);
        
        var usersData = users.ToList();
        
        Users.Clear();

        foreach (var user in usersData)
        {
            Users.Add(user);
        }

        ResultLabel = users.ToQueryString();
    }


}


