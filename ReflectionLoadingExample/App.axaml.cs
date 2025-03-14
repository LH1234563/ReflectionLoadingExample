using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using HomeModule;
using Microsoft.Extensions.DependencyInjection;
using ReflectionLoadingExample.Core;
using ReflectionLoadingExample.Core.Utils;
using ReflectionLoadingExample.ViewModels;
using ReflectionLoadingExample.Views;
using ShellModule;

namespace ReflectionLoadingExample;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        ModuleHelper.LoadDefaultModule();
        XmlHelper.LoadMoudleList();
        XmlHelper.LoadConfig();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        IOC_Initialized();
        var vm = IocHelper.ServicesProvider.GetRequiredService<MainWindowViewModel>();
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm
            };
            if (Config.ShowScreen)
            {
                var screen = new MainScreenWindow()
                {
                    DataContext = vm
                };
                screen.Show();
            }
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }

    private void IOC_Initialized()
    {
        // If you use CommunityToolkit, line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

        // Register all the services needed for the application to run
        var collection = new ServiceCollection();
        collection.AddCommonServices();
        IocHelper.ServicesProvider = collection.BuildServiceProvider();
        IocHelper.ServiceCollection = collection;
        // Creates a ServiceProvider containing services from the provided IServiceCollection
    }
}

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddSingleton<ShellViewModel>();
        collection.AddSingleton<HomeViewModel>();
        foreach (var item in XmlHelper.MoudleList)
        {
            foreach (var assemblyExportedType in item.type.Assembly.ExportedTypes)
            {
                if (assemblyExportedType.FullName.Contains("ViewModel"))
                {
                    collection.AddSingleton(assemblyExportedType);
                }
            }
        }
    }
}