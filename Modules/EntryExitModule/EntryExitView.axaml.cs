using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using ReflectionLoadingExample.Core.Utils;

namespace EntryExitModule;

public partial class EntryExitView : UserControl
{
    public EntryExitView()
    {
        InitializeComponent();
        DataContext = IocHelper.ServicesProvider.GetRequiredService<EntryExitViewModel>();
    }
}