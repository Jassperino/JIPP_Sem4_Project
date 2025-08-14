using System;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;
//using JIPP_Projekt.Utilities;
using JIPP_Projekt.ViewModels;
using Microsoft.Data.SqlClient;

namespace JIPP_Projekt.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ClickBtn_Clicked(object? sender, RoutedEventArgs e)
    {
        
        if (DataContext is not MainWindowViewModel vm)
            throw new InvalidOperationException("DataContext is not MainWindowViewModel");
        string connectionString =
            "Data Source=127.0.0.1,1433;Initial Catalog=JiPP_Projekt;User Id=sa;Password=JiPP4@Passw0rd;Encrypt=False;TrustServerCertificate=True;";


        using var sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();

        using var sqlCommand = new SqlCommand("SELECT Id, Username FROM Users", sqlConnection);
        using var sqlDataReader = sqlCommand.ExecuteReader();

        var stringBuilder = new StringBuilder();

        // foreach (var User in sqlDataReader.MapUsers())
        // {
        //     stringBuilder.AppendLine($"Id: {User.Id}, Name: {User.Name}");
        // }

        stringBuilder.AppendLine($"SQL: {sqlCommand.CommandText}");

        vm.ResultLabel = stringBuilder.ToString();

        sqlConnection.Close();
        

        
    }
}