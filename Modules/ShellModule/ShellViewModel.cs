using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HomeModule;
using Microsoft.Extensions.DependencyInjection;
using ReflectionLoadingExample.Core;
using ReflectionLoadingExample.Core.Utils;

namespace ShellModule;

public class ShellViewModel : ViewModelBase
{
    /// <summary>
    /// 
    /// </summary>
    private List<PageViewModelBase> _viewModelPages = new()
        { IocHelper.ServicesProvider.GetRequiredService<HomeViewModel>() };

    public ShellViewModel()
    {
        foreach (var item in XmlHelper.MoudleList)
        {
            _viewModelPages.Add(IocHelper.ServicesProvider.GetRequiredService(item.type) as PageViewModelBase);
        }

        CurrentPage = _viewModelPages[0];
        HomeCommand = new RelayCommand(() => { CurrentPage = _viewModelPages[0]; });
        OnActivated();
    }

    public RelayCommand HomeCommand { get; }

    /// <summary>
    /// 
    /// </summary>
    private PageViewModelBase _currentPage;

    public PageViewModelBase CurrentPage
    {
        get => _currentPage;
        set
        {
            _currentPage?.OnNavigatedFrom();
            if (SetProperty(ref _currentPage, value))
            {
                _currentPage?.OnNavigatedTo();
            }
        }
    }

    protected override void OnActivated()
    {
        Messenger.Register<ShellViewModel, MainNavigatedToMessage>(this,
            (r, m) =>
            {
                var page = _viewModelPages.FirstOrDefault(a => a.GetType() == m.Value);
                if (page != null)
                {
                    CurrentPage = page;
                }
            });
        Messenger.Register<ShellViewModel, MainNavigatedToHomeMessage>(this,
            (r, m) => { CurrentPage = _viewModelPages[0]; });
    }
}