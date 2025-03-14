using Microsoft.Extensions.DependencyInjection;

namespace ReflectionLoadingExample.Core.Utils;

public class IocHelper
{
    public static IServiceProvider? ServicesProvider;
    public static IServiceCollection? ServiceCollection;
}