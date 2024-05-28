using DIWpfDemo.StartupHelpers;
using DIWpfDemoApp.Library;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace DIWpfDemo;

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }
    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                // Add the dependency injection
                services.AddSingleton<MainWindow>();
                services.AddTransient<IDataAccess, DataAccess>();
                //services.AddTransient<ChildForm>();
                services.AddFormFactory<ChildForm>();
            })
            .Build();

    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var startUpForm = AppHost.Services.GetRequiredService<MainWindow>();
        startUpForm.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}
