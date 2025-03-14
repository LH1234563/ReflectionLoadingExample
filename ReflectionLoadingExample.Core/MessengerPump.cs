using CommunityToolkit.Mvvm.Messaging.Messages;

namespace ReflectionLoadingExample.Core;


/// <summary>
/// </summary>
public sealed class MainNavigatedToMessage : ValueChangedMessage<Type>
{
    public MainNavigatedToMessage(Type type) : base(type)
    {
    }
}
/// <summary>
/// 跳转到首页方法
/// </summary>
public sealed class MainNavigatedToHomeMessage
{

}
/// <summary>
/// 刷新续签数据事件
/// </summary>
public sealed class ResetRenewalDataMessage
{

}