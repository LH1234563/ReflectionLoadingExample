using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ReflectionLoadingExample.Core;

namespace EntryExitModule;

public class EntryExitViewModel : PageViewModelBase
{
    private List<Type> _entryExitVMs;

    public EntryExitViewModel()
    {
        EntryExitToViewCommand =
            new RelayCommand<Type>(v =>
            {
                EntryExitVM = _entryExitVMs.FirstOrDefault(vm => vm == v);
            });
        _entryExitVMs = new List<Type>
        {
            typeof(RenewalViewModel),
            typeof(ChakaViewModel),
            typeof(PayFeesViewModel)
        };
    }

    private Type? _entryExitVM;

    public Type? EntryExitVM
    {
        get => _entryExitVM;
        set => SetProperty(ref _entryExitVM, value);
    }

    public RelayCommand<Type> EntryExitToViewCommand { get; }

    public override void OnNavigatedTo()
    {
        EntryExitVM = null;
        Messenger.Send(new ResetRenewalDataMessage());
    }

    public override void OnNavigatedFrom()
    {
    }
}