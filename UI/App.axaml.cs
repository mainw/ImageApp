using Autofac;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Serilog;

namespace UI
{
    public partial class App : Application
    {
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
            var builder = new ContainerBuilder();

            // Регистрация Serilog
            builder.RegisterInstance(Log.Logger).As<ILogger>();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }
        private void OnExit(object sender, ControlledApplicationLifetimeExitEventArgs e)
        {
            Log.Information("App's shotdown");
            Log.CloseAndFlush();
        }
    }
}