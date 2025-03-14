using System.Reflection;

namespace ReflectionLoadingExample.Core.Utils;

public class ModuleHelper
{
    private static string[] moduleDllFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*Module.dll");

    /// <summary>
    /// 加载默认模块，Home和Shell
    /// </summary>
    public static void LoadDefaultModule()
    {
        foreach (string moduleDllFile in moduleDllFiles)
        {
            if (moduleDllFile.Contains("Shell") || moduleDllFile.Contains("Home"))
            {
                Assembly.LoadFrom(moduleDllFile);
            }
        }
    }

    /// <summary>
    /// 根据Module名称，加载并获取ViewModelType
    /// </summary>
    public static Type? GetModuleType(string typeName)
    {
        // foreach (string moduleDllFile in moduleDllFiles)
        // {
        var assemble = Assembly.LoadFrom(moduleDllFiles.FirstOrDefault(a => a.Contains(typeName)));
        return assemble?.ExportedTypes.FirstOrDefault(a => a.Name.Contains(typeName + "ViewModel"));
        // }
    }
}