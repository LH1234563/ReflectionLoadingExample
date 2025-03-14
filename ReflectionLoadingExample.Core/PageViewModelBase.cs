namespace ReflectionLoadingExample.Core;

public abstract class PageViewModelBase : ViewModelBase
{
    
    /// <summary>
    /// 进入导航页面事件
    /// </summary>
    public abstract void OnNavigatedTo();

    /// <summary>
    /// 离开导航页面事件
    /// </summary>
    public abstract void OnNavigatedFrom();
}