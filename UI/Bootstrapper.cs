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

            
            builder.RegisterInstance(Log.Logger).As<ILogger>().SingleInstance();

            
            builder.RegisterType<MainWindowViewModel>().AsSelf().SingleInstance();
            builder.RegisterType<LoginViewModel>().AsSelf().SingleInstance();

            

            return builder.Build();
        }
    }
}
