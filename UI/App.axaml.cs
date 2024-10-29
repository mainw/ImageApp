using Autofac;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using UI.ViewModels;
using Serilog;
using System;
using Avalonia.Controls;

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
                ChangeMainWindow(typeof(LoginWindow), typeof(LoginViewModel));
                desktop.Exit += OnExit;
            }
            base.OnFrameworkInitializationCompleted();
        }
        public void ChangeMainWindow(Type typeView, Type typeModel)
        {
            object viewObject = Activator.CreateInstance(typeView);
            object modelObject = _container.GetType().GetMethod("Resolve")?.MakeGenericMethod(typeModel).Invoke(_container, new object[] { });

            //typeView.GetProperty("DataContext").SetValue(viewObject, modelObject);
            (ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow = (Window)viewObject;
        }
        private void OnExit(object sender, ControlledApplicationLifetimeExitEventArgs e)
        {
            Log.Information("App is shutting down");
            Log.CloseAndFlush();
        }
    }
}