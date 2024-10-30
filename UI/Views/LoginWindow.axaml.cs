using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;
using UI.ViewModels;

namespace UI;

public partial class LoginWindow : Window
{
    public LoginViewModel LoginViewModel
    {
        get
        {
            return DataContext as LoginViewModel;
        }
    }
    public LoginWindow()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();
    }

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        bool isAuthorize = await LoginViewModel.LoginCommand.Execute();
        if (isAuthorize)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        //((App)App.Current).ChangeMainWindow(typeof(MainWindow), typeof(MainWindowViewModel));

    }
}