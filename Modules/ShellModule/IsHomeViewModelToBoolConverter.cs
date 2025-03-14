using System.Globalization;
using Avalonia.Data.Converters;
using HomeModule;

namespace ShellModule;

public class IsHomeViewModelToBoolConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is HomeViewModel;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}