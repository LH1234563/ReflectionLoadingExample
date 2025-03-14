namespace EntryExitModule;

/// <summary>
/// 续签类型
/// </summary>
public enum EntryExitRenewalType
{
    // 注签种类
    TypeOfEndorsement,
    // 前往地
    Destination,
    // 有效次数
    EffectiveTimes,
    // 注签信息确认
    TypeOfInfo,
    // 续签->缴费
    PayFees,
    // 缴费方式
    // PayFeesType,
    // 续签->制卡
    BusinessCard,
    // 续签->完成
    Complete
}