using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ReflectionLoadingExample.Core;

namespace EntryExitModule;

public class RenewalViewModel : ViewModelBase
{
    public RenewalViewModel()
    {
        OnActivated();
        TypeOfEndorsementCommand =
            new RelayCommand<string?>(v =>
                {
                    RenewalEnty.TypeOfEndorsement = v;
                    EntryExitRenewalType = EntryExitRenewalType.Destination;
                }
            );
        DestinationCommand =
            new RelayCommand<string?>(v =>
                {
                    RenewalEnty.Destination = v;
                    EntryExitRenewalType = EntryExitRenewalType.EffectiveTimes;
                }
            );
        EffectiveTimesCommand =
            new RelayCommand<string?>(v =>
                {
                    RenewalEnty.EffectiveTimes = v;
                    EntryExitRenewalType = EntryExitRenewalType.TypeOfInfo;
                }
            );
        TypeOfInfoCommand =
            new RelayCommand<string?>(v => { EntryExitRenewalType = EntryExitRenewalType.PayFees; }
            );
        PayFeesCommand =
            new RelayCommand<string?>(v =>
                {
                    RenewalEnty.PayFees = v;
                    EntryExitRenewalType = EntryExitRenewalType.BusinessCard;
                    Task.Run(async () =>
                    {
                        await Task.Delay(3000);
                        Dispatcher.UIThread.Post(() => { EntryExitRenewalType = EntryExitRenewalType.Complete; });
                    });
                }
            );
        CompleteCommand =
            new RelayCommand(() => { Messenger.Send(new MainNavigatedToHomeMessage()); }
            );
    }

    public RelayCommand<string?> TypeOfEndorsementCommand { get; }
    public RelayCommand<string?> DestinationCommand { get; }
    public RelayCommand<string?> EffectiveTimesCommand { get; }
    public RelayCommand<string?> TypeOfInfoCommand { get; }
    public RelayCommand<string?> PayFeesCommand { get; }
    public RelayCommand CompleteCommand { get; }
    private EntryExitRenewalType _entryExitRenewalType;

    public EntryExitRenewalType EntryExitRenewalType
    {
        get => _entryExitRenewalType;
        set => SetProperty(ref _entryExitRenewalType, value);
    }

    private void ResetRenewalData()
    {
        EntryExitRenewalType = EntryExitRenewalType.TypeOfEndorsement;
        RenewalEnty = new RenewalModel();
    }

    protected override void OnActivated()
    {
        Messenger.Register<RenewalViewModel, ResetRenewalDataMessage>(this,
            (r, m) => ResetRenewalData());
    }

    private RenewalModel _renewalEnty = new RenewalModel();

    public RenewalModel RenewalEnty
    {
        get => _renewalEnty;
        set => SetProperty(ref _renewalEnty, value);
    }
}

public class RenewalModel : ObservableObject
{
    private string? _name = Config.DefaultName;

    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    private string? _typeOfEndorsement;

    public string? TypeOfEndorsement
    {
        get => _typeOfEndorsement;
        set => SetProperty(ref _typeOfEndorsement, value);
    }

    private string? _destination;

    public string? Destination
    {
        get => _destination;
        set => SetProperty(ref _destination, value);
    }

    private string? _effectiveTimes;

    public string? EffectiveTimes
    {
        get => _effectiveTimes;
        set => SetProperty(ref _effectiveTimes, value);
    }

    private string? _payFees;

    public string? PayFees
    {
        get => _payFees;
        set => SetProperty(ref _payFees, value);
    }

    private string? _payFeesType;

    public string? PayFeesType
    {
        get => _payFeesType;
        set => SetProperty(ref _payFeesType, value);
    }
}