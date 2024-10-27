using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UI.ViewModels;

namespace UI;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        DataContext = new LoginViewModel();
    }
}