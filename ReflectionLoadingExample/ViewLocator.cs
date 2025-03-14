using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Microsoft.Extensions.DependencyInjection;
using ReflectionLoadingExample.Core;
using ReflectionLoadingExample.Core.Utils;

namespace ReflectionLoadingExample;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? param)
    {
        var paramType = param as Type;
        if (paramType is null)
            return null;
        var name = paramType.FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
        var type = paramType.Assembly.GetType(name);

        if (type != null)
        {
            var viewModel = IocHelper.ServicesProvider.GetRequiredService(paramType);
            var view = (Control)Activator.CreateInstance(type)!;
            view.DataContext = viewModel;
            return view;
        }

        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data)
    {
        return data is Type type && type.IsSubclassOf(typeof(ViewModelBase));
    }
}