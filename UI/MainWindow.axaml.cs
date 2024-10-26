using Avalonia.Controls;
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
    }
}