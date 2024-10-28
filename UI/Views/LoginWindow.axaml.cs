using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UI.ViewModels;

namespace UI;

public partial class LoginWindow : Window
{
    public LoginViewModel LoginViewModel { get; }
    public LoginWindow()
    {
        InitializeComponent();
        LoginViewModel = new LoginViewModel();
        DataContext = LoginViewModel;
    }
}