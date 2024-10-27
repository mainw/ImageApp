using Avalonia.Controls;
using Avalonia.Interactivity;
using UI.ViewModels;
using Avalonia.Styling;
using System.Linq;
namespace UI
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
        }
    }
}