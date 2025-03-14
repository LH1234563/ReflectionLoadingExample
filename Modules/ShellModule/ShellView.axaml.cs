using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using ReflectionLoadingExample.Core.Utils;

namespace ShellModule;

public partial class ShellView : UserControl
{
    public ShellView()
    {
        InitializeComponent();
        DataContext = IocHelper.ServicesProvider.GetRequiredService<ShellViewModel>();
    }
}