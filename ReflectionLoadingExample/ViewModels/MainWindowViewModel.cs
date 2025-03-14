using ReflectionLoadingExample.Core;

namespace ReflectionLoadingExample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!"; 
}