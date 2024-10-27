using Autofac;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using UI.ViewModels;
using Serilog;

namespace UI
{
    public partial class App : Application
    {
        private IContainer _container;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Logs/app-log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public override void OnFrameworkInitializationCompleted()
        {
            _container = Bootstrapper.ConfigureContainer();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var mainWindow = new MainWindow
                {
                    DataContext = _container.Resolve<MainWindowViewModel>()
                };
                desktop.MainWindow = mainWindow;
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void OnExit(object sender, ControlledApplicationLifetimeExitEventArgs e)
        {
            Log.Information("App is shutting down");
            Log.CloseAndFlush();
        }
    }
}