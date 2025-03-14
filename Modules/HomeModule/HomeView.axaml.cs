using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using ReflectionLoadingExample.Core.Utils;

namespace HomeModule;

public partial class HomeView : UserControl
{
    public HomeView()
    {
        InitializeComponent();
        DataContext = IocHelper.ServicesProvider.GetRequiredService<HomeViewModel>();
    }
}