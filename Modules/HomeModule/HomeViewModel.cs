using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ReflectionLoadingExample.Core;
using ReflectionLoadingExample.Core.Utils;

namespace HomeModule;

public class HomeViewModel : PageViewModelBase
{
    public HomeViewModel()
    {
        NavigatedToCommand = new RelayCommand<Type>(OnNavigatedTo);
        TypeList = new(XmlHelper.MoudleList);
    }

    private void OnNavigatedTo(Type pageType)
    {
        Messenger.Send(new MainNavigatedToMessage(pageType));
    }

    public RelayCommand<Type> NavigatedToCommand { get; }

    private ObservableCollection<MoudleEntity> _typeList;

    public ObservableCollection<MoudleEntity> TypeList
    {
        get => _typeList;
        set => SetProperty(ref _typeList, value);
    }

    public override void OnNavigatedTo()
    {
    }

    public override void OnNavigatedFrom()
    {
    }
}