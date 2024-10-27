using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Serilog;
using API.ImageService.DataBaseContext;
using API.ImageService.Repository;
using API.ImageService.Services;

var builder = WebApplication.CreateBuilder(args);

// ��������� Serilog (������ ���� ������������)
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// ������������� Serilog
builder.Host.UseSerilog();

// ������������� Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // ����������� ������������
    containerBuilder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<ImageRepository>().As<IImageRepository>().InstancePerLifetimeScope();

    // ����������� ��������
    containerBuilder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
    containerBuilder.RegisterType<ImageService>().As<IImageService>().InstancePerLifetimeScope();
});

// ��������� DbContext ����� DI
builder.Services.AddDbContext<Db>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ���������� �������� � ���������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ������������ pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();