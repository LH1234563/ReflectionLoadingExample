using System.Linq;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;

namespace ReflectionLoadingExample.Views;

public partial class MainScreenWindow : Window
{
    public MainScreenWindow()
    {
        InitializeComponent();
        // 获取屏幕信息
        var screens = Screens.All;

        // 如果存在副屏幕，则获取副屏幕的分辨率 
        var secondScreen = screens[^1];
        if (screens.Any(a => !a.IsPrimary))
            secondScreen = screens.First(a => !a.IsPrimary);

        var screenBounds = secondScreen.Bounds;
        // 设置窗口的位置和大小以覆盖副屏幕的整个分辨率
        this.Position = new PixelPoint(screenBounds.X, screenBounds.Y);
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            this.WindowState = WindowState.FullScreen;
        }
    }
}