using System;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProcessMonitor.Models;
using ProcessMonitor.Services;
using ProcessMonitor.ViewModels;
using ProcessMonitor.Views;
using ProcessMonitor.Views.Pages;
using Wpf.Ui;

namespace ProcessMonitor;

public partial class App
{
    private static readonly IHost Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration(c =>
        {
            c.SetBasePath(Path.GetDirectoryName(AppContext.BaseDirectory) ?? string.Empty);
        })
        .ConfigureServices((context, services) =>
        {
            services.AddHostedService<ApplicationHostService>();
            services.AddSingleton<IPageService, PageService>();

            services.AddSingleton<IThemeService, ThemeService>();

            services.AddSingleton<ITaskBarService, TaskBarService>();

            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<INavigationWindow, MainWindow>();
            services.AddSingleton<MainWindowViewModel>();

            services.AddSingleton<ProcessesPage>();
            services.AddSingleton<ProcessesViewModel>();

            services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));
        })
        .Build();

    public static T? GetService<T>() where T : class
    {
        return Host.Services.GetService(typeof(T)) as T;
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
    }

    private async void OnExit(object sender, ExitEventArgs e)
    {
        await Host.StopAsync();
        Host.Dispose();
    }

    private async void OnStartup(object sender, StartupEventArgs e)
    {
        await Host.StartAsync();
    }
}