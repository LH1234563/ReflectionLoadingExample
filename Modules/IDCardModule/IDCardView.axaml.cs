using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using ReflectionLoadingExample.Core.Utils;

namespace IDCardModule;

public partial class IDCardView : UserControl
{
    public IDCardView()
    {
        InitializeComponent();
        DataContext = IocHelper.ServicesProvider.GetRequiredService<IDCardViewModel>();
    }
}