using System.Globalization;
using Avalonia.Data.Converters;
using ReflectionLoadingExample.Core;

namespace ShellModule;

public class ViewModelToTypeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is ViewModelBase)
        {
            return value.GetType();
        }

        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}