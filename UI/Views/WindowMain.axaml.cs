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
        private async void addImageButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            var result = await dialog.ShowAsync(this);
            if (result != null && result.Length > 0)
            {
                var filePath = result[0];
                await _viewModel.AddImageAsync(filePath);
            }
        }
        private async void dropImageButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            await _viewModel.DeleteSelectedImageAsync();
        }

        private void ListBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            if(sender is ListBox listBox)
            {
                if (listBox.SelectedItem is ImageViewModel imageModel)
                    _viewModel.SelectedImage = imageModel;
                else
                    _viewModel.IsDropEnabled = !_viewModel.IsDropEnabled;
            }
        }
    }
}