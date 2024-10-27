using Avalonia.Controls;
using Avalonia.Styling;
using ServiceLib;
using ServiceLib.DataBaseContext;
using System.Linq;
namespace UI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Db db = new Db();
            //db.Users.Add(new ServiceLib.Models.User("qwe", "qwe"));
            //db.SaveChanges();
            //Qwe.Text = db.Users.FirstOrDefault(p => p.Id == 1)?.Login;
        }

        private void dropImageButtonButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
        }

        private void addImageButtonButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
        }

        private void Button_PointerEntered(object? sender, Avalonia.Input.PointerEventArgs e)
        {
            if (sender is Button button)
            {
                //button.Opacity = 0.7;
            }

            e.Handled = false;
        }

        private void Button_PointerExited(object? sender, Avalonia.Input.PointerEventArgs e)
        {
            if (sender is Button button)
            {
                button.Opacity = 1.0;
            }
        }
    }
}