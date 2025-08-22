using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using JIPP_Projekt_Sem4.Data;
using JIPP_Projekt_Sem4.Models;

namespace JIPP_Projekt_Sem4.Views;

public partial class UserEditWindow : Window
{
    private readonly User _user;

    public UserEditWindow(User user)
    {
        InitializeComponent();
        _user = user;
        UsernameBox.Text = user.Username;
        PasswordBox.Text = user.Password;
        if (user.Birthday.HasValue)
            BirthdayPicker.SelectedDate = user.Birthday.Value;
    }

    private async void Save_Click(object? sender, RoutedEventArgs e)
    {
        await using var dbContext = new SchoolDbContext();
        var entity = await dbContext.Users.FindAsync(_user.Id);
        if (entity != null)
        {
            entity.Username = UsernameBox.Text ?? string.Empty;
            entity.Password = PasswordBox.Text ?? string.Empty;
            entity.Birthday = BirthdayPicker.SelectedDate?.DateTime;
        }
        else
        {
            var newUser = new User
            {
                Id = 0,
                Username = UsernameBox.Text ?? string.Empty,
                Password = PasswordBox.Text ?? string.Empty,
                Birthday = BirthdayPicker.SelectedDate?.DateTime
            };
            dbContext.Users.Add(newUser);
        }

        await dbContext.SaveChangesAsync();
        Close(true);
    }

    private void Cancel_Click(object? sender, RoutedEventArgs e) => Close(false);
}