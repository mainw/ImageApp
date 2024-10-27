using Autofac;
using Serilog;
using UI.ViewModels;
namespace UI
{
    public static class Bootstrapper
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Регистрация логгера
            builder.RegisterInstance(Log.Logger).As<ILogger>().SingleInstance();

            // Регистрация ViewModels
            builder.RegisterType<MainWindowViewModel>().AsSelf().SingleInstance();
            builder.RegisterType<LoginViewModel>().AsSelf().SingleInstance();

            // Другие регистрации по необходимости

            return builder.Build();
        }
    }
}
